using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaveASheep
{
    public class PreferOneSheepPlayer : Player
    {
        public override int[] White(int num, int[] ownSheep)
        {
            int preferIndex = ownSheep[1] > ownSheep[0] ? 1 : 0;
            int notPreferIndex = (preferIndex +1) % 2;
            if (num == 2)
            {
                if (ownSheep[preferIndex] < 4) return new int[2] { preferIndex == 0 ? 2 : 0, preferIndex == 0 ? 0 : 2 };
                if (ownSheep[preferIndex] < 5) return new int[2] { 1, 1 };
                return new int[2] { preferIndex == 0 ? 0 : 2, preferIndex == 0 ? 2 : 0 };
            }
            else
            {
                if (ownSheep[preferIndex] < 5) return new int[2] { preferIndex == 0 ? 1 : 0, preferIndex == 0 ? 0 : 1 };
                return new int[2] { preferIndex == 0 ? 0 : 1, preferIndex == 0 ? 1 : 0 };
            }
        }

        public override string ToString()
        {
            return "'Prefer One Sheep'";
        }
    }
}
