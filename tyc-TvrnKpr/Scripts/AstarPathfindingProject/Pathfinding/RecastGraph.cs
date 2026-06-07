using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Graphs.Navmesh.Jobs;
using Pathfinding.Jobs;
using Pathfinding.Serialization;
using Pathfinding.Sync;
using Pathfinding.Util;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding
{
	[JsonOptIn]
	[Preserve]
	public class RecastGraph : NavmeshBase, IUpdatableGraph
	{
		public enum RelevantGraphSurfaceMode
		{
			DoNotRequire = 0,
			OnlyForCompletelyInsideTile = 1,
			RequireForAll = 2
		}

		public enum DimensionMode
		{
			Dimension2D = 0,
			Dimension3D = 1
		}

		public enum BackgroundTraversability
		{
			Walkable = 0,
			Unwalkable = 1
		}

		[Serializable]
		public struct PerLayerModification
		{
			public int layer;

			public RecastNavmeshModifier.Mode mode;

			public int surfaceID;

			public static PerLayerModification Default => default(PerLayerModification);

			public static PerLayerModification[] ToLayerLookup(List<PerLayerModification> perLayerModifications, PerLayerModification defaultValue)
			{
				return null;
			}
		}

		[Serializable]
		public struct PerTerrainLayerModification
		{
			public int layer;

			public RecastNavmeshModifier.Mode mode;

			public int surfaceID;

			public float threshold;

			public static PerTerrainLayerModification Default => default(PerTerrainLayerModification);
		}

		[Serializable]
		public class CollectionSettings
		{
			public enum FilterMode
			{
				Layers = 0,
				Tags = 1
			}

			public FilterMode collectionMode;

			[NonSerialized]
			public PhysicsScene? physicsScene;

			[NonSerialized]
			public PhysicsScene2D? physicsScene2D;

			public LayerMask layerMask;

			public List<string> tagMask;

			public bool rasterizeColliders;

			public bool rasterizeMeshes;

			public bool rasterizeTerrain;

			public bool rasterizeTrees;

			public int terrainHeightmapDownsamplingFactor;

			public float colliderRasterizeDetail;

			public Action<RecastMeshGatherer> onCollectMeshes;
		}

		private class RecastGraphUpdatePromise : IGraphUpdatePromise
		{
			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__5 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public RecastGraphUpdatePromise _003C_003E4__this;

				private int _003Ci_003E5__2;

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
				public _003CPrepare_003Ed__5(int _003C_003E1__state)
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

			public List<(Promise<TileBuilder.TileBuilderOutput>, Promise<TileCutter.TileCutterOutput>, Promise<JobBuildNodes.BuildNodeTilesOutput>)> promises;

			public List<GraphUpdateObject> graphUpdates;

			public RecastGraph graph;

			private int graphHash;

			public RecastGraphUpdatePromise(RecastGraph graph, List<GraphUpdateObject> graphUpdates)
			{
			}

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__5))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			private static int HashSettings(RecastGraph graph)
			{
				return 0;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		private class RecastGraphScanPromise : IGraphUpdatePromise
		{
			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__8 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public RecastGraphScanPromise _003C_003E4__this;

				private DisposeArena _003Carena_003E5__2;

				private Promise<TileBuilder.TileBuilderOutput> _003CtileMeshesPromise_003E5__3;

				private Promise<TileCutter.TileCutterOutput> _003CcutPromise_003E5__4;

				private Promise<JobBuildNodes.BuildNodeTilesOutput> _003CtilesPromise_003E5__5;

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
				public _003CPrepare_003Ed__8(int _003C_003E1__state)
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

			public RecastGraph graph;

			private TileLayout tileLayout;

			private bool emptyGraph;

			private NavmeshTile[] tiles;

			private IProgress progressSource;

			private NavmeshUpdates.NavmeshUpdateSettings cutSettings;

			public float Progress => 0f;

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__8))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
			}
		}

		private class RecastMovePromise : IGraphUpdatePromise
		{
			[CompilerGenerated]
			private sealed class _003CPrepare_003Ed__5 : IEnumerator<JobHandle>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private JobHandle _003C_003E2__current;

				public RecastMovePromise _003C_003E4__this;

				private IntRect _003CcreatedTiles_003E5__2;

				private DisposeArena _003CdisposeArena_003E5__3;

				private Promise<TileBuilder.TileBuilderOutput> _003CpendingPromise_003E5__4;

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
				public _003CPrepare_003Ed__5(int _003C_003E1__state)
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

			private RecastGraph graph;

			private TileMeshes tileMeshes;

			private Vector2Int delta;

			private IntRect newTileRect;

			public RecastMovePromise(RecastGraph graph, Vector2Int delta)
			{
			}

			[IteratorStateMachine(typeof(_003CPrepare_003Ed__5))]
			public IEnumerator<JobHandle> Prepare()
			{
				return null;
			}

			public void Apply(IGraphUpdateContext ctx)
			{
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
		public List<PerLayerModification> perLayerModifications;

		[JsonMember]
		public List<PerTerrainLayerModification> perTerrainLayerModifications;

		[JsonMember]
		public DimensionMode dimensionMode;

		[JsonMember]
		public BackgroundTraversability backgroundTraversability;

		[JsonMember]
		public RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		[JsonMember]
		public CollectionSettings collectionSettings;

		[JsonMember]
		public Vector3 rotation;

		[JsonMember]
		public Vector3 forcedBoundsCenter;

		private DisposeArena pendingGraphUpdateArena;

		private bool hasExtendedInX;

		private bool hasExtendedInZ;

		[Obsolete("Use collectionSettings.rasterizeColliders instead")]
		public bool rasterizeColliders
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use collectionSettings.rasterizeMeshes instead")]
		public bool rasterizeMeshes
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use collectionSettings.rasterizeTerrain instead")]
		public bool rasterizeTerrain
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use collectionSettings.rasterizeTrees instead")]
		public bool rasterizeTrees
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use collectionSettings.colliderRasterizeDetail instead")]
		public float colliderRasterizeDetail
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Obsolete("Use collectionSettings.layerMask instead")]
		public LayerMask mask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		[Obsolete("Use collectionSettings.tagMask instead")]
		public List<string> tagMask
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete("Use collectionSettings.terrainHeightmapDownsamplingFactor instead")]
		public int terrainSampleSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override float NavmeshCuttingCharacterRadius => 0f;

		public override bool RecalculateNormals => false;

		public override float TileWorldSizeX => 0f;

		public override float TileWorldSizeZ => 0f;

		public override float MaxTileConnectionEdgeDistance => 0f;

		public override Bounds bounds => default(Bounds);

		internal int CharacterRadiusInVoxels => 0;

		internal int TileBorderSizeInVoxels => 0;

		internal float TileBorderSizeInWorldUnits => 0f;

		public override bool IsInsideBounds(Vector3 point)
		{
			return false;
		}

		[Obsolete("Use SnapBoundsToScene instead")]
		public void SnapForceBoundsToScene()
		{
		}

		public void SnapBoundsToScene()
		{
		}

		IGraphUpdatePromise IUpdatableGraph.ScheduleGraphUpdates(List<GraphUpdateObject> graphUpdates)
		{
			return null;
		}

		public IGraphUpdatePromise TranslateInDirection(int dx, int dz)
		{
			return null;
		}

		protected override IGraphUpdatePromise ScanInternal(bool async)
		{
			return null;
		}

		public override GraphTransform CalculateTransform()
		{
			return null;
		}

		public static GraphTransform CalculateTransform(Bounds bounds, Quaternion rotation)
		{
			return null;
		}

		protected void SetLayout(TileLayout info)
		{
		}

		public virtual void Resize(IntRect newTileBounds)
		{
		}

		public void EnsureInitialized()
		{
		}

		public void ReplaceTiles(TileMeshes tileMeshes, float yOffset = 0f)
		{
		}

		protected override void PostDeserialization(GraphSerializationContext ctx)
		{
		}
	}
}
