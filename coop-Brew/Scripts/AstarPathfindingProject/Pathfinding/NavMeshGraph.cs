using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Graphs.Navmesh.Jobs;
using Pathfinding.Serialization;
using Pathfinding.Sync;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class NavMeshGraph : NavmeshBase, IUpdatableGraph
	{
		private class NavMeshGraphUpdatePromise : IGraphUpdatePromise
		{
			public NavMeshGraph graph;

			public List<GraphUpdateObject> graphUpdates;

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		private class NavMeshGraphScanPromise : IGraphUpdatePromise
		{
			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__7 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public NavMeshGraphScanPromise _003C_003E4__this;

				private NativeArray<Vector3> _003Cvertices_003E5__2;

				private NativeArray<int> _003Cindices_003E5__3;

				private Promise<TileBuilder.TileBuilderOutput> _003Cpromise_003E5__4;

				private GCHandle _003CtilesGCHandle_003E5__5;

				private Promise<TileCutter.TileCutterOutput> _003CcutPromise_003E5__6;

				private NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe> _003CtileNodeConnections_003E5__7;

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
				public _003CPrepare_003Ed__7(int _003C_003E1__state)
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
			}

			public NavMeshGraph graph;

			private bool emptyGraph;

			private GraphTransform transform;

			private NavmeshTile[] tiles;

			private Vector3 forcedBoundsSize;

			private IntRect tileRect;

			private NavmeshUpdates.NavmeshUpdateSettings cutSettings;

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__7))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		[JsonMember]
		public Mesh sourceMesh;

		[JsonMember]
		public Vector3 offset;

		[JsonMember]
		public Vector3 rotation;

		[JsonMember]
		public float scale;

		[JsonMember]
		public bool recalculateNormals;

		[JsonMember]
		private Vector3 cachedSourceMeshBoundsMin;

		[JsonMember]
		public float navmeshCuttingCharacterRadius;

		public override float NavmeshCuttingCharacterRadius => 0f;

		public override bool RecalculateNormals => false;

		public override float TileWorldSizeX => 0f;

		public override float TileWorldSizeZ => 0f;

		public override float MaxTileConnectionEdgeDistance => 0f;

		public override Bounds bounds => default(Bounds);

		public override bool IsInsideBounds(Vector3 point)
		{
			return false;
		}

		public override GraphTransform CalculateTransform()
		{
			return null;
		}

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			return null;
		}

		public static void UpdateArea(GraphUpdateObject o, INavmeshHolder graph)
		{
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			return null;
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}
	}
}
