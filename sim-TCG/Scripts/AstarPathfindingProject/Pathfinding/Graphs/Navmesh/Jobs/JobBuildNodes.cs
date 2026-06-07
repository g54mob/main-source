using System;
using System.Runtime.InteropServices;
using Pathfinding.Jobs;
using Pathfinding.Util;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh.Jobs
{
	public struct JobBuildNodes
	{
		public class BuildNodeTilesOutput : IProgress, IDisposable
		{
			public TileBuilder.TileBuilderOutput dependency;

			public NavmeshTile[] tiles;

			public float Progress => dependency.Progress;

			public void Dispose()
			{
			}
		}

		private AstarPath astar;

		private uint graphIndex;

		public uint initialPenalty;

		public bool recalculateNormals;

		public float maxTileConnectionEdgeDistance;

		private Matrix4x4 graphToWorldSpace;

		private TileLayout tileLayout;

		internal JobBuildNodes(RecastGraph graph, TileLayout tileLayout)
		{
			astar = graph.active;
			this.tileLayout = tileLayout;
			graphIndex = graph.graphIndex;
			initialPenalty = graph.initialPenalty;
			recalculateNormals = graph.RecalculateNormals;
			maxTileConnectionEdgeDistance = graph.MaxTileConnectionEdgeDistance;
			graphToWorldSpace = tileLayout.transform.matrix;
		}

		public Promise<BuildNodeTilesOutput> Schedule(DisposeArena arena, Promise<TileBuilder.TileBuilderOutput> dependency)
		{
			TileBuilder.TileBuilderOutput value = dependency.GetValue();
			IntRect tileRect = value.tileMeshes.tileRect;
			NavmeshTile[] array = new NavmeshTile[tileRect.Area];
			GCHandle gCHandle = GCHandle.Alloc(array);
			NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe> nativeArray = new NativeArray<JobCalculateTriangleConnections.TileNodeConnectionsUnsafe>(tileRect.Area, Allocator.Persistent);
			JobHandle job = Unity.Jobs.IJobExtensions.Schedule(new JobCalculateTriangleConnections
			{
				tileMeshes = value.tileMeshes.tileMeshes,
				nodeConnections = nativeArray
			}, dependency.handle);
			Vector2 tileWorldSize = new Vector2(tileLayout.TileWorldSizeX, tileLayout.TileWorldSizeZ);
			JobHandle job2 = Unity.Jobs.IJobExtensions.Schedule(new JobCreateTiles
			{
				tileMeshes = value.tileMeshes.tileMeshes,
				tiles = gCHandle,
				tileRect = tileRect,
				graphTileCount = tileLayout.tileCount,
				graphIndex = graphIndex,
				initialPenalty = initialPenalty,
				recalculateNormals = recalculateNormals,
				graphToWorldSpace = graphToWorldSpace,
				tileWorldSize = tileWorldSize
			}, dependency.handle);
			JobHandle dependency2 = Unity.Jobs.IJobExtensions.Schedule(new JobWriteNodeConnections
			{
				nodeConnections = nativeArray,
				tiles = gCHandle
			}, JobHandle.CombineDependencies(job, job2));
			JobHandle handle = JobConnectTiles.ScheduleBatch(gCHandle, dependency2, tileRect, tileWorldSize, maxTileConnectionEdgeDistance);
			arena.Add(gCHandle);
			arena.Add(nativeArray);
			return new Promise<BuildNodeTilesOutput>(handle, new BuildNodeTilesOutput
			{
				dependency = value,
				tiles = array
			});
		}
	}
}
