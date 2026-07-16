using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MortarStackingDamage", menuName = "Upgrade/Mortar/StackingDamage")]
public class UpgradeMortarStackingDamage : EnhancementUpgrade
{
	private ModuleMortar mortar;

	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	public override void ApplyUpgrade()
	{
		mortar = Train.Instance.GetModuleByType<ModuleMortar>();
		ModuleMortar moduleMortar = mortar;
		moduleMortar.OnExplosionKill = (Delegates.HealthChangeHandler)Delegate.Combine(moduleMortar.OnExplosionKill, new Delegates.HealthChangeHandler(AddDamage));
		LevelManager.Instance.LevelStarted += RemoveDamage;
	}

	public void AddDamage(HealthChangeInfo info)
	{
		appliedStatusEffect = mortar.StatsSO.ApplyStatusEffect(statusEffectSO);
	}

	public void RemoveDamage()
	{
		mortar.StatsSO.RemoveStatusEffect(statusEffectSO);
	}
}
