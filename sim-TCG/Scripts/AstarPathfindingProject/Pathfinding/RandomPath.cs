using System;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public class RandomPath : ABPath
	{
		public int searchLength;

		public int spread = 5000;

		public float aimStrength;

		private uint chosenPathNodeIndex;

		private uint chosenPathNodeGScore;

		private uint maxGScorePathNodeIndex;

		private uint maxGScore;

		public Vector3 aim;

		private int nodesEvaluatedRep;

		private readonly System.Random rnd = new System.Random();

		protected override bool hasEndPoint => false;

		public override bool endPointKnownBeforeCalculation => false;

		protected override void Reset()
		{
			base.Reset();
			searchLength = 5000;
			spread = 5000;
			aimStrength = 0f;
			chosenPathNodeIndex = uint.MaxValue;
			maxGScorePathNodeIndex = uint.MaxValue;
			chosenPathNodeGScore = 0u;
			maxGScore = 0u;
			aim = Vector3.zero;
			nodesEvaluatedRep = 0;
		}

		public static RandomPath Construct(Vector3 start, int length, OnPathDelegate callback = null)
		{
			RandomPath randomPath = PathPool.GetPath<RandomPath>();
			randomPath.Setup(start, length, callback);
			return randomPath;
		}

		protected RandomPath Setup(Vector3 start, int length, OnPathDelegate callback)
		{
			base.callback = callback;
			searchLength = length;
			originalStartPoint = start;
			originalEndPoint = Vector3.zero;
			startPoint = start;
			endPoint = Vector3.zero;
			return this;
		}

		protected override void ReturnPath()
		{
			if (path != null && path.Count > 0)
			{
				originalEndPoint = endPoint;
			}
			if (callback != null)
			{
				callback(this);
			}
		}

		protected override void Prepare()
		{
			nnConstraint.tags = enabledTags;
			NNInfo nearest = AstarPath.active.GetNearest(startPoint, nnConstraint);
			startPoint = nearest.position;
			endPoint = startPoint;
			if (nearest.node == null)
			{
				FailWithError("Couldn't find close nodes to the start point");
				return;
			}
			if (!CanTraverse(nearest.node))
			{
				FailWithError("The node closest to the start point could not be traversed");
				return;
			}
			heuristicScale = aimStrength;
			pathHandler.AddTemporaryNode(new TemporaryNode
			{
				type = TemporaryNodeType.Start,
				position = (Int3)nearest.position,
				associatedNode = nearest.node.NodeIndex
			});
			heuristicObjective = new HeuristicObjective((int3)(Int3)aim, heuristic, heuristicScale);
			AddStartNodesToHeap();
		}

		protected override void OnHeapExhausted()
		{
			if (chosenPathNodeIndex == uint.MaxValue && maxGScorePathNodeIndex != uint.MaxValue)
			{
				chosenPathNodeIndex = maxGScorePathNodeIndex;
				chosenPathNodeGScore = maxGScore;
			}
			if (chosenPathNodeIndex != uint.MaxValue)
			{
				OnFoundEndNode(chosenPathNodeIndex, 0u, chosenPathNodeGScore);
			}
			else
			{
				FailWithError("Not a single node found to search");
			}
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
			if (pathHandler.IsTemporaryNode(pathNode))
			{
				base.OnFoundEndNode(pathNode, hScore, gScore);
				return;
			}
			GraphNode node = pathHandler.GetNode(pathNode);
			endPoint = node.RandomPointOnSurface();
			cost = gScore;
			base.CompleteState = PathCompleteState.Complete;
			Trace(pathNode);
		}

		public override void OnVisitNode(uint pathNode, uint hScore, uint gScore)
		{
			if (base.CompleteState != PathCompleteState.NotCalculated)
			{
				return;
			}
			if (gScore >= searchLength)
			{
				if (gScore <= searchLength + spread)
				{
					nodesEvaluatedRep++;
					if (rnd.NextDouble() <= (double)(1f / (float)nodesEvaluatedRep))
					{
						chosenPathNodeIndex = pathNode;
						chosenPathNodeGScore = gScore;
					}
				}
				else
				{
					if (chosenPathNodeIndex == uint.MaxValue)
					{
						chosenPathNodeIndex = pathNode;
						chosenPathNodeGScore = gScore;
					}
					OnFoundEndNode(chosenPathNodeIndex, 0u, chosenPathNodeGScore);
				}
			}
			else if (gScore > maxGScore)
			{
				maxGScore = gScore;
				maxGScorePathNodeIndex = pathNode;
			}
		}
	}
}
