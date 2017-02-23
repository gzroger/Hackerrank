using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace MathSpecialMultiple
{
    internal class Program
    {
        public static IEnumerable<BigInteger> EnAll10()
        {
            var i = BigInteger.One;
            while (true)
            {
                yield return i;
                var e = i;
                var x = BigInteger.One;
                while (true)
                {
                    if (e % 10 == 0 )
                    {
                        i += x;
                        break;
                    }
                    i -= x;

                    if (e == 0)
                        break;
                    e = e / 10;
                    x *= 10;
                }
                //i = i + 1;
            }
            yield break;
        }

        public static void Main(string[] args)
        {
            /*foreach (var i in EnAll10())
            {
                Console.WriteLine(i);
                if (i > 100000000)
                    break;
            }*/
            var rg10 = new BigInteger[501];
            rg10[1] = BigInteger.One;
            for (int n = 2; n <= 500; n++)
            {

                switch (n % 10)
                {
                    case 0:
                        rg10[n] = rg10[n / 10] * 10;
                        break;
                    case 2:
                    case 4:
                    case 6:
                    case 8:
                        rg10[n] = rg10[n / 2] * 10;
                        break;
                    case 5:
                        rg10[n] = rg10[n / 5] * 10;
                        break;
                    default:
                        var k = 0;
                        switch (n % 10)
                        {
                            case 1:
                                k = 1;
                                break;
                            case 3:
                                k = 7;
                                break;
                            case 7:
                                k = 3;
                                break;
                            case 9:
                                k = 9;
                                break;
                        }
                        var z = (k * n - 1) / 10;
                        var y = EnAll10().First(i => i % n == z);
                        Debug.Assert( (y - z) % n == 0 );
                        Debug.Assert( (y*10 + 1) % n == 0 );
                        rg10[n] = y*10 + 1 ;

                        break;
                }
                //Console.WriteLine("{0} = {1}*{2} (mod {3})", rg10[n], n, rg10[n]/n, rg10[n]%n);
            }
/*            for (var n = 1; n <= 500; n++)
            {
                if (n % 9 == 0)
                {
                    Console.WriteLine("{0}: {1}", n, rg10[n / 9] * 9);
                }
                else if (n % 3 == 0)
                {
                    Console.WriteLine("{0}: {1}", n, rg10[n / 3] * 9);
                }
                else
                {
                    Console.WriteLine("{0}: {1}", n, rg10[n] * 9);
                }

            } */
            var t = int.Parse(Console.ReadLine());
            foreach (var _ in Enumerable.Range(0, t))
            {
                var n = int.Parse(Console.ReadLine());
                if (n % 9 == 0)
                {
                    Console.WriteLine("{1}", n, rg10[n / 9] * 9);
                }
                else if (n % 3 == 0)
                {
                    Console.WriteLine("{1}", n, rg10[n / 3] * 9);
                }
                else
                {
                    Console.WriteLine("{1}", n, rg10[n] * 9);
                }

            }
        }
    }
}