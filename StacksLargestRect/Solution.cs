using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksLargestRect
{
	class IH
	{
		public int i;
		public int h;
	}

	class Solution {
		static void Main(String[] args) {
			var n = int.Parse(Console.ReadLine());
			var rgh = Console.ReadLine().Split(' ').Select(st => int.Parse(st)).ToArray();
			var maxRect = 0;
			var stckIH = new Stack<IH>();
			var TT = new IH{i = int.MaxValue, h = 0 };
			for (var i = 0; i < n; i++)
			{
				var prevIH = TT;
				while (true)
				{
					var ih = stckIH.Any() ? stckIH.Peek() : TT;
					if (rgh[i] >= ih.h)
						break;
					prevIH = stckIH.Any() ? stckIH.Pop() : TT;
					maxRect = Math.Max(prevIH.h * (i - prevIH.i), maxRect);
				}
				var ihPeek = stckIH.Any() ? stckIH.Peek() : TT;
				if (ihPeek.h < rgh[i])
				{
					stckIH.Push(new IH {i = Math.Min(i, prevIH.i), h = rgh[i]});
				}

			}
			maxRect = stckIH.Select(ih => ih.h * (n - ih.i)).Concat(new[] {maxRect}).Max();
			Console.WriteLine(maxRect);
		}
	}
}