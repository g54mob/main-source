using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using QFSW.QC;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;

[UpdateAfter(typeof(BeginSimulationEntityCommandBufferSystem))]
[UpdateBefore(typeof(GhostSpawnSystemGroup))]
[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[BurstCompile]
public struct ControlPredictionSwitchingSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct MoveToPredictionJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<GhostInstance>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref MoveToPredictionJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveToPredictionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveToPredictionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveToPredictionJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveToPredictionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveToPredictionJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeQueue<ConvertPredictionEntry>.ParallelWriter predictedQueue;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in GhostInstance ghostInstance)
		{
			if (ghostInstance.ghostType >= 0)
			{
				predictedQueue.Enqueue(new ConvertPredictionEntry
				{
					TargetEntity = entity,
					TransitionDurationSeconds = 0f
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct MoveToInterpolatedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<GhostInstance>().Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref MoveToInterpolatedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveToInterpolatedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveToInterpolatedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveToInterpolatedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveToInterpolatedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveToInterpolatedJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeQueue<ConvertPredictionEntry>.ParallelWriter interpolatedQueue;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in GhostInstance ghostInstance)
		{
			if (ghostInstance.ghostType >= 0)
			{
				interpolatedQueue.Enqueue(new ConvertPredictionEntry
				{
					TargetEntity = entity,
					TransitionDurationSeconds = 0f
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct MoveToPredictionByPushbackAndDeathJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByPushbackCD> __MoveToPredictedByPushbackCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByEntityDestroyedCD>();
					__MoveToPredictedByPushbackCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByPushbackCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByPushbackCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByEntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByPushbackCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref MoveToPredictionByPushbackAndDeathJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveToPredictionByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveToPredictionByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveToPredictionByPushbackAndDeathJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveToPredictionByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveToPredictionByPushbackAndDeathJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeQueue<ConvertPredictionEntry>.ParallelWriter predictedQueue;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup;

		public NetworkTick currentTick;

		public NetworkTick interpolationTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in GhostInstance ghostInstance, ref MoveToPredictedByEntityDestroyedCD moveToPredictedByEntityDestroyedCD, ref MoveToPredictedByPushbackCD moveToPredictedByPushbackCD)
		{
			if (ghostInstance.ghostType < 0)
			{
				return;
			}
			if (!entityDestroyedLookup.HasAndIsComponentEnabled(entity) && (!receivedPushbackLookup.TryGetComponent(entity, out var componentData) || !componentData.enabled) && (!moveToPredictedByEntityDestroyedCD.lastInteractionTick.IsValid || currentTick.TicksSince(moveToPredictedByEntityDestroyedCD.lastInteractionTick) > tickRate))
			{
				moveToPredictedByEntityDestroyedCD.lastInteractionTick = NetworkTick.Invalid;
				uint num = NetworkTimeUtilities.SecondsToTicks(0.1f, tickRate);
				if (!moveToPredictedByPushbackCD.lastInteractionTick.IsValid || interpolationTick.TicksSince(moveToPredictedByPushbackCD.lastInteractionTick) > num)
				{
					moveToPredictedByPushbackCD.lastInteractionTick = NetworkTick.Invalid;
					return;
				}
			}
			predictedQueue.Enqueue(new ConvertPredictionEntry
			{
				TargetEntity = entity,
				TransitionDurationSeconds = 0f
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByPushbackCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct MoveToInterpolatedByPushbackAndDeathJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByPushbackCD> __MoveToPredictedByPushbackCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByEntityDestroyedCD>();
					__MoveToPredictedByPushbackCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByPushbackCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByPushbackCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByEntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByPushbackCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref MoveToInterpolatedByPushbackAndDeathJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveToInterpolatedByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveToInterpolatedByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveToInterpolatedByPushbackAndDeathJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveToInterpolatedByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveToInterpolatedByPushbackAndDeathJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeQueue<ConvertPredictionEntry>.ParallelWriter interpolatedQueue;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<ReceivedPushbackCD> receivedPushbackLookup;

		public NetworkTick currentTick;

		public NetworkTick interpolationTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in GhostInstance ghostInstance, ref MoveToPredictedByEntityDestroyedCD moveToPredictedByEntityDestroyedCD, ref MoveToPredictedByPushbackCD moveToPredictedByPushbackCD)
		{
			if (ghostInstance.ghostType < 0 || entityDestroyedLookup.HasAndIsComponentEnabled(entity) || (moveToPredictedByEntityDestroyedCD.lastInteractionTick.IsValid && currentTick.TicksSince(moveToPredictedByEntityDestroyedCD.lastInteractionTick) <= tickRate) || (receivedPushbackLookup.TryGetComponent(entity, out var componentData) && componentData.enabled))
			{
				return;
			}
			uint num = NetworkTimeUtilities.SecondsToTicks(0.1f, tickRate);
			if (moveToPredictedByPushbackCD.lastInteractionTick.IsValid && interpolationTick.TicksSince(moveToPredictedByPushbackCD.lastInteractionTick) <= num)
			{
				return;
			}
			if (receivedPushbackLookup.TryGetComponent(entity, out var componentData2) && componentData2.pushbackStartTick.IsValid)
			{
				NetworkTick pushbackStartTick = componentData2.pushbackStartTick;
				pushbackStartTick.Add(num);
				if (interpolationTick.IsOlderThan(pushbackStartTick))
				{
					return;
				}
			}
			interpolatedQueue.Enqueue(new ConvertPredictionEntry
			{
				TargetEntity = entity,
				TransitionDurationSeconds = 0.1f
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByPushbackCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByPushbackCD>(nativeArrayPtr4, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct MoveToPredictionByMissingHealthAndCombatInteractionJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD> __MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD>();
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByEntityDestroyedCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByCombatOrInventoryInteractionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByEntityDestroyedCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref MoveToPredictionByMissingHealthAndCombatInteractionJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveToPredictionByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveToPredictionByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveToPredictionByMissingHealthAndCombatInteractionJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveToPredictionByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveToPredictionByMissingHealthAndCombatInteractionJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeQueue<ConvertPredictionEntry>.ParallelWriter predictedQueue;

		public NetworkTick currentTick;

		public int tickRate;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookUp;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in GhostInstance ghostInstance, in ObjectDataCD objectDataCD, ref MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD, ref MoveToPredictedByEntityDestroyedCD moveToPredictedByEntityDestroyedCD)
		{
			if (ghostInstance.ghostType < 0)
			{
				return;
			}
			if ((!healthLookup.TryGetComponent(entity, out var componentData) || componentData.HasFullHealth || tileLookUp.HasComponent(entity)) && (!moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick.IsValid || currentTick.TicksSince(moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick) > tickRate))
			{
				moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick = NetworkTick.Invalid;
				if (!entityDestroyedLookup.HasAndIsComponentEnabled(entity) && (!moveToPredictedByEntityDestroyedCD.lastInteractionTick.IsValid || currentTick.TicksSince(moveToPredictedByEntityDestroyedCD.lastInteractionTick) > tickRate))
				{
					moveToPredictedByEntityDestroyedCD.lastInteractionTick = NetworkTick.Invalid;
					return;
				}
			}
			predictedQueue.Enqueue(new ConvertPredictionEntry
			{
				TargetEntity = entity,
				TransitionDurationSeconds = 0f
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct MoveToInterpolatedByMissingHealthAndCombatInteractionJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD> __MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD>();
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByEntityDestroyedCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByCombatOrInventoryInteractionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByEntityDestroyedCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref MoveToInterpolatedByMissingHealthAndCombatInteractionJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveToInterpolatedByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveToInterpolatedByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveToInterpolatedByMissingHealthAndCombatInteractionJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveToInterpolatedByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveToInterpolatedByMissingHealthAndCombatInteractionJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		public NativeQueue<ConvertPredictionEntry>.ParallelWriter interpolatedQueue;

		public NetworkTick currentTick;

		public int tickRate;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookUp;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookUp;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in GhostInstance ghostInstance, in ObjectDataCD objectDataCD, ref MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD, ref MoveToPredictedByEntityDestroyedCD moveToPredictedByEntityDestroyedCD)
		{
			if (ghostInstance.ghostType >= 0 && (!healthLookUp.TryGetComponent(entity, out var componentData) || componentData.HasFullHealth) && !entityDestroyedLookup.HasAndIsComponentEnabled(entity) && (!moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick.IsValid || currentTick.TicksSince(moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick) > tickRate) && (!moveToPredictedByEntityDestroyedCD.lastInteractionTick.IsValid || currentTick.TicksSince(moveToPredictedByEntityDestroyedCD.lastInteractionTick) > tickRate))
			{
				moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick = NetworkTick.Invalid;
				moveToPredictedByEntityDestroyedCD.lastInteractionTick = NetworkTick.Invalid;
				interpolatedQueue.Enqueue(new ConvertPredictionEntry
				{
					TargetEntity = entity,
					TransitionDurationSeconds = 0f
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr5, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct PredictedByPvPAndRTTKey
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct PredictOtherPlayersKey
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct PredictEnemiesKey
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct PredictPetsKey
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct PredictOtherObjectsKey
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct StartInterpolateByHighRTTThresholdKey
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct StopInterpolateByHighRTTThresholdKey
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_429919307_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<GhostInstance, FactionCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<GhostInstance, FactionCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<GhostInstance>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<FactionCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<GhostInstance> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<FactionCD> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<FactionCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<GhostInstance, FactionCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<GhostInstance, FactionCD> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<GhostInstance>();
			state.EntityManager.CompleteDependencyBeforeRO<FactionCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_429919307_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr Entity_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public QueryEnumerableWithEntity<GhostInstance, FactionCD> Get(int index)
			{
				return new QueryEnumerableWithEntity<GhostInstance, FactionCD>(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<GhostInstance>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<FactionCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(Entity_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<GhostInstance> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<FactionCD> item2_ComponentTypeHandle_RO;

			private EntityTypeHandle Entity_TypeHandle;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<FactionCD>(isReadOnly: true);
				Entity_TypeHandle = systemState.GetEntityTypeHandle();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				Entity_TypeHandle.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					Entity_IntPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(archetypeChunk, Entity_TypeHandle)
				};
			}
		}

		public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<GhostInstance, FactionCD>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public QueryEnumerableWithEntity<GhostInstance, FactionCD> Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<GhostInstance>();
			state.EntityManager.CompleteDependencyBeforeRO<FactionCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_429919307_0.TypeHandle __IFE_429919307_0_TypeHandle;

		public IFE_429919307_1.TypeHandle __IFE_429919307_1_TypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ReceivedPushbackCD> __ReceivedPushbackCD_RO_ComponentLookup;

		public MoveToPredictionByPushbackAndDeathJob.InternalCompilerQueryAndHandleData __ControlPredictionSwitchingSystem_MoveToPredictionByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle;

		public MoveToInterpolatedByPushbackAndDeathJob.InternalCompilerQueryAndHandleData __ControlPredictionSwitchingSystem_MoveToInterpolatedByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle;

		public MoveToPredictionByMissingHealthAndCombatInteractionJob.InternalCompilerQueryAndHandleData __ControlPredictionSwitchingSystem_MoveToPredictionByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle;

		public MoveToInterpolatedByMissingHealthAndCombatInteractionJob.InternalCompilerQueryAndHandleData __ControlPredictionSwitchingSystem_MoveToInterpolatedByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<GhostOwnerIsLocal> __Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup;

		public MoveToPredictionJob.InternalCompilerQueryAndHandleData __ControlPredictionSwitchingSystem_MoveToPredictionJob_WithoutDefaultQuery_JobEntityTypeHandle;

		public MoveToInterpolatedJob.InternalCompilerQueryAndHandleData __ControlPredictionSwitchingSystem_MoveToInterpolatedJob_WithoutDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_429919307_0_TypeHandle = new IFE_429919307_0.TypeHandle(ref state);
			__IFE_429919307_1_TypeHandle = new IFE_429919307_1.TypeHandle(ref state);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
			__ReceivedPushbackCD_RO_ComponentLookup = state.GetComponentLookup<ReceivedPushbackCD>(isReadOnly: true);
			__ControlPredictionSwitchingSystem_MoveToPredictionByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__ControlPredictionSwitchingSystem_MoveToInterpolatedByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__ControlPredictionSwitchingSystem_MoveToPredictionByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__ControlPredictionSwitchingSystem_MoveToInterpolatedByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup = state.GetComponentLookup<GhostOwnerIsLocal>(isReadOnly: true);
			__ControlPredictionSwitchingSystem_MoveToPredictionJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__ControlPredictionSwitchingSystem_MoveToInterpolatedJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000055BE_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000055BE_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000055BE_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000055BF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000055BF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000055BF_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	private static readonly SharedStatic<bool> _predictedPlayersByPvPAndRTT = SharedStatic<bool>.GetOrCreateUnsafe(0u, -6520124305451701686L, 0L);

	private static readonly SharedStatic<bool> _predictOtherPlayers = SharedStatic<bool>.GetOrCreateUnsafe(0u, 5308683677583910379L, 0L);

	private static readonly SharedStatic<bool> _predictEnemies = SharedStatic<bool>.GetOrCreateUnsafe(0u, -8319675195105955165L, 0L);

	private static readonly SharedStatic<bool> _predictPets = SharedStatic<bool>.GetOrCreateUnsafe(0u, 8592453045617615229L, 0L);

	private static readonly SharedStatic<bool> _predictOtherObjects = SharedStatic<bool>.GetOrCreateUnsafe(0u, -4801472137985260595L, 0L);

	private static readonly SharedStatic<float> _startInterpolateByHighRTTThreshold = SharedStatic<float>.GetOrCreateUnsafe(0u, -645810711545013171L, 0L);

	private static readonly SharedStatic<float> _stopInterpolateByHighRTTThreshold = SharedStatic<float>.GetOrCreateUnsafe(0u, 1513076067445768573L, 0L);

	private bool _lastInterpolationByHighRTTState;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_429919307_0;

	private EntityQuery __query_429919307_1;

	private EntityQuery __query_429919307_2;

	private EntityQuery __query_429919307_3;

	private EntityQuery __query_429919307_4;

	private EntityQuery __query_429919307_5;

	private EntityQuery __query_429919307_6;

	private EntityQuery __query_429919307_7;

	private EntityQuery __query_429919307_8;

	private EntityQuery __query_429919307_9;

	private EntityQuery __query_429919307_10;

	private EntityQuery __query_429919307_11;

	private EntityQuery __query_429919307_12;

	private EntityQuery __query_429919307_13;

	private static void RemoveSingletonFromWorld<T>(World world)
	{
		EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(T));
		world.EntityManager.DestroyEntity(entityQuery);
		entityQuery.Dispose();
	}

	private static void AddSingletonToWorld<T>(World world)
	{
		EntityQuery entityQuery = world.EntityManager.CreateEntityQuery(typeof(T));
		if (entityQuery.IsEmpty)
		{
			world.EntityManager.CreateEntity(typeof(T));
		}
		entityQuery.Dispose();
	}

	[Command("setOtherPlayersPredicted", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetOtherPlayersPredicted(bool value)
	{
		_predictOtherPlayers.Data = value;
	}

	[Command("setEnemiesPredicted", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetEnemiesPredicted(bool value)
	{
		_predictEnemies.Data = value;
	}

	[Command("setPetsPredicted", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetPetsPredicted(bool value)
	{
		_predictPets.Data = value;
	}

	[Command("setOtherObjectsPredicted", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetOtherObjectsPredicted(bool value)
	{
		_predictOtherObjects.Data = value;
		_predictedPlayersByPvPAndRTT.Data = false;
	}

	[Command("setOtherPlayersPredictedByPvPAndRTT", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetOtherPlayersPredictedByPvPAndRTT(bool value)
	{
		_predictedPlayersByPvPAndRTT.Data = value;
	}

	[Command("setStartInterpolateByHighRTTThreshold", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetInterpolateByHighRTTThresholdStartStop(float startRTT, float stopRTT)
	{
		_startInterpolateByHighRTTThreshold.Data = startRTT;
		_stopInterpolateByHighRTTThreshold.Data = stopRTT;
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_predictedPlayersByPvPAndRTT.Data = true;
		_predictOtherPlayers.Data = true;
		_predictEnemies.Data = false;
		_predictPets.Data = false;
		_predictOtherObjects.Data = false;
		_startInterpolateByHighRTTThreshold.Data = 200f;
		_stopInterpolateByHighRTTThreshold.Data = _startInterpolateByHighRTTThreshold.Data - 25f;
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<GhostPredictionSwitchingQueues>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		GhostPredictionSwitchingQueues valueRW = __query_429919307_9.GetSingletonRW<GhostPredictionSwitchingQueues>().ValueRW;
		NativeQueue<ConvertPredictionEntry>.ParallelWriter convertToInterpolatedQueue = valueRW.ConvertToInterpolatedQueue;
		NativeQueue<ConvertPredictionEntry>.ParallelWriter convertToPredictedQueue = valueRW.ConvertToPredictedQueue;
		bool data = _predictEnemies.Data;
		bool data2 = _predictPets.Data;
		ComponentLookup<EntityDestroyedCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state);
		ComponentLookup<HealthCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state);
		ComponentLookup<TileCD> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state);
		state.Dependency.Complete();
		UpdateEnemiesAndCrittersPredictionState(ref state, convertToInterpolatedQueue, convertToPredictedQueue, data, componentLookup);
		UpdatePetsPredictionState(ref state, convertToInterpolatedQueue, convertToPredictedQueue, data2);
		UpdateObjectAndMerchantPredictionState(ref state, convertToInterpolatedQueue, convertToPredictedQueue, componentLookup2, componentLookup, componentLookup3);
		UpdatePlayerPredictionState(ref state, convertToInterpolatedQueue, convertToPredictedQueue, _predictedPlayersByPvPAndRTT.Data, _predictOtherPlayers.Data, _startInterpolateByHighRTTThreshold.Data, _stopInterpolateByHighRTTThreshold.Data, ref _lastInterpolationByHighRTTState);
	}

	private void UpdateEnemiesAndCrittersPredictionState(ref SystemState state, NativeQueue<ConvertPredictionEntry>.ParallelWriter interpolatedQueue, NativeQueue<ConvertPredictionEntry>.ParallelWriter predictedQueue, bool predictEnemies, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup)
	{
		__query_429919307_10.TryGetSingleton<NetworkTime>(out var value);
		__query_429919307_11.TryGetSingleton<ClientServerTickRate>(out var value2);
		__ScheduleViaJobChunkExtension_0(new MoveToPredictionByPushbackAndDeathJob
		{
			predictedQueue = predictedQueue,
			entityDestroyedLookup = entityDestroyedLookup,
			receivedPushbackLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ReceivedPushbackCD_RO_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			interpolationTick = value.InterpolationTick,
			tickRate = (uint)value2.SimulationTickRate
		}, __query_429919307_2, state.Dependency, ref state, hasUserDefinedQuery: true);
		__ScheduleViaJobChunkExtension_1(new MoveToInterpolatedByPushbackAndDeathJob
		{
			interpolatedQueue = interpolatedQueue,
			entityDestroyedLookup = entityDestroyedLookup,
			receivedPushbackLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ReceivedPushbackCD_RO_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			interpolationTick = value.InterpolationTick,
			tickRate = (uint)value2.SimulationTickRate
		}, __query_429919307_3, state.Dependency, ref state, hasUserDefinedQuery: true);
	}

	private void UpdatePetsPredictionState(ref SystemState state, NativeQueue<ConvertPredictionEntry>.ParallelWriter interpolatedQueue, NativeQueue<ConvertPredictionEntry>.ParallelWriter predictedQueue, bool predictPets)
	{
		if (predictPets)
		{
			__ScheduleViaJobChunkExtension_4(new MoveToPredictionJob
			{
				predictedQueue = predictedQueue
			}, __query_429919307_4, state.Dependency, ref state, hasUserDefinedQuery: true);
		}
		else
		{
			__ScheduleViaJobChunkExtension_5(new MoveToInterpolatedJob
			{
				interpolatedQueue = interpolatedQueue
			}, __query_429919307_5, state.Dependency, ref state, hasUserDefinedQuery: true);
		}
	}

	private void UpdateObjectAndMerchantPredictionState(ref SystemState state, NativeQueue<ConvertPredictionEntry>.ParallelWriter interpolatedQueue, NativeQueue<ConvertPredictionEntry>.ParallelWriter predictedQueue, ComponentLookup<HealthCD> healthLookup, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ComponentLookup<TileCD> tileLookup)
	{
		__query_429919307_10.TryGetSingleton<NetworkTime>(out var value);
		__query_429919307_11.TryGetSingleton<ClientServerTickRate>(out var value2);
		__ScheduleViaJobChunkExtension_2(new MoveToPredictionByMissingHealthAndCombatInteractionJob
		{
			predictedQueue = predictedQueue,
			currentTick = value.ServerTick,
			tickRate = value2.SimulationTickRate,
			healthLookup = healthLookup,
			entityDestroyedLookup = entityDestroyedLookup,
			tileLookUp = tileLookup
		}, __query_429919307_6, state.Dependency, ref state, hasUserDefinedQuery: true);
		__ScheduleViaJobChunkExtension_3(new MoveToInterpolatedByMissingHealthAndCombatInteractionJob
		{
			interpolatedQueue = interpolatedQueue,
			currentTick = value.ServerTick,
			tickRate = value2.SimulationTickRate,
			entityDestroyedLookup = entityDestroyedLookup,
			healthLookUp = healthLookup,
			tileLookUp = tileLookup
		}, __query_429919307_7, state.Dependency, ref state, hasUserDefinedQuery: true);
	}

	private void UpdatePlayerPredictionState(ref SystemState state, NativeQueue<ConvertPredictionEntry>.ParallelWriter interpolatedQueue, NativeQueue<ConvertPredictionEntry>.ParallelWriter predictedQueue, bool predictedByPvPAndRTT, bool predictOtherPlayers, float startInterpolateByHighRTTThreshold, float stopInterpolateByHighRTTThreshold, ref bool lastInterpolationByHighRTTState)
	{
		__query_429919307_12.TryGetSingleton<WorldInfoCD>(out var value);
		EntityQuery _query_429919307_ = __query_429919307_8;
		NativeArray<FactionCD> nativeArray = _query_429919307_.ToComponentDataArray<FactionCD>(state.WorldUpdateAllocator);
		FactionCD item;
		FactionCD factionCD;
		if (nativeArray.Length <= 0)
		{
			item = default(FactionCD);
			factionCD = item;
		}
		else
		{
			factionCD = nativeArray[0];
		}
		FactionCD localPlayerFactionCD = factionCD;
		__query_429919307_13.TryGetSingleton<NetworkSnapshotAck>(out var value2);
		float estimatedRTT = value2.EstimatedRTT;
		bool interpolateByHighRTT = (lastInterpolationByHighRTTState = (lastInterpolationByHighRTTState ? (estimatedRTT > stopInterpolateByHighRTTThreshold) : (estimatedRTT > startInterpolateByHighRTTThreshold)));
		GhostInstance item2;
		Entity entity;
		foreach (QueryEnumerableWithEntity<GhostInstance, FactionCD> item3 in IFE_429919307_0.Query(__query_429919307_0, __TypeHandle.__IFE_429919307_0_TypeHandle, ref state))
		{
			item3.Deconstruct(out item2, out item, out entity);
			GhostInstance ghostInstance = item2;
			FactionCD factionCD2 = item;
			Entity entity2 = entity;
			if (ghostInstance.ghostType >= 0 && (InternalCompilerInterface.IsComponentEnabledAfterCompletingDependency(ref __TypeHandle.__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup, ref state, entity2) || ((!predictedByPvPAndRTT || ShouldPlayerBePredicted(factionCD2, localPlayerFactionCD, value, interpolateByHighRTT)) && (predictedByPvPAndRTT || predictOtherPlayers))))
			{
				predictedQueue.Enqueue(new ConvertPredictionEntry
				{
					TargetEntity = entity2,
					TransitionDurationSeconds = 0f
				});
			}
		}
		foreach (QueryEnumerableWithEntity<GhostInstance, FactionCD> item4 in IFE_429919307_1.Query(__query_429919307_1, __TypeHandle.__IFE_429919307_1_TypeHandle, ref state))
		{
			item4.Deconstruct(out item2, out item, out entity);
			GhostInstance ghostInstance2 = item2;
			FactionCD factionCD3 = item;
			Entity targetEntity = entity;
			if (ghostInstance2.ghostType >= 0 && (!predictedByPvPAndRTT || !ShouldPlayerBePredicted(factionCD3, localPlayerFactionCD, value, interpolateByHighRTT)) && !(!predictedByPvPAndRTT && predictOtherPlayers))
			{
				interpolatedQueue.Enqueue(new ConvertPredictionEntry
				{
					TargetEntity = targetEntity,
					TransitionDurationSeconds = 0f
				});
			}
		}
	}

	private static bool ShouldPlayerBePredicted(FactionCD factionCD, FactionCD localPlayerFactionCD, WorldInfoCD worldInfoCD, bool interpolateByHighRTT)
	{
		if (!interpolateByHighRTT)
		{
			return localPlayerFactionCD.CanAttack(factionCD, worldInfoCD);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_0(MoveToPredictionByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_1(MoveToInterpolatedByPushbackAndDeathJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByPushbackAndDeathJob_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_2(MoveToPredictionByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_3(MoveToInterpolatedByMissingHealthAndCombatInteractionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedByMissingHealthAndCombatInteractionJob_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_4(MoveToPredictionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToPredictionJob_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_5(MoveToInterpolatedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__ControlPredictionSwitchingSystem_MoveToInterpolatedJob_WithoutDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PredictedGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<SwitchPredictionSmoothing>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<FactionCD>();
		__query_429919307_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<SwitchPredictionSmoothing>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PredictedGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<FactionCD>();
		__query_429919307_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance, MoveToPredictedByEntityDestroyedCD, MoveToPredictedByPushbackCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<EnemyCD, ProjectileCD, CritterCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PredictedGhost, SwitchPredictionSmoothing, BossCD>();
		__query_429919307_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance, PredictedGhost, MoveToPredictedByEntityDestroyedCD, MoveToPredictedByPushbackCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<EnemyCD, CritterCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<SwitchPredictionSmoothing, BossCD>();
		__query_429919307_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance, PetCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PredictedGhost, SwitchPredictionSmoothing>();
		__query_429919307_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance, PetCD, PredictedGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<SwitchPredictionSmoothing>();
		__query_429919307_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance, ObjectDataCD, MoveToPredictedByCombatOrInventoryInteractionCD, MoveToPredictedByEntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PredictedGhost, SwitchPredictionSmoothing>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PhysicsVelocity, PetCD, EnemyCD, MinionOrbitCD, ExplosionCD, ProjectileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<MortarProjectileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.AddAdditionalQuery();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance, ObjectDataCD, MoveToPredictedByCombatOrInventoryInteractionCD, MoveToPredictedByEntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<MerchantCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PredictedGhost, SwitchPredictionSmoothing>();
		__query_429919307_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostInstance, ObjectDataCD, PredictedGhost, MoveToPredictedByCombatOrInventoryInteractionCD, MoveToPredictedByEntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<SwitchPredictionSmoothing>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PhysicsVelocity, PetCD, EnemyCD, MinionOrbitCD, ExplosionCD, ProjectileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<MortarProjectileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.AddAdditionalQuery();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance, ObjectDataCD, PredictedGhost, MoveToPredictedByCombatOrInventoryInteractionCD, MoveToPredictedByEntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<MerchantCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<SwitchPredictionSmoothing>();
		__query_429919307_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost, GhostOwnerIsLocal, FactionCD>();
		__query_429919307_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<GhostPredictionSwitchingQueues>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_429919307_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_429919307_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_429919307_11 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_429919307_12 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkSnapshotAck>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_429919307_13 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__OnCreate_000055BE_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000055BF_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ControlPredictionSwitchingSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ControlPredictionSwitchingSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ControlPredictionSwitchingSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
