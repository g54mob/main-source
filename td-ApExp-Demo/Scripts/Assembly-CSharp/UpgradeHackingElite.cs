using UnityEngine;

[CreateAssetMenu(fileName = "HackingElite", menuName = "Upgrade/Hacking/Elite")]
public class UpgradeHackingElite : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleByType.canHackEliteUnits = true;
		}
	}
}
