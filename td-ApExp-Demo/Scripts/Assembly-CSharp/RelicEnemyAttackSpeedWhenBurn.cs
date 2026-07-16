using UnityEngine;

[CreateAssetMenu(fileName = "RelicEnemyAttackSpeedWhenBurn", menuName = "Upgrade/Relic/EnemyAttackSpeedWhenBurn")]
public class RelicEnemyAttackSpeedWhenBurn : EnhancementUpgrade
{
	[SerializeField]
	private float newEnemyAttackSpeedSlowingDownWhenBurnPerStack = 0.3f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.EnemyAttackSpeedSlowingDownWhenBurnPerStack = newEnemyAttackSpeedSlowingDownWhenBurnPerStack;
	}
}
