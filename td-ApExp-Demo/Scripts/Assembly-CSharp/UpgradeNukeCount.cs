using UnityEngine;

[CreateAssetMenu(fileName = "MortarCount", menuName = "Upgrade/Nuke/Count")]
public class UpgradeNukeCount : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleNuke moduleByType = Train.Instance.GetModuleByType<ModuleNuke>();
		if ((object)moduleByType != null)
		{
			moduleByType.NukeCount++;
		}
	}
}
