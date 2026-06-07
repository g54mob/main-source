using System.Collections.Generic;
using SteamIntegrations;
using UIScripts.UIReferences;
using UnityEngine;

namespace UIScripts
{
	public class AchievementPanel : UIPanel
	{
		public GameObject achievementItemPrefab;

		public Transform holder;

		private List<AchievementItem> items = new List<AchievementItem>();

		public override void InitPanel()
		{
			base.InitPanel();
			foreach (Achievement achievement in AchievementManager.achievements)
			{
				AchievementItem component = Object.Instantiate(achievementItemPrefab, holder).GetComponent<AchievementItem>();
				component.InitializeItem(achievement);
				items.Add(component);
			}
			achievementItemPrefab.SetActive(value: false);
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			foreach (AchievementItem item in items)
			{
				item.UpdateAchieved();
				if (item.unachievedSecret)
				{
					item.transform.SetAsLastSibling();
				}
			}
		}
	}
}
