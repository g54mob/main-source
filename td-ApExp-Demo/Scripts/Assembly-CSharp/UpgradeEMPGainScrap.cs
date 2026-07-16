using UnityEngine;

[CreateAssetMenu(fileName = "EMPGainScrap", menuName = "Upgrade/EMP/GainScrap")]
public class UpgradeEMPGainScrap : EnhancementUpgrade
{
	[SerializeField]
	private float percentChanceToGainScrap;

	[SerializeField]
	private float amountOfScrapGained;

	public override void ApplyUpgrade()
	{
		CombatManager.Instance.EnemyKilled += TryGainScrap;
	}

	private void TryGainScrap(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (!killer.IsEnemy && enemy.IsEMPd && ProbUtils.CheckWithLuck(percentChanceToGainScrap) && enemy.empDuration > 0f)
		{
			ResourceManager.Instance.Scrap.AddValue(amountOfScrapGained);
		}
	}
}
