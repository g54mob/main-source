using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class EuclideanEmbedding
	{
		public HeuristicOptimizationMode mode;

		public int seed;

		public Transform pivotPointRoot;

		public int spreadOutCount;

		[NonSerialized]
		public bool dirty;

		private uint[] costs;

		private int maxNodeIndex;

		private int pivotCount;

		private GraphNode[] pivots;

		private const uint ra = 12820163u;

		private const uint rc = 1140671485u;

		private uint rval;

		private object lockObj;

		private uint GetRandom()
		{
			return 0u;
		}

		private void EnsureCapacity(int index)
		{
		}

		public uint GetHeuristic(int nodeIndex1, int nodeIndex2)
		{
			return 0u;
		}

		private void GetClosestWalkableNodesToChildrenRecursively(Transform tr, List<GraphNode> nodes)
		{
		}

		private void PickNRandomNodes(int count, List<GraphNode> buffer)
		{
		}

		private GraphNode PickAnyWalkableNode()
		{
			return null;
		}

		public void RecalculatePivots()
		{
		}

		public void RecalculateCosts()
		{
		}

		private void ApplyGridGraphEndpointSpecialCase()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
