using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScrapinatorGetScrapOnKill", menuName = "Upgrade/Scrapinator/GetScrapOnKill")]
public class UpgradeScrapinatorGetScrapOnKill : EnhancementUpgrade
{
	[SerializeField]
	private int minScrapGain;

	[SerializeField]
	private int maxScrapGain;

	public override void ApplyUpgrade()
	{
		ModuleScrapinator moduleByType = Train.Instance.GetModuleByType<ModuleScrapinator>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnKill = (Delegates.HealthChangeHandler)Delegate.Combine(moduleByType.OnKill, new Delegates.HealthChangeHandler(GetScrapOnKill));
		}
	}

	private void GetScrapOnKill(HealthChangeInfo info)
	{
		int num = UnityEngine.Random.Range(minScrapGain, maxScrapGain - 1);
		ResourceManager.Instance.Scrap.AddValue(num);
	}
}
