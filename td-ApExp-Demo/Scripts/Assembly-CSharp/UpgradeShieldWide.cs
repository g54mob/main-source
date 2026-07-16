using UnityEngine;

[CreateAssetMenu(fileName = "ShieldWide", menuName = "Upgrade/Shield/ShieldWide")]
public class UpgradeShieldWide : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.ApplyShieldWide();
	}
}
