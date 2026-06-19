using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public static class MinionExtensions
{
	private const int DEFAULT_MAX_MINIONS = 1;

	private const string minionMeleeDamageTerm = "weaponMeleeDamage";

	private const string minionRangeDamageTerm = "weaponRangeDamage";

	private const string minionMiningDamageTerm = "Conditions/MiningIncrease";

	private const string minionHealthTerm = "WeaponSecondary/MinionHealth";

	private const string minionLifespanTerm = "WeaponSecondary/MinionLifespan";

	public const string commandMinionTerm = "useItemTerm";

	private const string spawnMinionTerm = "weaponSecondary";

	private const string conditionTerm = "Conditions/";

	public static int GetMinionLevelFromWeaponLevel(ObjectDataCD objectDataCD, int weaponItemLevel)
	{
		int maxLevel = LevelScaling.GetMaxLevel();
		if (objectDataCD.variation <= 0)
		{
			return weaponItemLevel;
		}
		return math.min(maxLevel, objectDataCD.variation);
	}

	public static int GetMinionMaxHealth(int minionLevel)
	{
		return 100 + minionLevel * 50;
	}

	public static int GetMinionBaseDamage(MinionCD minionCD, int level)
	{
		return (int)math.round((float)(30 + level * 3) * minionCD.damageMultiplier);
	}

	public static int GetMinionDamage(MinionCD minionCD, MinionLevelCD levelCD, DynamicBuffer<SummarizedConditionsBuffer> conditions, DynamicBuffer<SummarizedConditionEffectsBuffer> conditionEffects)
	{
		int minionBaseDamage = GetMinionBaseDamage(minionCD, levelCD.value);
		float num = 1f + (float)conditionEffects[105].value / 1000f;
		num += (float)conditions[279].value / 100f * ((float)conditionEffects[102].value / 1000f);
		return (int)math.round((float)minionBaseDamage * num);
	}

	public static int GetMinionTileDamage(MiningMinionCD miningMinion, int minionLevel)
	{
		return DamageObjectStateAuthoring.LevelToTileDamage(minionLevel, miningMinion.damageMultiplier, isEnemy: false);
	}

	public static int GetMinionAttackSpeed(DynamicBuffer<SummarizedConditionEffectsBuffer> conditions)
	{
		return conditions[114].value;
	}

	public static int GetMinionCritChance(DynamicBuffer<SummarizedConditionEffectsBuffer> conditions)
	{
		return conditions[115].value;
	}

	public static int GetMinionCritDamage(DynamicBuffer<SummarizedConditionEffectsBuffer> conditions)
	{
		return conditions[128].value;
	}

	public static int GetMinionBossDamage(DynamicBuffer<SummarizedConditionEffectsBuffer> conditions)
	{
		return conditions[129].value;
	}

	public static int GetLifeSpan(DynamicBuffer<SummarizedConditionEffectsBuffer> conditions)
	{
		return 60 + (int)math.round(60f * ((float)conditions[103].value / 100f));
	}

	public static List<ConditionData> GetMinionConditionData(List<ConditionData> conditionsData, int level, ConditionsTable conditionsTable)
	{
		for (int i = 0; i < conditionsData.Count; i++)
		{
			int upgradedConditionValue = GetUpgradedConditionValue(conditionsData[i].conditionID, level);
			conditionsData[i] = new ConditionData
			{
				conditionID = conditionsData[i].conditionID,
				value = upgradedConditionValue,
				valueMultiplier = ((conditionsData[i].valueMultiplier != 0f) ? conditionsData[i].valueMultiplier : 1f),
				duration = conditionsData[i].duration
			};
		}
		return conditionsData;
	}

	public static int GetUpgradedConditionValue(ConditionID conditionID, int level)
	{
		int result = 0;
		switch (conditionID)
		{
		case ConditionID.ApplyBurning:
		case ConditionID.ApplyBurningIfBurning:
			result = ConditionExtensions.GetApplyBurning(level);
			break;
		case ConditionID.AuraApplyRadioactiveDamageOverTime:
			result = ConditionExtensions.GetRadioactiveDamageOverTime(level);
			break;
		case ConditionID.ChanceToApplyPoisoned:
			result = ConditionExtensions.GetChanceToApplyPoison(level);
			break;
		}
		return result;
	}

	public static int GetMaxMinions(DynamicBuffer<SummarizedConditionEffectsBuffer> conditions)
	{
		return 1 + conditions[113].value;
	}

	public static List<TextAndFormatFields> GetSummonMinionStatText(ObjectID minionToSpawn, ObjectDataCD weaponObjectData, string weaponSecondaryTerm, string weaponSecondaryCategory, bool previewUpgraded)
	{
		List<TextAndFormatFields> list = new List<TextAndFormatFields>();
		bool flag = PugDatabase.HasComponent<HealthCD>(minionToSpawn);
		MinionCD component = PugDatabase.GetComponent<MinionCD>(minionToSpawn);
		int num = ((weaponObjectData.variation > 0 || !PugDatabase.HasComponent<LevelCD>(weaponObjectData)) ? weaponObjectData.variation : PugDatabase.GetComponent<LevelCD>(weaponObjectData).level);
		int minionLevelFromWeaponLevel = GetMinionLevelFromWeaponLevel(weaponObjectData, num);
		int minionBaseDamage = GetMinionBaseDamage(component, minionLevelFromWeaponLevel);
		string term = (PugDatabase.HasComponent<RangeAttackStateCD>(minionToSpawn) ? "weaponRangeDamage" : "weaponMeleeDamage");
		MiningMinionCD component2;
		bool flag2 = PugDatabase.TryGetComponent<MiningMinionCD>(minionToSpawn, out component2);
		int num2 = (flag2 ? GetMinionTileDamage(component2, minionLevelFromWeaponLevel) : 0);
		int num3 = (flag ? GetMinionMaxHealth(minionLevelFromWeaponLevel) : 0);
		int value = 60;
		Color color = Color.Lerp(Color.yellow, Color.white, 0.5f);
		DynamicBuffer<ConditionsBuffer> buffer = PugDatabase.GetBuffer<ConditionsBuffer>(minionToSpawn);
		List<ConditionData> list2 = new List<ConditionData>();
		if (buffer.Length > 0)
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i].condition.conditionData.value != 0)
				{
					list2.Add(buffer[i].condition.conditionData);
				}
			}
			GetMinionConditionData(list2, num, ConditionsTable.GetTable());
		}
		if (previewUpgraded)
		{
			int minionLevelFromWeaponLevel2 = GetMinionLevelFromWeaponLevel(new ObjectDataCD
			{
				objectID = weaponObjectData.objectID,
				variation = num + 1
			}, num + 1);
			int minionBaseDamage2 = GetMinionBaseDamage(component, minionLevelFromWeaponLevel2);
			int minionMaxHealth = GetMinionMaxHealth(minionLevelFromWeaponLevel2);
			int valueDiff = minionBaseDamage2 - minionBaseDamage;
			int valueDiff2 = minionMaxHealth - num3;
			list.Add(new TextAndFormatFields
			{
				text = "weaponSecondary",
				formatFields = new string[1] { PugText.ProcessText(weaponSecondaryCategory + minionToSpawn, null, shouldLocalize: true, shouldLocalizeFormatFields: false) },
				color = Color.yellow
			});
			list.Add(GetMinionStatText(term, minionBaseDamage2, valueDiff, color, isDamage: true));
			if (flag2)
			{
				int minionTileDamage = GetMinionTileDamage(component2, minionLevelFromWeaponLevel2);
				int valueDiff3 = minionTileDamage - num2;
				list.Add(GetMinionStatText("Conditions/MiningIncrease", minionTileDamage, valueDiff3, color, isDamage: false));
			}
			if (buffer.Length > 0)
			{
				List<ConditionData> list3 = new List<ConditionData>();
				list3.AddRange(list2);
				List<ConditionData> minionConditionData = GetMinionConditionData(list3, num + 1, ConditionsTable.GetTable());
				for (int j = 0; j < list2.Count; j++)
				{
					int valueDiff4 = minionConditionData[j].value - list2[j].value;
					list.Add(GetMinionStatText("Conditions/" + list2[j].conditionID, list2[j].value, valueDiff4, color, isDamage: false));
				}
			}
			if (flag)
			{
				list.Add(GetMinionStatText("WeaponSecondary/MinionHealth", minionMaxHealth, valueDiff2, color, isDamage: false));
			}
			list.Add(GetMinionStatText("WeaponSecondary/MinionLifespan", value, 0, color, isDamage: false));
			return list;
		}
		list.Add(new TextAndFormatFields
		{
			text = "weaponSecondary",
			formatFields = new string[1] { PugText.ProcessText(weaponSecondaryCategory + minionToSpawn, null, shouldLocalize: true, shouldLocalizeFormatFields: false) },
			color = Color.yellow
		});
		list.Add(GetMinionStatText(term, minionBaseDamage, 0, color, isDamage: true));
		if (flag2)
		{
			list.Add(GetMinionStatText("Conditions/MiningIncrease", num2, 0, color, isDamage: false));
		}
		if (buffer.Length > 0)
		{
			for (int k = 0; k < buffer.Length; k++)
			{
				list.Add(GetMinionStatText("Conditions/" + list2[k].conditionID, list2[k].value, 0, color, isDamage: false));
			}
		}
		if (flag)
		{
			list.Add(GetMinionStatText("WeaponSecondary/MinionHealth", num3, 0, color, isDamage: false));
		}
		list.Add(GetMinionStatText("WeaponSecondary/MinionLifespan", value, 0, color, isDamage: false));
		return list;
	}

	private static TextAndFormatFields GetMinionStatText(string term, int value, int valueDiff, Color color, bool isDamage)
	{
		TextAndFormatFields textAndFormatFields;
		if (isDamage)
		{
			int num = (int)((float)value * 0.1f);
			textAndFormatFields = new TextAndFormatFields();
			textAndFormatFields.text = term;
			textAndFormatFields.formatFields = new string[2]
			{
				(value - num).ToString(),
				(value + num).ToString()
			};
			textAndFormatFields.color = color;
			textAndFormatFields.additionalText = ((valueDiff > 0) ? (" (+" + valueDiff + ")") : "");
			textAndFormatFields.additionalTextColor = Manager.ui.previewReinforcedColor;
			return textAndFormatFields;
		}
		textAndFormatFields = new TextAndFormatFields();
		textAndFormatFields.text = term;
		textAndFormatFields.formatFields = new string[1] { value.ToString() };
		textAndFormatFields.color = color;
		textAndFormatFields.additionalText = ((valueDiff > 0) ? (" (+" + valueDiff + ")") : "");
		textAndFormatFields.additionalTextColor = Manager.ui.previewReinforcedColor;
		return textAndFormatFields;
	}
}
