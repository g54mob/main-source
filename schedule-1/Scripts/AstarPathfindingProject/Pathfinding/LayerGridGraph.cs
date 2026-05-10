using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding
{
	[Preserve]
	public class LayerGridGraph : GridGraph, IUpdatableGraph
	{
		protected struct HeightSample
		{
			public Vector3 position;

			public RaycastHit hit;

			public float height;

			public bool walkable;
		}

		private class HitComparer : IComparer<RaycastHit>
		{
			public int Compare(RaycastHit a, RaycastHit b)
			{
				return 0;
			}
		}

		[CompilerGenerated]
		private sealed class _003CScanInternal_003Ed__19 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Progress _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public LayerGridGraph _003C_003E4__this;

			private int _003CprogressCounter_003E5__2;

			private int _003Cz_003E5__3;

			Progress IEnumerator<Progress>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(Progress);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CScanInternal_003Ed__19(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Progress> IEnumerable<Progress>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[JsonMember]
		internal int layerCount;

		[JsonMember]
		public float mergeSpanRange;

		[JsonMember]
		public float characterHeight;

		internal int lastScannedWidth;

		internal int lastScannedDepth;

		private static readonly HitComparer comparer;

		private static HeightSample[] heightSampleBuffer;

		public override bool uniformWidthDepthGrid => false;

		public override int LayerCount => 0;

		protected override void OnDestroy()
		{
		}

		private void RemoveGridGraphFromStatic()
		{
		}

		public override int CountNodes()
		{
			return 0;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
		}

		protected override List<GraphNode> GetNodesInRegion(Bounds b, GraphUpdateShape shape)
		{
			return null;
		}

		public override List<GraphNode> GetNodesInRegion(IntRect rect)
		{
			return null;
		}

		public override int GetNodesInRegion(IntRect rect, GridNodeBase[] buffer)
		{
			return 0;
		}

		public override GridNodeBase GetNode(int x, int z)
		{
			return null;
		}

		public GridNodeBase GetNode(int x, int z, int layer)
		{
			return null;
		}

		void IUpdatableGraph.UpdateArea(GraphUpdateObject o)
		{
		}

		[IteratorStateMachine(typeof(_003CScanInternal_003Ed__19))]
		protected override IEnumerable<Progress> ScanInternal()
		{
			return null;
		}

		protected static HeightSample[] SampleHeights(GraphCollision collision, float mergeSpanRange, Vector3 position, out int numHits)
		{
			numHits = default(int);
			return null;
		}

		public override void RecalculateCell(int x, int z, bool resetPenalties = true, bool resetTags = true)
		{
		}

		private void AddLayers(int count)
		{
		}

		protected override bool ErosionAnyFalseConnections(GraphNode baseNode)
		{
			return false;
		}

		public override void CalculateConnections(GridNodeBase baseNode)
		{
		}

		[Obsolete("Use CalculateConnections(x,z,layerIndex) or CalculateConnections(node) instead")]
		public void CalculateConnections(int x, int z, int layerIndex, LevelGridNode node)
		{
		}

		public override void CalculateConnections(int x, int z)
		{
		}

		public void CalculateConnections(int x, int z, int layerIndex)
		{
		}

		public override NNInfoInternal GetNearest(Vector3 position, NNConstraint constraint, GraphNode hint)
		{
			return default(NNInfoInternal);
		}

		protected override GridNodeBase GetNearestFromGraphSpace(Vector3 positionGraphSpace)
		{
			return null;
		}

		private GridNodeBase GetNearestNode(Vector3 position, int x, int z, NNConstraint constraint)
		{
			return null;
		}

		[Obsolete("Use node.HasConnectionInDirection instead")]
		public static bool CheckConnection(LevelGridNode node, int dir)
		{
			return false;
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
