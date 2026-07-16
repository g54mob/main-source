using UnityEngine;

[CreateAssetMenu(fileName = "AutocannonTargetPriorityLowHp", menuName = "Upgrade/Autocannon/TargetPriorityLowHp")]
public class UpgradeAutocannonTargetPriorityLowHp : EnhancementUpgrade
{
	private ModuleAutocannon moduleAutocannon;

	public override void ApplyUpgrade()
	{
		ModuleAutocannon moduleByType = Train.Instance.GetModuleByType<ModuleAutocannon>();
		if ((object)moduleByType != null)
		{
			moduleAutocannon = moduleByType;
			moduleAutocannon.findLowestHpTarget = true;
		}
	}
}
