using UnityEngine;

[CreateAssetMenu(fileName = "FactoryFillCoal", menuName = "Upgrade/Factory/FillCoal")]
public class UpgradeFactoryFillCoal : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		Train.Instance.GetModuleByType<ModuleFactory>().CanFillCoalOncePerLevel = true;
	}
}
