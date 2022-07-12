using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }

        //ask about changing this from private to public
        public bool busted;

        public Hand()
        {
            Cards = new List<Card>();
            busted = false;
        }

        public void AddRandomCard(bool visible)
        {
            Card newCard = new Card(visible);
            Cards.Add(newCard);
        }

        public string CardsString()
        {
            StringBuilder builder = new StringBuilder();
            foreach( Card thisCard in Cards )
            {
                builder.Append(thisCard + " ");
            }

            if (busted)
            {
                builder.Append("BUSTED");
            }

            return builder.ToString().Trim();
        }
    }
}
