using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace queues_castle
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var rgstrow = Enumerable.Range(0, n).Select(_ => Console.ReadLine()).ToArray();
			var rgnum = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			var posStart = Tuple.Create(rgnum[0], rgnum[1]);
			var posEnd = Tuple.Create(rgnum[0], rgnum[1]);

			var rgposOpen = new Queue<Tuple<int, int>>(new [] {posStart});
			var mpSpanTree = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
			var hlmClosed = new HashSet<Tuple<int, int>>();
			while (rgposOpen.Any())
			{
				var pos = rgposOpen.Dequeue();
				if (pos == posEnd)
				{

					Console.WriteLine();
					break;
				}

				hlmClosed.Add(pos);
				foreach (var posNext in PosNextFromPos(pos, rgstrow))
				{
					if (hlmClosed.Contains(posNext))
						continue;
					mpSpanTree[posNext] = pos;

				}
			}
		}

		private static IEnumerable<Tuple<int, int>> PosNextFromPos(Tuple<int, int> pos, string[] rgstrow)
		{
			throw new NotImplementedException();
		}
	}
}