using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Career.Milestones;
using Assets.Scripts.State;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class MilestonesViewModel : CareerViewModelBase
	{
		public const string MilestoneCompleteClass = "milestone-complete";

		private MilestonesDetails _details;

		public override IEnumerator LoadItems()
		{
			_details = new MilestonesDetails(base.ListView.ListViewDetails);
			GameState gameState = Game.Instance.GameState;
			foreach (Milestone milestone in gameState.Career.Milestones.Milestones)
			{
				if (gameState.Career.Milestones.IsMilestoneActive(milestone, null))
				{
					AddMilestone(milestone);
				}
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = "MILESTONES";
			listView.CanDelete = false;
			listView.PrimaryButtonText = string.Empty;
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
			listView.FooterEnabled = false;
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				Milestone milestone = item.ItemModel as Milestone;
				base.ListView.DetailsTitleText = milestone.Name;
				_details.UpdateDetails(milestone);
			}
			completeCallback?.Invoke();
		}

		private void AddMilestone(Milestone milestone)
		{
			string valueText = milestone.ValueText;
			ListViewItemScript listViewItemScript = base.ListView.CreateItem(milestone.Name, valueText, milestone, null, null, "list-item-milestone");
			List<XmlElement> childElementsWithClass = listViewItemScript.XmlElement.GetChildElementsWithClass("star");
			int currentTierIndex = milestone.CurrentTierIndex;
			bool flag = currentTierIndex >= milestone.Tiers.Count;
			Image elementByInternalId = listViewItemScript.XmlElement.GetElementByInternalId<Image>("milestone-progress-fill");
			if (flag)
			{
				listViewItemScript.XmlElement.GetElementByInternalId("milestone-progress-fill").AddClass("milestone-complete");
				elementByInternalId.fillAmount = 1f;
			}
			else
			{
				elementByInternalId.fillAmount = milestone.TierPercentageComplete;
			}
			for (int i = 0; i < currentTierIndex; i++)
			{
				if (flag)
				{
					childElementsWithClass[i].AddClass("milestone-complete");
				}
				else
				{
					childElementsWithClass[i].AddClass("star-complete");
				}
			}
		}
	}
}
