using UnityEngine;

[CreateAssetMenu(fileName = "AutocannonTargetPriorityHighHp", menuName = "Upgrade/Autocannon/TargetPriorityHighHp")]
public class UpgradeAutocannonTargetPriority : EnhancementUpgrade
{
	private ModuleAutocannon moduleAutocannon;

	public override void ApplyUpgrade()
	{
		ModuleAutocannon moduleByType = Train.Instance.GetModuleByType<ModuleAutocannon>();
		if ((object)moduleByType != null)
		{
			moduleAutocannon = moduleByType;
			moduleAutocannon.findHighestHpTarget = true;
		}
	}
}
