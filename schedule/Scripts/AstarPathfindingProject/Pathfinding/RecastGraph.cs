using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Serialization;
using Pathfinding.Util;
using Pathfinding.Voxels;
using UnityEngine;

namespace Pathfinding
{
	[Preserve]
	[JsonOptIn]
	public class RecastGraph : NavmeshBase, IUpdatableGraph
	{
		public enum RelevantGraphSurfaceMode
		{
			DoNotRequire = 0,
			OnlyForCompletelyInsideTile = 1,
			RequireForAll = 2
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass50_0
		{
			public Voxelize[] voxelizers;

			public List<RasterizationMesh>[] buckets;

			public RecastGraph _003C_003E4__this;

			public uint graphIndex;

			internal void _003CScanAllTiles_003Eb__0(Int2 tile, int threadIndex)
			{
			}

			internal void _003CScanAllTiles_003Eb__1(GraphNode node)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass50_1
		{
			public int direction;

			public _003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals1;

			internal void _003CScanAllTiles_003Eb__2(Int2 tile, int threadIndex)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CScanAllTiles_003Ed__50 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Progress _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public RecastGraph _003C_003E4__this;

			private _003C_003Ec__DisplayClass50_0 _003C_003E8__1;

			private _003C_003Ec__DisplayClass50_1 _003C_003E8__2;

			private List<RasterizationMesh> _003Cmeshes_003E5__2;

			private Queue<Int2> _003CtileQueue_003E5__3;

			private int _003CtimeoutMillis_003E5__4;

			private IEnumerator<int> _003C_003E7__wrap4;

			private int _003CcoordinateSum_003E5__6;

			private int _003CnumTilesInQueue_003E5__7;

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
			public _003CScanAllTiles_003Ed__50(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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

		[CompilerGenerated]
		private sealed class _003CScanInternal_003Ed__46 : IEnumerable<Progress>, IEnumerable, IEnumerator<Progress>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Progress _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public RecastGraph _003C_003E4__this;

			private IEnumerator<Progress> _003C_003E7__wrap1;

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
			public _003CScanInternal_003Ed__46(int _003C_003E1__state)
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
		public float characterRadius;

		[JsonMember]
		public float contourMaxError;

		[JsonMember]
		public float cellSize;

		[JsonMember]
		public float walkableHeight;

		[JsonMember]
		public float walkableClimb;

		[JsonMember]
		public float maxSlope;

		[JsonMember]
		public float maxEdgeLength;

		[JsonMember]
		public float minRegionSize;

		[JsonMember]
		public int editorTileSize;

		[JsonMember]
		public int tileSizeX;

		[JsonMember]
		public int tileSizeZ;

		[JsonMember]
		public bool useTiles;

		public bool scanEmptyGraph;

		[JsonMember]
		public RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		[JsonMember]
		public bool rasterizeColliders;

		[JsonMember]
		public bool rasterizeMeshes;

		[JsonMember]
		public bool rasterizeTerrain;

		[JsonMember]
		public bool rasterizeTrees;

		[JsonMember]
		public float colliderRasterizeDetail;

		[JsonMember]
		public LayerMask mask;

		[JsonMember]
		public List<string> tagMask;

		[JsonMember]
		public int terrainSampleSize;

		[JsonMember]
		public Vector3 rotation;

		[JsonMember]
		public Vector3 forcedBoundsCenter;

		private Voxelize globalVox;

		public const int BorderVertexMask = 1;

		public const int BorderVertexOffset = 31;

		private List<NavmeshTile> stagingTiles;

		protected override bool RecalculateNormals => false;

		public override float TileWorldSizeX => 0f;

		public override float TileWorldSizeZ => 0f;

		protected override float MaxTileConnectionEdgeDistance => 0f;

		[Obsolete("Obsolete since this is not accurate when the graph is rotated (rotation was not supported when this property was created)")]
		public Bounds forcedBounds => default(Bounds);

		private float CellHeight => 0f;

		private int CharacterRadiusInVoxels => 0;

		private int TileBorderSizeInVoxels => 0;

		private float TileBorderSizeInWorldUnits => 0f;

		[Obsolete("Use node.ClosestPointOnNode instead")]
		public Vector3 ClosestPointOnNode(TriangleMeshNode node, Vector3 pos)
		{
			return default(Vector3);
		}

		[Obsolete("Use node.ContainsPoint instead")]
		public bool ContainsPoint(TriangleMeshNode node, Vector3 pos)
		{
			return false;
		}

		public void SnapForceBoundsToScene()
		{
		}

		GraphUpdateThreading IUpdatableGraph.CanUpdateAsync(GraphUpdateObject o)
		{
			return default(GraphUpdateThreading);
		}

		void IUpdatableGraph.UpdateAreaInit(GraphUpdateObject o)
		{
		}

		void IUpdatableGraph.UpdateArea(GraphUpdateObject guo)
		{
		}

		void IUpdatableGraph.UpdateAreaPost(GraphUpdateObject guo)
		{
		}

		[IteratorStateMachine(typeof(_003CScanInternal_003Ed__46))]
		protected override IEnumerable<Progress> ScanInternal()
		{
			return null;
		}

		public override GraphTransform CalculateTransform()
		{
			return null;
		}

		private void InitializeTileInfo()
		{
		}

		private List<RasterizationMesh>[] PutMeshesIntoTileBuckets(List<RasterizationMesh> meshes)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CScanAllTiles_003Ed__50))]
		protected IEnumerable<Progress> ScanAllTiles()
		{
			return null;
		}

		private List<RasterizationMesh> CollectMeshes(Bounds bounds)
		{
			return null;
		}

		private Bounds CalculateTileBoundsWithBorder(int x, int z)
		{
			return default(Bounds);
		}

		protected NavmeshTile BuildTileMesh(Voxelize vox, int x, int z, int threadIndex = 0)
		{
			return null;
		}

		private NavmeshTile CreateTile(Voxelize vox, VoxelMesh mesh, int x, int z, int threadIndex)
		{
			return null;
		}

		protected override void DeserializeSettingsCompatibility(GraphSerializationContext ctx)
		{
		}
	}
}
