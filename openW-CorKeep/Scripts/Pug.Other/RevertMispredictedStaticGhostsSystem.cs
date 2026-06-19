using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.NetCode.LowLevel;

[BurstCompile]
[UpdateInGroup(typeof(SimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct RevertMispredictedStaticGhostsSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithPresent(new Type[] { typeof(StaticGhostChangeCD) })]
	[WithChangeFilter(new Type[]
	{
		typeof(MoveToPredictedByEntityDestroyedCD),
		typeof(MoveToPredictedByCombatOrInventoryInteractionCD)
	})]
	private struct UpdateStaticGhostChangeJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MoveToPredictedByEntityDestroyedCD> __MoveToPredictedByEntityDestroyedCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD> __MoveToPredictedByCombatOrInventoryInteractionCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__MoveToPredictedByEntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByEntityDestroyedCD>(isReadOnly: true);
					__MoveToPredictedByCombatOrInventoryInteractionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__MoveToPredictedByEntityDestroyedCD_RO_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByCombatOrInventoryInteractionCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithPresent<StaticGhostChangeCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MoveToPredictedByEntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MoveToPredictedByCombatOrInventoryInteractionCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				DefaultQuery.SetChangedVersionFilter(new ComponentType[2]
				{
					new ComponentType(typeof(MoveToPredictedByEntityDestroyedCD)),
					new ComponentType(typeof(MoveToPredictedByCombatOrInventoryInteractionCD))
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
			public void Run(ref UpdateStaticGhostChangeJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateStaticGhostChangeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateStaticGhostChangeJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateStaticGhostChangeJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateStaticGhostChangeJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateStaticGhostChangeJob job, EntityManager entityManager)
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

		public ComponentLookup<StaticGhostChangeCD> staticGhostChangeLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in MoveToPredictedByEntityDestroyedCD moveToPredictedByEntityDestroyedCD, in MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD)
		{
			ref StaticGhostChangeCD valueRW = ref staticGhostChangeLookup.GetRefRW(entity).ValueRW;
			if (moveToPredictedByEntityDestroyedCD.lastInteractionTick.IsValid && (!valueRW.lastChangeTick.IsValid || moveToPredictedByEntityDestroyedCD.lastInteractionTick.IsNewerThan(valueRW.lastChangeTick)))
			{
				valueRW.lastChangeTick = moveToPredictedByEntityDestroyedCD.lastInteractionTick;
				staticGhostChangeLookup.SetComponentEnabled(entity, value: true);
			}
			if (moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick.IsValid && (!valueRW.lastChangeTick.IsValid || moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick.IsNewerThan(valueRW.lastChangeTick)))
			{
				valueRW.lastChangeTick = moveToPredictedByCombatOrInventoryInteractionCD.lastInteractionTick;
				staticGhostChangeLookup.SetComponentEnabled(entity, value: true);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByEntityDestroyedCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByCombatOrInventoryInteractionCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByEntityDestroyedCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, k));
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
	private struct RevertMispredictedStaticGhostsJob : IJobChunk
	{
		public Entity networkSnapshotAckEntity;

		[ReadOnly]
		public NativeParallelHashMap<ulong, IntPtr>.ReadOnly predictionState;

		[ReadOnly]
		public ComponentLookup<NetworkSnapshotAck> networkSnapshotAckLookup;

		[ReadOnly]
		public ComponentTypeHandle<GhostInstance> ghostInstanceTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SnapshotData> snapshotDataTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SnapshotDataBuffer> snapshotDataBufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SnapshotDynamicDataBuffer> snapshotDynamicDataBufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PredictedGhost> predictedGhostTypeHandle;

		public ComponentTypeHandle<StaticGhostChangeCD> staticGhostChangeCDTypeHandle;

		public ComponentTypeHandle<HealthCD> healthTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> objectDataTypeHandle;

		public BufferTypeHandle<ContainedObjectsBuffer> containedObjectsBufferTypeHandle;

		public SnapshotDataLookupHelper snapshotDatasLookupHelper;

		public NetworkTick currentTick;

		public uint tickRate;

		public unsafe void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			NativeArray<StaticGhostChangeCD> nativeArray = chunk.GetNativeArray(ref staticGhostChangeCDTypeHandle);
			NativeArray<PredictedGhost> nativeArray2 = chunk.GetNativeArray(ref predictedGhostTypeHandle);
			NativeArray<GhostInstance> nativeArray3 = chunk.GetNativeArray(ref ghostInstanceTypeHandle);
			bool isCreated = nativeArray2.IsCreated;
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			if (isCreated)
			{
				NetworkTick lastReceivedSnapshotByLocal = networkSnapshotAckLookup[networkSnapshotAckEntity].LastReceivedSnapshotByLocal;
				int firstGhostTypeId = nativeArray3.GetFirstGhostTypeId();
				int num = UnsafeUtility.SizeOf<Entity>();
				IntPtr item;
				bool flag = predictionState.TryGetValue(chunk.SequenceNumber, out item) && ((PredictionBackupState*)(void*)item)->ghostType == firstGhostTypeId;
				int nextIndex;
				while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
				{
					StaticGhostChangeCD staticGhostChangeCD = nativeArray[nextIndex];
					if (staticGhostChangeCD.lastChangeTick.IsValid && currentTick.TicksSince(staticGhostChangeCD.lastChangeTick) <= tickRate)
					{
						continue;
					}
					chunk.SetComponentEnabled(ref staticGhostChangeCDTypeHandle, nextIndex, value: false);
					if (flag && nextIndex < ((PredictionBackupState*)(void*)item)->entityCapacity)
					{
						int num2 = currentTick.TicksSince(lastReceivedSnapshotByLocal) + 1;
						uint tickIndexForValidTick = lastReceivedSnapshotByLocal.TickIndexForValidTick;
						for (int i = 0; i < num2; i++)
						{
							int index = (int)((tickIndexForValidTick + i) % 12);
							UnsafeUtility.MemClear(PredictionBackupState.GetEntities(item, index) + nextIndex, num);
						}
					}
				}
				return;
			}
			SnapshotDataBufferComponentLookup snapshotDataBufferComponentLookup = snapshotDatasLookupHelper.CreateSnapshotBufferLookup();
			NativeArray<SnapshotData> nativeArray4 = chunk.GetNativeArray(ref snapshotDataTypeHandle);
			BufferAccessor<SnapshotDataBuffer> bufferAccessor = chunk.GetBufferAccessor(ref snapshotDataBufferTypeHandle);
			BufferAccessor<SnapshotDynamicDataBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref snapshotDynamicDataBufferTypeHandle);
			NativeArray<HealthCD> nativeArray5 = chunk.GetNativeArray(ref healthTypeHandle);
			NativeArray<ObjectDataCD> nativeArray6 = chunk.GetNativeArray(ref objectDataTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref containedObjectsBufferTypeHandle);
			bool isCreated2 = nativeArray5.IsCreated;
			bool isCreated3 = nativeArray6.IsCreated;
			bool flag2 = chunk.Has<ChangeVariationTriggerCD>();
			bool flag3 = chunk.Has<ContainedObjectsBuffer>();
			int nextIndex2;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex2))
			{
				StaticGhostChangeCD staticGhostChangeCD2 = nativeArray[nextIndex2];
				if (!staticGhostChangeCD2.lastChangeTick.IsValid || currentTick.TicksSince(staticGhostChangeCD2.lastChangeTick) > tickRate)
				{
					chunk.SetComponentEnabled(ref staticGhostChangeCDTypeHandle, nextIndex2, value: false);
					GhostInstance ghostInstance = nativeArray3[nextIndex2];
					SnapshotData snapshotData = nativeArray4[nextIndex2];
					DynamicBuffer<SnapshotDataBuffer> snapshotBuffer = bufferAccessor[nextIndex2];
					if (isCreated2 && snapshotDataBufferComponentLookup.TryGetComponentDataFromSnapshotHistory<HealthCD>(ghostInstance.ghostType, snapshotData, in snapshotBuffer, out var componentData, currentTick, 1f))
					{
						nativeArray5[nextIndex2] = componentData;
					}
					if (flag2 && isCreated3 && snapshotDataBufferComponentLookup.TryGetComponentDataFromSnapshotHistory<ObjectDataCD>(ghostInstance.ghostType, snapshotData, in snapshotBuffer, out var componentData2, currentTick, 1f))
					{
						nativeArray6[nextIndex2] = componentData2;
					}
					if (flag3)
					{
						DynamicBuffer<SnapshotDynamicDataBuffer> dynamicDataBuffer = bufferAccessor2[nextIndex2];
						DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = bufferAccessor3[nextIndex2];
						snapshotDataBufferComponentLookup.TryCopyBufferFromSnapshotHistory(ghostInstance.ghostType, snapshotData, in snapshotBuffer, in dynamicDataBuffer, dynamicBuffer, currentTick, 1f);
					}
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
		public ComponentLookup<StaticGhostChangeCD> __StaticGhostChangeCD_RW_ComponentLookup;

		public UpdateStaticGhostChangeJob.InternalCompilerQueryAndHandleData __RevertMispredictedStaticGhostsSystem_UpdateStaticGhostChangeJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<NetworkSnapshotAck> __Unity_NetCode_NetworkSnapshotAck_RO_ComponentLookup;

		[ReadOnly]
		public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SnapshotData> __Unity_NetCode_SnapshotData_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SnapshotDataBuffer> __Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SnapshotDynamicDataBuffer> __Unity_NetCode_SnapshotDynamicDataBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PredictedGhost> __Unity_NetCode_PredictedGhost_RO_ComponentTypeHandle;

		public ComponentTypeHandle<StaticGhostChangeCD> __StaticGhostChangeCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__StaticGhostChangeCD_RW_ComponentLookup = state.GetComponentLookup<StaticGhostChangeCD>();
			__RevertMispredictedStaticGhostsSystem_UpdateStaticGhostChangeJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_NetCode_NetworkSnapshotAck_RO_ComponentLookup = state.GetComponentLookup<NetworkSnapshotAck>(isReadOnly: true);
			__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
			__Unity_NetCode_SnapshotData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnapshotData>(isReadOnly: true);
			__Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SnapshotDataBuffer>(isReadOnly: true);
			__Unity_NetCode_SnapshotDynamicDataBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SnapshotDynamicDataBuffer>(isReadOnly: true);
			__Unity_NetCode_PredictedGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PredictedGhost>(isReadOnly: true);
			__StaticGhostChangeCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StaticGhostChangeCD>();
			__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
			__ObjectDataCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>();
			__ContainedObjectsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000027B0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000027B0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000027B0_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000027B1_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000027B1_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000027B1_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_000027B2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000027B2_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000027B2_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	private SnapshotDataLookupHelper _snapshotDataLookupHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1000222391_0;

	private EntityQuery __query_1000222391_1;

	private EntityQuery __query_1000222391_2;

	private EntityQuery __query_1000222391_3;

	private EntityQuery __query_1000222391_4;

	private EntityQuery __query_1000222391_5;

	private EntityQuery __query_1000222391_6;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<GhostCollection>();
		state.RequireForUpdate<SpawnedGhostEntityMap>();
		state.RequireForUpdate<NetworkSnapshotAck>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_snapshotDataLookupHelper = new SnapshotDataLookupHelper(ref state, __query_1000222391_1.GetSingletonEntity(), __query_1000222391_2.GetSingletonEntity());
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_snapshotDataLookupHelper.Update(ref state);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateStaticGhostChangeJob
		{
			staticGhostChangeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__StaticGhostChangeCD_RW_ComponentLookup, ref state)
		}, __TypeHandle.__RevertMispredictedStaticGhostsSystem_UpdateStaticGhostChangeJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		__query_1000222391_3.TryGetSingleton<NetworkTime>(out var value);
		__query_1000222391_4.TryGetSingleton<GhostPredictionHistoryState>(out var value2);
		if (value2.PredictionState.IsCreated)
		{
			ClientServerTickRate singleton = __query_1000222391_5.GetSingleton<ClientServerTickRate>();
			state.Dependency = JobChunkExtensions.Schedule(new RevertMispredictedStaticGhostsJob
			{
				predictionState = value2.PredictionState,
				networkSnapshotAckEntity = __query_1000222391_6.GetSingletonEntity(),
				networkSnapshotAckLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_NetworkSnapshotAck_RO_ComponentLookup, ref state),
				ghostInstanceTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle, ref state),
				snapshotDataTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_NetCode_SnapshotData_RO_ComponentTypeHandle, ref state),
				snapshotDataBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle, ref state),
				snapshotDynamicDataBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__Unity_NetCode_SnapshotDynamicDataBuffer_RO_BufferTypeHandle, ref state),
				predictedGhostTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_NetCode_PredictedGhost_RO_ComponentTypeHandle, ref state),
				staticGhostChangeCDTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__StaticGhostChangeCD_RW_ComponentTypeHandle, ref state),
				healthTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle, ref state),
				objectDataTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle, ref state),
				containedObjectsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferTypeHandle, ref state),
				snapshotDatasLookupHelper = _snapshotDataLookupHelper,
				currentTick = value.ServerTick,
				tickRate = (uint)singleton.SimulationTickRate
			}, __query_1000222391_0, state.Dependency);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(UpdateStaticGhostChangeJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__RevertMispredictedStaticGhostsSystem_UpdateStaticGhostChangeJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__RevertMispredictedStaticGhostsSystem_UpdateStaticGhostChangeJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__RevertMispredictedStaticGhostsSystem_UpdateStaticGhostChangeJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__RevertMispredictedStaticGhostsSystem_UpdateStaticGhostChangeJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<HealthCD, ContainedObjectsBuffer, ChangeVariationTriggerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<StaticGhostChangeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance, SnapshotData, SnapshotDataBuffer, SnapshotDynamicDataBuffer>();
		__query_1000222391_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostCollection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1000222391_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnedGhostEntityMap>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1000222391_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1000222391_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostPredictionHistoryState>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1000222391_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1000222391_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkSnapshotAck>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1000222391_6 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000027B0_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000027B1_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000027B2_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((RevertMispredictedStaticGhostsSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((RevertMispredictedStaticGhostsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RevertMispredictedStaticGhostsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RevertMispredictedStaticGhostsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RevertMispredictedStaticGhostsSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
