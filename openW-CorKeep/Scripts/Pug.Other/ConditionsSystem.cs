using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(ConditionEffectsUpdateSystemGroup), OrderLast = true)]
public struct ConditionsSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	[WithChangeFilter(new Type[] { typeof(NewConditionsBuffer) })]
	public struct ProcessNewConditionsBufferJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public BufferTypeHandle<NewConditionsBuffer> __NewConditionsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__NewConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<NewConditionsBuffer>();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__NewConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NewConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(NewConditionsBuffer))
				});
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
			public void Run(ref ProcessNewConditionsBufferJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ProcessNewConditionsBufferJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ProcessNewConditionsBufferJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ProcessNewConditionsBufferJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ProcessNewConditionsBufferJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ProcessNewConditionsBufferJob job, EntityManager entityManager)
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

		public ConditionsTableCD ConditionsTable;

		public NetworkTick CurrentTick;

		public uint TickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		public void Execute(ref DynamicBuffer<NewConditionsBuffer> newConditionsBuffer, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer)
		{
			foreach (NewConditionsBuffer item in newConditionsBuffer)
			{
				EntityUtility.AddOrRefreshCondition(item.conditionData, conditionsBuffer, ConditionsTable, CurrentTick, TickRate, summarizedConditionsBuffer);
			}
			newConditionsBuffer.Clear();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			BufferAccessor<NewConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__NewConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					DynamicBuffer<NewConditionsBuffer> newConditionsBuffer = bufferAccessor[i];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor2[i];
					Execute(ref newConditionsBuffer, ref conditionsBuffer, bufferAccessor3[i]);
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
						DynamicBuffer<NewConditionsBuffer> newConditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(ref newConditionsBuffer2, ref conditionsBuffer2, bufferAccessor3[nextRangeBegin]);
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
					DynamicBuffer<NewConditionsBuffer> newConditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor2[j];
					Execute(ref newConditionsBuffer3, ref conditionsBuffer3, bufferAccessor3[j]);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					DynamicBuffer<NewConditionsBuffer> newConditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor2[k];
					Execute(ref newConditionsBuffer4, ref conditionsBuffer4, bufferAccessor3[k]);
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
	[WithAll(new Type[] { typeof(Simulate) })]
	[WithChangeFilter(new Type[] { typeof(RemoveConditionsBuffer) })]
	public struct MarkConditionsToBeRemovedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public BufferTypeHandle<RemoveConditionsBuffer> __RemoveConditionsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__RemoveConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<RemoveConditionsBuffer>();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__RemoveConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RemoveConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(RemoveConditionsBuffer))
				});
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
			public void Run(ref MarkConditionsToBeRemovedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MarkConditionsToBeRemovedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MarkConditionsToBeRemovedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MarkConditionsToBeRemovedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MarkConditionsToBeRemovedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MarkConditionsToBeRemovedJob job, EntityManager entityManager)
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

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		public void Execute(ref DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer)
		{
			foreach (RemoveConditionsBuffer item in removeConditionsBuffer)
			{
				for (int i = 0; i < conditionsBuffer.Length; i++)
				{
					if (conditionsBuffer[i].condition.conditionData.conditionID == item.conditionId)
					{
						ConditionsBuffer value = conditionsBuffer[i];
						value.condition.toBeRemoved = true;
						conditionsBuffer[i] = value;
						break;
					}
				}
			}
			removeConditionsBuffer.Clear();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			BufferAccessor<RemoveConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__RemoveConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer = bufferAccessor[i];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor2[i];
					Execute(ref removeConditionsBuffer, ref conditionsBuffer);
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
						DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(ref removeConditionsBuffer2, ref conditionsBuffer2);
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
					DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor2[j];
					Execute(ref removeConditionsBuffer3, ref conditionsBuffer3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					DynamicBuffer<RemoveConditionsBuffer> removeConditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor2[k];
					Execute(ref removeConditionsBuffer4, ref conditionsBuffer4);
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
	public struct DamageTakenJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<LastDamageTakenTimeCD> __LastDamageTakenTimeCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__LastDamageTakenTimeCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LastDamageTakenTimeCD>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__LastDamageTakenTimeCD_RO_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LastDamageTakenTimeCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
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
			public void Run(ref DamageTakenJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DamageTakenJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DamageTakenJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DamageTakenJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DamageTakenJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DamageTakenJob job, EntityManager entityManager)
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

		public NetworkTick CurrentTick;

		public uint TickRate;

		public ConditionsTableCD ConditionsTable;

		private const float TimeSinceLastDamageTakenToLooseBuff = 5f;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		public void Execute(in LastDamageTakenTimeCD lastDamageTakenTimeCD, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffers, ref DynamicBuffer<ConditionsBuffer> conditionsBuffers)
		{
			if (summarizedConditionsBuffers[293].value == 0 || (lastDamageTakenTimeCD.lastDamageTick.IsValid && NetworkTimeUtilities.TimeBetweenTicksInSeconds(lastDamageTakenTimeCD.lastDamageTick, CurrentTick, TickRate) < 5f))
			{
				if (summarizedConditionsBuffers[294].value != 0)
				{
					EntityUtility.RemoveCondition(ConditionID.MeleeDamageAsLongAsNotTakenDamage, conditionsBuffers);
				}
			}
			else if (summarizedConditionsBuffers[294].value == 0)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.MeleeDamageAsLongAsNotTakenDamage,
					value = summarizedConditionsBuffers[293].value,
					duration = 0f
				}, conditionsBuffers, ConditionsTable, CurrentTick, TickRate, summarizedConditionsBuffers);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__LastDamageTakenTimeCD_RO_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref LastDamageTakenTimeCD lastDamageTakenTimeCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr, i);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffers = bufferAccessor[i];
					DynamicBuffer<ConditionsBuffer> conditionsBuffers = bufferAccessor2[i];
					Execute(in lastDamageTakenTimeCD, in summarizedConditionsBuffers, ref conditionsBuffers);
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
						ref LastDamageTakenTimeCD lastDamageTakenTimeCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr, nextRangeBegin);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffers2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<ConditionsBuffer> conditionsBuffers2 = bufferAccessor2[nextRangeBegin];
						Execute(in lastDamageTakenTimeCD2, in summarizedConditionsBuffers2, ref conditionsBuffers2);
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
					ref LastDamageTakenTimeCD lastDamageTakenTimeCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr, j);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffers3 = bufferAccessor[j];
					DynamicBuffer<ConditionsBuffer> conditionsBuffers3 = bufferAccessor2[j];
					Execute(in lastDamageTakenTimeCD3, in summarizedConditionsBuffers3, ref conditionsBuffers3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref LastDamageTakenTimeCD lastDamageTakenTimeCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr, k);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffers4 = bufferAccessor[k];
					DynamicBuffer<ConditionsBuffer> conditionsBuffers4 = bufferAccessor2[k];
					Execute(in lastDamageTakenTimeCD4, in summarizedConditionsBuffers4, ref conditionsBuffers4);
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

	private struct ConditionToRemove : IComparable<ConditionToRemove>
	{
		public Entity Entity;

		public int ConditionIndex;

		public int CompareTo(ConditionToRemove other)
		{
			return other.ConditionIndex.CompareTo(ConditionIndex);
		}
	}

	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(Simulate),
		typeof(ConditionsBuffer)
	})]
	[WithChangeFilter(new Type[] { typeof(HealthCD) })]
	private struct RemoveConditionsFromDeadEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ConditionsBuffer>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[1]
				{
					new ComponentType(typeof(HealthCD))
				});
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
			public void Run(ref RemoveConditionsFromDeadEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RemoveConditionsFromDeadEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RemoveConditionsFromDeadEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RemoveConditionsFromDeadEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RemoveConditionsFromDeadEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RemoveConditionsFromDeadEntitiesJob job, EntityManager entityManager)
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

		public BufferLookup<ConditionsBuffer> ConditionsBufferLookup;

		public BlobAssetReference<ConditionsTableBlob> ConditionsTable;

		public NetworkTick CurrentTick;

		public uint TickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		public void Execute(Entity entity, in HealthCD health)
		{
			if (health.health > 0)
			{
				return;
			}
			DynamicBuffer<ConditionsBuffer> dynamicBuffer = ConditionsBufferLookup[entity];
			for (int num = dynamicBuffer.Length - 1; num >= 0; num--)
			{
				ref ConditionsBuffer reference = ref dynamicBuffer.ElementAt(num);
				ConditionID conditionID = reference.condition.conditionData.conditionID;
				bool isPermanent = ConditionsTable.Value.infos[(int)conditionID].isPermanent;
				NetworkTick removeTick = reference.condition.removeTick;
				int num2 = (removeTick.IsValid ? removeTick.TicksSince(CurrentTick) : 0);
				uint tickRate = TickRate;
				if (!isPermanent && num2 > tickRate && reference.condition.conditionData.duration > 0f)
				{
					reference.condition.removeTick = CurrentTick;
					reference.condition.removeTick.Add(tickRate);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, k));
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
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct FindConditionsToRemoveAndUpdateTimerJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<ConditionTickTimerBuffer> __ConditionTickTimerBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
					__ConditionTickTimerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionTickTimerBuffer>();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__ConditionTickTimerBuffer_RW_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionTickTimerBuffer>();
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
			public void Run(ref FindConditionsToRemoveAndUpdateTimerJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FindConditionsToRemoveAndUpdateTimerJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FindConditionsToRemoveAndUpdateTimerJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FindConditionsToRemoveAndUpdateTimerJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FindConditionsToRemoveAndUpdateTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FindConditionsToRemoveAndUpdateTimerJob job, EntityManager entityManager)
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

		public ComponentLookup<BurningConditionCD> BurningConditionLookup;

		public ComponentLookup<AffectedBySlipperyMovementConditionCD> AffectedBySlipperyMovementConditionLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> PhysicsVelocityLookup;

		public ConditionsTableCD ConditionsTable;

		public NetworkTick CurrentTick;

		public uint TickRate;

		public NativeList<ConditionToRemove> ConditionsToRemove;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[BurstCompile]
		public void Execute(Entity entity, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, ref DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer)
		{
			for (int num = conditionsBuffer.Length - 1; num >= 0; num--)
			{
				ConditionsBuffer conditionsBuffer2 = conditionsBuffer[num];
				ConditionID conditionID = conditionsBuffer2.condition.conditionData.conditionID;
				bool isPermanent = ConditionsTable.Value.Value.infos[(int)conditionID].isPermanent;
				NetworkTick removeTick = conditionsBuffer2.condition.removeTick;
				int num2 = (removeTick.IsValid ? removeTick.TicksSince(CurrentTick) : 0);
				bool flag = !isPermanent && !float.IsInfinity(conditionsBuffer2.condition.conditionData.duration) && conditionsBuffer2.condition.conditionData.duration > 0f && num2 <= 0;
				bool toBeRemoved = conditionsBuffer2.condition.toBeRemoved;
				bool flag2 = EntityUtility.ShouldBeRemovedByActiveEffect(conditionID, in summarizedConditionEffectsBuffer);
				bool flag3 = flag || toBeRemoved || flag2;
				switch (conditionID)
				{
				case ConditionID.Burning:
					if (BurningConditionLookup.HasComponent(entity))
					{
						bool flag5 = BurningConditionLookup.IsComponentEnabled(entity);
						if (flag5 && flag3)
						{
							BurningConditionLookup.SetComponentEnabled(entity, value: false);
							ConditionTickTimerUtilities.RemoveTickTimer(conditionTickTimerBuffer, ConditionID.Burning);
							EntityUtility.OnBurningRemoved(ref conditionsBuffer, in summarizedConditionsBuffer);
						}
						else if (!flag5)
						{
							BurningConditionLookup.SetComponentEnabled(entity, value: true);
							ConditionTickTimerUtilities.GetOrCreateTickTimer(conditionTickTimerBuffer, ConditionID.Burning);
							EntityUtility.OnBurningApplied(ref conditionsBuffer, in summarizedConditionsBuffer, ConditionsTable, CurrentTick, TickRate);
						}
					}
					break;
				case ConditionID.SlipperyMovement:
				case ConditionID.SlipperyMovementFromGround:
					if (AffectedBySlipperyMovementConditionLookup.HasComponent(entity))
					{
						bool flag4 = AffectedBySlipperyMovementConditionLookup.HasComponent(entity);
						if (flag4 && flag3)
						{
							AffectedBySlipperyMovementConditionLookup.SetComponentEnabled(entity, value: false);
						}
						else if (!flag4)
						{
							AffectedBySlipperyMovementConditionLookup.SetComponentEnabled(entity, value: true);
							AffectedBySlipperyMovementConditionLookup[entity] = new AffectedBySlipperyMovementConditionCD
							{
								previousVelocity = (PhysicsVelocityLookup.TryGetComponent(entity, out var componentData) ? componentData.Linear : float3.zero)
							};
						}
					}
					break;
				case ConditionID.SequenceExplosionTotalMaxExplosions:
					if (flag && !toBeRemoved)
					{
						flag3 = EntityUtility.RemoveStackAndRefreshCondition(num, conditionsBuffer2.condition.conditionData, conditionsBuffer, summarizedConditionsBuffer, 5f, CurrentTick, TickRate) <= 0;
					}
					break;
				}
				if (flag3)
				{
					ref NativeList<ConditionToRemove> conditionsToRemove = ref ConditionsToRemove;
					ConditionToRemove value = new ConditionToRemove
					{
						Entity = entity,
						ConditionIndex = num
					};
					conditionsToRemove.Add(in value);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<ConditionTickTimerBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionTickTimerBuffer_RW_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor[i];
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer = bufferAccessor2[i];
					Execute(entity, ref conditionsBuffer, ref conditionTickTimerBuffer, bufferAccessor3[i], bufferAccessor4[i]);
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
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref conditionsBuffer2, ref conditionTickTimerBuffer2, bufferAccessor3[nextRangeBegin], bufferAccessor4[nextRangeBegin]);
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
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref conditionsBuffer3, ref conditionTickTimerBuffer3, bufferAccessor3[j], bufferAccessor4[j]);
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
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<ConditionTickTimerBuffer> conditionTickTimerBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref conditionsBuffer4, ref conditionTickTimerBuffer4, bufferAccessor3[k], bufferAccessor4[k]);
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
	private struct RemoveConditionsJob : IJob
	{
		public BufferLookup<ConditionsBuffer> ConditionsBufferLookup;

		public NativeList<ConditionToRemove> ConditionsToRemove;

		[BurstCompile]
		public void Execute()
		{
			ConditionsToRemove.Sort();
			for (int i = 0; i < ConditionsToRemove.Length; i++)
			{
				Entity entity = ConditionsToRemove[i].Entity;
				int conditionIndex = ConditionsToRemove[i].ConditionIndex;
				ConditionsBufferLookup[entity].RemoveAtSwapBack(conditionIndex);
			}
		}
	}

	private struct TypeHandle
	{
		public ProcessNewConditionsBufferJob.InternalCompilerQueryAndHandleData __ConditionsSystem_ProcessNewConditionsBufferJob_WithDefaultQuery_JobEntityTypeHandle;

		public MarkConditionsToBeRemovedJob.InternalCompilerQueryAndHandleData __ConditionsSystem_MarkConditionsToBeRemovedJob_WithDefaultQuery_JobEntityTypeHandle;

		public BufferLookup<ConditionsBuffer> __ConditionsBuffer_RW_BufferLookup;

		public RemoveConditionsFromDeadEntitiesJob.InternalCompilerQueryAndHandleData __ConditionsSystem_RemoveConditionsFromDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<BurningConditionCD> __BurningConditionCD_RW_ComponentLookup;

		public ComponentLookup<AffectedBySlipperyMovementConditionCD> __AffectedBySlipperyMovementConditionCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RO_ComponentLookup;

		public FindConditionsToRemoveAndUpdateTimerJob.InternalCompilerQueryAndHandleData __ConditionsSystem_FindConditionsToRemoveAndUpdateTimerJob_WithDefaultQuery_JobEntityTypeHandle;

		public DamageTakenJob.InternalCompilerQueryAndHandleData __ConditionsSystem_DamageTakenJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ConditionsSystem_ProcessNewConditionsBufferJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ConditionsSystem_MarkConditionsToBeRemovedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ConditionsBuffer_RW_BufferLookup = state.GetBufferLookup<ConditionsBuffer>();
			__ConditionsSystem_RemoveConditionsFromDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__BurningConditionCD_RW_ComponentLookup = state.GetComponentLookup<BurningConditionCD>();
			__AffectedBySlipperyMovementConditionCD_RW_ComponentLookup = state.GetComponentLookup<AffectedBySlipperyMovementConditionCD>();
			__Unity_Physics_PhysicsVelocity_RO_ComponentLookup = state.GetComponentLookup<PhysicsVelocity>(isReadOnly: true);
			__ConditionsSystem_FindConditionsToRemoveAndUpdateTimerJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ConditionsSystem_DamageTakenJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000126B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000126B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000126B_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000126C_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000126C_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000126C_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_617746596_0;

	private EntityQuery __query_617746596_1;

	private EntityQuery __query_617746596_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		ConditionsTableCD singleton = __query_617746596_0.GetSingleton<ConditionsTableCD>();
		if (!__query_617746596_1.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_617746596_2.TryGetSingleton<NetworkTime>(out var value2);
		ProcessNewConditionsBufferJob job = new ProcessNewConditionsBufferJob
		{
			ConditionsTable = singleton,
			CurrentTick = value2.ServerTick,
			TickRate = (uint)value.SimulationTickRate
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__ConditionsSystem_ProcessNewConditionsBufferJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(default(MarkConditionsToBeRemovedJob), __TypeHandle.__ConditionsSystem_MarkConditionsToBeRemovedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		RemoveConditionsFromDeadEntitiesJob job2 = new RemoveConditionsFromDeadEntitiesJob
		{
			ConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RW_BufferLookup, ref state),
			ConditionsTable = singleton.Value,
			CurrentTick = value2.ServerTick,
			TickRate = (uint)value.SimulationTickRate
		};
		state.Dependency = __ScheduleViaJobChunkExtension_2(job2, __TypeHandle.__ConditionsSystem_RemoveConditionsFromDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		NativeList<ConditionToRemove> conditionsToRemove = new NativeList<ConditionToRemove>(state.WorldUpdateAllocator);
		FindConditionsToRemoveAndUpdateTimerJob job3 = new FindConditionsToRemoveAndUpdateTimerJob
		{
			BurningConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BurningConditionCD_RW_ComponentLookup, ref state),
			AffectedBySlipperyMovementConditionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectedBySlipperyMovementConditionCD_RW_ComponentLookup, ref state),
			PhysicsVelocityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RO_ComponentLookup, ref state),
			ConditionsTable = singleton,
			CurrentTick = value2.ServerTick,
			TickRate = (uint)value.SimulationTickRate,
			ConditionsToRemove = conditionsToRemove
		};
		state.Dependency = __ScheduleViaJobChunkExtension_3(job3, __TypeHandle.__ConditionsSystem_FindConditionsToRemoveAndUpdateTimerJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		RemoveConditionsJob jobData = new RemoveConditionsJob
		{
			ConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RW_BufferLookup, ref state),
			ConditionsToRemove = conditionsToRemove
		};
		state.Dependency = IJobExtensions.Schedule(jobData, state.Dependency);
		DamageTakenJob job4 = new DamageTakenJob
		{
			CurrentTick = value2.ServerTick,
			ConditionsTable = singleton,
			TickRate = (uint)value.SimulationTickRate
		};
		state.Dependency = __ScheduleViaJobChunkExtension_4(job4, __TypeHandle.__ConditionsSystem_DamageTakenJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ProcessNewConditionsBufferJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ConditionsSystem_ProcessNewConditionsBufferJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ConditionsSystem_ProcessNewConditionsBufferJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ConditionsSystem_ProcessNewConditionsBufferJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ConditionsSystem_ProcessNewConditionsBufferJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(MarkConditionsToBeRemovedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ConditionsSystem_MarkConditionsToBeRemovedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ConditionsSystem_MarkConditionsToBeRemovedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ConditionsSystem_MarkConditionsToBeRemovedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ConditionsSystem_MarkConditionsToBeRemovedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(RemoveConditionsFromDeadEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ConditionsSystem_RemoveConditionsFromDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ConditionsSystem_RemoveConditionsFromDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ConditionsSystem_RemoveConditionsFromDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ConditionsSystem_RemoveConditionsFromDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(FindConditionsToRemoveAndUpdateTimerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ConditionsSystem_FindConditionsToRemoveAndUpdateTimerJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ConditionsSystem_FindConditionsToRemoveAndUpdateTimerJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ConditionsSystem_FindConditionsToRemoveAndUpdateTimerJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ConditionsSystem_FindConditionsToRemoveAndUpdateTimerJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(DamageTakenJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ConditionsSystem_DamageTakenJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ConditionsSystem_DamageTakenJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ConditionsSystem_DamageTakenJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ConditionsSystem_DamageTakenJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_617746596_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_617746596_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_617746596_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000126B_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000126C_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ConditionsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ConditionsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ConditionsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
