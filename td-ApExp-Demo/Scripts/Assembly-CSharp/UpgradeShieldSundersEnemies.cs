using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeShieldMoraleBreaker", menuName = "Upgrade/Shield/ShieldMoraleBreaker")]
public class UpgradeShieldSundersEnemies : EnhancementUpgrade
{
	[SerializeField]
	private float sunderEnemiesChance = 50f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.ShieldSundersEnemyChance = sunderEnemiesChance;
	}
}
