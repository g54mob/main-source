using System;
using System.Collections.Generic;
using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Pathfinding.Jobs;
using Pathfinding.Sync;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileBuilder
	{
		public class TileBuilderOutput : IProgress, IDisposable
		{
			public NativeReference<int> currentTileCounter;

			public TileMeshesUnsafe tileMeshes;

			public float Progress => 0f;

			public void Dispose()
			{
			}
		}

		public struct BucketMapping
		{
			public NativeArray<RasterizationMesh> meshes;

			public NativeArray<int> pointers;

			public NativeArray<int> bucketRanges;
		}

		public float walkableClimb;

		public RecastGraph.CollectionSettings collectionSettings;

		public RecastGraph.RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		public RecastGraph.DimensionMode dimensionMode;

		public RecastGraph.BackgroundTraversability backgroundTraversability;

		public int tileBorderSizeInVoxels;

		public float walkableHeight;

		public float maxSlope;

		public int characterRadiusInVoxels;

		public int minRegionSize;

		public float maxEdgeLength;

		public float contourMaxError;

		public Scene scene;

		public TileLayout tileLayout;

		public IntRect tileRect;

		public List<RecastGraph.PerLayerModification> perLayerModifications;

		private int TileBorderSizeInVoxels => 0;

		private float TileBorderSizeInWorldUnits => 0f;

		public TileBuilder(RecastGraph graph, TileLayout tileLayout, IntRect tileRect)
		{
			walkableClimb = 0f;
			collectionSettings = null;
			relevantGraphSurfaceMode = default(RecastGraph.RelevantGraphSurfaceMode);
			dimensionMode = default(RecastGraph.DimensionMode);
			backgroundTraversability = default(RecastGraph.BackgroundTraversability);
			tileBorderSizeInVoxels = 0;
			walkableHeight = 0f;
			maxSlope = 0f;
			characterRadiusInVoxels = 0;
			minRegionSize = 0;
			maxEdgeLength = 0f;
			contourMaxError = 0f;
			scene = default(Scene);
			this.tileLayout = default(TileLayout);
			this.tileRect = default(IntRect);
			perLayerModifications = null;
		}

		public Bounds GetWorldSpaceBounds(float xzPadding = 0f)
		{
			return default(Bounds);
		}

		public RecastMeshGatherer.MeshCollection CollectMeshes(Bounds bounds)
		{
			return default(RecastMeshGatherer.MeshCollection);
		}

		private BucketMapping PutMeshesIntoTileBuckets(RecastMeshGatherer.MeshCollection meshCollection, IntRect tileBuckets)
		{
			return default(BucketMapping);
		}

		public Promise<TileBuilderOutput> Schedule(DisposeArena arena)
		{
			return default(Promise<TileBuilderOutput>);
		}
	}
}
