using System.Collections.Generic;

namespace Pathfinding
{
	public class PointKDTree
	{
		private struct Node
		{
			public GraphNode[] data;

			public int split;

			public ushort count;

			public byte splitAxis;
		}

		private class CompareX : IComparer<GraphNode>
		{
			public int Compare(GraphNode lhs, GraphNode rhs)
			{
				return 0;
			}
		}

		private class CompareY : IComparer<GraphNode>
		{
			public int Compare(GraphNode lhs, GraphNode rhs)
			{
				return 0;
			}
		}

		private class CompareZ : IComparer<GraphNode>
		{
			public int Compare(GraphNode lhs, GraphNode rhs)
			{
				return 0;
			}
		}

		public const int LeafSize = 10;

		public const int LeafArraySize = 21;

		private Node[] tree;

		private int numNodes;

		private readonly List<GraphNode> largeList;

		private readonly Stack<GraphNode[]> arrayCache;

		private static readonly IComparer<GraphNode>[] comparers;

		public void Add(GraphNode node)
		{
		}

		public void Rebuild(GraphNode[] nodes, int start, int end)
		{
		}

		private GraphNode[] GetOrCreateList()
		{
			return null;
		}

		private int Size(int index)
		{
			return 0;
		}

		private void CollectAndClear(int index, List<GraphNode> buffer)
		{
		}

		private static int MaxAllowedSize(int numNodes, int depth)
		{
			return 0;
		}

		private void Rebalance(int index)
		{
		}

		private void EnsureSize(int index)
		{
		}

		private void Build(int index, List<GraphNode> nodes, int start, int end)
		{
		}

		private void Add(GraphNode point, int index, int depth = 0)
		{
		}

		public GraphNode GetNearest(Int3 point, NNConstraint constraint)
		{
			return null;
		}

		private void GetNearestInternal(int index, Int3 point, NNConstraint constraint, ref GraphNode best, ref long bestSqrDist)
		{
		}

		public GraphNode GetNearestConnection(Int3 point, NNConstraint constraint, long maximumSqrConnectionLength)
		{
			return null;
		}

		private void GetNearestConnectionInternal(int index, Int3 point, NNConstraint constraint, ref GraphNode best, ref long bestSqrDist, long distanceThresholdOffset)
		{
		}

		public void GetInRange(Int3 point, long sqrRadius, List<GraphNode> buffer)
		{
		}

		private void GetInRangeInternal(int index, Int3 point, long sqrRadius, List<GraphNode> buffer)
		{
		}
	}
}
