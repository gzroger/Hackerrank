using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathEvenOddQuery
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var Q = int.Parse(Console.ReadLine());
            foreach (var _ in Enumerable.Range(0, Q))
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var x = xy[0];
                var y = xy[1];
                Console.WriteLine(FEven(A, x, y) /*Find(A, x, y) % 2 == 0*/ ? "Even" : "Odd");
            }
        }

        private static bool FEven(int[] A, int x, int y)
        {
            return x <= y && (x + 1 > y ? 1 : A[x]) != 0 && A[x - 1] % 2 == 0;
        }
        /*
        private static BigInteger Find(int[] A, int x, int y)
        {
            return x > y ? 1 : Pow(A[x-1], x + 1 > y ? 1 : Pow(A[x], (int)Find(A, x + 1 + 1, y)));
        }*/
    }
}