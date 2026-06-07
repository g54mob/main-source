using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Pathfinding.ECS
{
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[UpdateBefore(typeof(RepairPathSystem))]
	[UpdateBefore(typeof(TraverseOffMeshLinkSystem))]
	[BurstCompile]
	public struct SchedulePathSearchSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAbsent(new Type[] { typeof(ManagedAgentOffMeshLinkTraversal) })]
		[WithPresent(new Type[] { typeof(AgentShouldRecalculatePath) })]
		private struct JobCheckStaleness : IJobEntity, IJobEntityChunkBeginEnd, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<ManagedState> __Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle;

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
				public void Run(ref JobCheckStaleness job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobCheckStaleness job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobCheckStaleness job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobCheckStaleness job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobCheckStaleness job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobCheckStaleness job, EntityManager entityManager)
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

			public NativeBitArray isPathStale;

			private int index;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public EntityManager __EntityManager;

			public void Execute(ManagedState state)
			{
			}

			public bool OnChunkBegin(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				return false;
			}

			public void OnChunkEnd(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask, bool chunkWasExecuted)
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

			bool IJobEntityChunkBeginEnd.OnChunkBegin(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				return false;
			}

			void IJobEntityChunkBeginEnd.OnChunkEnd(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask, bool chunkWasExecuted)
			{
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
			}
		}

		[BurstCompile]
		[WithAbsent(new Type[] { typeof(ManagedAgentOffMeshLinkTraversal) })]
		[WithPresent(new Type[] { typeof(AgentShouldRecalculatePath) })]
		private struct JobShouldRecalculatePaths : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<AutoRepathPolicy> __Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<AgentCylinderShape> __Pathfinding_ECS_AgentCylinderShape_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<DestinationPoint> __Pathfinding_ECS_DestinationPoint_RO_ComponentTypeHandle;

					public ComponentTypeHandle<AgentShouldRecalculatePath> __Pathfinding_ECS_AgentShouldRecalculatePath_RW_ComponentTypeHandle;

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
				public void Run(ref JobShouldRecalculatePaths job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobShouldRecalculatePaths job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobShouldRecalculatePaths job, EntityManager entityManager)
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

			public float time;

			public NativeBitArray isPathStale;

			private int index;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(ref AutoRepathPolicy autoRepathPolicy, in LocalTransform transform, in AgentCylinderShape shape, in DestinationPoint destination, EnabledRefRW<AgentShouldRecalculatePath> shouldRecalculatePath)
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

		[WithAbsent(new Type[] { typeof(ManagedAgentOffMeshLinkTraversal) })]
		[WithAll(new Type[] { typeof(AgentShouldRecalculatePath) })]
		public struct JobRecalculatePaths : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<ManagedState> __Pathfinding_ECS_ManagedState_RW_ComponentTypeHandle;

					public ComponentTypeHandle<ManagedSettings> __Pathfinding_ECS_ManagedSettings_RW_ComponentTypeHandle;

					public ComponentTypeHandle<AutoRepathPolicy> __Pathfinding_ECS_AutoRepathPolicy_RW_ComponentTypeHandle;

					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

					public ComponentTypeHandle<DestinationPoint> __Pathfinding_ECS_DestinationPoint_RW_ComponentTypeHandle;

					public ComponentTypeHandle<AgentMovementPlane> __Pathfinding_ECS_AgentMovementPlane_RW_ComponentTypeHandle;

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
				public void Run(ref JobRecalculatePaths job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref JobRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref JobRecalculatePaths job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref JobRecalculatePaths job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref JobRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref JobRecalculatePaths job, EntityManager entityManager)
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

			public float time;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public EntityManager __EntityManager;

			public void Execute(ManagedState state, ManagedSettings settings, ref AutoRepathPolicy autoRepathPolicy, ref LocalTransform transform, ref DestinationPoint destination, ref AgentMovementPlane movementPlane)
			{
			}

			public static void MaybeRecalculatePath(ManagedState state, ManagedSettings settings, ref AutoRepathPolicy autoRepathPolicy, ref LocalTransform transform, ref DestinationPoint destination, ref AgentMovementPlane movementPlane, float time, bool wantsToRecalculatePath)
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
			public JobCheckStaleness.InternalCompilerQueryAndHandleData __Pathfinding_ECS_SchedulePathSearchSystem_JobCheckStaleness_WithDefaultQuery_JobEntityTypeHandle;

			public JobShouldRecalculatePaths.InternalCompilerQueryAndHandleData __Pathfinding_ECS_SchedulePathSearchSystem_JobShouldRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle;

			public JobRecalculatePaths.InternalCompilerQueryAndHandleData __Pathfinding_ECS_SchedulePathSearchSystem_JobRecalculatePaths_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_376638600_0;

		public void OnUpdate(ref SystemState systemState)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_0(JobCheckStaleness job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_1(JobShouldRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __ScheduleViaJobChunkExtension_2(JobRecalculatePaths job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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
