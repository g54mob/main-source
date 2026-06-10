using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class PilePanelSelector : UIView
	{
		[SerializeField]
		private TMP_Dropdown groupDropdown;

		[SerializeField]
		private string[] sortingGroups;

		[SerializeField]
		private ResourcePilePanelView[] panelViews;

		private void Start()
		{
			List<string> list = new List<string>();
			string[] array = sortingGroups;
			foreach (string text in array)
			{
				list.Add(base.Localize.GetText("resource_group_" + text));
			}
			groupDropdown.AddOptions(list);
			groupDropdown.onValueChanged.AddListener(OnGroupChange);
		}

		public override void Show()
		{
			base.Show();
			OnGroupChange(groupDropdown.value);
		}

		private void OnGroupChange(int index)
		{
			ResourcePilePanelView[] array = panelViews;
			foreach (ResourcePilePanelView resourcePilePanelView in array)
			{
				if (resourcePilePanelView.AllowedSortingGroups.Contains(sortingGroups[index]))
				{
					resourcePilePanelView.SetGroupAndShow(sortingGroups[index]);
				}
				else
				{
					resourcePilePanelView.Hide();
				}
			}
		}
	}
}
