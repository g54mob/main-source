using UnityEngine;

[CreateAssetMenu(fileName = "EMPDangerClose", menuName = "Upgrade/EMP/DangerClose")]
public class UpgradeEMPDangerClose : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleEMP moduleByType = Train.Instance.GetModuleByType<ModuleEMP>();
		if ((object)moduleByType != null)
		{
			moduleByType.destroyBombers = true;
		}
	}
}
