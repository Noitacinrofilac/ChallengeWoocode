using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeWoocode.Game
{
    class Challenge
    {
        /// <summary>
        /// Main methods used to call the diferent games in this solution
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Game game = new GamePoker(4);
            Game game = new GameWar(2);
            game.play();
        }
    }
}
