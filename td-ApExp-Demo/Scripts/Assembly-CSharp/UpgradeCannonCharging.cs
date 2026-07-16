using UnityEngine;

[CreateAssetMenu(fileName = "CannonCharging", menuName = "Upgrade/Cannon/Charging")]
public class UpgradeCannonCharging : EnhancementUpgrade
{
	[SerializeField]
	private float damageMultiplyer;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			moduleByType.cannon.isCharging = true;
			moduleByType.cannon.ChargingDamageMultiplyer = damageMultiplyer;
			moduleByType.cannon.OnUpgraded();
		}
	}
}
