using UnityEngine;

[CreateAssetMenu(fileName = "HackingRefundCooldown", menuName = "Upgrade/Hacking/RefundCooldown")]
public class UpgradeHackingRefundCooldown : EnhancementUpgrade
{
	[SerializeField]
	private float cdRefundPercentAmount;

	private ModuleHacking moduleHacking;

	public override void ApplyUpgrade()
	{
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleHacking = moduleByType;
		}
		CombatManager.Instance.EnemyKilled += OnEnemyKilled;
	}

	private void OnEnemyKilled(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (UnitHelper.HackedEnemyKilledAnEnemy(enemy, killer))
		{
			moduleHacking.ChargeModuleBy(moduleHacking.GetUpgradedStatValueByStatType(StatTypes.cooldownPrimary) * cdRefundPercentAmount / 100f);
		}
	}
}
