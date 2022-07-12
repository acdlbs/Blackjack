using NUnit.Framework;
using Moq;
using BlackJack;
using System.Collections.Generic;

namespace TestBlackjack
{
    public class TestGame
    {
        private Game g1;
        private Mock<Player> mockPlayer;

        [SetUp]
        public void Setup()
        {
            g1 = new Game();
            mockPlayer = new Mock<Player>() { CallBase = true };
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //test to check for proper player count
        [TestCase(0)]
        [TestCase(4)]
        [Test]
        public void Test_Game_ConfigurePlayers_Count(int playerCount)
        {
            g1.ConfigurePlayers(playerCount);

            if (playerCount > 0)
                Assert.AreEqual(playerCount, g1.Players.Count);
            else
                Assert.AreEqual(null, g1.Players);
        }

        //test to check if dealer was made
        [TestCase(0)]
        [TestCase(4)]
        [Test]
        public void Test_Game_ConfigurePlayers_Dealer(int playerCount)
        {
            g1.ConfigurePlayers(playerCount);
            
            if (playerCount > 0)
                Assert.AreEqual("Dealer", g1.Dealer.Name);
            else
                Assert.AreEqual(null, g1.Dealer);
        }
        //TODO check if names initialized correctly

        //check to see if AddInitialHand is called
        [Test]
        public void Test_Game_DealInitialCards_AddInitialHand()
        {
            mockPlayer.Object.AddInitialHand();
            mockPlayer.Verify(a => a.AddInitialHand(), Times.Once);
        }

        [Test]
        public void Test_Game_DealInitialCards_AddInitialHand_Dealer()
        {
            mockPlayer.Setup(player => player.Name).Returns("Dealer");
            mockPlayer.Object.AddInitialDealerHand();
            mockPlayer.Verify(a => a.AddInitialDealerHand(), Times.Once);
        }

        //TODO ask DealInitialCard -- are we on right track?
        //[Test]
        //public void Test_Game_DealInitalCards_AddInitialHand_AllPlayers()
        //{
        //    Mock<Game> mockGame = new Mock<Game>() { CallBase = true };
        //    List<Mock<Player>> mList = new List<Mock<Player>>();
        //    mList.Add(new Mock<Player>("Player 1"));
        //    mList.Add(new Mock<Player>("Player 2"));
        //    mList.Add(new Mock<Player>("Player 3"));

        //    mockGame.Setup(game => game.Players).Returns(mList);

        //}


    }
}
