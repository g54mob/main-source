using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pathfinding
{
	public class ABPath : Path
	{
		public Vector3 originalStartPoint;

		public Vector3 originalEndPoint;

		public Vector3 startPoint;

		public Vector3 endPoint;

		public uint cost;

		public bool calculatePartial;

		protected uint partialBestTargetPathNodeIndex;

		protected uint partialBestTargetHScore = uint.MaxValue;

		protected uint partialBestTargetGScore = uint.MaxValue;

		public PathEndingCondition endingCondition;

		private static readonly NNConstraint NNConstraintNone = NNConstraint.None;

		public GraphNode startNode
		{
			get
			{
				if (path.Count <= 0)
				{
					return null;
				}
				return path[0];
			}
		}

		public GraphNode endNode
		{
			get
			{
				if (path.Count <= 0)
				{
					return null;
				}
				return path[path.Count - 1];
			}
		}

		protected virtual bool hasEndPoint => true;

		public virtual bool endPointKnownBeforeCalculation => true;

		public static ABPath Construct(Vector3 start, Vector3 end, OnPathDelegate callback = null)
		{
			ABPath aBPath = PathPool.GetPath<ABPath>();
			aBPath.Setup(start, end, callback);
			return aBPath;
		}

		protected void Setup(Vector3 start, Vector3 end, OnPathDelegate callbackDelegate)
		{
			callback = callbackDelegate;
			UpdateStartEnd(start, end);
		}

		public static ABPath FakePath(List<Vector3> vectorPath, List<GraphNode> nodePath = null)
		{
			ABPath aBPath = PathPool.GetPath<ABPath>();
			for (int i = 0; i < vectorPath.Count; i++)
			{
				aBPath.vectorPath.Add(vectorPath[i]);
			}
			aBPath.completeState = PathCompleteState.Complete;
			((IPathInternals)aBPath).AdvanceState(PathState.Returned);
			if (vectorPath.Count > 0)
			{
				aBPath.UpdateStartEnd(vectorPath[0], vectorPath[vectorPath.Count - 1]);
			}
			if (nodePath != null)
			{
				for (int j = 0; j < nodePath.Count; j++)
				{
					aBPath.path.Add(nodePath[j]);
				}
			}
			return aBPath;
		}

		protected void UpdateStartEnd(Vector3 start, Vector3 end)
		{
			originalStartPoint = start;
			originalEndPoint = end;
			startPoint = start;
			endPoint = end;
		}

		protected override void Reset()
		{
			base.Reset();
			originalStartPoint = Vector3.zero;
			originalEndPoint = Vector3.zero;
			startPoint = Vector3.zero;
			endPoint = Vector3.zero;
			calculatePartial = false;
			partialBestTargetPathNodeIndex = 0u;
			partialBestTargetHScore = uint.MaxValue;
			partialBestTargetGScore = uint.MaxValue;
			cost = 0u;
			endingCondition = null;
		}

		protected virtual bool EndPointGridGraphSpecialCase(GraphNode closestWalkableEndNode, Vector3 originalEndPoint, int targetIndex)
		{
			if (closestWalkableEndNode is GridNode gridNode)
			{
				GridGraph gridGraph = GridNode.GetGridGraph(gridNode.GraphIndex);
				GridNode gridNode2 = gridGraph.GetNearest(originalEndPoint, NNConstraintNone).node as GridNode;
				if (gridNode != gridNode2 && gridNode2 != null)
				{
					int num = gridNode.NodeInGridIndex % gridGraph.width;
					int num2 = gridNode.NodeInGridIndex / gridGraph.width;
					int num3 = gridNode2.NodeInGridIndex % gridGraph.width;
					int num4 = gridNode2.NodeInGridIndex / gridGraph.width;
					bool flag = false;
					switch (gridGraph.neighbours)
					{
					case NumNeighbours.Four:
						if ((num == num3 && Math.Abs(num2 - num4) == 1) || (num2 == num4 && Math.Abs(num - num3) == 1))
						{
							flag = true;
						}
						break;
					case NumNeighbours.Eight:
						if (Math.Abs(num - num3) <= 1 && Math.Abs(num2 - num4) <= 1)
						{
							flag = true;
						}
						break;
					case NumNeighbours.Six:
					{
						for (int i = 0; i < 6; i++)
						{
							int num5 = num3 + GridGraph.neighbourXOffsets[GridGraph.hexagonNeighbourIndices[i]];
							int num6 = num4 + GridGraph.neighbourZOffsets[GridGraph.hexagonNeighbourIndices[i]];
							if (num == num5 && num2 == num6)
							{
								flag = true;
								break;
							}
						}
						break;
					}
					default:
						throw new Exception("Unhandled NumNeighbours");
					}
					if (flag)
					{
						AddEndpointsForSurroundingGridNodes(gridNode2, originalEndPoint, targetIndex);
						return true;
					}
				}
			}
			return false;
		}

		private void AddEndpointsForSurroundingGridNodes(GridNode gridNode, Vector3 desiredPoint, int targetIndex)
		{
			GridGraph gridGraph = GridNode.GetGridGraph(gridNode.GraphIndex);
			int num = ((gridGraph.neighbours == NumNeighbours.Four) ? 4 : ((gridGraph.neighbours == NumNeighbours.Eight) ? 8 : 6));
			int num2 = gridNode.NodeInGridIndex % gridGraph.width;
			int num3 = gridNode.NodeInGridIndex / gridGraph.width;
			for (int i = 0; i < num; i++)
			{
				int x;
				int z;
				if (gridGraph.neighbours == NumNeighbours.Six)
				{
					x = num2 + GridGraph.neighbourXOffsets[GridGraph.hexagonNeighbourIndices[i]];
					z = num3 + GridGraph.neighbourZOffsets[GridGraph.hexagonNeighbourIndices[i]];
				}
				else
				{
					x = num2 + GridGraph.neighbourXOffsets[i];
					z = num3 + GridGraph.neighbourZOffsets[i];
				}
				GridNodeBase node = gridGraph.GetNode(x, z);
				if (node != null)
				{
					pathHandler.AddTemporaryNode(new TemporaryNode
					{
						type = TemporaryNodeType.End,
						position = (Int3)node.ClosestPointOnNode(desiredPoint),
						associatedNode = node.NodeIndex,
						targetIndex = targetIndex
					});
				}
			}
		}

		protected override void Prepare()
		{
			NNInfo nearest = GetNearest(startPoint);
			if (nnConstraint is PathNNConstraint pathNNConstraint)
			{
				pathNNConstraint.SetStart(nearest.node);
			}
			startPoint = nearest.position;
			if (nearest.node == null)
			{
				FailWithError("Couldn't find a node close to the start point");
				return;
			}
			if (!CanTraverse(nearest.node))
			{
				FailWithError("The node closest to the start point could not be traversed");
				return;
			}
			pathHandler.AddTemporaryNode(new TemporaryNode
			{
				associatedNode = nearest.node.NodeIndex,
				position = (Int3)nearest.position,
				type = TemporaryNodeType.Start
			});
			uint targetNodeIndex = 0u;
			if (hasEndPoint)
			{
				NNInfo nearest2 = GetNearest(originalEndPoint);
				endPoint = nearest2.position;
				if (nearest2.node == null)
				{
					FailWithError("Couldn't find a node close to the end point");
					return;
				}
				if (!CanTraverse(nearest2.node))
				{
					FailWithError("The node closest to the end point could not be traversed");
					return;
				}
				if (nearest.node.Area != nearest2.node.Area)
				{
					FailWithError("There is no valid path to the target");
					return;
				}
				targetNodeIndex = nearest2.node.NodeIndex;
				if (!EndPointGridGraphSpecialCase(nearest2.node, originalEndPoint, 0))
				{
					pathHandler.AddTemporaryNode(new TemporaryNode
					{
						associatedNode = nearest2.node.NodeIndex,
						position = (Int3)nearest2.position,
						type = TemporaryNodeType.End
					});
				}
			}
			TemporaryEndNodesBoundingBox(out var mn, out var mx);
			heuristicObjective = new HeuristicObjective(mn, mx, heuristic, heuristicScale, targetNodeIndex, AstarPath.active.euclideanEmbedding);
			MarkNodesAdjacentToTemporaryEndNodes();
			AddStartNodesToHeap();
		}

		private void CompletePartial()
		{
			base.CompleteState = PathCompleteState.Partial;
			endPoint = pathHandler.GetNode(partialBestTargetPathNodeIndex).ClosestPointOnNode(originalEndPoint);
			cost = partialBestTargetGScore;
			Trace(partialBestTargetPathNodeIndex);
		}

		protected override void OnHeapExhausted()
		{
			if (calculatePartial && partialBestTargetPathNodeIndex != 0)
			{
				CompletePartial();
			}
			else
			{
				FailWithError("Searched all reachable nodes, but could not find target. This can happen if you have nodes with a different tag blocking the way to the goal. You can enable path.calculatePartial to handle that case as a workaround (though this comes with a performance cost).");
			}
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
			if (pathHandler.IsTemporaryNode(pathNode))
			{
				TemporaryNode temporaryNode = pathHandler.GetTemporaryNode(pathNode);
				GraphNode node = pathHandler.GetNode(temporaryNode.associatedNode);
				if (endingCondition != null && !endingCondition.TargetFound(node, partialBestTargetHScore, gScore))
				{
					return;
				}
				endPoint = (Vector3)temporaryNode.position;
				endPoint = node.ClosestPointOnNode(endPoint);
			}
			else
			{
				GraphNode node2 = pathHandler.GetNode(pathNode);
				endPoint = (Vector3)node2.position;
			}
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
			if (endingCondition != null)
			{
				GraphNode node = pathHandler.GetNode(pathNode);
				if (endingCondition.TargetFound(node, hScore, gScore))
				{
					OnFoundEndNode(pathNode, hScore, gScore);
					if (base.CompleteState == PathCompleteState.Complete)
					{
						return;
					}
				}
			}
			if (hScore < partialBestTargetHScore)
			{
				partialBestTargetPathNodeIndex = pathNode;
				partialBestTargetHScore = hScore;
				partialBestTargetGScore = gScore;
			}
		}

		protected override string DebugString(PathLog logMode)
		{
			if (logMode == PathLog.None || (!base.error && logMode == PathLog.OnlyErrors))
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			DebugStringPrefix(logMode, stringBuilder);
			if (!base.error)
			{
				stringBuilder.Append(" Path Cost: ");
				stringBuilder.Append(cost);
			}
			if (!base.error && logMode == PathLog.Heavy)
			{
				Vector3 vector;
				if (hasEndPoint && endNode != null)
				{
					stringBuilder.Append("\n\tPoint: ");
					vector = endPoint;
					stringBuilder.Append(vector.ToString());
					stringBuilder.Append("\n\tGraph: ");
					stringBuilder.Append(endNode.GraphIndex);
				}
				stringBuilder.Append("\nStart Node");
				stringBuilder.Append("\n\tPoint: ");
				vector = startPoint;
				stringBuilder.Append(vector.ToString());
				stringBuilder.Append("\n\tGraph: ");
				if (startNode != null)
				{
					stringBuilder.Append(startNode.GraphIndex);
				}
				else
				{
					stringBuilder.Append("< null startNode >");
				}
			}
			DebugStringSuffix(logMode, stringBuilder);
			return stringBuilder.ToString();
		}
	}
}
