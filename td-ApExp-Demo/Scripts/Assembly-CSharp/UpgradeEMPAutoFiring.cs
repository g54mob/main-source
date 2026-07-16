using UnityEngine;

[CreateAssetMenu(fileName = "EMPAutoFiring", menuName = "Upgrade/EMP/AutoFiring")]
public class UpgradeEMPAutoFiring : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		ModuleEMP moduleByType = Train.Instance.GetModuleByType<ModuleEMP>();
		if ((object)moduleByType != null)
		{
			moduleByType.isAutoFiring = true;
		}
	}
}
