using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(SimulateMovement),
		typeof(SimulateMovementFinalize)
	})]
	[WithNone(new Type[] { typeof(AgentOffMeshLinkMovementDisabled) })]
	public struct JobMoveAgent : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MovementState> __Pathfinding_ECS_MovementState_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSettings> __Pathfinding_ECS_MovementSettings_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ResolvedMovement> __Pathfinding_ECS_ResolvedMovement_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MovementStatistics> __Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
				}

				public void Update(ref SystemState state)
				{
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref JobMoveAgent job, EntityQuery query)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobMoveAgent job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobMoveAgent job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobMoveAgent job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobMoveAgent job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobMoveAgent job, EntityManager entityManager)
			{
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public float dt;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public static quaternion ResolveRotation(quaternion rotation, ref MovementState state, in ResolvedMovement resolvedMovement, in MovementSettings movementSettings, in AgentMovementPlane movementPlane, float dt)
		{
			return default(quaternion);
		}

		public static float3 MoveWithoutGravity(float3 position, in ResolvedMovement resolvedMovement, in AgentMovementPlane movementPlane, float dt)
		{
			return default(float3);
		}

		public static void ResolvePositionSmoothing(float3 movementDelta, ref MovementState state, in MovementSettings movementSettings, float dt)
		{
		}

		public void Execute(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, ref MovementState state, in MovementSettings movementSettings, in ResolvedMovement resolvedMovement, ref MovementStatistics movementStatistics)
		{
		}

		public static void MoveAgent(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, ref MovementState state, in MovementSettings movementSettings, in ResolvedMovement resolvedMovement, ref MovementStatistics movementStatistics, float dt)
		{
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}

		private JobHandle __ThrowCodeGenException()
		{
			return default(JobHandle);
		}

		public void Run()
		{
		}

		public void RunByRef()
		{
		}

		public void Run(EntityQuery query)
		{
		}

		public void RunByRef(EntityQuery query)
		{
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public void Schedule()
		{
		}

		public void ScheduleByRef()
		{
		}

		public void Schedule(EntityQuery query)
		{
		}

		public void ScheduleByRef(EntityQuery query)
		{
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return default(JobHandle);
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return default(JobHandle);
		}

		public void ScheduleParallel()
		{
		}

		public void ScheduleParallelByRef()
		{
		}

		public void ScheduleParallel(EntityQuery query)
		{
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
		}
	}
}
