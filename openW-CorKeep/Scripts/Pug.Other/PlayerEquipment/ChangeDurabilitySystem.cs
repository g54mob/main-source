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
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateBefore(typeof(InventorySystemGroup))]
	[UpdateInGroup(typeof(EndPredictedSimulationSystemGroup))]
	public struct ChangeDurabilitySystem : ISystem, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAny(new Type[]
		{
			typeof(IncreaseDurabilityOfEquippedTriggerCD),
			typeof(ReduceDurabilityOfEquippedTriggerCD)
		})]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct ChangeDurabilityOfHeldEquipmentJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerInvincibilityCD> __PlayerInvincibilityCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

					public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
						__PlayerInvincibilityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerInvincibilityCD>(isReadOnly: true);
						__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
						__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
						__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
						__PlayerInvincibilityCD_RO_ComponentTypeHandle.Update(ref state);
						__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
						__RandomCD_RW_ComponentTypeHandle.Update(ref state);
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
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<IncreaseDurabilityOfEquippedTriggerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAny<ReduceDurabilityOfEquippedTriggerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerInvincibilityCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquippedObjectCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
				public void Run(ref ChangeDurabilityOfHeldEquipmentJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ChangeDurabilityOfHeldEquipmentJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ChangeDurabilityOfHeldEquipmentJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ChangeDurabilityOfHeldEquipmentJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ChangeDurabilityOfHeldEquipmentJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ChangeDurabilityOfHeldEquipmentJob job, EntityManager entityManager)
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

			public ComponentLookup<IncreaseDurabilityOfEquippedTriggerCD> increaseDurabilityOfEquippedLookup;

			public ComponentLookup<ReduceDurabilityOfEquippedTriggerCD> reduceDurabilityOfEquippedLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> durabilityLookup;

			[ReadOnly]
			public ComponentLookup<GodModeCD> godModeLookup;

			public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

			public Entity inventoryChangeBufferEntity;

			public NetworkTick currentTick;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, in GhostInstance ghostInstance, in PlayerInvincibilityCD playerInvincibilityCD, in EquippedObjectCD equippedObjectCD, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, ref RandomCD randomCD, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, in PlayerGhost playerGhost)
			{
				increaseDurabilityOfEquippedLookup.SetComponentEnabled(entity, value: false);
				RefRW<IncreaseDurabilityOfEquippedTriggerCD> refRW = increaseDurabilityOfEquippedLookup.GetRefRW(entity);
				ref IncreaseDurabilityOfEquippedTriggerCD valueRW = ref refRW.ValueRW;
				refRW = increaseDurabilityOfEquippedLookup.GetRefRW(entity);
				int triggerCounter = refRW.ValueRW.triggerCounter;
				valueRW = default(IncreaseDurabilityOfEquippedTriggerCD);
				reduceDurabilityOfEquippedLookup.SetComponentEnabled(entity, value: false);
				RefRW<ReduceDurabilityOfEquippedTriggerCD> refRW2 = reduceDurabilityOfEquippedLookup.GetRefRW(entity);
				ref ReduceDurabilityOfEquippedTriggerCD valueRW2 = ref refRW2.ValueRW;
				refRW2 = reduceDurabilityOfEquippedLookup.GetRefRW(entity);
				int triggerCounter2 = refRW2.ValueRW.triggerCounter;
				valueRW2 = default(ReduceDurabilityOfEquippedTriggerCD);
				if (equippedObjectCD.containedObject.objectID == ObjectID.None || !durabilityLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var componentData) || equippedObjectCD.containedObject.objectData.amount <= 0)
				{
					return;
				}
				int value = summarizedConditionsBuffer[252].value;
				DynamicBuffer<InventoryChangeBuffer> dynamicBuffer = inventoryChangeBufferLookup[inventoryChangeBufferEntity];
				int num = equippedObjectCD.containedObject.objectData.amount;
				if (value > 0)
				{
					num = math.clamp(equippedObjectCD.containedObject.objectData.amount + value * triggerCounter, 0, componentData.maxDurability * ((!componentData.IsReinforced(num)) ? 1 : 2));
					dynamicBuffer.Add(new InventoryChangeBuffer
					{
						inventoryChangeData = Create.SetAmount(entity, equippedObjectCD.equippedSlotIndex, equippedObjectCD.containedObject.objectID, num),
						playerEntity = entity
					});
				}
				if (playerInvincibilityCD.isInvincible || godModeLookup.IsComponentEnabled(entity))
				{
					return;
				}
				float num2 = (float)summarizedConditionsBuffer[117].value / 100f;
				if (randomCD.Value.NextFloat() < num2 || equippedObjectCD.containedObject.objectID == ObjectID.None || !durabilityLookup.HasComponent(equippedObjectCD.equipmentPrefab))
				{
					return;
				}
				num = math.max(num - triggerCounter2, 0);
				if (num <= 0)
				{
					if (equippedObjectCD.containedObject.objectData.amount > 0)
					{
						DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = currentTick,
							value = new EffectEventCD
							{
								effectID = EffectID.EquipmentBreak,
								localOnlyEffect = 1,
								entity = entity
							}
						};
						buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
						dynamicBuffer.Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.SetAmount(entity, equippedObjectCD.equippedSlotIndex, equippedObjectCD.containedObject.objectID, 0),
							playerEntity = entity
						});
						dynamicBuffer.Add(new InventoryChangeBuffer
						{
							inventoryChangeData = Create.TryReplaceBrokenObject(entity, equippedObjectCD.equippedSlotIndex),
							playerEntity = entity
						});
					}
				}
				else
				{
					dynamicBuffer.Add(new InventoryChangeBuffer
					{
						inventoryChangeData = Create.SetAmount(entity, equippedObjectCD.equippedSlotIndex, equippedObjectCD.containedObject.objectID, num),
						playerEntity = entity
					});
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerInvincibilityCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
				BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref GhostInstance ghostInstance = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, i);
						ref PlayerInvincibilityCD playerInvincibilityCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr3, i);
						ref EquippedObjectCD equippedObjectCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, i);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = bufferAccessor[i];
						ref RandomCD randomCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, i);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor2[i];
						Execute(entity, in ghostInstance, in playerInvincibilityCD, in equippedObjectCD, in summarizedConditionsBuffer, ref randomCD, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, i));
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
							ref GhostInstance ghostInstance2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, nextRangeBegin);
							ref PlayerInvincibilityCD playerInvincibilityCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr3, nextRangeBegin);
							ref EquippedObjectCD equippedObjectCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, nextRangeBegin);
							DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer2 = bufferAccessor[nextRangeBegin];
							ref RandomCD randomCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, nextRangeBegin);
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor2[nextRangeBegin];
							Execute(entity2, in ghostInstance2, in playerInvincibilityCD2, in equippedObjectCD2, in summarizedConditionsBuffer2, ref randomCD2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, nextRangeBegin));
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
						ref GhostInstance ghostInstance3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, j);
						ref PlayerInvincibilityCD playerInvincibilityCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr3, j);
						ref EquippedObjectCD equippedObjectCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, j);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer3 = bufferAccessor[j];
						ref RandomCD randomCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, j);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor2[j];
						Execute(entity3, in ghostInstance3, in playerInvincibilityCD3, in equippedObjectCD3, in summarizedConditionsBuffer3, ref randomCD3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, j));
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
						ref GhostInstance ghostInstance4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr2, k);
						ref PlayerInvincibilityCD playerInvincibilityCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr3, k);
						ref EquippedObjectCD equippedObjectCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr4, k);
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer4 = bufferAccessor[k];
						ref RandomCD randomCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, k);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor2[k];
						Execute(entity4, in ghostInstance4, in playerInvincibilityCD4, in equippedObjectCD4, in summarizedConditionsBuffer4, ref randomCD4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, k));
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
		[WithAll(new Type[]
		{
			typeof(ReduceDurabilityOfAllEquipmentTriggerCD),
			typeof(Simulate)
		})]
		private struct ReduceDurabilityOfAllEquipmentJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					[ReadOnly]
					public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

					public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<EquipmentCD> __EquipmentCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerInvincibilityCD> __PlayerInvincibilityCD_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

					public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

					public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

					[ReadOnly]
					public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

					[ReadOnly]
					public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
						__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
						__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
						__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
						__EquipmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquipmentCD>(isReadOnly: true);
						__PlayerInvincibilityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerInvincibilityCD>(isReadOnly: true);
						__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
						__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
						__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
					}

					public void Update(ref SystemState state)
					{
						__Unity_Entities_Entity_TypeHandle.Update(ref state);
						__RandomCD_RW_ComponentTypeHandle.Update(ref state);
						__HealthCD_RO_ComponentTypeHandle.Update(ref state);
						__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle.Update(ref state);
						__EquipmentCD_RO_ComponentTypeHandle.Update(ref state);
						__PlayerInvincibilityCD_RO_ComponentTypeHandle.Update(ref state);
						__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
						__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
						__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
						__PlayerGhost_RO_ComponentTypeHandle.Update(ref state);
						__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionEffectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<EquipmentCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerInvincibilityCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReduceDurabilityOfAllEquipmentTriggerCD>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
				public void Run(ref ReduceDurabilityOfAllEquipmentJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ReduceDurabilityOfAllEquipmentJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ReduceDurabilityOfAllEquipmentJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ReduceDurabilityOfAllEquipmentJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ReduceDurabilityOfAllEquipmentJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ReduceDurabilityOfAllEquipmentJob job, EntityManager entityManager)
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

			[ReadOnly]
			public ComponentLookup<DurabilityCD> durabilityLookup;

			[ReadOnly]
			public ComponentLookup<GodModeCD> godModeLookup;

			public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

			public Entity inventoryChangeBufferEntity;

			public PugDatabase.DatabaseBankCD databaseBankCD;

			public NetworkTick currentTick;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(Entity entity, ref RandomCD randomCD, in HealthCD healthCD, in DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer, in EquipmentCD equipmentCD, in PlayerInvincibilityCD playerInvincibilityCD, in DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, in PlayerGhost playerGhost, in DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer)
			{
				reduceDurabilityOfAllEquipmentLookup.SetComponentEnabled(entity, value: false);
				ref ReduceDurabilityOfAllEquipmentTriggerCD valueRW = ref reduceDurabilityOfAllEquipmentLookup.GetRefRW(entity).ValueRW;
				int num = valueRW.damage;
				float percentage = valueRW.percentage;
				valueRW = default(ReduceDurabilityOfAllEquipmentTriggerCD);
				float num2 = (float)summarizedConditionsBuffer[118].value / 100f;
				if (randomCD.Value.NextFloat() < num2 || playerInvincibilityCD.isInvincible || godModeLookup.IsComponentEnabled(entity))
				{
					num = 0;
				}
				int maxHealthWithConditions = healthCD.GetMaxHealthWithConditions(summarizedConditionEffectsBuffer);
				if ((float)num < (float)maxHealthWithConditions * 0.03f)
				{
					num = 0;
				}
				if (num != 0 || percentage != 0f)
				{
					float num3 = math.clamp((float)num / (float)maxHealthWithConditions, 0f, 1f);
					int flatDurabilityLoss = (int)math.max(1f, math.round(num3 * 5f));
					DynamicBuffer<InventoryChangeBuffer> inventoryChangeBuffer = inventoryChangeBufferLookup[inventoryChangeBufferEntity];
					if ((0u | (ReduceDurabilityOfEquipment(entity, equipmentCD.helmSlotIndex, containedObjectsBuffer, flatDurabilityLoss, percentage, inventoryChangeBuffer) ? 1u : 0u) | (ReduceDurabilityOfEquipment(entity, equipmentCD.breastSlotIndex, containedObjectsBuffer, flatDurabilityLoss, percentage, inventoryChangeBuffer) ? 1u : 0u) | (ReduceDurabilityOfEquipment(entity, equipmentCD.pantsSlotIndex, containedObjectsBuffer, flatDurabilityLoss, percentage, inventoryChangeBuffer) ? 1u : 0u)) != 0)
					{
						DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
						GhostEffectEventBuffer item = new GhostEffectEventBuffer
						{
							Tick = currentTick,
							value = new EffectEventCD
							{
								effectID = EffectID.EquipmentBreak,
								entity = entity,
								localOnlyEffect = 1
							}
						};
						buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item);
					}
				}
			}

			private bool ReduceDurabilityOfEquipment(Entity playerEntity, int slotIndex, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, int flatDurabilityLoss, float percentageDurabilityLoss, DynamicBuffer<InventoryChangeBuffer> inventoryChangeBuffer)
			{
				ContainedObjectsBuffer containedObjectsBuffer2 = containedObjectsBuffer[slotIndex];
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer2.objectID, databaseBankCD.databaseBankBlob, containedObjectsBuffer2.variation);
				if (containedObjectsBuffer2.amount <= 0 || !durabilityLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
				{
					return false;
				}
				int num = (int)math.round((float)componentData.maxDurability * percentageDurabilityLoss);
				int num2 = math.max(containedObjectsBuffer2.amount - flatDurabilityLoss - num, 0);
				if (num2 > 0)
				{
					inventoryChangeBuffer.Add(new InventoryChangeBuffer
					{
						inventoryChangeData = Create.SetAmount(playerEntity, slotIndex, containedObjectsBuffer2.objectID, num2),
						playerEntity = playerEntity
					});
					return false;
				}
				inventoryChangeBuffer.Add(new InventoryChangeBuffer
				{
					inventoryChangeData = Create.SetAmount(playerEntity, slotIndex, containedObjectsBuffer2.objectID, 0),
					playerEntity = playerEntity
				});
				return true;
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
				IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
				BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle);
				IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquipmentCD_RO_ComponentTypeHandle);
				IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerInvincibilityCD_RO_ComponentTypeHandle);
				BufferAccessor<ContainedObjectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
				BufferAccessor<GhostEffectEventBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
				IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
				IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
				BufferAccessor<SummarizedConditionsBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
						ref RandomCD randomCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr2, i);
						ref HealthCD healthCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, i);
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer = bufferAccessor[i];
						ref EquipmentCD equipmentCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, i);
						ref PlayerInvincibilityCD playerInvincibilityCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr5, i);
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = bufferAccessor2[i];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor3[i];
						Execute(entity, ref randomCD, in healthCD, in summarizedConditionEffectsBuffer, in equipmentCD, in playerInvincibilityCD, in containedObjectsBuffer, ref ghostEffectEventBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, i), bufferAccessor4[i]);
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
							ref RandomCD randomCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr2, nextRangeBegin);
							ref HealthCD healthCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, nextRangeBegin);
							DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer2 = bufferAccessor[nextRangeBegin];
							ref EquipmentCD equipmentCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, nextRangeBegin);
							ref PlayerInvincibilityCD playerInvincibilityCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr5, nextRangeBegin);
							DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer2 = bufferAccessor2[nextRangeBegin];
							DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor3[nextRangeBegin];
							Execute(entity2, ref randomCD2, in healthCD2, in summarizedConditionEffectsBuffer2, in equipmentCD2, in playerInvincibilityCD2, in containedObjectsBuffer2, ref ghostEffectEventBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, nextRangeBegin), bufferAccessor4[nextRangeBegin]);
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
						ref RandomCD randomCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr2, j);
						ref HealthCD healthCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, j);
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer3 = bufferAccessor[j];
						ref EquipmentCD equipmentCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, j);
						ref PlayerInvincibilityCD playerInvincibilityCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr5, j);
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer3 = bufferAccessor2[j];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor3[j];
						Execute(entity3, ref randomCD3, in healthCD3, in summarizedConditionEffectsBuffer3, in equipmentCD3, in playerInvincibilityCD3, in containedObjectsBuffer3, ref ghostEffectEventBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, j), bufferAccessor4[j]);
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
						ref RandomCD randomCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr2, k);
						ref HealthCD healthCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, k);
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer4 = bufferAccessor[k];
						ref EquipmentCD equipmentCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquipmentCD>(nativeArrayPtr4, k);
						ref PlayerInvincibilityCD playerInvincibilityCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerInvincibilityCD>(nativeArrayPtr5, k);
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer4 = bufferAccessor2[k];
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor3[k];
						Execute(entity4, ref randomCD4, in healthCD4, in summarizedConditionEffectsBuffer4, in equipmentCD4, in playerInvincibilityCD4, in containedObjectsBuffer4, ref ghostEffectEventBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr7, k), bufferAccessor4[k]);
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
			public ComponentLookup<IncreaseDurabilityOfEquippedTriggerCD> __PlayerEquipment_IncreaseDurabilityOfEquippedTriggerCD_RW_ComponentLookup;

			public ComponentLookup<ReduceDurabilityOfEquippedTriggerCD> __PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DurabilityCD> __DurabilityCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<GodModeCD> __GodModeCD_RO_ComponentLookup;

			public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

			public ChangeDurabilityOfHeldEquipmentJob.InternalCompilerQueryAndHandleData __PlayerEquipment_ChangeDurabilitySystem_ChangeDurabilityOfHeldEquipmentJob_WithDefaultQuery_JobEntityTypeHandle;

			public ComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD> __PlayerEquipment_ReduceDurabilityOfAllEquipmentTriggerCD_RW_ComponentLookup;

			public ReduceDurabilityOfAllEquipmentJob.InternalCompilerQueryAndHandleData __PlayerEquipment_ChangeDurabilitySystem_ReduceDurabilityOfAllEquipmentJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__PlayerEquipment_IncreaseDurabilityOfEquippedTriggerCD_RW_ComponentLookup = state.GetComponentLookup<IncreaseDurabilityOfEquippedTriggerCD>();
				__PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup = state.GetComponentLookup<ReduceDurabilityOfEquippedTriggerCD>();
				__DurabilityCD_RO_ComponentLookup = state.GetComponentLookup<DurabilityCD>(isReadOnly: true);
				__GodModeCD_RO_ComponentLookup = state.GetComponentLookup<GodModeCD>(isReadOnly: true);
				__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
				__PlayerEquipment_ChangeDurabilitySystem_ChangeDurabilityOfHeldEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
				__PlayerEquipment_ReduceDurabilityOfAllEquipmentTriggerCD_RW_ComponentLookup = state.GetComponentLookup<ReduceDurabilityOfAllEquipmentTriggerCD>();
				__PlayerEquipment_ChangeDurabilitySystem_ReduceDurabilityOfAllEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00007476_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00007476_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00007476_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnUpdate_00007477_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00007477_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00007477_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

		private EntityQuery __query_1758100231_0;

		private EntityQuery __query_1758100231_1;

		private EntityQuery __query_1758100231_2;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<InventoryChangeBuffer>();
			state.RequireForUpdate<ServerSeedCD>();
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			__query_1758100231_0.TryGetSingleton<NetworkTime>(out var value);
			state.Dependency = __ScheduleViaJobChunkExtension_0(new ChangeDurabilityOfHeldEquipmentJob
			{
				increaseDurabilityOfEquippedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_IncreaseDurabilityOfEquippedTriggerCD_RW_ComponentLookup, ref state),
				reduceDurabilityOfEquippedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_ReduceDurabilityOfEquippedTriggerCD_RW_ComponentLookup, ref state),
				durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
				godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
				currentTick = value.ServerTick,
				inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				inventoryChangeBufferEntity = __query_1758100231_1.GetSingletonEntity()
			}, __TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ChangeDurabilityOfHeldEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = __ScheduleViaJobChunkExtension_1(new ReduceDurabilityOfAllEquipmentJob
			{
				reduceDurabilityOfAllEquipmentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerEquipment_ReduceDurabilityOfAllEquipmentTriggerCD_RW_ComponentLookup, ref state),
				durabilityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DurabilityCD_RO_ComponentLookup, ref state),
				godModeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GodModeCD_RO_ComponentLookup, ref state),
				inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
				inventoryChangeBufferEntity = __query_1758100231_1.GetSingletonEntity(),
				databaseBankCD = __query_1758100231_2.GetSingleton<PugDatabase.DatabaseBankCD>(),
				currentTick = value.ServerTick
			}, __TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ReduceDurabilityOfAllEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ChangeDurabilityOfHeldEquipmentJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ChangeDurabilityOfHeldEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ChangeDurabilityOfHeldEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ChangeDurabilityOfHeldEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ChangeDurabilityOfHeldEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_1(ReduceDurabilityOfAllEquipmentJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ReduceDurabilityOfAllEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ReduceDurabilityOfAllEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ReduceDurabilityOfAllEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerEquipment_ChangeDurabilitySystem_ReduceDurabilityOfAllEquipmentJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1758100231_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1758100231_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1758100231_2 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_00007476_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00007477_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((ChangeDurabilitySystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ChangeDurabilitySystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ChangeDurabilitySystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}
	}
}
