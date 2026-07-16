using UnityEngine;

[CreateAssetMenu(fileName = "FactoryResourceGain", menuName = "Upgrade/Factory/ResourceGain")]
public class UpgradeFactoryResourceGain : EnhancementUpgrade
{
	[SerializeField]
	private float scrapIncrease;

	[SerializeField]
	private float ammoIncrease;

	public override void ApplyUpgrade()
	{
		ModuleFactory moduleByType = Train.Instance.GetModuleByType<ModuleFactory>();
		if ((object)moduleByType != null)
		{
			moduleByType.ScrapGain += scrapIncrease;
			moduleByType.AmmoGain += ammoIncrease;
		}
	}
}
