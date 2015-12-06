using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeWoocode.Game;

namespace ChallengeWoocode.DeckCard
{
    /// <summary>
    /// Define the Dealer's deck
    /// </summary>
    public class DealersDeck : Deck
    {
        /// <summary>
        /// Constructor using the base empty constructor
        /// It creates the 52 cards deck
        /// </summary>
        public DealersDeck()
            : base()
        {
            foreach (CardColor col in Enum.GetValues(typeof(CardColor)))
            {
                foreach (CardValueTwoToAs val in Enum.GetValues(typeof(CardValueTwoToAs)))
                {
                    this.cards.Add(new Card(col, val));
                }
            }
        }

        /*Override methods*/
        public override List<Card> draw(int amount)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                cards.Add(this.cards.ElementAt(i));
            }
            this.cards.RemoveRange(0, amount);
            return cards;
        }


        //Dealer's methods
        /// <summary>
        /// Shuffles the dealer's deck
        /// </summary>
        public void shuffle()
        {
            Random rng = new Random();
            int n = this.cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = this.cards[k];
                this.cards[k] = this.cards[n];
                this.cards[n] = value;
            }
        }
        /// <summary>
        /// Deals a certain amount of cards by turn to a list of player
        /// </summary>
        /// <param name="amount">Amount of card to deal to EACH player</param>
        /// <param name="cardsByTurn">How many cards are dealt everyturn (<= amount)</param>
        /// <param name="players">List of player receiving the cards</param>
        public void deal(int amount, int cardsByTurn, List<Player> players)
        {
            //this.shuffle();
            int cardLeftToDeal = amount*players.Count;
            while (cardLeftToDeal - cardsByTurn >= 0)
            {
                foreach (Player pl in players)
                {
                    for (int i = 0; i < cardsByTurn; i++)
                    {
                        pl.deck.cards.Add(this.cards.ElementAt(i));
                    }
                    this.cards.RemoveRange(0, cardsByTurn);
                    cardLeftToDeal -= cardsByTurn;
                }
            }
        }
    }
}
