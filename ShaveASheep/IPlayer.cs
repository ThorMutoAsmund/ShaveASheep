using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaveASheep
{
    public interface IPlayer
    {
        int[] White(int num, int[] ownSheep);
        int[] Green(int[] ownSheep, int[] otherSheep);
        int Pink(int[] ownSheep);
        int Wolf(int[] otherSheep);
    }
}
