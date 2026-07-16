using UnityEngine;

[CreateAssetMenu(fileName = "ScrapinatorTargetPriority", menuName = "Upgrade/Scrapinator/TargetPriority")]
public class UpgradeScrapinatorTargetPriority : EnhancementUpgrade
{
	public override void ApplyUpgrade()
	{
		ModuleScrapinator moduleByType = Train.Instance.GetModuleByType<ModuleScrapinator>();
		if ((object)moduleByType != null)
		{
			moduleByType.targetPriority = true;
		}
	}
}
