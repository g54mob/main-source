using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
	[SerializeField]
	public SerializedDictionary<StatTypes, float> stats;

	[SerializeField]
	private List<EnhancementUpgrade> upgrades;

	[SerializeField]
	private List<StatusEffect> statusEffects;

	[SerializeField]
	private List<StatUpgrade> statUpgrades;

	public int instances;

	[field: SerializeField]
	public ModuleCombatTypes ModuleType { get; private set; }

	public EnhancementUpgrade[] Upgrades => upgrades.ToArray();

	public event Action<Stats, EnhancementUpgrade> upgradeEvent;

	public void AddUpgrade(EnhancementUpgrade upgrade)
	{
		upgrades.Add(upgrade);
		this.upgradeEvent?.Invoke(this, upgrade);
	}

	public void RemoveUpgrade(EnhancementUpgrade upgrade)
	{
		if (upgrades.Contains(upgrade))
		{
			upgrades.Remove(upgrade);
		}
	}

	public float GetInitialStatValue(StatTypes statType)
	{
		if (stats.TryGetValue(statType, out var value))
		{
			return value;
		}
		return 0f;
	}

	public void UpdateSEs()
	{
		for (int i = 0; i < statusEffects.Count; i++)
		{
			statusEffects[i].Update();
		}
	}

	public float GetUpgradedStatValue(StatTypes statType)
	{
		float initialStatValue = GetInitialStatValue(statType);
		float num = 0f;
		float num2 = 0f;
		foreach (EnhancementUpgradeStats item in upgrades.OfType<EnhancementUpgradeStats>())
		{
			foreach (StatUpgrade item2 in item.statUpgrades.Where((StatUpgrade su) => su.stat.statType == statType))
			{
				float statValue = item2.stat.statValue;
				if (item2.isPercent)
				{
					num2 += statValue;
				}
				else
				{
					num += statValue;
				}
			}
		}
		foreach (StatusEffect statusEffect in statusEffects)
		{
			StatusEffectStats statusEffectStats = statusEffect as StatusEffectStats;
			if (statusEffect == null || statusEffectStats == null || statusEffectStats.statUpgrades == null)
			{
				continue;
			}
			foreach (StatUpgrade item3 in statusEffectStats.statUpgrades.Where((StatUpgrade su) => su.stat.statType == statType))
			{
				float num3 = item3.stat.statValue * (float)statusEffect.Stacks;
				if (item3.isPercent)
				{
					num2 += num3;
				}
				else
				{
					num += num3;
				}
			}
		}
		if (statUpgrades != null && statUpgrades.Count > 0)
		{
			foreach (StatUpgrade item4 in statUpgrades.Where((StatUpgrade su) => su.stat.statType == statType))
			{
				float statValue2 = item4.stat.statValue;
				if (item4.isPercent)
				{
					num2 += statValue2;
				}
				else
				{
					num += statValue2;
				}
			}
		}
		initialStatValue += num;
		initialStatValue *= 1f + num2 / 100f;
		if (statType == StatTypes.cooldownPrimary)
		{
			initialStatValue = Mathf.Max(initialStatValue, 0.1f);
		}
		return initialStatValue;
	}

	public StatusEffect ApplyStatusEffect(StatusEffect statusEffect)
	{
		StatusEffect statusEffect2 = statusEffects.FirstOrDefault((StatusEffect se) => se.Guid == statusEffect.Guid);
		if (statusEffect2 != null)
		{
			statusEffect2.AddStacks(1);
			return statusEffect2;
		}
		StatusEffect statusEffect3 = UnityEngine.Object.Instantiate(statusEffect);
		statusEffects.Add(statusEffect3);
		return statusEffect3;
	}

	public void RemoveStatusEffect(StatusEffect statusEffect)
	{
		if ((bool)statusEffect)
		{
			statusEffects?.RemoveAll((StatusEffect se) => se.Guid == statusEffect.Guid);
		}
	}

	public void ResetUpgrades()
	{
		upgrades.Clear();
		statusEffects.Clear();
		statUpgrades.Clear();
		instances = 0;
	}

	public void ApplyStatUpgrades(StatUpgrade su)
	{
		statUpgrades.Add(su);
	}

	public void RemoveStatUpgrades(StatUpgrade su)
	{
		statUpgrades.Remove(su);
	}
}
