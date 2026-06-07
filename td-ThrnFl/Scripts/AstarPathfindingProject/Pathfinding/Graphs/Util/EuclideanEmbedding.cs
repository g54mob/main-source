using System;
using System.Collections.Generic;
using Pathfinding.Drawing;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Mathematics;
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
				EuclideanEmbeddingSearchPath euclideanEmbeddingSearchPath = PathPool.GetPath<EuclideanEmbeddingSearchPath>();
				euclideanEmbeddingSearchPath.costs = costs;
				euclideanEmbeddingSearchPath.costIndexStride = costIndexStride;
				euclideanEmbeddingSearchPath.pivotIndex = pivotIndex;
				euclideanEmbeddingSearchPath.startNode = startNode;
				euclideanEmbeddingSearchPath.furthestNodeScore = 0u;
				euclideanEmbeddingSearchPath.furthestNode = null;
				return euclideanEmbeddingSearchPath;
			}

			protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
			{
				throw new InvalidOperationException();
			}

			protected override void OnHeapExhausted()
			{
				base.CompleteState = PathCompleteState.Complete;
			}

			public override void OnVisitNode(uint pathNode, uint hScore, uint gScore)
			{
				if (!pathHandler.IsTemporaryNode(pathNode))
				{
					GraphNode node = pathHandler.GetNode(pathNode);
					uint num = node.NodeIndex * costIndexStride;
					costs[num + pivotIndex] = math.min(costs[num + pivotIndex], gScore);
					uint num2 = uint.MaxValue;
					for (int i = 0; i <= pivotIndex; i++)
					{
						num2 = math.min(num2, costs[num + (uint)i]);
					}
					if (num2 > furthestNodeScore || furthestNode == null)
					{
						furthestNodeScore = num2;
						furthestNode = node;
					}
				}
			}

			protected override void Prepare()
			{
				pathHandler.AddTemporaryNode(new TemporaryNode
				{
					associatedNode = startNode.NodeIndex,
					position = startNode.position,
					type = TemporaryNodeType.Start
				});
				heuristicObjective = new HeuristicObjective(0, Heuristic.None, 0f);
				MarkNodesAdjacentToTemporaryEndNodes();
				AddStartNodesToHeap();
			}
		}

		public HeuristicOptimizationMode mode;

		public int seed;

		public Transform pivotPointRoot;

		public int spreadOutCount = 1;

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
			rval = 12820163 * rval + 1140671485;
			return rval;
		}

		public void OnDisable()
		{
			if (costs.IsCreated)
			{
				costs.Dispose();
			}
			costs = default(NativeArray<uint>);
			pivotCount = 0;
		}

		public static uint GetHeuristic(UnsafeSpan<uint> costs, uint pivotCount, uint nodeIndex1, uint nodeIndex2)
		{
			uint num = 0u;
			if (nodeIndex1 < costs.Length && nodeIndex2 < costs.Length)
			{
				for (uint num2 = 0u; num2 < pivotCount; num2++)
				{
					uint num3 = costs[nodeIndex1 * pivotCount + num2];
					uint num4 = costs[nodeIndex2 * pivotCount + num2];
					if (num3 != uint.MaxValue && num4 != uint.MaxValue)
					{
						uint num5 = (uint)math.abs((int)(num3 - num4));
						if (num5 > num)
						{
							num = num5;
						}
					}
				}
			}
			return num;
		}

		private void GetClosestWalkableNodesToChildrenRecursively(Transform tr, List<GraphNode> nodes)
		{
			foreach (Transform item in tr)
			{
				NNInfo nearest = AstarPath.active.GetNearest(item.position, NNConstraint.Walkable);
				if (nearest.node != null && nearest.node.Walkable)
				{
					nodes.Add(nearest.node);
				}
				GetClosestWalkableNodesToChildrenRecursively(item, nodes);
			}
		}

		private void PickNRandomNodes(int count, List<GraphNode> buffer)
		{
			int n = 0;
			NavGraph[] graphs = AstarPath.active.graphs;
			for (int i = 0; i < graphs.Length; i++)
			{
				graphs[i].GetNodes(delegate(GraphNode node)
				{
					if (!node.Destroyed && node.Walkable)
					{
						n++;
						if (GetRandom() % n < count)
						{
							if (buffer.Count < count)
							{
								buffer.Add(node);
							}
							else
							{
								buffer[n % buffer.Count] = node;
							}
						}
					}
				});
			}
		}

		private GraphNode PickAnyWalkableNode()
		{
			NavGraph[] graphs = AstarPath.active.graphs;
			GraphNode first = null;
			for (int i = 0; i < graphs.Length; i++)
			{
				graphs[i].GetNodes(delegate(GraphNode node)
				{
					if (node != null && node.Walkable && first == null)
					{
						first = node;
					}
				});
			}
			return first;
		}

		public void RecalculatePivots()
		{
			if (mode == HeuristicOptimizationMode.None)
			{
				pivotCount = 0;
				pivots = null;
				return;
			}
			rval = (uint)seed;
			List<GraphNode> list = ListPool<GraphNode>.Claim();
			switch (mode)
			{
			case HeuristicOptimizationMode.Custom:
				if (pivotPointRoot == null)
				{
					throw new Exception("heuristicOptimizationMode is HeuristicOptimizationMode.Custom, but no 'customHeuristicOptimizationPivotsRoot' is set");
				}
				GetClosestWalkableNodesToChildrenRecursively(pivotPointRoot, list);
				break;
			case HeuristicOptimizationMode.Random:
				PickNRandomNodes(spreadOutCount, list);
				break;
			case HeuristicOptimizationMode.RandomSpreadOut:
			{
				if (pivotPointRoot != null)
				{
					GetClosestWalkableNodesToChildrenRecursively(pivotPointRoot, list);
				}
				if (list.Count == 0)
				{
					GraphNode graphNode = PickAnyWalkableNode();
					if (graphNode == null)
					{
						Debug.LogError("Could not find any walkable node in any of the graphs.");
						ListPool<GraphNode>.Release(ref list);
						return;
					}
					list.Add(graphNode);
				}
				int num = spreadOutCount - list.Count;
				for (int i = 0; i < num; i++)
				{
					list.Add(null);
				}
				break;
			}
			default:
				throw new Exception("Invalid HeuristicOptimizationMode: " + mode);
			}
			pivots = list.ToArray();
			ListPool<GraphNode>.Release(ref list);
		}

		public void RecalculateCosts()
		{
			if (pivots == null)
			{
				RecalculatePivots();
			}
			if (mode != HeuristicOptimizationMode.None)
			{
				RecalculateCostsInner();
			}
		}

		private void RecalculateCostsInner()
		{
			pivotCount = 0;
			for (int i = 0; i < pivots.Length; i++)
			{
				if (pivots[i] != null && (pivots[i].Destroyed || !pivots[i].Walkable))
				{
					throw new Exception("Invalid pivot nodes (destroyed or unwalkable)");
				}
			}
			if (mode != HeuristicOptimizationMode.RandomSpreadOut)
			{
				for (int j = 0; j < pivots.Length; j++)
				{
					if (pivots[j] == null)
					{
						throw new Exception("Invalid pivot nodes (null)");
					}
				}
			}
			pivotCount = pivots.Length;
			Action<int> startCostCalculation = null;
			int numComplete = 0;
			uint nextNodeIndex = AstarPath.active.nodeStorage.nextNodeIndex;
			if (costs.IsCreated)
			{
				costs.Dispose();
			}
			costs = new NativeArray<uint>((int)nextNodeIndex * pivotCount, Allocator.Persistent);
			costs.AsUnsafeSpan().Fill(uint.MaxValue);
			startCostCalculation = delegate(int pivotIndex)
			{
				GraphNode startNode = pivots[pivotIndex];
				EuclideanEmbeddingSearchPath path = EuclideanEmbeddingSearchPath.Construct(costs.AsUnsafeSpan(), (uint)pivotCount, (uint)pivotIndex, startNode);
				path.immediateCallback = delegate
				{
					if (mode == HeuristicOptimizationMode.RandomSpreadOut && pivotIndex < pivots.Length - 1)
					{
						if (pivots[pivotIndex + 1] == null)
						{
							pivots[pivotIndex + 1] = path.furthestNode;
							if (path.furthestNode == null)
							{
								Debug.LogError("Failed generating random pivot points for heuristic optimizations");
								return;
							}
						}
						startCostCalculation(pivotIndex + 1);
					}
					int num2 = numComplete;
					numComplete = num2 + 1;
					if (numComplete == pivotCount)
					{
						ApplyGridGraphEndpointSpecialCase();
					}
				};
				AstarPath.StartPath(path, pushToFront: true, assumeInPlayMode: true);
			};
			if (mode != HeuristicOptimizationMode.RandomSpreadOut)
			{
				for (int num = 0; num < pivots.Length; num++)
				{
					startCostCalculation(num);
				}
			}
			else
			{
				startCostCalculation(0);
			}
			dirty = false;
		}

		private void ApplyGridGraphEndpointSpecialCase()
		{
			UnsafeSpan<uint> unsafeSpan = costs.AsUnsafeSpan();
			NavGraph[] graphs = AstarPath.active.graphs;
			for (int i = 0; i < graphs.Length; i++)
			{
				if (!(graphs[i] is GridGraph { nodes: var nodes } gridGraph))
				{
					continue;
				}
				int num = ((gridGraph.neighbours == NumNeighbours.Four) ? 4 : ((gridGraph.neighbours == NumNeighbours.Eight) ? 8 : 6));
				for (int j = 0; j < gridGraph.depth; j++)
				{
					for (int k = 0; k < gridGraph.width; k++)
					{
						GridNodeBase gridNodeBase = nodes[j * gridGraph.width + k];
						if (gridNodeBase.Walkable)
						{
							continue;
						}
						uint num2 = gridNodeBase.NodeIndex * (uint)pivotCount;
						for (int l = 0; l < pivotCount; l++)
						{
							unsafeSpan[num2 + (uint)l] = uint.MaxValue;
						}
						for (int m = 0; m < num; m++)
						{
							int num3;
							int num4;
							if (gridGraph.neighbours == NumNeighbours.Six)
							{
								num3 = k + GridGraph.neighbourXOffsets[GridGraph.hexagonNeighbourIndices[m]];
								num4 = j + GridGraph.neighbourZOffsets[GridGraph.hexagonNeighbourIndices[m]];
							}
							else
							{
								num3 = k + GridGraph.neighbourXOffsets[m];
								num4 = j + GridGraph.neighbourZOffsets[m];
							}
							if (num3 < 0 || num4 < 0 || num3 >= gridGraph.width || num4 >= gridGraph.depth)
							{
								continue;
							}
							GridNodeBase gridNodeBase2 = gridGraph.nodes[num4 * gridGraph.width + num3];
							if (gridNodeBase2.Walkable)
							{
								for (uint num5 = 0u; num5 < pivotCount; num5++)
								{
									uint val = unsafeSpan[(uint)((int)gridNodeBase2.NodeIndex * pivotCount) + num5] + gridGraph.neighbourCosts[m];
									unsafeSpan[num2 + num5] = Math.Min(unsafeSpan[num2 + num5], val);
								}
							}
						}
					}
				}
			}
		}

		public void OnDrawGizmos()
		{
			if (pivots == null)
			{
				return;
			}
			for (int i = 0; i < pivots.Length; i++)
			{
				if (pivots[i] != null && !pivots[i].Destroyed)
				{
					Draw.SolidBox((Vector3)pivots[i].position, Vector3.one, new Color(53f / 85f, 0.36862746f, 0.7607843f, 0.8f));
				}
			}
		}
	}
}
