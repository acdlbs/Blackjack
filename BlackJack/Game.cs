using System.Collections.Generic;

namespace BlackJack
{
    public class Game
    {
        private bool active;
        public virtual int currentPlayer { get; private set; }


        public List<Player> Players { get; private set; }
        public Player Dealer { get; private set; }

        //note wont test this
        public Game()
        {
            Players = new List<Player>();
            active = true;
        }

        public virtual void ConfigurePlayers(int playerCount)
        {
            if (playerCount <= 0)
            {
                Players = null;
                return;
            }

            Players.Clear();
            currentPlayer = 0;

            for ( int playerNum = 1; playerNum <= playerCount; playerNum++)
            {
                Players.Add(new Player($"Player {playerNum}"));
            }

            Dealer = new Player("Dealer");


        }

        public virtual void DealInitialCards()
        {
            foreach( Player thisPlayer in Players)
            {
                thisPlayer.AddInitialHand();
            }

            Dealer.AddInitialDealerHand();
        }

        public Player GetCurrentPlayer()
        {
            if ((currentPlayer < 0) || (currentPlayer >= Players.Count))
                return null;

            return Players[currentPlayer];
        }
    }
}
