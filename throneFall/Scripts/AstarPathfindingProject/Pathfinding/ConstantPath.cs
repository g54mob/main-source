using System;
using System.Collections.Generic;
using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public class ConstantPath : Path
	{
		public GraphNode startNode;

		public Vector3 startPoint;

		public Vector3 originalStartPoint;

		public List<GraphNode> allNodes;

		public PathEndingCondition endingCondition;

		public static ConstantPath Construct(Vector3 start, int maxGScore, OnPathDelegate callback = null)
		{
			ConstantPath constantPath = PathPool.GetPath<ConstantPath>();
			constantPath.Setup(start, maxGScore, callback);
			return constantPath;
		}

		protected void Setup(Vector3 start, int maxGScore, OnPathDelegate callback)
		{
			base.callback = callback;
			startPoint = start;
			originalStartPoint = startPoint;
			endingCondition = new EndingConditionDistance(this, maxGScore);
		}

		protected override void OnEnterPool()
		{
			base.OnEnterPool();
			if (allNodes != null)
			{
				ListPool<GraphNode>.Release(ref allNodes);
			}
		}

		protected override void Reset()
		{
			base.Reset();
			allNodes = ListPool<GraphNode>.Claim();
			endingCondition = null;
			originalStartPoint = Vector3.zero;
			startPoint = Vector3.zero;
			startNode = null;
			heuristic = Heuristic.None;
		}

		protected override void Prepare()
		{
			NNInfo nearest = GetNearest(startPoint);
			startNode = nearest.node;
			if (startNode == null)
			{
				FailWithError("Could not find close node to the start point");
				return;
			}
			pathHandler.AddTemporaryNode(new TemporaryNode
			{
				type = TemporaryNodeType.Start,
				position = (Int3)nearest.position,
				associatedNode = startNode.NodeIndex
			});
			heuristicObjective = new HeuristicObjective(int3.zero, Heuristic.None, 0f);
			AddStartNodesToHeap();
		}

		protected override void OnHeapExhausted()
		{
			base.CompleteState = PathCompleteState.Complete;
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
			throw new InvalidOperationException("ConstantPaths do not have any end nodes");
		}

		public override void OnVisitNode(uint pathNode, uint hScore, uint gScore)
		{
			GraphNode node = pathHandler.GetNode(pathNode);
			if (endingCondition.TargetFound(node, hScore, gScore))
			{
				base.CompleteState = PathCompleteState.Complete;
			}
			else
			{
				allNodes.Add(node);
			}
		}
	}
}
