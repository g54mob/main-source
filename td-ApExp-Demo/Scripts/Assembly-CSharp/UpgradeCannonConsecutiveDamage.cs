using UnityEngine;

[CreateAssetMenu(fileName = "CannonConsecutiveDamage", menuName = "Upgrade/Cannon/ConsecutiveDamage")]
public class UpgradeCannonConsecutiveDamage : EnhancementUpgradeStats
{
	[SerializeField]
	private float consecutiveHitsDamageIncrease = 0.1f;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			moduleByType.cannon.consecutiveHitsDamageIncrease = consecutiveHitsDamageIncrease;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
