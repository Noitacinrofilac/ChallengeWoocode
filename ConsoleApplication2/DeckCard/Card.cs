using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWoocode.DeckCard
{
    /// <summary>
    /// Enum defining the usual colors of the cards
    /// </summary>
    public enum CardColor
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }
    /// <summary>
    /// Enum defining the value of the cards
    /// Starting by As and ending by King
    /// </summary>
    public enum CardValueAsToKing
    {
        As = 1, two, three, four, five, six, seven, height, nine, ten, Jack, Queen, King
    }
    /// <summary>
    /// Enum defining the value of the cards
    /// Starting by Two and ending by As
    /// </summary>
    public enum CardValueTwoToAs
    {
        two = 2, three, four, five, six, seven, height, nine, ten, Jack, Queen, King, As
    }

    public class Card
    {
        public CardColor color;
        public CardValueTwoToAs value;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="color">define the card's color</param>
        /// <param name="value">defines the card's value</param>
        public Card(CardColor color, CardValueTwoToAs value)
        {
            this.color = color;
            this.value = value;
        }
        
        /// <summary>
        /// check if the 2 cards have the same color
        /// </summary>
        /// <param name="c">Cards to compare with</param>
        /// <returns>True if the cards have the same color</returns>
        public bool sameColor(Card c)
        {
            if (this.color.Equals(c.color))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if the cards have the same value
        /// </summary>
        /// <param name="c">Cards to compare with</param>
        /// <returns>True if the cards have the same value</returns>
        public bool sameValue(Card c)
        {
            if (this.value.Equals(c.value))
            {
                return true;
            }
            return false;
        }

        /*Override Methods*/
        public override string ToString()
        {
            return value + "_" + color;
        }
        
        public override bool Equals(object obj)
        {
            Card card = obj as Card;
            if (card == null)
                return false;

            if (this.sameColor(card) && this.sameValue(card))
                return true;
            return false;
        }
    }
}
