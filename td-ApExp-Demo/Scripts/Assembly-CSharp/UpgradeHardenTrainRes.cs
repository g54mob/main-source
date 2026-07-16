using UnityEngine;

[CreateAssetMenu(fileName = "HardenTrainRes", menuName = "Upgrade/Harden/TrainRes")]
public class UpgradeHardenTrainRes : EnhancementUpgrade
{
	[SerializeField]
	private float resHealthPercent = 10f;

	private bool hasOccurred;

	private ModuleHarden harden;

	public override void ApplyUpgrade()
	{
		Train.Instance.HealthComponent.PreDeath += PreTrainDeath;
		harden = Train.Instance.GetModuleByType<ModuleHarden>();
	}

	private void PreTrainDeath(HealthChangeInfo info)
	{
		if (!hasOccurred)
		{
			hasOccurred = true;
			Train.Instance.repairableDamageTaken = 0f;
			UIManager.Instance.TrainHealthBar.repairableBar.SetValue(0f);
			Train.Instance.HealthComponent.SetHealthWithInfo(new HealthChangeInfo(harden, Train.Instance.HealthComponent, resHealthPercent, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
			Train.Instance.MaxHealAllModules();
		}
	}

	public override void ResetUpgrade()
	{
		base.ResetUpgrade();
		hasOccurred = false;
	}
}
