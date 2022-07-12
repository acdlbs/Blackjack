using System.Collections.Generic;
using System.IO;

namespace BlackJack
{
    public class Player
    {
        public List<Hand> Hands { get; private set; }
        public virtual string Name { get; set; }

        public Player(string Name)
        {
            Hands = new List<Hand>();
            this.Name = Name;
        }

        public Player()
        {
            Hands = new List<Hand>();
        }

        /*
         * check
         * - not null
         * - two cards
         * - is visible
         */
        public virtual void AddInitialHand()
        {
            Hands.Add(new Hand());
            Hands[0].AddRandomCard(true);
            Hands[0].AddRandomCard(true);
        }

        /*
         * check
         *  - not null
         *  - two cards
         *  - first visible ***not actual blackjack
         *  - second not visibile ***not actual blackjack
         */
        public virtual void AddInitialDealerHand()
        {
            Hands.Add(new Hand());
            Hands[0].AddRandomCard(true);
            Hands[0].AddRandomCard(false);
        }

        public void DisplayPlayer(TextWriter writer, bool isCurrentPlayer)
        {

        }
        public void displayMultiHand(TextWriter writer, bool isCurrentPlayer)
        {

        }
        public void displaySingleHand(TextWriter writer, bool isCurrentPlayer)
        {

        }
    }
}