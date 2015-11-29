using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWoocode.Game
{
    public class GameWar : Game
    {
        public GameWar(int players)
            : base(players)
        {

        }
        public override string playersInfo()
        {
            string res = "List of players : \n";
            foreach (Player p in this.players)
            {
                res += p + "\n";
            }
            return res;
        }

        public override void play()
        {
            Console.WriteLine("Welcome to the BAttle game");
            this.setupGame();

            while (!winCondition())
            {
                nextTurn(0);
                Console.ReadLine();
            }
            this.endGame();
        }

        public override void setupGame()
        {
            this.dealerDeck.shuffle();
            this.dealerDeck.deal(26, 2, players); // Deal 2 cards in 2 turns
        }

        public override bool nextTurn(int drawnCards)
        {
            foreach (Player p in players)
            {

                this.board.AddRange(p.deck.draw(1));
                Console.WriteLine(p + " turn :\n" + this.boardInfo());
                int cardsOnBoard = board.Count;
                if (board.Count > 1 && board.ElementAt(cardsOnBoard - 1).sameValue(board.ElementAt(cardsOnBoard - 2)))
                {
                    board.RemoveRange(0, cardsOnBoard);
                    p.points += cardsOnBoard;
                }
            }
            return true;
        }

        public override void endGame()
        {
            Console.WriteLine("Game over");
            Console.ReadLine();
        }

        public override bool winCondition()
        {
            if (this.players.ElementAt(0).deck.cards.Count == 0 || this.players.ElementAt(1).deck.cards.Count == 0)
            {
                Console.WriteLine("The winner is : " +
                    (this.players.ElementAt(0).points > this.players.ElementAt(1).points ?
                    this.players.ElementAt(0) :
                    this.players.ElementAt(1)));
                return true;
            }
            return false;
        }
    }
}
