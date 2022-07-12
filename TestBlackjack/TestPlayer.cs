using NUnit.Framework;
using Moq;
using BlackJack;
using System.IO;

namespace TestBlackjack
{
    public class TestPlayer
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_Constructors_InitializeHands()
        {
            Player testPlayer1 = new Player("Name");
            Assert.IsNotNull(testPlayer1.Hands);

            Player testPlayer2 = new Player();
            Assert.IsNotNull(testPlayer2.Hands);

        }

        [Test]
        public void Test_AddInitialHand_InitializesHand()
        {
            Player testPlayer = new Player("Name");
            testPlayer.AddInitialHand();

            Assert.AreEqual(1, testPlayer.Hands.Count);
            Assert.AreEqual(2, testPlayer.Hands[0].Cards.Count);
            Assert.IsTrue(testPlayer.Hands[0].Cards[0].Visible);
            Assert.IsTrue(testPlayer.Hands[0].Cards[1].Visible);
            Assert.IsTrue(IsRandomCardValue(testPlayer.Hands[0].Cards[0]));
            Assert.IsTrue(IsRandomCardValue(testPlayer.Hands[0].Cards[1]));
        }
        
        [Test]
        public void Test_AddInitialDealerHand_InitializesHand()
        {
            Player testPlayer = new Player("Dealer");
            testPlayer.AddInitialDealerHand();

            Assert.AreEqual(1, testPlayer.Hands.Count);
            Assert.AreEqual(2, testPlayer.Hands[0].Cards.Count);
            Assert.IsTrue(testPlayer.Hands[0].Cards[0].Visible);
            Assert.IsFalse(testPlayer.Hands[0].Cards[1].Visible);
            Assert.IsTrue(IsRandomCardValue(testPlayer.Hands[0].Cards[0]));
            Assert.IsTrue(IsRandomCardValue(testPlayer.Hands[0].Cards[1]));
        }

        private bool IsRandomCardValue(Card testCard)
        {
            return (testCard.Value >= 2) && (testCard.Value <= 11);
        }

        [Test]
        public void Test_DisplayPlayer_MultihandPlayer_ExecutesDisplayMultiHand()
        {
            Mock<Player> mockPlayer = new Mock<Player>() { CallBase = true };
            Player testPlayer = mockPlayer.Object;
            testPlayer.Name = "Multihander";

            testPlayer.AddInitialHand();
            testPlayer.AddInitialHand();

            Assert.AreEqual(2, testPlayer.Hands.Count);

            StringWriter writer = new StringWriter();

            mockPlayer.Setup(p => p.displayMultiHand(writer, true));
            mockPlayer.Setup(p => p.displaySingleHand(writer, true));

            testPlayer.DisplayPlayer(writer, true);

            mockPlayer.Verify(p => p.displayMultiHand(writer, true), Times.Once);
            mockPlayer.Verify(p => p.displaySingleHand(writer, true), Times.Never);
        }

        [Test]
        public void Test_DisplayPlayer_SinglehandPlayer_ExecutesDisplaySingleHand()
        {
            Mock<Player> mockPlayer = new Mock<Player>() { CallBase = true };
            Player testPlayer = mockPlayer.Object;
            testPlayer.Name = "SingleHander";

            testPlayer.AddInitialHand();

            Assert.AreEqual(1, testPlayer.Hands.Count);

            StringWriter writer = new StringWriter();

            mockPlayer.Setup(p => p.displayMultiHand(writer, true));
            mockPlayer.Setup(p => p.displaySingleHand(writer, true));

            testPlayer.DisplayPlayer(writer, true);

            mockPlayer.Verify(p => p.displayMultiHand(writer, true), Times.Never);
            mockPlayer.Verify(p => p.displaySingleHand(writer, true), Times.Once);
        }

        [TestCase(true, "*Player 1\r\n\tHand 1: 1 2\r\n\tHand 2: 3 4\r\n")]
        [TestCase(false, " Player 1\r\n\tHand 1: 1 2\r\n\tHand 2: 3 4\r\n")]
        public void Test_displayMultiHand_CorrectDisplay(bool currentPlayer, string expected)
        {
            Player newPlayer = new Player("Player 1");

            Hand newHand = new Hand();
            newHand.Cards.Add(new Card(true) { Value = 1 });
            newHand.Cards.Add(new Card(true) { Value = 2 });
            newPlayer.Hands.Add(newHand);

            Hand newHand2 = new Hand();
            newHand2.Cards.Add(new Card(true) { Value = 3 });
            newHand2.Cards.Add(new Card(true) { Value = 4 });
            newPlayer.Hands.Add(newHand2);

            StringWriter writer = new StringWriter();

            newPlayer.displayMultiHand(writer, currentPlayer);

            string result = writer.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestCase(true, "*Player 1 Hand: 1 2\r\n")]
        [TestCase(false, " Player 1 Hand: 1 2\r\n")]
        public void Test_displaySingleHand_CorrectDisplay(bool currentPlayer, string expected)
        {
            Player newPlayer = new Player("Player 1");

            Hand newHand = new Hand();
            newHand.Cards.Add(new Card(true) { Value = 1 });
            newHand.Cards.Add(new Card(true) { Value = 2 });
            newPlayer.Hands.Add(newHand);

            StringWriter writer = new StringWriter();

            newPlayer.displaySingleHand(writer, currentPlayer);

            string result = writer.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
