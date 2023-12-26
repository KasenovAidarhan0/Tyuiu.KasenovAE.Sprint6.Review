using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Tyuiu.KasenovAE.Sprint6.TaskReview.V14.Lib;

namespace Tyuiu.KasenovAE.Sprint6.TaskReview.V14.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMatrix()
        {
            int n1 = 1;
            int n2 = 7;
            Random r = new Random();
            int[,] arr = new int[3, 4];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(n1, n2);
                    if (j % 2 == 0 && j != 0)
                        arr[i, j] = arr[i, j - 1] * arr[i, j - 2];
                    Debug.Write(Convert.ToString(arr[i, j]) + '\t');
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");
            DataService ds = new DataService();
            int res = ds.GetMatrix(arr, 2, 0, 2);
            Debug.WriteLine(res);
        }
    }
}
