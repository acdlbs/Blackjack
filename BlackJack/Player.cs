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

        public virtual void DisplayPlayer(TextWriter writer, bool isCurrentPlayer)
        {
            if (Hands.Count > 1)
            {
                displayMultiHand(writer, isCurrentPlayer);
            }
            else
            {
                displaySingleHand(writer, isCurrentPlayer);
            }
        }
        public virtual void displayMultiHand(TextWriter writer, bool isCurrentPlayer)
        {
            if (isCurrentPlayer == true)
            {
                string finalString = "*" + Name + "\r\n\t";
                for (int i = 0; i < Hands.Count; i++)
                {
                    if (i == Hands.Count - 1)
                    {
                        finalString += "Hand " + (i + 1) + ": " + Hands[i].CardsString() + "\r\n";
                    }
                    else
                    {
                        finalString += "Hand " + (i + 1) + ": " + Hands[i].CardsString() + "\r\n\t";
                    }  
                }
                writer.Write(finalString);
            }
            else
            {
                string finalString = " " + Name + "\r\n\t";
                for (int i = 0; i < Hands.Count; i++)
                {
                    if (i == Hands.Count - 1)
                    {
                        finalString += "Hand " + (i + 1) + ": " + Hands[i].CardsString() + "\r\n";
                    }
                    else
                    {
                        finalString += "Hand " + (i + 1) + ": " + Hands[i].CardsString() + "\r\n\t";
                    }
                }
                writer.Write(finalString);
            }
        }
        public virtual void displaySingleHand(TextWriter writer, bool isCurrentPlayer)
        {
            if (isCurrentPlayer == true)
            {
                writer.Write("*" + Name + " Hand: " + Hands[0].CardsString() + "\r\n");
            }
            else
            {
                writer.Write(" " + Name + " Hand: " + Hands[0].CardsString() + "\r\n");
            }
            
        }
    }
}