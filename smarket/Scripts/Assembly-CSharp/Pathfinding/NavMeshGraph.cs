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
	public class NavMeshGraph : NavmeshBase, IUpdatableGraph
	{
		[CompilerGenerated]
		private sealed class _003CScanInternal_003Ed__21 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Progress _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public NavMeshGraph _003C_003E4__this;

			private List<Int3> _003CintVertices_003E5__2;

			private Int3[] _003CcompressedVertices_003E5__3;

			private int[] _003CcompressedTriangles_003E5__4;

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
			public _003CScanInternal_003Ed__21(int _003C_003E1__state)
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

		protected override bool RecalculateNormals => false;

		public override float TileWorldSizeX => 0f;

		public override float TileWorldSizeZ => 0f;

		protected override float MaxTileConnectionEdgeDistance => 0f;

		public override GraphTransform CalculateTransform()
		{
			return null;
		}

		GraphUpdateThreading IUpdatableGraph.CanUpdateAsync(GraphUpdateObject o)
		{
			return default(GraphUpdateThreading);
		}

		void IUpdatableGraph.UpdateAreaInit(GraphUpdateObject o)
		{
		}

		void IUpdatableGraph.UpdateAreaPost(GraphUpdateObject o)
		{
		}

		void IUpdatableGraph.UpdateArea(GraphUpdateObject o)
		{
		}

		public static void UpdateArea(GraphUpdateObject o, INavmeshHolder graph)
		{
		}

		[Obsolete("Set the mesh to ObjImporter.ImportFile(...) and scan the graph the normal way instead")]
		public void ScanInternal(string objMeshPath)
		{
		}

		[IteratorStateMachine(typeof(_003CScanInternal_003Ed__21))]
		protected override IEnumerable<Progress> ScanInternal()
		{
			return null;
		}

		protected override void DeserializeSettingsCompatibility(GraphSerializationContext ctx)
		{
		}
	}
}
