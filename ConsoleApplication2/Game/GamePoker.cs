using ChallengeWoocode.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWoocode.Game
{
    /*
     * SImple version of poker
     * No overbet possible
     */
    public class GamePoker : Game
    {
        public Dictionary<Player, int> bets = new Dictionary<Player, int>();

        public GamePoker(int nbPlayers)
            : base(nbPlayers)
        {
            foreach (Player p in this.players)
            {
                bets.Add(p, 0);
            }
        }
        /*Base Methods*/
        public string boardInfo()
        {
            return base.boardInfo() + "Highest bet = " + this.bets.Values.Max() + "\n"; ;
        }
        /*Override methods*/
        public override string playersInfo()
        {
            string res = "List of players : \n";
            foreach (Player p in this.players)
            {
                res += p + " [Bet=" + this.bets[p] + "]\n";
            }
            return res;
        }
        public override void play()
        {
            Console.WriteLine("Welcome to the poker game");
            this.setupGame();
            if (this.nextTurn(3))
            {
                Console.WriteLine("*************************END TURN 1*************************");
                if (this.nextTurn(1))
                {
                    Console.WriteLine("*************************END TURN 2*************************");
                    if (this.nextTurn(1))
                    {
                        Console.WriteLine("*************************END TURN 3*************************");
                        this.endGame();
                    }
                }
            }
            Console.ReadLine();
        }
        public override void setupGame()
        {
            this.dealerDeck.shuffle();
            this.dealerDeck.deal(2, 1, players); // Deal during 2 turns 1 cards
        }
        public override bool nextTurn(int cardDrawn)
        {
            Console.WriteLine("*************************TURN Info*************************");
            Console.WriteLine(this.boardInfo());
            Console.WriteLine(this.playersInfo());
            Console.WriteLine("*************************TURN Info*************************");
            this.playerBet();
            this.board.AddRange(this.dealerDeck.draw(cardDrawn));
            handsValue();
            if (this.winCondition())
            {
                Console.WriteLine("The winner is " + players.ElementAt(0));
                return false;
            }
            return true;
        }
        public override void endGame()
        {
            foreach (Player p in players)
            {
                p.points = this.getPoints(this.board, p.deck.cards);
            }
        }
        public override bool winCondition()
        {
            //Check player"s Fold
            List<Player> outPlayers = new List<Player>();
            foreach (Player p in players)
            {
                if (bets[p] == 0)
                {
                    outPlayers.Add(p);
                }
            }
            foreach (Player op in outPlayers)
            {
                players.Remove(op);
            }
            if (players.Count == 1)
            {
                return true;
            }
            return false;
        }

        

        /*Poker methods*/
        public void playerBet()
        {
            int betValue = 0;
            foreach (Player p in this.players)
            {
                int maxBet = bets.Values.Max();
                Console.WriteLine(p);
                Console.WriteLine(p.deck.display());
                Console.WriteLine("Enter your bet (=" + maxBet + ")");
                string val = Console.ReadLine();
                if (!val.Equals(""))
                    betValue = Int32.Parse(val);
                else
                    betValue = 0;
                this.bets[p] += betValue;
                Console.WriteLine(p + ": current bet = " + this.bets[p]);
            }
        }
        private int getPoints(List<Card> boardC, List<Card> playerC)
        {
            int points = 0;
            foreach (Card c in playerC)
            {
                if ((int)c.value > points)
                {
                    points = (int)c.value;
                }
            }
            //Chec highest card value
            //check pair
            //Check Carré
            return points;
        }

        public void handsValue()
        {
            foreach (Player p in players)
            {
                p.points = this.getPoints(board, p.deck.cards);
            }
        }
        
    }
}
