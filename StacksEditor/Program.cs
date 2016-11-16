using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerrankStackEditor
{
	class Program
	{
		internal enum Kop
		{
			Ins = 1,
			Del = 2,
			Print = 3,
			Undo = 4
		}

		class Nodest
		{
			internal string st;
			internal Nodest nodestNext;
		}

		class Edst
		{
			Nodest nodestHead;
			int c;

			internal Edst()
			{
				nodestHead = null;
				c = 0;
			}

			public Edst EdstNext(Op op)
			{
				switch (op.kop)
				{
					case Kop.Ins:
						return new Edst {nodestHead = new Nodest {st = op.st, nodestNext = nodestHead}, c = c + op.st.Length};
					case Kop.Del:
						var nodest = nodestHead;
						var n = op.n;
						while (nodest != null)
						{
							if (n < nodest.st.Length)
							{
								var nodestNew =
									n == 0 ? nodest :
									new Nodest {st = nodest.st.Substring(0, nodest.st.Length - n), nodestNext = nodest.nodestNext};
								return new Edst {nodestHead = nodestNew, c = c - op.n};
							}
							n -= nodest.st.Length;
							nodest = nodest.nodestNext;
						}
						if (nodest == null && n == 0)
							return new Edst {nodestHead = new Nodest {st = "", nodestNext = null}, c = 0};
						throw new ArgumentOutOfRangeException();
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			public void Print(int n)
			{
				var nFB = c - n;
				var nodest = nodestHead;
				while (nodest != null)
				{
					if (nFB < nodest.st.Length)
					{
						Console.WriteLine( nodest.st[ nodest.st.Length - 1 - nFB ] );
						break;
					}
					nFB -= nodest.st.Length;
					nodest = nodest.nodestNext;
				}
			}
		}


		internal class Op
		{
			public Kop kop;
			public string st;
			public int n;

			internal static Op OpFromStop(string stop)
			{
				var rgst = stop.Split();
				var nkop = Convert.ToInt32(rgst[0]);
				var kop = (Kop) nkop;

				switch (kop)
				{
					case Kop.Ins:
						return new Op {kop = kop, st = rgst[1]};
					case Kop.Del:
					case Kop.Print:
						return new Op { kop = kop, n = Convert.ToInt32(rgst[1]) };
					case Kop.Undo:
						return new Op { kop = kop };
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		static void Main(string[] args)
		{
			var n = Convert.ToInt32(Console.ReadLine());
			var rgop = Enumerable.Range(0, n).Select(_ => Op.OpFromStop(Console.ReadLine())).ToList();

			var stckEdst = new Stack<Edst>(new[] {new Edst()});

			foreach (var op in rgop)
			{
				switch (op.kop)
				{
					case Kop.Ins:
					case Kop.Del:
						stckEdst.Push(stckEdst.Peek().EdstNext(op));
						break;
					case Kop.Print:
						stckEdst.Peek().Print(op.n);
						break;
					case Kop.Undo:
						stckEdst.Pop();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}
	}
}
