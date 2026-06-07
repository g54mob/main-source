using System;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Unity.Entities;
using Unity.Jobs;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	public struct AIGizmosSystem : ISystem, ISystemCompilerGenerated
	{
		private class DrawerCallback : IDrawGizmos
		{
			private World world;

			public bool Exists => false;

			public DrawerCallback(World world)
			{
			}

			public void DrawGizmos()
			{
			}
		}

		private struct TypeHandle
		{
			public JobDrawFollowerGizmosBase.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobDrawFollowerGizmosBase_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private static bool manuallyTriggered;

		private JobRepairPath.Scheduler jobRepairPathScheduler;

		private ComponentTypeHandle<MovementState> MovementStateTypeHandleRO;

		private ComponentTypeHandle<ResolvedMovement> ResolvedMovementHandleRO;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_2063717491_0;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		private void DrawGizmos(ref SystemState systemState)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(JobDrawFollowerGizmosBase job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
