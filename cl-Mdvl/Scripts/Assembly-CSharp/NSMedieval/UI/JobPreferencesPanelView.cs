using System.Collections.Generic;
using NSEipix;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class JobPreferencesPanelView : UIView
	{
		[SerializeField]
		private LayoutGroupView parent;

		private readonly List<BasicLayoutItemView> itemViews = new List<BasicLayoutItemView>();

		public void UpdateData(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance.GoalPreferences.HasGoalPreferences)
			{
				Show();
				itemViews.SetAllActive(active: false);
				{
					foreach (KeyValuePair<GoalPreferenceLevel, string> item in HumanoidUtils.GetPrefLevelNamesLocalized(humanoidInstance))
					{
						if (item.Key != GoalPreferenceLevel.None && item.Key != GoalPreferenceLevel.Indifferent)
						{
							BasicLayoutItemView next = itemViews.GetNext(parent);
							string path = item.Key.ToString().ToLower();
							next.SetImage(1, path);
							next.SetDataText(item.Value);
							if (next.TooltipNew is GoalPreferenceTooltipView goalPreferenceTooltipView)
							{
								goalPreferenceTooltipView.SetData(humanoidInstance, item.Key);
							}
						}
					}
					return;
				}
			}
			Hide();
		}
	}
}
