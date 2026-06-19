using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using PlayerState;
using QFSW.QC;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine.Scripting;

[BurstCompile]
[UpdateInGroup(typeof(InventoryResultEvaluationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct EatableSlotConsumeResultEvaluationSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct PetCandyGivesMuchXpKey
	{
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(WaitingForEatableSlotConsumeResultCD) })]
	private struct EvaluateConsumeResultJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EquippedObjectCD> __EquippedObjectCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PetOwnerCD> __PetOwnerCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

				public BufferTypeHandle<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ManaCD> __ManaCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<HungerCD> __HungerCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__EquippedObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
					__PetOwnerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PetOwnerCD>(isReadOnly: true);
					__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
					__GhostEffectEventBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
					__ContainedObjectsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__ManaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ManaCD>();
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerStateCD>(isReadOnly: true);
					__HungerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HungerCD>();
					__SummarizedConditionEffectsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>();
					__SummarizedConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__EquippedObjectCD_RO_ComponentTypeHandle.Update(ref state);
					__PetOwnerCD_RO_ComponentTypeHandle.Update(ref state);
					__PlayerGhost_RO_ComponentTypeHandle.Update(ref state);
					__GhostEffectEventBuffer_RW_BufferTypeHandle.Update(ref state);
					__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle.Update(ref state);
					__ContainedObjectsBuffer_RW_BufferTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__ManaCD_RW_ComponentTypeHandle.Update(ref state);
					__PlayerState_PlayerStateCD_RO_ComponentTypeHandle.Update(ref state);
					__HungerCD_RW_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionEffectsBuffer_RW_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EquippedObjectCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PetOwnerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<WaitingForEatableSlotConsumeResultCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<GhostEffectEventBufferPointerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ManaCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HungerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SummarizedConditionEffectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SummarizedConditionsBuffer>();
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
			public void Run(ref EvaluateConsumeResultJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref EvaluateConsumeResultJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref EvaluateConsumeResultJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref EvaluateConsumeResultJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref EvaluateConsumeResultJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref EvaluateConsumeResultJob job, EntityManager entityManager)
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

		public ComponentLookup<WaitingForEatableSlotConsumeResultCD> waitingForEatableSlotConsumeResultLookup;

		[ReadOnly]
		public ComponentLookup<PetCandyCD> petCandyLookup;

		[ReadOnly]
		public ComponentLookup<CookedFoodCD> cookedFoodLookup;

		[ReadOnly]
		public ComponentLookup<FlowerCD> flowerLookup;

		[ReadOnly]
		public ComponentLookup<FishCD> fishLookup;

		public BufferLookup<InventoryChangeBuffer> inventoryChangeBufferLookup;

		[ReadOnly]
		public BufferLookup<InventoryChangeResultBuffer> inventoryChangeResultBufferLookup;

		public BufferLookup<HealthChangeBuffer> healthChangeBufferLookup;

		[ReadOnly]
		public BufferLookup<GivesConditionsWhenConsumedBuffer> givesConditionsWhenConsumedBufferLookup;

		public Entity inventoryChangeResultBufferEntity;

		public Entity healthChangeBufferEntity;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public ConditionsTableCD conditionsTableCD;

		public NetworkTick currentTick;

		public uint tickRate;

		public bool petCandyGivesMuchXp;

		public bool isServer;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in EquippedObjectCD equippedObjectCD, in PetOwnerCD petOwnerCD, in PlayerGhost playerGhost, ref DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer, ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD, DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer, ref HealthCD healthCD, ref ManaCD manaCD, in PlayerStateCD playerStateCD, ref HungerCD hungerCD, DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer, DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, DynamicBuffer<ConditionsBuffer> conditionsBuffer)
		{
			waitingForEatableSlotConsumeResultLookup.SetComponentEnabled(entity, value: false);
			ref readonly WaitingForEatableSlotConsumeResultCD valueRO = ref waitingForEatableSlotConsumeResultLookup.GetRefRO(entity).ValueRO;
			if (!inventoryChangeResultBufferLookup[inventoryChangeResultBufferEntity][valueRO.consumeResultIndex].inventoryChangeSuccessful)
			{
				return;
			}
			if (petCandyLookup.TryGetComponent(equippedObjectCD.equipmentPrefab, out var componentData))
			{
				int xpIncrease = (petCandyGivesMuchXp ? 100000 : componentData.xp);
				if (isServer)
				{
					PlayerController.IncreasePetXp(entity, xpIncrease, in petOwnerCD, in playerGhost, in containedObjectsBuffer, inventoryChangeBufferLookup, inventoryChangeResultBufferEntity);
				}
				return;
			}
			ObjectDataCD item = equippedObjectCD.containedObject.objectData;
			bool flag = cookedFoodLookup.HasComponent(equippedObjectCD.equipmentPrefab);
			FixedList64Bytes<ObjectDataCD> ingredients = new FixedList64Bytes<ObjectDataCD> { in item };
			if (flag)
			{
				ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(item.variation);
				ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(item.variation);
				ObjectDataCD item2 = new ObjectDataCD
				{
					objectID = primaryIngredientFromVariation,
					amount = 1
				};
				ingredients.Add(in item2);
				item2 = new ObjectDataCD
				{
					objectID = secondaryIngredientFromVariation,
					amount = 1
				};
				ingredients.Add(in item2);
			}
			using NativeArray<ConditionData> nativeArray = ConditionUIExtensions.GetConditionsOnConsume(item, ingredients, flag, entity, databaseBankCD, conditionsTableCD, flowerLookup, fishLookup, givesConditionsWhenConsumedBufferLookup, summarizedConditionsBuffer, Allocator.Temp);
			ObjectID objectID = item.objectID;
			for (int i = 0; i < nativeArray.Length; i++)
			{
				switch (nativeArray[i].conditionID)
				{
				case ConditionID.HealthAddition:
					PlayerController.HealPlayer(nativeArray[i].value, ref healthCD, in playerStateCD, in summarizedConditionEffectsBuffer);
					continue;
				case ConditionID.HealthAdditionPercentage:
				{
					int maxHealthWithConditions = healthCD.GetMaxHealthWithConditions(summarizedConditionEffectsBuffer);
					int num = (int)math.round(math.clamp((float)nativeArray[i].value / 100f * (float)maxHealthWithConditions, 0f, maxHealthWithConditions));
					PlayerController.HealPlayer(num, ref healthCD, in playerStateCD, in summarizedConditionEffectsBuffer);
					if (objectID == ObjectID.HealingPotion || objectID == ObjectID.GreaterHealingPotion)
					{
						float num2 = (float)summarizedConditionsBuffer[113].value / 10f;
						if (num2 > 0f)
						{
							EntityUtility.AddOrRefreshCondition(new ConditionData
							{
								conditionID = ConditionID.HealOverTimeFromPotion,
								value = (int)math.round((float)num * num2 / 20f),
								duration = 20f
							}, conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
						}
					}
					continue;
				}
				case ConditionID.ManaAdditionPercentage:
				{
					int maxMana = manaCD.maxMana;
					PlayerController.AddManaToPlayer((int)math.round(math.clamp((float)nativeArray[i].value / 100f * (float)maxMana, 0f, maxMana)), ref manaCD, in playerStateCD, in summarizedConditionEffectsBuffer);
					continue;
				}
				case ConditionID.HealthReduction:
					healthChangeBufferLookup[healthChangeBufferEntity].Add(new HealthChangeBuffer
					{
						healthChange = new HealthChange
						{
							entity = entity,
							amount = nativeArray[i].value
						}
					});
					continue;
				case ConditionID.ChannelVoidBreach:
				{
					EntityUtility.AddOrRefreshCondition(nativeArray[i], conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
					DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBuffer;
					GhostEffectEventBuffer item3 = new GhostEffectEventBuffer
					{
						Tick = currentTick,
						value = new EffectEventCD
						{
							effectID = EffectID.TriggerVoidBreach,
							entity = entity
						}
					};
					buffer.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item3);
					continue;
				}
				case ConditionID.HungerAddition:
					PlayerController.AddHunger(nativeArray[i].value, in playerStateCD, ref hungerCD);
					continue;
				}
				int length = conditionsBuffer.Length;
				EntityUtility.AddOrRefreshCondition(nativeArray[i], conditionsBuffer, conditionsTableCD, currentTick, tickRate, summarizedConditionsBuffer);
				if (isFirstTimeFullyPredictingTick)
				{
					bool num3 = length != conditionsBuffer.Length;
					ConditionInfoBlob conditionInfo = conditionsTableCD.GetConditionInfo(nativeArray[i].conditionID);
					if ((num3 || !conditionInfo.isUnique) && conditionInfo.effect == ConditionEffect.MaxHealthPermanent)
					{
						DynamicBuffer<GhostEffectEventBuffer> buffer2 = ghostEffectEventBuffer;
						GhostEffectEventBuffer item3 = new GhostEffectEventBuffer
						{
							Tick = currentTick,
							value = new EffectEventCD
							{
								effectID = EffectID.EatIncreaseMaxHealthItem,
								entity = entity
							}
						};
						buffer2.AddToRingBuffer(ref ghostEffectEventBufferPointerCD, in item3);
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EquippedObjectCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PetOwnerCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
			BufferAccessor<GhostEffectEventBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ManaCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HungerCD_RW_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RW_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor5 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref EquippedObjectCD equippedObjectCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, i);
					ref PetOwnerCD petOwnerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, i);
					ref PlayerGhost playerGhost = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr4, i);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = bufferAccessor[i];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, i);
					DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer = bufferAccessor2[i];
					ref HealthCD healthCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, i);
					ref ManaCD manaCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ManaCD>(nativeArrayPtr7, i);
					ref PlayerStateCD playerStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr8, i);
					ref HungerCD hungerCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr9, i);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer = bufferAccessor3[i];
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer = bufferAccessor4[i];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor5[i];
					Execute(entity, in equippedObjectCD, in petOwnerCD, in playerGhost, ref ghostEffectEventBuffer, ref ghostEffectEventBufferPointerCD, containedObjectsBuffer, ref healthCD, ref manaCD, in playerStateCD, ref hungerCD, summarizedConditionEffectsBuffer, summarizedConditionsBuffer, conditionsBuffer);
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
						ref EquippedObjectCD equippedObjectCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, nextRangeBegin);
						ref PetOwnerCD petOwnerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, nextRangeBegin);
						ref PlayerGhost playerGhost2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer2 = bufferAccessor[nextRangeBegin];
						ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, nextRangeBegin);
						DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer2 = bufferAccessor2[nextRangeBegin];
						ref HealthCD healthCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, nextRangeBegin);
						ref ManaCD manaCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ManaCD>(nativeArrayPtr7, nextRangeBegin);
						ref PlayerStateCD playerStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr8, nextRangeBegin);
						ref HungerCD hungerCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr9, nextRangeBegin);
						DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer2 = bufferAccessor3[nextRangeBegin];
						DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer2 = bufferAccessor4[nextRangeBegin];
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor5[nextRangeBegin];
						Execute(entity2, in equippedObjectCD2, in petOwnerCD2, in playerGhost2, ref ghostEffectEventBuffer2, ref ghostEffectEventBufferPointerCD2, containedObjectsBuffer2, ref healthCD2, ref manaCD2, in playerStateCD2, ref hungerCD2, summarizedConditionEffectsBuffer2, summarizedConditionsBuffer2, conditionsBuffer2);
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
					ref EquippedObjectCD equippedObjectCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, j);
					ref PetOwnerCD petOwnerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, j);
					ref PlayerGhost playerGhost3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr4, j);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer3 = bufferAccessor[j];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, j);
					DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer3 = bufferAccessor2[j];
					ref HealthCD healthCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, j);
					ref ManaCD manaCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ManaCD>(nativeArrayPtr7, j);
					ref PlayerStateCD playerStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr8, j);
					ref HungerCD hungerCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr9, j);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer3 = bufferAccessor3[j];
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer3 = bufferAccessor4[j];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor5[j];
					Execute(entity3, in equippedObjectCD3, in petOwnerCD3, in playerGhost3, ref ghostEffectEventBuffer3, ref ghostEffectEventBufferPointerCD3, containedObjectsBuffer3, ref healthCD3, ref manaCD3, in playerStateCD3, ref hungerCD3, summarizedConditionEffectsBuffer3, summarizedConditionsBuffer3, conditionsBuffer3);
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
					ref EquippedObjectCD equippedObjectCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EquippedObjectCD>(nativeArrayPtr2, k);
					ref PetOwnerCD petOwnerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PetOwnerCD>(nativeArrayPtr3, k);
					ref PlayerGhost playerGhost4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr4, k);
					DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer4 = bufferAccessor[k];
					ref GhostEffectEventBufferPointerCD ghostEffectEventBufferPointerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostEffectEventBufferPointerCD>(nativeArrayPtr5, k);
					DynamicBuffer<ContainedObjectsBuffer> containedObjectsBuffer4 = bufferAccessor2[k];
					ref HealthCD healthCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, k);
					ref ManaCD manaCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ManaCD>(nativeArrayPtr7, k);
					ref PlayerStateCD playerStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerStateCD>(nativeArrayPtr8, k);
					ref HungerCD hungerCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HungerCD>(nativeArrayPtr9, k);
					DynamicBuffer<SummarizedConditionEffectsBuffer> summarizedConditionEffectsBuffer4 = bufferAccessor3[k];
					DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer4 = bufferAccessor4[k];
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor5[k];
					Execute(entity4, in equippedObjectCD4, in petOwnerCD4, in playerGhost4, ref ghostEffectEventBuffer4, ref ghostEffectEventBufferPointerCD4, containedObjectsBuffer4, ref healthCD4, ref manaCD4, in playerStateCD4, ref hungerCD4, summarizedConditionEffectsBuffer4, summarizedConditionsBuffer4, conditionsBuffer4);
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
		public ComponentLookup<WaitingForEatableSlotConsumeResultCD> __WaitingForEatableSlotConsumeResultCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetCandyCD> __PetCandyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CookedFoodCD> __CookedFoodCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FlowerCD> __FlowerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FishCD> __FishCD_RO_ComponentLookup;

		public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<InventoryChangeResultBuffer> __Inventory_InventoryChangeResultBuffer_RO_BufferLookup;

		public BufferLookup<HealthChangeBuffer> __HealthChangeBuffer_RW_BufferLookup;

		[ReadOnly]
		public BufferLookup<GivesConditionsWhenConsumedBuffer> __GivesConditionsWhenConsumedBuffer_RO_BufferLookup;

		public EvaluateConsumeResultJob.InternalCompilerQueryAndHandleData __EatableSlotConsumeResultEvaluationSystem_EvaluateConsumeResultJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__WaitingForEatableSlotConsumeResultCD_RW_ComponentLookup = state.GetComponentLookup<WaitingForEatableSlotConsumeResultCD>();
			__PetCandyCD_RO_ComponentLookup = state.GetComponentLookup<PetCandyCD>(isReadOnly: true);
			__CookedFoodCD_RO_ComponentLookup = state.GetComponentLookup<CookedFoodCD>(isReadOnly: true);
			__FlowerCD_RO_ComponentLookup = state.GetComponentLookup<FlowerCD>(isReadOnly: true);
			__FishCD_RO_ComponentLookup = state.GetComponentLookup<FishCD>(isReadOnly: true);
			__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
			__Inventory_InventoryChangeResultBuffer_RO_BufferLookup = state.GetBufferLookup<InventoryChangeResultBuffer>(isReadOnly: true);
			__HealthChangeBuffer_RW_BufferLookup = state.GetBufferLookup<HealthChangeBuffer>();
			__GivesConditionsWhenConsumedBuffer_RO_BufferLookup = state.GetBufferLookup<GivesConditionsWhenConsumedBuffer>(isReadOnly: true);
			__EatableSlotConsumeResultEvaluationSystem_EvaluateConsumeResultJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001C21_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001C21_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001C21_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00001C22_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001C22_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001C22_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private static readonly SharedStatic<bool> _petCandyGivesMuchXp = SharedStatic<bool>.GetOrCreateUnsafe(0u, -1316441552152923558L, 0L);

	private TypeHandle __TypeHandle;

	private EntityQuery __query_385195023_0;

	private EntityQuery __query_385195023_1;

	private EntityQuery __query_385195023_2;

	private EntityQuery __query_385195023_3;

	private EntityQuery __query_385195023_4;

	private EntityQuery __query_385195023_5;

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("enablePetCandyGivesMuchXp", "Pet candy will give much more xp.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void EnablePetCandyGivesMuchXp(bool value)
	{
		_petCandyGivesMuchXp.Data = value;
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<HealthChangeBuffer>();
		state.RequireForUpdate<InventoryChangeBuffer>();
		state.RequireForUpdate<ClientServerTickRate>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_385195023_0.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new EvaluateConsumeResultJob
		{
			waitingForEatableSlotConsumeResultLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WaitingForEatableSlotConsumeResultCD_RW_ComponentLookup, ref state),
			petCandyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PetCandyCD_RO_ComponentLookup, ref state),
			cookedFoodLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CookedFoodCD_RO_ComponentLookup, ref state),
			flowerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FlowerCD_RO_ComponentLookup, ref state),
			fishLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FishCD_RO_ComponentLookup, ref state),
			inventoryChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state),
			inventoryChangeResultBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeResultBuffer_RO_BufferLookup, ref state),
			healthChangeBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HealthChangeBuffer_RW_BufferLookup, ref state),
			givesConditionsWhenConsumedBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GivesConditionsWhenConsumedBuffer_RO_BufferLookup, ref state),
			inventoryChangeResultBufferEntity = __query_385195023_1.GetSingletonEntity(),
			healthChangeBufferEntity = __query_385195023_2.GetSingletonEntity(),
			databaseBankCD = __query_385195023_3.GetSingleton<PugDatabase.DatabaseBankCD>(),
			conditionsTableCD = __query_385195023_4.GetSingleton<ConditionsTableCD>(),
			currentTick = value.ServerTick,
			isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick,
			tickRate = (uint)__query_385195023_5.GetSingleton<ClientServerTickRate>().SimulationTickRate,
			petCandyGivesMuchXp = _petCandyGivesMuchXp.Data,
			isServer = state.WorldUnmanaged.IsServer()
		}, __TypeHandle.__EatableSlotConsumeResultEvaluationSystem_EvaluateConsumeResultJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(EvaluateConsumeResultJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__EatableSlotConsumeResultEvaluationSystem_EvaluateConsumeResultJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__EatableSlotConsumeResultEvaluationSystem_EvaluateConsumeResultJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__EatableSlotConsumeResultEvaluationSystem_EvaluateConsumeResultJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__EatableSlotConsumeResultEvaluationSystem_EvaluateConsumeResultJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_385195023_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_385195023_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_385195023_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_385195023_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_385195023_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_385195023_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00001C21_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001C22_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EatableSlotConsumeResultEvaluationSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EatableSlotConsumeResultEvaluationSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EatableSlotConsumeResultEvaluationSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
