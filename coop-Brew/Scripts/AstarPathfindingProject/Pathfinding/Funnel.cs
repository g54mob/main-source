using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public static class Funnel
	{
		public struct FunnelPortals
		{
			public List<Vector3> left;

			public List<Vector3> right;
		}

		public enum PartType
		{
			OffMeshLink = 0,
			NodeSequence = 1
		}

		public struct PathPart
		{
			public int startIndex;

			public int endIndex;

			public Vector3 startPoint;

			public Vector3 endPoint;

			public PartType type;
		}

		[BurstCompile]
		public struct FunnelState
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void PushStart_0000095D_0024PostfixBurstDelegate(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis);

			internal static class PushStart_0000095D_0024BurstDirectCall
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

				public static void Invoke(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis)
				{
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ConvertCornerIndicesToPathProjected_00000967_0024PostfixBurstDelegate(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up);

			internal static class ConvertCornerIndicesToPathProjected_00000967_0024BurstDirectCall
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

				public static void Invoke(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up)
				{
				}
			}

			public NativeCircularBuffer<float3> leftFunnel;

			public NativeCircularBuffer<float3> rightFunnel;

			public NativeCircularBuffer<float4> unwrappedPortals;

			public float3 projectionAxis;

			public FunnelState(int initialCapacity, Allocator allocator)
			{
				leftFunnel = default(NativeCircularBuffer<float3>);
				rightFunnel = default(NativeCircularBuffer<float3>);
				unwrappedPortals = default(NativeCircularBuffer<float4>);
				projectionAxis = default(float3);
			}

			public FunnelState(FunnelPortals portals, Allocator allocator)
			{
				leftFunnel = default(NativeCircularBuffer<float3>);
				rightFunnel = default(NativeCircularBuffer<float3>);
				unwrappedPortals = default(NativeCircularBuffer<float4>);
				projectionAxis = default(float3);
			}

			public FunnelState Clone()
			{
				return default(FunnelState);
			}

			public void Clear()
			{
			}

			public void PopStart()
			{
			}

			public void PopEnd()
			{
			}

			public void Pop(bool fromStart)
			{
			}

			public void PushStart(float3 newLeftPortal, float3 newRightPortal)
			{
			}

			private static bool DifferentSidesOfLine(float3 start, float3 end, float3 a, float3 b)
			{
				return false;
			}

			public bool IsReasonableToPopStart(float3 startPoint, float3 endPoint)
			{
				return false;
			}

			public bool IsReasonableToPopEnd(float3 startPoint, float3 endPoint)
			{
				return false;
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(PushStart_0000095D_0024PostfixBurstDelegate))]
			private static void PushStart(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis)
			{
			}

			public void Splice(int startIndex, int toRemove, List<float3> newLeftPortal, List<float3> newRightPortal)
			{
			}

			public void PushEnd(Vector3 newLeftPortal, Vector3 newRightPortal)
			{
			}

			public void Push(bool toStart, Vector3 newLeftPortal, Vector3 newRightPortal)
			{
			}

			public void Dispose()
			{
			}

			public int CalculateNextCornerIndices(int maxCorners, NativeArray<int> result, float3 startPoint, float3 endPoint, out bool lastCorner)
			{
				lastCorner = default(bool);
				return 0;
			}

			public void CalculateNextCorners(int maxCorners, bool splitAtEveryPortal, float3 startPoint, float3 endPoint, NativeList<float3> result)
			{
			}

			public void ConvertCornerIndicesToPath(NativeArray<int> indices, int numCorners, bool splitAtEveryPortal, float3 startPoint, float3 endPoint, bool lastCorner, NativeList<float3> result)
			{
			}

			public void ConvertCornerIndicesToPathProjected(UnsafeSpan<int> indices, bool splitAtEveryPortal, float3 startPoint, float3 endPoint, bool lastCorner, NativeList<float3> result, float3 up)
			{
			}

			public float4x3 UnwrappedPortalsToWorldMatrix(float3 up)
			{
				return default(float4x3);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(ConvertCornerIndicesToPathProjected_00000967_0024PostfixBurstDelegate))]
			public static void ConvertCornerIndicesToPathProjected(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up)
			{
			}

			private static void CalculatePortalIntersections(int startIndex, int endIndex, NativeCircularBuffer<float3> leftPortals, NativeCircularBuffer<float3> rightPortals, NativeCircularBuffer<float4> unwrappedPortals, float2 from, float2 to, NativeList<float3> result)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void PushStart_0024BurstManaged(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void ConvertCornerIndicesToPathProjected_0024BurstManaged(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int Calculate_00000951_0024PostfixBurstDelegate(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner);

		internal static class Calculate_00000951_0024BurstDirectCall
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

			public static int Invoke(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner)
			{
				lastCorner = default(bool);
				return 0;
			}
		}

		public const int RightSideBit = 1073741824;

		public const int FunnelPortalIndexMask = 1073741823;

		public static List<PathPart> SplitIntoParts(Path path)
		{
			return null;
		}

		public static void Simplify(List<PathPart> parts, ref List<GraphNode> nodes)
		{
		}

		public static void Simplify(PathPart part, IRaycastableGraph graph, List<GraphNode> nodes, List<GraphNode> result, int[] tagPenalties, int traversableTags)
		{
		}

		private static void RemoveBacktracking(List<GraphNode> nodes, int listStartIndex, int aroundIndex)
		{
		}

		public static FunnelPortals ConstructFunnelPortals(List<GraphNode> nodes, PathPart part)
		{
			return default(FunnelPortals);
		}

		private static float2 Unwrap(float3 leftPortal, float3 rightPortal, float2 leftUnwrappedPortal, float2 rightUnwrappedPortal, float3 point, float sideMultiplier, float3 projectionAxis)
		{
			return default(float2);
		}

		private static bool RightOrColinear(Vector2 a, Vector2 b)
		{
			return false;
		}

		private static bool LeftOrColinear(Vector2 a, Vector2 b)
		{
			return false;
		}

		public static List<Vector3> Calculate(FunnelPortals funnel, bool splitAtEveryPortal)
		{
			return null;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(Calculate_00000951_0024PostfixBurstDelegate))]
		private static int Calculate(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner)
		{
			lastCorner = default(bool);
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static int Calculate_0024BurstManaged(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner)
		{
			lastCorner = default(bool);
			return 0;
		}
	}
}
