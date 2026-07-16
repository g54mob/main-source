using UnityEngine;

[CreateAssetMenu(fileName = "ShieldLowest", menuName = "Upgrade/Shield/Lowest")]
public class UpgradeShieldLowest : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleShield moduleByType = Train.Instance.GetModuleByType<ModuleShield>();
		if ((object)moduleByType != null)
		{
			moduleByType.protectLowest = true;
		}
	}
}
