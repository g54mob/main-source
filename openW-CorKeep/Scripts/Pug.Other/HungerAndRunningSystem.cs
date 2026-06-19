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
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct HungerAndRunningSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct HungerAndRunningJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<HungerCD> __HungerCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<CharacterTypeCD> __CharacterTypeCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
					__HungerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HungerCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__CharacterTypeCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CharacterTypeCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__HungerCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__CharacterTypeCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CharacterTypeCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HungerCD>();
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
			public void Run(ref HungerAndRunningJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HungerAndRunningJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HungerAndRunningJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HungerAndRunningJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HungerAndRunningJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HungerAndRunningJob job, EntityManager entityManager)
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

		[ReadOnly]
		public ConditionsTableCD conditionsTable;

		public float deltaTime;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, ref HungerCD hunger, in LocalTransform transform, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, in CharacterTypeCD characterTypeCD)
		{
			float num = math.length(hunger.previousPosition - transform.Position);
			if (hunger.canConsumeHunger)
			{
				if (num < 5f)
				{
					hunger.accumulatedMovement += num * (1f - (float)summarizedConditionEffectsBuffer[51].value / 100f);
				}
				if (hunger.accumulatedMovement > (float)(characterTypeCD.IsCasual() ? 40 : 20))
				{
					hunger.hunger = math.clamp(hunger.hunger - 1, 0, 100);
					hunger.accumulatedMovement = 0f;
				}
			}
			hunger.previousPosition = transform.Position;
			if (summarizedConditionsBuffer[7].value != 0)
			{
				EntityUtility.RemoveCondition(ConditionID.StarvingMovementSpeedDecrease, conditionsBuffer);
			}
			if (hunger.hunger < 25)
			{
				int value = -1 * (25 - hunger.hunger);
				EntityUtility.AddOrRefreshConditionOverrideStacks(new ConditionData
				{
					conditionID = ConditionID.StarvingHealthDecrease,
					duration = -1f,
					value = value
				}, conditionsBuffer, conditionsTable, currentTick, tickRate);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.StarvingHealthDecrease, conditionsBuffer);
			}
			if (hunger.hunger < 25)
			{
				int value2 = -10 * (25 - hunger.hunger);
				EntityUtility.AddOrRefreshConditionOverrideStacks(new ConditionData
				{
					conditionID = ConditionID.StarvingDamageDecrease,
					duration = -1f,
					value = value2
				}, conditionsBuffer, conditionsTable, currentTick, tickRate);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.StarvingDamageDecrease, conditionsBuffer);
			}
			int value3 = summarizedConditionsBuffer[139].value;
			float num2 = 1f + (float)summarizedConditionsBuffer[140].value / 100f;
			if (summarizedConditionsBuffer[32].value != 0)
			{
				EntityUtility.RemoveCondition(ConditionID.WellFedMovementSpeedIncrease, conditionsBuffer);
			}
			if (hunger.hunger >= 75 - value3)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.WellFedHealthIncrease,
					duration = -1f,
					value = (int)math.round(5f * num2)
				}, conditionsBuffer, conditionsTable, currentTick, tickRate, summarizedConditionsBuffer);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.WellFedHealthIncrease, conditionsBuffer);
			}
			if (hunger.hunger >= 75 - value3)
			{
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.WellFedDamageIncrease,
					duration = -1f,
					value = (int)math.round(50f * num2)
				}, conditionsBuffer, conditionsTable, currentTick, tickRate, summarizedConditionsBuffer);
			}
			else
			{
				EntityUtility.RemoveCondition(ConditionID.WellFedDamageIncrease, conditionsBuffer);
			}
			int value4 = summarizedConditionsBuffer[70].value;
			int value5 = summarizedConditionsBuffer[71].value;
			if (num > 0.01f || value4 == 0)
			{
				hunger.standingStillTimer = 0f;
				if (value5 > 0)
				{
					EntityUtility.RemoveCondition(ConditionID.DodgeIncreaseFromStandingStill, conditionsBuffer);
				}
			}
			else if (value4 != value5)
			{
				hunger.standingStillTimer += deltaTime;
				if (hunger.standingStillTimer > 3f)
				{
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.DodgeIncreaseFromStandingStill,
						value = value4
					}, conditionsBuffer, conditionsTable, currentTick, tickRate, summarizedConditionsBuffer);
				}
			}
			int value6 = summarizedConditionsBuffer[72].value;
			int value7 = summarizedConditionsBuffer[73].value;
			if (!hunger.canConsumeHunger || num < 0.01f || value6 == 0)
			{
				hunger.loseConsistentRunningTimer -= deltaTime;
				if (hunger.loseConsistentRunningTimer < 0f)
				{
					hunger.consistentRunningTimer = 0f;
					if (value7 > 0)
					{
						EntityUtility.RemoveCondition(ConditionID.MovementSpeedIncreaseFromRunningConsistently, conditionsBuffer);
					}
				}
			}
			else if (value6 != value7)
			{
				hunger.consistentRunningTimer += deltaTime;
				hunger.loseConsistentRunningTimer = 0.75f;
				if (hunger.consistentRunningTimer > 3f)
				{
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.MovementSpeedIncreaseFromRunningConsistently,
						value = value6
					}, conditionsBuffer, conditionsTable, currentTick, tickRate, summarizedConditionsBuffer);
				}
			}
			int value8 = summarizedConditionsBuffer[75].value;
			if (!hunger.canConsumeHunger || num < 0.01f || value8 == 0)
			{
				if (hunger.loseDamageFromRunningStreakTimer > 0.75f)
				{
					hunger.damageFromRunningTimer = 0f;
				}
				else
				{
					hunger.loseDamageFromRunningStreakTimer += deltaTime;
				}
				return;
			}
			hunger.damageFromRunningTimer += deltaTime;
			hunger.loseDamageFromRunningStreakTimer = 0f;
			if (hunger.damageFromRunningTimer > 3f)
			{
				hunger.damageFromRunningTimer = 0f;
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.DamageIncreaseFromRunning,
					value = value8,
					duration = 8f
				}, conditionsBuffer, conditionsTable, currentTick, tickRate, summarizedConditionsBuffer);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			BufferAccessor<ConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HungerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__CharacterTypeCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor[i];
					Execute(ref conditionsBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), bufferAccessor2[i], bufferAccessor3[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, i));
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
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(ref conditionsBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), bufferAccessor2[nextRangeBegin], bufferAccessor3[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, nextRangeBegin));
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
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor[j];
					Execute(ref conditionsBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), bufferAccessor2[j], bufferAccessor3[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor[k];
					Execute(ref conditionsBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), bufferAccessor2[k], bufferAccessor3[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, k));
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

	private struct TypeHandle
	{
		public HungerAndRunningJob.InternalCompilerQueryAndHandleData __HungerAndRunningSystem_HungerAndRunningJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__HungerAndRunningSystem_HungerAndRunningJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000020F9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000020F9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000020F9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000020FA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000020FA_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000020FA_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_000020FB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000020FB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000020FB_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1012490617_0;

	private EntityQuery __query_1012490617_1;

	private EntityQuery __query_1012490617_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ConditionsTableCD>();
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		ConditionsTableCD singleton = __query_1012490617_0.GetSingleton<ConditionsTableCD>();
		if (!__query_1012490617_1.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_1012490617_2.TryGetSingleton<NetworkTime>(out var value2);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new HungerAndRunningJob
		{
			conditionsTable = singleton,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime,
			currentTick = value2.ServerTick,
			tickRate = (uint)value.SimulationTickRate
		}, __TypeHandle.__HungerAndRunningSystem_HungerAndRunningJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(HungerAndRunningJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HungerAndRunningSystem_HungerAndRunningJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HungerAndRunningSystem_HungerAndRunningJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HungerAndRunningSystem_HungerAndRunningJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HungerAndRunningSystem_HungerAndRunningJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1012490617_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1012490617_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1012490617_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000020F9_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000020FA_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000020FB_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((HungerAndRunningSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HungerAndRunningSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HungerAndRunningSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HungerAndRunningSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
