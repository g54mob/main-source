using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace Pathfinding.ECS
{
	[BurstCompile]
	public struct JobPrepareAgentRaycasts : IJobEntity, IJobChunk
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

				public ComponentTypeHandle<ResolvedMovement> __Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementStatistics> __Pathfinding_ECS_MovementStatistics_RW_ComponentTypeHandle;

				public ComponentTypeHandle<GravityState> __Pathfinding_ECS_GravityState_RW_ComponentTypeHandle;

				[ReadOnly]
				public SharedComponentTypeHandle<PhysicsSceneRef> __Pathfinding_ECS_PhysicsSceneRef_SharedComponentTypeHandle;

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
			public void Run(ref JobPrepareAgentRaycasts job, EntityQuery query)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobPrepareAgentRaycasts job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobPrepareAgentRaycasts job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobPrepareAgentRaycasts job, EntityManager entityManager)
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

		public NativeArray<RaycastCommand> raycastCommands;

		public QueryParameters raycastQueryParameters;

		public float dt;

		public float gravity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		private void ApplyGravity(ref GravityState gravityState)
		{
		}

		private RaycastCommand CalculateRaycastCommands(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, in MovementSettings movementSettings, ref GravityState gravityState, PhysicsScene physicsScene)
		{
			return default(RaycastCommand);
		}

		public void Execute(ref LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, ref MovementState state, in MovementSettings movementSettings, ref ResolvedMovement resolvedMovement, ref MovementStatistics movementStatistics, ref GravityState gravityState, in PhysicsSceneRef physicsWorldIndex, [EntityIndexInQuery] int entityIndexInQuery)
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
