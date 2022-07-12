using System;
using System.IO;

namespace BlackJack
{
    public class Controller
    {
        // This logic is really just here so we can set the current
        // game directly during unit testing... we wouldn't run this
        // code normally
        private Game currentGame;
        public Game CurrentGame
        {
            get
            {
                if (currentGame == null) currentGame = new Game();
                return currentGame;
            }
            set
            {
                currentGame = value;
            }
        }
        // End logic just for unit testing

        public Controller()
        {
            // Nothing to configure
        }

        public Game StartGame(int playerCount)
        {
            if ( playerCount <= 0 )
            {
                throw new ApplicationException("Must have a non-negative and non-zero number of players");
            }

            CurrentGame.ConfigurePlayers(playerCount);
            CurrentGame.DealInitialCards();

            return CurrentGame;
        }

        public void DisplayGame(TextWriter writer)
        {
            Player currentPlayer = CurrentGame.GetCurrentPlayer();

            foreach( Player thisPlayer in CurrentGame.Players )
            {
                thisPlayer.DisplayPlayer(writer, currentPlayer == thisPlayer);
            }

            CurrentGame.Dealer.DisplayPlayer(writer, false);
        }
    }
}
