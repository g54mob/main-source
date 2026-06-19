using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public static class ConditionUIExtensions
{
	public static List<ConditionData> GetConditions(ObjectDataCD objectData)
	{
		List<ConditionData> list = new List<ConditionData>();
		if (PugDatabase.HasComponent<ConditionsBuffer>(objectData) && !PugDatabase.HasComponent<DontShowConditionsStatTextOnItemCD>(objectData))
		{
			DynamicBuffer<ConditionsBuffer> buffer = PugDatabase.GetBuffer<ConditionsBuffer>(objectData);
			for (int i = 0; i < buffer.Length; i++)
			{
				ConditionData conditionData = buffer[i].condition.conditionData;
				if (conditionData.conditionID != ConditionID.None)
				{
					list.Add(new ConditionData
					{
						conditionID = conditionData.conditionID,
						value = conditionData.value
					});
				}
			}
		}
		return list;
	}

	public static NativeArray<ConditionData> GetConditionsOnConsume(ObjectDataCD foodObjectData, FixedList64Bytes<ObjectDataCD> ingredients, bool isCooked, Entity playerEntity, PugDatabase.DatabaseBankCD databaseBankCD, ConditionsTableCD conditionsTableCD, ComponentLookup<FlowerCD> flowerLookup, ComponentLookup<FishCD> fishLookup, BufferLookup<GivesConditionsWhenConsumedBuffer> givesConditionsWhenConsumedBufferLookup, DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer, Allocator allocator)
	{
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(foodObjectData.objectID, databaseBankCD.databaseBankBlob, foodObjectData.variation);
		bool flag = flowerLookup.HasComponent(primaryPrefabEntity);
		bool flag2 = fishLookup.HasComponent(primaryPrefabEntity);
		bool flag3 = isCooked && CookedFoodCD.IngredientShouldBePrimary(CookedFoodCD.GetPrimaryIngredientFromVariation(foodObjectData.variation)) && CookedFoodCD.IngredientShouldBePrimary(CookedFoodCD.GetSecondaryIngredientFromVariation(foodObjectData.variation));
		foreach (ObjectDataCD item in ingredients)
		{
			Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(item.objectID, databaseBankCD.databaseBankBlob, item.variation);
			flag |= flowerLookup.HasComponent(primaryPrefabEntity2);
			flag2 |= fishLookup.HasComponent(primaryPrefabEntity2);
		}
		float num = 1f;
		float num2 = (flag3 ? 1.15f : 1f);
		if (isCooked)
		{
			num = PugDatabase.GetEntityObjectInfo(foodObjectData.objectID, databaseBankCD.databaseBankBlob).rarity switch
			{
				Rarity.Rare => 1.25f, 
				Rarity.Epic => 1.5f, 
				_ => 1f, 
			};
		}
		NativeHashMap<int, ConditionData> nativeHashMap = new NativeHashMap<int, ConditionData>(16, Allocator.Temp);
		foreach (ObjectDataCD item2 in ingredients)
		{
			Entity primaryPrefabEntity3 = PugDatabase.GetPrimaryPrefabEntity(item2.objectID, databaseBankCD.databaseBankBlob, item2.variation);
			if (!givesConditionsWhenConsumedBufferLookup.TryGetBuffer(primaryPrefabEntity3, out var bufferData))
			{
				continue;
			}
			for (int i = 0; i < bufferData.Length; i++)
			{
				ConditionData conditionData = (isCooked ? bufferData[i].conditionDataContainer.conditionDataWhenCooked : bufferData[i].conditionDataContainer.conditionData);
				if (playerEntity != Entity.Null && conditionData.conditionID == ConditionID.HungerAddition)
				{
					float num3 = 1f;
					if (flag)
					{
						num3 += (float)summarizedConditionsBuffer[129].value / 100f;
					}
					if (isCooked)
					{
						num3 += (float)summarizedConditionsBuffer[143].value / 100f;
					}
					conditionData.value = (int)math.round((float)conditionData.value * num3);
				}
				if (conditionData.conditionID != ConditionID.None)
				{
					ConditionInfoBlob conditionInfo = conditionsTableCD.GetConditionInfo(conditionData.conditionID);
					int num4 = 0;
					num4 = ((!conditionInfo.isPermanent) ? ((int)math.round((float)conditionData.value * num * num2)) : ((int)math.round(conditionData.value)));
					if (!nativeHashMap.ContainsKey((int)conditionData.conditionID))
					{
						nativeHashMap.Add((int)conditionData.conditionID, new ConditionData
						{
							conditionID = conditionData.conditionID,
							value = num4,
							valueMultiplier = conditionData.valueMultiplier,
							duration = conditionData.duration
						});
					}
					else if (conditionData.conditionID == ConditionID.IncreasedMaxHealthPermanent)
					{
						num4 = (int)math.round(nativeHashMap[(int)conditionData.conditionID].value + num4);
						nativeHashMap[(int)conditionData.conditionID] = new ConditionData
						{
							conditionID = conditionData.conditionID,
							value = num4,
							valueMultiplier = conditionData.valueMultiplier,
							duration = conditionData.duration
						};
					}
					else if (nativeHashMap[(int)conditionData.conditionID].value < num4)
					{
						nativeHashMap[(int)conditionData.conditionID] = new ConditionData
						{
							conditionID = conditionData.conditionID,
							value = num4,
							valueMultiplier = conditionData.valueMultiplier,
							duration = conditionData.duration
						};
					}
				}
			}
		}
		if (playerEntity != Entity.Null)
		{
			if (flag2)
			{
				int value = summarizedConditionsBuffer[134].value;
				if (value != 0)
				{
					nativeHashMap.Add(135, new ConditionData
					{
						conditionID = ConditionID.IncreasedBossDamageFromEatingFish,
						value = value,
						duration = 60f
					});
				}
			}
			if (isCooked)
			{
				int value2 = summarizedConditionsBuffer[141].value;
				if (value2 != 0)
				{
					nativeHashMap.Add(142, new ConditionData
					{
						conditionID = ConditionID.MeleeAttackSpeedFromCookedFood,
						value = value2,
						duration = 30f
					});
				}
				int value3 = summarizedConditionsBuffer[138].value;
				if (value3 != 0)
				{
					float num5 = 1f + (float)value3 / 100f;
					using NativeArray<int> nativeArray = nativeHashMap.GetKeyArray(Allocator.Temp);
					foreach (int item3 in nativeArray)
					{
						float duration = nativeHashMap[item3].duration * num5;
						nativeHashMap[item3] = new ConditionData
						{
							conditionID = nativeHashMap[item3].conditionID,
							value = nativeHashMap[item3].value,
							duration = duration
						};
					}
				}
			}
		}
		NativeArray<ConditionData> valueArray = nativeHashMap.GetValueArray(allocator);
		nativeHashMap.Dispose();
		return valueArray;
	}

	public static List<ConditionData> GetConditionsOnEquip(ObjectDataCD objectData)
	{
		List<ConditionData> list = new List<ConditionData>();
		if (PugDatabase.HasComponent<GivesConditionsWhenEquippedBuffer>(objectData))
		{
			Entity levelEntity = EntityUtility.GetLevelEntity(objectData);
			DynamicBuffer<GivesConditionsWhenEquippedBuffer> dynamicBuffer = ((!(levelEntity != Entity.Null)) ? PugDatabase.GetBuffer<GivesConditionsWhenEquippedBuffer>(objectData) : EntityUtility.GetBuffer<GivesConditionsWhenEquippedBuffer>(levelEntity, Manager.ecs.ClientWorld));
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				EquipmentCondition equipmentCondition = dynamicBuffer[i].equipmentCondition;
				if (equipmentCondition.id != ConditionID.None)
				{
					list.Add(new ConditionData
					{
						conditionID = equipmentCondition.id,
						value = equipmentCondition.value
					});
				}
			}
		}
		return list;
	}
}
