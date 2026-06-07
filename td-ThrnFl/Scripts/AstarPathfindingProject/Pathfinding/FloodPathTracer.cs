using System;
using UnityEngine;

namespace Pathfinding
{
	public class FloodPathTracer : ABPath
	{
		protected FloodPath flood;

		protected override bool hasEndPoint => false;

		public static FloodPathTracer Construct(Vector3 start, FloodPath flood, OnPathDelegate callback = null)
		{
			FloodPathTracer floodPathTracer = PathPool.GetPath<FloodPathTracer>();
			floodPathTracer.Setup(start, flood, callback);
			return floodPathTracer;
		}

		protected void Setup(Vector3 start, FloodPath flood, OnPathDelegate callback)
		{
			this.flood = flood;
			if (flood == null || flood.PipelineState < PathState.Returning)
			{
				throw new ArgumentException("You must supply a calculated FloodPath to the 'flood' argument");
			}
			Setup(start, flood.originalStartPoint, callback);
			nnConstraint = new FloodPathConstraint(flood);
		}

		protected override void Reset()
		{
			base.Reset();
			flood = null;
		}

		protected override void Prepare()
		{
			if (!flood.IsValid(pathHandler.nodeStorage))
			{
				FailWithError("The flood path is invalid because nodes have been destroyed since it was calculated. Please recalculate the flood path.");
				return;
			}
			base.Prepare();
			if (base.CompleteState != PathCompleteState.NotCalculated)
			{
				return;
			}
			for (uint num = 0u; num < pathHandler.numTemporaryNodes; num++)
			{
				uint nodeIndex = pathHandler.temporaryNodeStartIndex + num;
				ref TemporaryNode temporaryNode = ref pathHandler.GetTemporaryNode(nodeIndex);
				if (temporaryNode.type != TemporaryNodeType.Start)
				{
					continue;
				}
				GraphNode node = pathHandler.GetNode(temporaryNode.associatedNode);
				bool flag = false;
				for (uint num2 = 0u; num2 < node.PathNodeVariants; num2++)
				{
					if (flood.GetParent(node.NodeIndex + num2) != 0)
					{
						flag = true;
						base.CompleteState = PathCompleteState.Complete;
						Trace(node.NodeIndex + num2);
						break;
					}
				}
				if (!flag)
				{
					FailWithError("The flood path did not contain any information about the end node. Have you modified the path's nnConstraint to an instance which does not subclass FloodPathConstraint?");
				}
				return;
			}
			FailWithError("Could not find a valid start node");
		}

		protected override void CalculateStep(long targetTick)
		{
			if (base.CompleteState != PathCompleteState.Complete)
			{
				throw new Exception("Something went wrong. At this point the path should be completed");
			}
		}

		protected override void Trace(uint fromPathNodeIndex)
		{
			uint num = fromPathNodeIndex;
			int num2 = 0;
			GraphNode graphNode = null;
			while (num != 0)
			{
				if ((num & 0x80000000u) != 0)
				{
					num = flood.GetParent(num & 0x7FFFFFFF);
				}
				else
				{
					GraphNode node = pathHandler.GetNode(num);
					if (node == null)
					{
						FailWithError("A node in the path has been destroyed. The FloodPath needs to be recalculated before you can use a FloodPathTracer.");
						break;
					}
					if (node != graphNode)
					{
						if (!CanTraverse(node))
						{
							FailWithError("A node in the path is no longer walkable. The FloodPath needs to be recalculated before you can use a FloodPathTracer.");
							break;
						}
						path.Add(node);
						graphNode = node;
						vectorPath.Add((Vector3)node.position);
					}
					uint parent = flood.GetParent(num);
					if (parent == num)
					{
						break;
					}
					num = parent;
				}
				num2++;
				if (num2 > 10000)
				{
					Debug.LogWarning("Infinite loop? >10000 node path. Remove this message if you really have that long paths");
					break;
				}
			}
		}
	}
}
