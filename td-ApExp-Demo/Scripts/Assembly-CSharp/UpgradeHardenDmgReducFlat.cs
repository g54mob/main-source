using UnityEngine;

[CreateAssetMenu(fileName = "HardenDmgReducFlat", menuName = "Upgrade/Harden/DmgReducFlat")]
public class UpgradeHardenDmgReducFlat : EnhancementUpgrade
{
	[SerializeField]
	private float damageReductionFlat = 1f;

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			moduleByType.DamageReductionFlat += damageReductionFlat;
		}
	}
}
