using UnityEngine;

[CreateAssetMenu(fileName = "HackingFillFurnace", menuName = "Upgrade/Hacking/FillFurnace")]
public class UpgradeHackingFillFurnace : EnhancementUpgrade
{
	[SerializeField]
	private float fillPercentAmount;

	public override void ApplyUpgrade()
	{
		CombatManager.Instance.EnemyKilled += OnEnemyKilled;
	}

	private void OnEnemyKilled(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (UnitHelper.HackedEnemyKilledAnEnemy(enemy, killer))
		{
			Train.Instance.CoalSeconds += Train.Instance.CoalSecondsCapacity * fillPercentAmount / 100f;
		}
	}
}
