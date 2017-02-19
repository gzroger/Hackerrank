using System;
using System.Linq;
using System.Numerics;

namespace MathSherlockPermutations
{
    internal class Program
    {
            // ( N+M-1 ) ! / (M-1)! / N!
        static void Main(String[] args) {
            var T = int.Parse(Console.ReadLine());
            foreach (var _ in Enumerable.Range(0, T))
            {
                var rg = Console.ReadLine().Split();
                var N = int.Parse(rg[0]);
                var M = int.Parse(rg[1]);
                var R = BigInteger.One;
                for (var i = N + 1; i <= N + M - 1; i++)
                {
                    R = BigInteger.Multiply(R, i);
                }
                for (var i = 2; i <= M - 1; i++)
                {
                    R = BigInteger.Divide(R, i);
                }

                Console.WriteLine( /*( N+M-1 ) ! / (M-1)! / N! %*/ BigInteger.Remainder(R, 1000000007) );
            }
        }
    }
}