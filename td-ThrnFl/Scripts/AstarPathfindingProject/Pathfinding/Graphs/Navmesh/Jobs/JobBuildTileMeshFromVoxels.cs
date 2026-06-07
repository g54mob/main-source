using System.Threading;
using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Pathfinding.Util;
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

		private static readonly ProfilerMarker MarkerVoxelize = new ProfilerMarker("Voxelize");

		private static readonly ProfilerMarker MarkerFilterLedges = new ProfilerMarker("FilterLedges");

		private static readonly ProfilerMarker MarkerFilterLowHeightSpans = new ProfilerMarker("FilterLowHeightSpans");

		private static readonly ProfilerMarker MarkerBuildCompactField = new ProfilerMarker("BuildCompactField");

		private static readonly ProfilerMarker MarkerBuildConnections = new ProfilerMarker("BuildConnections");

		private static readonly ProfilerMarker MarkerErodeWalkableArea = new ProfilerMarker("ErodeWalkableArea");

		private static readonly ProfilerMarker MarkerBuildDistanceField = new ProfilerMarker("BuildDistanceField");

		private static readonly ProfilerMarker MarkerBuildRegions = new ProfilerMarker("BuildRegions");

		private static readonly ProfilerMarker MarkerBuildContours = new ProfilerMarker("BuildContours");

		private static readonly ProfilerMarker MarkerBuildMesh = new ProfilerMarker("BuildMesh");

		private static readonly ProfilerMarker MarkerConvertAreasToTags = new ProfilerMarker("ConvertAreasToTags");

		private static readonly ProfilerMarker MarkerRemoveDuplicateVertices = new ProfilerMarker("RemoveDuplicateVertices");

		private static readonly ProfilerMarker MarkerTransformTileCoordinates = new ProfilerMarker("TransformTileCoordinates");

		public unsafe void SetOutputMeshes(NativeArray<TileMesh.TileMeshUnsafe> arr)
		{
			outputMeshes = (TileMesh.TileMeshUnsafe*)arr.GetUnsafeReadOnlyPtr();
		}

		public unsafe void SetCounter(NativeReference<int> counter)
		{
			currentTileCounter = counter.GetUnsafePtr();
		}

		public unsafe void Execute()
		{
			for (int i = 0; i < maxTiles; i++)
			{
				int num = Interlocked.Increment(ref UnsafeUtility.AsRef<int>(currentTileCounter)) - 1;
				if (num >= tileGraphSpaceBounds.Length)
				{
					break;
				}
				tileBuilder.linkedVoxelField.ResetLinkedVoxelSpans();
				if (dimensionMode == RecastGraph.DimensionMode.Dimension2D && backgroundTraversability == RecastGraph.BackgroundTraversability.Walkable)
				{
					tileBuilder.linkedVoxelField.SetWalkableBackground();
				}
				int num2 = ((num > 0) ? inputMeshes.bucketRanges[num - 1] : 0);
				int num3 = inputMeshes.bucketRanges[num];
				JobVoxelize jobVoxelize = default(JobVoxelize);
				jobVoxelize.inputMeshes = inputMeshes.meshes;
				jobVoxelize.bucket = inputMeshes.pointers.GetSubArray(num2, num3 - num2);
				jobVoxelize.voxelWalkableClimb = voxelWalkableClimb;
				jobVoxelize.voxelWalkableHeight = voxelWalkableHeight;
				jobVoxelize.cellSize = cellSize;
				jobVoxelize.cellHeight = cellHeight;
				jobVoxelize.maxSlope = maxSlope;
				jobVoxelize.graphTransform = graphToWorldSpace;
				jobVoxelize.graphSpaceBounds = tileGraphSpaceBounds[num];
				jobVoxelize.graphSpaceLimits = graphSpaceLimits;
				jobVoxelize.voxelArea = tileBuilder.linkedVoxelField;
				jobVoxelize.Execute();
				JobFilterLedges jobFilterLedges = default(JobFilterLedges);
				jobFilterLedges.field = tileBuilder.linkedVoxelField;
				jobFilterLedges.voxelWalkableClimb = voxelWalkableClimb;
				jobFilterLedges.voxelWalkableHeight = voxelWalkableHeight;
				jobFilterLedges.cellSize = cellSize;
				jobFilterLedges.cellHeight = cellHeight;
				jobFilterLedges.Execute();
				JobFilterLowHeightSpans jobFilterLowHeightSpans = default(JobFilterLowHeightSpans);
				jobFilterLowHeightSpans.field = tileBuilder.linkedVoxelField;
				jobFilterLowHeightSpans.voxelWalkableHeight = voxelWalkableHeight;
				jobFilterLowHeightSpans.Execute();
				JobBuildCompactField jobBuildCompactField = default(JobBuildCompactField);
				jobBuildCompactField.input = tileBuilder.linkedVoxelField;
				jobBuildCompactField.output = tileBuilder.compactVoxelField;
				jobBuildCompactField.Execute();
				JobBuildConnections jobBuildConnections = default(JobBuildConnections);
				jobBuildConnections.field = tileBuilder.compactVoxelField;
				jobBuildConnections.voxelWalkableHeight = (int)voxelWalkableHeight;
				jobBuildConnections.voxelWalkableClimb = voxelWalkableClimb;
				jobBuildConnections.Execute();
				JobErodeWalkableArea jobErodeWalkableArea = default(JobErodeWalkableArea);
				jobErodeWalkableArea.field = tileBuilder.compactVoxelField;
				jobErodeWalkableArea.radius = characterRadiusInVoxels;
				jobErodeWalkableArea.Execute();
				JobBuildDistanceField jobBuildDistanceField = default(JobBuildDistanceField);
				jobBuildDistanceField.field = tileBuilder.compactVoxelField;
				jobBuildDistanceField.output = tileBuilder.distanceField;
				jobBuildDistanceField.Execute();
				JobBuildRegions jobBuildRegions = default(JobBuildRegions);
				jobBuildRegions.field = tileBuilder.compactVoxelField;
				jobBuildRegions.distanceField = tileBuilder.distanceField;
				jobBuildRegions.borderSize = tileBorderSizeInVoxels;
				jobBuildRegions.minRegionSize = Mathf.RoundToInt(minRegionSize);
				jobBuildRegions.srcQue = tileBuilder.tmpQueue1;
				jobBuildRegions.dstQue = tileBuilder.tmpQueue2;
				jobBuildRegions.relevantGraphSurfaces = relevantGraphSurfaces;
				jobBuildRegions.relevantGraphSurfaceMode = relevantGraphSurfaceMode;
				jobBuildRegions.cellSize = cellSize;
				jobBuildRegions.cellHeight = cellHeight;
				jobBuildRegions.graphTransform = graphToWorldSpace;
				jobBuildRegions.graphSpaceBounds = tileGraphSpaceBounds[num];
				jobBuildRegions.Execute();
				JobBuildContours jobBuildContours = default(JobBuildContours);
				jobBuildContours.field = tileBuilder.compactVoxelField;
				jobBuildContours.maxError = contourMaxError;
				jobBuildContours.maxEdgeLength = maxEdgeLength;
				jobBuildContours.buildFlags = 5;
				jobBuildContours.cellSize = cellSize;
				jobBuildContours.outputContours = tileBuilder.contours;
				jobBuildContours.outputVerts = tileBuilder.contourVertices;
				jobBuildContours.Execute();
				JobBuildMesh jobBuildMesh = default(JobBuildMesh);
				jobBuildMesh.contours = tileBuilder.contours;
				jobBuildMesh.contourVertices = tileBuilder.contourVertices;
				jobBuildMesh.mesh = tileBuilder.voxelMesh;
				jobBuildMesh.field = tileBuilder.compactVoxelField;
				jobBuildMesh.Execute();
				TileMesh.TileMeshUnsafe* ptr = outputMeshes + num;
				*ptr = new TileMesh.TileMeshUnsafe
				{
					verticesInTileSpace = new UnsafeAppendBuffer(0, 4, Allocator.Persistent),
					triangles = new UnsafeAppendBuffer(0, 4, Allocator.Persistent),
					tags = new UnsafeAppendBuffer(0, 4, Allocator.Persistent)
				};
				JobConvertAreasToTags jobConvertAreasToTags = default(JobConvertAreasToTags);
				jobConvertAreasToTags.areas = tileBuilder.voxelMesh.areas;
				jobConvertAreasToTags.Execute();
				MeshUtility.JobRemoveDuplicateVertices jobRemoveDuplicateVertices = default(MeshUtility.JobRemoveDuplicateVertices);
				jobRemoveDuplicateVertices.vertices = tileBuilder.voxelMesh.verts.AsArray();
				jobRemoveDuplicateVertices.triangles = tileBuilder.voxelMesh.tris.AsArray();
				jobRemoveDuplicateVertices.tags = tileBuilder.voxelMesh.areas.AsArray();
				jobRemoveDuplicateVertices.outputTags = &ptr->tags;
				jobRemoveDuplicateVertices.outputVertices = &ptr->verticesInTileSpace;
				jobRemoveDuplicateVertices.outputTriangles = &ptr->triangles;
				jobRemoveDuplicateVertices.Execute();
				JobTransformTileCoordinates jobTransformTileCoordinates = default(JobTransformTileCoordinates);
				jobTransformTileCoordinates.vertices = &ptr->verticesInTileSpace;
				jobTransformTileCoordinates.matrix = voxelToTileSpace;
				jobTransformTileCoordinates.Execute();
			}
		}
	}
}
