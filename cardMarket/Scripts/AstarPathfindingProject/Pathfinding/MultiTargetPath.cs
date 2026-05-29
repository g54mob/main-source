using System;
using System.Collections.Generic;
using System.Text;
using Pathfinding.Util;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public class MultiTargetPath : ABPath
	{
		public OnPathDelegate[] callbacks;

		public GraphNode[] targetNodes;

		protected int targetNodeCount;

		public bool[] targetsFound;

		public uint[] targetPathCosts;

		public Vector3[] targetPoints;

		public Vector3[] originalTargetPoints;

		public List<Vector3>[] vectorPaths;

		public List<GraphNode>[] nodePaths;

		public bool pathsForAll = true;

		public int chosenTarget = -1;

		public bool inverted { get; protected set; }

		public override bool endPointKnownBeforeCalculation => false;

		public static MultiTargetPath Construct(Vector3[] startPoints, Vector3 target, OnPathDelegate[] callbackDelegates, OnPathDelegate callback = null)
		{
			MultiTargetPath multiTargetPath = Construct(target, startPoints, callbackDelegates, callback);
			multiTargetPath.inverted = true;
			return multiTargetPath;
		}

		public static MultiTargetPath Construct(Vector3 start, Vector3[] targets, OnPathDelegate[] callbackDelegates, OnPathDelegate callback = null)
		{
			MultiTargetPath multiTargetPath = PathPool.GetPath<MultiTargetPath>();
			multiTargetPath.Setup(start, targets, callbackDelegates, callback);
			return multiTargetPath;
		}

		protected void Setup(Vector3 start, Vector3[] targets, OnPathDelegate[] callbackDelegates, OnPathDelegate callback)
		{
			inverted = false;
			base.callback = callback;
			callbacks = callbackDelegates;
			if (callbacks != null && callbacks.Length != targets.Length)
			{
				throw new ArgumentException("The targets array must have the same length as the callbackDelegates array");
			}
			targetPoints = targets;
			originalStartPoint = start;
			startPoint = start;
			if (targets.Length == 0)
			{
				FailWithError("No targets were assigned to the MultiTargetPath");
				return;
			}
			endPoint = targets[0];
			originalTargetPoints = new Vector3[targetPoints.Length];
			for (int i = 0; i < targetPoints.Length; i++)
			{
				originalTargetPoints[i] = targetPoints[i];
			}
		}

		protected override void Reset()
		{
			base.Reset();
			pathsForAll = true;
			chosenTarget = -1;
			inverted = true;
		}

		protected override void OnEnterPool()
		{
			if (vectorPaths != null)
			{
				for (int i = 0; i < vectorPaths.Length; i++)
				{
					if (vectorPaths[i] != null)
					{
						ListPool<Vector3>.Release(vectorPaths[i]);
					}
				}
			}
			vectorPaths = null;
			vectorPath = null;
			if (nodePaths != null)
			{
				for (int j = 0; j < nodePaths.Length; j++)
				{
					if (nodePaths[j] != null)
					{
						ListPool<GraphNode>.Release(nodePaths[j]);
					}
				}
			}
			nodePaths = null;
			path = null;
			callbacks = null;
			targetNodes = null;
			targetsFound = null;
			targetPathCosts = null;
			targetPoints = null;
			originalTargetPoints = null;
			base.OnEnterPool();
		}

		private void ChooseShortestPath()
		{
			chosenTarget = -1;
			if (nodePaths == null)
			{
				return;
			}
			uint num = uint.MaxValue;
			for (int i = 0; i < nodePaths.Length; i++)
			{
				if (nodePaths[i] != null)
				{
					uint num2 = targetPathCosts[i];
					if (num2 < num)
					{
						chosenTarget = i;
						num = num2;
					}
				}
			}
		}

		private void SetPathParametersForReturn(int target)
		{
			path = nodePaths[target];
			vectorPath = vectorPaths[target];
			if (inverted)
			{
				startPoint = targetPoints[target];
				originalStartPoint = originalTargetPoints[target];
			}
			else
			{
				endPoint = targetPoints[target];
				originalEndPoint = originalTargetPoints[target];
			}
			cost = ((path != null) ? targetPathCosts[target] : 0u);
		}

		protected override void ReturnPath()
		{
			if (base.error)
			{
				if (callbacks != null)
				{
					for (int i = 0; i < callbacks.Length; i++)
					{
						if (callbacks[i] != null)
						{
							callbacks[i](this);
						}
					}
				}
				if (callback != null)
				{
					callback(this);
				}
				return;
			}
			bool flag = false;
			if (inverted)
			{
				endPoint = startPoint;
				originalEndPoint = originalStartPoint;
			}
			for (int j = 0; j < nodePaths.Length; j++)
			{
				if (nodePaths[j] != null)
				{
					completeState = PathCompleteState.Complete;
					flag = true;
				}
				else
				{
					completeState = PathCompleteState.Error;
				}
				if (callbacks != null && callbacks[j] != null)
				{
					SetPathParametersForReturn(j);
					callbacks[j](this);
					vectorPaths[j] = vectorPath;
				}
			}
			if (flag)
			{
				completeState = PathCompleteState.Complete;
				SetPathParametersForReturn(chosenTarget);
			}
			else
			{
				completeState = PathCompleteState.Error;
			}
			if (callback != null)
			{
				callback(this);
			}
		}

		protected void RebuildOpenList()
		{
			BinaryHeap heap = pathHandler.heap;
			for (int i = 0; i < heap.numberOfItems; i++)
			{
				uint pathNodeIndex = heap.GetPathNodeIndex(i);
				Int3 int5 = ((!pathHandler.IsTemporaryNode(pathNodeIndex)) ? pathHandler.GetNode(pathNodeIndex).DecodeVariantPosition(pathNodeIndex, pathHandler.pathNodes[pathNodeIndex].fractionAlongEdge) : pathHandler.GetTemporaryNode(pathNodeIndex).position);
				uint h = (uint)heuristicObjective.Calculate((int3)int5, 0u);
				heap.SetH(i, h);
			}
			pathHandler.heap.Rebuild(pathHandler.pathNodes);
		}

		protected override void Prepare()
		{
			nnConstraint.tags = enabledTags;
			NNInfo nearest = AstarPath.active.GetNearest(startPoint, nnConstraint);
			GraphNode node = nearest.node;
			if (endingCondition != null)
			{
				FailWithError("Multi target paths cannot use custom ending conditions");
				return;
			}
			if (node == null)
			{
				FailWithError("Could not find start node for multi target path");
				return;
			}
			if (!CanTraverse(node))
			{
				FailWithError("The node closest to the start point could not be traversed");
				return;
			}
			if (nnConstraint is PathNNConstraint pathNNConstraint)
			{
				pathNNConstraint.SetStart(nearest.node);
			}
			pathHandler.AddTemporaryNode(new TemporaryNode
			{
				associatedNode = nearest.node.NodeIndex,
				position = (Int3)nearest.position,
				type = TemporaryNodeType.Start
			});
			vectorPaths = new List<Vector3>[targetPoints.Length];
			nodePaths = new List<GraphNode>[targetPoints.Length];
			targetNodes = new GraphNode[targetPoints.Length];
			targetsFound = new bool[targetPoints.Length];
			targetPathCosts = new uint[targetPoints.Length];
			targetNodeCount = 0;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i < targetPoints.Length; i++)
			{
				Vector3 position = targetPoints[i];
				NNInfo nearest2 = AstarPath.active.GetNearest(position, nnConstraint);
				targetNodes[i] = nearest2.node;
				targetPoints[i] = nearest2.position;
				if (targetNodes[i] != null)
				{
					flag3 = true;
				}
				bool flag4 = false;
				if (nearest2.node != null && CanTraverse(nearest2.node))
				{
					flag = true;
				}
				else
				{
					flag4 = true;
				}
				if (nearest2.node != null && nearest2.node.Area == node.Area)
				{
					flag2 = true;
				}
				else
				{
					flag4 = true;
				}
				if (flag4)
				{
					targetsFound[i] = true;
					continue;
				}
				targetNodeCount++;
				if (!EndPointGridGraphSpecialCase(nearest2.node, position, i))
				{
					pathHandler.AddTemporaryNode(new TemporaryNode
					{
						associatedNode = nearest2.node.NodeIndex,
						position = (Int3)nearest2.position,
						targetIndex = i,
						type = TemporaryNodeType.End
					});
				}
			}
			startPoint = nearest.position;
			if (!flag3)
			{
				FailWithError("Couldn't find a valid node close to the any of the end points");
				return;
			}
			if (!flag)
			{
				FailWithError("No target nodes could be traversed");
				return;
			}
			if (!flag2)
			{
				FailWithError("There's no valid path to any of the given targets");
				return;
			}
			MarkNodesAdjacentToTemporaryEndNodes();
			AddStartNodesToHeap();
			RecalculateHTarget();
		}

		private void RecalculateHTarget()
		{
			if (pathsForAll)
			{
				int3 int5 = FirstTemporaryEndNode();
				heuristicObjective = new HeuristicObjective(int5, int5, heuristic, heuristicScale, 0u, null);
			}
			else
			{
				TemporaryEndNodesBoundingBox(out var mn, out var mx);
				heuristicObjective = new HeuristicObjective(mn, mx, heuristic, heuristicScale, 0u, null);
			}
			RebuildOpenList();
		}

		protected override void Cleanup()
		{
			ChooseShortestPath();
			base.Cleanup();
		}

		protected override void OnHeapExhausted()
		{
			base.CompleteState = PathCompleteState.Complete;
		}

		protected override void OnFoundEndNode(uint pathNode, uint hScore, uint gScore)
		{
			if (!pathHandler.IsTemporaryNode(pathNode))
			{
				FailWithError("Expected the end node to be a temporary node. Cannot determine which path it belongs to. This could happen if you are using a custom ending condition for the path.");
				return;
			}
			int targetIndex = pathHandler.GetTemporaryNode(pathNode).targetIndex;
			if (targetsFound[targetIndex])
			{
				throw new ArgumentException("This target has already been found");
			}
			Trace(pathNode);
			vectorPaths[targetIndex] = vectorPath;
			nodePaths[targetIndex] = path;
			vectorPath = ListPool<Vector3>.Claim();
			path = ListPool<GraphNode>.Claim();
			targetsFound[targetIndex] = true;
			targetPathCosts[targetIndex] = gScore;
			targetNodeCount--;
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint nodeIndex = pathHandler.temporaryNodeStartIndex + num;
				ref TemporaryNode temporaryNode = ref pathHandler.GetTemporaryNode(nodeIndex);
				if (temporaryNode.type == TemporaryNodeType.End && temporaryNode.targetIndex == targetIndex)
				{
					temporaryNode.type = TemporaryNodeType.Ignore;
				}
			}
			if (!pathsForAll)
			{
				base.CompleteState = PathCompleteState.Complete;
				targetNodeCount = 0;
			}
			else if (targetNodeCount <= 0)
			{
				base.CompleteState = PathCompleteState.Complete;
			}
			else
			{
				RecalculateHTarget();
			}
		}

		protected override void Trace(uint pathNodeIndex)
		{
			base.Trace(pathNodeIndex);
			if (inverted)
			{
				int num = path.Count / 2;
				for (int i = 0; i < num; i++)
				{
					GraphNode value = path[i];
					path[i] = path[path.Count - i - 1];
					path[path.Count - i - 1] = value;
				}
				for (int j = 0; j < num; j++)
				{
					Vector3 value2 = vectorPath[j];
					vectorPath[j] = vectorPath[vectorPath.Count - j - 1];
					vectorPath[vectorPath.Count - j - 1] = value2;
				}
			}
		}

		protected override string DebugString(PathLog logMode)
		{
			if (logMode == PathLog.None || (!base.error && logMode == PathLog.OnlyErrors))
			{
				return "";
			}
			StringBuilder debugStringBuilder = pathHandler.DebugStringBuilder;
			debugStringBuilder.Length = 0;
			DebugStringPrefix(logMode, debugStringBuilder);
			if (!base.error)
			{
				debugStringBuilder.Append("\nShortest path was ");
				debugStringBuilder.Append((chosenTarget == -1) ? "undefined" : nodePaths[chosenTarget].Count.ToString());
				debugStringBuilder.Append(" nodes long");
				if (logMode == PathLog.Heavy)
				{
					debugStringBuilder.Append("\nPaths (").Append(targetsFound.Length).Append("):");
					for (int i = 0; i < targetsFound.Length; i++)
					{
						debugStringBuilder.Append("\n\n\tPath ").Append(i).Append(" Found: ")
							.Append(targetsFound[i]);
						if (nodePaths[i] != null)
						{
							debugStringBuilder.Append("\n\t\tLength: ");
							debugStringBuilder.Append(nodePaths[i].Count);
						}
					}
					debugStringBuilder.Append("\nStart Node");
					debugStringBuilder.Append("\n\tPoint: ");
					Vector3 vector = endPoint;
					debugStringBuilder.Append(vector.ToString());
					debugStringBuilder.Append("\n\tGraph: ");
					debugStringBuilder.Append(base.startNode.GraphIndex);
					debugStringBuilder.Append("\nBinary Heap size at completion: ");
					debugStringBuilder.AppendLine((pathHandler.heap.numberOfItems - 2).ToString());
				}
			}
			DebugStringSuffix(logMode, debugStringBuilder);
			return debugStringBuilder.ToString();
		}
	}
}
