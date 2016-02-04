using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaveASheep
{
    public class PreferTwoSheepPlayer : Player
    {
        public override int[] White(int num, int[] ownSheep)
        {
            if (num == 2)
            {
                if (ownSheep[0] < ownSheep[1] + 1 && ownSheep[0] < 4) return new int[2] { 2, 0 };
                if (ownSheep[1] < ownSheep[0] + 1 && ownSheep[1] < 4) return new int[2] { 0, 2 };
                return new int[2] { 1, 1 };
            }
            else
            {
                if (ownSheep[0] < ownSheep[1]) return new int[2] { 1, 0 };
                return new int[2] { 0, 1 };
            }
        }

        public override string ToString()
        {
            return "'Prefer Two Sheep'";
        }
    }
}
