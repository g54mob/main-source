using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Sync;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	public struct TileCutter
	{
		public struct TileCutterOutput : IProgress, IDisposable
		{
			public TileMeshesUnsafe tileMeshes;

			public float Progress => 0f;

			public void Dispose()
			{
			}
		}

		[BurstCompile]
		private struct JobCutTiles : IJob
		{
			public UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices;

			public UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles;

			public UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags;

			public TileHandler.CutCollection cutCollection;

			public TileMeshesUnsafe inputTileMeshes;

			public NativeArray<TileMesh.TileMeshUnsafe> outputTileMeshes;

			public void Execute()
			{
			}
		}

		private NavmeshBase graph;

		private GridLookup<NavmeshClipper> cuts;

		private TileLayout tileLayout;

		public TileCutter(NavmeshBase graph, GridLookup<NavmeshClipper> cuts, TileLayout tileLayout)
		{
			this.graph = null;
			this.cuts = null;
			this.tileLayout = default(TileLayout);
		}

		private static void DisposeTileData(UnsafeSpan<UnsafeList<UnsafeSpan<Int3>>> tileVertices, UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTriangles, UnsafeSpan<UnsafeList<UnsafeSpan<int>>> tileTags, Allocator allocator, bool skipFirst)
		{
		}

		public static void EnsurePreCutDataExists(NavmeshBase graph, NavmeshTile tile)
		{
		}

		private static bool CheckVersion()
		{
			return false;
		}

		public Promise<TileCutterOutput> Schedule(List<Vector2Int> tileCoordinates)
		{
			return default(Promise<TileCutterOutput>);
		}

		public Promise<TileCutterOutput> Schedule(Promise<TileBuilder.TileBuilderOutput> builderOutput)
		{
			return default(Promise<TileCutterOutput>);
		}
	}
}
