using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Leaderboards;
using Assets.Nimbatus.Scripts.Workshop;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class DroneBrowserManager : MonoBehaviour, IWorkshopItemList
	{
		[HideInInspector]
		public EWorkshopCategory SelectedCategory;

		public UIInput SearchInput;

		public PageControl PageControl;

		public UIGrid CategoryGrid;

		public CategoryButton CategoryPrefab;

		public SortModeSelector SortModeSelector;

		public GameObject DroneListLoadingPanel;

		public UIGrid ResultGrid;

		public UIScrollView ResultScrollView;

		public WorkshopItem WorkshopItemPrefab;

		public DroneWorkshopInformation InformationPanel;

		public DroneUploadPanel DroneUploadPanel;

		private uint _lastPage;

		private string _lastSearch;

		private Callback<DownloadItemResult_t> _itemDownloadedCallback;

		private readonly Stack<IEnumerator> _queryQueue = new Stack<IEnumerator>();

		private bool _itemDownloaded;

		private EWorkshopSortMode _lastSortMode;

		[HideInInspector]
		public WorkshopItemResult SelectedItem { get; set; }

		public void OnEnable()
		{
			_itemDownloadedCallback = Callback<DownloadItemResult_t>.Create(ItemDownloaded);
		}

		public void OnDisable()
		{
			_itemDownloadedCallback.Dispose();
		}

		public void Start()
		{
			PageControl.Init();
			SortModeSelector.Init(this);
			FillUpCategories();
			StartCoroutine(UpdateResultList());
			InformationPanel.Init(this, null);
			TriggerQuery(EWorkshopCategory.All);
			DroneListLoadingPanel.SetActive(false);
			DroneUploadPanel.gameObject.SetActive(false);
		}

		public void UpdateSearchText()
		{
			TriggerQuery(SelectedCategory);
		}

		public void UpdatePage()
		{
			TriggerQuery(SelectedCategory);
		}

		public void SelectItem(WorkshopItemResult item)
		{
			if (SelectedItem != item)
			{
				SelectedItem = item;
				DroneUploadPanel.gameObject.SetActive(false);
				InformationPanel.Init(this, item);
			}
		}

		public void TriggerQuery(EWorkshopCategory category, bool force = false)
		{
			if (SelectedCategory != category)
			{
				PageControl.CurrentPage = 1u;
			}
			if (PageControl.CurrentPage == 0)
			{
				PageControl.CurrentPage = 1u;
			}
			EUGCQuery currentSortMode = (EUGCQuery)SortModeSelector.CurrentSortMode;
			SearchInput.gameObject.SetActive(true);
			SortModeSelector.gameObject.SetActive(true);
			if (force || SelectedCategory != category || _lastSearch != SearchInput.value || PageControl.CurrentPage != _lastPage || _lastSortMode != SortModeSelector.CurrentSortMode)
			{
				ClearItems();
				SelectedCategory = category;
				switch (SelectedCategory)
				{
				case EWorkshopCategory.Uploaded:
					SortModeSelector.gameObject.SetActive(false);
					SearchInput.gameObject.SetActive(false);
					_queryQueue.Push(UpdateQueryUser(EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderAsc, EUserUGCList.k_EUserUGCList_Published));
					break;
				case EWorkshopCategory.All:
					_queryQueue.Push(UpdateQuery(currentSortMode));
					break;
				case EWorkshopCategory.Battle:
					_queryQueue.Push(UpdateQuery(currentSortMode, "Battle"));
					break;
				case EWorkshopCategory.Racing:
					_queryQueue.Push(UpdateQuery(currentSortMode, "Racing"));
					break;
				case EWorkshopCategory.Sumo:
					_queryQueue.Push(UpdateQuery(currentSortMode, "Sumo"));
					break;
				case EWorkshopCategory.Brawl:
					_queryQueue.Push(UpdateQuery(currentSortMode, "Brawl"));
					break;
				case EWorkshopCategory.Subscribed:
					SortModeSelector.gameObject.SetActive(false);
					SearchInput.gameObject.SetActive(false);
					_queryQueue.Push(UpdateQueryUser(EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderAsc, EUserUGCList.k_EUserUGCList_Subscribed));
					break;
				}
			}
			_lastPage = PageControl.CurrentPage;
			_lastSearch = SearchInput.value;
			_lastSortMode = SortModeSelector.CurrentSortMode;
		}

		private IEnumerator UpdateResultList()
		{
			while (true)
			{
				if (_queryQueue.Count > 0)
				{
					IEnumerator routine = _queryQueue.Pop();
					_queryQueue.Clear();
					yield return StartCoroutine(routine);
				}
				yield return true;
			}
		}

		private IEnumerator UpdateQuery(EUGCQuery sorting, params string[] tags)
		{
			DroneListLoadingPanel.SetActive(true);
			SteamWorkshopQuery query = new SteamWorkshopQuery();
			yield return StartCoroutine(query.Start(sorting, PageControl.CurrentPage, SearchInput.value, tags.ToList()));
			if (query.HasResult)
			{
				SelectItem(null);
				PageControl.ResetFromQuery(query);
				FillUpItems(query);
			}
			DroneListLoadingPanel.SetActive(false);
		}

		private IEnumerator UpdateQueryUser(EUserUGCListSortOrder sorting, EUserUGCList list, params string[] tags)
		{
			DroneListLoadingPanel.SetActive(true);
			SteamWorkshopQuery query = new SteamWorkshopQuery();
			yield return StartCoroutine(query.StartUser(sorting, list, PageControl.CurrentPage, SearchInput.value, tags.ToList()));
			if (query.HasResult)
			{
				SelectItem(null);
				PageControl.ResetFromQuery(query);
				FillUpItems(query);
			}
			DroneListLoadingPanel.SetActive(false);
		}

		public void FillUpCategories()
		{
			(from Transform child in CategoryGrid.transform
				select child.gameObject).ToList().ForEach(Object.Destroy);
			CategoryGrid.gameObject.SetActive(true);
			foreach (EWorkshopCategory value in EnumHelper.GetValues<EWorkshopCategory>())
			{
				CategoryButton categoryButton = Object.Instantiate(CategoryPrefab);
				categoryButton.Init(this, value);
				categoryButton.gameObject.transform.position = CategoryGrid.transform.position;
				categoryButton.gameObject.transform.parent = CategoryGrid.transform;
				categoryButton.gameObject.transform.localScale = CategoryGrid.transform.localScale;
			}
			CategoryGrid.Reposition();
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

		public IEnumerator DeleteItem(WorkshopItemResult item)
		{
			SteamCallbackCoroutine<DeleteItemResult_t> deleteCallback = new SteamCallbackCoroutine<DeleteItemResult_t>();
			SteamAPICall_t handle = SteamUGC.DeleteItem(item.FileId);
			yield return StartCoroutine(deleteCallback.Start(handle, 5f));
			if (deleteCallback.HasResult)
			{
				InformationPanel.Init(this, null);
				TriggerQuery(SelectedCategory, true);
			}
		}

		public IEnumerator UnsubscribeItem(WorkshopItemResult item)
		{
			SteamCallbackCoroutine<RemoteStorageUnsubscribePublishedFileResult_t> unsubscribeCallback = new SteamCallbackCoroutine<RemoteStorageUnsubscribePublishedFileResult_t>();
			SteamAPICall_t handle = SteamUGC.UnsubscribeItem(item.FileId);
			yield return StartCoroutine(unsubscribeCallback.Start(handle, 5f));
			if (unsubscribeCallback.HasResult)
			{
				item.IsDownloaded = false;
				if (SelectedCategory == EWorkshopCategory.Subscribed)
				{
					InformationPanel.Init(this, null);
					TriggerQuery(SelectedCategory, true);
				}
			}
		}

		public IEnumerator DownloadItem(WorkshopItemResult item)
		{
			_itemDownloaded = false;
			SteamCallbackCoroutine<RemoteStorageSubscribePublishedFileResult_t> steamCallbackCoroutine = new SteamCallbackCoroutine<RemoteStorageSubscribePublishedFileResult_t>();
			SteamAPICall_t handle = SteamUGC.SubscribeItem(item.FileId);
			yield return StartCoroutine(steamCallbackCoroutine.Start(handle, 10f));
			if (!SteamUGC.DownloadItem(item.FileId, true))
			{
				yield break;
			}
			Stopwatch timeoutWatch = new Stopwatch();
			timeoutWatch.Start();
			while (!_itemDownloaded)
			{
				yield return true;
				if (timeoutWatch.ElapsedMilliseconds > 30000)
				{
					timeoutWatch.Stop();
					yield break;
				}
			}
			bool isDownloaded = false;
			int tryCount = 0;
			while (!isDownloaded && tryCount < 3)
			{
				ulong punSizeOnDisk;
				string pchFolder;
				uint punTimeStamp;
				if (SteamUGC.GetItemInstallInfo(item.FileId, out punSizeOnDisk, out pchFolder, 1024u, out punTimeStamp) && Directory.Exists(pchFolder))
				{
					isDownloaded = true;
				}
				tryCount++;
				yield return new WaitForSeconds(0.1f);
			}
			item.IsDownloaded = true;
		}

		public void Update()
		{
			if (_lastPage != PageControl.CurrentPage)
			{
				UpdatePage();
			}
		}

		private void ItemDownloaded(DownloadItemResult_t param)
		{
			_itemDownloaded = true;
		}

		public void HideDroneUploadPanel(bool refreshSelectedDrone)
		{
			if (refreshSelectedDrone)
			{
				TriggerQuery(SelectedCategory, true);
			}
			DroneUploadPanel.gameObject.SetActive(false);
		}

		public void ShowUploadPanel(WorkshopItemResult item)
		{
			DroneUploadPanel.gameObject.SetActive(true);
			DroneUploadPanel.Init(this, item);
		}
	}
}
