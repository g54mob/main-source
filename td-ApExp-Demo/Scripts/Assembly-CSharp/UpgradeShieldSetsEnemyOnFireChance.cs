using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeShieldSetsEnemyOnFireChance", menuName = "Upgrade/Shield/ShieldSetsEnemyOnFireChance")]
public class UpgradeShieldSetsEnemyOnFireChance : EnhancementUpgrade
{
	[SerializeField]
	private float newShieldSetsEnemyOnFireChance = 0.5f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.ShieldSetsEnemyOnFireChance = newShieldSetsEnemyOnFireChance;
	}
}
