using System;
using System.Collections;
using Assets.Scripts.State;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class CareerSelectorViewModel : ListViewModel
	{
		private CareerSelectorDetails _details;

		public string PrimaryButtonText { get; set; } = "SELECT";

		public string Title { get; set; } = "Career Modes";

		public override IEnumerator LoadItems()
		{
			_details = new CareerSelectorDetails(base.ListView.ListViewDetails);
			foreach (string availableCareerFolder in CareerState.GetAvailableCareerFolders())
			{
				base.ListView.CreateItem(availableCareerFolder, null, availableCareerFolder, null, ListViewScript.SpriteLoadLocation.Resources);
			}
			yield return new WaitForEndOfFrame();
		}

		public override void OnListViewInitialized(ListViewScript listView)
		{
			base.OnListViewInitialized(listView);
			listView.Title = Title;
			listView.CanDelete = false;
			listView.PrimaryButtonText = PrimaryButtonText;
			listView.DisplayType = ListViewScript.ListViewDisplayType.SmallDialog;
		}

		public override void OnPrimaryButtonClicked(ListViewItemScript selectedItem)
		{
			if (_details.IsValidCareer)
			{
				base.ListView.Close();
			}
		}

		public override void UpdateDetails(ListViewItemScript item, Action completeCallback)
		{
			if (item != null)
			{
				string folderName = item.ItemModel as string;
				_details.UpdateDetails(folderName);
			}
			completeCallback?.Invoke();
		}
	}
}
