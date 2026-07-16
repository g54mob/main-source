using UnityEngine;

[CreateAssetMenu(fileName = "HardenDmgReductionOnBreak", menuName = "Upgrade/Harden/DmgReductionOnBreak")]
public class UpgradeHardenDmgReductionOnBreak : EnhancementUpgrade
{
	[SerializeField]
	private float damageReductionPercentGain;

	[SerializeField]
	private float boostDuration;

	private ModuleHarden harden;

	public override void ApplyUpgrade()
	{
		harden = Train.Instance.GetModuleByType<ModuleHarden>();
		Module[] modulesByType = Train.Instance.GetModulesByType<Module>();
		if (modulesByType != null)
		{
			for (int i = 0; i < modulesByType.Length; i++)
			{
				modulesByType[i].FullyBroken += OnModuleFullyBroken;
			}
		}
	}

	private void OnModuleFullyBroken()
	{
		if (!harden.isHardenApplied)
		{
			return;
		}
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module && !(module == this))
			{
				module.hardenBoostOn = true;
				module.hardenBoostAmount = damageReductionPercentGain;
				module.hardenBoostDuration = boostDuration;
				module.HealthComponent.DamageReductionPercent += damageReductionPercentGain;
			}
		}
	}
}
