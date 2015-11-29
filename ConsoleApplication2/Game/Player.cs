using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeWoocode.Deck;

namespace ChallengeWoocode.Game
{
    /// <summary>
    /// defines the player for the different games
    /// </summary>
    public class Player
    {
        public PlayersDeck deck;
        public int id;
        public int points;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of the player </param>
        public Player(int id)
        {
            deck = new PlayersDeck();
            this.id = id;
            this.points = 0;

        }
        /*Override methods*/
        public override string ToString()
        {
            return "Player" + id + "[" + deck.amountCards() + " cards][" + points + " points]";
        }
        public override bool Equals(object obj)
        {
            return this.id.Equals((obj as Player).id);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
