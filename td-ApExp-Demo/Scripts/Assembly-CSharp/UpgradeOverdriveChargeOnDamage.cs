using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveChargeOnDamage", menuName = "Upgrade/Overdrive/ChargeOnDamage")]
public class UpgradeOverdriveChargeOnDamage : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleOverdrive moduleByType = Train.Instance.GetModuleByType<ModuleOverdrive>();
		if ((object)moduleByType != null)
		{
			moduleByType.chargeFromDamage = true;
		}
	}
}
