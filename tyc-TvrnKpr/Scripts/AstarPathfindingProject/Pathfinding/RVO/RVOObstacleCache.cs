using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Sync;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;

namespace Pathfinding.RVO
{
	[BurstCompile]
	public static class RVOObstacleCache
	{
		public struct ObstacleSegment
		{
			public float3 vertex1;

			public float3 vertex2;

			public int vertex1LinkId;

			public int vertex2LinkId;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void TraceContours_000010F1_0024PostfixBurstDelegate(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles);

		internal static class TraceContours_000010F1_0024BurstDirectCall
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

			public unsafe static void Invoke(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles)
			{
			}
		}

		private static readonly ProfilerMarker MarkerAllocate;

		private static ulong HashKey(GraphNode sourceNode, int traversableTags, SimpleMovementPlane movementPlane)
		{
			return 0uL;
		}

		public static void CollectContours(List<GraphNode> nodes, NativeList<ObstacleSegment> obstacles)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(TraceContours_000010F1_0024PostfixBurstDelegate))]
		internal unsafe static void TraceContours(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public unsafe static void TraceContours_0024BurstManaged(ref UnsafeSpan<ObstacleSegment> obstaclesSpan, ref NativeMovementPlane movementPlane, int obstacleId, UnmanagedObstacle* outputObstacles, ref SlabAllocator<float3> verticesAllocator, ref SlabAllocator<ObstacleVertexGroup> obstaclesAllocator, ref SpinLock spinLock, bool simplifyObstacles)
		{
		}
	}
}
