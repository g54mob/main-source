using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.ECS.Hybrid;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct LocalAnimationSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct FindNewAnimationsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostLocalSpawnTickCD> __GhostLocalSpawnTickCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RO_ComponentTypeHandle;

				public BufferTypeHandle<LocalAnimationBuffer> __LocalAnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<LocalAnimationBufferPointer> __LocalAnimationBufferPointer_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EntityMonoBehaviourCD> __Pug_ECS_Hybrid_EntityMonoBehaviourCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__GhostLocalSpawnTickCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostLocalSpawnTickCD>(isReadOnly: true);
					__AnimationBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>(isReadOnly: true);
					__AnimationBufferPointer_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>(isReadOnly: true);
					__LocalAnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<LocalAnimationBuffer>();
					__LocalAnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalAnimationBufferPointer>();
					__Pug_ECS_Hybrid_EntityMonoBehaviourCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityMonoBehaviourCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__GhostLocalSpawnTickCD_RO_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RO_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RO_ComponentTypeHandle.Update(ref state);
					__LocalAnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__LocalAnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__Pug_ECS_Hybrid_EntityMonoBehaviourCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostLocalSpawnTickCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityMonoBehaviourCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalAnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalAnimationBufferPointer>();
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
			public void Run(ref FindNewAnimationsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FindNewAnimationsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FindNewAnimationsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FindNewAnimationsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FindNewAnimationsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FindNewAnimationsJob job, EntityManager entityManager)
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

		public NetworkTick CurrentPredictionTick;

		public Entity TriggerAnimationBufferEntity;

		public BufferLookup<TriggerAnimationsSystem.TriggerAnimationBuffer> TriggerAnimationBufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, in GhostLocalSpawnTickCD ghostLocalSpawnTick, in DynamicBuffer<AnimationBuffer> animationBuffer, in AnimationBufferPointer animationBufferPointer, ref DynamicBuffer<LocalAnimationBuffer> localAnimationBuffer, ref LocalAnimationBufferPointer localAnimationBufferPointer, in EntityMonoBehaviourCD entityMonoCD)
		{
			AnimationBuffer lastAddedElement = animationBuffer.GetLastAddedElement(in animationBufferPointer);
			if (lastAddedElement.Tick.IsValid && entityMonoCD.entityMonoBehaviour.IsValid() && (!EntityDestroyedLookup.HasAndIsComponentEnabled(entity) || lastAddedElement.animID == -414722770))
			{
				LocalAnimationBuffer lastAddedElement2 = localAnimationBuffer.GetLastAddedElement(in localAnimationBufferPointer);
				NetworkTick networkTick = lastAddedElement2.Tick;
				NetworkTick spawnTick = ghostLocalSpawnTick.spawnTick;
				if (!networkTick.IsValid || (spawnTick.IsValid && spawnTick.IsNewerThan(networkTick)))
				{
					networkTick = spawnTick;
				}
				bool flag = lastAddedElement.animID != lastAddedElement2.animID;
				if (!networkTick.IsValid || (lastAddedElement.Tick.IsNewerThan(networkTick) && (flag || (long)lastAddedElement.Tick.TicksSince(networkTick) > 2L)) || ((long)CurrentPredictionTick.TicksSince(networkTick) > 2L && flag) || (lastAddedElement.animID == -414722770 && lastAddedElement2.animID != -414722770))
				{
					DynamicBuffer<LocalAnimationBuffer> buffer = localAnimationBuffer;
					LocalAnimationBuffer item = new LocalAnimationBuffer
					{
						Tick = lastAddedElement.Tick,
						animID = lastAddedElement.animID
					};
					buffer.AddToRingBuffer(ref localAnimationBufferPointer, in item);
					TriggerAnimationBufferLookup[TriggerAnimationBufferEntity].Add(new TriggerAnimationsSystem.TriggerAnimationBuffer
					{
						Entity = entity,
						AnimID = lastAddedElement.animID
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__GhostLocalSpawnTickCD_RO_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RO_ComponentTypeHandle);
			BufferAccessor<LocalAnimationBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__LocalAnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__LocalAnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_ECS_Hybrid_EntityMonoBehaviourCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref GhostLocalSpawnTickCD ghostLocalSpawnTick = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostLocalSpawnTickCD>(nativeArrayPtr2, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					ref AnimationBufferPointer animationBufferPointer = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, i);
					DynamicBuffer<LocalAnimationBuffer> localAnimationBuffer = bufferAccessor2[i];
					Execute(entity, in ghostLocalSpawnTick, in animationBuffer, in animationBufferPointer, ref localAnimationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalAnimationBufferPointer>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityMonoBehaviourCD>(nativeArrayPtr5, i));
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
						ref GhostLocalSpawnTickCD ghostLocalSpawnTick2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostLocalSpawnTickCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						ref AnimationBufferPointer animationBufferPointer2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<LocalAnimationBuffer> localAnimationBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, in ghostLocalSpawnTick2, in animationBuffer2, in animationBufferPointer2, ref localAnimationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalAnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityMonoBehaviourCD>(nativeArrayPtr5, nextRangeBegin));
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
					ref GhostLocalSpawnTickCD ghostLocalSpawnTick3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostLocalSpawnTickCD>(nativeArrayPtr2, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					ref AnimationBufferPointer animationBufferPointer3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, j);
					DynamicBuffer<LocalAnimationBuffer> localAnimationBuffer3 = bufferAccessor2[j];
					Execute(entity3, in ghostLocalSpawnTick3, in animationBuffer3, in animationBufferPointer3, ref localAnimationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalAnimationBufferPointer>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityMonoBehaviourCD>(nativeArrayPtr5, j));
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
					ref GhostLocalSpawnTickCD ghostLocalSpawnTick4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostLocalSpawnTickCD>(nativeArrayPtr2, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					ref AnimationBufferPointer animationBufferPointer4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, k);
					DynamicBuffer<LocalAnimationBuffer> localAnimationBuffer4 = bufferAccessor2[k];
					Execute(entity4, in ghostLocalSpawnTick4, in animationBuffer4, in animationBufferPointer4, ref localAnimationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalAnimationBufferPointer>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityMonoBehaviourCD>(nativeArrayPtr5, k));
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
		public BufferLookup<TriggerAnimationsSystem.TriggerAnimationBuffer> __TriggerAnimationsSystem_TriggerAnimationBuffer_RW_BufferLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		public FindNewAnimationsJob.InternalCompilerQueryAndHandleData __LocalAnimationSystem_FindNewAnimationsJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__TriggerAnimationsSystem_TriggerAnimationBuffer_RW_BufferLookup = state.GetBufferLookup<TriggerAnimationsSystem.TriggerAnimationBuffer>();
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__LocalAnimationSystem_FindNewAnimationsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000006_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000006_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000006_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000007_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000007_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000007_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private const uint ACCEPTED_MISPREDICTION_TICK_DIFFERENCE = 2u;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1641481738_0;

	private EntityQuery __query_1641481738_1;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<TriggerAnimationsSystem.TriggerAnimationBuffer>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1641481738_0.TryGetSingleton<NetworkTime>(out var value);
		FindNewAnimationsJob job = new FindNewAnimationsJob
		{
			CurrentPredictionTick = value.ServerTick,
			TriggerAnimationBufferEntity = __query_1641481738_1.GetSingletonEntity(),
			TriggerAnimationBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TriggerAnimationsSystem_TriggerAnimationBuffer_RW_BufferLookup, ref state),
			EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__LocalAnimationSystem_FindNewAnimationsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(FindNewAnimationsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__LocalAnimationSystem_FindNewAnimationsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__LocalAnimationSystem_FindNewAnimationsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__LocalAnimationSystem_FindNewAnimationsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__LocalAnimationSystem_FindNewAnimationsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1641481738_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TriggerAnimationsSystem.TriggerAnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1641481738_1 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000006_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000007_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((LocalAnimationSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((LocalAnimationSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((LocalAnimationSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
