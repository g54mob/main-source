using UnityEngine;

[CreateAssetMenu(fileName = "ProjectilesScreenWrap", menuName = "Upgrade/Projectiles/ScreenWrap")]
public class UpgradeProjectilesScreenWrap : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		base.ApplyUpgrade();
		Train.Instance.projectileScreenWarpCounter++;
	}

	public override void OnRemove()
	{
		base.OnRemove();
		Train.Instance.projectileScreenWarpCounter--;
	}
}
