using UnityEngine;

public static class StatUtils
{
	public static void ReduceCooldown(Module module, StatusEffect effect)
	{
		if (!module.hasCooldown)
		{
			return;
		}
		foreach (StatTypes key in module.StatsSO.stats.Keys)
		{
			if (key == StatTypes.cooldownPrimary && module.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) != 0f)
			{
				module.StatsSO.ApplyStatusEffect(effect);
			}
		}
	}

	public static void ReduceConsumption(Module module, StatusEffect effect)
	{
		if (!module.hasConsumption)
		{
			return;
		}
		foreach (StatTypes key in module.StatsSO.stats.Keys)
		{
			if (key == StatTypes.consumption && module.GetUpgradedStatValueByStatType(StatTypes.consumption) != 0f)
			{
				module.StatsSO.ApplyStatusEffect(effect);
			}
		}
	}

	public static void IncreaseDamage(Module module, StatusEffect effect)
	{
		foreach (StatTypes key in module.StatsSO.stats.Keys)
		{
			if (key == StatTypes.damage && module.GetUpgradedStatValueByStatType(StatTypes.damage) != 0f)
			{
				module.StatsSO.ApplyStatusEffect(effect);
			}
		}
	}

	public static void RaiseMaxHp(Module module, StatusEffect effect)
	{
		foreach (StatTypes key in module.StatsSO.stats.Keys)
		{
			if (key == StatTypes.health && module.GetUpgradedStatValueByStatType(StatTypes.health) != 0f)
			{
				module.StatsSO.ApplyStatusEffect(effect);
				module.HealthComponent.SetMaxHealth(module.GetUpgradedStatValueByStatType(StatTypes.health));
			}
		}
	}

	public static void RemoveBuff(Module module, StatusEffect effect)
	{
		module.StatsSO.RemoveStatusEffect(effect);
	}

	public static float AddMultiplier(float modifier)
	{
		if (modifier > 1f || modifier < -1f)
		{
			Debug.LogError("Modifier must be between -1 and 1!");
		}
		return 1f - modifier;
	}
}
