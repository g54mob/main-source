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
	[JsonOptIn]
	[Preserve]
	public class PointGraph : NavGraph
	{
		public enum NodeDistanceMode
		{
			Node = 0,
			Connection = 1
		}

		[CompilerGenerated]
		private sealed class _003CConnectNodesAsync_003Ed__34 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Progress _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PointGraph _003C_003E4__this;

			private List<Connection> _003Cconnections_003E5__2;

			private int _003Ci_003E5__3;

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
			public _003CConnectNodesAsync_003Ed__34(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CScanInternal_003Ed__32 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Progress _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PointGraph _003C_003E4__this;

			private GameObject[] _003Cgos_003E5__2;

			private IEnumerator<Progress> _003C_003E7__wrap2;

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
			public _003CScanInternal_003Ed__32(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
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
		public Transform root;

		[JsonMember]
		public string searchTag;

		[JsonMember]
		public float maxDistance;

		[JsonMember]
		public Vector3 limits;

		[JsonMember]
		public bool raycast;

		[JsonMember]
		public bool use2DPhysics;

		[JsonMember]
		public bool thickRaycast;

		[JsonMember]
		public float thickRaycastRadius;

		[JsonMember]
		public bool recursive;

		[JsonMember]
		public LayerMask mask;

		public PointNode[] nodes;

		[JsonMember]
		public NodeDistanceMode nearestNodeDistanceMode;

		public int nodeCount { get; protected set; }

		public override int CountNodes()
		{
			return 0;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
		}

		public override NNInfoInternal GetNearest(Vector3 position, NNConstraint constraint, GraphNode hint)
		{
			return default(NNInfoInternal);
		}

		public override NNInfoInternal GetNearestForce(Vector3 position, NNConstraint constraint)
		{
			return default(NNInfoInternal);
		}

		private NNInfoInternal GetNearestInternal(Vector3 position, NNConstraint constraint, bool fastCheck)
		{
			return default(NNInfoInternal);
		}

		private NNInfoInternal FindClosestConnectionPoint(PointNode node, Vector3 position)
		{
			return default(NNInfoInternal);
		}

		public PointNode AddNode(Int3 position)
		{
			return null;
		}

		public T AddNode<T>(T node, Int3 position) where T : PointNode
		{
			return null;
		}

		protected static int CountChildren(Transform tr)
		{
			return 0;
		}

		protected void AddChildren(ref int c, Transform tr)
		{
		}

		public void RebuildNodeLookup()
		{
		}

		public void RebuildConnectionDistanceLookup()
		{
		}

		private void AddToLookup(PointNode node)
		{
		}

		public void RegisterConnectionLength(long sqrLength)
		{
		}

		protected virtual PointNode[] CreateNodes(int count)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CScanInternal_003Ed__32))]
		protected override IEnumerable<Progress> ScanInternal()
		{
			return null;
		}

		public void ConnectNodes()
		{
		}

		[IteratorStateMachine(typeof(_003CConnectNodesAsync_003Ed__34))]
		private IEnumerable<Progress> ConnectNodesAsync()
		{
			return null;
		}

		public virtual bool IsValidConnection(GraphNode a, GraphNode b, out float dist)
		{
			dist = default(float);
			return false;
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}

		public override void RelocateNodes(Matrix4x4 deltaMatrix)
		{
		}

		protected override void DeserializeSettingsCompatibility(GraphSerializationContext ctx)
		{
		}

		protected override void SerializeExtraInfo(GraphSerializationContext ctx)
		{
		}

		protected override void DeserializeExtraInfo(GraphSerializationContext ctx)
		{
		}
	}
}
