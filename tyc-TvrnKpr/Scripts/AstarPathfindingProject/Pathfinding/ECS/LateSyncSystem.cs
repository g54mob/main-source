using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[UpdateAfter(typeof(AIMoveSystem))]
	[UpdateAfter(typeof(MovementStatisticsSystem))]
	[RequireMatchingQueriesForUpdate]
	public struct LateSyncSystem : ISystem, ISystemCompilerGenerated
	{
		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentLookup<SyncPositionWithTransform> __Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SyncRotationWithTransform> __Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OrientationYAxisForward> __Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MovementState> __Pathfinding_ECS_MovementState_RO_ComponentLookup;

			public JobClearTemporaryData.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobClearTemporaryData_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private JobRepairPath.Scheduler jobRepairPathScheduler;

		private EntityQuery entityQueryPrepareMovement;

		private TypeHandle __TypeHandle;

		public void OnCreate(ref SystemState systemState)
		{
		}

		public void OnDestroy(ref SystemState systemState)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		private JobHandle ScheduleRepairPaths(ref SystemState systemState, JobHandle dependency)
		{
			return default(JobHandle);
		}

		private JobHandle ScheduleSyncEntitiesToTransforms(ref SystemState systemState, JobHandle dependency)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(JobClearTemporaryData job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
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
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
