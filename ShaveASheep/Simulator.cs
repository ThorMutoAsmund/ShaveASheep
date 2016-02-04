using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaveASheep
{
    public class Simulator
    {
        private IPlayer[] Players { get; set; }
        private Random rand = new Random((int)DateTime.Now.ToFileTime());

        public Simulator(IPlayer player0, IPlayer player1)
        {
            this.Players = new IPlayer[2] { player0, player1 };
        }

        public int[] Start(int simulations)
        {
            int[] stats = new int[2];
            for (int s = 0; s < simulations; ++s)
            {
                var result = DoOneRound(s % 2);
                if (result > -1)
                {
                    stats[result]++;
                }
            }

            return stats;
        }

        public void Report()
        {
        }

        private enum Dice { White, Double, Green, Pink, Wolf }

        private int DoOneRound(int startingPlayer)
        {
            int[][] sheep = new int[2][];
            sheep[0] = new int[2];
            sheep[1] = new int[2];
            sheep[0][0] = 0;
            sheep[0][1] = 0;
            sheep[1][0] = 0;
            sheep[1][1] = 0;
            int pool = 24;
            int turn = startingPlayer;
            int otherTurn;
            int[] points = new int[2];
            points[0] = 0;
            points[1] = 0;
            Dice dice;
            int roll;
            
            while (pool > 0)
            {
                for (int i = 0; i < 2; ++i)
                {
                    for (int s = 0; s < 2; ++s)
                    {
                        if (sheep[i][s] > 5)
                        {
                            throw new Exception("Sheep has more than 5 pieces of wool!");
                        }
                        if (sheep[i][s] == 5)
                        {
                            points[i] += 5;
                            sheep[i][s] = 0;
                        }
                    }
                }

                otherTurn = (turn + 1) % 2;
                roll = rand.Next(6);
                switch (roll)
                {
                    case 0:
                    case 1:
                        dice = Dice.White;
                        break;
                    case 2:
                        dice = Dice.Green;
                        break;
                    case 3:
                        dice = Dice.Pink;
                        break;
                    case 4:
                        dice = Dice.Double;
                        break;
                    case 5:
                        dice = Dice.Wolf;
                        break;
                    default:
                        throw new Exception("Unexpected dice value");
                }

                switch (dice)
                {
                    case Dice.White:
                    case Dice.Double:
                        {
                            var take = dice == Dice.White ? 1 : ((pool > 1) ? 2 : 1);
                            pool -= take;
                            var amounts = this.Players[turn].White(take, sheep[turn]);
                            if (amounts[0] + amounts[1] != take)
                            {
                                throw new Exception("Wool amount returned wrong!");
                            }
                            for (int i = 0; i < 2; ++i)
                            {
                                sheep[turn][i] += amounts[i];
                                if (sheep[turn][i] > 5)
                                {
                                    sheep[turn][i] = 5;
                                    pool += 1;
                                }
                            }
                            break;
                        }
                    case Dice.Green:
                        {
                            var indices = this.Players[turn].Green(sheep[turn], sheep[otherTurn]);
                            if (indices != null)
                            {
                                var ownS = sheep[turn][indices[0]];
                                sheep[turn][indices[0]] = sheep[otherTurn][indices[1]];
                                sheep[otherTurn][indices[1]] = ownS;
                            }
                            break;
                        }
                    case Dice.Pink:
                        {
                            var index = this.Players[turn].Pink(sheep[turn]);
                            points[turn] += sheep[turn][index];
                            sheep[turn][index] = 0;
                            break;
                        }
                    case Dice.Wolf:
                        {
                            var index = this.Players[turn].Wolf(sheep[otherTurn]);
                            pool += sheep[otherTurn][index];
                            sheep[otherTurn][index] = 0;
                            break;
                        }
                }
                turn = (turn + 1) % 2;
            }

            points[0] = sheep[0][0] + sheep[0][1];
            points[1] = sheep[1][0] + sheep[1][1];

            return points[0] > points[1] ? 0 : (points[1] > points[0] ? 1 : -1);
        }
    }
}
