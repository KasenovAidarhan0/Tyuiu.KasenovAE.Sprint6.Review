using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.KasenovAE.Sprint6.TaskReview.V14.Lib
{
    public class DataService
    {
        public int GetMatrix(int[,] array, int c, int k, int l)
        {
            int res = 1;

            for (int i = k; i <= l; i++)
            {
                if (i % 2 == 0)
                {
                    res *= array[i, c];
                }
            }

            return res;
        }
    }
}
