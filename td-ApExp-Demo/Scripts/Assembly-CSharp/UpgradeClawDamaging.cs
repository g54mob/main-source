using UnityEngine;

[CreateAssetMenu(fileName = "ClawDamaging", menuName = "Upgrade/Claw/Damaging")]
public class UpgradeClawDamaging : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleClaw moduleByType = Train.Instance.GetModuleByType<ModuleClaw>();
		if ((object)moduleByType != null)
		{
			moduleByType.isShocking = true;
		}
	}
}
