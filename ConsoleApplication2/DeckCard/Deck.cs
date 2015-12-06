using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWoocode.DeckCard
{
    /// <summary>
    /// The abstract class Deck defines the patern of a deck
    /// It is used to create the dealer's deck and also the players' decks
    /// </summary>
    public abstract class Deck
    {
        public List<Card> cards { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Deck()
        {
            cards = new List<Card>();
        }

        /*Abstract Methods*/
        /// <summary>
        /// The draw method is used to draw "amount" cards from the deck and return them.
        /// It takes the top deck cards
        /// </summary>
        /// <param name="amount">Amount of cards to draw</param>
        /// <returns>The "amount" cards drawn from the top of the deck</returns>
        public abstract List<Card> draw(int amount);

        /*Deck methods*/
        /// <summary>
        /// Display the deck by returning the cards it contains as a string
        /// </summary>
        /// <returns>Displayable version of the cards in the deck</returns>
        public string display()
        {
            string res = "";
            foreach (Card c in this.cards)
            {
                res += "\t" + c + "\n";
            }
            return res;
        }
        /// <summary>
        /// Returns the amount of cards the deck contains
        /// </summary>
        /// <returns>Amount of cards</returns>
        public int amountCards()
        {
            return this.cards.Count;
        }
    }
}
