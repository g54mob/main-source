using System;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[Preserve]
	public class LayerGridGraph : GridGraph, IUpdatableGraph
	{
		[JsonMember]
		internal int layerCount;

		[JsonMember]
		public float characterHeight;

		internal int lastScannedWidth;

		internal int lastScannedDepth;

		public override int LayerCount
		{
			get
			{
				return 0;
			}
			protected set
			{
			}
		}

		public override int MaxLayers => 0;

		protected override void DisposeUnmanagedData()
		{
		}

		protected override GridNodeBase[] AllocateNodesJob(int size, out JobHandle dependency)
		{
			dependency = default(JobHandle);
			return null;
		}

		public override int CountNodes()
		{
			return 0;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
		}

		public override int GetNodesInRegion(IntRect rect, GridNodeBase[] buffer)
		{
			return 0;
		}

		public GridNodeBase GetNode(int x, int z, int layer)
		{
			return null;
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			return null;
		}

		protected override GridNodeBase GetNearestFromGraphSpace(Vector3 positionGraphSpace)
		{
			return null;
		}

		private GridNodeBase GetNearestNode(Vector3 position, int x, int z, NNConstraint constraint)
		{
			return null;
		}

		protected override void SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}
	}
}
