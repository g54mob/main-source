using System;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Profiling;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[BurstCompile]
	public struct FollowerControlSystem : ISystem, ISystemCompilerGenerated
	{
		private struct TypeHandle
		{
			public JobManagedMovementOverrideBeforeControl.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedMovementOverrideBeforeControl_WithoutDefaultQuery_JobEntityTypeHandle;

			public JobControl.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobControl_WithDefaultQuery_JobEntityTypeHandle;

			public JobManagedMovementOverrideAfterControl.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobManagedMovementOverrideAfterControl_WithoutDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private EntityQuery entityQueryControlManaged;

		private EntityQuery entityQueryControlManaged2;

		private RedrawScope redrawScope;

		private static readonly ProfilerMarker MarkerMovementOverrideBeforeControl;

		private static readonly ProfilerMarker MarkerMovementOverrideAfterControl;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_248260819_0;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnDestroy(ref SystemState state)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		private void ProcessControlLoop(ref SystemState systemState, float dt)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_0(JobManagedMovementOverrideBeforeControl job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobControl job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_2(JobManagedMovementOverrideAfterControl job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
