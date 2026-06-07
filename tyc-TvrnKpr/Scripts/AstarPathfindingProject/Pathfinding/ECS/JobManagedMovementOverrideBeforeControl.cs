using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	public struct JobManagedMovementOverrideBeforeControl : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<ManagedMovementOverrideBeforeControl> __Pathfinding_ECS_ManagedMovementOverrideBeforeControl_RW_ComponentTypeHandle;

				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

				public ComponentTypeHandle<DestinationPoint> __Pathfinding_ECS_DestinationPoint_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementState> __Pathfinding_ECS_MovementState_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementSettings> __Pathfinding_ECS_MovementSettings_RW_ComponentTypeHandle;

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
			public void Run(ref JobManagedMovementOverrideBeforeControl job, EntityQuery query)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref JobManagedMovementOverrideBeforeControl job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref JobManagedMovementOverrideBeforeControl job, EntityQuery query, JobHandle dependency)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref JobManagedMovementOverrideBeforeControl job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref JobManagedMovementOverrideBeforeControl job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return default(JobHandle);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref JobManagedMovementOverrideBeforeControl job, EntityManager entityManager)
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

		public EntityManager __EntityManager;

		public void Execute(ManagedMovementOverrideBeforeControl managedOverride, Entity entity, ref LocalTransform localTransform, ref AgentCylinderShape shape, ref AgentMovementPlane movementPlane, ref DestinationPoint destination, ref MovementState movementState, ref MovementSettings movementSettings)
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
