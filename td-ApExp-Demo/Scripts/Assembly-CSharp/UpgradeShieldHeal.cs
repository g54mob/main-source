using UnityEngine;

[CreateAssetMenu(fileName = "ShieldHeal", menuName = "Upgrade/Shield/Heal")]
public class UpgradeShieldHeal : EnhancementUpgrade
{
	[SerializeField]
	private float percentOfDamageHealed;

	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyShieldHeal(HealLowestModule);
	}

	public void HealLowestModule(float amount)
	{
		amount *= percentOfDamageHealed / 100f;
		float num = 999f;
		Module module = null;
		foreach (Module module2 in Train.Instance.Modules)
		{
			if ((bool)module2 && (bool)module2.HealthComponent && module2.HealthComponent.HealthCurrent < num && !module2.IsFullyBroken)
			{
				num = module2.HealthComponent.HealthCurrent;
				module = module2;
			}
		}
		module.HealthComponent.Heal(amount, Train.Instance.GetModuleByType<ModuleShield>());
	}
}
