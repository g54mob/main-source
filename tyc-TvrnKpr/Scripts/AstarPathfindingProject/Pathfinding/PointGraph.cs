using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class PointGraph : NavGraph, IUpdatableGraph
	{
		public enum NodeDistanceMode
		{
			Node = 0,
			Connection = 1
		}

		private class PointGraphScanPromise : IGraphUpdatePromise
		{
			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__3 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public PointGraphScanPromise _003C_003E4__this;

				private IEnumerator<float> _003C_003E7__wrap1;

				JobHandle IEnumerator<JobHandle>.Current
				{
					[DebuggerHidden]
					get
					{
						return default(JobHandle);
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
				public _003CPrepare_003Ed__3(int _003C_003E1__state)
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
			}

			public PointGraph graph;

			private PointKDTree lookupTree;

			private PointNode[] nodes;

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__3))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		private class PointGraphUpdatePromise : IGraphUpdatePromise
		{
			public PointGraph graph;

			public List<GraphUpdateObject> graphUpdates;

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CConnectNodesAsync_003Ed__44 : IEnumerable<float>, IEnumerable, IEnumerator<float>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private float _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private float maxDistance;

			public float _003C_003E3__maxDistance;

			private Vector3 limits;

			public Vector3 _003C_003E3__limits;

			private int nodeCount;

			public int _003C_003E3__nodeCount;

			private PointNode[] nodes;

			public PointNode[] _003C_003E3__nodes;

			private PointKDTree lookupTree;

			public PointKDTree _003C_003E3__lookupTree;

			private PointGraph graph;

			public PointGraph _003C_003E3__graph;

			private List<Connection> _003Cconnections_003E5__2;

			private List<GraphNode> _003CcandidateConnections_003E5__3;

			private long _003CmaxSquaredRange_003E5__4;

			private int _003Ci_003E5__5;

			float IEnumerator<float>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0f;
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
			public _003CConnectNodesAsync_003Ed__44(int _003C_003E1__state)
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
			IEnumerator<float> IEnumerable<float>.GetEnumerator()
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

		[JsonMember]
		public bool optimizeForSparseGraph;

		private PointKDTree lookupTree;

		private long maximumConnectionLength;

		public PointNode[] nodes;

		[JsonMember]
		public NodeDistanceMode nearestNodeDistanceMode;

		public int nodeCount { get; protected set; }

		public override bool isScanned => false;

		public override int CountNodes()
		{
			return 0;
		}

		public override void GetNodes(Action<GraphNode> action)
		{
		}

		public override void GetNodes<T>(GraphNode.NodeActionWithData<T> action, ref T data)
		{
		}

		public override NNInfo GetNearest(Vector3 position, ref NearestNodeConstraint constraint)
		{
			return default(NNInfo);
		}

		private NNInfo FindClosestConnectionPoint(PointNode node, Vector3 position, float maxDistanceSqr)
		{
			return default(NNInfo);
		}

		public override NNInfo RandomPointOnSurface(NearestNodeConstraint constraint, bool highQuality = true)
		{
			return default(NNInfo);
		}

		public PointNode AddNode(Int3 position)
		{
			return null;
		}

		public T AddNode<T>(T node, Int3 position) where T : PointNode
		{
			return null;
		}

		public void RemoveNode(PointNode node)
		{
		}

		public void Clear()
		{
		}

		protected static int CountChildren(Transform tr)
		{
			return 0;
		}

		protected static void AddChildren(PointNode[] nodes, ref int c, Transform tr)
		{
		}

		public void RebuildNodeLookup()
		{
		}

		private static PointKDTree BuildNodeLookup(PointNode[] nodes, int nodeCount, bool optimizeForSparseGraph)
		{
			return null;
		}

		public void RebuildConnectionDistanceLookup()
		{
		}

		private static long LongestConnectionLength(PointNode[] nodes, int nodeCount)
		{
			return 0L;
		}

		public void RegisterConnectionLength(long sqrLength)
		{
		}

		protected virtual PointNode[] CreateNodes(int count)
		{
			return null;
		}

		protected override void DestroyAllNodes()
		{
		}

		protected override IGraphUpdatePromise ScanInternal()
		{
			return null;
		}

		public void ConnectNodes()
		{
		}

		[IteratorStateMachine(typeof(_003CConnectNodesAsync_003Ed__44))]
		private static IEnumerable<float> ConnectNodesAsync(PointNode[] nodes, int nodeCount, PointKDTree lookupTree, float maxDistance, Vector3 limits, PointGraph graph)
		{
			return null;
		}

		public virtual bool IsValidConnection(GraphNode a, GraphNode b, out float dist)
		{
			dist = default(float);
			return false;
		}

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			return null;
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}

		public override void RelocateNodes(Matrix4x4 deltaMatrix)
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
