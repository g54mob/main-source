using System;
using System.Runtime.CompilerServices;
using Pathfinding.ECS.RVO;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Profiling;

namespace Pathfinding.ECS
{
	[BurstCompile]
	[UpdateAfter(typeof(FollowerControlSystem))]
	[UpdateAfter(typeof(RVOSystem))]
	[UpdateAfter(typeof(FallbackResolveMovementSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	public struct AIMoveSystem : ISystem, ISystemCompilerGenerated
	{
		private struct TypeHandle
		{
			public JobAlignAgentWithMovementDirection.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobAlignAgentWithMovementDirection_WithDefaultQuery_JobEntityTypeHandle;

			public JobMoveAgent.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobMoveAgent_WithDefaultQuery_JobEntityTypeHandle;

			public JobPrepareAgentRaycasts.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobPrepareAgentRaycasts_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobApplyGravity.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobApplyGravity_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobManagedMovementOverrideBeforeMovement.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedMovementOverrideBeforeMovement_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private EntityQuery entityQueryWithGravity;

		private EntityQuery entityQueryMovementOverride;

		private static readonly ProfilerMarker MarkerMovementOverride;

		private TypeHandle __TypeHandle;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		private void ScheduleApplyGravity(ref SystemState systemState, float dt)
		{
		}

		private void RunMovementOverrideBeforeMovement(ref SystemState systemState, float dt)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(JobAlignAgentWithMovementDirection job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobMoveAgent job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_2(JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_3(JobApplyGravity job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_4(JobManagedMovementOverrideBeforeMovement job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
