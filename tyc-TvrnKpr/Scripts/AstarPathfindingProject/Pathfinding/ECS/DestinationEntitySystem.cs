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
	[UpdateBefore(typeof(SchedulePathSearchSystem))]
	[BurstCompile]
	[RequireMatchingQueriesForUpdate]
	public struct DestinationEntitySystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		private struct UpdateDestinationJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ComponentTypeHandle<DestinationPoint> __Pathfinding_ECS_DestinationPoint_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<DestinationEntity> __Pathfinding_ECS_DestinationEntity_RO_ComponentTypeHandle;

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
				public void Run(ref UpdateDestinationJob job, EntityQuery query)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref UpdateDestinationJob job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref UpdateDestinationJob job, EntityQuery query, JobHandle dependency)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref UpdateDestinationJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref UpdateDestinationJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return default(JobHandle);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref UpdateDestinationJob job, EntityManager entityManager)
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
			public ComponentLookup<LocalToWorld> TransformLookup;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			public void Execute(ref DestinationPoint destPoint, in DestinationEntity destEntity)
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
			[ReadOnly]
			public ComponentLookup<LocalToWorld> __Unity_Transforms_LocalToWorld_RO_ComponentLookup;

			public UpdateDestinationJob.InternalCompilerQueryAndHandleData __Pathfinding_ECS_DestinationEntitySystem_UpdateDestinationJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void __codegen__OnUpdate_00001472_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00001472_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(IntPtr self, IntPtr state)
			{
			}
		}

		private TypeHandle __TypeHandle;

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(UpdateDestinationJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
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

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		public static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
		}
	}
}
