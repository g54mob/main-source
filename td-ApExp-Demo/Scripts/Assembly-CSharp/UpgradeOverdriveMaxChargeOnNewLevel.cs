using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveMaxChargeOnNewLevel", menuName = "Upgrade/Overdrive/MaxChargeOnNewLevel")]
public class UpgradeOverdriveMaxChargeOnNewLevel : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleOverdrive moduleByType = Train.Instance.GetModuleByType<ModuleOverdrive>();
		if ((object)moduleByType != null)
		{
			moduleByType.maxChargeOnNewLevel = true;
		}
	}
}
