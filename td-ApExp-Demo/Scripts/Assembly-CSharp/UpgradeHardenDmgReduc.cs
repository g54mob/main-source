using UnityEngine;

[CreateAssetMenu(fileName = "HardenDmgReduc", menuName = "Upgrade/Harden/DmgReduc")]
public class UpgradeHardenDmgReduc : EnhancementUpgrade
{
	[SerializeField]
	private float damageReductionPercent = 25f;

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			moduleByType.DamageReductionPercent += damageReductionPercent;
		}
	}
}
