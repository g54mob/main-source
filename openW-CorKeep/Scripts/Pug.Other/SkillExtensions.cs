using QFSW.QC;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

public static class SkillExtensions
{
	public class GainONeLevelPerSKillPointKey
	{
	}

	private static readonly float miningMulFactor = 1.039572f;

	private static readonly int miningBase = 50;

	private static readonly float runningMulFactor = 1.0494f;

	private static readonly int runningBase = 200;

	private static readonly float meleeMulFactor = 1.02382f;

	private static readonly int meleeBase = 50;

	private static readonly float vitalityMulFactor = 1.04943f;

	private static readonly int vitalityBase = 2000;

	private static readonly float craftingMulFactor = 1.03706f;

	private static readonly int craftingBase = 30;

	private static readonly float rangeMulFactor = 1.02382f;

	private static readonly int rangeBase = 50;

	private static readonly float gardeningMulFactor = 1.02526f;

	private static readonly int gardeningBase = 15;

	private static readonly float fishingMulFactor = 1.0193f;

	private static readonly int fishingBase = 5;

	private static readonly float cookingMulFactor = 1.03706f;

	private static readonly int cookingBase = 5;

	private static readonly float magicMulFactor = 1.02382f;

	private static readonly int magicBase = 50;

	private static readonly float summoningMulFactor = 1.0395f;

	private static readonly int summoningBase = 50;

	private static readonly float explosivesMulFactor = 1.0128f;

	private static readonly int explosivesBase = 10;

	public static readonly SharedStatic<bool> gainOneSkillPointPerLevel = SharedStatic<bool>.GetOrCreateUnsafe(0u, 3704537186779710621L, 0L);

	public static ConditionData GetConditionDataForSkill(SkillID skillID, int skillValue)
	{
		int num = GetLevelFromSkill(skillID, skillValue);
		switch (skillID)
		{
		case SkillID.Gardening:
			num = (int)math.ceil((float)num / 0.25f);
			break;
		case SkillID.Crafting:
			num = (int)math.ceil((float)num / 0.2f);
			break;
		case SkillID.Cooking:
			num = (int)math.ceil((float)num / 0.5f);
			break;
		case SkillID.Melee:
			num = (int)math.ceil((float)num / 0.2f);
			break;
		case SkillID.Range:
			num = (int)math.ceil((float)num / 0.2f);
			break;
		case SkillID.Magic:
			num = (int)math.ceil((float)num / 0.2f);
			break;
		case SkillID.Summoning:
			num = (int)math.ceil((float)num / 0.2f);
			break;
		case SkillID.Explosives:
			num = (int)math.ceil((float)num / 2f);
			break;
		}
		ConditionID conditionIDForSkill = GetConditionIDForSkill(skillID);
		return new ConditionData
		{
			conditionID = conditionIDForSkill,
			value = num
		};
	}

	private static ConditionID GetConditionIDForSkill(SkillID skillID)
	{
		switch (skillID)
		{
		case SkillID.Mining:
			return ConditionID.MiningIncrease;
		case SkillID.Running:
			return ConditionID.MovementSpeedIncrease;
		case SkillID.Melee:
			return ConditionID.PhysicalMeleeDamageIncrease;
		case SkillID.Vitality:
			return ConditionID.IncreasedMaxHealth;
		case SkillID.Crafting:
			return ConditionID.ArmorPercentageIncrease;
		case SkillID.Range:
			return ConditionID.PhysicalRangeDamageIncrease;
		case SkillID.Gardening:
			return ConditionID.ExtraHarvestChance;
		case SkillID.Fishing:
			return ConditionID.IncreasedFishing;
		case SkillID.Cooking:
			return ConditionID.ChanceToGainExtraCookedFood;
		case SkillID.Magic:
			return ConditionID.IncreasedMagicDamagePercentage;
		case SkillID.Summoning:
			return ConditionID.IncreasedMinionDamagePercentage;
		case SkillID.Explosives:
			return ConditionID.IncreasedExplosivesDamage;
		default:
			Debug.LogError("unknown skill ID");
			return ConditionID.MiningIncrease;
		}
	}

	[Preserve]
	[Command("gainOneSkillPointPerLevel", "Changes so one skill point gives one skill level for quick testing.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void GainOneSkillPointPerLevel(bool value)
	{
		gainOneSkillPointPerLevel.Data = value;
	}

	public static int GetLevelFromSkill(SkillID skillID, int skillValue)
	{
		if (gainOneSkillPointPerLevel.Data)
		{
			return math.min(skillValue, GetMaxSkillLevel(skillID));
		}
		float skillMulFactor = GetSkillMulFactor(skillID);
		int skillBase = GetSkillBase(skillID);
		return math.min((int)(math.log(1f - (float)skillValue * (1f - skillMulFactor) / (float)skillBase) / math.log(skillMulFactor)), GetMaxSkillLevel(skillID));
	}

	public static int GetSkillFromLevel(SkillID skillID, int level)
	{
		if (gainOneSkillPointPerLevel.Data)
		{
			return level;
		}
		float skillMulFactor = GetSkillMulFactor(skillID);
		int num = (int)math.round((float)GetSkillBase(skillID) * (1f - math.pow(skillMulFactor, level)) / (1f - skillMulFactor));
		for (int levelFromSkill = GetLevelFromSkill(skillID, num); levelFromSkill < math.min(level, 100); levelFromSkill = GetLevelFromSkill(skillID, num))
		{
			num++;
		}
		return num;
	}

	private static float GetSkillMulFactor(SkillID skillID)
	{
		return skillID switch
		{
			SkillID.Mining => miningMulFactor, 
			SkillID.Running => runningMulFactor, 
			SkillID.Melee => meleeMulFactor, 
			SkillID.Vitality => vitalityMulFactor, 
			SkillID.Crafting => craftingMulFactor, 
			SkillID.Range => rangeMulFactor, 
			SkillID.Gardening => gardeningMulFactor, 
			SkillID.Fishing => fishingMulFactor, 
			SkillID.Cooking => cookingMulFactor, 
			SkillID.Magic => magicMulFactor, 
			SkillID.Summoning => summoningMulFactor, 
			SkillID.Explosives => explosivesMulFactor, 
			_ => 1f, 
		};
	}

	private static int GetSkillBase(SkillID skillID)
	{
		return skillID switch
		{
			SkillID.Mining => miningBase, 
			SkillID.Running => runningBase, 
			SkillID.Melee => meleeBase, 
			SkillID.Vitality => vitalityBase, 
			SkillID.Crafting => craftingBase, 
			SkillID.Range => rangeBase, 
			SkillID.Gardening => gardeningBase, 
			SkillID.Fishing => fishingBase, 
			SkillID.Cooking => cookingBase, 
			SkillID.Magic => magicBase, 
			SkillID.Summoning => summoningBase, 
			SkillID.Explosives => explosivesBase, 
			_ => 1, 
		};
	}

	public static int GetMaxSkillLevel(SkillID skillID)
	{
		return skillID switch
		{
			SkillID.Mining => 100, 
			SkillID.Running => 100, 
			SkillID.Melee => 100, 
			SkillID.Vitality => 100, 
			SkillID.Crafting => 100, 
			SkillID.Range => 100, 
			SkillID.Gardening => 100, 
			SkillID.Fishing => 100, 
			SkillID.Cooking => 100, 
			SkillID.Magic => 100, 
			SkillID.Summoning => 100, 
			SkillID.Explosives => 100, 
			_ => 100, 
		};
	}
}
