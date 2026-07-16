using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlHullRepairOnKill", menuName = "Upgrade/Module/DamageControl/DamageControlHullRepairOnKill")]
public class UpgradeDamageControlHullRepairOnKill : EnhancementUpgrade
{
	[SerializeField]
	private float hullRepairAmount = 1f;

	private Health trainHealth;

	public override void ApplyUpgrade()
	{
		trainHealth = Train.Instance.HealthComponent;
		CombatManager.Instance.EnemyKilled += OnKill;
	}

	private void OnKill(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (!killer.IsEnemy)
		{
			trainHealth.ChangeHealthWithInfo(new HealthChangeInfo(this, trainHealth, hullRepairAmount, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
		}
	}
}
