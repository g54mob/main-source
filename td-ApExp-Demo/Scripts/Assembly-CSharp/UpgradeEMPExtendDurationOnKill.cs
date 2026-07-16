using UnityEngine;

[CreateAssetMenu(fileName = "EMPExtendDurationOnKill", menuName = "Upgrade/EMP/ExtendDurationOnKill")]
public class UpgradeEMPExtendDurationOnKill : EnhancementUpgrade
{
	[SerializeField]
	private float extendDurationAmount;

	public override void ApplyUpgrade()
	{
		CombatManager.Instance.EnemyKilled += ExtendDurationOnKill;
	}

	private void ExtendDurationOnKill(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (killer.IsEnemy || !enemy.IsEMPd)
		{
			return;
		}
		foreach (EnemyBase enemy2 in EnemyManager.Instance.Enemies)
		{
			if (enemy2.empDuration > 0f)
			{
				enemy2.empDuration += extendDurationAmount;
			}
		}
	}
}
