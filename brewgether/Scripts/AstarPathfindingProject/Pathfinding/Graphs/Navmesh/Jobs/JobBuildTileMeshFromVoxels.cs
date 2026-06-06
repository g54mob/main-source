using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	[BurstCompile(CompileSynchronously = true)]
	public struct JobBuildTileMeshFromVoxels : IJob
	{
		public TileBuilderBurst tileBuilder;

		[ReadOnly]
		public TileBuilder.BucketMapping inputMeshes;

		[ReadOnly]
		public NativeArray<Bounds> tileGraphSpaceBounds;

		public Matrix4x4 voxelToTileSpace;

		public Vector2 graphSpaceLimits;

		[NativeDisableUnsafePtrRestriction]
		public unsafe TileMesh.TileMeshUnsafe* outputMeshes;

		public int maxTiles;

		public int voxelWalkableClimb;

		public uint voxelWalkableHeight;

		public float cellSize;

		public float cellHeight;

		public float maxSlope;

		public RecastGraph.DimensionMode dimensionMode;

		public RecastGraph.BackgroundTraversability backgroundTraversability;

		public Matrix4x4 graphToWorldSpace;

		public int characterRadiusInVoxels;

		public int tileBorderSizeInVoxels;

		public int minRegionSize;

		public float maxEdgeLength;

		public float contourMaxError;

		[ReadOnly]
		public NativeArray<JobBuildRegions.RelevantGraphSurfaceInfo> relevantGraphSurfaces;

		public RecastGraph.RelevantGraphSurfaceMode relevantGraphSurfaceMode;

		[NativeDisableUnsafePtrRestriction]
		public unsafe int* currentTileCounter;

		private static readonly ProfilerMarker MarkerVoxelize;

		private static readonly ProfilerMarker MarkerFilterLedges;

		private static readonly ProfilerMarker MarkerFilterLowHeightSpans;

		private static readonly ProfilerMarker MarkerBuildCompactField;

		private static readonly ProfilerMarker MarkerBuildConnections;

		private static readonly ProfilerMarker MarkerErodeWalkableArea;

		private static readonly ProfilerMarker MarkerBuildDistanceField;

		private static readonly ProfilerMarker MarkerBuildRegions;

		private static readonly ProfilerMarker MarkerBuildContours;

		private static readonly ProfilerMarker MarkerBuildMesh;

		private static readonly ProfilerMarker MarkerConvertAreasToTags;

		private static readonly ProfilerMarker MarkerRemoveDuplicateVertices;

		private static readonly ProfilerMarker MarkerTransformTileCoordinates;

		public void SetOutputMeshes(NativeArray<TileMesh.TileMeshUnsafe> arr)
		{
		}

		public void SetCounter(NativeReference<int> counter)
		{
		}

		public void Execute()
		{
		}
	}
}
