using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeWoocode.DeckCard;

namespace ChallengeWoocode.Game
{
    /// <summary>
    /// Abstract class Game. 
    /// Used by inherit this class.
    /// It provides the general methods used for the game creation
    /// </summary>
    public abstract class Game
    {
        public List<Player> players;
        public List<Card> board;
        public DealersDeck dealerDeck;

        public Game(int numberPlayer)
        {
            board = new List<Card>();
            dealerDeck = new DealersDeck();
            players = new List<Player>();
            for (int i = 0; i < numberPlayer; i++)
            {
                players.Add(new Player(i));
            }

        }
        /*********Methods*********/
        /// <summary>
        /// information : 
        ///     Amount of cards
        ///     Display cards
        /// </summary>
        /// <returns>The basic information of the board</returns>
        public virtual string boardInfo()
        {
            string res = "Board : " + this.board.Count + " cards : \n";
            foreach (Card c in this.board)
            {
                res += "\t" + c + "\n";
            }
            return res;
        }
        /********Abstract Methods***********/
        /// <summary>
        /// Diaply the information of the palyers
        /// </summary>
        /// <returns>players information</returns>
        public abstract string playersInfo();
        /// <summary>
        /// Define the rule of the game and launch it
        /// </summary>
        public abstract void play();
        /// <summary>
        /// Define the setup for the game 
        /// e.g. deal the cards, shuffle the dealer's deck...
        /// </summary>
        public abstract void setupGame();
        /// <summary>
        /// Define what happens during one turn
        /// </summary>
        /// <param name="drawnCards">amount of card drawn by the dealer on the board</param>
        /// <returns>true if the game is over</returns>
        public abstract bool nextTurn(int drawnCards);
        /// <summary>
        /// Define the last turn of the game if it is not yet over
        /// </summary>
        public abstract void endGame();
        /// <summary>
        /// Define the win condition for the players to win
        /// </summary>
        /// <returns>true if a player won</returns>
        public abstract bool winCondition();
    }
}
