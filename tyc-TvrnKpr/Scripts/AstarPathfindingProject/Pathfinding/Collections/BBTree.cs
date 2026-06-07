using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Drawing;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Profiling;

namespace Pathfinding.Collections
{
	[BurstCompile]
	public struct BBTree : IDisposable
	{
		[BurstCompile]
		public readonly struct ProjectionParams
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate float SquaredRectPointDistanceOnPlane_00000F48_0024PostfixBurstDelegate(in ProjectionParams projection, ref IntRect rect, ref float3 p);

			internal static class SquaredRectPointDistanceOnPlane_00000F48_0024BurstDirectCall
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

				public static float Invoke(in ProjectionParams projection, ref IntRect rect, ref float3 p)
				{
					return 0f;
				}
			}

			public readonly float2x3 planeProjection;

			public readonly float2 projectedUpNormalized;

			public readonly float3 projectionAxis;

			public readonly float distanceScaleAlongProjectionAxis;

			public readonly DistanceMetric distanceMetricType;

			private readonly byte alignedWithXZPlaneBacking;

			public bool alignedWithXZPlane => false;

			public float SquaredRectPointDistanceOnPlane(IntRect rect, float3 p)
			{
				return 0f;
			}

			[BurstCompile(FloatMode = FloatMode.Fast)]
			[IgnoredByDeepProfiler]
			[MonoPInvokeCallback(typeof(SquaredRectPointDistanceOnPlane_00000F48_0024PostfixBurstDelegate))]
			private static float SquaredRectPointDistanceOnPlane(in ProjectionParams projection, ref IntRect rect, ref float3 p)
			{
				return 0f;
			}

			public ProjectionParams(ref Pathfinding.DistanceMetric distanceMetric, GraphTransform graphTransform)
			{
				planeProjection = default(float2x3);
				projectedUpNormalized = default(float2);
				projectionAxis = default(float3);
				distanceScaleAlongProjectionAxis = 0f;
				distanceMetricType = default(DistanceMetric);
				alignedWithXZPlaneBacking = 0;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile(FloatMode = FloatMode.Fast)]
			[IgnoredByDeepProfiler]
			public static float SquaredRectPointDistanceOnPlane_0024BurstManaged(in ProjectionParams projection, ref IntRect rect, ref float3 p)
			{
				return 0f;
			}
		}

		private struct CloseNode
		{
			public int node;

			public float distanceSq;

			public float tieBreakingDistance;

			public float3 closestPointOnNode;
		}

		public enum DistanceMetric : byte
		{
			Euclidean = 0,
			ScaledManhattan = 1
		}

		[BurstCompile]
		private struct NearbyNodesIterator : IEnumerator<CloseNode>, IEnumerator, IDisposable
		{
			public struct BoxWithDist
			{
				public int index;

				public float distSqr;
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate bool MoveNext_00000F4F_0024PostfixBurstDelegate(ref NearbyNodesIterator it);

			internal static class MoveNext_00000F4F_0024BurstDirectCall
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

				public static bool Invoke(ref NearbyNodesIterator it)
				{
					return false;
				}
			}

			public UnsafeSpan<BoxWithDist> stack;

			public int stackSize;

			public UnsafeSpan<BBTreeBox> tree;

			public UnsafeSpan<int> nodes;

			public UnsafeSpan<int> triangles;

			public UnsafeSpan<Int3> vertices;

			public int indexInLeaf;

			public float3 point;

			public ProjectionParams projection;

			public float distanceThresholdSqr;

			public float tieBreakingDistanceThreshold;

			internal CloseNode current;

			public CloseNode Current => default(CloseNode);

			object IEnumerator.Current => null;

			public bool MoveNext()
			{
				return false;
			}

			void IDisposable.Dispose()
			{
			}

			void IEnumerator.Reset()
			{
			}

			[BurstCompile(FloatMode = FloatMode.Default)]
			[MonoPInvokeCallback(typeof(MoveNext_00000F4F_0024PostfixBurstDelegate))]
			private static bool MoveNext(ref NearbyNodesIterator it)
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile(FloatMode = FloatMode.Default)]
			public static bool MoveNext_0024BurstManaged(ref NearbyNodesIterator it)
			{
				return false;
			}
		}

		private struct BBTreeBox
		{
			public IntRect rect;

			public int nodeOffset;

			public int left;

			public int right;

			public bool IsLeaf => false;

			public BBTreeBox(IntRect rect)
			{
				this.rect = default(IntRect);
				nodeOffset = 0;
				left = 0;
				right = 0;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void Build_00000F3D_0024PostfixBurstDelegate(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree);

		internal static class Build_00000F3D_0024BurstDirectCall
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

			public static void Invoke(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree)
			{
				bbTree = default(BBTree);
			}
		}

		private UnsafeList<BBTreeBox> tree;

		private UnsafeList<int> nodePermutation;

		private const int MaximumLeafSize = 4;

		private const int MAX_TREE_HEIGHT = 26;

		public IntRect Size => default(IntRect);

		public void Dispose()
		{
		}

		public BBTree(UnsafeSpan<int> triangles, UnsafeSpan<Int3> vertices)
		{
			tree = default(UnsafeList<BBTreeBox>);
			nodePermutation = default(UnsafeList<int>);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Build_00000F3D_0024PostfixBurstDelegate))]
		private static void Build(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree)
		{
			bbTree = default(BBTree);
		}

		private static int SplitByX(NativeArray<IntRect> nodesBounds, NativeArray<int> permutation, int from, int to, int divider)
		{
			return 0;
		}

		private static int SplitByZ(NativeArray<IntRect> nodesBounds, NativeArray<int> permutation, int from, int to, int divider)
		{
			return 0;
		}

		private static int BuildSubtree(NativeArray<int> permutation, NativeArray<IntRect> nodeBounds, ref UnsafeList<int> nodes, ref UnsafeList<BBTreeBox> tree, int from, int to, bool odd, int depth)
		{
			return 0;
		}

		private static IntRect NodeBounds(NativeArray<int> permutation, NativeArray<IntRect> nodeBounds, int from, int to)
		{
			return default(IntRect);
		}

		public float DistanceSqrLowerBound(float3 p, in ProjectionParams projection)
		{
			return 0f;
		}

		public void QueryClosest(float3 p, ref NearestNodeConstraint constraint, in ProjectionParams projection, ref float distanceSqr, ref NNInfo previous, GraphNode[] nodes, UnsafeSpan<int> triangles, UnsafeSpan<Int3> vertices)
		{
		}

		public void DrawGizmos(CommandBuilder draw)
		{
		}

		private void DrawGizmos(ref CommandBuilder draw, int boxi, int depth)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void Build_0024BurstManaged(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree)
		{
			bbTree = default(BBTree);
		}
	}
}
