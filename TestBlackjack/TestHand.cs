using NUnit.Framework;
using Moq;
using BlackJack;

namespace TestBlackjack
{
    public class TestHand
    {
        
        public Hand hand;
        public Card cardOne;
        public Card cardTwo;
        

        [SetUp] 
         
        public void Setup()
        {
            hand = new Hand();
            cardOne = new Card();
            cardTwo = new Card();
        }

        [Test]
        public void Test_Hand_AddRandomCard_CardSetToVisible()
        {
            hand.AddRandomCard(true);
            Assert.IsTrue(hand.Cards[0].Visible);
        }

        [Test]
      
        public void Test_Hand_CardString_IsNotBusted()
        {
           
            hand.AddRandomCard(true);
            hand.AddRandomCard(true);
            hand.Cards[0].Value = 5;
            hand.Cards[1].Value = 4;
            Assert.AreEqual("5 4 6", hand.CardsString());
            
        }

        [Test]

        public void Test_Hand_CardString_IsBusted()

        {

            hand.AddRandomCard(true);
            hand.AddRandomCard(true);
            hand.Cards[0].Value = 5;
            hand.Cards[1].Value = 4;
            hand.busted = true;
            Assert.AreEqual("5 4 BUSTED", hand.CardsString());

        }
        //public string CardsString()
        //{
        //    StringBuilder builder = new StringBuilder();
        //    foreach (Card thisCard in Cards)
        //    {
        //        builder.Append(thisCard + " ");
        //    }

        //    if (busted)
        //    {
        //        builder.Append("BUSTED");
        //    }

        //    return builder.ToString().Trim();
        //}
    }
}
