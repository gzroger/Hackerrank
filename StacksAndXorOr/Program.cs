using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndXorOr
{
	class Program
	{
		static void Main(String[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var rgh = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
			var maxXor = 0L;
			var stckMin = new Stack<long>();
			for (var i = 0; i < n; i++)
			{
				foreach (var m1 in stckMin)
				{
					var x = m1 ^ rgh[i];
					//Console.WriteLine("{0} xor {1} = {2} ", m1, rgh[i], x);
					maxXor = Math.Max(x, maxXor);
					if (m1 < rgh[i])
						break;
				}

				while (stckMin.Any() && stckMin.Peek() > rgh[i])
					stckMin.Pop();

				stckMin.Push(rgh[i]);
			}
			Console.WriteLine(maxXor);
		}
	}
}