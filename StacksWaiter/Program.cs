using System;
using System.Collections.Generic;
using System.Linq;

namespace stacks_waiter
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var _ = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			var N = _[0];
			var Q = _[1];

			// 1200th prime: 9733
			var rgn = new bool[5000];
			var rgprime = new List<int> {2};
			for (int n = 3; n < 5000 * 2; n += 2)
			{
				if (rgn[n/2])
					continue;

				rgprime.Add(n);
				for (int j = n*3; j < 5000 * 2; j += n)
				{
					if (j%2 == 0)
						continue;

					rgn[j/2] = true;
				}
			}

			var A0 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			var stck0 = new Stack<int>(A0);
			for (int i = 0; i < Q; i++)
			{
				var stck1 = new Stack<int>();
				var stckb = new Stack<int>();
				var primeI = rgprime[i];
				while (stck0.Any())
				{
					var q = stck0.Pop();
					if (q % primeI == 0)
					{
						stckb.Push(q);
					}
					else
					{
						stck1.Push(q);
					}
				}
				foreach (var q in stckb)
				{
					Console.WriteLine(q);
				}

				stck0 = stck1;
			}
			foreach (var q in stck0)
			{
				Console.WriteLine(q);
			}
		}
	}
}