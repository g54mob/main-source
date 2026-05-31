using System;
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

		private void EnsureCapacity(int index)
		{
		}

		public uint GetHeuristic(int nodeIndex1, int nodeIndex2)
		{
			return 0u;
		}

		public void RecalculatePivots()
		{
		}

		public void RecalculateCosts()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
