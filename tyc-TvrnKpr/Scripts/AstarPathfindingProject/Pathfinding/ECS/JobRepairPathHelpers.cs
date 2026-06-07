using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[BurstCompile]
	internal static class JobRepairPathHelpers
	{
		public struct PathTracerInfo
		{
			public float3 endPointOfFirstPart;

			public int partCount;

			public bool isStale;

			public bool hasValidEndPoint;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void UpdateReachedEndInfo_0000140D_0024PostfixBurstDelegate(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer);

		internal static class UpdateReachedEndInfo_0000140D_0024BurstDirectCall
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

			public static void Invoke(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer)
			{
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(UpdateReachedEndInfo_0000140D_0024PostfixBurstDelegate))]
		public static void UpdateReachedEndInfo(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer)
		{
		}

		public static void UpdateReachedOrientation(ref MovementState state, ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref DestinationPoint destination)
		{
		}

		private static bool ReachedDesiredOrientation(ref LocalTransform transform, ref AgentMovementPlane movementPlane, ref DestinationPoint destination)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void UpdateReachedEndInfo_0024BurstManaged(ref UnsafeSpan<float3> nextCorners, ref MovementState state, ref AgentMovementPlane movementPlane, ref LocalTransform transform, ref AgentCylinderShape shape, ref DestinationPoint destination, float stopDistance, ref PathTracerInfo pathTracer)
		{
		}
	}
}
