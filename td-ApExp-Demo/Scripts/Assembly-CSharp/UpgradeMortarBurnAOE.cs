using UnityEngine;

[CreateAssetMenu(fileName = "MortarBurnAOE", menuName = "Upgrade/Mortar/BurnAOE")]
public class UpgradeMortarBurnAOE : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		ModuleMortar moduleByType = Train.Instance.GetModuleByType<ModuleMortar>();
		if ((object)moduleByType != null)
		{
			moduleByType.dropsBurnAOE = true;
		}
	}
}
