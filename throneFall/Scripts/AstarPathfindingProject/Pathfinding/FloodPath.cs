using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public class FloodPath : Path
	{
		public Vector3 originalStartPoint;

		public Vector3 startPoint;

		public GraphNode startNode;

		public bool saveParents = true;

		protected Dictionary<uint, uint> parents;

		private uint validationHash;

		public const uint TemporaryNodeBit = 2147483648u;

		public bool HasPathTo(GraphNode node)
		{
			if (parents != null)
			{
				for (uint num = 0u; num < node.PathNodeVariants; num++)
				{
					if (parents.ContainsKey(node.NodeIndex + num))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal bool IsValid(GlobalNodeStorage nodeStorage)
		{
			return nodeStorage.destroyedNodesVersion == validationHash;
		}

		public uint GetParent(uint node)
		{
			if (!parents.TryGetValue(node, out var value))
			{
				return 0u;
			}
			return value;
		}

		public static FloodPath Construct(Vector3 start, OnPathDelegate callback = null)
		{
			FloodPath floodPath = PathPool.GetPath<FloodPath>();
			floodPath.Setup(start, callback);
			return floodPath;
		}

		public static FloodPath Construct(GraphNode start, OnPathDelegate callback = null)
		{
			if (start == null)
			{
				throw new ArgumentNullException("start");
			}
			FloodPath floodPath = PathPool.GetPath<FloodPath>();
			floodPath.Setup(start, callback);
			return floodPath;
		}

		protected void Setup(Vector3 start, OnPathDelegate callback)
		{
			base.callback = callback;
			originalStartPoint = start;
			startPoint = start;
			heuristic = Heuristic.None;
		}

		protected void Setup(GraphNode start, OnPathDelegate callback)
		{
			base.callback = callback;
			originalStartPoint = (Vector3)start.position;
			startNode = start;
			startPoint = (Vector3)start.position;
			heuristic = Heuristic.None;
		}

		protected override void Reset()
		{
			base.Reset();
			originalStartPoint = Vector3.zero;
			startPoint = Vector3.zero;
			startNode = null;
			parents = new Dictionary<uint, uint>();
			saveParents = true;
			validationHash = 0u;
		}

		protected override void Prepare()
		{
			if (startNode == null)
			{
				NNInfo nearest = GetNearest(originalStartPoint);
				startPoint = nearest.position;
				startNode = nearest.node;
			}
			else
			{
				if (startNode.Destroyed)
				{
					FailWithError("Start node has been destroyed");
					return;
				}
				startPoint = (Vector3)startNode.position;
			}
			if (startNode == null)
			{
				FailWithError("Couldn't find a close node to the start point");
				return;
			}
			if (!CanTraverse(startNode))
			{
				FailWithError("The node closest to the start point could not be traversed");
				return;
			}
			pathHandler.AddTemporaryNode(new TemporaryNode
			{
				type = TemporaryNodeType.Start,
				position = (Int3)startPoint,
				associatedNode = startNode.NodeIndex
			});
			heuristicObjective = new HeuristicObjective(int3.zero, Heuristic.None, 0f);
			AddStartNodesToHeap();
			validationHash = pathHandler.nodeStorage.destroyedNodesVersion;
		}

		protected override void OnHeapExhausted()
		{
			base.CompleteState = PathCompleteState.Complete;
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
			throw new InvalidOperationException("FloodPaths do not have any end nodes");
		}

		public override void OnVisitNode(uint pathNode, uint hScore, uint gScore)
		{
			if (saveParents)
			{
				uint parentIndex = pathHandler.pathNodes[pathNode].parentIndex;
				parents[pathNode] = parentIndex | (uint)(pathHandler.IsTemporaryNode(parentIndex) ? int.MinValue : 0);
			}
		}
	}
}
