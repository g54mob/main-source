using UnityEngine;

[CreateAssetMenu(fileName = "HardenRicochet", menuName = "Upgrade/Harden/Ricochet")]
public class UpgradeHardenRicochet : EnhancementUpgrade
{
	[SerializeField]
	private float ricochetChance = 10f;

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			moduleByType.RicochetChance = ricochetChance;
		}
	}
}
