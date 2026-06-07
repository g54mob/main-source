using System.Runtime.InteropServices;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.RVO;
using Pathfinding.Sync;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public class NavmeshEdges
	{
		[BurstCompile]
		private struct JobResizeObstacles : IJob
		{
			public NativeList<UnmanagedObstacle> obstacles;

			public NativeReference<int> numHierarchicalNodes;

			public void Execute()
			{
			}
		}

		private struct JobCalculateObstacles : IJobParallelForBatch
		{
			public GCHandle hGraphGC;

			public SlabAllocator<float3> obstacleVertices;

			public SlabAllocator<ObstacleVertexGroup> obstacleVertexGroups;

			[NativeDisableParallelForRestriction]
			public NativeArray<UnmanagedObstacle> obstacles;

			[NativeDisableParallelForRestriction]
			public NativeArray<Bounds> bounds;

			[ReadOnly]
			public NativeList<int> dirtyHierarchicalNodes;

			[NativeDisableParallelForRestriction]
			public NativeReference<SpinLock> allocationLock;

			private static readonly ProfilerMarker MarkerBBox;

			private static readonly ProfilerMarker MarkerObstacles;

			private static readonly ProfilerMarker MarkerCollect;

			private static readonly ProfilerMarker MarkerTrace;

			public void Execute(int startIndex, int count)
			{
			}

			private void CalculateBoundingBox(HierarchicalGraph hGraph, int hierarchicalNode)
			{
			}

			private void CalculateObstacles(HierarchicalGraph hGraph, int hierarchicalNode, SlabAllocator<ObstacleVertexGroup> obstacleVertexGroups, SlabAllocator<float3> obstacleVertices, NativeArray<UnmanagedObstacle> obstacles, NativeList<RVOObstacleCache.ObstacleSegment> edgesScratch)
			{
			}
		}

		public struct NavmeshBorderData
		{
			public HierarchicalGraph.HierarhicalNodeData hierarhicalNodeData;

			public SimulatorBurst.ObstacleData obstacleData;

			public static NavmeshBorderData CreateEmpty(Allocator allocator)
			{
				return default(NavmeshBorderData);
			}

			public void DisposeEmpty(JobHandle dependsOn)
			{
			}

			private static void GetHierarchicalNodesInRangeRec(int hierarchicalNode, Bounds bounds, SlabAllocator<int> connectionAllocator, [NoAlias] NativeList<int> connectionAllocations, NativeList<Bounds> nodeBounds, [NoAlias] NativeList<int> indices)
			{
			}

			private static void ConvertObstaclesToEdges(ref SimulatorBurst.ObstacleData obstacleData, NativeList<int> obstacleIndices, Bounds localBounds, NativeList<float2> edgeBuffer, NativeMovementPlane movementPlane)
			{
			}

			public GraphHitInfo GetClosestEdge(int hierarchicalNode, float3 position, NativeList<int> scratchBuffer)
			{
				return default(GraphHitInfo);
			}

			public void GetObstaclesInRange(int hierarchicalNode, Bounds bounds, NativeList<int> obstacleIndexBuffer)
			{
			}

			public void GetEdgesInRange(int hierarchicalNode, Bounds localBounds, NativeList<float2> edgeBuffer, NativeList<int> scratchBuffer, NativeMovementPlane movementPlane)
			{
			}
		}

		public SimulatorBurst.ObstacleData obstacleData;

		private NativeReference<SpinLock> allocationLock;

		private const int JobRecalculateObstaclesBatchCount = 32;

		private RWLock rwLock;

		public HierarchicalGraph hierarchicalGraph;

		private int gizmoVersion;

		public void Dispose()
		{
		}

		private void Init()
		{
		}

		public JobHandle RecalculateObstacles(NativeList<int> dirtyHierarchicalNodes, NativeReference<int> numHierarchicalNodes, JobHandle dependency)
		{
			return default(JobHandle);
		}

		public void OnDrawGizmos(DrawingData gizmos, bool renderInGame)
		{
		}

		public NavmeshBorderData GetNavmeshEdgeData(out RWLock.CombinedReadLockAsync readLock)
		{
			readLock = default(RWLock.CombinedReadLockAsync);
			return default(NavmeshBorderData);
		}
	}
}
