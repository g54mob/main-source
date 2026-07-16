using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlHullRepair", menuName = "Upgrade/DamageControl/HullRepair")]
public class UpgradeDamageControlHullRepair : EnhancementUpgradeStats
{
	[SerializeField]
	private float hullRepPerSec = 5f;

	private ModuleDamageControl dc;

	private Health trainHealth;

	public override void ApplyUpgrade()
	{
		trainHealth = Train.Instance.HealthComponent;
		ModuleDamageControl moduleByType = Train.Instance.GetModuleByType<ModuleDamageControl>();
		if ((object)moduleByType != null)
		{
			dc = moduleByType;
		}
	}

	public override void UpdateUpgrade()
	{
		base.UpdateUpgrade();
		if (dc.IsHealing)
		{
			trainHealth.ChangeHealthWithInfo(new HealthChangeInfo(dc, trainHealth, hullRepPerSec * dc.GetUpgradedStatValueByStatType(StatTypes.damage) * Time.deltaTime, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
		}
	}
}
