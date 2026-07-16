using UnityEngine;

[CreateAssetMenu(fileName = "CannonLaser", menuName = "Upgrade/Cannon/Laser")]
public class UpgradeCannonLaser : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			moduleByType.cannon.hasLaser = true;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
