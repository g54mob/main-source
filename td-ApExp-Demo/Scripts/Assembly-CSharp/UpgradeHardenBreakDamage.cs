using UnityEngine;

[CreateAssetMenu(fileName = "HardenBreakDamage", menuName = "Upgrade/Harden/BreakDamage")]
public class UpgradeHardenBreakDamage : EnhancementUpgrade
{
	[SerializeField]
	private float damageTakenFromModuleBreak;

	public override void ApplyUpgrade()
	{
		Train.Instance.hullDamageTakenOnModuleBreak = damageTakenFromModuleBreak;
	}
}
