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
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[UpdateAfter(typeof(UpdateHealthSystemGroup))]
public struct SetEntitiesDestroyedSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct SetEntitiesDestroyedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.Build(ref state);
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
			public void Run(ref SetEntitiesDestroyedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SetEntitiesDestroyedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SetEntitiesDestroyedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SetEntitiesDestroyedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SetEntitiesDestroyedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SetEntitiesDestroyedJob job, EntityManager entityManager)
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

		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public BufferLookup<LinkedEntityGroup> linkedEntityGroupLookup;

		[ReadOnly]
		public ComponentLookup<DontDestroyOnZeroHealthCD> dontDestroyOnZeroHealthLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity)
		{
			if ((dontDestroyOnZeroHealthLookup.TryGetComponent(entity, out var componentData) && !componentData.disabled) || healthLookup[entity].health > 0)
			{
				return;
			}
			entityDestroyedLookup.SetComponentEnabled(entity, value: true);
			if (!linkedEntityGroupLookup.TryGetBuffer(entity, out var bufferData))
			{
				return;
			}
			for (int i = 0; i < bufferData.Length; i++)
			{
				Entity value = bufferData[i].Value;
				if (healthLookup.TryGetComponent(value, out var componentData2))
				{
					componentData2.health = 0;
					healthLookup[value] = componentData2;
					entityDestroyedLookup.SetComponentEnabled(value, value: true);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity);
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
						Execute(entity2);
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
					Execute(entity3);
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
					Execute(entity4);
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
	private struct StartDestroyTimerJob : IJobChunk
	{
		public uint GlobalSystemVersion;

		public ComponentTypeHandle<EntityDestroyedCD> EntityDestroyedTypeHandle;

		[ReadOnly]
		public EntityTypeHandle EntityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<OverrideTimeBeforeDestroy> OverrideTimeBeforeDestroyTypeHandle;

		public NetworkTick CurrentTick;

		public uint TickRate;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (!chunk.DidChange(ref EntityDestroyedTypeHandle, GlobalSystemVersion) && !chunk.DidOrderChange(GlobalSystemVersion))
			{
				return;
			}
			NativeArray<EntityDestroyedCD> nativeArray = chunk.GetNativeArray(ref EntityDestroyedTypeHandle);
			NativeArray<OverrideTimeBeforeDestroy> nativeArray2 = (chunk.Has(ref OverrideTimeBeforeDestroyTypeHandle) ? chunk.GetNativeArray(ref OverrideTimeBeforeDestroyTypeHandle) : default(NativeArray<OverrideTimeBeforeDestroy>));
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				EntityDestroyedCD value = nativeArray[nextIndex];
				if (!value.destroyTimer.HasStarted)
				{
					if (nativeArray2.IsCreated)
					{
						value.destroyTimer.Start(CurrentTick, nativeArray2[nextIndex].timeBeforeDestroy, TickRate);
					}
					else if (value.destroyTimer.targetTicks == 0)
					{
						value.destroyTimer.Start(CurrentTick, 2f, TickRate);
					}
					else
					{
						value.destroyTimer.Start(CurrentTick);
					}
					nativeArray[nextIndex] = value;
				}
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentLookup;

		public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

		[ReadOnly]
		public BufferLookup<LinkedEntityGroup> __Unity_Entities_LinkedEntityGroup_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DontDestroyOnZeroHealthCD> __DontDestroyOnZeroHealthCD_RO_ComponentLookup;

		public SetEntitiesDestroyedJob.InternalCompilerQueryAndHandleData __SetEntitiesDestroyedSystem_SetEntitiesDestroyedJob_WithoutDefaultQuery_JobEntityTypeHandle;

		public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<OverrideTimeBeforeDestroy> __OverrideTimeBeforeDestroy_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EntityDestroyedCD_RW_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>();
			__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
			__Unity_Entities_LinkedEntityGroup_RO_BufferLookup = state.GetBufferLookup<LinkedEntityGroup>(isReadOnly: true);
			__DontDestroyOnZeroHealthCD_RO_ComponentLookup = state.GetComponentLookup<DontDestroyOnZeroHealthCD>(isReadOnly: true);
			__SetEntitiesDestroyedSystem_SetEntitiesDestroyedJob_WithoutDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: false);
			__EntityDestroyedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>();
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__OverrideTimeBeforeDestroy_RO_ComponentTypeHandle = state.GetComponentTypeHandle<OverrideTimeBeforeDestroy>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_0000168F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000168F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000168F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery setEntitiesDestroyedQuery;

	private uint _globalSystemVersionWhenLastRunForDisabledEntities;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_235625391_0;

	private EntityQuery __query_235625391_1;

	private EntityQuery __query_235625391_2;

	private EntityQuery __query_235625391_3;

	private EntityQuery __query_235625391_4;

	public void OnCreate(ref SystemState state)
	{
		setEntitiesDestroyedQuery = __query_235625391_0;
		setEntitiesDestroyedQuery.AddChangedVersionFilter(typeof(HealthCD));
		setEntitiesDestroyedQuery.AddOrderVersionFilter();
		state.World.GetExistingSystemManaged<PredictedSimulationSystemGroup>().AddSystemToPartialTickUpdate(ref state);
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_235625391_3.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new SetEntitiesDestroyedJob
		{
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentLookup, ref state),
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref state),
			linkedEntityGroupLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Unity_Entities_LinkedEntityGroup_RO_BufferLookup, ref state),
			dontDestroyOnZeroHealthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDestroyOnZeroHealthCD_RO_ComponentLookup, ref state)
		}, setEntitiesDestroyedQuery, state.Dependency, ref state, hasUserDefinedQuery: true);
		StartDestroyTimerJob jobData = new StartDestroyTimerJob
		{
			EntityDestroyedTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentTypeHandle, ref state),
			EntityTypeHandle = InternalCompilerInterface.GetEntityTypeHandle(ref __TypeHandle.__Unity_Entities_Entity_TypeHandle, ref state),
			OverrideTimeBeforeDestroyTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__OverrideTimeBeforeDestroy_RO_ComponentTypeHandle, ref state),
			CurrentTick = value.ServerTick,
			TickRate = (uint)__query_235625391_4.GetSingleton<ClientServerTickRate>().SimulationTickRate
		};
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 30, 0.1f))
		{
			EntityQuery _query_235625391_ = __query_235625391_1;
			jobData.GlobalSystemVersion = _globalSystemVersionWhenLastRunForDisabledEntities;
			state.Dependency = JobChunkExtensions.Schedule(jobData, _query_235625391_, state.Dependency);
			_globalSystemVersionWhenLastRunForDisabledEntities = state.GlobalSystemVersion;
		}
		else
		{
			EntityQuery _query_235625391_2 = __query_235625391_2;
			jobData.GlobalSystemVersion = state.LastSystemVersion;
			state.Dependency = JobChunkExtensions.Schedule(jobData, _query_235625391_2, state.Dependency);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(SetEntitiesDestroyedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SetEntitiesDestroyedSystem_SetEntitiesDestroyedJob_WithoutDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SetEntitiesDestroyedSystem_SetEntitiesDestroyedJob_WithoutDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SetEntitiesDestroyedSystem_SetEntitiesDestroyedJob_WithoutDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SetEntitiesDestroyedSystem_SetEntitiesDestroyedJob_WithoutDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<EntityDestroyedCD>();
		__query_235625391_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EntityDestroyedCD, Simulate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_235625391_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EntityDestroyedCD, Simulate>();
		__query_235625391_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_235625391_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_235625391_4 = entityQueryBuilder2.Build(ref state);
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
		((SetEntitiesDestroyedSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000168F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SetEntitiesDestroyedSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SetEntitiesDestroyedSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
