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

[BurstCompile]
[UpdateInGroup(typeof(ConditionEffectsUpdateSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct ConditionsFromMovementSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct UpdateConditionsByMovementJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<ConditionsFromMovementCD> __ConditionsFromMovementCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerMovementCD> __PlayerMovementCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ConditionsFromMovementCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ConditionsFromMovementCD>();
					__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
					__PlayerMovementCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerMovementCD>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ConditionsFromMovementCD_RW_ComponentTypeHandle.Update(ref state);
					__ClientInput_RO_ComponentTypeHandle.Update(ref state);
					__PlayerMovementCD_RO_ComponentTypeHandle.Update(ref state);
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
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerMovementCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsFromMovementCD>();
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
			public void Run(ref UpdateConditionsByMovementJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateConditionsByMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateConditionsByMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateConditionsByMovementJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateConditionsByMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateConditionsByMovementJob job, EntityManager entityManager)
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

		public ConditionsTableCD conditionsTableCD;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref ConditionsFromMovementCD conditionsFromMovementCD, in ClientInput clientInput, in PlayerMovementCD playerMovementCD, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer)
		{
			bool flag = math.lengthsq(playerMovementCD.targetMovementVelocity) > 0.01f;
			if (!flag)
			{
				float seconds = 3f;
				if (!conditionsFromMovementCD.standStillTimer.isRunning)
				{
					conditionsFromMovementCD.standStillTimer.Start(currentTick, seconds, tickRate);
				}
				else if (conditionsFromMovementCD.standStillTimer.IsTimerElapsed(currentTick))
				{
					int value = summarizedConditionsBuffer[100].value;
					if (value > 0 && summarizedConditionsBuffer[101].value != value)
					{
						EntityUtility.AddOrRefreshCondition(new ConditionData
						{
							conditionID = ConditionID.RangeDamageIncreaseFromStandingStill,
							value = value,
							duration = 0f
						}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
					}
					else if (value == 0 && summarizedConditionsBuffer[101].value != 0)
					{
						EntityUtility.RemoveCondition(ConditionID.RangeDamageIncreaseFromStandingStill, conditionsBuffer);
					}
					int value2 = summarizedConditionsBuffer[153].value;
					if (value2 > 0 && summarizedConditionsBuffer[154].value != value2)
					{
						EntityUtility.AddOrRefreshCondition(new ConditionData
						{
							conditionID = ConditionID.CriticalHitChanceFromStandingStill,
							value = value2,
							duration = 0f
						}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
					}
					else if (value2 == 0 && summarizedConditionsBuffer[154].value != 0)
					{
						EntityUtility.RemoveCondition(ConditionID.CriticalHitChanceFromStandingStill, conditionsBuffer);
					}
				}
			}
			else
			{
				conditionsFromMovementCD.standStillTimer.ClearStart();
				if (summarizedConditionsBuffer[101].value != 0)
				{
					EntityUtility.RemoveCondition(ConditionID.RangeDamageIncreaseFromStandingStill, conditionsBuffer);
				}
				if (summarizedConditionsBuffer[154].value != 0)
				{
					EntityUtility.RemoveCondition(ConditionID.CriticalHitChanceFromStandingStill, conditionsBuffer);
				}
			}
			bool flag2 = clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown) || clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown) || clientInput.IsButtonStateSet(CommandInputButtonStateNames.UseOffHand_HeldDown);
			if (!flag2)
			{
				float seconds2 = 3f;
				if (!conditionsFromMovementCD.interactTimer.isRunning)
				{
					conditionsFromMovementCD.interactTimer.Start(currentTick, seconds2, tickRate);
				}
			}
			else
			{
				conditionsFromMovementCD.interactTimer.ClearStart();
			}
			int value3 = summarizedConditionsBuffer[322].value;
			if (!flag && !flag2)
			{
				int value4 = summarizedConditionsBuffer[347].value;
				if (value4 <= 0)
				{
					conditionsFromMovementCD.sleepyTimer.Stop(currentTick);
				}
				if (value4 > 0 && !conditionsFromMovementCD.sleepyTimer.isRunning)
				{
					conditionsFromMovementCD.sleepyTimer.Start(currentTick, 3f, tickRate);
				}
				if (value4 > 0 && conditionsFromMovementCD.standStillTimer.IsTimerElapsed(currentTick) && conditionsFromMovementCD.interactTimer.IsTimerElapsed(currentTick) && conditionsFromMovementCD.sleepyTimer.IsTimerElapsed(currentTick))
				{
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.SleepingFromStandingStill,
						value = value4,
						duration = 5f
					}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				}
				else if (value4 == 0 && value3 != 0)
				{
					EntityUtility.RemoveCondition(ConditionID.SleepingFromStandingStill, conditionsBuffer);
				}
			}
			else if (value3 != 0)
			{
				EntityUtility.RemoveCondition(ConditionID.SleepingFromStandingStill, conditionsBuffer);
			}
			if (summarizedConditionsBuffer[81].value > 0)
			{
				bool flag3 = flag || clientInput.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown) || clientInput.IsButtonStateSet(CommandInputButtonStateNames.SecondInteract_HeldDown) || clientInput.IsButtonStateSet(CommandInputButtonStateNames.UseOffHand_HeldDown);
				if (EntityUtility.GetFirstOccurrenceOfCondition(ConditionID.ImmuneToDamageAfterRespawn, conditionsBuffer).condition.conditionData.duration == 0f && flag3)
				{
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.ImmuneToDamageAfterRespawn,
						value = 1,
						duration = 2f
					}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ConditionsFromMovementCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerMovementCD_RO_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref ConditionsFromMovementCD conditionsFromMovementCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ConditionsFromMovementCD>(nativeArrayPtr2, i);
					ref ClientInput clientInput = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, i);
					ref PlayerMovementCD playerMovementCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr4, i);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = bufferAccessor[i];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor2[i];
					Execute(entity, ref conditionsFromMovementCD, in clientInput, in playerMovementCD, in summarizedConditionsBuffer, ref conditionsBuffer);
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
						ref ConditionsFromMovementCD conditionsFromMovementCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ConditionsFromMovementCD>(nativeArrayPtr2, nextRangeBegin);
						ref ClientInput clientInput2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, nextRangeBegin);
						ref PlayerMovementCD playerMovementCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref conditionsFromMovementCD2, in clientInput2, in playerMovementCD2, in summarizedConditionsBuffer2, ref conditionsBuffer2);
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
					ref ConditionsFromMovementCD conditionsFromMovementCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ConditionsFromMovementCD>(nativeArrayPtr2, j);
					ref ClientInput clientInput3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, j);
					ref PlayerMovementCD playerMovementCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr4, j);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref conditionsFromMovementCD3, in clientInput3, in playerMovementCD3, in summarizedConditionsBuffer3, ref conditionsBuffer3);
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
					ref ConditionsFromMovementCD conditionsFromMovementCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ConditionsFromMovementCD>(nativeArrayPtr2, k);
					ref ClientInput clientInput4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, k);
					ref PlayerMovementCD playerMovementCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerMovementCD>(nativeArrayPtr4, k);
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref conditionsFromMovementCD4, in clientInput4, in playerMovementCD4, in summarizedConditionsBuffer4, ref conditionsBuffer4);
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
		public UpdateConditionsByMovementJob.InternalCompilerQueryAndHandleData __ConditionsFromMovementSystem_UpdateConditionsByMovementJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ConditionsFromMovementSystem_UpdateConditionsByMovementJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001239_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001239_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001239_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000123A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000123A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000123A_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_534591642_0;

	private EntityQuery __query_534591642_1;

	private EntityQuery __query_534591642_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<ConditionsTableCD>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_534591642_0.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateConditionsByMovementJob
		{
			conditionsTableCD = __query_534591642_1.GetSingleton<ConditionsTableCD>(),
			currentTick = value.ServerTick,
			tickRate = (uint)__query_534591642_2.GetSingleton<ClientServerTickRate>().SimulationTickRate
		}, __TypeHandle.__ConditionsFromMovementSystem_UpdateConditionsByMovementJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(UpdateConditionsByMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ConditionsFromMovementSystem_UpdateConditionsByMovementJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ConditionsFromMovementSystem_UpdateConditionsByMovementJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ConditionsFromMovementSystem_UpdateConditionsByMovementJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ConditionsFromMovementSystem_UpdateConditionsByMovementJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_534591642_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_534591642_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_534591642_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001239_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000123A_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ConditionsFromMovementSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ConditionsFromMovementSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ConditionsFromMovementSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
