using UnityEngine;

[CreateAssetMenu(fileName = "HackingSwitchingSides", menuName = "Upgrade/Hacking/SwitchingSides")]
public class UpgradeHackingSwitchingSides : EnhancementUpgrade
{
	private ModuleHacking moduleHacking;

	[SerializeField]
	private float prob;

	public override void ApplyUpgrade()
	{
		ModuleHacking moduleByType = Train.Instance.GetModuleByType<ModuleHacking>();
		if ((object)moduleByType != null)
		{
			moduleHacking = moduleByType;
			moduleByType.prob = prob;
		}
	}
}
