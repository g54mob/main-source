using UnityEngine;

[CreateAssetMenu(fileName = "HardenHealingChance", menuName = "Upgrade/Harden/HealingChance")]
public class UpgradeHardenHealingChance : EnhancementUpgrade
{
	[SerializeField]
	private float healingChance = 10f;

	[SerializeField]
	private float healingAmount = 2f;

	public override void ApplyUpgrade()
	{
		Train.Instance.GetModuleByType<ModuleHarden>()?.SetHealingEffect(healingChance, healingAmount);
	}
}
