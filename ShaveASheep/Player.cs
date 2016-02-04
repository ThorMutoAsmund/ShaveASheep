using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaveASheep
{
    public abstract class Player : IPlayer
    {
        public int[] Green(int[] ownSheep, int[] otherSheep)
        {
            var otherIndex = otherSheep[1] > otherSheep[0] ? 1 : 0;
            var ownIndex = ownSheep[1] > ownSheep[0] ? 1 : 0;
            return (otherSheep[otherIndex] > ownSheep[ownIndex]) ? new int[] { ownIndex, otherIndex } : null;
        }

        public int Pink(int[] ownSheep)
        {
            return ownSheep[1] > ownSheep[0] ? 1 : 0;
        }

        public int Wolf(int[] otherSheep)
        {
            return otherSheep[1] > otherSheep[0] ? 1 : 0;
        }

        public abstract int[] White(int num, int[] ownSheep);
    }
}
