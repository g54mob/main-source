#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Steamworks;
using TH20.Analytics;
using UnityEngine;

namespace TH20.ExtContent
{
	public class ExtContentSourceWorkshop : ExtContentSourceBase
	{
		public class WorkshopConfig
		{
			public bool bTest = true;

			public Texture2D _bundleIndicatorTexture2D;

			public Vector2 _bundleIndicatorNormPosition;
		}

		public delegate void OnWorkshopInstalledItemCreatedCallback(WorkshopInstalledItem workshopInstalledItem);

		public delegate void OnWorkshopInstalledItemUpdatedCallback(WorkshopInstalledItem workshopInstalledItem);

		public delegate void OnPreInstalledItemsProcessedCallback();

		private const float cUpdatesRequiredPendingTime = 2f;

		private const float cCheckDownloadQueryPendingTime = 5f;

		private const float cCheckUpdateInstalledItemsPendingTime = 5f;

		private const string cPersistentPublishedFileIdsFileName = "SubIDs.txt";

		private const string cLastSubscribedToPublishedFileIdsFileName = "SubIDsLast.txt";

		private WorkshopConfig _config;

		private ExtContentManager _extContentManager;

		private MonoBehaviour _behaviourToRunCoroutinesOn;

		private Coroutine _queryItemsCoroutine;

		private Coroutine _downloadItemsCoroutine;

		private List<WorkshopInstalledItem> _installedItems;

		private List<GameItemBase> _cachedInstalledGameItems;

		private bool _currentlyPerformingQuery;

		private bool _checkDownloadQueryPendingAllSubscribedToItems;

		private bool _updateInstalledItemsPending;

		private List<PublishedFileId_t> _publishedFileIdsRequiringUpdate;

		private List<string> _persistentSubscribedToItemIds;

		private bool _bProcessPersistentSubscribedToItemIdsWritePending;

		private List<string> _lastSubscribedToPulishedFileIdsList;

		private string _lastWorkshopInstalledContentFolderSpec;

		private float _updatesRequiredPendingTimer;

		private float _checkDownloadQueryPendingTimer;

		private float _updateInstalledItemsPendingTimer;

		private PublishedFileId_t _checkDownloadQueryPendingPublishedFileId;

		private Callback<ItemInstalled_t> _itemInstalledCallback;

		private Callback<DownloadItemResult_t> _itemDownloadedCallback;

		public List<WorkshopInstalledItem> InstalledItems => _installedItems;

		public WorkshopConfig Config => _config;

		public event OnWorkshopInstalledItemCreatedCallback OnWorkshopInstalledItemCreated;

		public event OnWorkshopInstalledItemUpdatedCallback OnWorkshopInstalledItemUpdated;

		public event OnPreInstalledItemsProcessedCallback OnPreInstalledItemsProcessed;

		public ExtContentSourceWorkshop(WorkshopConfig config)
		{
			_config = config;
		}

		public void Init(ExtContentManager extContentManager)
		{
			_extContentManager = extContentManager;
			_behaviourToRunCoroutinesOn = _extContentManager.BehaviourToRunCoroutinesOn;
			_publishedFileIdsRequiringUpdate = new List<PublishedFileId_t>();
			_persistentSubscribedToItemIds = new List<string>();
			_lastSubscribedToPulishedFileIdsList = new List<string>();
			_itemInstalledCallback = Callback<ItemInstalled_t>.Create(OnWorkshopItemInstalled);
			_itemDownloadedCallback = Callback<DownloadItemResult_t>.Create(OnWorkshopItemDownloaded);
			ExtContentMessages.LogDebug(string.Format("ContentSourceWorkshop: Steam Initialised: {0}, User Logged On: {1}", OnlineManager.IsInitialized() ? "Y" : "N", OnlineManager.IsInitializedAndLoggedOn() ? "Y" : "N"));
			ReadPersistentSubscribedToItemIds();
			InitInstalledItems();
			SetUpdateInstalledItemsPending(bSet: true, 0.1f);
		}

		public void DeInit()
		{
			_itemInstalledCallback.Unregister();
			_itemInstalledCallback = null;
			_itemDownloadedCallback.Unregister();
			_itemDownloadedCallback = null;
			StopCoroutines();
			DeInitInstalledItems();
			_publishedFileIdsRequiringUpdate = null;
		}

		public override List<GameItemBase> GetAllGameItems(EContentType contentType = EContentType.None)
		{
			List<GameItemBase> list = new List<GameItemBase>();
			if (ExtContentType.IsValid(contentType))
			{
				foreach (WorkshopInstalledItem installedItem in _installedItems)
				{
					foreach (GameItemBase gameItem in installedItem.GameItems)
					{
						if (gameItem.ContentType == contentType)
						{
							list.Add(gameItem);
						}
					}
				}
			}
			else
			{
				foreach (WorkshopInstalledItem installedItem2 in _installedItems)
				{
					list.AddRange(installedItem2.GameItems);
				}
			}
			return list;
		}

		public override List<GameItemBase> GetAllGameItemsRef()
		{
			_cachedInstalledGameItems = GetAllGameItems();
			return _cachedInstalledGameItems;
		}

		public override string GetContentSourceIdentifier()
		{
			return "Workshop";
		}

		public override string GetCommonPathSearchFolder()
		{
			return WorkshopUtils.GetAppIdStr();
		}

		public override bool IsCurrentlyUsingOnlineServices()
		{
			if (!base.IsCurrentlyUsingOnlineServices() && !_currentlyPerformingQuery && _queryItemsCoroutine == null)
			{
				return _downloadItemsCoroutine != null;
			}
			return true;
		}

		private void StopCoroutines()
		{
			StopQueryItemsCoroutine();
			StopDownloadItemsCoroutine();
		}

		private void StopQueryItemsCoroutine()
		{
			if (_queryItemsCoroutine != null)
			{
				_behaviourToRunCoroutinesOn.StopCoroutine(_queryItemsCoroutine);
				_queryItemsCoroutine = null;
			}
		}

		private void StopDownloadItemsCoroutine()
		{
			if (_downloadItemsCoroutine != null)
			{
				_behaviourToRunCoroutinesOn.StopCoroutine(_downloadItemsCoroutine);
				_downloadItemsCoroutine = null;
			}
		}

		public WorkshopInstalledItem FindWorkshopInstalledItemForGameItem(GameItemBase gameItem)
		{
			WorkshopInstalledItem result = null;
			foreach (WorkshopInstalledItem installedItem in _installedItems)
			{
				if (installedItem.GameItems.Contains(gameItem))
				{
					result = installedItem;
					break;
				}
			}
			return result;
		}

		public PublishedFileId_t FindPublishedFileIdForGameItem(GameItemBase gameItem)
		{
			PublishedFileId_t result = WorkshopUtils.cNullPublishedFileId;
			WorkshopInstalledItem workshopInstalledItem = FindWorkshopInstalledItemForGameItem(gameItem);
			if (workshopInstalledItem != null)
			{
				result = workshopInstalledItem.PublishedFileId;
			}
			return result;
		}

		public void GetSteamOverlayWorkshopItemURLsForGameItem(GameItemBase gameItem, ref string steamURL, ref string browserURL)
		{
			steamURL = string.Empty;
			browserURL = string.Empty;
			string publishedFileId = string.Empty;
			WorkshopInstalledItem workshopInstalledItem = FindWorkshopInstalledItemForGameItem(gameItem);
			if (workshopInstalledItem != null)
			{
				publishedFileId = workshopInstalledItem.PublishedFileId.ToString();
			}
			GetSteamOverlayWorkshopItemURLsForPublishedFileId(publishedFileId, ref steamURL, ref browserURL);
		}

		public static void GetSteamOverlayWorkshopItemURLsForPublishedFileId(string publishedFileId, ref string steamURL, ref string browserURL)
		{
			WorkshopContentCreationManager.WorkshopContentCreationConfig instance = ExtContentUtils.ExtContentManager.Config.WorkshopContentCreationManagerConfig.Instance;
			steamURL = string.Empty;
			browserURL = string.Empty;
			if (!publishedFileId.IsNullOrEmpty() && publishedFileId != "0")
			{
				steamURL = instance.steamOverlayWorkshopPublishBaseURL + publishedFileId;
				browserURL = instance.steamOverlayWorkshopPublishBaseURLBrowser + publishedFileId;
			}
			else
			{
				GetSteamOverlayWorkshopURLs(ref steamURL, ref browserURL);
			}
		}

		public static void GetSteamOverlayWorkshopURLs(ref string steamURL, ref string browserURL)
		{
			WorkshopContentCreationManager.WorkshopContentCreationConfig instance = ExtContentUtils.ExtContentManager.Config.WorkshopContentCreationManagerConfig.Instance;
			steamURL = instance.steamOverlayWorkshopPageURL;
			browserURL = instance.steamOverlayWorkshopPageURLBrowser;
		}

		public void Update()
		{
			ProcessUpdateInstalledItemsPending();
			ProcessPublishedFileIdsRequiringUpdate();
			ProcessCheckDownloadQueryPending();
			ProcessPersistentSubscribedToItemIdsWritePending();
		}

		private void OnWorkshopItemInstalled(ItemInstalled_t itemInstalledCallback)
		{
			if (itemInstalledCallback.m_unAppID.m_AppId == WorkshopUtils.GetAppId())
			{
				OnItemInstalled(itemInstalledCallback.m_nPublishedFileId);
			}
		}

		private void OnWorkshopItemDownloaded(DownloadItemResult_t itemDownloadedCallback)
		{
			if (itemDownloadedCallback.m_unAppID.m_AppId == WorkshopUtils.GetAppId())
			{
				WorkshopUtils.SetLastSteamResult(itemDownloadedCallback.m_eResult);
				if (itemDownloadedCallback.m_eResult == EResult.k_EResultOK)
				{
					OnItemDownloaded(itemDownloadedCallback.m_nPublishedFileId);
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorDownloadingWorkshopItem), itemDownloadedCallback.m_nPublishedFileId.ToString()));
				}
			}
		}

		private void OnItemInstalled(PublishedFileId_t publishedFileId)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Received item installed callback for item id {0}"), publishedFileId.ToString()));
			_updatesRequiredPendingTimer = 2f;
			_publishedFileIdsRequiringUpdate.AddUnique(publishedFileId);
		}

		private void OnItemDownloaded(PublishedFileId_t publishedFileId)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Successfully downloaded workshop item '{0}'"), publishedFileId.ToString()));
			_updatesRequiredPendingTimer = 2f;
			_publishedFileIdsRequiringUpdate.AddUnique(publishedFileId);
		}

		private void InitInstalledItems()
		{
			if (_installedItems == null)
			{
				_installedItems = new List<WorkshopInstalledItem>();
			}
		}

		private void DeInitInstalledItems()
		{
			if (_installedItems != null)
			{
				int i = 0;
				for (int count = _installedItems.Count; i < count; i++)
				{
					_installedItems[i].DeInit();
				}
				_installedItems.Clear();
				_installedItems = null;
			}
		}

		public void RefreshWorkshopInstalledItems()
		{
			SetUpdateInstalledItemsPending();
		}

		private void SetUpdateInstalledItemsPending(bool bSet = true, float delayTime = 0f)
		{
			_updateInstalledItemsPending = bSet;
			_updateInstalledItemsPendingTimer = delayTime;
			if (_updateInstalledItemsPendingTimer <= 0f)
			{
				ProcessUpdateInstalledItemsPending();
			}
		}

		private void ProcessUpdateInstalledItemsPending()
		{
			if (!_updateInstalledItemsPending)
			{
				return;
			}
			_updateInstalledItemsPendingTimer -= Time.unscaledDeltaTime;
			if (_updateInstalledItemsPendingTimer <= 0f)
			{
				if (UpdateInstalledItems())
				{
					_updateInstalledItemsPending = false;
				}
				else
				{
					_updateInstalledItemsPendingTimer = 5f;
				}
			}
		}

		private bool UpdateInstalledItems()
		{
			bool result = false;
			bool flag = true;
			if (WorkshopUtils.AreSteamWorkshopFeaturesAvailable())
			{
				flag = false;
				result = UpdateInstalledItemsOnline();
			}
			if (flag)
			{
				result = UpdateInstalledItemsOffline();
			}
			return result;
		}

		private bool UpdateInstalledItemsOnline()
		{
			bool result = false;
			if (_queryItemsCoroutine == null && !_currentlyPerformingQuery)
			{
				_queryItemsCoroutine = _behaviourToRunCoroutinesOn.StartCoroutine(InstalledItemsQueryCoroutine());
				result = true;
			}
			return result;
		}

		private IEnumerator InstalledItemsQueryCoroutine()
		{
			_currentlyPerformingQuery = true;
			WorkshopUtils.ResetLastSteamResult();
			DeInitInstalledItems();
			InitInstalledItems();
			uint numSubscribedToItems = 0u;
			List<WorkshopItemDetail> itemDetails = null;
			if (WorkshopUtils.GetSubscribedToItemsPublishedFileIds(out numSubscribedToItems, out var retPublishedFileIDs) && numSubscribedToItems != 0)
			{
				WaitForCallResult<SteamUGCQueryCompleted_t> queryResult = WorkshopUtils.StartPublishedItemsQuery(numSubscribedToItems, retPublishedFileIDs);
				yield return queryResult.WaitForResult();
				if (WorkshopUtils.ValidateItemsQueryResult(queryResult.Result, numSubscribedToItems) && WorkshopUtils.CreateItemDetailsFromQueryResult(queryResult.Result, ref itemDetails))
				{
					foreach (WorkshopItemDetail item in itemDetails)
					{
						if (item.IsFullyInstalled())
						{
							WorkshopInstalledItem workshopInstalledItem = new WorkshopInstalledItem();
							workshopInstalledItem.Init(item);
							AddInstalledItem(workshopInstalledItem);
						}
					}
				}
				OnInstalledItemsDetailsChanged();
			}
			CheckWriteLastSubscribedToPulishedFileIdsList();
			LogInstalledItems();
			LogGameItems();
			WorkshopUtils.OnFinishedItemsQuery(_installedItems.Count);
			if (this.OnPreInstalledItemsProcessed != null)
			{
				this.OnPreInstalledItemsProcessed();
			}
			StartDownloadingDetailItemsNeedingUpdate(itemDetails);
			_queryItemsCoroutine = null;
			_currentlyPerformingQuery = false;
			WorkshopUtils.ResetLastSteamResult();
		}

		private IEnumerator UpdatedItemsQueryCoroutine()
		{
			_currentlyPerformingQuery = true;
			WorkshopUtils.ResetLastSteamResult();
			List<PublishedFileId_t> list = new List<PublishedFileId_t>(_publishedFileIdsRequiringUpdate);
			_publishedFileIdsRequiringUpdate.Clear();
			int numNewItemsAdded = 0;
			int numExistingItemsUpdated = 0;
			bool bInstalledItemsDetailsChanged = false;
			uint numUpdateItems = (uint)list.Count;
			if (numUpdateItems != 0)
			{
				PublishedFileId_t[] publishedFileIDs = WorkshopUtils.PublishedFileIdsArrayFromList(list);
				WaitForCallResult<SteamUGCQueryCompleted_t> queryResult = WorkshopUtils.StartPublishedItemsQuery(numUpdateItems, publishedFileIDs);
				yield return queryResult.WaitForResult();
				if (WorkshopUtils.ValidateItemsQueryResult(queryResult.Result, numUpdateItems))
				{
					List<WorkshopItemDetail> workshopItemsDetails = null;
					if (WorkshopUtils.CreateItemDetailsFromQueryResult(queryResult.Result, ref workshopItemsDetails))
					{
						foreach (WorkshopItemDetail itemDetail in workshopItemsDetails)
						{
							WorkshopInstalledItem workshopInstalledItem = _installedItems.Find((WorkshopInstalledItem item) => item.PublishedFileId.m_PublishedFileId == itemDetail.PublishedFileId.m_PublishedFileId);
							if (itemDetail.InstalledInfoValid)
							{
								if (workshopInstalledItem != null)
								{
									numExistingItemsUpdated++;
									bInstalledItemsDetailsChanged = true;
									workshopInstalledItem.UpdateItemDetail(itemDetail);
									InvokeOnWorkshopInstalledItemUpdated(workshopInstalledItem);
								}
								else
								{
									numNewItemsAdded++;
									bInstalledItemsDetailsChanged = true;
									workshopInstalledItem = new WorkshopInstalledItem();
									workshopInstalledItem.Init(itemDetail);
									AddInstalledItem(workshopInstalledItem);
									InvokeOnWorkshopInstalledItemCreated(workshopInstalledItem);
								}
							}
						}
					}
				}
				if (bInstalledItemsDetailsChanged)
				{
					OnInstalledItemsDetailsChanged();
					CheckWriteLastSubscribedToPulishedFileIdsList();
				}
				if (numNewItemsAdded > 0 || numExistingItemsUpdated > 0)
				{
					ExtContentUIUtils.CloseAllGameMenusOnGameItemsUpdate();
					ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.WorkshopItemsUpdateReceivedNotificationTitle), string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopItemsUpdateReceivedNotificationBody), numNewItemsAdded + numExistingItemsUpdated));
				}
			}
			LogInstalledItems();
			LogGameItems();
			_queryItemsCoroutine = null;
			_currentlyPerformingQuery = false;
			WorkshopUtils.ResetLastSteamResult();
			WorkshopUtils.OnFinishedItemsQuery((int)numUpdateItems);
		}

		private void InvokeOnWorkshopInstalledItemCreated(WorkshopInstalledItem installedItem)
		{
			if (installedItem == null)
			{
				return;
			}
			if (this.OnWorkshopInstalledItemCreated != null)
			{
				this.OnWorkshopInstalledItemCreated(installedItem);
			}
			foreach (GameItemBase gameItem in installedItem.GameItems)
			{
				InvokeOnGameItemCreated(gameItem);
			}
		}

		private void InvokeOnWorkshopInstalledItemUpdated(WorkshopInstalledItem installedItem)
		{
			if (installedItem == null)
			{
				return;
			}
			if (this.OnWorkshopInstalledItemUpdated != null)
			{
				this.OnWorkshopInstalledItemUpdated(installedItem);
			}
			foreach (GameItemBase gameItem in installedItem.GameItems)
			{
				InvokeOnGameItemUpdated(gameItem);
			}
		}

		private void AddInstalledItem(WorkshopInstalledItem installedItem)
		{
			_installedItems.Add(installedItem);
			string text = installedItem.PublishedFileId.ToString();
			if (IsPublishedFileIDNewlySubscribedTo(text))
			{
				SendAnalyticsEventWorkshopItemSubscribedTo(installedItem);
				_persistentSubscribedToItemIds.AddUnique(text);
				_bProcessPersistentSubscribedToItemIdsWritePending = true;
			}
		}

		private void ReadPublishedFileIdsListFromDisk(string fileSpec, ref List<string> _publishedFileIdsList, bool bDeleteFileUponReadFail = false)
		{
			_publishedFileIdsList.Clear();
			if (File.Exists(fileSpec))
			{
				try
				{
					string[] array = File.ReadAllLines(fileSpec);
					foreach (string item in array)
					{
						_publishedFileIdsList.Add(item);
					}
				}
				catch (Exception ex)
				{
					Logging.Error(LogChannels.ExternalContent, $"Exception error {ex.ToString()}' reading published file ids from file '{fileSpec}'");
					if (bDeleteFileUponReadFail)
					{
						ExtContentUtils.DeleteFile(fileSpec);
					}
				}
			}
			Logging.Info(LogChannels.ExternalContent, $"Read {_publishedFileIdsList.Count} published file ids from file '{fileSpec}'");
		}

		private void WritePublishedFileIdsListToDisk(string fileSpec, List<string> _publishedFileIdsList)
		{
			Logging.Info(LogChannels.ExternalContent, $"Writing {_publishedFileIdsList.Count} published file ids to file '{fileSpec}'");
			try
			{
				File.WriteAllLines(fileSpec, _publishedFileIdsList);
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.ExternalContent, $"Exception error {ex.ToString()}' writing {_publishedFileIdsList.Count} published file ids to file '{fileSpec}'");
			}
		}

		private void ReadPersistentSubscribedToItemIds()
		{
			ReadPublishedFileIdsListFromDisk(ExtContentUtils.GetPathSpec(Application.persistentDataPath, "SubIDs.txt"), ref _persistentSubscribedToItemIds, bDeleteFileUponReadFail: true);
		}

		private void WritePersistentSubscribedToItemIds()
		{
			WritePublishedFileIdsListToDisk(ExtContentUtils.GetPathSpec(Application.persistentDataPath, "SubIDs.txt"), _persistentSubscribedToItemIds);
		}

		private void ProcessPersistentSubscribedToItemIdsWritePending()
		{
			if (_bProcessPersistentSubscribedToItemIdsWritePending)
			{
				WritePersistentSubscribedToItemIds();
				_bProcessPersistentSubscribedToItemIdsWritePending = false;
			}
		}

		private bool IsPublishedFileIDNewlySubscribedTo(string publishedFiledIdStr)
		{
			return _persistentSubscribedToItemIds.FindIndex((string item) => item == publishedFiledIdStr) < 0;
		}

		private void SendAnalyticsEventWorkshopItemSubscribedTo(WorkshopInstalledItem installedItem)
		{
			if (_extContentManager.AnalyticsManager != null && installedItem != null && installedItem.ItemDetail != null && installedItem.ItemDetail.CheckReadInstalledItemMetaDataFile())
			{
				WorkshopItemMetaData workshopMetaData = installedItem.ItemDetail.WorkshopMetaData;
				Logging.Info(LogChannels.Analytics, $"Sending UGC analytics: Newly subscribed to workshop item: PublishedFileId: '{workshopMetaData.PublishedFileId}'");
				string value = string.Empty;
				GameItemPictureBase.GameItemPictureBaseConfig pictureBaseConfigForContentTypeAndTag = ExtContentUtils.GetPictureBaseConfigForContentTypeAndTag(workshopMetaData.FirstItemContentType, workshopMetaData.FirstItemContentSubType);
				if (pictureBaseConfigForContentTypeAndTag != null)
				{
					value = pictureBaseConfigForContentTypeAndTag._itemAnalyticsName;
				}
				GameEvent gameEvent = new GameEvent(_extContentManager.AnalyticsManager.Config.UGCWorkshopItemSubscribedToInfo).AddParam("publishedfileid", workshopMetaData.PublishedFileId).AddParam("contenttype", workshopMetaData.ContentType).AddParam("numgameitems", workshopMetaData.NumGameItems)
					.AddParam("firstitemcontenttype", workshopMetaData.FirstItemContentType)
					.AddParam("firstitemsubtype", value);
				_extContentManager.AnalyticsManager.RecordEvent(gameEvent);
			}
		}

		private void OnInstalledItemsDetailsChanged()
		{
			SortInstalledItemsList();
		}

		private void SortInstalledItemsList()
		{
			_installedItems.Sort(delegate(WorkshopInstalledItem item1, WorkshopInstalledItem item2)
			{
				long lastFolderUpdateTime = item1.ItemDetail.LastFolderUpdateTime;
				long lastFolderUpdateTime2 = item2.ItemDetail.LastFolderUpdateTime;
				if (lastFolderUpdateTime < lastFolderUpdateTime2)
				{
					return 1;
				}
				return (lastFolderUpdateTime > lastFolderUpdateTime2) ? (-1) : 0;
			});
		}

		public bool CheckDownloadItemsNeedingUpdate(bool bQueryAllSubscribedToItems, PublishedFileId_t publishedFileId)
		{
			bool result = false;
			if (_downloadItemsCoroutine == null)
			{
				result = true;
				_downloadItemsCoroutine = _behaviourToRunCoroutinesOn.StartCoroutine(DownloadItemsQueryCoroutine(bQueryAllSubscribedToItems, publishedFileId));
			}
			else
			{
				ExtContentMessages.LogError(ExtContentMessages.GetMessageString(EMessageType.ItemsDownloadCheckAlreadyInProgress));
			}
			return result;
		}

		private IEnumerator DownloadItemsQueryCoroutine(bool bQueryAllSubscribedToItems, PublishedFileId_t publishedFileId)
		{
			_currentlyPerformingQuery = true;
			WorkshopUtils.ResetLastSteamResult();
			uint numSubscribedToItems = 0u;
			List<WorkshopItemDetail> itemDetails = null;
			bool flag = false;
			PublishedFileId_t[] retPublishedFileIDs;
			if (bQueryAllSubscribedToItems)
			{
				flag = WorkshopUtils.GetSubscribedToItemsPublishedFileIds(out numSubscribedToItems, out retPublishedFileIDs);
			}
			else
			{
				retPublishedFileIDs = new PublishedFileId_t[1] { publishedFileId };
				numSubscribedToItems = 1u;
			}
			if (flag && numSubscribedToItems != 0)
			{
				WaitForCallResult<SteamUGCQueryCompleted_t> queryResult = WorkshopUtils.StartPublishedItemsQuery(numSubscribedToItems, retPublishedFileIDs);
				yield return queryResult.WaitForResult();
				if (WorkshopUtils.ValidateItemsQueryResult(queryResult.Result, numSubscribedToItems))
				{
					WorkshopUtils.CreateItemDetailsFromQueryResult(queryResult.Result, ref itemDetails);
				}
			}
			WorkshopUtils.OnFinishedItemsQuery((int)numSubscribedToItems);
			StartDownloadingDetailItemsNeedingUpdate(itemDetails);
			_downloadItemsCoroutine = null;
			_currentlyPerformingQuery = false;
			WorkshopUtils.ResetLastSteamResult();
		}

		public void StartDownloadingDetailItemsNeedingUpdate(List<WorkshopItemDetail> itemDetails)
		{
			int num = 0;
			if (itemDetails != null)
			{
				int num2 = 0;
				foreach (WorkshopItemDetail itemDetail in itemDetails)
				{
					bool flag = false;
					if (itemDetail.DoesItemNeedUpdating() && WorkshopUtils.StartItemDownloading(itemDetail))
					{
						flag = true;
						num++;
					}
					if (!flag)
					{
						WorkshopInstalledItem workshopInstalledItem = _installedItems.Find((WorkshopInstalledItem item) => item.PublishedFileId.m_PublishedFileId == itemDetail.PublishedFileId.m_PublishedFileId);
						if (workshopInstalledItem != null && workshopInstalledItem.ItemDetail.DoesExternallyModifiableDataDiffer(itemDetail))
						{
							num2++;
							workshopInstalledItem.UpdateItemDetail(itemDetail);
							InvokeOnWorkshopInstalledItemUpdated(workshopInstalledItem);
						}
					}
				}
				if (num2 > 0)
				{
					ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.WorkshopItemsExternalDataModifiedNotificationTitle), string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopItemsExternalDataModifiedNotificationBody), num2));
				}
			}
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Started downloading {0} items found needing updating ..."), num));
		}

		private void ProcessPublishedFileIdsRequiringUpdate()
		{
			if (!(_updatesRequiredPendingTimer > 0f))
			{
				return;
			}
			_updatesRequiredPendingTimer -= Time.unscaledDeltaTime;
			if (!(_updatesRequiredPendingTimer <= 0f))
			{
				return;
			}
			if (!_currentlyPerformingQuery)
			{
				_updatesRequiredPendingTimer = 0f;
				if (_publishedFileIdsRequiringUpdate.Count > 0 && _queryItemsCoroutine == null)
				{
					_queryItemsCoroutine = _behaviourToRunCoroutinesOn.StartCoroutine(UpdatedItemsQueryCoroutine());
				}
			}
			else
			{
				_updatesRequiredPendingTimer = 2f;
			}
		}

		public void SetCheckDownloadQueryPending(bool bSet, bool bQueryAllSubscribedToItems, PublishedFileId_t publishedFileId)
		{
			_checkDownloadQueryPendingTimer = 0f;
			if (bSet)
			{
				_checkDownloadQueryPendingTimer = 5f;
				_checkDownloadQueryPendingAllSubscribedToItems = bQueryAllSubscribedToItems;
				_checkDownloadQueryPendingPublishedFileId = publishedFileId;
			}
		}

		private void ProcessCheckDownloadQueryPending()
		{
			if (!(_checkDownloadQueryPendingTimer > 0f))
			{
				return;
			}
			_checkDownloadQueryPendingTimer -= Time.unscaledDeltaTime;
			if (_checkDownloadQueryPendingTimer <= 0f)
			{
				if (CheckDownloadItemsNeedingUpdate(_checkDownloadQueryPendingAllSubscribedToItems, _checkDownloadQueryPendingPublishedFileId))
				{
					_updatesRequiredPendingTimer = 0f;
				}
				else
				{
					_checkDownloadQueryPendingTimer = 5f;
				}
			}
		}

		private bool UpdateInstalledItemsOffline()
		{
			bool result = true;
			ReadLastSubscribedToPulishedFileIdsList();
			ExtContentMessages.LogDebug(string.Format("Workshop offline. Read {0} published filed ids from file '{1}' to be loaded from path '{2}'", _lastSubscribedToPulishedFileIdsList.Count, ExtContentUtils.GetPathSpec(Application.persistentDataPath, "SubIDsLast.txt"), _lastWorkshopInstalledContentFolderSpec));
			foreach (string lastSubscribedToPulishedFileIds in _lastSubscribedToPulishedFileIdsList)
			{
				string pathSpec = ExtContentUtils.GetPathSpec(_lastWorkshopInstalledContentFolderSpec, lastSubscribedToPulishedFileIds);
				if (WorkshopItemMetaData.DoesMetaDataFileExist(pathSpec))
				{
					WorkshopItemMetaData workshopItemMetaData = new WorkshopItemMetaData();
					if (workshopItemMetaData.ReadFromMetaDataFile(pathSpec))
					{
						PublishedFileId_t publishedFileId = WorkshopUtils.PublishedFileIdFromString(workshopItemMetaData.PublishedFileId);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("AssetVersion", workshopItemMetaData.VersionNumberOnDisk.ToString());
						dictionary.Add("ContentType", ExtContentType.ContentTypeToString(workshopItemMetaData.ContentType));
						long lastFolderUpdateTime = File.GetLastWriteTime(WorkshopItemMetaData.GetMetaDataFileSpec(pathSpec)).Millisecond;
						long sizeOnDisk = -1L;
						WorkshopItemDetail workshopItemDetail = new WorkshopItemDetail(workshopItemMetaData.Title, workshopItemMetaData.Description, publishedFileId, workshopItemMetaData.Visibility, dictionary);
						workshopItemDetail.SetInstalledInfo(pathSpec, lastFolderUpdateTime, sizeOnDisk);
						WorkshopInstalledItem workshopInstalledItem = new WorkshopInstalledItem();
						workshopInstalledItem.Init(workshopItemDetail);
						AddInstalledItem(workshopInstalledItem);
					}
				}
			}
			if (this.OnPreInstalledItemsProcessed != null)
			{
				this.OnPreInstalledItemsProcessed();
			}
			return result;
		}

		private void ReadLastSubscribedToPulishedFileIdsList()
		{
			List<string> _publishedFileIdsList = new List<string>();
			ReadPublishedFileIdsListFromDisk(ExtContentUtils.GetPathSpec(Application.persistentDataPath, "SubIDsLast.txt"), ref _publishedFileIdsList);
			_lastWorkshopInstalledContentFolderSpec = string.Empty;
			_lastSubscribedToPulishedFileIdsList.Clear();
			if (_publishedFileIdsList.Count > 0)
			{
				_lastWorkshopInstalledContentFolderSpec = _publishedFileIdsList[0];
				int i = 1;
				for (int count = _publishedFileIdsList.Count; i < count; i++)
				{
					_lastSubscribedToPulishedFileIdsList.Add(_publishedFileIdsList[i]);
				}
			}
		}

		private void CheckWriteLastSubscribedToPulishedFileIdsList()
		{
			if (!WorkshopUtils.AreSteamWorkshopFeaturesAvailable())
			{
				return;
			}
			_lastWorkshopInstalledContentFolderSpec = string.Empty;
			if (_installedItems.Count > 0)
			{
				_lastWorkshopInstalledContentFolderSpec = Path.GetDirectoryName(_installedItems[0].ItemDetail.InstalledFolderPathSpec);
			}
			_lastSubscribedToPulishedFileIdsList.Clear();
			foreach (WorkshopInstalledItem installedItem in _installedItems)
			{
				_lastSubscribedToPulishedFileIdsList.Add(installedItem.PublishedFileId.ToString());
			}
			List<string> list = new List<string>();
			list.Add(_lastWorkshopInstalledContentFolderSpec);
			foreach (string lastSubscribedToPulishedFileIds in _lastSubscribedToPulishedFileIdsList)
			{
				list.Add(lastSubscribedToPulishedFileIds);
			}
			WritePublishedFileIdsListToDisk(ExtContentUtils.GetPathSpec(Application.persistentDataPath, "SubIDsLast.txt"), list);
		}

		public void LogInstalledItems()
		{
			string arg = string.Empty;
			if (_installedItems.Count > 0)
			{
				arg = ExtContentUtils.GetPathSpecToNamedFolder(_installedItems[0].ItemDetail.InstalledFolderPathSpec, WorkshopUtils.GetAppIdStr());
			}
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("{0}: {1} Installed Items: (RootInstallPath: '{2}')"), "Workshop", _installedItems.Count, arg));
			int i = 0;
			for (int count = _installedItems.Count; i < count; i++)
			{
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("{0} Item:{1:00}/{2:00}:"), "Workshop Installed", i, count) + _installedItems[i].GetLogInfoString());
			}
		}

		public override string GetGameItemSourceSpecificLogInfoString(GameItemBase gameItem)
		{
			string empty = string.Empty;
			WorkshopInstalledItem workshopInstalledItem = FindWorkshopInstalledItemForGameItem(gameItem);
			if (workshopInstalledItem != null)
			{
				string pathSpecToNamedFolder = ExtContentUtils.GetPathSpecToNamedFolder(workshopInstalledItem.ItemDetail.InstalledFolderPathSpec, WorkshopUtils.GetAppIdStr());
				string arg = ExtContentUtils.MakePathSpecRelativeTo(workshopInstalledItem.ItemDetail.InstalledFolderPathSpec, pathSpecToNamedFolder);
				empty = string.Format(ExtContentUtils.HiliteParams("PFID:{0}({1}), I:'{2}'"), workshopInstalledItem.PublishedFileId.ToString(), "v" + $"{workshopInstalledItem.ItemDetail.GetVersionNumberOnDisk()}", arg);
			}
			else
			{
				empty = string.Format(ExtContentUtils.HiliteParams("{0}"), "Error finding workshop install info");
			}
			return "Workshop Installed: " + empty;
		}
	}
}
