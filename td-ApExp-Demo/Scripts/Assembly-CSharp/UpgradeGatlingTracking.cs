using UnityEngine;

[CreateAssetMenu(fileName = "GatlingTracking", menuName = "Upgrade/Gatling/Tracking")]
public class UpgradeGatlingTracking : EnhancementUpgrade
{
	[SerializeField]
	private float trackingSpeedIncrease = 5f;

	public override void ApplyUpgrade()
	{
		ModuleGatling moduleByType = Train.Instance.GetModuleByType<ModuleGatling>();
		if ((object)moduleByType != null)
		{
			moduleByType.autoTrackingSpeed = trackingSpeedIncrease;
		}
	}
}
