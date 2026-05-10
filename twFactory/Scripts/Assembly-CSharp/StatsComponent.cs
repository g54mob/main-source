using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
	public delegate void StatChanged(EStats stat, float newValue, float oldValue);

	[SerializeField]
	private List<StatConfig> statsList;

	private Dictionary<EStats, Stat> statsDic;

	private List<StatModifier> modifierOperationsList = new List<StatModifier>();

	public event StatChanged onStatChanged;

	private void Awake()
	{
		InitDefaultStats();
	}

	private void InitDefaultStats()
	{
		if (statsList == null)
		{
			statsList = new List<StatConfig>();
		}
		statsDic = new Dictionary<EStats, Stat>();
		foreach (StatConfig stats in statsList)
		{
			Stat stat = new Stat();
			stat.baseValue = stats.startValue;
			statsDic.Add(stats.stat, stat);
			UpdateCurrentValue(stats.stat);
		}
		SetStat(EStats.Health, GetStat(EStats.HealthMax));
		SetStat(EStats.Armor, GetStat(EStats.ArmorMax));
		SetStat(EStats.Shield, GetStat(EStats.ShieldMax));
	}

	private void Reset()
	{
		InitDefaultStats();
	}

	private void LimitStat(EStats stat, ref float baseValue)
	{
		switch (stat)
		{
		case EStats.Health:
			baseValue = Mathf.Clamp(baseValue, 0f, GetStat(EStats.HealthMax));
			break;
		case EStats.Armor:
			baseValue = Mathf.Clamp(baseValue, 0f, GetStat(EStats.ArmorMax));
			break;
		case EStats.Shield:
			baseValue = Mathf.Clamp(baseValue, 0f, GetStat(EStats.ShieldMax));
			break;
		case EStats.HealthMax:
		case EStats.ArmorMax:
			break;
		}
	}

	public void SetStat(EStats stat, float baseValue)
	{
		if (HasStat(stat))
		{
			float stat2 = GetStat(stat);
			LimitStat(stat, ref baseValue);
			statsDic[stat].baseValue = baseValue;
			UpdateCurrentValue(stat);
			switch (stat)
			{
			case EStats.HealthMax:
				SetStat(EStats.Health, ((stat2 > 0f) ? (GetStat(EStats.Health) / stat2) : 1f) * GetStat(EStats.HealthMax));
				break;
			case EStats.ArmorMax:
				SetStat(EStats.Armor, ((stat2 > 0f) ? (GetStat(EStats.Armor) / stat2) : 1f) * GetStat(EStats.ArmorMax));
				break;
			case EStats.ShieldMax:
				SetStat(EStats.Shield, ((stat2 > 0f) ? (GetStat(EStats.Shield) / stat2) : 1f) * GetStat(EStats.ShieldMax));
				break;
			case EStats.Armor:
			case EStats.Shield:
				break;
			}
		}
	}

	public float GetConfigStat(EStats stat)
	{
		foreach (StatConfig stats in statsList)
		{
			if (stats.stat == stat)
			{
				return stats.startValue;
			}
		}
		return 0f;
	}

	public void SetConfigStat(EStats stat, float value)
	{
		foreach (StatConfig stats in statsList)
		{
			if (stats.stat == stat)
			{
				stats.startValue = value;
				break;
			}
		}
	}

	public float GetStat(EStats stat)
	{
		if (HasStat(stat))
		{
			return statsDic[stat].currentValue;
		}
		return GetConfigStat(stat);
	}

	public float GetStatBase(EStats stat)
	{
		if (HasStat(stat))
		{
			return statsDic[stat].baseValue;
		}
		return GetConfigStat(stat);
	}

	private void SetStatCurrent(EStats stat, float currentValue)
	{
		if (HasStat(stat))
		{
			statsDic[stat].currentValue = currentValue;
		}
	}

	private void UpdateCurrentValue(EStats stat)
	{
		if (!HasStat(stat))
		{
			return;
		}
		float stat2 = GetStat(stat);
		SetStatCurrent(stat, GetStatBase(stat));
		foreach (StatModifier modifierOperations in modifierOperationsList)
		{
			if (modifierOperations.stat == stat)
			{
				ApplyModifier(modifierOperations);
			}
		}
		NotifyStatChanged(stat, GetStat(stat), stat2);
	}

	public void AddStatModifier(StatModifier statModifier)
	{
		if (HasStat(statModifier.stat))
		{
			float stat = GetStat(statModifier.stat);
			ApplyModifier(statModifier);
			modifierOperationsList.Add(statModifier);
			NotifyStatChanged(statModifier.stat, GetStat(statModifier.stat), stat);
		}
	}

	public void AddStatModifierList(List<StatModifier> statModifierList)
	{
		foreach (StatModifier statModifier in statModifierList)
		{
			AddStatModifier(statModifier);
		}
	}

	public void RemoveStatModifier(StatModifier statModifier)
	{
		if (modifierOperationsList.Contains(statModifier))
		{
			float stat = GetStat(statModifier.stat);
			RemoveModifier(statModifier);
			modifierOperationsList.Remove(statModifier);
			NotifyStatChanged(statModifier.stat, GetStat(statModifier.stat), stat);
		}
	}

	public void RemoveStatModifierList(List<StatModifier> statModifierList)
	{
		foreach (StatModifier statModifier in statModifierList)
		{
			RemoveStatModifier(statModifier);
		}
	}

	public bool HasStat(EStats stat)
	{
		if (statsDic != null)
		{
			return statsDic.ContainsKey(stat);
		}
		return false;
	}

	private float CalculateModifierValue(StatModifier statModifier)
	{
		float result = 0f;
		switch (statModifier.operation)
		{
		case ModifierOperation.Additive:
			result = statModifier.value;
			break;
		case ModifierOperation.Multiplicative:
			result = GetStatBase(statModifier.stat) * statModifier.value;
			break;
		}
		return result;
	}

	private void ApplyModifier(StatModifier statModifier)
	{
		float num = CalculateModifierValue(statModifier);
		SetStatCurrent(statModifier.stat, GetStat(statModifier.stat) + num);
	}

	private void RemoveModifier(StatModifier statModifier)
	{
		float num = CalculateModifierValue(statModifier);
		SetStatCurrent(statModifier.stat, GetStat(statModifier.stat) - num);
	}

	private void NotifyStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (oldValue != newValue)
		{
			this.onStatChanged?.Invoke(stat, newValue, oldValue);
		}
	}
}
