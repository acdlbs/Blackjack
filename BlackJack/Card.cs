using System;

namespace BlackJack
{
    public class Card
    {
        public bool Visible { get; set; }

        public int Value { get; set; }

        public Card(bool visible)
        {
            create_random_card(visible);
        }

        public Card()
        {
            
        }

        public virtual void create_random_card(bool visible)
        {
            Visible = visible;
            Value = RandomNum(null);
        }

        public virtual int RandomNum(int? Seed)
        {
            Random random;

            if (Seed.HasValue)
                random = new Random(Seed.Value);
            else
                random = new Random();

            return random.Next(2, 11);
        }

        public void DisplayCard()
        {
            if (Visible)
            {
                throw new ApplicationException("This card is already visible!");
            }
            else
            {
                Visible = true;
            }
        }

        public override string ToString()
        {
            if ( Visible )
            {
                return Value.ToString();
            }
            else
            {
                return "(hidden)";
            }
        }
    }
}
