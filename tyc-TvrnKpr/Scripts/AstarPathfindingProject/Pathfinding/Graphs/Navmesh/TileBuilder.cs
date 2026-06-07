using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Pathfinding.Jobs;
using Pathfinding.Sync;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void PutMeshesIntoTileBuckets_00000C26_0024PostfixBurstDelegate(ref UnsafeSpan<RasterizationMesh> meshes, ref IntRect tileBuckets, ref float4x4 worldToGraphMatrix, ref float2 tileSize, int borderExpansion, out UnsafeSpan<int> bucketRanges, out UnsafeSpan<int> pointers);

		internal static class PutMeshesIntoTileBuckets_00000C26_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref UnsafeSpan<RasterizationMesh> meshes, ref IntRect tileBuckets, ref float4x4 worldToGraphMatrix, ref float2 tileSize, int borderExpansion, out UnsafeSpan<int> bucketRanges, out UnsafeSpan<int> pointers)
			{
				bucketRanges = default(UnsafeSpan<int>);
				pointers = default(UnsafeSpan<int>);
			}
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

		public TileLayout tileLayout;

		public IntRect tileRect;

		public List<RecastGraph.PerLayerModification> perLayerModifications;

		public List<RecastGraph.PerTerrainLayerModification> perTerrainLayerModifications;

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
			this.tileLayout = default(TileLayout);
			this.tileRect = default(IntRect);
			perLayerModifications = null;
			perTerrainLayerModifications = null;
		}

		public Bounds GetWorldSpaceBounds(float xzPadding = 0f)
		{
			return default(Bounds);
		}

		public RecastMeshGatherer.MeshCollection CollectMeshes(Bounds bounds)
		{
			return default(RecastMeshGatherer.MeshCollection);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(PutMeshesIntoTileBuckets_00000C26_0024PostfixBurstDelegate))]
		private static void PutMeshesIntoTileBuckets(ref UnsafeSpan<RasterizationMesh> meshes, ref IntRect tileBuckets, ref float4x4 worldToGraphMatrix, ref float2 tileSize, int borderExpansion, out UnsafeSpan<int> bucketRanges, out UnsafeSpan<int> pointers)
		{
			bucketRanges = default(UnsafeSpan<int>);
			pointers = default(UnsafeSpan<int>);
		}

		public Promise<TileBuilderOutput> Schedule(DisposeArena arena)
		{
			return default(Promise<TileBuilderOutput>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void PutMeshesIntoTileBuckets_0024BurstManaged(ref UnsafeSpan<RasterizationMesh> meshes, ref IntRect tileBuckets, ref float4x4 worldToGraphMatrix, ref float2 tileSize, int borderExpansion, out UnsafeSpan<int> bucketRanges, out UnsafeSpan<int> pointers)
		{
			bucketRanges = default(UnsafeSpan<int>);
			pointers = default(UnsafeSpan<int>);
		}
	}
}
