using System;
using System.Collections.Generic;
using Pathfinding.Graphs.Navmesh.Jobs;
using Pathfinding.Graphs.Navmesh.Voxelization.Burst;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
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

			public float Progress
			{
				get
				{
					int area = tileMeshes.tileRect.Area;
					int num = Mathf.Min(area, currentTileCounter.Value);
					if (area <= 0)
					{
						return 0f;
					}
					return (float)num / (float)area;
				}
			}

			public void Dispose()
			{
				tileMeshes.Dispose();
				if (currentTileCounter.IsCreated)
				{
					currentTileCounter.Dispose();
				}
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

		private int TileBorderSizeInVoxels => characterRadiusInVoxels + 3;

		private float TileBorderSizeInWorldUnits => (float)TileBorderSizeInVoxels * tileLayout.cellSize;

		public TileBuilder(RecastGraph graph, TileLayout tileLayout, IntRect tileRect)
		{
			this.tileLayout = tileLayout;
			this.tileRect = tileRect;
			walkableClimb = Mathf.Min(graph.walkableClimb, graph.walkableHeight);
			collectionSettings = graph.collectionSettings;
			dimensionMode = graph.dimensionMode;
			backgroundTraversability = graph.backgroundTraversability;
			tileBorderSizeInVoxels = graph.TileBorderSizeInVoxels;
			walkableHeight = graph.walkableHeight;
			maxSlope = graph.maxSlope;
			characterRadiusInVoxels = graph.CharacterRadiusInVoxels;
			minRegionSize = Mathf.RoundToInt(graph.minRegionSize);
			maxEdgeLength = graph.maxEdgeLength;
			contourMaxError = graph.contourMaxError;
			relevantGraphSurfaceMode = graph.relevantGraphSurfaceMode;
			scene = graph.active.gameObject.scene;
			perLayerModifications = graph.perLayerModifications;
		}

		public Bounds GetWorldSpaceBounds(float xzPadding = 0f)
		{
			Bounds tileBoundsInGraphSpace = tileLayout.GetTileBoundsInGraphSpace(tileRect.xmin, tileRect.ymin, tileRect.Width, tileRect.Height);
			tileBoundsInGraphSpace.Expand(new Vector3(2f * xzPadding, 0f, 2f * xzPadding));
			return tileLayout.transform.Transform(tileBoundsInGraphSpace);
		}

		public RecastMeshGatherer.MeshCollection CollectMeshes(Bounds bounds)
		{
			_ = collectionSettings.layerMask;
			_ = collectionSettings.tagMask;
			if (collectionSettings.collectionMode != RecastGraph.CollectionSettings.FilterMode.Layers)
			{
				_ = (LayerMask)(-1);
			}
			RecastMeshGatherer recastMeshGatherer = new RecastMeshGatherer(scene, bounds, collectionSettings.terrainHeightmapDownsamplingFactor, collectionSettings.layerMask, collectionSettings.tagMask, perLayerModifications, tileLayout.cellSize / collectionSettings.colliderRasterizeDetail);
			if (collectionSettings.rasterizeMeshes && dimensionMode == RecastGraph.DimensionMode.Dimension3D)
			{
				recastMeshGatherer.CollectSceneMeshes();
			}
			recastMeshGatherer.CollectRecastMeshObjs();
			if (collectionSettings.rasterizeTerrain && dimensionMode == RecastGraph.DimensionMode.Dimension3D)
			{
				float desiredChunkSize = 0.51f * tileLayout.cellSize * (float)(math.max(tileLayout.tileSizeInVoxels.x, tileLayout.tileSizeInVoxels.y) + 2 * TileBorderSizeInVoxels);
				recastMeshGatherer.CollectTerrainMeshes(collectionSettings.rasterizeTrees, desiredChunkSize);
			}
			if (collectionSettings.rasterizeColliders || dimensionMode == RecastGraph.DimensionMode.Dimension2D)
			{
				if (dimensionMode == RecastGraph.DimensionMode.Dimension3D)
				{
					recastMeshGatherer.CollectColliderMeshes();
				}
				else
				{
					recastMeshGatherer.Collect2DColliderMeshes();
				}
			}
			if (collectionSettings.onCollectMeshes != null)
			{
				collectionSettings.onCollectMeshes(recastMeshGatherer);
			}
			RecastMeshGatherer.MeshCollection result = recastMeshGatherer.Finalize();
			if (tileRect == new IntRect(0, 0, tileLayout.tileCount.x - 1, tileLayout.tileCount.y - 1) && result.meshes.Length == 0)
			{
				Debug.LogWarning("No rasterizable objects were found contained in the layers specified by the 'mask' variables");
			}
			return result;
		}

		private BucketMapping PutMeshesIntoTileBuckets(RecastMeshGatherer.MeshCollection meshCollection, IntRect tileBuckets)
		{
			int num = tileBuckets.Width * tileBuckets.Height;
			NativeList<int>[] array = new NativeList<int>[num];
			float tileBorderSizeInWorldUnits = TileBorderSizeInWorldUnits;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new NativeList<int>(Allocator.Persistent);
			}
			Int2 offset = -tileBuckets.Min;
			IntRect b = new IntRect(0, 0, tileBuckets.Width - 1, tileBuckets.Height - 1);
			NativeArray<RasterizationMesh> meshes = meshCollection.meshes;
			for (int j = 0; j < meshes.Length; j++)
			{
				Bounds bounds = meshes[j].bounds;
				IntRect intRect = IntRect.Intersection(tileLayout.GetTouchingTiles(bounds, tileBorderSizeInWorldUnits).Offset(offset), b);
				for (int k = intRect.ymin; k <= intRect.ymax; k++)
				{
					for (int l = intRect.xmin; l <= intRect.xmax; l++)
					{
						array[l + k * tileBuckets.Width].Add(in j);
					}
				}
			}
			int num2 = 0;
			for (int m = 0; m < array.Length; m++)
			{
				num2 += array[m].Length;
			}
			NativeArray<int> nativeArray = new NativeArray<int>(num2, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			NativeArray<int> bucketRanges = new NativeArray<int>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			num2 = 0;
			for (int n = 0; n < array.Length; n++)
			{
				if (array[n].Length > 0)
				{
					NativeArray<int>.Copy(array[n].AsArray(), 0, nativeArray, num2, array[n].Length);
				}
				num2 = (bucketRanges[n] = num2 + array[n].Length);
				array[n].Dispose();
			}
			return new BucketMapping
			{
				meshes = meshCollection.meshes,
				pointers = nativeArray,
				bucketRanges = bucketRanges
			};
		}

		public Promise<TileBuilderOutput> Schedule(DisposeArena arena)
		{
			int area = tileRect.Area;
			int width = tileRect.Width;
			int height = tileRect.Height;
			Bounds worldSpaceBounds = GetWorldSpaceBounds(TileBorderSizeInWorldUnits);
			if (dimensionMode == RecastGraph.DimensionMode.Dimension2D)
			{
				worldSpaceBounds.extents = new Vector3(worldSpaceBounds.extents.x, worldSpaceBounds.extents.y, float.PositiveInfinity);
			}
			RecastMeshGatherer.MeshCollection meshCollection = CollectMeshes(worldSpaceBounds);
			BucketMapping inputMeshes = PutMeshesIntoTileBuckets(meshCollection, tileRect);
			NativeArray<TileMesh.TileMeshUnsafe> nativeArray = new NativeArray<TileMesh.TileMeshUnsafe>(area, Allocator.Persistent);
			int width2 = tileLayout.tileSizeInVoxels.x + tileBorderSizeInVoxels * 2;
			int depth = tileLayout.tileSizeInVoxels.y + tileBorderSizeInVoxels * 2;
			float cellHeight = tileLayout.CellHeight;
			uint voxelWalkableHeight = (uint)(walkableHeight / cellHeight);
			int voxelWalkableClimb = Mathf.RoundToInt(walkableClimb / cellHeight);
			NativeArray<Bounds> nativeArray2 = new NativeArray<Bounds>(area, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					int index = j + i * width;
					Bounds tileBoundsInGraphSpace = tileLayout.GetTileBoundsInGraphSpace(tileRect.xmin + j, tileRect.ymin + i);
					tileBoundsInGraphSpace.Expand(new Vector3(1f, 0f, 1f) * TileBorderSizeInWorldUnits * 2f);
					nativeArray2[index] = tileBoundsInGraphSpace;
				}
			}
			TileBuilderBurst[] array = new TileBuilderBurst[Mathf.Max(1, Mathf.Min(area, JobsUtility.JobWorkerCount + 1))];
			NativeReference<int> nativeReference = new NativeReference<int>(0, Allocator.Persistent);
			JobHandle jobHandle = default(JobHandle);
			NativeList<JobBuildRegions.RelevantGraphSurfaceInfo> data = new NativeList<JobBuildRegions.RelevantGraphSurfaceInfo>(Allocator.Persistent);
			RelevantGraphSurface relevantGraphSurface = RelevantGraphSurface.Root;
			while (relevantGraphSurface != null)
			{
				data.Add(new JobBuildRegions.RelevantGraphSurfaceInfo
				{
					position = relevantGraphSurface.transform.position,
					range = relevantGraphSurface.maxRange
				});
				relevantGraphSurface = relevantGraphSurface.Next;
			}
			int num = Mathf.CeilToInt(Mathf.Sqrt(area));
			int num2 = num * array.Length;
			int num3 = 2 * (area + num2 - 1) / num2;
			JobBuildTileMeshFromVoxels jobData = new JobBuildTileMeshFromVoxels
			{
				tileBuilder = array[0],
				inputMeshes = inputMeshes,
				tileGraphSpaceBounds = nativeArray2,
				voxelWalkableClimb = voxelWalkableClimb,
				voxelWalkableHeight = voxelWalkableHeight,
				voxelToTileSpace = Matrix4x4.Scale(new Vector3(tileLayout.cellSize, cellHeight, tileLayout.cellSize)) * Matrix4x4.Translate(-new Vector3(1f, 0f, 1f) * TileBorderSizeInVoxels),
				cellSize = tileLayout.cellSize,
				cellHeight = cellHeight,
				maxSlope = Mathf.Max(maxSlope, 0.0001f),
				dimensionMode = dimensionMode,
				backgroundTraversability = backgroundTraversability,
				graphToWorldSpace = tileLayout.transform.matrix,
				graphSpaceLimits = new Vector2(tileLayout.graphSpaceSize.x + (float)(characterRadiusInVoxels - 1) * tileLayout.cellSize, tileLayout.graphSpaceSize.z + (float)(characterRadiusInVoxels - 1) * tileLayout.cellSize),
				characterRadiusInVoxels = characterRadiusInVoxels,
				tileBorderSizeInVoxels = tileBorderSizeInVoxels,
				minRegionSize = minRegionSize,
				maxEdgeLength = maxEdgeLength,
				contourMaxError = contourMaxError,
				maxTiles = num,
				relevantGraphSurfaces = data.AsArray(),
				relevantGraphSurfaceMode = relevantGraphSurfaceMode
			};
			jobData.SetOutputMeshes(nativeArray);
			jobData.SetCounter(nativeReference);
			int maximumVoxelYCoord = (int)(tileLayout.graphSpaceSize.y / cellHeight);
			for (int k = 0; k < array.Length; k++)
			{
				jobData.tileBuilder = (array[k] = new TileBuilderBurst(width2, depth, (int)voxelWalkableHeight, maximumVoxelYCoord));
				JobHandle jobHandle2 = default(JobHandle);
				for (int l = 0; l < num3; l++)
				{
					jobHandle2 = jobData.Schedule(jobHandle2);
				}
				jobHandle = JobHandle.CombineDependencies(jobHandle, jobHandle2);
			}
			JobHandle.ScheduleBatchedJobs();
			arena.Add(nativeArray2);
			arena.Add(data);
			arena.Add(inputMeshes.bucketRanges);
			arena.Add(inputMeshes.pointers);
			arena.Add(meshCollection);
			for (int m = 0; m < array.Length; m++)
			{
				arena.Add(array[m]);
			}
			return new Promise<TileBuilderOutput>(jobHandle, new TileBuilderOutput
			{
				tileMeshes = new TileMeshesUnsafe(nativeArray, tileRect, new Vector2(tileLayout.TileWorldSizeX, tileLayout.TileWorldSizeZ)),
				currentTileCounter = nativeReference
			});
		}
	}
}
