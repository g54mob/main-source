using UnityEngine;

[CreateAssetMenu(fileName = "ShieldCooldown", menuName = "Upgrade/Shield/Cooldown")]
public class UpgradeShieldCooldown : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyShieldCooldown(OnModuleCovered, OnModuleUncovered);
	}

	public void OnModuleCovered(Module module)
	{
		StatUtils.ReduceCooldown(module, statusEffectSO);
	}

	public void OnModuleUncovered(Module module)
	{
		StatUtils.RemoveBuff(module, statusEffectSO);
	}
}
