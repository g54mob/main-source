using System;
using UnityEngine;

public class HealthChangeInfo : EventArgs
{
	public object source { get; private set; }

	public Health Target { get; private set; }

	public float HealthChange { get; set; }

	public bool IsPercent { get; private set; }

	public RaycastHit2D? Hit { get; private set; }

	public bool IsLethal
	{
		get
		{
			if (Target == null)
			{
				return false;
			}
			if (Target.HealthCurrent <= 0f)
			{
				return false;
			}
			return Target.HealthCurrent + HealthChange <= 0f;
		}
	}

	public bool CanRes { get; private set; }

	public bool IgnoreArmor { get; private set; }

	public bool IgnoreImmunity { get; private set; }

	public bool IsBurn { get; private set; }

	public bool IgnoreGrace { get; private set; }

	public bool IsCrit { get; private set; }

	public bool IsDamageReduced { get; set; }

	public bool IsImmune { get; set; }

	public bool RemoveHitEffect { get; set; }

	public bool ShowDamageNumbers { get; set; }

	public DamageType DamageType { get; set; }

	public HealthChangeInfo(object Source, Health targetHealth, float healthChange, bool isPercent = false, RaycastHit2D? hit = null, bool canRes = false, bool ignoreArmor = false, bool ignoreImmunity = false, bool isBurn = false, bool ignoreGrace = false, bool isCrit = false, bool isDamageReduced = false, bool isImmune = false, bool removeHitEffect = false, bool showDamageNumbers = true, DamageType damageType = DamageType.Direct)
	{
		source = Source;
		Target = targetHealth;
		HealthChange = healthChange;
		IsPercent = isPercent;
		Hit = hit;
		CanRes = canRes;
		IgnoreArmor = ignoreArmor;
		IgnoreImmunity = ignoreImmunity;
		IsBurn = isBurn;
		IgnoreGrace = ignoreGrace;
		IsCrit = isCrit;
		IsDamageReduced = isDamageReduced;
		IsImmune = isImmune;
		RemoveHitEffect = removeHitEffect;
		ShowDamageNumbers = showDamageNumbers;
		DamageType = damageType;
	}

	public override string ToString()
	{
		return "HealthChangeInfo: " + $"\nSource: {source}" + $"\nTarget: {Target}" + $"\nHealthChange: {HealthChange}" + $"\nIsPercent: {IsPercent}" + "\nHit: " + (Hit?.ToString() ?? "null") + $"\nCanRes: {CanRes}";
	}
}
