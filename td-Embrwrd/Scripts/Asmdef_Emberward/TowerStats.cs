using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class TowerStats
{
	public eStatType StatType;

	[FormerlySerializedAs("Value")]
	public float BaseValue;

	public List<StatModifier> list_Modifiers;

	[HideInInspector]
	public int id;

	public float FinalValue => 0f;

	public bool IsModified => false;

	public static TowerStats Create(eStatType statType, eModifierType modifierType, float value)
	{
		return null;
	}

	public TowerStats()
	{
	}

	public TowerStats(TowerStats copyFrom)
	{
	}

	public TowerStats Clone()
	{
		return null;
	}

	public void Tick()
	{
	}

	public void OverrideByMultiplier(float multiplier)
	{
	}

	public virtual string GetFinalValueText_Combined(bool forceInteger = true)
	{
		return null;
	}

	public virtual string GetFinalValueText_Detailed(bool forceInteger = true)
	{
		return null;
	}

	public void AddModifier(StatModifier modifier, bool noDuplicadeFromSameID = false)
	{
	}

	public void RemoveModifier(StatModifier modifier)
	{
	}

	public void RemoveModifier(int id)
	{
	}

	public string GetSingleModifierValueLocString(bool isExtraValue, bool isPercentage = false)
	{
		return null;
	}
}
