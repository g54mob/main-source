using UnityEngine;

[CreateAssetMenu(fileName = "EMPElectromagneticAnnihilation", menuName = "Upgrade/EMP/ElectromagneticAnnihilation")]
public class UpgradeEMPElectromagneticAnnihilation : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		ModuleEMP moduleByType = Train.Instance.GetModuleByType<ModuleEMP>();
		if ((object)moduleByType != null)
		{
			moduleByType.destroyProjectiles = true;
		}
	}
}
