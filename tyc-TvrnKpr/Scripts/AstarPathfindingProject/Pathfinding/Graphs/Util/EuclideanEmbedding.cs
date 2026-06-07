using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Unity.Collections;
using UnityEngine;

namespace Pathfinding.Graphs.Util
{
	[Serializable]
	public class EuclideanEmbedding
	{
		private class EuclideanEmbeddingSearchPath : Path
		{
			public UnsafeSpan<uint> costs;

			public uint costIndexStride;

			public uint pivotIndex;

			public GraphNode startNode;

			public uint furthestNodeScore;

			public GraphNode furthestNode;

			public static EuclideanEmbeddingSearchPath Construct(UnsafeSpan<uint> costs, uint costIndexStride, uint pivotIndex, GraphNode startNode)
			{
				return null;
			}

			protected override void OnFoundEndNode(ref SearchContext ctx, uint pathNode, uint hScore, uint gScore)
			{
			}

			protected override void OnHeapExhausted(ref SearchContext ctx)
			{
			}

			public override void OnVisitNode(ref SearchContext ctx, uint pathNode, uint hScore, uint gScore)
			{
			}

			protected override void Prepare(ref SearchContext ctx)
			{
			}
		}

		public HeuristicOptimizationMode mode;

		public int seed;

		public Transform pivotPointRoot;

		public int spreadOutCount;

		[NonSerialized]
		public bool dirty;

		private GraphNode[] pivots;

		private const uint ra = 12820163u;

		private const uint rc = 1140671485u;

		private uint rval;

		public NativeArray<uint> costs { get; private set; }

		public int pivotCount { get; private set; }

		private uint GetRandom()
		{
			return 0u;
		}

		public void OnDisable()
		{
		}

		public static uint GetHeuristic(UnsafeSpan<uint> costs, uint pivotCount, uint nodeIndex1, uint nodeIndex2)
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

		private void RecalculateCostsInner()
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
