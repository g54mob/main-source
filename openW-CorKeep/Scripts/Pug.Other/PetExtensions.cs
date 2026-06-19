using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public static class PetExtensions
{
	private static readonly float mulFactor = 1.993f;

	private static readonly int baseFactor = 200;

	public static readonly int maxLevel = 10;

	public static bool HasTalent(int index, ContainedObjectsBuffer containedPetObject)
	{
		if (InventoryHandler.TryGetExtraInventoryBuffer(containedPetObject, out DynamicBuffer<PetTalentBuffer> buffer))
		{
			if (buffer.IsCreated && buffer.Length > index)
			{
				return buffer[index].points > 0;
			}
			return false;
		}
		return false;
	}

	public static int GetAvailableTalentPoints(int currentXp, ContainedObjectsBuffer containedPetObject)
	{
		return GetTotalTalentPoints(currentXp) - GetSpentTalentPoints(containedPetObject);
	}

	public static int GetTotalTalentPoints(int currentXp)
	{
		return (int)math.floor((float)GetLevelFromXP(currentXp) / 2f);
	}

	public static int GetSpentTalentPoints(ContainedObjectsBuffer containedPetObject)
	{
		if (!InventoryHandler.TryGetExtraInventoryBuffer(containedPetObject, out DynamicBuffer<PetTalentBuffer> buffer))
		{
			return 0;
		}
		int num = 0;
		if (buffer.IsCreated)
		{
			foreach (PetTalentBuffer item in buffer)
			{
				num += item.points;
			}
		}
		return num;
	}

	public static List<PetInfosTable.PetTalentInfo> GetTalents(PetInfosTable petInfosTable, DynamicBuffer<PetTalentBuffer> petTalents, bool onlyGetActiveOnes = false)
	{
		List<PetInfosTable.PetTalentInfo> list = new List<PetInfosTable.PetTalentInfo>();
		for (int i = 0; i < 9; i++)
		{
			if (petTalents.IsCreated && petTalents.Length > i && (!onlyGetActiveOnes || petTalents[i].points > 0))
			{
				list.Add(petInfosTable.GetTalent(petTalents[i].petTalentID));
			}
			else
			{
				list.Add(petInfosTable.GetTalent(PetTalent.CritChance));
			}
		}
		return list;
	}

	public static List<ConditionData> GetActiveConditions(ContainedObjectsBuffer containedPetObject, PetInfosTable petInfosTable, PetCD petCD, Entity petEntity)
	{
		List<ConditionData> list = new List<ConditionData>();
		if (!InventoryHandler.TryGetExtraInventoryBuffer(containedPetObject, out DynamicBuffer<PetTalentBuffer> buffer))
		{
			return list;
		}
		if (!buffer.IsCreated)
		{
			return list;
		}
		float num = 1f;
		if (petEntity != Entity.Null)
		{
			num += (float)EntityUtility.GetConditionEffectValue(ConditionEffect.BuffsIncrease, petEntity, Manager.ecs.ClientWorld) / 100f;
		}
		for (int i = 0; i < buffer.Length; i++)
		{
			if (buffer[i].points <= 0)
			{
				continue;
			}
			PetInfosTable.PetTalentInfo talent = petInfosTable.GetTalent(buffer[i].petTalentID);
			float num2 = 1f;
			foreach (PetInfosTable.PetTalentMultiplierOverride multiplierOverride in talent.multiplierOverrides)
			{
				if (multiplierOverride.petId == containedPetObject.objectID)
				{
					num2 = multiplierOverride.multiplier;
					break;
				}
			}
			int num3 = (petCD.buffsOwner ? talent.buffValue : talent.value);
			list.Add(new ConditionData
			{
				conditionID = talent.conditionID,
				value = (int)math.round((float)num3 * num2 * num)
			});
		}
		return list;
	}

	public static void GetNativeActiveConditions(ObjectID petId, DynamicBuffer<PetTalentBuffer> petTalents, NativeParallelHashMap<int, PetInfosTable.PetTalentInfoBlittable> petTalentsLookUp, NativeParallelMultiHashMap<int, PetInfosTable.PetTalentMultiplierOverride> petTalentsMultiplierOverridesLookUp, PetCD petCD, float buffMultiplier, NativeList<ConditionData> result)
	{
		if (!petTalents.IsCreated)
		{
			return;
		}
		for (int i = 0; i < petTalents.Length; i++)
		{
			if (petTalents[i].points <= 0)
			{
				continue;
			}
			PetInfosTable.PetTalentInfoBlittable petTalentInfoBlittable = petTalentsLookUp[(int)petTalents[i].petTalentID];
			float valueMultiplier = 1f;
			NativeParallelMultiHashMap<int, PetInfosTable.PetTalentMultiplierOverride>.Enumerator valuesForKey = petTalentsMultiplierOverridesLookUp.GetValuesForKey((int)petTalents[i].petTalentID);
			while (valuesForKey.MoveNext())
			{
				if (valuesForKey.Current.petId == petId)
				{
					valueMultiplier = valuesForKey.Current.multiplier;
					break;
				}
			}
			valuesForKey.Dispose();
			int num = (petCD.buffsOwner ? petTalentInfoBlittable.buffValue : petTalentInfoBlittable.value);
			result.Add(new ConditionData
			{
				conditionID = petTalentInfoBlittable.conditionID,
				value = (int)((float)num * buffMultiplier),
				valueMultiplier = valueMultiplier
			});
		}
	}

	public static int GetDamage(int petExperience, PetType petType)
	{
		float num = ((petType == PetType.Melee) ? 11.5f : 10f);
		return (int)math.round(math.pow(GetLevelFromXP(petExperience), 1.7f) * num);
	}

	public static int GetLevelFromXP(int xp)
	{
		float num = mulFactor;
		int num2 = baseFactor;
		return math.min(1 + (int)(math.log(1f - (float)xp * (1f - num) / (float)num2) / math.log(num)), maxLevel);
	}

	public static int GetXPFromLevel(int level)
	{
		int num = level - 1;
		float num2 = mulFactor;
		int num3 = (int)math.round((float)baseFactor * (1f - math.pow(num2, num)) / (1f - num2));
		for (int levelFromXP = GetLevelFromXP(num3); levelFromXP < math.min(level, maxLevel); levelFromXP = GetLevelFromXP(num3))
		{
			num3++;
		}
		return num3;
	}

	public static int GetCurrentXpForCurrentLevel(int currentTotalXp)
	{
		int levelFromXP = GetLevelFromXP(currentTotalXp);
		if (levelFromXP == 1)
		{
			return currentTotalXp;
		}
		int xPFromLevel = GetXPFromLevel(levelFromXP);
		return currentTotalXp - xPFromLevel;
	}

	public static int GetTotalXpNeededToLevelUp(int currentTotalXp)
	{
		int levelFromXP = GetLevelFromXP(currentTotalXp);
		int xPFromLevel = GetXPFromLevel(levelFromXP);
		return GetXPFromLevel(levelFromXP + 1) - xPFromLevel;
	}

	public static bool IsAtMaxLevel(int currentTotalXp)
	{
		return GetLevelFromXP(currentTotalXp) >= maxLevel;
	}

	public static int GetExperienceFromDamage(int damageMultiplied)
	{
		return (int)math.min(math.max(1f, (float)damageMultiplied / 20f), 250f);
	}
}
