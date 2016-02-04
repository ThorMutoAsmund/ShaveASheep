using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaveASheep
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player0 = new PreferOneSheepPlayer();
            IPlayer player1 = new PreferTwoSheepPlayer();
            var simulator = new Simulator(player0, player1);

            int simulations = 100000;
            Console.WriteLine("Performing {0} simulations", simulations);
            var stats = simulator.Start(simulations);
            Console.WriteLine("Player {0} won {1} times", player0.ToString(), stats[0]);
            Console.WriteLine("Player {0} won {1} times", player1.ToString(), stats[1]);
            Console.ReadKey();
        }
    }
}
