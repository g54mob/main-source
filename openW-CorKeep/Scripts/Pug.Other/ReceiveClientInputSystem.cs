using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
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
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
public struct ReceiveClientInputSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct ReceiveClientInputJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RW_ComponentTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EffectiveVelocityCD> __EffectiveVelocityCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PlayerGhost_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
					__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__EffectiveVelocityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EffectiveVelocityCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PlayerGhost_RW_ComponentTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__ClientInput_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__EffectiveVelocityCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EffectiveVelocityCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlayerGhost>();
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
			public void Run(ref ReceiveClientInputJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ReceiveClientInputJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ReceiveClientInputJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ReceiveClientInputJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ReceiveClientInputJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ReceiveClientInputJob job, EntityManager entityManager)
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

		public EntityCommandBuffer ECB;

		public NetworkTick Tick;

		public int ExtrapolateTicks;

		public float TickTime;

		[ReadOnly]
		public ComponentLookup<Disabled> DisabledLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> DisablePhysicsLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref PlayerGhost playerGhost, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, in ClientInput clientInput, in LocalTransform localTransform, in EffectiveVelocityCD effectiveVelocityCD)
		{
			playerGhost.cameraPosition = clientInput.cameraPosition;
			if (math.any(effectiveVelocityCD.Value != float2.zero))
			{
				playerGhost.smoothedVelocity = math.lerp(playerGhost.smoothedVelocity, effectiveVelocityCD.Value, 0.1f);
			}
			else
			{
				playerGhost.smoothedVelocity = effectiveVelocityCD.Value;
			}
			float2 float5 = localTransform.Position.ToFloat2();
			float2 smoothedVelocity = playerGhost.smoothedVelocity;
			float2 zero = float2.zero;
			float2 zero2 = float2.zero;
			float2 float6 = float5;
			float2 float7 = smoothedVelocity;
			float2 float8 = zero;
			float2 float9 = zero2;
			float num = math.length(smoothedVelocity);
			NetworkTick interpolationTick = clientInput.InterpolationTick;
			if (math.lengthsq(smoothedVelocity) > 0.1f && interpolationTick.IsValid)
			{
				uint tickIndexForValidTick = interpolationTick.TickIndexForValidTick;
				uint tickIndexForValidTick2 = Tick.TickIndexForValidTick;
				for (uint num2 = tickIndexForValidTick; num2 <= tickIndexForValidTick2 + ExtrapolateTicks; num2++)
				{
					float num3 = ((float)(num2 - tickIndexForValidTick) + 1f) / ((float)(tickIndexForValidTick2 - tickIndexForValidTick) + 1f);
					float2 float10 = float9 / 2f;
					float2 float11 = float10;
					float2 float12 = float8 + float11 * num3 * num3 * TickTime;
					float2 float13 = (float8 + float12) / 2f;
					float2 float14 = float7 + float13 * num3 * TickTime;
					if (math.length(float14) > num)
					{
						float14 = math.normalize(float14) * num;
					}
					float2 float15 = (float7 + float14) / 2f;
					if (math.all((float15 == float2.zero) | (math.sign(float15) != math.sign(smoothedVelocity))))
					{
						break;
					}
					float6 += float15 * TickTime;
					float7 = float14;
					float8 = float12;
					float9 = float10;
					if (math.distancesq(float5, float6) > 3f)
					{
						break;
					}
				}
			}
			ECB.SetComponent(playerGhost.playerGhostExtrapolated, LocalTransform.FromPosition(float6.ToFloat3()));
			bool flag = DisablePhysicsLookup.HasAndIsComponentEnabled(entity);
			bool flag2 = DisabledLookup.HasComponent(playerGhost.playerGhostExtrapolated);
			if (flag && !flag2)
			{
				ECB.AddComponent<Disabled>(playerGhost.playerGhostExtrapolated);
			}
			else if (!flag && flag2)
			{
				ECB.RemoveComponent<Disabled>(playerGhost.playerGhostExtrapolated);
			}
			ECB.SetComponent(entity, new CollectedAndEnabledSoulsMask
			{
				Value = clientInput.collectedAndEnabledSoulsMask
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RW_ComponentTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EffectiveVelocityCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref PlayerGhost playerGhost = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, i);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor[i];
					Execute(entity, ref playerGhost, ref conditionsBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr5, i));
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
						ref PlayerGhost playerGhost2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref playerGhost2, ref conditionsBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr5, nextRangeBegin));
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
					ref PlayerGhost playerGhost3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, j);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor[j];
					Execute(entity3, ref playerGhost3, ref conditionsBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr5, j));
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
					ref PlayerGhost playerGhost4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, k);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor[k];
					Execute(entity4, ref playerGhost4, ref conditionsBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EffectiveVelocityCD>(nativeArrayPtr5, k));
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
		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		public ReceiveClientInputJob.InternalCompilerQueryAndHandleData __ReceiveClientInputSystem_ReceiveClientInputJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Disabled_RO_ComponentLookup = state.GetComponentLookup<Disabled>(isReadOnly: true);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__ReceiveClientInputSystem_ReceiveClientInputJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000026C3_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000026C3_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000026C3_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_607405769_0;

	private EntityQuery __query_607405769_1;

	private EntityQuery __query_607405769_2;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		ClientServerTickRate clientServerTickRate = default(ClientServerTickRate);
		if (__query_607405769_0.HasSingleton<ClientServerTickRate>())
		{
			clientServerTickRate = __query_607405769_0.GetSingleton<ClientServerTickRate>();
		}
		clientServerTickRate.ResolveDefaults();
		__query_607405769_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		float tickTime = 1f / (float)clientServerTickRate.SimulationTickRate;
		int extrapolateTicks = (int)math.round(0.3f * (float)clientServerTickRate.SimulationTickRate);
		EntityCommandBuffer eCB = __query_607405769_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		ReceiveClientInputJob job = new ReceiveClientInputJob
		{
			ECB = eCB,
			Tick = serverTick,
			ExtrapolateTicks = extrapolateTicks,
			TickTime = tickTime,
			DisabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup, ref state),
			DisablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__ReceiveClientInputSystem_ReceiveClientInputJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ReceiveClientInputJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ReceiveClientInputSystem_ReceiveClientInputJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ReceiveClientInputSystem_ReceiveClientInputJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ReceiveClientInputSystem_ReceiveClientInputJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ReceiveClientInputSystem_ReceiveClientInputJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_607405769_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_607405769_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_607405769_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnUpdate_000026C3_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ReceiveClientInputSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ReceiveClientInputSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
