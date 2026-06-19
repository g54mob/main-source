using System;
using System.Runtime.CompilerServices;
using Affixes.Components;
using Pug.Automation;
using PugScan;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SerializationSystemGroup))]
public class DeserializeComponentsSystem : SystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_0_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> database;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public BufferLookup<ContainedObjectsSerializedBuffer> containedObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsAuxIndexSerializedBuffer> containedAuxObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedObjectsNonSerializedBufferLookup;

		[ReadOnly]
		public BufferLookup<ConditionsSerializedBuffer> conditionsBufferLookup;

		[ReadOnly]
		public BufferLookup<ConditionsBuffer> conditionsNonSerializedBufferLookup;

		[ReadOnly]
		public BufferLookup<AffixSerializedBuffer> affixBufferLookup;

		[ReadOnly]
		public BufferLookup<ActiveAffixStateBuffer> activeAffixStateNonSerializedBufferLookup;

		[ReadOnly]
		public BufferLookup<ActiveAffixConditionsBuffer> activeAffixConditionNonSerializedBufferLookup;

		[ReadOnly]
		public BufferLookup<DropsLootSerializedBuffer> dropsLootBufferLookup;

		[ReadOnly]
		public BufferLookup<DropsLootBuffer> dropsLootNonSerializedBufferLookup;

		[ReadOnly]
		public BufferLookup<DescriptionSerializedBuffer> descriptionBufferLookup;

		[ReadOnly]
		public BufferLookup<DescriptionBuffer> descriptionNonSerializedBufferLookup;

		public ConditionsTableCD conditionsTable;

		[ReadOnly]
		public BufferLookup<CraftingByRecipeSlotBuffer> craftingWithRecipeSlotBufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingTimerSlotBuffer> craftingTimerSlotBufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingByConsumedObjectSlotBuffer> craftingByConsumedObjectSlotBufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingSlotTimerSerialized> craftingSlotTimerSerializedLookup;

		[ReadOnly]
		public BufferLookup<CraftingSlotByRecipesSerialized> craftingSlotRecipesSerializedLookup;

		[ReadOnly]
		public BufferLookup<CraftingSlotByConsumedObjectsSerialized> craftingSlotObjectsSerializedLookup;

		[ReadOnly]
		public ComponentLookup<ObjectFilteringCD> moverFilterLookup;

		[ReadOnly]
		public BufferLookup<FilteringSerializedBuffer> filteringSerializedLookup;

		[ReadOnly]
		public ComponentLookup<PugAutomationEnabledMoverSyncedCD> pugAutomationMoverOrchestratorSyncedLookup;

		[ReadOnly]
		public ComponentLookup<MoverOrchestratorSerialized> moverOrchestratorSerializedLookup;

		public ObjectLookupWriterCD objectLookupWriterCD;

		[ReadOnly]
		public ComponentLookup<MoveeSerialized> moveeBigEntitySerializedLookup;

		[ReadOnly]
		public ComponentLookup<MoveeBigEntityCD> moveeBigEntityLookup;

		public Season currentSeason;

		public NetworkTick currentTick;

		public uint tickRate;

		public EntityArchetype tryMoveToDisabledArchetype;

		public bool printMissingComponentErrors;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<Translation> __translationTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataSerializedCD> __objectDataTypeHandle;

		[ReadOnly]
		public ComponentLookup<RotationSerializedCD> __RotationSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SeasonObjectCD> __SeasonObjectCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CharacterGuidSerializedCD> __CharacterGuidSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CreateNewGuidCD> __CreateNewGuidCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByCharacterGuidSerializedCD> __ClaimedByCharacterGuidSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByCharacterGuidCD> __ClaimedByCharacterGuidCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGuidSerializedCD> __PlayerGuidSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByPlayerGuidSerializedCD> __ClaimedByPlayerGuidSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByPlayerGuidCD> __ClaimedByPlayerGuidCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthSerializedCD> __HealthSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GrowingSerializedCD> __GrowingSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GrowingCD> __GrowingCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HungerSerializedCD> __HungerSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HungerCD> __HungerCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LootTableSerializedCD> __LootTableSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DropsLootFromLootTableCD> __DropsLootFromLootTableCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PaintableObjectSerializedCD> __PaintableObjectSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PaintableObjectCD> __PaintableObjectCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedStateSerializedCD> __BreedStateSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> __MealsEatenCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleSerializedCD> __BreedToggleSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleCD> __BreedToggleCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HasBeenDiscoveredSerializedCD> __HasBeenDiscoveredSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CanBeDiscoveredCD> __CanBeDiscoveredCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnStateCD> __SpawnStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CustomSceneObjectSerializedCD> __CustomSceneObjectSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ActiveEquipmentPresetSerializedCD> __ActiveEquipmentPresetSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ActiveEquipmentPresetCD> __ActiveEquipmentPresetCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NameSerializedCD> __NameSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NameCD> __NameCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerSerializedCD> __PlayerSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerLastSessionSerializedCD> __PlayerLastSessionSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnPointCD> __SpawnPointCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeBossSegmentSerializedCD> __SnakeBossSegmentSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeSegmentCD> __SnakeSegmentCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmunityZoneShapeSerializedCD> __ImmunityZoneShapeSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmunityZoneCD> __ImmunityZoneCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] in Translation translation, [NoAlias] in ObjectDataSerializedCD objectData)
		{
			ecb.DestroyEntity(entityInQueryIndex, entity);
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.ObjectID, database, objectData.Variation);
			if (primaryPrefabEntity == Entity.Null)
			{
				return;
			}
			if (__RotationSerializedCD_ComponentLookup.HasComponent(entity))
			{
				DirectionCD directionCD = new DirectionCD
				{
					direction = __RotationSerializedCD_ComponentLookup[entity].Value
				};
				objectLookupWriterCD.Remove(ecb, entityInQueryIndex, objectData.ObjectID, objectData.Variation, translation.Value, hasDirection: true, directionCD);
			}
			else
			{
				objectLookupWriterCD.Remove(ecb, entityInQueryIndex, objectData.ObjectID, objectData.Variation, translation.Value, hasDirection: false, default(DirectionCD));
			}
			if (__SeasonObjectCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				SeasonObjectCD seasonObjectCD = __SeasonObjectCD_ComponentLookup[primaryPrefabEntity];
				if (seasonObjectCD.removeFromWorldWhenOutOfSeason && seasonObjectCD.belongsToSeason != currentSeason)
				{
					return;
				}
			}
			Entity entity2 = EntityUtility.CreateEntity(ecb, entityInQueryIndex, translation.Value, objectData.ObjectID, objectData.Amount, database, objectData.Variation);
			if (entity2 == Entity.Null)
			{
				return;
			}
			Entity e = ecb.CreateEntity(entityInQueryIndex, tryMoveToDisabledArchetype);
			ecb.SetComponent(entityInQueryIndex, e, new TryMoveDeserializedEntityToDisabledCD
			{
				targetEntity = entity2
			});
			FixedList64Bytes<ComponentType> other = default(FixedList64Bytes<ComponentType>);
			if (__CharacterGuidSerializedCD_ComponentLookup.HasComponent(entity) && __CreateNewGuidCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				CharacterGuidSerializedCD characterGuidSerializedCD = __CharacterGuidSerializedCD_ComponentLookup[entity];
				if (characterGuidSerializedCD.IsCreated)
				{
					ecb.SetComponent(entityInQueryIndex, entity2, new CharacterGuidCD
					{
						Value = characterGuidSerializedCD.Value
					});
					ecb.RemoveComponent<CreateNewGuidCD>(entityInQueryIndex, entity2);
				}
			}
			if (__ClaimedByCharacterGuidSerializedCD_ComponentLookup.HasComponent(entity) && __ClaimedByCharacterGuidCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				ClaimedByCharacterGuidSerializedCD claimedByCharacterGuidSerializedCD = __ClaimedByCharacterGuidSerializedCD_ComponentLookup[entity];
				ecb.SetComponent(entityInQueryIndex, entity2, new ClaimedByCharacterGuidCD
				{
					characterGuid = claimedByCharacterGuidSerializedCD.Value
				});
			}
			if (__PlayerGuidSerializedCD_ComponentLookup.HasComponent(entity) && __CreateNewGuidCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				PlayerGuidSerializedCD playerGuidSerializedCD = __PlayerGuidSerializedCD_ComponentLookup[entity];
				if (playerGuidSerializedCD.IsCreated)
				{
					ecb.SetComponent(entityInQueryIndex, entity2, new PlayerGuidCD
					{
						Value = playerGuidSerializedCD.Value
					});
					ecb.RemoveComponent<CreateNewGuidCD>(entityInQueryIndex, entity2);
				}
			}
			if (__ClaimedByPlayerGuidSerializedCD_ComponentLookup.HasComponent(entity) && __ClaimedByPlayerGuidCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				ClaimedByPlayerGuidSerializedCD claimedByPlayerGuidSerializedCD = __ClaimedByPlayerGuidSerializedCD_ComponentLookup[entity];
				ecb.SetComponent(entityInQueryIndex, entity2, new ClaimedByPlayerGuidCD
				{
					playerGuid = claimedByPlayerGuidSerializedCD.Value
				});
			}
			if (__HealthSerializedCD_ComponentLookup.HasComponent(entity) && __HealthCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				HealthCD component = __HealthCD_ComponentLookup[primaryPrefabEntity];
				HealthSerializedCD healthSerializedCD = __HealthSerializedCD_ComponentLookup[entity];
				component.health = (int)math.round((float)component.maxHealth * healthSerializedCD.Value);
				ecb.SetComponent(entityInQueryIndex, entity2, component);
			}
			if (__GrowingSerializedCD_ComponentLookup.HasComponent(entity) && __GrowingCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				GrowingCD component2 = __GrowingCD_ComponentLookup[primaryPrefabEntity];
				GrowingSerializedCD growingSerializedCD = __GrowingSerializedCD_ComponentLookup[entity];
				component2.currentStage = growingSerializedCD.Stage;
				component2.grownTimeToApplyToTimer = growingSerializedCD.GrowTime;
				ecb.SetComponent(entityInQueryIndex, entity2, component2);
			}
			if (craftingSlotTimerSerializedLookup.HasBuffer(entity) && craftingTimerSlotBufferLookup.HasBuffer(primaryPrefabEntity))
			{
				NativeArray<CraftingTimerSlotBuffer> v257 = craftingTimerSlotBufferLookup[primaryPrefabEntity].ToNativeArray(Allocator.Temp);
				DynamicBuffer<CraftingSlotTimerSerialized> dynamicBuffer = craftingSlotTimerSerializedLookup[entity];
				int num = math.min(dynamicBuffer.Length, v257.Length);
				for (int i = 0; i < num; i++)
				{
					CraftingTimerSlotBuffer value = v257[i];
					value.timeLeftToCraft = dynamicBuffer[i].TimeLeftToCraft;
					v257[i] = value;
				}
				ecb.SetBuffer<CraftingTimerSlotBuffer>(entityInQueryIndex, entity2).CopyFrom(v257);
			}
			if (craftingSlotObjectsSerializedLookup.HasBuffer(entity) && craftingByConsumedObjectSlotBufferLookup.HasBuffer(primaryPrefabEntity))
			{
				NativeArray<CraftingByConsumedObjectSlotBuffer> v258 = craftingByConsumedObjectSlotBufferLookup[primaryPrefabEntity].ToNativeArray(Allocator.Temp);
				DynamicBuffer<CraftingSlotByConsumedObjectsSerialized> dynamicBuffer2 = craftingSlotObjectsSerializedLookup[entity];
				int num2 = math.min(dynamicBuffer2.Length, v258.Length);
				for (int j = 0; j < num2; j++)
				{
					CraftingByConsumedObjectSlotBuffer value2 = v258[j];
					value2.previousConsumedItem.objectData = dynamicBuffer2[j].ConsumedObject.ObjectData;
					value2.previousConsumedItem.auxDataIndex = dynamicBuffer2[j].ConsumedObjectAuxIndex.Value;
					v258[j] = value2;
				}
				ecb.SetBuffer<CraftingByConsumedObjectSlotBuffer>(entityInQueryIndex, entity2).CopyFrom(v258);
			}
			if (craftingSlotRecipesSerializedLookup.HasBuffer(entity) && craftingWithRecipeSlotBufferLookup.HasBuffer(primaryPrefabEntity))
			{
				DynamicBuffer<CraftingSlotByRecipesSerialized> dynamicBuffer3 = craftingSlotRecipesSerializedLookup[entity];
				NativeArray<CraftingByRecipeSlotBuffer> v259 = craftingWithRecipeSlotBufferLookup[primaryPrefabEntity].ToNativeArray(Allocator.Temp);
				int num3 = math.min(dynamicBuffer3.Length, v259.Length);
				for (int k = 0; k < num3; k++)
				{
					CraftingByRecipeSlotBuffer value3 = v259[k];
					value3.currentlyCraftingIndex = dynamicBuffer3[k].CurrentlyCrafting;
					v259[k] = value3;
				}
				ecb.SetBuffer<CraftingByRecipeSlotBuffer>(entityInQueryIndex, entity2).CopyFrom(v259);
			}
			if (filteringSerializedLookup.HasBuffer(entity) && moverFilterLookup.HasComponent(primaryPrefabEntity))
			{
				DynamicBuffer<FilteringSerializedBuffer> dynamicBuffer4 = filteringSerializedLookup[entity];
				if (dynamicBuffer4.Length > 0)
				{
					FilteringSerializedBuffer filteringSerializedBuffer = dynamicBuffer4[0];
					ecb.SetComponent(entityInQueryIndex, entity2, new ObjectFilteringCD
					{
						filterType = (FilterType)filteringSerializedBuffer.filterType,
						filterObject = filteringSerializedBuffer.filterObject,
						filterVariation = filteringSerializedBuffer.filterVariation
					});
				}
			}
			if (moverOrchestratorSerializedLookup.HasComponent(entity) && pugAutomationMoverOrchestratorSyncedLookup.HasComponent(primaryPrefabEntity))
			{
				MoverOrchestratorSerialized moverOrchestratorSerialized = moverOrchestratorSerializedLookup[entity];
				PugAutomationEnabledMoverSyncedCD component3 = pugAutomationMoverOrchestratorSyncedLookup[primaryPrefabEntity];
				component3.moverIndex = moverOrchestratorSerialized.activeMoverIndex;
				component3.nextMoverCycleIncrement = moverOrchestratorSerialized.nextMoverCycleIncrement;
				ecb.SetComponent(entityInQueryIndex, entity2, component3);
			}
			if (moveeBigEntitySerializedLookup.HasComponent(entity) && moveeBigEntityLookup.HasComponent(primaryPrefabEntity))
			{
				MoveeSerialized moveeSerialized = moveeBigEntitySerializedLookup[entity];
				MoveeBigEntityCD component4 = moveeBigEntityLookup[primaryPrefabEntity];
				component4.target = moveeSerialized.target;
				component4.moveTimer = moveeSerialized.moveTimer;
				ecb.SetComponent(entityInQueryIndex, entity2, component4);
			}
			if (__HungerSerializedCD_ComponentLookup.HasComponent(entity) && __HungerCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				HungerCD component5 = __HungerCD_ComponentLookup[primaryPrefabEntity];
				component5.hunger = (int)math.round(100f * __HungerSerializedCD_ComponentLookup[entity].Value);
				ecb.SetComponent(entityInQueryIndex, entity2, component5);
			}
			if (__LootTableSerializedCD_ComponentLookup.HasComponent(entity) && __DropsLootFromLootTableCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				LootTableID value4 = __LootTableSerializedCD_ComponentLookup[entity].Value;
				ecb.SetComponent(entityInQueryIndex, entity2, new DropsLootFromLootTableCD
				{
					lootTableID = value4
				});
			}
			if (__PaintableObjectSerializedCD_ComponentLookup.HasComponent(entity) && __PaintableObjectCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				int value5 = __PaintableObjectSerializedCD_ComponentLookup[entity].Value;
				ecb.SetComponent(entityInQueryIndex, entity2, new PaintableObjectCD
				{
					color = (PaintableColor)value5
				});
			}
			if (__BreedStateSerializedCD_ComponentLookup.HasComponent(entity) && __MealsEatenCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				int value6 = __BreedStateSerializedCD_ComponentLookup[entity].Value;
				ecb.SetComponent(entityInQueryIndex, entity2, new MealsEatenCD
				{
					Value = value6
				});
			}
			if (__BreedToggleSerializedCD_ComponentLookup.HasComponent(entity) && __BreedToggleCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				int value7 = __BreedToggleSerializedCD_ComponentLookup[entity].Value;
				ecb.SetComponent(entityInQueryIndex, entity2, new BreedToggleCD
				{
					breedingDisabled = (value7 != 0)
				});
			}
			if (__RotationSerializedCD_ComponentLookup.HasComponent(entity) && __DirectionCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				float3 value8 = __RotationSerializedCD_ComponentLookup[entity].Value;
				ecb.SetComponent(entityInQueryIndex, entity2, new DirectionCD
				{
					direction = value8
				});
			}
			if (__HasBeenDiscoveredSerializedCD_ComponentLookup.HasComponent(entity) && __CanBeDiscoveredCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				other.Add(ComponentType.ReadOnly<HasBeenDiscoveredCD>());
			}
			if (__SpawnStateCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				other.Add(ComponentType.ReadOnly<HasRunSpawnStateCD>());
			}
			if (__CustomSceneObjectSerializedCD_ComponentLookup.HasComponent(entity))
			{
				other.Add(ComponentType.ReadOnly<CustomSceneObjectCD>());
			}
			if (__ActiveEquipmentPresetSerializedCD_ComponentLookup.HasComponent(entity) && __ActiveEquipmentPresetCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				int value9 = __ActiveEquipmentPresetSerializedCD_ComponentLookup[entity].Value;
				ecb.SetComponent(entityInQueryIndex, entity2, new ActiveEquipmentPresetCD
				{
					Value = value9
				});
			}
			if (__NameSerializedCD_ComponentLookup.HasComponent(entity) && __NameCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				FixedString64Bytes value10 = __NameSerializedCD_ComponentLookup[entity].Value;
				ecb.SetComponent(entityInQueryIndex, entity2, new NameCD
				{
					Value = value10
				});
			}
			if (containedObjectsBufferLookup.HasComponent(entity) && containedObjectsNonSerializedBufferLookup.HasComponent(primaryPrefabEntity))
			{
				DynamicBuffer<ContainedObjectsSerializedBuffer> dynamicBuffer5 = containedObjectsBufferLookup[entity];
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer6 = ecb.SetBuffer<ContainedObjectsBuffer>(entityInQueryIndex, entity2);
				int length = containedObjectsNonSerializedBufferLookup[primaryPrefabEntity].Length;
				containedAuxObjectsBufferLookup.TryGetBuffer(entity, out var bufferData);
				int l;
				for (l = 0; l < dynamicBuffer5.Length; l++)
				{
					ObjectDataSerializedCD objectData2 = dynamicBuffer5[l].ObjectData;
					int auxDataIndex = (bufferData.IsCreated ? bufferData[l].Value : 0);
					dynamicBuffer6.Add(new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							amount = objectData2.Amount,
							objectID = objectData2.ObjectID,
							variation = objectData2.Variation
						},
						auxDataIndex = auxDataIndex
					});
				}
				for (; l < length; l++)
				{
					dynamicBuffer6.Add(default(ContainedObjectsBuffer));
				}
			}
			if (conditionsBufferLookup.HasComponent(entity) && conditionsNonSerializedBufferLookup.HasComponent(primaryPrefabEntity) && !__PlayerGhost_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				DynamicBuffer<ConditionsSerializedBuffer> dynamicBuffer7 = conditionsBufferLookup[entity];
				DynamicBuffer<ConditionsBuffer> conditionsBuffer = ecb.SetBuffer<ConditionsBuffer>(entityInQueryIndex, entity2);
				conditionsBuffer.AddRange(conditionsNonSerializedBufferLookup[primaryPrefabEntity].AsNativeArray());
				for (int m = 0; m < dynamicBuffer7.Length; m++)
				{
					ConditionSerialized value11 = dynamicBuffer7[m].Value;
					int index = EntityUtility.AddOrRefreshConditionOverrideStacks(new ConditionData
					{
						conditionID = (ConditionID)value11.Id,
						value = value11.Value,
						duration = value11.Duration
					}, conditionsBuffer, conditionsTable, currentTick, tickRate);
					conditionsBuffer.ElementAt(index).condition.removeTick = NetworkTimeUtilities.SecondsToTick(math.max(value11.Timer, 0f), currentTick, tickRate);
				}
			}
			if (affixBufferLookup.HasComponent(entity) && activeAffixConditionNonSerializedBufferLookup.HasComponent(primaryPrefabEntity) && activeAffixStateNonSerializedBufferLookup.HasComponent(primaryPrefabEntity))
			{
				DynamicBuffer<AffixSerializedBuffer> dynamicBuffer8 = affixBufferLookup[entity];
				DynamicBuffer<ActiveAffixStateBuffer> dynamicBuffer9 = ecb.SetBuffer<ActiveAffixStateBuffer>(entityInQueryIndex, entity2);
				DynamicBuffer<ActiveAffixConditionsBuffer> dynamicBuffer10 = ecb.SetBuffer<ActiveAffixConditionsBuffer>(entityInQueryIndex, entity2);
				for (int n = 0; n < dynamicBuffer8.Length; n++)
				{
					AffixSerializedBuffer affixSerializedBuffer = dynamicBuffer8[n];
					dynamicBuffer10.Add(new ActiveAffixConditionsBuffer
					{
						conditionData = new ConditionData
						{
							conditionID = (ConditionID)affixSerializedBuffer.condition.Id,
							value = affixSerializedBuffer.condition.Value,
							duration = affixSerializedBuffer.condition.Duration
						}
					});
					dynamicBuffer9.Add(new ActiveAffixStateBuffer
					{
						state = (AffixState)affixSerializedBuffer.state,
						cooldownTimer = new TickTimer
						{
							startTick = currentTick,
							targetTicks = NetworkTimeUtilities.SecondsToTicks(math.max(affixSerializedBuffer.remainingCooldown, 0f), tickRate)
						}
					});
				}
			}
			if (dropsLootBufferLookup.HasComponent(entity))
			{
				if (dropsLootNonSerializedBufferLookup.HasComponent(primaryPrefabEntity))
				{
					DynamicBuffer<DropsLootSerializedBuffer> dynamicBuffer11 = dropsLootBufferLookup[entity];
					DynamicBuffer<DropsLootBuffer> dynamicBuffer12 = ecb.SetBuffer<DropsLootBuffer>(entityInQueryIndex, entity2);
					DynamicBuffer<DropsLootBuffer> dynamicBuffer13 = dropsLootNonSerializedBufferLookup[primaryPrefabEntity];
					for (int num4 = 0; num4 < dynamicBuffer11.Length; num4++)
					{
						DropsLootBuffer elem = ((!dynamicBuffer13.IsCreated || num4 >= dynamicBuffer13.Length) ? default(DropsLootBuffer) : dynamicBuffer13[num4]);
						elem.lootDropID = dynamicBuffer11[num4].ObjectID;
						elem.amount = dynamicBuffer11[num4].Amount;
						dynamicBuffer12.Add(elem);
					}
				}
				else if (printMissingComponentErrors)
				{
					Debug.LogError($"Missing DropsLootBuffer on prefab entity {primaryPrefabEntity.Index} when deserialized");
				}
			}
			if (descriptionBufferLookup.HasComponent(entity))
			{
				NativeArray<DescriptionBuffer> newElems = descriptionBufferLookup[entity].Reinterpret<DescriptionBuffer>().AsNativeArray();
				if (descriptionNonSerializedBufferLookup.HasComponent(primaryPrefabEntity))
				{
					ecb.SetBuffer<DescriptionBuffer>(entityInQueryIndex, entity2).AddRange(newElems);
				}
				else
				{
					ecb.AddBuffer<DescriptionBuffer>(entityInQueryIndex, entity2).AddRange(newElems);
				}
			}
			if (__PlayerSerializedCD_ComponentLookup.HasComponent(entity))
			{
				PlayerSerializedCD playerSerializedCD = __PlayerSerializedCD_ComponentLookup[entity];
				other.Add(ComponentType.ReadOnly<Disabled>());
				ecb.SetComponent(entityInQueryIndex, entity2, new PlayerGhost
				{
					playerGuid = playerSerializedCD.PlayerGuid
				});
			}
			if (__PlayerLastSessionSerializedCD_ComponentLookup.HasComponent(entity))
			{
				PlayerLastSessionSerializedCD playerLastSessionSerializedCD = __PlayerLastSessionSerializedCD_ComponentLookup[entity];
				ecb.SetComponent(entityInQueryIndex, entity2, new PlayerLastSessionCD
				{
					Value = playerLastSessionSerializedCD.Value
				});
			}
			if (__SpawnPointCD_ComponentLookup.HasComponent(entity))
			{
				SpawnPointCD component6 = __SpawnPointCD_ComponentLookup[entity];
				ecb.AddComponent(entityInQueryIndex, entity2, component6);
			}
			if (__SnakeBossSegmentSerializedCD_ComponentLookup.HasComponent(entity) && __SnakeSegmentCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				SnakeSegmentCD component7 = __SnakeSegmentCD_ComponentLookup[primaryPrefabEntity];
				SnakeBossSegmentSerializedCD snakeBossSegmentSerializedCD = __SnakeBossSegmentSerializedCD_ComponentLookup[entity];
				component7.index = snakeBossSegmentSerializedCD.Index;
				component7.groupIndex = snakeBossSegmentSerializedCD.GroupIndex;
				ecb.SetComponent(entityInQueryIndex, entity2, component7);
			}
			if (__ImmunityZoneShapeSerializedCD_ComponentLookup.HasComponent(entity) && __ImmunityZoneCD_ComponentLookup.HasComponent(primaryPrefabEntity))
			{
				ImmunityZoneCD component8 = __ImmunityZoneCD_ComponentLookup[primaryPrefabEntity];
				ImmunityZoneShapeSerializedCD immunityZoneShapeSerializedCD = __ImmunityZoneShapeSerializedCD_ComponentLookup[entity];
				component8.offset = immunityZoneShapeSerializedCD.Offset;
				component8.useRectangularBounds = immunityZoneShapeSerializedCD.ShapeType == 1;
				if (component8.useRectangularBounds)
				{
					component8.rectangularWidth = (int)math.round(immunityZoneShapeSerializedCD.SizeValue1);
					component8.rectangularHeight = (int)math.round(immunityZoneShapeSerializedCD.SizeValue2);
				}
				else
				{
					component8.radius = immunityZoneShapeSerializedCD.SizeValue1;
					component8.radiusSq = component8.radius * component8.radius;
				}
				ecb.SetComponent(entityInQueryIndex, entity2, component8);
			}
			ecb.AddComponent(entityInQueryIndex, entity2, new ComponentTypeSet((FixedList128Bytes<ComponentType>)other));
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __translationTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr3, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr3, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr3, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_1_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		[ReadOnly]
		public DynamicBuffer<InventoryAuxDataPrefabBuffer> inventoryAuxDataPrefabBuffer;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public BufferLookup<TalentsSerializedCD> talentsSerializedBufferLookup;

		[ReadOnly]
		public BufferLookup<PetTalentBuffer> petTalentsBufferLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataSerializedCD> __inventoryAuxDataSerializedTypeHandle;

		[ReadOnly]
		public ComponentLookup<NameSerializedCD> __NameSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NameCD> __NameCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetSkinSerializedCD> __PetSkinSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetSkinCD> __PetSkinCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedStateSerializedCD> __BreedStateSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> __MealsEatenCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleSerializedCD> __BreedToggleSerializedCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleCD> __BreedToggleCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] in InventoryAuxDataSerializedCD inventoryAuxDataSerialized)
		{
			ecb.DestroyEntity(entityInQueryIndex, entity);
			Entity entity2 = Entity.Null;
			for (int i = 0; i < inventoryAuxDataPrefabBuffer.Length; i++)
			{
				if (inventoryAuxDataPrefabBuffer[i].TypeHash == inventoryAuxDataSerialized.TypeHash)
				{
					entity2 = inventoryAuxDataPrefabBuffer[i].Entity;
					break;
				}
			}
			if (entity2 == Entity.Null)
			{
				return;
			}
			Entity e = ecb.Instantiate(entityInQueryIndex, entity2);
			ecb.SetComponent(entityInQueryIndex, e, new InventoryAuxDataCD
			{
				Index = inventoryAuxDataSerialized.Index
			});
			if (__NameSerializedCD_ComponentLookup.HasComponent(entity) && __NameCD_ComponentLookup.HasComponent(entity2))
			{
				ecb.SetComponent(entityInQueryIndex, e, new NameCD
				{
					Value = __NameSerializedCD_ComponentLookup[entity].Value
				});
			}
			if (talentsSerializedBufferLookup.HasComponent(entity) && petTalentsBufferLookup.HasComponent(entity2))
			{
				DynamicBuffer<TalentsSerializedCD> dynamicBuffer = talentsSerializedBufferLookup[entity];
				DynamicBuffer<PetTalentBuffer> dynamicBuffer2 = ecb.SetBuffer<PetTalentBuffer>(entityInQueryIndex, e);
				for (int j = 0; j < dynamicBuffer.Length; j++)
				{
					dynamicBuffer2.Add(new PetTalentBuffer
					{
						petTalentID = (PetTalent)dynamicBuffer[j].Talent,
						points = dynamicBuffer[j].Points
					});
				}
			}
			if (__PetSkinSerializedCD_ComponentLookup.HasComponent(entity) && __PetSkinCD_ComponentLookup.HasComponent(entity2))
			{
				ecb.SetComponent(entityInQueryIndex, e, new PetSkinCD
				{
					skinIndex = __PetSkinSerializedCD_ComponentLookup[entity].skinIndex
				});
			}
			if (__BreedStateSerializedCD_ComponentLookup.HasComponent(entity) && __MealsEatenCD_ComponentLookup.HasComponent(entity2))
			{
				ecb.SetComponent(entityInQueryIndex, e, new MealsEatenCD
				{
					Value = __BreedStateSerializedCD_ComponentLookup[entity].Value
				});
			}
			if (__BreedToggleSerializedCD_ComponentLookup.HasComponent(entity) && __BreedToggleCD_ComponentLookup.HasComponent(entity2))
			{
				ecb.SetComponent(entityInQueryIndex, e, new BreedToggleCD
				{
					breedingDisabled = (__BreedToggleSerializedCD_ComponentLookup[entity].Value != 0)
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __inventoryAuxDataSerializedTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataSerializedCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataSerializedCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataSerializedCD>(nativeArrayPtr2, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<InventoryAuxDataSerializedCD>(nativeArrayPtr2, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_2_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public BufferTypeHandle<SubMapLayerSerializedBuffer> __layersTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<Translation> __translationTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SubMapSerializedCD> __submapTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, DynamicBuffer<SubMapLayerSerializedBuffer> layers, [NoAlias] in Translation translation, [NoAlias] in SubMapSerializedCD submap)
		{
			ecb.DestroyEntity(entityInQueryIndex, entity);
			if (math.any(math.abs(submap.Position) >= 33554431))
			{
				Debug.LogError("Removing submap with _way_ too large position");
				return;
			}
			Entity e = ecb.CreateEntity(entityInQueryIndex);
			ecb.AddComponent(entityInQueryIndex, e, new ComponentTypeSet(ComponentType.ReadOnly<LocalTransform>(), ComponentType.ReadOnly<SubMapCD>()));
			ecb.SetComponent(entityInQueryIndex, e, LocalTransform.FromPosition(translation.Value));
			ecb.SetComponent(entityInQueryIndex, e, new SubMapCD
			{
				index = submap.Position
			});
			DynamicBuffer<SubMapLayerBuffer> dynamicBuffer = ecb.AddBuffer<SubMapLayerBuffer>(entityInQueryIndex, e);
			foreach (SubMapLayer item in layers.Reinterpret<SubMapLayer>())
			{
				TileType tileType = item.layer.tileType;
				int tileset = item.layer.tileset;
				if (tileset < 0 || tileset >= 75)
				{
					Debug.LogWarning($"Discarding submap with invalid tileset {tileset} for tile type {(int)tileType}");
				}
				else
				{
					dynamicBuffer.Add(item);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			BufferAccessor<SubMapLayerSerializedBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __layersTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __translationTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __submapTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapSerializedCD>(nativeArrayPtr3, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapSerializedCD>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapSerializedCD>(nativeArrayPtr3, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<Translation>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapSerializedCD>(nativeArrayPtr3, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_3_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public ComponentLookup<Translation> translationSerializedLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CustomSceneSerializedCD> __customSceneTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] in CustomSceneSerializedCD customScene)
		{
			ecb.DestroyEntity(entityInQueryIndex, entity);
			Entity e = ecb.CreateEntity(entityInQueryIndex);
			ecb.AddComponent(entityInQueryIndex, e, new CustomSceneCD
			{
				name = CustomSceneSerializedCD.AsFixedString32Bytes(customScene)
			});
			if (translationSerializedLookup.TryGetComponent(entity, out var componentData))
			{
				ecb.AddComponent(entityInQueryIndex, e, LocalTransform.FromPosition(componentData.Value));
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __customSceneTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CustomSceneSerializedCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CustomSceneSerializedCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CustomSceneSerializedCD>(nativeArrayPtr2, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CustomSceneSerializedCD>(nativeArrayPtr2, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_4_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PheromoneSerializedCD> __pheromoneSerializedTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] in PheromoneSerializedCD pheromoneSerialized)
		{
			ecb.DestroyEntity(entityInQueryIndex, entity);
			Entity e = ecb.CreateEntity(entityInQueryIndex);
			PheromoneCD component = new PheromoneCD
			{
				position = pheromoneSerialized.Position
			};
			UnsafeUtility.MemCpy(component.pheromone.values, pheromoneSerialized.Values.GetUnsafePtr(), 2 * UnsafeUtility.SizeOf<ushort>());
			ecb.AddComponent(entityInQueryIndex, e, component);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __pheromoneSerializedTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSerializedCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSerializedCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSerializedCD>(nativeArrayPtr2, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSerializedCD>(nativeArrayPtr2, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_5_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public EntityCommandBuffer.ParallelWriter ecb;

		public Entity killedEnemiesBufferSingleton;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public BufferTypeHandle<KilledEnemiesSerializedBuffer> __killedEnemiesSerializedBufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, DynamicBuffer<KilledEnemiesSerializedBuffer> killedEnemiesSerializedBuffer)
		{
			ecb.RemoveComponent<KilledEnemiesSerializedBuffer>(entityInQueryIndex, entity);
			DynamicBuffer<KilledEnemiesBuffer> dynamicBuffer = ecb.SetBuffer<KilledEnemiesBuffer>(entityInQueryIndex, killedEnemiesBufferSingleton);
			for (int i = 0; i < killedEnemiesSerializedBuffer.Length; i++)
			{
				dynamicBuffer.Add(new KilledEnemiesBuffer
				{
					objectData = killedEnemiesSerializedBuffer[i].ObjectData
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			BufferAccessor<KilledEnemiesSerializedBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __killedEnemiesSerializedBufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, bufferAccessor[i]);
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, bufferAccessor[j]);
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, bufferAccessor[k]);
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, bufferAccessor[l]);
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_6_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		[ReadOnly]
		public DynamicBuffer<PugPrefabBuffer> pugPrefabBuffer;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public BufferTypeHandle<ActivatedContentBundlesSerializedBuffer> __activatedContentBundlesSerializedBufferTypeHandle;

		[ReadOnly]
		public BufferLookup<ActivatedContentBundlesBuffer> __ActivatedContentBundlesBuffer_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, DynamicBuffer<ActivatedContentBundlesSerializedBuffer> activatedContentBundlesSerializedBuffer)
		{
			ecb.DestroyEntity(entityInQueryIndex, entity);
			Entity e = Entity.Null;
			for (int i = 0; i < pugPrefabBuffer.Length; i++)
			{
				if (__ActivatedContentBundlesBuffer_BufferLookup.HasBuffer(pugPrefabBuffer[i].Value))
				{
					e = ecb.Instantiate(entityInQueryIndex, pugPrefabBuffer[i].Value);
					break;
				}
			}
			DynamicBuffer<ActivatedContentBundlesBuffer> dynamicBuffer = ecb.SetBuffer<ActivatedContentBundlesBuffer>(entityInQueryIndex, e);
			for (int j = 0; j < activatedContentBundlesSerializedBuffer.Length; j++)
			{
				dynamicBuffer.Add(new ActivatedContentBundlesBuffer
				{
					ContentBundle = activatedContentBundlesSerializedBuffer[j].ContentBundle
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			BufferAccessor<ActivatedContentBundlesSerializedBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __activatedContentBundlesSerializedBufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, bufferAccessor[i]);
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, bufferAccessor[j]);
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, bufferAccessor[k]);
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, bufferAccessor[l]);
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_7_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataSerializedCD> __objectDataTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] in ObjectDataSerializedCD objectData)
		{
			ecb.DestroyEntity(entityInQueryIndex, entity);
			Entity e = ecb.CreateEntity(entityInQueryIndex);
			ecb.AddComponent(entityInQueryIndex, e, new PugScanCD
			{
				objectToScan = objectData
			});
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr2, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataSerializedCD>(nativeArrayPtr2, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct DeserializeComponentsSystem_514D995_LambdaJob_8_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public EntityCommandBuffer.ParallelWriter ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<TheGreatWallStatusSerializedCD> __wallStatusTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] in TheGreatWallStatusSerializedCD wallStatus)
		{
			ecb.RemoveComponent<TheGreatWallStatusSerializedCD>(entityInQueryIndex, entity);
			if (wallStatus.HasBeenLowered)
			{
				ecb.AddComponent<TheGreatWallHasBeenLoweredCD>(entityInQueryIndex, entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __wallStatusTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallStatusSerializedCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallStatusSerializedCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallStatusSerializedCD>(nativeArrayPtr2, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallStatusSerializedCD>(nativeArrayPtr2, l));
				}
				num2 >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<Translation> __Unity_Transforms_Translation_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataSerializedCD> __ObjectDataSerializedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<RotationSerializedCD> __RotationSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SeasonObjectCD> __SeasonObjectCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CharacterGuidSerializedCD> __CharacterGuidSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CreateNewGuidCD> __CreateNewGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByCharacterGuidSerializedCD> __ClaimedByCharacterGuidSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByCharacterGuidCD> __ClaimedByCharacterGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGuidSerializedCD> __PlayerGuidSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByPlayerGuidSerializedCD> __ClaimedByPlayerGuidSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ClaimedByPlayerGuidCD> __ClaimedByPlayerGuidCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthSerializedCD> __HealthSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GrowingSerializedCD> __GrowingSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GrowingCD> __GrowingCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HungerSerializedCD> __HungerSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HungerCD> __HungerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LootTableSerializedCD> __LootTableSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DropsLootFromLootTableCD> __DropsLootFromLootTableCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PaintableObjectSerializedCD> __PaintableObjectSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PaintableObjectCD> __PaintableObjectCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedStateSerializedCD> __BreedStateSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MealsEatenCD> __MealsEatenCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleSerializedCD> __BreedToggleSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BreedToggleCD> __BreedToggleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HasBeenDiscoveredSerializedCD> __HasBeenDiscoveredSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CanBeDiscoveredCD> __CanBeDiscoveredCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnStateCD> __SpawnStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CustomSceneObjectSerializedCD> __CustomSceneObjectSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ActiveEquipmentPresetSerializedCD> __ActiveEquipmentPresetSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ActiveEquipmentPresetCD> __ActiveEquipmentPresetCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NameSerializedCD> __NameSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NameCD> __NameCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerSerializedCD> __PlayerSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerLastSessionSerializedCD> __PlayerLastSessionSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnPointCD> __SpawnPointCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeBossSegmentSerializedCD> __SnakeBossSegmentSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeSegmentCD> __SnakeSegmentCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmunityZoneShapeSerializedCD> __ImmunityZoneShapeSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmunityZoneCD> __ImmunityZoneCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentTypeHandle<InventoryAuxDataSerializedCD> __InventoryAuxDataSerializedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<PetSkinSerializedCD> __PetSkinSerializedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PetSkinCD> __PetSkinCD_RO_ComponentLookup;

		public BufferTypeHandle<SubMapLayerSerializedBuffer> __SubMapLayerSerializedBuffer_RW_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<SubMapSerializedCD> __SubMapSerializedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<CustomSceneSerializedCD> __CustomSceneSerializedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PheromoneSerializedCD> __PheromoneSerializedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<KilledEnemiesSerializedBuffer> __KilledEnemiesSerializedBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ActivatedContentBundlesSerializedBuffer> __ActivatedContentBundlesSerializedBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public BufferLookup<ActivatedContentBundlesBuffer> __ActivatedContentBundlesBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentTypeHandle<TheGreatWallStatusSerializedCD> __TheGreatWallStatusSerializedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferLookup<ContainedObjectsSerializedBuffer> __ContainedObjectsSerializedBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsAuxIndexSerializedBuffer> __ContainedObjectsAuxIndexSerializedBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ConditionsSerializedBuffer> __ConditionsSerializedBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ConditionsBuffer> __ConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<AffixSerializedBuffer> __AffixSerializedBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ActiveAffixStateBuffer> __Affixes_Components_ActiveAffixStateBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ActiveAffixConditionsBuffer> __ActiveAffixConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<DropsLootSerializedBuffer> __DropsLootSerializedBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<DropsLootBuffer> __DropsLootBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<DescriptionSerializedBuffer> __DescriptionSerializedBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<DescriptionBuffer> __DescriptionBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<TalentsSerializedCD> __TalentsSerializedCD_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<PetTalentBuffer> __PetTalentBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingByRecipeSlotBuffer> __CraftingByRecipeSlotBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingTimerSlotBuffer> __CraftingTimerSlotBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingByConsumedObjectSlotBuffer> __CraftingByConsumedObjectSlotBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingSlotTimerSerialized> __CraftingSlotTimerSerialized_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingSlotByRecipesSerialized> __CraftingSlotByRecipesSerialized_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<CraftingSlotByConsumedObjectsSerialized> __CraftingSlotByConsumedObjectsSerialized_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ObjectFilteringCD> __ObjectFilteringCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<FilteringSerializedBuffer> __FilteringSerializedBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PugAutomationEnabledMoverSyncedCD> __Pug_Automation_PugAutomationEnabledMoverSyncedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MoverOrchestratorSerialized> __MoverOrchestratorSerialized_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MoveeSerialized> __MoveeSerialized_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MoveeBigEntityCD> __Pug_Automation_MoveeBigEntityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Translation> __Unity_Transforms_Translation_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Transforms_Translation_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Translation>(isReadOnly: true);
			__ObjectDataSerializedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataSerializedCD>(isReadOnly: true);
			__RotationSerializedCD_RO_ComponentLookup = state.GetComponentLookup<RotationSerializedCD>(isReadOnly: true);
			__SeasonObjectCD_RO_ComponentLookup = state.GetComponentLookup<SeasonObjectCD>(isReadOnly: true);
			__CharacterGuidSerializedCD_RO_ComponentLookup = state.GetComponentLookup<CharacterGuidSerializedCD>(isReadOnly: true);
			__CreateNewGuidCD_RO_ComponentLookup = state.GetComponentLookup<CreateNewGuidCD>(isReadOnly: true);
			__ClaimedByCharacterGuidSerializedCD_RO_ComponentLookup = state.GetComponentLookup<ClaimedByCharacterGuidSerializedCD>(isReadOnly: true);
			__ClaimedByCharacterGuidCD_RO_ComponentLookup = state.GetComponentLookup<ClaimedByCharacterGuidCD>(isReadOnly: true);
			__PlayerGuidSerializedCD_RO_ComponentLookup = state.GetComponentLookup<PlayerGuidSerializedCD>(isReadOnly: true);
			__ClaimedByPlayerGuidSerializedCD_RO_ComponentLookup = state.GetComponentLookup<ClaimedByPlayerGuidSerializedCD>(isReadOnly: true);
			__ClaimedByPlayerGuidCD_RO_ComponentLookup = state.GetComponentLookup<ClaimedByPlayerGuidCD>(isReadOnly: true);
			__HealthSerializedCD_RO_ComponentLookup = state.GetComponentLookup<HealthSerializedCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__GrowingSerializedCD_RO_ComponentLookup = state.GetComponentLookup<GrowingSerializedCD>(isReadOnly: true);
			__GrowingCD_RO_ComponentLookup = state.GetComponentLookup<GrowingCD>(isReadOnly: true);
			__HungerSerializedCD_RO_ComponentLookup = state.GetComponentLookup<HungerSerializedCD>(isReadOnly: true);
			__HungerCD_RO_ComponentLookup = state.GetComponentLookup<HungerCD>(isReadOnly: true);
			__LootTableSerializedCD_RO_ComponentLookup = state.GetComponentLookup<LootTableSerializedCD>(isReadOnly: true);
			__DropsLootFromLootTableCD_RO_ComponentLookup = state.GetComponentLookup<DropsLootFromLootTableCD>(isReadOnly: true);
			__PaintableObjectSerializedCD_RO_ComponentLookup = state.GetComponentLookup<PaintableObjectSerializedCD>(isReadOnly: true);
			__PaintableObjectCD_RO_ComponentLookup = state.GetComponentLookup<PaintableObjectCD>(isReadOnly: true);
			__BreedStateSerializedCD_RO_ComponentLookup = state.GetComponentLookup<BreedStateSerializedCD>(isReadOnly: true);
			__MealsEatenCD_RO_ComponentLookup = state.GetComponentLookup<MealsEatenCD>(isReadOnly: true);
			__BreedToggleSerializedCD_RO_ComponentLookup = state.GetComponentLookup<BreedToggleSerializedCD>(isReadOnly: true);
			__BreedToggleCD_RO_ComponentLookup = state.GetComponentLookup<BreedToggleCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__HasBeenDiscoveredSerializedCD_RO_ComponentLookup = state.GetComponentLookup<HasBeenDiscoveredSerializedCD>(isReadOnly: true);
			__CanBeDiscoveredCD_RO_ComponentLookup = state.GetComponentLookup<CanBeDiscoveredCD>(isReadOnly: true);
			__SpawnStateCD_RO_ComponentLookup = state.GetComponentLookup<SpawnStateCD>(isReadOnly: true);
			__CustomSceneObjectSerializedCD_RO_ComponentLookup = state.GetComponentLookup<CustomSceneObjectSerializedCD>(isReadOnly: true);
			__ActiveEquipmentPresetSerializedCD_RO_ComponentLookup = state.GetComponentLookup<ActiveEquipmentPresetSerializedCD>(isReadOnly: true);
			__ActiveEquipmentPresetCD_RO_ComponentLookup = state.GetComponentLookup<ActiveEquipmentPresetCD>(isReadOnly: true);
			__NameSerializedCD_RO_ComponentLookup = state.GetComponentLookup<NameSerializedCD>(isReadOnly: true);
			__NameCD_RO_ComponentLookup = state.GetComponentLookup<NameCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__PlayerSerializedCD_RO_ComponentLookup = state.GetComponentLookup<PlayerSerializedCD>(isReadOnly: true);
			__PlayerLastSessionSerializedCD_RO_ComponentLookup = state.GetComponentLookup<PlayerLastSessionSerializedCD>(isReadOnly: true);
			__SpawnPointCD_RO_ComponentLookup = state.GetComponentLookup<SpawnPointCD>(isReadOnly: true);
			__SnakeBossSegmentSerializedCD_RO_ComponentLookup = state.GetComponentLookup<SnakeBossSegmentSerializedCD>(isReadOnly: true);
			__SnakeSegmentCD_RO_ComponentLookup = state.GetComponentLookup<SnakeSegmentCD>(isReadOnly: true);
			__ImmunityZoneShapeSerializedCD_RO_ComponentLookup = state.GetComponentLookup<ImmunityZoneShapeSerializedCD>(isReadOnly: true);
			__ImmunityZoneCD_RO_ComponentLookup = state.GetComponentLookup<ImmunityZoneCD>(isReadOnly: true);
			__InventoryAuxDataSerializedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<InventoryAuxDataSerializedCD>(isReadOnly: true);
			__PetSkinSerializedCD_RO_ComponentLookup = state.GetComponentLookup<PetSkinSerializedCD>(isReadOnly: true);
			__PetSkinCD_RO_ComponentLookup = state.GetComponentLookup<PetSkinCD>(isReadOnly: true);
			__SubMapLayerSerializedBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SubMapLayerSerializedBuffer>();
			__SubMapSerializedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SubMapSerializedCD>(isReadOnly: true);
			__CustomSceneSerializedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CustomSceneSerializedCD>(isReadOnly: true);
			__PheromoneSerializedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PheromoneSerializedCD>(isReadOnly: true);
			__KilledEnemiesSerializedBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<KilledEnemiesSerializedBuffer>(isReadOnly: true);
			__ActivatedContentBundlesSerializedBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ActivatedContentBundlesSerializedBuffer>(isReadOnly: true);
			__ActivatedContentBundlesBuffer_RO_BufferLookup = state.GetBufferLookup<ActivatedContentBundlesBuffer>(isReadOnly: true);
			__TheGreatWallStatusSerializedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TheGreatWallStatusSerializedCD>(isReadOnly: true);
			__ContainedObjectsSerializedBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsSerializedBuffer>(isReadOnly: true);
			__ContainedObjectsAuxIndexSerializedBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsAuxIndexSerializedBuffer>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__ConditionsSerializedBuffer_RO_BufferLookup = state.GetBufferLookup<ConditionsSerializedBuffer>(isReadOnly: true);
			__ConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<ConditionsBuffer>(isReadOnly: true);
			__AffixSerializedBuffer_RO_BufferLookup = state.GetBufferLookup<AffixSerializedBuffer>(isReadOnly: true);
			__Affixes_Components_ActiveAffixStateBuffer_RO_BufferLookup = state.GetBufferLookup<ActiveAffixStateBuffer>(isReadOnly: true);
			__ActiveAffixConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<ActiveAffixConditionsBuffer>(isReadOnly: true);
			__DropsLootSerializedBuffer_RO_BufferLookup = state.GetBufferLookup<DropsLootSerializedBuffer>(isReadOnly: true);
			__DropsLootBuffer_RO_BufferLookup = state.GetBufferLookup<DropsLootBuffer>(isReadOnly: true);
			__DescriptionSerializedBuffer_RO_BufferLookup = state.GetBufferLookup<DescriptionSerializedBuffer>(isReadOnly: true);
			__DescriptionBuffer_RO_BufferLookup = state.GetBufferLookup<DescriptionBuffer>(isReadOnly: true);
			__TalentsSerializedCD_RO_BufferLookup = state.GetBufferLookup<TalentsSerializedCD>(isReadOnly: true);
			__PetTalentBuffer_RO_BufferLookup = state.GetBufferLookup<PetTalentBuffer>(isReadOnly: true);
			__CraftingByRecipeSlotBuffer_RO_BufferLookup = state.GetBufferLookup<CraftingByRecipeSlotBuffer>(isReadOnly: true);
			__CraftingTimerSlotBuffer_RO_BufferLookup = state.GetBufferLookup<CraftingTimerSlotBuffer>(isReadOnly: true);
			__CraftingByConsumedObjectSlotBuffer_RO_BufferLookup = state.GetBufferLookup<CraftingByConsumedObjectSlotBuffer>(isReadOnly: true);
			__CraftingSlotTimerSerialized_RO_BufferLookup = state.GetBufferLookup<CraftingSlotTimerSerialized>(isReadOnly: true);
			__CraftingSlotByRecipesSerialized_RO_BufferLookup = state.GetBufferLookup<CraftingSlotByRecipesSerialized>(isReadOnly: true);
			__CraftingSlotByConsumedObjectsSerialized_RO_BufferLookup = state.GetBufferLookup<CraftingSlotByConsumedObjectsSerialized>(isReadOnly: true);
			__ObjectFilteringCD_RO_ComponentLookup = state.GetComponentLookup<ObjectFilteringCD>(isReadOnly: true);
			__FilteringSerializedBuffer_RO_BufferLookup = state.GetBufferLookup<FilteringSerializedBuffer>(isReadOnly: true);
			__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RO_ComponentLookup = state.GetComponentLookup<PugAutomationEnabledMoverSyncedCD>(isReadOnly: true);
			__MoverOrchestratorSerialized_RO_ComponentLookup = state.GetComponentLookup<MoverOrchestratorSerialized>(isReadOnly: true);
			__MoveeSerialized_RO_ComponentLookup = state.GetComponentLookup<MoveeSerialized>(isReadOnly: true);
			__Pug_Automation_MoveeBigEntityCD_RO_ComponentLookup = state.GetComponentLookup<MoveeBigEntityCD>(isReadOnly: true);
			__Unity_Transforms_Translation_RO_ComponentLookup = state.GetComponentLookup<Translation>(isReadOnly: true);
		}
	}

	public EntityArchetype _tryMoveToDisabledArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1359213098_0;

	private EntityQuery __query_1359213098_1;

	private EntityQuery __query_1359213098_2;

	private EntityQuery __query_1359213098_3;

	private EntityQuery __query_1359213098_4;

	private EntityQuery __query_1359213098_5;

	private EntityQuery __query_1359213098_6;

	private EntityQuery __query_1359213098_7;

	private EntityQuery __query_1359213098_8;

	private EntityQuery __query_1359213098_9;

	private EntityQuery __query_1359213098_10;

	private EntityQuery __query_1359213098_11;

	private EntityQuery __query_1359213098_12;

	private EntityQuery __query_1359213098_13;

	private EntityQuery __query_1359213098_14;

	private EntityQuery __query_1359213098_15;

	private EntityQuery __query_1359213098_16;

	private EntityQuery __query_1359213098_17;

	private EntityQuery __query_1359213098_18;

	private EntityQuery __query_1359213098_19;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<PugDatabase.DatabaseBankCD>();
		RequireForUpdate<ConditionsTableCD>();
		RequireForUpdate<InventoryAuxDataPrefabBuffer>();
		RequireForUpdate<GhostCollection>();
		RequireForUpdate<ObjectDataSerializedCD>();
		RequireForUpdate<ObjectLookupWriterCD>();
		RequireForUpdate<PugPrefabBuffer>();
		_tryMoveToDisabledArchetype = base.EntityManager.CreateArchetype(ComponentType.ReadOnly<TryMoveDeserializedEntityToDisabledCD>());
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer entityCommandBuffer = __query_1359213098_10.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(base.World.Unmanaged);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_1359213098_11.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		DynamicBuffer<InventoryAuxDataPrefabBuffer> singletonBuffer = __query_1359213098_12.GetSingletonBuffer<InventoryAuxDataPrefabBuffer>();
		DynamicBuffer<PugPrefabBuffer> singletonBuffer2 = __query_1359213098_13.GetSingletonBuffer<PugPrefabBuffer>();
		EntityCommandBuffer.ParallelWriter ecb = entityCommandBuffer.AsParallelWriter();
		BufferLookup<ContainedObjectsSerializedBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsSerializedBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<ContainedObjectsAuxIndexSerializedBuffer> bufferLookup2 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsAuxIndexSerializedBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<ContainedObjectsBuffer> bufferLookup3 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<ConditionsSerializedBuffer> bufferLookup4 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsSerializedBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<ConditionsBuffer> bufferLookup5 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ConditionsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<AffixSerializedBuffer> bufferLookup6 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AffixSerializedBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<ActiveAffixStateBuffer> bufferLookup7 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Affixes_Components_ActiveAffixStateBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<ActiveAffixConditionsBuffer> bufferLookup8 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ActiveAffixConditionsBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<DropsLootSerializedBuffer> bufferLookup9 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__DropsLootSerializedBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<DropsLootBuffer> bufferLookup10 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__DropsLootBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<DescriptionSerializedBuffer> bufferLookup11 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__DescriptionSerializedBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<DescriptionBuffer> bufferLookup12 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__DescriptionBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<TalentsSerializedCD> bufferLookup13 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TalentsSerializedCD_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<PetTalentBuffer> bufferLookup14 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__PetTalentBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		ConditionsTableCD singleton = __query_1359213098_14.GetSingleton<ConditionsTableCD>();
		BufferLookup<CraftingByRecipeSlotBuffer> bufferLookup15 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingByRecipeSlotBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<CraftingTimerSlotBuffer> bufferLookup16 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingTimerSlotBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<CraftingByConsumedObjectSlotBuffer> bufferLookup17 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingByConsumedObjectSlotBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<CraftingSlotTimerSerialized> bufferLookup18 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingSlotTimerSerialized_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<CraftingSlotByRecipesSerialized> bufferLookup19 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingSlotByRecipesSerialized_RO_BufferLookup, ref base.CheckedStateRef);
		BufferLookup<CraftingSlotByConsumedObjectsSerialized> bufferLookup20 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CraftingSlotByConsumedObjectsSerialized_RO_BufferLookup, ref base.CheckedStateRef);
		ComponentLookup<ObjectFilteringCD> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectFilteringCD_RO_ComponentLookup, ref base.CheckedStateRef);
		BufferLookup<FilteringSerializedBuffer> bufferLookup21 = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__FilteringSerializedBuffer_RO_BufferLookup, ref base.CheckedStateRef);
		ComponentLookup<PugAutomationEnabledMoverSyncedCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_PugAutomationEnabledMoverSyncedCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<MoverOrchestratorSerialized> componentLookup3 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoverOrchestratorSerialized_RO_ComponentLookup, ref base.CheckedStateRef);
		ObjectLookupWriterCD singleton2 = __query_1359213098_15.GetSingleton<ObjectLookupWriterCD>();
		ComponentLookup<MoveeSerialized> componentLookup4 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveeSerialized_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<MoveeBigEntityCD> componentLookup5 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Automation_MoveeBigEntityCD_RO_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<Translation> componentLookup6 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_Translation_RO_ComponentLookup, ref base.CheckedStateRef);
		Season season = Manager.prefs.season;
		__query_1359213098_16.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		if (!__query_1359213098_17.TryGetSingleton<ClientServerTickRate>(out var value2))
		{
			value2.ResolveDefaults();
		}
		uint simulationTickRate = (uint)value2.SimulationTickRate;
		EntityArchetype tryMoveToDisabledArchetype = _tryMoveToDisabledArchetype;
		bool printMissingComponentErrors = false;
		bool flag = false;
		if (__query_1359213098_9.IsEmpty)
		{
			Entity e = ecb.CreateEntity(0);
			ecb.AddComponent<WorldHasBeenDeserializedCD>(0, e);
			flag = true;
			__query_1359213098_18.TryGetSingleton<WorldVersionSerializedCD>(out var value3);
			printMissingComponentErrors = value3.Version == 12;
		}
		DeserializeComponentsSystem_514D995_LambdaJob_0_Execute(databaseBankBlob, ecb, bufferLookup, bufferLookup2, bufferLookup3, bufferLookup4, bufferLookup5, bufferLookup6, bufferLookup7, bufferLookup8, bufferLookup9, bufferLookup10, bufferLookup11, bufferLookup12, singleton, bufferLookup15, bufferLookup16, bufferLookup17, bufferLookup18, bufferLookup19, bufferLookup20, componentLookup, bufferLookup21, componentLookup2, componentLookup3, singleton2, componentLookup4, componentLookup5, season, serverTick, simulationTickRate, tryMoveToDisabledArchetype, printMissingComponentErrors);
		if (flag)
		{
			DeserializeComponentsSystem_514D995_LambdaJob_1_Execute(singletonBuffer, ecb, bufferLookup13, bufferLookup14);
			DeserializeComponentsSystem_514D995_LambdaJob_2_Execute(ecb);
			DeserializeComponentsSystem_514D995_LambdaJob_3_Execute(ecb, componentLookup6);
			DeserializeComponentsSystem_514D995_LambdaJob_4_Execute(ecb);
			Entity singletonEntity = __query_1359213098_19.GetSingletonEntity();
			DeserializeComponentsSystem_514D995_LambdaJob_5_Execute(ecb, singletonEntity);
			DeserializeComponentsSystem_514D995_LambdaJob_6_Execute(singletonBuffer2, ecb);
			DeserializeComponentsSystem_514D995_LambdaJob_7_Execute(ecb);
			DeserializeComponentsSystem_514D995_LambdaJob_8_Execute(ecb);
		}
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_0_Execute(BlobAssetReference<PugDatabase.PugDatabaseBank> database, EntityCommandBuffer.ParallelWriter ecb, BufferLookup<ContainedObjectsSerializedBuffer> containedObjectsBufferLookup, BufferLookup<ContainedObjectsAuxIndexSerializedBuffer> containedAuxObjectsBufferLookup, BufferLookup<ContainedObjectsBuffer> containedObjectsNonSerializedBufferLookup, BufferLookup<ConditionsSerializedBuffer> conditionsBufferLookup, BufferLookup<ConditionsBuffer> conditionsNonSerializedBufferLookup, BufferLookup<AffixSerializedBuffer> affixBufferLookup, BufferLookup<ActiveAffixStateBuffer> activeAffixStateNonSerializedBufferLookup, BufferLookup<ActiveAffixConditionsBuffer> activeAffixConditionNonSerializedBufferLookup, BufferLookup<DropsLootSerializedBuffer> dropsLootBufferLookup, BufferLookup<DropsLootBuffer> dropsLootNonSerializedBufferLookup, BufferLookup<DescriptionSerializedBuffer> descriptionBufferLookup, BufferLookup<DescriptionBuffer> descriptionNonSerializedBufferLookup, ConditionsTableCD conditionsTable, BufferLookup<CraftingByRecipeSlotBuffer> craftingWithRecipeSlotBufferLookup, BufferLookup<CraftingTimerSlotBuffer> craftingTimerSlotBufferLookup, BufferLookup<CraftingByConsumedObjectSlotBuffer> craftingByConsumedObjectSlotBufferLookup, BufferLookup<CraftingSlotTimerSerialized> craftingSlotTimerSerializedLookup, BufferLookup<CraftingSlotByRecipesSerialized> craftingSlotRecipesSerializedLookup, BufferLookup<CraftingSlotByConsumedObjectsSerialized> craftingSlotObjectsSerializedLookup, ComponentLookup<ObjectFilteringCD> moverFilterLookup, BufferLookup<FilteringSerializedBuffer> filteringSerializedLookup, ComponentLookup<PugAutomationEnabledMoverSyncedCD> pugAutomationMoverOrchestratorSyncedLookup, ComponentLookup<MoverOrchestratorSerialized> moverOrchestratorSerializedLookup, ObjectLookupWriterCD objectLookupWriterCD, ComponentLookup<MoveeSerialized> moveeBigEntitySerializedLookup, ComponentLookup<MoveeBigEntityCD> moveeBigEntityLookup, Season currentSeason, NetworkTick currentTick, uint tickRate, EntityArchetype tryMoveToDisabledArchetype, bool printMissingComponentErrors)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_Translation_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataSerializedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RotationSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__SeasonObjectCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__CharacterGuidSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__CreateNewGuidCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClaimedByCharacterGuidSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClaimedByCharacterGuidCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGuidSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClaimedByPlayerGuidSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClaimedByPlayerGuidCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__GrowingSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__GrowingCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HungerSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HungerCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__LootTableSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DropsLootFromLootTableCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PaintableObjectSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PaintableObjectCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BreedStateSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__MealsEatenCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BreedToggleSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BreedToggleCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DirectionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HasBeenDiscoveredSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__CanBeDiscoveredCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__SpawnStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__CustomSceneObjectSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ActiveEquipmentPresetSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ActiveEquipmentPresetCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__NameSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__NameCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGhost_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerLastSessionSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__SpawnPointCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__SnakeBossSegmentSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__SnakeSegmentCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ImmunityZoneShapeSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ImmunityZoneCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_0_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_0_Job
		{
			database = database,
			ecb = ecb,
			containedObjectsBufferLookup = containedObjectsBufferLookup,
			containedAuxObjectsBufferLookup = containedAuxObjectsBufferLookup,
			containedObjectsNonSerializedBufferLookup = containedObjectsNonSerializedBufferLookup,
			conditionsBufferLookup = conditionsBufferLookup,
			conditionsNonSerializedBufferLookup = conditionsNonSerializedBufferLookup,
			affixBufferLookup = affixBufferLookup,
			activeAffixStateNonSerializedBufferLookup = activeAffixStateNonSerializedBufferLookup,
			activeAffixConditionNonSerializedBufferLookup = activeAffixConditionNonSerializedBufferLookup,
			dropsLootBufferLookup = dropsLootBufferLookup,
			dropsLootNonSerializedBufferLookup = dropsLootNonSerializedBufferLookup,
			descriptionBufferLookup = descriptionBufferLookup,
			descriptionNonSerializedBufferLookup = descriptionNonSerializedBufferLookup,
			conditionsTable = conditionsTable,
			craftingWithRecipeSlotBufferLookup = craftingWithRecipeSlotBufferLookup,
			craftingTimerSlotBufferLookup = craftingTimerSlotBufferLookup,
			craftingByConsumedObjectSlotBufferLookup = craftingByConsumedObjectSlotBufferLookup,
			craftingSlotTimerSerializedLookup = craftingSlotTimerSerializedLookup,
			craftingSlotRecipesSerializedLookup = craftingSlotRecipesSerializedLookup,
			craftingSlotObjectsSerializedLookup = craftingSlotObjectsSerializedLookup,
			moverFilterLookup = moverFilterLookup,
			filteringSerializedLookup = filteringSerializedLookup,
			pugAutomationMoverOrchestratorSyncedLookup = pugAutomationMoverOrchestratorSyncedLookup,
			moverOrchestratorSerializedLookup = moverOrchestratorSerializedLookup,
			objectLookupWriterCD = objectLookupWriterCD,
			moveeBigEntitySerializedLookup = moveeBigEntitySerializedLookup,
			moveeBigEntityLookup = moveeBigEntityLookup,
			currentSeason = currentSeason,
			currentTick = currentTick,
			tickRate = tickRate,
			tryMoveToDisabledArchetype = tryMoveToDisabledArchetype,
			printMissingComponentErrors = printMissingComponentErrors,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__translationTypeHandle = __TypeHandle.__Unity_Transforms_Translation_RO_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataSerializedCD_RO_ComponentTypeHandle,
			__RotationSerializedCD_ComponentLookup = __TypeHandle.__RotationSerializedCD_RO_ComponentLookup,
			__SeasonObjectCD_ComponentLookup = __TypeHandle.__SeasonObjectCD_RO_ComponentLookup,
			__CharacterGuidSerializedCD_ComponentLookup = __TypeHandle.__CharacterGuidSerializedCD_RO_ComponentLookup,
			__CreateNewGuidCD_ComponentLookup = __TypeHandle.__CreateNewGuidCD_RO_ComponentLookup,
			__ClaimedByCharacterGuidSerializedCD_ComponentLookup = __TypeHandle.__ClaimedByCharacterGuidSerializedCD_RO_ComponentLookup,
			__ClaimedByCharacterGuidCD_ComponentLookup = __TypeHandle.__ClaimedByCharacterGuidCD_RO_ComponentLookup,
			__PlayerGuidSerializedCD_ComponentLookup = __TypeHandle.__PlayerGuidSerializedCD_RO_ComponentLookup,
			__ClaimedByPlayerGuidSerializedCD_ComponentLookup = __TypeHandle.__ClaimedByPlayerGuidSerializedCD_RO_ComponentLookup,
			__ClaimedByPlayerGuidCD_ComponentLookup = __TypeHandle.__ClaimedByPlayerGuidCD_RO_ComponentLookup,
			__HealthSerializedCD_ComponentLookup = __TypeHandle.__HealthSerializedCD_RO_ComponentLookup,
			__HealthCD_ComponentLookup = __TypeHandle.__HealthCD_RO_ComponentLookup,
			__GrowingSerializedCD_ComponentLookup = __TypeHandle.__GrowingSerializedCD_RO_ComponentLookup,
			__GrowingCD_ComponentLookup = __TypeHandle.__GrowingCD_RO_ComponentLookup,
			__HungerSerializedCD_ComponentLookup = __TypeHandle.__HungerSerializedCD_RO_ComponentLookup,
			__HungerCD_ComponentLookup = __TypeHandle.__HungerCD_RO_ComponentLookup,
			__LootTableSerializedCD_ComponentLookup = __TypeHandle.__LootTableSerializedCD_RO_ComponentLookup,
			__DropsLootFromLootTableCD_ComponentLookup = __TypeHandle.__DropsLootFromLootTableCD_RO_ComponentLookup,
			__PaintableObjectSerializedCD_ComponentLookup = __TypeHandle.__PaintableObjectSerializedCD_RO_ComponentLookup,
			__PaintableObjectCD_ComponentLookup = __TypeHandle.__PaintableObjectCD_RO_ComponentLookup,
			__BreedStateSerializedCD_ComponentLookup = __TypeHandle.__BreedStateSerializedCD_RO_ComponentLookup,
			__MealsEatenCD_ComponentLookup = __TypeHandle.__MealsEatenCD_RO_ComponentLookup,
			__BreedToggleSerializedCD_ComponentLookup = __TypeHandle.__BreedToggleSerializedCD_RO_ComponentLookup,
			__BreedToggleCD_ComponentLookup = __TypeHandle.__BreedToggleCD_RO_ComponentLookup,
			__DirectionCD_ComponentLookup = __TypeHandle.__DirectionCD_RO_ComponentLookup,
			__HasBeenDiscoveredSerializedCD_ComponentLookup = __TypeHandle.__HasBeenDiscoveredSerializedCD_RO_ComponentLookup,
			__CanBeDiscoveredCD_ComponentLookup = __TypeHandle.__CanBeDiscoveredCD_RO_ComponentLookup,
			__SpawnStateCD_ComponentLookup = __TypeHandle.__SpawnStateCD_RO_ComponentLookup,
			__CustomSceneObjectSerializedCD_ComponentLookup = __TypeHandle.__CustomSceneObjectSerializedCD_RO_ComponentLookup,
			__ActiveEquipmentPresetSerializedCD_ComponentLookup = __TypeHandle.__ActiveEquipmentPresetSerializedCD_RO_ComponentLookup,
			__ActiveEquipmentPresetCD_ComponentLookup = __TypeHandle.__ActiveEquipmentPresetCD_RO_ComponentLookup,
			__NameSerializedCD_ComponentLookup = __TypeHandle.__NameSerializedCD_RO_ComponentLookup,
			__NameCD_ComponentLookup = __TypeHandle.__NameCD_RO_ComponentLookup,
			__PlayerGhost_ComponentLookup = __TypeHandle.__PlayerGhost_RO_ComponentLookup,
			__PlayerSerializedCD_ComponentLookup = __TypeHandle.__PlayerSerializedCD_RO_ComponentLookup,
			__PlayerLastSessionSerializedCD_ComponentLookup = __TypeHandle.__PlayerLastSessionSerializedCD_RO_ComponentLookup,
			__SpawnPointCD_ComponentLookup = __TypeHandle.__SpawnPointCD_RO_ComponentLookup,
			__SnakeBossSegmentSerializedCD_ComponentLookup = __TypeHandle.__SnakeBossSegmentSerializedCD_RO_ComponentLookup,
			__SnakeSegmentCD_ComponentLookup = __TypeHandle.__SnakeSegmentCD_RO_ComponentLookup,
			__ImmunityZoneShapeSerializedCD_ComponentLookup = __TypeHandle.__ImmunityZoneShapeSerializedCD_RO_ComponentLookup,
			__ImmunityZoneCD_ComponentLookup = __TypeHandle.__ImmunityZoneCD_RO_ComponentLookup
		};
		JobHandle outJobHandle;
		NativeArray<int> chunkBaseEntityIndices = (jobData.__ChunkBaseEntityIndices = __query_1359213098_0.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle));
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.ScheduleParallel(jobData, __query_1359213098_0, base.CheckedStateRef.Dependency, chunkBaseEntityIndices);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_1_Execute(DynamicBuffer<InventoryAuxDataPrefabBuffer> inventoryAuxDataPrefabBuffer, EntityCommandBuffer.ParallelWriter ecb, BufferLookup<TalentsSerializedCD> talentsSerializedBufferLookup, BufferLookup<PetTalentBuffer> petTalentsBufferLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__InventoryAuxDataSerializedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__NameSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__NameCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PetSkinSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__PetSkinCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BreedStateSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__MealsEatenCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BreedToggleSerializedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BreedToggleCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_1_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_1_Job
		{
			inventoryAuxDataPrefabBuffer = inventoryAuxDataPrefabBuffer,
			ecb = ecb,
			talentsSerializedBufferLookup = talentsSerializedBufferLookup,
			petTalentsBufferLookup = petTalentsBufferLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__inventoryAuxDataSerializedTypeHandle = __TypeHandle.__InventoryAuxDataSerializedCD_RO_ComponentTypeHandle,
			__NameSerializedCD_ComponentLookup = __TypeHandle.__NameSerializedCD_RO_ComponentLookup,
			__NameCD_ComponentLookup = __TypeHandle.__NameCD_RO_ComponentLookup,
			__PetSkinSerializedCD_ComponentLookup = __TypeHandle.__PetSkinSerializedCD_RO_ComponentLookup,
			__PetSkinCD_ComponentLookup = __TypeHandle.__PetSkinCD_RO_ComponentLookup,
			__BreedStateSerializedCD_ComponentLookup = __TypeHandle.__BreedStateSerializedCD_RO_ComponentLookup,
			__MealsEatenCD_ComponentLookup = __TypeHandle.__MealsEatenCD_RO_ComponentLookup,
			__BreedToggleSerializedCD_ComponentLookup = __TypeHandle.__BreedToggleSerializedCD_RO_ComponentLookup,
			__BreedToggleCD_ComponentLookup = __TypeHandle.__BreedToggleCD_RO_ComponentLookup
		};
		JobHandle outJobHandle;
		NativeArray<int> chunkBaseEntityIndices = (jobData.__ChunkBaseEntityIndices = __query_1359213098_1.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle));
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.ScheduleParallel(jobData, __query_1359213098_1, base.CheckedStateRef.Dependency, chunkBaseEntityIndices);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_2_Execute(EntityCommandBuffer.ParallelWriter ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SubMapLayerSerializedBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_Translation_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SubMapSerializedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_2_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_2_Job
		{
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__layersTypeHandle = __TypeHandle.__SubMapLayerSerializedBuffer_RW_BufferTypeHandle,
			__translationTypeHandle = __TypeHandle.__Unity_Transforms_Translation_RO_ComponentTypeHandle,
			__submapTypeHandle = __TypeHandle.__SubMapSerializedCD_RO_ComponentTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> chunkBaseEntityIndices = (jobData.__ChunkBaseEntityIndices = __query_1359213098_2.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle));
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.ScheduleParallel(jobData, __query_1359213098_2, base.CheckedStateRef.Dependency, chunkBaseEntityIndices);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_3_Execute(EntityCommandBuffer.ParallelWriter ecb, ComponentLookup<Translation> translationSerializedLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__CustomSceneSerializedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_3_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_3_Job
		{
			ecb = ecb,
			translationSerializedLookup = translationSerializedLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__customSceneTypeHandle = __TypeHandle.__CustomSceneSerializedCD_RO_ComponentTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> chunkBaseEntityIndices = (jobData.__ChunkBaseEntityIndices = __query_1359213098_3.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle));
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.ScheduleParallel(jobData, __query_1359213098_3, base.CheckedStateRef.Dependency, chunkBaseEntityIndices);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_4_Execute(EntityCommandBuffer.ParallelWriter ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PheromoneSerializedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_4_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_4_Job
		{
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__pheromoneSerializedTypeHandle = __TypeHandle.__PheromoneSerializedCD_RO_ComponentTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> chunkBaseEntityIndices = (jobData.__ChunkBaseEntityIndices = __query_1359213098_4.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle));
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.ScheduleParallel(jobData, __query_1359213098_4, base.CheckedStateRef.Dependency, chunkBaseEntityIndices);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_5_Execute(EntityCommandBuffer.ParallelWriter ecb, Entity killedEnemiesBufferSingleton)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__KilledEnemiesSerializedBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_5_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_5_Job
		{
			ecb = ecb,
			killedEnemiesBufferSingleton = killedEnemiesBufferSingleton,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__killedEnemiesSerializedBufferTypeHandle = __TypeHandle.__KilledEnemiesSerializedBuffer_RO_BufferTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_1359213098_5.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1359213098_5, base.CheckedStateRef.Dependency);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_6_Execute(DynamicBuffer<PugPrefabBuffer> pugPrefabBuffer, EntityCommandBuffer.ParallelWriter ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ActivatedContentBundlesSerializedBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ActivatedContentBundlesBuffer_RO_BufferLookup.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_6_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_6_Job
		{
			pugPrefabBuffer = pugPrefabBuffer,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__activatedContentBundlesSerializedBufferTypeHandle = __TypeHandle.__ActivatedContentBundlesSerializedBuffer_RO_BufferTypeHandle,
			__ActivatedContentBundlesBuffer_BufferLookup = __TypeHandle.__ActivatedContentBundlesBuffer_RO_BufferLookup
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_1359213098_6.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1359213098_6, base.CheckedStateRef.Dependency);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_7_Execute(EntityCommandBuffer.ParallelWriter ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataSerializedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_7_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_7_Job
		{
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataSerializedCD_RO_ComponentTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_1359213098_7.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1359213098_7, base.CheckedStateRef.Dependency);
	}

	private void DeserializeComponentsSystem_514D995_LambdaJob_8_Execute(EntityCommandBuffer.ParallelWriter ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TheGreatWallStatusSerializedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		DeserializeComponentsSystem_514D995_LambdaJob_8_Job jobData = new DeserializeComponentsSystem_514D995_LambdaJob_8_Job
		{
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__wallStatusTypeHandle = __TypeHandle.__TheGreatWallStatusSerializedCD_RO_ComponentTypeHandle
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_1359213098_8.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1359213098_8, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Translation>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataSerializedCD>();
		__query_1359213098_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryAuxDataSerializedCD>();
		__query_1359213098_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<Translation>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<SubMapSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SubMapLayerSerializedBuffer>();
		__query_1359213098_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CustomSceneSerializedCD>();
		__query_1359213098_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PheromoneSerializedCD>();
		__query_1359213098_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<KilledEnemiesSerializedBuffer>();
		__query_1359213098_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ActivatedContentBundlesSerializedBuffer>();
		__query_1359213098_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ScannedObjectSerializedCD>();
		__query_1359213098_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallStatusSerializedCD>();
		__query_1359213098_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldHasBeenDeserializedCD>();
		__query_1359213098_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_11 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<InventoryAuxDataPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_12 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PugPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_13 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_14 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectLookupWriterCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_15 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_16 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_17 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldVersionSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_18 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<KilledEnemiesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359213098_19 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public DeserializeComponentsSystem()
	{
	}
}
