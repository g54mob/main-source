using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using PlayerState;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

[BurstCompile]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[UpdateAfter(typeof(UpdateHealthSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct CheckForDeadPlayerSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(Simulate) })]
	private struct CheckJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<CharacterTypeCD> __CharacterTypeCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__CharacterTypeCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CharacterTypeCD>(isReadOnly: true);
					__PlayerState_PlayerStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>();
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__CharacterTypeCD_RO_ComponentTypeHandle.Update(ref state);
					__PlayerState_PlayerStateCD_RW_ComponentTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CharacterTypeCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
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
			public void Run(ref CheckJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CheckJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CheckJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CheckJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CheckJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CheckJob job, EntityManager entityManager)
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

		public ComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD> reduceDurabilityOfAllEquipmentLookup;

		public NetworkTick currentTick;

		public bool isServer;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in HealthCD healthCD, in CharacterTypeCD characterTypeCD, ref PlayerStateCD playerStateCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD)
		{
			if (healthCD.health <= 0 && !playerStateCD.HasAnyState(PlayerStateEnum.SpawningFromCore | PlayerStateEnum.Death))
			{
				playerStateCD.SetNextState(PlayerStateEnum.Death, nextStateLocked: true);
				if (!characterTypeCD.IsHardcore() && isServer)
				{
					reduceDurabilityOfAllEquipmentLookup.SetComponentEnabled(entity, value: true);
					reduceDurabilityOfAllEquipmentLookup.GetRefRW(entity).ValueRW.percentage += 0.15f;
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							entity = entity,
							localOnlyEffect = 1,
							effectID = EffectID.ChatMessage,
							value1 = 6
						}
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__CharacterTypeCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RW_ComponentTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref HealthCD healthCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, i);
					ref CharacterTypeCD characterTypeCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, i);
					ref PlayerStateCD playerStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr4, i);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor[i];
					Execute(entity, in healthCD, in characterTypeCD, ref playerStateCD, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, i));
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
						ref HealthCD healthCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, nextRangeBegin);
						ref CharacterTypeCD characterTypeCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, nextRangeBegin);
						ref PlayerStateCD playerStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, in healthCD2, in characterTypeCD2, ref playerStateCD2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, nextRangeBegin));
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
					ref HealthCD healthCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, j);
					ref CharacterTypeCD characterTypeCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, j);
					ref PlayerStateCD playerStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr4, j);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor[j];
					Execute(entity3, in healthCD3, in characterTypeCD3, ref playerStateCD3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, j));
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
					ref HealthCD healthCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, k);
					ref CharacterTypeCD characterTypeCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CharacterTypeCD>(nativeArrayPtr3, k);
					ref PlayerStateCD playerStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr4, k);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor[k];
					Execute(entity4, in healthCD4, in characterTypeCD4, ref playerStateCD4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, k));
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
		public ComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD> __PlayerEquipment_ReduceDurabilityOfAllEquipmentTriggerCD_RW_ComponentLookup;

		public CheckJob.InternalCompilerQueryAndHandleData __CheckForDeadPlayerSystem_CheckJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__PlayerEquipment_ReduceDurabilityOfAllEquipmentTriggerCD_RW_ComponentLookup = state.GetComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD>();
			__CheckForDeadPlayerSystem_CheckJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00002D3E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00002D3E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00002D3E_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_1795137583_0;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1795137583_0.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new CheckJob
		{
			reduceDurabilityOfAllEquipmentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_ReduceDurabilityOfAllEquipmentTriggerCD_RW_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			isServer = state.WorldUnmanaged.IsServer()
		}, __TypeHandle.__CheckForDeadPlayerSystem_CheckJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(CheckJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CheckForDeadPlayerSystem_CheckJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CheckForDeadPlayerSystem_CheckJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CheckForDeadPlayerSystem_CheckJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CheckForDeadPlayerSystem_CheckJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1795137583_0 = entityQueryBuilder2.Build(ref state);
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
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00002D3E_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CheckForDeadPlayerSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CheckForDeadPlayerSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
