using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Jobs;

namespace Pathfinding.ECS
{
	[UpdateBefore(typeof(TransformSystemGroup))]
	[UpdateBefore(typeof(AIMovementSystemGroup))]
	[UpdateInGroup(typeof(SimulationSystemGroup))]
	public struct SyncTransformsToEntitiesSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct SyncTransformsToEntitiesJob : IJobParallelForTransform
		{
			[ReadOnly]
			[DeallocateOnJobCompletion]
			public NativeArray<Entity> entities;

			[NativeDisableParallelForRestriction]
			public ComponentLookup<LocalTransform> entityPositions;

			[ReadOnly]
			public ComponentLookup<SyncPositionWithTransform> syncPositionWithTransform;

			[ReadOnly]
			public ComponentLookup<SyncRotationWithTransform> syncRotationWithTransform;

			[ReadOnly]
			public ComponentLookup<OrientationYAxisForward> orientationYAxisForward;

			[ReadOnly]
			public ComponentLookup<MovementState> movementState;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		private struct TypeHandle
		{
			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SyncPositionWithTransform> __Pathfinding_ECS_SyncPositionWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<SyncRotationWithTransform> __Pathfinding_ECS_SyncRotationWithTransform_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OrientationYAxisForward> __Pathfinding_ECS_OrientationYAxisForward_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MovementState> __Pathfinding_ECS_MovementState_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		public static readonly quaternion ZAxisForwardToYAxisForward;

		public static readonly quaternion YAxisForwardToZAxisForward;

		private TypeHandle __TypeHandle;

		public void OnUpdate(ref SystemState systemState)
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
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
