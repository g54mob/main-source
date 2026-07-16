using UnityEngine;

[CreateAssetMenu(fileName = "AutocannonDouble", menuName = "Upgrade/Autocannon/Double")]
public class UpgradeAutocannonDouble : EnhancementUpgradeStats
{
	public override void ApplyUpgrade()
	{
		Train.Instance.GetModuleByType<ModuleAutocannon>()?.SetAutocannonsActive(northActive: true, southActive: true);
	}
}
