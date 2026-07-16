using UnityEngine;

[CreateAssetMenu(fileName = "GatlingSpinUpFaster", menuName = "Upgrade/Gatling/SpinUpFaster")]
public class UpgradeGatlingSpinUpFaster : EnhancementUpgrade
{
	[SerializeField]
	private float speedMult = 2f;

	public override void ApplyUpgrade()
	{
		Train.Instance.GetModuleByType<ModuleGatling>();
	}
}
