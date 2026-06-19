using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public static class ConditionExtensions
{
	public const float CONDITION_MIN_DEV_MULT = 0.9f;

	public const float CONDITION_MAX_DEV_MULT = 1.1f;

	private const float COOKED_CONDITION_VALUE_MULTIPLIER = 2f;

	public static bool ConditionCanBeInherited(ConditionID conditionID, ConditionsTableCD conditionsTable)
	{
		return conditionsTable.Value.Value.infos[(int)conditionID].isInheritedByProjectiles;
	}

	public static int GetStacks(ConditionID conditionID, int value)
	{
		return conditionID switch
		{
			ConditionID.InfectedWithMold => value / -70, 
			ConditionID.StackedCritChance => value / 3, 
			ConditionID.StarvingHealthDecrease => value / -1, 
			ConditionID.StarvingDamageDecrease => value / -10, 
			ConditionID.StarvingMovementSpeedDecrease => value / -12, 
			ConditionID.MeleeDamageIncreaseFromHitting => value / 20, 
			ConditionID.RangeDamageIncreaseFromShooting => value / 20, 
			ConditionID.AttackSpeedFromMissingHealth => value / 2, 
			ConditionID.SequenceExplosionTotalMaxExplosions => value, 
			ConditionID.IncreaseManaCostAndMagicDamagePercentage => value, 
			_ => 0, 
		};
	}

	public static int GetNewConditionValueFromStacks(ConditionID conditionID, int stacks, DynamicBuffer<SummarizedConditionsBuffer> summarizedConditionsBuffer)
	{
		return conditionID switch
		{
			ConditionID.InfectedWithMold => math.min(stacks * -70, -700), 
			ConditionID.StackedCritChance => math.min(stacks, 5) * 3, 
			ConditionID.RangeDamageIncreaseFromShooting => math.min(stacks, summarizedConditionsBuffer[84].value) * 20, 
			ConditionID.SequenceExplosionTotalMaxExplosions => math.min(stacks, 8), 
			ConditionID.IncreaseManaCostAndMagicDamagePercentage => math.min(stacks, 400), 
			_ => 0, 
		};
	}

	public static int GetMaxStacksForWeaponEquipmentConditions(ConditionID conditionID)
	{
		return conditionID switch
		{
			ConditionID.SequenceExplosionTotalMaxExplosions => 8, 
			ConditionID.IncreaseManaCostAndMagicDamagePercentage => 400, 
			_ => 0, 
		};
	}

	public static int GetConditionValueForAdditiveMaxCaps(ConditionID conditionID, int value)
	{
		if (conditionID == ConditionID.IncreaseManaCostAndMagicDamagePercentage)
		{
			return math.clamp(value, 0, 400);
		}
		return value;
	}

	public static List<ConditionDataContainer> LevelToConsumedConditionValues(List<ConditionDataContainer> conditionsListToUpdate, int level, uint rngSeed, ConditionsTable conditionsTable)
	{
		Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(rngSeed);
		float num = conditionsListToUpdate.Count;
		float num2 = conditionsListToUpdate.Count;
		for (int i = 0; i < conditionsListToUpdate.Count; i++)
		{
			ConditionData conditionData = conditionsListToUpdate[i].conditionData;
			if (conditionsTable.GetConditionInfo(conditionData.conditionID).isNegative || conditionData.conditionID == ConditionID.HungerAddition || conditionData.conditionID == ConditionID.None)
			{
				num = math.max(1f, num - 1f);
			}
			ConditionData conditionDataWhenCooked = conditionsListToUpdate[i].conditionDataWhenCooked;
			if (conditionsTable.GetConditionInfo(conditionDataWhenCooked.conditionID).isNegative || conditionDataWhenCooked.conditionID == ConditionID.HungerAddition || conditionDataWhenCooked.conditionID == ConditionID.None)
			{
				num2 = math.max(1f, num2 - 1f);
			}
		}
		for (int j = 0; j < conditionsListToUpdate.Count; j++)
		{
			float randomDeviationMultiplier = random.NextFloat(0.9f, 1.1f);
			ConditionData conditionData2 = conditionsListToUpdate[j].conditionData;
			ConditionInfo conditionInfo = conditionsTable.GetConditionInfo(conditionData2.conditionID);
			float valueMultiplier = ((conditionData2.valueMultiplier != 0f) ? conditionData2.valueMultiplier : 1f);
			float valueDivider = ((conditionData2.conditionID == ConditionID.HungerAddition) ? 1f : num);
			int conditionValueFromLevel = GetConditionValueFromLevel(conditionInfo.effect, conditionInfo.isNegative, level, valueMultiplier, randomDeviationMultiplier, valueDivider, isTemporary: true, isHeldInHand: false, isArmor: false, isEnemy: false, conditionInfo.Id);
			ConditionData conditionDataWhenCooked2 = conditionsListToUpdate[j].conditionDataWhenCooked;
			conditionInfo = conditionsTable.GetConditionInfo(conditionDataWhenCooked2.conditionID);
			float num3 = ((conditionDataWhenCooked2.valueMultiplier != 0f) ? conditionDataWhenCooked2.valueMultiplier : 1f);
			valueDivider = ((conditionData2.conditionID == ConditionID.HungerAddition) ? 1f : num2);
			int conditionValueFromLevel2 = GetConditionValueFromLevel(conditionInfo.effect, conditionInfo.isNegative, level, num3 * 2f, randomDeviationMultiplier, valueDivider, isTemporary: true, isHeldInHand: false, isArmor: false, isEnemy: false, conditionInfo.Id);
			conditionsListToUpdate[j] = new ConditionDataContainer
			{
				conditionData = new ConditionData
				{
					conditionID = conditionData2.conditionID,
					duration = conditionData2.duration,
					value = conditionValueFromLevel,
					valueMultiplier = valueMultiplier
				},
				conditionDataWhenCooked = new ConditionData
				{
					conditionID = conditionDataWhenCooked2.conditionID,
					duration = conditionDataWhenCooked2.duration,
					value = conditionValueFromLevel2,
					valueMultiplier = num3
				}
			};
		}
		return conditionsListToUpdate;
	}

	public static List<EquipmentCondition> LevelToEquipmentConditionValues(List<EquipmentCondition> conditionsListToUpdate, List<ConditionData> emptyConditionDataList, int level, uint rngSeed, bool isHeldInHand, bool isArmor, bool isEnemy, ConditionsTable conditionsTable)
	{
		emptyConditionDataList.Clear();
		for (int i = 0; i < conditionsListToUpdate.Count; i++)
		{
			EquipmentCondition equipmentCondition = conditionsListToUpdate[i];
			emptyConditionDataList.Add(new ConditionData
			{
				conditionID = equipmentCondition.id,
				value = equipmentCondition.value,
				valueMultiplier = equipmentCondition.valueMultiplier
			});
		}
		LevelToConditionValues(emptyConditionDataList, level, rngSeed, isHeldInHand, isArmor, isEnemy, conditionsTable);
		for (int j = 0; j < emptyConditionDataList.Count; j++)
		{
			ConditionData conditionData = emptyConditionDataList[j];
			conditionsListToUpdate[j] = new EquipmentCondition
			{
				id = conditionData.conditionID,
				value = conditionData.value,
				valueMultiplier = conditionData.valueMultiplier
			};
		}
		emptyConditionDataList.Clear();
		return conditionsListToUpdate;
	}

	public static void LevelToConditionValues(List<ConditionData> conditionsListToUpdate, int level, uint rngSeed, bool isHeldInHand, bool isArmor, bool isEnemy, ConditionsTable conditionsTable)
	{
		Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(rngSeed);
		float num = conditionsListToUpdate.Count;
		for (int i = 0; i < conditionsListToUpdate.Count; i++)
		{
			ConditionInfo conditionInfo = conditionsTable.GetConditionInfo(conditionsListToUpdate[i].conditionID);
			if (conditionInfo.isNegative)
			{
				num = math.max(1f, num - 1.2f);
			}
			else if (conditionInfo.effect == ConditionEffect.MaxHealth || conditionInfo.effect == ConditionEffect.MaxHealthPercentage || conditionInfo.effect == ConditionEffect.MaxHealthPermanent || (isArmor && conditionInfo.effect == ConditionEffect.MaxMana) || (isArmor && conditionInfo.Id == ConditionID.IncreasedManaRegen))
			{
				num = math.max(1f, num - 1f);
			}
		}
		for (int j = 0; j < conditionsListToUpdate.Count; j++)
		{
			ConditionData conditionData = conditionsListToUpdate[j];
			float randomDeviationMultiplier = random.NextFloat(0.9f, 1.1f);
			ConditionInfo conditionInfo2 = conditionsTable.GetConditionInfo(conditionData.conditionID);
			int conditionValueFromLevel = GetConditionValueFromLevel(conditionInfo2.effect, conditionInfo2.isNegative, level, conditionData.valueMultiplier, randomDeviationMultiplier, num, isTemporary: false, isHeldInHand, isArmor, isEnemy, conditionInfo2.Id);
			conditionsListToUpdate[j] = new ConditionData
			{
				conditionID = conditionData.conditionID,
				value = conditionValueFromLevel,
				valueMultiplier = ((conditionData.valueMultiplier != 0f) ? conditionData.valueMultiplier : 1f),
				duration = conditionData.duration
			};
		}
	}

	public static int GetConditionValueFromLevel(ConditionEffect effect, bool isNegative, int level, float valueMultiplier, float randomDeviationMultiplier, float valueDivider, bool isTemporary, bool isHeldInHand, bool isArmor, bool isEnemy, ConditionID conditionIDToCheckIfEffectNotFound = ConditionID.None)
	{
		int num = 0;
		bool flag = true;
		switch (effect)
		{
		case ConditionEffect.None:
			flag = false;
			num = 0;
			break;
		case ConditionEffect.Glowing:
			num = (int)math.round(math.min(math.max(2f, (float)level * 0.6f), 10f));
			break;
		case ConditionEffect.MovementSpeed:
			num = (isNegative ? (-50) : ((int)math.round(40f + (float)level * 5f * (isTemporary ? 3f : 1f))));
			break;
		case ConditionEffect.ReducedImpactOfSlowedBySlime:
			num = (int)math.clamp(20f + (float)level * 0.5f, 1f, 45f);
			break;
		case ConditionEffect.ArmorAffectedByMovementSpeed:
			num = -(int)math.round(10f + (float)level * 5f);
			break;
		case ConditionEffect.Health:
			num = (int)math.round(10 + level * 10);
			if (isNegative)
			{
				num = -num;
			}
			break;
		case ConditionEffect.HealOverTime:
		{
			float num2 = math.pow(level, 1.2f);
			num = (isTemporary ? ((int)math.round(15f + num2 / 4f * 10f)) : ((int)math.max(1f, math.round(num2))));
			break;
		}
		case ConditionEffect.HealOverTimePercentage:
			num = (int)math.round(10 + level * 2);
			break;
		case ConditionEffect.MaxHealth:
		case ConditionEffect.MaxHealthPermanent:
			if (isArmor)
			{
				valueDivider = 1f;
			}
			num = (int)math.round((float)(level * 3) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.ProtectiveArmor:
			num = (int)math.round(level * 2);
			break;
		case ConditionEffect.Hunger:
			num = 10;
			break;
		case ConditionEffect.Mining:
			num = GetMiningDamage(level, isHeldInHand);
			break;
		case ConditionEffect.Digging:
			num = ((level >= 11) ? (50 + 10 * level) : (10 + 10 * level));
			break;
		case ConditionEffect.MiningPercentage:
			num = (int)math.round(1 + level * 2);
			break;
		case ConditionEffect.PhysicalMeleeDamage:
		case ConditionEffect.PhysicalRangeDamage:
			num = (int)math.round(30f + (float)math.max(1, level * 20) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.MeleeDamage:
		case ConditionEffect.RangeDamage:
			num = (int)math.round(25f + (float)math.max(1, level * 18) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.MagicDamage:
			num = (int)math.round(25f + (float)math.max(1, level * 18) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.AllDamage:
			num = (int)math.round(20f + math.max(1f, (float)level * 15f) * (isTemporary ? 2f : 1f));
			if (isNegative)
			{
				num = -(int)math.round((float)num * 0.3f);
			}
			break;
		case ConditionEffect.DamageBasedOnTargetRemainingHealth:
			num = (int)math.round(40f + math.max(1f, (float)level * 30f) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.Armor:
			if (isArmor)
			{
				valueDivider = 1f;
			}
			num = (int)math.round((1f + math.max(1f, (float)level * 1.5f)) * (isTemporary ? 2f : 1f));
			if (isNegative)
			{
				num = -num;
			}
			break;
		case ConditionEffect.ArmorPercentage:
			num = (int)math.round((10f + math.max(1f, (float)level * 50f)) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.CritChance:
		case ConditionEffect.ApplyPetCritChanceIncrease:
			num = (int)math.round(3f + (float)level * 0.7f);
			break;
		case ConditionEffect.CriticalDamagePercentage:
		case ConditionEffect.ApplyPetCritDamageIncrease:
			num = (int)math.round(8 + level * 2);
			break;
		case ConditionEffect.ChanceToApplyPoisoned:
			num = GetChanceToApplyPoison(level);
			break;
		case ConditionEffect.ChanceOnHitToApplySlipperyMovement:
			num = (int)math.round(10 + level * 2);
			break;
		case ConditionEffect.ChanceToDealTripleDamage:
			num = (int)math.round(1 + level);
			break;
		case ConditionEffect.DodgeChance:
			num = (int)math.round(3f + (float)level * 0.7f);
			break;
		case ConditionEffect.DamageEverySecond:
		case ConditionEffect.ApplyDamageEverySecond:
			num = (int)math.round(10 + level * 10);
			break;
		case ConditionEffect.Burning:
		case ConditionEffect.ApplyBurning:
		case ConditionEffect.ApplyBurningIfBurning:
			num = (isEnemy ? ((int)math.round(level * 2)) : GetApplyBurning(level));
			break;
		case ConditionEffect.RegenManaFromQualitySleep:
			num = (int)math.round(level * 2);
			break;
		case ConditionEffect.ApplySlowedBySlime:
			num = math.clamp(level * -75, -600, 600);
			break;
		case ConditionEffect.ApplyMovementSpeedReduction:
			num = -(int)math.min(math.round(100 + level * 50), 900f);
			break;
		case ConditionEffect.LifeOnHit:
			num = (int)math.round(math.max(1f, (float)level * 0.5f));
			break;
		case ConditionEffect.ManaOnHit:
			num = (int)math.round(math.max(1f, (float)level * 0.5f));
			break;
		case ConditionEffect.LifeOnMinionHit:
			num = (int)math.round(math.max(1f, (float)level * 0.5f));
			break;
		case ConditionEffect.LifeOnPetHit:
			num = (int)math.round(math.max(1f, (float)level * 0.5f));
			break;
		case ConditionEffect.ThornsDamage:
			num = (int)math.round(1 + level * 2);
			break;
		case ConditionEffect.ReadyToAmassThenReciprocateDamage:
			num = (int)math.round(1 + level * 40);
			break;
		case ConditionEffect.HarvestChance:
			num = (int)math.round(10 + level * 20);
			break;
		case ConditionEffect.ChanceOnHitToKnockback:
			num = (int)math.round(10 + level) * ((!isHeldInHand) ? 1 : 2);
			break;
		case ConditionEffect.ReducedDamageFromBosses:
			num = (int)math.round(5f + (float)level * 0.7f);
			break;
		case ConditionEffect.ReducedDamageFromExplosions:
			num = (int)math.round(15f + (float)level * 1f);
			break;
		case ConditionEffect.DamageTakenPercentage:
			num = (int)(-10f * math.round(5f + (float)level * 0.7f));
			if (isNegative)
			{
				num = -num;
			}
			break;
		case ConditionEffect.Poisoned:
		case ConditionEffect.ImmuneToSlimeSlow:
		case ConditionEffect.ApplySnare:
		case ConditionEffect.Snared:
		case ConditionEffect.ChanceOnCritToSpawnThunderBeam:
		case ConditionEffect.ImmuneToPoison:
		case ConditionEffect.ImmuneToMold:
		case ConditionEffect.ImmuneToAcid:
		case ConditionEffect.MaxHealthPercentage:
		case ConditionEffect.ImmuneToSlipperyMovement:
		case ConditionEffect.ImmuneToStun:
		case ConditionEffect.ImmuneToBurning:
		case ConditionEffect.ChanceOnRangeHitToSpawnOctopusBossProjectile:
		case ConditionEffect.ThornsDamageAddedToMeleeAndRange:
		case ConditionEffect.ImmuneToCharm:
		case ConditionEffect.Charmed:
		case ConditionEffect.ImmuneToRadioactiveDamage:
			num = 15;
			break;
		case ConditionEffect.HealthPercentage:
			num = 10;
			if (isNegative)
			{
				num = -num;
			}
			break;
		case ConditionEffect.ManaPercentage:
			num = 10;
			if (isNegative)
			{
				num = -num;
			}
			break;
		case ConditionEffect.Fishing:
			num = (int)math.round(math.max(0, math.max(level, 1) * 20));
			if (!isHeldInHand)
			{
				num = (int)math.ceil((float)num * 0.3f);
			}
			break;
		case ConditionEffect.MiningSpeed:
		case ConditionEffect.MeleeAttackSpeed:
		case ConditionEffect.RangeAttackSpeed:
			if (isArmor)
			{
				valueDivider = 1f;
			}
			num = (int)math.round(math.max(1f, 20f + (float)level * 4f) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.AttackSpeed:
			if (isArmor)
			{
				valueDivider = 1f;
			}
			num = (int)math.round(math.max(1f, 10f + (float)level * 4f) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.MaxMana:
			if (isArmor)
			{
				valueDivider = 1f;
			}
			num = (int)math.round(math.max(1f, (float)level * 3f) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.ApplyPetAttackSpeedIncrease:
			num = (int)math.round(math.max(100f, (float)level * 50f));
			break;
		case ConditionEffect.DamagePercentageAgainstBosses:
			num = (int)math.round(math.max(1, level * 2));
			break;
		case ConditionEffect.ChanceOnRangeShotToStun:
		case ConditionEffect.ChanceOnMeleeHitToStun:
		case ConditionEffect.ChanceOnHitToStun:
			num = 5;
			break;
		case ConditionEffect.AppliedStunDurationPercentage:
			num = 100;
			break;
		case ConditionEffect.DamageAgainstStunned:
			num = (int)math.round(5 + level);
			break;
		case ConditionEffect.PercentageOfMiningAsMelee:
			num = (int)math.round(math.max(1, level));
			break;
		case ConditionEffect.ExplosivesDamage:
			num = (int)math.round(math.max(1f, (float)level * 2f));
			break;
		case ConditionEffect.ChanceOnHitToKillTargetWithLowerHealth:
			num = 15;
			valueDivider = 1f;
			break;
		case ConditionEffect.DrainLessHunger:
			num = (int)math.round(math.max(1, level));
			break;
		case ConditionEffect.ApplySlipperyMovementWhenHit:
			return 1;
		case ConditionEffect.ChanceForOreOnMiningWall:
			num = (int)math.round(1 + level);
			break;
		case ConditionEffect.DamageAgainstPoisoned:
		case ConditionEffect.DamageAgainstBurning:
			num = (int)math.round(5 + level);
			break;
		case ConditionEffect.CritDamageAgainstBurning:
			num = (int)math.round(10f + (float)level * 1.3f);
			break;
		case ConditionEffect.AdditionalChanceOnCritToSpawnThunderBeam:
		case ConditionEffect.AdditionalChanceOnHitToSpawnScarabBossProjectile:
		case ConditionEffect.AdditionalChanceOnRangeHitToSpawnOctopusBossProjectile:
			num = (int)math.max(1f, math.round((float)level * 0.6f));
			break;
		case ConditionEffect.IncreasedCharmDuration:
			num = (int)math.round((float)level * 10f);
			break;
		case ConditionEffect.ChanceToConsumeBurning:
			num = (int)math.round((float)level * 2f);
			break;
		case ConditionEffect.ApplyPetDamageIncrease:
			num = (int)math.round((float)level * 10f);
			break;
		case ConditionEffect.ApplyPetBuffsIncrease:
			num = (int)math.round((float)level * 0.87f);
			break;
		case ConditionEffect.ApplyPetChanceToGainManaOnAttack:
			num = (int)math.round(level);
			break;
		case ConditionEffect.SnareAndStunDurationPercentage:
			num = (int)math.round((float)level * 2f);
			break;
		case ConditionEffect.Vulnerable:
			num = 1;
			break;
		case ConditionEffect.ChanceToSpawnMinionOnHit:
			num = (int)math.round(1f + (float)level * 3f);
			break;
		case ConditionEffect.MinionLifespan:
			num = (int)math.round(10f + (float)level * 3f);
			break;
		case ConditionEffect.ManaOnCrit:
			num = (int)math.round(math.max(1, level * 2));
			break;
		case ConditionEffect.PercentageOfMagicBarrierAsMagicDamage:
			num = (int)math.round(math.max(1, level * 2));
			break;
		case ConditionEffect.MinionDamagePercentage:
			num = (int)math.round(25f + (float)math.max(1, level * 18) * (isTemporary ? 2f : 1f));
			break;
		case ConditionEffect.MinionAttackSpeed:
			num = (int)math.round(level * 50);
			break;
		case ConditionEffect.MinionCritChance:
			num = (int)math.round(level);
			break;
		case ConditionEffect.MinionCritDamage:
			num = (int)math.round(8 + level * 2);
			break;
		case ConditionEffect.MinionBossDamage:
			num = (int)math.round(math.max(1, level * 2));
			break;
		case ConditionEffect.MaxMinions:
			valueDivider = 1f;
			num = (int)math.round(math.clamp(1f + (float)level * 0.01f, 1f, 2f));
			break;
		default:
			flag = false;
			if (conditionIDToCheckIfEffectNotFound == ConditionID.None)
			{
				Debug.LogError($"No Level to condition calculation available for {effect}");
			}
			break;
		}
		if (!flag)
		{
			switch (conditionIDToCheckIfEffectNotFound)
			{
			case ConditionID.None:
				num = 0;
				break;
			case ConditionID.Love:
			case ConditionID.KillsIncreaseCritChance:
			case ConditionID.GainAttackSpeedFromMissingHealth:
			case ConditionID.RedGlowingEyes:
			case ConditionID.LookLikeGhost:
			case ConditionID.Snowing:
			case ConditionID.Sleeping:
			case ConditionID.ImmuneToVoidDamageOverTime:
			case ConditionID.LiquidMetalBuff:
			case ConditionID.LightningGunChainLightning:
			case ConditionID.SleepingFromStandingStill:
			case ConditionID.ChannelVoidBreach:
			case ConditionID.ImmuneToOil:
			case ConditionID.AmassThenReciprocateDamage:
			case ConditionID.IncreaseSequenceExplosionTotalMaxExplosionsOnHit:
			case ConditionID.SequenceExplosionTotalMaxExplosions:
			case ConditionID.ClosedEyes:
			case ConditionID.ExplosivesApplyOilOnGround:
			case ConditionID.GainSleepFromStandingStill:
			case ConditionID.IncreaseManaCostAndMagicDamagePercentagePerSecond:
			case ConditionID.IncreaseManaCostAndMagicDamagePercentage:
			case ConditionID.ChanceToSpawnFireOnAttack:
				num = 1;
				break;
			case ConditionID.ExtraHealFromSleepPercentage:
				num = (int)math.round(10 + level * 4);
				break;
			case ConditionID.GainArmorAtLowHealth:
				num = (int)math.round(math.max(10f, (float)level * 30f) * (isTemporary ? 2f : 1f));
				break;
			case ConditionID.GainHealthRegenWhileBelowHalfHealth:
				num = (int)math.round(math.max(1f, (float)level * 1f) * (isTemporary ? 2f : 1f));
				break;
			case ConditionID.ChanceOnHitToIncreaseRangeDamage:
				num = (int)math.round(math.max(1f, (float)level * 1f) * (isTemporary ? 2f : 1f));
				break;
			case ConditionID.ChanceOnShotToIncreaseMeleeDamage:
				num = (int)math.round(math.max(1f, (float)level * 1f) * (isTemporary ? 2f : 1f));
				break;
			case ConditionID.GainDamageIncreaseAfterMining:
				num = (int)math.round(80f + (float)level * 20f);
				break;
			case ConditionID.ToolDurabilityLastsLonger:
			case ConditionID.EquipmentDurabilityLastsLonger:
				num = (int)math.round((float)level * 1f);
				break;
			case ConditionID.GainRangeDamageIncreaseFromStandingStill:
				num = (int)math.round(5f + (float)level * 1.5f);
				break;
			case ConditionID.GainCriticalHitChanceFromStandingStill:
				num = (int)math.round((float)level * 1.5f);
				break;
			case ConditionID.IncreasedHealthRegenEffectiveness:
				num = (int)math.round((float)level * 1.5f);
				break;
			case ConditionID.IncreaseCritChanceAfterPoisonApply:
				num = (int)math.round(6 + level * 2);
				break;
			case ConditionID.ChanceToApplyPoisonOnBlock:
				num = (int)math.round(5 + level * 2);
				break;
			case ConditionID.AuraApplyDamageDecrease:
				num = -(int)math.round(20f + math.max(1f, (float)level * 15f));
				break;
			case ConditionID.AuraApplyDamageIncrease:
				num = (int)math.round(20f + math.max(1f, (float)level * 15f));
				break;
			case ConditionID.DamageIncreaseIfBurning:
				num = (int)math.round(200f + math.max(1f, (float)level * 150f) * (isTemporary ? 2f : 1f));
				break;
			case ConditionID.AuraApplyMovementSpeedDecrease:
				num = -(int)math.round(20f + math.max(1f, (float)level * 15f));
				break;
			case ConditionID.ChanceToAddRandomConditionOnHit:
				num = (int)math.round(level * 8);
				break;
			case ConditionID.AuraApplyBurning:
				num = (int)math.round(level * 5);
				break;
			case ConditionID.AuraApplyVoidDamagePercentageOverTime:
				num = -(int)math.round((float)level * 1.5f);
				break;
			case ConditionID.ChanceOnKillToSummonGhost:
				num = 20;
				break;
			case ConditionID.ChanceToApplyCharmed:
				num = 25;
				break;
			case ConditionID.FishBitesFaster:
				num = (int)math.round(5 + level);
				break;
			case ConditionID.IncreasedChanceToGetFish:
				num = (int)math.round(5 + level);
				break;
			case ConditionID.IncreasedChanceToGetFishLoot:
				num = (int)math.round(5 + level);
				break;
			case ConditionID.FishStartsCloserToBeReeledIn:
				num = (int)math.round(3 + level);
				break;
			case ConditionID.PercentageOfFishingAsRange:
				num = (int)math.round(3 + level * 2);
				break;
			case ConditionID.ChanceToGetDoubleFish:
				num = (int)math.round(10 + level * 2);
				break;
			case ConditionID.ChanceForAdditionalOre:
				num = (int)math.round(5 + level);
				break;
			case ConditionID.IncreasedChanceForHigherRarityFish:
				num = (int)math.round(10 + level);
				break;
			case ConditionID.GainRangeDamageFromShooting:
				num = 1;
				break;
			case ConditionID.IncreasedPickUpRadius:
				num = (int)math.round(30 + level * 7);
				break;
			case ConditionID.IncreasedBoatSpeed:
				num = (int)math.round(level);
				break;
			case ConditionID.ChanceToShootShockWaveOnBlock:
				num = (int)math.round(5f + (float)level * 2f);
				break;
			case ConditionID.IncreasedArmorPercentageWhileAdjacentToWater:
				num = (int)math.round(100 + level * 10);
				break;
			case ConditionID.IncreasedMagicDamagePercentageWhileAdjacentToWater:
				num = (int)math.round(100 + level * 10);
				break;
			case ConditionID.LarvaDisguise:
				num = 1;
				break;
			case ConditionID.KingOfSlimes:
				num = 3;
				break;
			case ConditionID.Charmed:
				num = 5;
				break;
			case ConditionID.GainDamageIncreaseAtLowHealth:
				num = (int)math.round(50 + level * 10);
				break;
			case ConditionID.GainDamageIncreaseAtMaxHealth:
				num = (int)math.round(level * 10);
				break;
			case ConditionID.ChanceToSpawnNapalmFromExplosives:
				num = (int)math.round(level);
				break;
			case ConditionID.GainAttackSpeedBoostAfterDodge:
				num = (int)math.round(level * 20);
				break;
			case ConditionID.DealAoeFireDamageOnBlock:
				num = (int)math.round(10f + (float)level * 5f);
				break;
			case ConditionID.AuraApplyHealingOverTime:
			{
				float x = math.pow(level, 1.2f);
				num = (int)math.max(1f, math.round(x) * 0.7f);
				break;
			}
			case ConditionID.AuraApplyRadioactiveDamageOverTime:
				num = (isEnemy ? ((int)math.round(level * 2)) : GetRadioactiveDamageOverTime(level));
				break;
			case ConditionID.MovementSpeedBoostAfterMining:
			case ConditionID.MovementSpeedBoostAfterDodge:
				num = (int)math.round(level);
				break;
			case ConditionID.CheatDeath:
				num = (int)math.round((float)level * 0.5f);
				break;
			case ConditionID.IncreasedDashDuration:
				num = (int)math.round(level * 5);
				break;
			case ConditionID.PiercingProjectiles:
				num = (int)math.round((float)level * 0.5f);
				break;
			case ConditionID.GainManaFromExplosion:
				num = (int)math.round(level);
				break;
			case ConditionID.VisibleOreDistanceIncrease:
				num = (int)math.round((float)level * 0.5f);
				break;
			case ConditionID.GainIncreasedMaxHealthFromPet:
				num = 15;
				break;
			case ConditionID.GainMoreFoodFromPlants:
				num = (int)math.round(level);
				break;
			case ConditionID.StrongerWellFedBuffs:
				num = (int)math.round(level * 2);
				break;
			case ConditionID.IncreasedManaRegen:
				if (isArmor)
				{
					valueDivider = 1f;
				}
				num = (int)math.round(math.max(1, level * 3));
				break;
			case ConditionID.IncreasedManaRegenEffectiveness:
				num = (int)math.round(math.max(1, level * 2));
				break;
			case ConditionID.ReducedManaRegenDelayPercentage:
				num = (int)math.round(math.max(1f, 20f + (float)level * 0.5f));
				break;
			case ConditionID.MagicBarrier:
				if (isArmor)
				{
					valueDivider = 1f;
				}
				num = (int)math.round(5f + (float)(level * 2) * (isTemporary ? 2f : 1f));
				break;
			case ConditionID.GainManaPercentageOnDamageTaken:
				num = (int)math.round(math.max(1, level * 3));
				break;
			case ConditionID.GainRemainingManaAsMagicDamagePercentage:
				num = (int)math.round(math.max(1, level * 2));
				break;
			case ConditionID.IncreasedMagicDamageToMinionDamage:
				num = (int)math.round(math.max(1, level * 3));
				break;
			case ConditionID.GainMeleeDamageAsLongAsNotTakenDamage:
				num = (int)math.round(300 + level * 30);
				break;
			case ConditionID.IncreasedExplosivesRadiusPercentage:
				num = (int)math.round(math.max(1f, 10f + (float)level * 2f));
				break;
			case ConditionID.ManaBarrier:
				num = (int)math.round(level);
				break;
			case ConditionID.GainMagicDamagePercentageBoostAfterCrit:
				num = (int)math.round(math.max(1, level * 3));
				break;
			case ConditionID.ChanceToPreserveBait:
				num = (int)math.round(math.max(1, level * 2));
				break;
			case ConditionID.SpawnExplosionOnDamageTaken:
				num = (int)math.round(level * 4);
				break;
			case ConditionID.ChanceOnHitToGainMeleeAttackSpeed:
				num = (int)math.round(level);
				break;
			case ConditionID.MinionsExplodeAsTheyDespawn:
				num = 500;
				break;
			case ConditionID.ChanceToNotConsumeExplosives:
				num = (int)math.round(level * 2);
				break;
			case ConditionID.ChanceToDropExplosivesComponents:
				num = (int)math.round(8 + level);
				break;
			default:
				Debug.LogWarning($"No Level to condition calculation available for {conditionIDToCheckIfEffectNotFound}");
				break;
			}
		}
		float num3 = ((valueMultiplier != 0f) ? valueMultiplier : 1f);
		int x2 = (int)math.round((float)num * num3 * randomDeviationMultiplier / valueDivider);
		x2 = ((!((float)num * num3 >= 0f)) ? math.min(x2, -1) : math.max(x2, 1));
		if (effect == ConditionEffect.Glowing)
		{
			x2 = math.min(x2, 8);
		}
		if (math.ceil(valueMultiplier) == 0f)
		{
			x2 = 0;
		}
		return x2;
	}

	public static int GetApplyBurning(int level)
	{
		return (int)math.round(10 + level * 3);
	}

	public static int GetRadioactiveDamageOverTime(int level)
	{
		return (int)math.round(10 + level * 3);
	}

	public static int GetChanceToApplyPoison(int level)
	{
		return (int)math.round(5 + level);
	}

	public static int GetMiningDamage(int level, bool isHeldInHand)
	{
		float num = (float)level / 2f + 0.5f;
		int num2 = (int)math.round(5f * (4f + 3f * num + 3f * math.pow(num, 2f)) - 20f);
		num2 = (int)math.round((float)num2 * 0.7f);
		if (!isHeldInHand)
		{
			num2 = (int)math.round((float)num2 * 0.2f);
		}
		return num2;
	}

	public static int GetReinforcedBonusValue(int conditionValue, ConditionInfo info)
	{
		int result = 0;
		if (info.effect == ConditionEffect.MaxMinions)
		{
			return result;
		}
		if (conditionValue < 0)
		{
			result = (int)math.round(math.min(-1f, (float)conditionValue * 0.14999998f));
			if (info.isNegative)
			{
				result = -result;
			}
		}
		else
		{
			result = (int)math.round(math.max(1f, (float)conditionValue * 0.14999998f));
		}
		return result;
	}

	public static bool IsLightSource(ConditionID conditionID)
	{
		if (conditionID != ConditionID.BlueGlow && conditionID != ConditionID.OrangeGlow && conditionID != ConditionID.PinkGlow && conditionID != ConditionID.GreenGlow)
		{
			return conditionID == ConditionID.VoidGlow;
		}
		return true;
	}
}
