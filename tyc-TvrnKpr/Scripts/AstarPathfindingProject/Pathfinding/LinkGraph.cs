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
			}

			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}
		}

		private LinkNode[] nodes;

		private int nodeCount;

		public override bool isScanned => false;

		public override bool persistent => false;

		public override bool showInInspector => false;

		public override int CountNodes()
		{
			return 0;
		}

		protected override void DestroyAllNodes()
		{
		}

		public override void GetNodes<T>(GraphNode.NodeActionWithData<T> action, ref T data)
		{
		}

		internal LinkNode AddNode()
		{
			return null;
		}

		internal void RemoveNode(LinkNode node)
		{
		}

		public override float NearestNodeDistanceSqrLowerBound(Vector3 position, ref NearestNodeConstraint constraint)
		{
			return 0f;
		}

		public override NNInfo GetNearest(Vector3 position, ref NearestNodeConstraint constraint)
		{
			return default(NNInfo);
		}

		public override void OnDrawGizmos(DrawingData gizmos, bool drawNodes, RedrawScope redrawScope, bool renderInGame)
		{
		}

		protected override IGraphUpdatePromise ScanInternal()
		{
			return null;
		}
	}
}
