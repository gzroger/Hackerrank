using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace hckr_equalstacks
{
	class Solution {

		static void Main(String[] args) {
			var tokens_n1 = Console.ReadLine().Split(' ');
			var n1 = Convert.ToInt32(tokens_n1[0]);
			var n2 = Convert.ToInt32(tokens_n1[1]);
			var n3 = Convert.ToInt32(tokens_n1[2]);
			var h1_temp = Console.ReadLine().Split(' ');
			var h1 = Array.ConvertAll(h1_temp,Int32.Parse);
			var h2_temp = Console.ReadLine().Split(' ');
			var h2 = Array.ConvertAll(h2_temp,Int32.Parse);
			var h3_temp = Console.ReadLine().Split(' ');
			var h3 = Array.ConvertAll(h3_temp,Int32.Parse);

			var stck1 = new Stack<int>(h1.Reverse());
			var stck2 = new Stack<int>(h2.Reverse());
			var stck3 = new Stack<int>(h3.Reverse());
			var hh1 = h1.Sum();
			var hh2 = h2.Sum();
			var hh3 = h3.Sum();

			while (true)
			{
				if (hh1 == hh2 && hh2 == hh3)
				{
					Console.WriteLine(hh1);
					break;
				}

				if (hh1 <= hh3 && hh2 <= hh3)
				{
					hh3 -= stck3.Pop();
				}
				else if (hh3 <= hh2 && hh1 <= hh2)
				{
					hh2 -= stck2.Pop();
				}
				else
					hh1 -= stck1.Pop();

				/*if (hh1 < hh2)
				{
					if (hh2 < hh3)
					{
						// hh1 < hh2 < hh3
					}
					else // hh3 <= hh2
					{
						if (hh1 < hh3)
						{
							// hh1 < hh3 <= hh2
						}
						else // hh3 <= hh1
						{
							// hh3 <= hh1 < hh2
						}
					}
				}
				else // hh2 <= hh1
				{
					if (hh1 < hh3)
					{
						// hh2 <= hh2 < hh3
					}
					else // hh3 <= hh1
					{
						if (hh2 < hh3)
						{
							// hh2 < hh3 <= hh1
						}
						else // hh3 <= hh2
						{
							// hh3 <= hh2 <= hh1
						}
					}
				}*/
			}
		}
	}
}
