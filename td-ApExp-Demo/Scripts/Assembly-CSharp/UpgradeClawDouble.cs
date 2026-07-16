using UnityEngine;

[CreateAssetMenu(fileName = "ClawDouble", menuName = "Upgrade/Claw/Double")]
public class UpgradeClawDouble : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.GetModuleByType<ModuleClaw>()?.InstantiateC2();
	}
}
