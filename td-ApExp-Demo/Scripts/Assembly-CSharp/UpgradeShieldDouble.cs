using UnityEngine;

[CreateAssetMenu(fileName = "ShieldDouble", menuName = "Upgrade/Shield/Double")]
public class UpgradeShieldDouble : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyShieldDouble();
	}
}
