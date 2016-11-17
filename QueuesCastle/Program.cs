using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace queues_castle
{
	internal interface Node
	{
		IEnumerable<Edge> EnEdgeOut { get; }
	}

	internal interface Edge
	{
		int Weight { get; }
		Node NodeA { get; }
		Node NodeB { get; }
	}

	static class U
	{
		public static Node NodeOther(this Edge edge, Node node) =>
			node == edge.NodeA ? edge.NodeB
			: (node == edge.NodeB ? edge.NodeA : null);
	}

	internal class A
	{
		public virtual Node NodeStart { get; }
		public virtual Func<Node, bool> FNodeEnd { get; }
		/* A* public virtual Node->int heristics */

		public IEnumerable<Node> EnNodeSolve()
		{
			var rgposOpen = new Queue<Node>(new [] {NodeStart});
			var mpNodeParentByNode = new Dictionary<Node, Node>();
			var hlmClosed = new HashSet<Node>();
			var hlmOpenAndClosed = new HashSet<Node>();
			while (rgposOpen.Any())
			{
				var node = rgposOpen.Dequeue();
				hlmClosed.Add(node);
				if ( FNodeEnd(node) )
				{
					return EnFromSpanTree(node, mpNodeParentByNode);
				}

				hlmClosed.Add(node);
				foreach (var edge in node.EnEdgeOut)
				{
					var nodeNext = edge.NodeOther(node);
					if (hlmOpenAndClosed.Contains(nodeNext))
						continue;
					hlmOpenAndClosed.Add(node);
					mpNodeParentByNode[nodeNext] = node;
					rgposOpen.Enqueue(nodeNext);
				}
			}
			return null;
		}

		private IEnumerable<Node> EnFromSpanTree(Node node, Dictionary<Node, Node> mpNodeParentByNode)
		{
			while (node != null)
			{
				yield return node;
				node = mpNodeParentByNode.ContainsKey(node) ? mpNodeParentByNode[node] : null;
			}
		}
	}

	internal class Program
	{
		public static void Main(string[] args)
		{
			var n = int.Parse(Console.ReadLine());
			var rgstrow = Enumerable.Range(0, n).Select(_ => Console.ReadLine()).ToArray();
			var rgnum = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			var posStart = Tuple.Create(rgnum[0], rgnum[1]);
			var posEnd = Tuple.Create(rgnum[0], rgnum[1]);

		}

		private static IEnumerable<Tuple<int, int>> PosNextFromPos(Tuple<int, int> pos, string[] rgstrow)
		{
			throw new NotImplementedException();
		}
	}
}