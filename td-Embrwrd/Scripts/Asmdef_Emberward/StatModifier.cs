using System;
using UnityEngine;

[Serializable]
public class StatModifier
{
	public eModifierType ModifierType;

	public float Value;

	[HideInInspector]
	public int ID;

	[HideInInspector]
	public bool hasTimeLimit;

	[HideInInspector]
	public float timeLimit;

	public StatModifier(eModifierType type, float value)
	{
	}

	public StatModifier(eModifierType type, float value, int id)
	{
	}

	public void SetTimeLimit(float time)
	{
	}

	public float ApplyModifier(float originalValue)
	{
		return 0f;
	}
}
