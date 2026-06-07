using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.RVO;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Pathfinding.ECS.RVO
{
	[BurstCompile]
	[UpdateAfter(typeof(FollowerControlSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	public struct RVOSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		public struct JobCopyFromEntitiesToRVOSimulator : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentIndex> __Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<RVOAgent> __Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MovementControl> __Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle;

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
				public void Run(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobCopyFromEntitiesToRVOSimulator job, EntityManager entityManager)
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

			[NativeDisableParallelForRestriction]
			public SimulatorBurst.AgentData agentData;

			[ReadOnly]
			public SimulatorBurst.AgentOutputData agentOutputData;

			public MovementPlane movementPlaneMode;

			[ReadOnly]
			public ComponentLookup<AgentOffMeshLinkTraversal> agentOffMeshLinkTraversalLookup;

			public float dt;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(Entity entity, in LocalTransform transform, in AgentCylinderShape shape, in AgentMovementPlane movementPlane, in AgentIndex agentIndex, in RVOAgent controller, in MovementControl target)
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

		[BurstCompile]
		public struct JobCopyFromRVOSimulatorToEntities : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentIndex> __Pathfinding_ECS_RVO_AgentIndex_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<RVOAgent> __Pathfinding_ECS_RVO_RVOAgent_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<MovementControl> __Pathfinding_ECS_MovementControl_RO_ComponentTypeHandle;

					public ComponentTypeHandle<ResolvedMovement> __Pathfinding_ECS_ResolvedMovement_RW_ComponentTypeHandle;

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
				public void Run(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobCopyFromRVOSimulatorToEntities job, EntityManager entityManager)
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

			[ReadOnly]
			public NativeArray<AgentIndex> agentDataVersions;

			[ReadOnly]
			public RVOQuadtreeBurst quadtree;

			[ReadOnly]
			public SimulatorBurst.AgentOutputData agentOutputData;

			private const float MaximumCirclePackingDensity = 0.9069f;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in LocalTransform transform, in AgentCylinderShape shape, in AgentIndex agentIndex, in RVOAgent controller, in MovementControl control, ref ResolvedMovement resolved)
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

		private struct TypeHandle
		{
			public JobCopyFromEntitiesToRVOSimulator.InternalCompilerQueryAndHandleData __Pathfinding_ECS_RVO_RVOSystem_JobCopyFromEntitiesToRVOSimulator_WithDefaultQuery_JobEntityTypeHandle;

			public JobCopyFromRVOSimulatorToEntities.InternalCompilerQueryAndHandleData __Pathfinding_ECS_RVO_RVOSystem_JobCopyFromRVOSimulatorToEntities_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private GCHandle lastSimulator;

		private ComponentLookup<AgentOffMeshLinkTraversal> agentOffMeshLinkTraversalLookup;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_614662194_0;

		private EntityQuery __query_614662194_1;

		private EntityQuery __query_614662194_2;

		private EntityQuery __query_614662194_3;

		public void OnCreate(ref SystemState state)
		{
		}

		public void OnDestroy(ref SystemState state)
		{
		}

		public void OnUpdate(ref SystemState systemState)
		{
		}

		private void RemoveAllAgentsFromSimulation(ref SystemState systemState)
		{
		}

		private void AddAndRemoveAgentsFromSimulation(ref SystemState systemState, SimulatorBurst simulator)
		{
		}

		private void CopyFromEntitiesToRVOSimulator(ref SystemState systemState, SimulatorBurst simulator, float dt)
		{
		}

		private void CopyFromRVOSimulatorToEntities(ref SystemState systemState, SimulatorBurst simulator)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(JobCopyFromEntitiesToRVOSimulator job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(JobCopyFromRVOSimulatorToEntities job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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
