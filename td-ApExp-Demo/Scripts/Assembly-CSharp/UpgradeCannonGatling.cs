using UnityEngine;

[CreateAssetMenu(fileName = "CannonGatling", menuName = "Upgrade/Cannon/Gatling")]
public class UpgradeCannonGatling : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			moduleByType.cannon.isGatling = true;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
