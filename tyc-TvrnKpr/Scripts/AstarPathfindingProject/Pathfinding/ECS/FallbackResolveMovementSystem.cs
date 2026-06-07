using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.ECS.RVO;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Pathfinding.ECS
{
	[BurstCompile]
	[UpdateAfter(typeof(FollowerControlSystem))]
	[UpdateAfter(typeof(RVOSystem))]
	[UpdateInGroup(typeof(AIMovementSystemGroup))]
	[RequireMatchingQueriesForUpdate]
	public struct FallbackResolveMovementSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(SimulateMovement) })]
		[WithOptions(EntityQueryOptions.FilterWriteGroup)]
		public struct CopyJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
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
				public void Run(ref CopyJob job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref CopyJob job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref CopyJob job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref CopyJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref CopyJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref CopyJob job, EntityManager entityManager)
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

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in MovementControl control, ref ResolvedMovement resolved)
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
		[WithAll(new Type[] { typeof(SimulateMovement) })]
		public struct CopyRotationJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
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
				public void Run(ref CopyRotationJob job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref CopyRotationJob job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref CopyRotationJob job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref CopyRotationJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref CopyRotationJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref CopyRotationJob job, EntityManager entityManager)
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

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(in MovementControl control, ref ResolvedMovement resolved)
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
			public CopyJob.InternalCompilerQueryAndHandleData __Pathfinding_ECS_FallbackResolveMovementSystem_CopyJob_WithDefaultQuery_JobEntityTypeHandle;

			public CopyRotationJob.InternalCompilerQueryAndHandleData __Pathfinding_ECS_FallbackResolveMovementSystem_CopyRotationJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		private TypeHandle __TypeHandle;

		public void OnUpdate(ref SystemState systemState)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(CopyJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			return default(JobHandle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(CopyRotationJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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
