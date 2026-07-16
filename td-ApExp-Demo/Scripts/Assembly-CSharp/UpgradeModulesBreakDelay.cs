using UnityEngine;

[CreateAssetMenu(fileName = "ModulesBreakDelay", menuName = "Upgrade/Modules/BreakDelay")]
public class UpgradeModulesBreakDelay : EnhancementUpgrade
{
	[SerializeField]
	private float moduleBreakDelayLB = 5f;

	[SerializeField]
	private float moduleBreakDelayUB = 10f;

	public override void ApplyUpgrade()
	{
		GlobalFields.Instance.ModuleBreakDelayLB = moduleBreakDelayLB;
		GlobalFields.Instance.ModuleBreakDelayUB = moduleBreakDelayUB;
	}
}
