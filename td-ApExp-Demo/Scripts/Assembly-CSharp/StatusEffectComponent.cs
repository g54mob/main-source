using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusEffectComponent : MonoBehaviour
{
	[NonSerialized]
	public List<StatusEffect> statusEffects;

	private void Awake()
	{
		statusEffects = new List<StatusEffect>();
	}

	private void Update()
	{
		for (int i = 0; i < statusEffects.Count; i++)
		{
			statusEffects[i].Update();
		}
	}

	public StatusEffect ApplyStatusEffect(StatusEffect statusEffect, Unit unit)
	{
		StatusEffect statusEffect2 = statusEffects.FirstOrDefault((StatusEffect se) => se.Guid == statusEffect.Guid);
		if (statusEffect2 != null)
		{
			statusEffect2.AddStacks(1);
			return statusEffect2;
		}
		StatusEffect statusEffect3 = UnityEngine.Object.Instantiate(statusEffect);
		statusEffects.Add(statusEffect3);
		statusEffect3.Apply(unit);
		statusEffect3.Expired += OnStatusEffectExpired;
		return statusEffect3;
	}

	public void OnStatusEffectExpired(Unit unit, StatusEffect statusEffect)
	{
		statusEffects.Remove(statusEffect);
	}
}
