using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveSkip", menuName = "Upgrade/Overdrive/Skip")]
public class UpgradeOverdriveSkip : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleOverdrive moduleByType = Train.Instance.GetModuleByType<ModuleOverdrive>();
		if ((object)moduleByType != null)
		{
			moduleByType.CanSkipLevel = true;
		}
	}
}
