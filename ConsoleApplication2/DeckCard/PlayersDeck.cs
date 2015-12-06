using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWoocode.DeckCard
{
    public class PlayersDeck : Deck
    {
        /// <summary>
        /// Empty constructor using the base constructor
        /// </summary>
        public PlayersDeck()
            : base()
        {
        }
        /* Override methods*/
        public override List<Card> draw(int amount)
        {
            List<Card> drawnCards = new List<Card>();
            drawnCards.Add(cards.ElementAt(0));
            cards.RemoveAt(0);
            return drawnCards;
        }
        //Player's methods
        /// <summary>
        /// Draw a specific card from the player's deck
        /// </summary>
        /// <param name="card">the card to draw and display on the board</param>
        /// <returns>the cards from the player's deck</returns>
        public Card draw(Card card)
        {
            Card c = cards.Find(x => x.Equals(card));
            cards.Remove(card);
            return c;
        }

    }
}
