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
public struct MagicBarrierSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(ManaCD),
		typeof(Simulate)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct UpdateBarrierJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<MagicBarrierCD> __MagicBarrierCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LastDamageTakenTimeCD> __LastDamageTakenTimeCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__MagicBarrierCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MagicBarrierCD>();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					__LastDamageTakenTimeCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LastDamageTakenTimeCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__MagicBarrierCD_RW_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					__LastDamageTakenTimeCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LastDamageTakenTimeCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ManaCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MagicBarrierCD>();
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
			public void Run(ref UpdateBarrierJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateBarrierJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateBarrierJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateBarrierJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateBarrierJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateBarrierJob job, EntityManager entityManager)
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

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref MagicBarrierCD magicBarrierCD, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, in LastDamageTakenTimeCD lastDamageTakenTimeCD)
		{
			int value = summarizedConditionsBuffer[263].value;
			value += summarizedConditionsBuffer[281].value;
			magicBarrierCD.barrierMaxHealth = value;
			magicBarrierCD.barrierHealth = math.clamp(magicBarrierCD.barrierHealth, 0, magicBarrierCD.barrierMaxHealth);
			DoRegenBarrier(currentTick, tickRate, ref magicBarrierCD, in summarizedConditionsBuffer, in lastDamageTakenTimeCD);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MagicBarrierCD_RW_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__LastDamageTakenTimeCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MagicBarrierCD>(nativeArrayPtr, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr2, i));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MagicBarrierCD>(nativeArrayPtr, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MagicBarrierCD>(nativeArrayPtr, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MagicBarrierCD>(nativeArrayPtr, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LastDamageTakenTimeCD>(nativeArrayPtr2, k));
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
		public UpdateBarrierJob.InternalCompilerQueryAndHandleData __MagicBarrierSystem_UpdateBarrierJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__MagicBarrierSystem_UpdateBarrierJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00002261_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00002261_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00002261_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private uint _tickRate;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_82429986_0;

	public void OnCreate(ref SystemState state)
	{
		_tickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_82429986_0.TryGetSingleton<NetworkTime>(out var value);
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 0, 2f))
		{
			state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateBarrierJob
			{
				currentTick = value.ServerTick,
				tickRate = _tickRate
			}, __TypeHandle.__MagicBarrierSystem_UpdateBarrierJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	private static void DoRegenBarrier(NetworkTick currentTick, uint tickRate, ref MagicBarrierCD magicBarrierCD, in DynamicBuffer<SummarizedConditionsBuffer> sumConditions, in LastDamageTakenTimeCD lastDamageTakenTimeCD)
	{
		if (magicBarrierCD.barrierHealth >= magicBarrierCD.barrierMaxHealth)
		{
			magicBarrierCD.barrierRegenTimer.ClearStart();
			return;
		}
		if (lastDamageTakenTimeCD.lastDamageTick.IsValid)
		{
			float num = 0.08f * (float)sumConditions[270].value;
			float num2 = math.max(0f, 8f - num);
			float num3 = NetworkTimeUtilities.TimeBetweenTicksInSeconds(lastDamageTakenTimeCD.lastDamageTick, currentTick, tickRate);
			if (num3 < num2)
			{
				magicBarrierCD.barrierRegenTimer.Start(currentTick, num2 - num3, tickRate);
				return;
			}
		}
		if (!magicBarrierCD.barrierRegenTimer.isRunning || magicBarrierCD.barrierRegenTimer.IsTimerElapsed(currentTick))
		{
			magicBarrierCD.barrierRegenTimer.Start(currentTick, tickRate);
			magicBarrierCD.barrierHealth = math.clamp(magicBarrierCD.barrierHealth + (int)math.ceil(0.1f * (float)magicBarrierCD.barrierMaxHealth), 0, magicBarrierCD.barrierMaxHealth);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(UpdateBarrierJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__MagicBarrierSystem_UpdateBarrierJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__MagicBarrierSystem_UpdateBarrierJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__MagicBarrierSystem_UpdateBarrierJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__MagicBarrierSystem_UpdateBarrierJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_82429986_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((MagicBarrierSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00002261_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((MagicBarrierSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((MagicBarrierSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
