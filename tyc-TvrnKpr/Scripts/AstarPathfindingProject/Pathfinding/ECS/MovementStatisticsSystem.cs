using System;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Jobs;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[UpdateAfter(typeof(AIMoveSystem))]
	[RequireMatchingQueriesForUpdate]
	public struct MovementStatisticsSystem : ISystem, ISystemCompilerGenerated
	{
		private struct TypeHandle
		{
			public JobUpdateMovementStatistics.InternalCompilerQueryAndHandleData __Pathfinding_ECS_JobUpdateMovementStatistics_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private TypeHandle __TypeHandle;

		public void OnUpdate(ref SystemState state)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(JobUpdateMovementStatistics job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
