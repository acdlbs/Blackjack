using NUnit.Framework;
using Moq;
using BlackJack;
using System;
using System.IO;

namespace TestBlackjack
{
    public class TestController
    {
        private Controller controller;
        private Mock<Game> mockGame;

        [SetUp]
        public void Setup()
        {
            // Create the controller to test
            controller = new Controller();

            // We will mock the game to see that methods are called correctly
            mockGame = new Mock<Game>() { CallBase = true };

            // Use our mocked game in the controller
            controller.CurrentGame = mockGame.Object;
        }

        [TestCase(-1, true)]
        [TestCase(0, true)]
        [TestCase(1, false)]
        public void Test_StartGame_ZeroOrNegativePlayerCount_ThrowsException(int PlayerCount, bool ThrowsException)
        {
            bool exceptionCalled = false;

            try
            {
                controller.StartGame(PlayerCount);
            }
            catch (Exception ee)
            {
                exceptionCalled = true;
            }

            Assert.AreEqual(ThrowsException, exceptionCalled);

        }

        [Test]
        public void Test_StartGame_ValidPlayerCount_SetsUpGame()
        {
            int playersCount = 11;

            mockGame.Setup(g => g.ConfigurePlayers(playersCount));
            mockGame.Setup(g => g.DealInitialCards());

            Game returnGame = controller.StartGame(playersCount);

            // Verify the methods on the game are called correctly and once
            mockGame.Verify(g => g.ConfigurePlayers(playersCount), Times.Once);
            mockGame.Verify(g => g.DealInitialCards(), Times.Once);

            // Returns the correct game
            Assert.AreEqual(returnGame, mockGame.Object);
        }

        [Test]
        public void Test_DisplayGame_IncludesAllPlayersAndDealer()
        {
            controller.StartGame(2);

            StringWriter writer = new StringWriter();
            controller.DisplayGame(writer);
            string output = writer.ToString();

            Assert.IsTrue(output.IndexOf("Player 1 Hand") >= 0, "Player 1 not included");
            Assert.IsTrue(output.IndexOf("Player 2 Hand") >= 0, "Player 2 not included");
            Assert.IsTrue(output.IndexOf("Dealer Hand") >= 0, "Dealer not included");

            // So.. what happened to mocking in this example?
            // Well.. it was hard.  Making mocking work with this example would
            // have required lots and lots of plumbing.
            // So, we are testing more than just that the DisplayGame method
            // calls the right methods in the Players, but this is okay.
        }
    }
}
