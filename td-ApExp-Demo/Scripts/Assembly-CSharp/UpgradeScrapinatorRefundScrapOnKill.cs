using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScrapinatorRefundScrapOnKill", menuName = "Upgrade/Scrapinator/RefundScrapOnKill")]
public class UpgradeScrapinatorRefundScrapOnKill : EnhancementUpgrade
{
	[SerializeField]
	private float prob;

	private ModuleScrapinator scrapinatorModule;

	public override void ApplyUpgrade()
	{
		ModuleScrapinator moduleByType = Train.Instance.GetModuleByType<ModuleScrapinator>();
		if ((object)moduleByType != null)
		{
			scrapinatorModule = moduleByType;
			ModuleScrapinator moduleScrapinator = scrapinatorModule;
			moduleScrapinator.OnKill = (Delegates.HealthChangeHandler)Delegate.Combine(moduleScrapinator.OnKill, new Delegates.HealthChangeHandler(ScrapOnKill));
		}
	}

	private void ScrapOnKill(HealthChangeInfo info)
	{
		if (ProbUtils.CheckWithLuck(prob))
		{
			ResourceManager.Instance.Scrap.AddValue(scrapinatorModule.scrapCount);
		}
	}
}
