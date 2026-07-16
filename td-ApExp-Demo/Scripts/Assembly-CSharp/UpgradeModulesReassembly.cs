using UnityEngine;

[CreateAssetMenu(fileName = "ModulesReassembly", menuName = "Upgrade/DamageControl/Reassembly")]
public class UpgradeModulesReassembly : EnhancementUpgrade
{
	[SerializeField]
	private float moduleRepairTimer = 5f;

	[SerializeField]
	private float moduleHealthAfterRepairPercent = 50f;

	public override void ApplyUpgrade()
	{
		Train.Instance.AutoRepairModules = true;
		Train.Instance.AutoRepairModulesTimer = moduleRepairTimer;
		Train.Instance.AutoRepairModulesHealthPercent = moduleHealthAfterRepairPercent;
	}
}
