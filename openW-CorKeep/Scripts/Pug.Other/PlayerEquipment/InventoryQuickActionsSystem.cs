using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerEquipment
{
	[BurstCompile]
	[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct InventoryQuickActionsSystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct TorchSwapJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<QuickSwapTorchCD> __QuickSwapTorchCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<ClientInput> __ClientInput_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__QuickSwapTorchCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<QuickSwapTorchCD>();
						__ClientInput_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClientInput>(isReadOnly: true);
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
						__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__QuickSwapTorchCD_RW_ComponentTypeHandle.Update(ref state);
						__ClientInput_RO_ComponentTypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
						__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerGhost_RO_ComponentTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientInput>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<QuickSwapTorchCD>();
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
				public void Run(ref TorchSwapJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref TorchSwapJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref TorchSwapJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref TorchSwapJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref TorchSwapJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref TorchSwapJob job, EntityManager entityManager)
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

			public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

			public Entity inventoryChangeBufferEntity;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			public NetworkTick currentTick;

			public int playerSwapItemSFXID;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref QuickSwapTorchCD quickSwapTorchCD, in ClientInput clientInput, in EquippedObjectCD equippedObjectCD, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, in PlayerGhost playerGhost)
			{
				bool flag = false;
				DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = inventoryChangeBufferLookup[inventoryChangeBufferEntity];
				if (clientInput.IsButtonStateSet(CommandInputButtonStateNames.QuickSwapTorch_HeldDown) && quickSwapTorchCD.swappedTorchFromIndex == -1)
				{
					int num = InventoryUtility.FindFirstOccurenceOfObject(ObjectID.Torch, containedObjectsBuffer, databaseBankCD, equippedObjectCD.equippedSlotIndex);
					if (num != -1)
					{
						quickSwapTorchCD.swappedTorchFromIndex = num;
						quickSwapTorchCD.swappedTorchToIndex = equippedObjectCD.equippedSlotIndex;
						dynamicBuffer.Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.Swap(entity, entity, quickSwapTorchCD.swappedTorchFromIndex, equippedObjectCD.equippedSlotIndex),
							playerEntity = entity
						});
						flag = true;
					}
				}
				else if (quickSwapTorchCD.swappedTorchFromIndex != -1 && quickSwapTorchCD.swappedTorchToIndex != -1 && !clientInput.IsButtonStateSet(CommandInputButtonStateNames.QuickSwapTorch_HeldDown))
				{
					dynamicBuffer.Add(new InventoryChangeBuffer
					{
						inventoryChangeData = Create.Swap(entity, entity, quickSwapTorchCD.swappedTorchFromIndex, quickSwapTorchCD.swappedTorchToIndex),
						playerEntity = entity
					});
					quickSwapTorchCD.swappedTorchFromIndex = -1;
					quickSwapTorchCD.swappedTorchToIndex = -1;
					flag = true;
				}
				if (flag)
				{
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.SingleAudioSFXFromTable,
							localOnlyEffect = 1,
							entity = entity,
							value1 = playerSwapItemSFXID
						}
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__QuickSwapTorchCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ClientInput_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref QuickSwapTorchCD quickSwapTorchCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<QuickSwapTorchCD>(nativeArrayPtr2, i);
						ref ClientInput clientInput = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, i);
						ref EquippedObjectCD equippedObjectCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, i);
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = bufferAccessor[i];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor2[i];
						Execute(entity, ref quickSwapTorchCD, in clientInput, in equippedObjectCD, in containedObjectsBuffer, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr6, i));
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
							ref QuickSwapTorchCD quickSwapTorchCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<QuickSwapTorchCD>(nativeArrayPtr2, nextRangeBegin);
							ref ClientInput clientInput2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, nextRangeBegin);
							ref EquippedObjectCD equippedObjectCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, nextRangeBegin);
							DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer2 = bufferAccessor[nextRangeBegin];
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor2[nextRangeBegin];
							Execute(entity2, ref quickSwapTorchCD2, in clientInput2, in equippedObjectCD2, in containedObjectsBuffer2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr6, nextRangeBegin));
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
						ref QuickSwapTorchCD quickSwapTorchCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<QuickSwapTorchCD>(nativeArrayPtr2, j);
						ref ClientInput clientInput3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, j);
						ref EquippedObjectCD equippedObjectCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, j);
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer3 = bufferAccessor[j];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor2[j];
						Execute(entity3, ref quickSwapTorchCD3, in clientInput3, in equippedObjectCD3, in containedObjectsBuffer3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr6, j));
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
						ref QuickSwapTorchCD quickSwapTorchCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<QuickSwapTorchCD>(nativeArrayPtr2, k);
						ref ClientInput clientInput4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClientInput>(nativeArrayPtr3, k);
						ref EquippedObjectCD equippedObjectCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, k);
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer4 = bufferAccessor[k];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor2[k];
						Execute(entity4, ref quickSwapTorchCD4, in clientInput4, in equippedObjectCD4, in containedObjectsBuffer4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr6, k));
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
			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			public TorchSwapJob.InternalCompilerQueryAndHandleData __PlayerEquipment_InventoryQuickActionsSystem_TorchSwapJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__PlayerEquipment_InventoryQuickActionsSystem_TorchSwapJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_0000756B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_0000756B_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000756B_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private int _playerSwapItemSFXID;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1670801576_0;

		private EntityQuery __query_1670801576_1;

		private EntityQuery __query_1670801576_2;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<InventoryChangeBuffer>();
			_playerSwapItemSFXID = SfxTableID.playerSwapItem;
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1670801576_0.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new TorchSwapJob
			{
				inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				inventoryChangeBufferEntity = __query_1670801576_1.GetSingletonEntity(),
				databaseBankCD = __query_1670801576_2.GetSingleton<PugDatabase.DatabaseBankCD>(),
				currentTick = value.ServerTick,
				playerSwapItemSFXID = _playerSwapItemSFXID
			}, __TypeHandle.__PlayerEquipment_InventoryQuickActionsSystem_TorchSwapJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(TorchSwapJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_InventoryQuickActionsSystem_TorchSwapJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_InventoryQuickActionsSystem_TorchSwapJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_InventoryQuickActionsSystem_TorchSwapJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_InventoryQuickActionsSystem_TorchSwapJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1670801576_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1670801576_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1670801576_2 = entityQueryBuilder2.Build(ref state);
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
			((InventoryQuickActionsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_0000756B_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((InventoryQuickActionsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((InventoryQuickActionsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
