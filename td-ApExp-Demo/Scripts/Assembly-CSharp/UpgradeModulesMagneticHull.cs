using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlMagneticHull", menuName = "Upgrade/DamageControl/MagneticHull")]
public class UpgradeModulesMagneticHull : EnhancementUpgrade
{
	[SerializeField]
	private float repairPercent = 5f;

	public override void ApplyUpgrade()
	{
		Train.Instance.TurnOnMagneticHull(repairPercent);
	}
}
