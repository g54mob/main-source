using System.Collections;
using System.Linq;
using Assets.Nimbatus.Scripts.Workshop;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class FillUploadedDrones : MonoBehaviour, IWorkshopItemList
	{
		public PageControl PageControl;

		public GameObject DroneListLoadingPanel;

		public UIGrid ResultGrid;

		public UIScrollView ResultScrollView;

		public WorkshopItem WorkshopItemPrefab;

		private uint _lastPage;

		[HideInInspector]
		public WorkshopItemResult SelectedItem { get; set; }

		public void Init()
		{
			PageControl.Init();
			TriggerQuery();
			DroneListLoadingPanel.SetActive(false);
		}

		public void Udpate()
		{
			if (_lastPage != PageControl.CurrentPage)
			{
				UpdatePage();
			}
		}

		public void UpdatePage()
		{
			TriggerQuery();
		}

		public void TriggerQuery()
		{
			if (PageControl.CurrentPage == 0)
			{
				PageControl.CurrentPage = 1u;
			}
			ClearItems();
			_lastPage = PageControl.CurrentPage;
			StartCoroutine(UpdateQueryUser(EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderAsc, EUserUGCList.k_EUserUGCList_Published));
		}

		private IEnumerator UpdateQueryUser(EUserUGCListSortOrder sorting, EUserUGCList list, params string[] tags)
		{
			DroneListLoadingPanel.SetActive(true);
			SteamWorkshopQuery query = new SteamWorkshopQuery();
			yield return StartCoroutine(query.StartUser(sorting, list, PageControl.CurrentPage, "", tags.ToList()));
			if (query.HasResult)
			{
				PageControl.ResetFromQuery(query);
				FillUpItems(query);
			}
			DroneListLoadingPanel.SetActive(false);
		}

		public void ClearItems()
		{
			ResultScrollView.ResetPosition();
			(from Transform child in ResultGrid.transform
				select child.gameObject).ToList().ForEach(Object.Destroy);
			ResultGrid.gameObject.SetActive(true);
			ResultGrid.Reposition();
			ResultScrollView.ResetPosition();
			ResultScrollView.UpdateScrollbars(true);
		}

		public void FillUpItems(SteamWorkshopQuery query)
		{
			ResultScrollView.ResetPosition();
			(from Transform child in ResultGrid.transform
				select child.gameObject).ToList().ForEach(Object.Destroy);
			ResultGrid.gameObject.SetActive(true);
			foreach (WorkshopItemResult result in query.Results)
			{
				WorkshopItem workshopItem = Object.Instantiate(WorkshopItemPrefab);
				workshopItem.Init(this, result);
				workshopItem.gameObject.transform.position = ResultGrid.transform.position;
				workshopItem.gameObject.transform.parent = ResultGrid.transform;
				workshopItem.gameObject.transform.localScale = ResultGrid.transform.localScale;
			}
			ResultGrid.Reposition();
			ResultScrollView.ResetPosition();
			ResultScrollView.UpdateScrollbars(true);
		}

		public void SelectItem(WorkshopItemResult item)
		{
			SelectedItem = item;
		}
	}
}
