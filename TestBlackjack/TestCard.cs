using NUnit.Framework;
using Moq;
using BlackJack;
using System;

namespace TestBlackjack
{
    public class TestCard
    {
        private Mock<Card> mockCard;
        private Card testCard;

        [SetUp]
        public void Setup()
        {
            mockCard = new Mock<Card>() { CallBase = true };
            testCard = new Card(true);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void Test_Card_Constructor_AssignsVisibilityCorrectly(bool setValue)
        {
            testCard = new Card(setValue);

            Assert.AreEqual(setValue, testCard.Visible);
        }

        [Test]
        public void Test_Card_CreateRandomCard_CallsRandomNumber()
        {
            mockCard.Setup(card => card.RandomNum(null)).Returns(2);

            mockCard.Object.create_random_card(true);

            Assert.AreEqual(true, mockCard.Object.Visible);
            Assert.AreEqual(2, mockCard.Object.Value);

            mockCard.Verify(a => a.RandomNum(null), Times.Once);            
        }

        [Test]
        public void Test_Card_RandomNum_MinAndMaxCorrect()
        {
            int minimum = 2;
            int maximum = 11;

            for (int i = 0; i < 20; i++ )
            {
                int newValue = testCard.RandomNum(null);
                Assert.IsTrue(newValue >= minimum && newValue <= maximum);
            }
        }

        [TestCase(56456, 8)]
        public void Test_Card_RandomNum_SeedResultsInSameRandomNumber(int Seed, int ExpectedValue)
        {
            int newValue = testCard.RandomNum(Seed);
            Assert.AreEqual(ExpectedValue, newValue);

        }

        [Test]
        public void Test_DisplayCard_CardAlreadyVisible_ExceptionThrown()
        {
            testCard.Visible = true;

            try
            {
                testCard.DisplayCard();
            }
            catch ( Exception ee)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail("Exception wasn't thrown");
        }

        public void Test_DisplayCard_CardNotDisplayed_VisibleSetToTrue()
        {
            testCard.Visible = false;

            testCard.DisplayCard();

            Assert.AreEqual(true, testCard.Visible);
        }

        public void Test_ToString_CardNotVisible_HiddenDisplayed()
        {
            testCard.Visible = false;

            string cardString = testCard.ToString();

            Assert.AreEqual("(hidden)", cardString);
        }

        public void Test_ToString_CardVisible_ShowValue()
        {
            testCard.Visible = true;

            string expectedString = testCard.Value.ToString();

            string cardString = testCard.ToString();

            Assert.AreEqual(expectedString, cardString);
        }
    }
}
