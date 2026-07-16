using UnityEngine;

[CreateAssetMenu(fileName = "MissileAmmoRefund", menuName = "Upgrade/Missile/AmmoRefund")]
public class UpgradeMissileAmmoRefund : EnhancementUpgrade
{
	[SerializeField]
	private float ammoRefund;

	[SerializeField]
	private float refundChance;

	public override void ApplyUpgrade()
	{
		ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
		if ((object)moduleByType != null)
		{
			moduleByType.onHitAmmoGain = ammoRefund;
			moduleByType.onHitAmmoGainChance = refundChance;
		}
	}
}
