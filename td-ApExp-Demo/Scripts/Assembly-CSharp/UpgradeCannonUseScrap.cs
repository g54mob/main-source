using UnityEngine;

[CreateAssetMenu(fileName = "CannonUseScrap", menuName = "Upgrade/Cannon/UseScrap")]
public class UpgradeCannonUseScrap : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			moduleByType.cannon.UseScrapInsteadOfAmmo = true;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
