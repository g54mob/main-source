using System;
using System.Collections.Generic;
using Pathfinding.Drawing;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class LinkGraph : NavGraph
	{
		private class LinkGraphUpdatePromise : IGraphUpdatePromise
		{
			public LinkGraph graph;

			public void Apply(IGraphUpdateContext ctx)
			{
				graph.DestroyAllNodes();
			}

			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}
		}

		private LinkNode[] nodes = new LinkNode[0];

		private int nodeCount;

		public override bool isScanned => true;

		public override bool persistent => false;

		public override bool showInInspector => false;

		public override int CountNodes()
		{
			return nodeCount;
		}

		protected override void DestroyAllNodes()
		{
			base.DestroyAllNodes();
			nodes = new LinkNode[0];
			nodeCount = 0;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
			if (nodes != null)
			{
				for (int i = 0; i < nodeCount; i++)
				{
					action(nodes[i]);
				}
			}
		}

		internal LinkNode AddNode()
		{
			AssertSafeToUpdateGraph();
			if (nodeCount >= nodes.Length)
			{
				Memory.Realloc(ref nodes, Mathf.Max(16, nodeCount * 2));
			}
			nodeCount++;
			return nodes[nodeCount - 1] = new LinkNode(active)
			{
				nodeInGraphIndex = nodeCount - 1,
				GraphIndex = graphIndex,
				Walkable = true
			};
		}

		internal void RemoveNode(LinkNode node)
		{
			if (nodes[node.nodeInGraphIndex] != node)
			{
				throw new ArgumentException("Node is not in this graph");
			}
			nodeCount--;
			nodes[node.nodeInGraphIndex] = nodes[nodeCount];
			nodes[node.nodeInGraphIndex].nodeInGraphIndex = node.nodeInGraphIndex;
			nodes[nodeCount] = null;
			node.Destroy();
		}

		public override float NearestNodeDistanceSqrLowerBound(Vector3 position, NNConstraint constraint = null)
		{
			return float.PositiveInfinity;
		}

		public override NNInfo GetNearest(Vector3 position, NNConstraint constraint, float maxDistanceSqr)
		{
			return default(NNInfo);
		}

		public override void OnDrawGizmos(DrawingData gizmos, bool drawNodes, RedrawScope redrawScope)
		{
			base.OnDrawGizmos(gizmos, drawNodes, redrawScope);
		}

		protected override IGraphUpdatePromise ScanInternal()
		{
			return new LinkGraphUpdatePromise
			{
				graph = this
			};
		}
	}
}
