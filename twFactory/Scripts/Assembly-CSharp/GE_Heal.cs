using System;
using UnityEngine;

public class GE_Heal : GameplayEffect
{
	private GE_HealData healData;

	private StatsComponent enemyStatsComponent;

	private GameplayEffectsComponent enemyGEComponent;

	protected override void OnInitEffect()
	{
		healData = base.EffectData as GE_HealData;
		enemyStatsComponent = base.Owner.GetComponent<StatsComponent>();
		enemyGEComponent = base.Owner.GetComponent<GameplayEffectsComponent>();
		if (healData.Refill)
		{
			ApplyRefillHeal();
		}
		else
		{
			ApplyHeal();
		}
		InstantiateHealVFX();
		enemyGEComponent.RemoveEffect(healData);
	}

	private void ApplyHeal()
	{
		EStats stat = EStats.Health;
		EStats stat2 = EStats.HealthMax;
		switch (healData.BarType)
		{
		case GE_HealData.EBarType.Health:
			stat = EStats.Health;
			stat2 = EStats.HealthMax;
			break;
		case GE_HealData.EBarType.Armor:
			stat = EStats.Armor;
			stat2 = EStats.ArmorMax;
			break;
		case GE_HealData.EBarType.Shield:
			stat = EStats.Shield;
			stat2 = EStats.ShieldMax;
			break;
		}
		float num;
		if (healData.HealType == GE_HealData.EHealType.Normal)
		{
			num = healData.Amount;
			if (healData.IncreaseMaxStat && enemyStatsComponent.GetStat(stat2) < healData.Amount)
			{
				enemyStatsComponent.SetStat(stat2, healData.Amount * MatchInfo.instance.CurrentMatchSettings.EnemyLifeMultiplier);
			}
		}
		else
		{
			num = enemyStatsComponent.GetStat(stat2) * healData.Amount;
		}
		enemyStatsComponent.SetStat(stat, enemyStatsComponent.GetStat(stat) + num * MatchInfo.instance.CurrentMatchSettings.EnemyLifeMultiplier);
	}

	private void ApplyRefillHeal()
	{
		float num = healData.Amount * MatchInfo.instance.CurrentMatchSettings.EnemyLifeMultiplier;
		float num2 = 0f;
		num2 = MathF.Min(enemyStatsComponent.GetStat(EStats.HealthMax) - enemyStatsComponent.GetStat(EStats.Health), num);
		if (num2 > 0f)
		{
			num -= num2;
			enemyStatsComponent.SetStat(EStats.Health, enemyStatsComponent.GetStat(EStats.Health) + num2);
		}
		if (num > 0f)
		{
			num2 = MathF.Min(enemyStatsComponent.GetStat(EStats.ArmorMax) - enemyStatsComponent.GetStat(EStats.Armor), num);
			if (num2 > 0f)
			{
				num -= num2;
				enemyStatsComponent.SetStat(EStats.Armor, enemyStatsComponent.GetStat(EStats.Armor) + num2);
			}
		}
		if (num > 0f)
		{
			num2 = MathF.Min(enemyStatsComponent.GetStat(EStats.ShieldMax) - enemyStatsComponent.GetStat(EStats.Shield), num);
			if (num2 > 0f)
			{
				num -= num2;
				enemyStatsComponent.SetStat(EStats.Shield, enemyStatsComponent.GetStat(EStats.Shield) + num2);
			}
		}
	}

	private void InstantiateHealVFX()
	{
		GE_Heal_VFX original = null;
		if (healData.Refill)
		{
			original = healData.HealVFX_life;
		}
		else
		{
			switch (healData.BarType)
			{
			case GE_HealData.EBarType.Health:
				original = healData.HealVFX_health;
				break;
			case GE_HealData.EBarType.Armor:
				original = healData.HealVFX_armor;
				break;
			case GE_HealData.EBarType.Shield:
				original = healData.HealVFX_shield;
				break;
			}
		}
		UnityEngine.Object.Instantiate(original, base.Owner.transform.position, Quaternion.identity, base.Owner.transform).PlayVFX(base.Owner.gameObject);
	}
}
