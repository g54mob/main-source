using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Steamworks;
using UnityEngine;

namespace TH20.ExtContent
{
	public static class WorkshopUtils
	{
		public static PublishedFileId_t cNullPublishedFileId = default(PublishedFileId_t);

		private static int _uniqueSearchTagID = 1;

		private static EResult _lastSteamResult = EResult.k_EResultOK;

		public const bool _bAllowBlankWorkshopDescriptions = true;

		public const string cPeviewIconFileName = "WorkshopPreviewIcon.png";

		public static EItemVisibility StringToVisibilityType(string visibilityTypeStr)
		{
			EItemVisibility result = EItemVisibility.Private;
			visibilityTypeStr = visibilityTypeStr.ToLower();
			int i = 0;
			for (int num = 3; i < num; i++)
			{
				EItemVisibility eItemVisibility = (EItemVisibility)i;
				if (eItemVisibility.ToString().ToLower() == visibilityTypeStr)
				{
					result = eItemVisibility;
					break;
				}
			}
			return result;
		}

		public static bool AreSteamWorkshopFeaturesAvailable()
		{
			return OnlineManager.IsInitialized();
		}

		public static bool AreSteamWorkshopFeaturesAvailableForPublishing()
		{
			return true;
		}

		public static bool CheckSteamWorkshopFeaturesAvailableForPublishing(bool bSilent = false)
		{
			bool num = AreSteamWorkshopFeaturesAvailableForPublishing();
			if (!num && !bSilent)
			{
				ExtContentMessages.ShowErrorMessageBox(ExtContentMessages.GetMessageString(EMessageType.SteamWorkshopFeaturesErrorMessageTitle), ExtContentMessages.GetMessageString(EMessageType.SteamWorkshopFeaturesErrorMessageBody));
			}
			return num;
		}

		private static bool CheckSteamWorkshopFeaturesAvailable(bool bSilent = false)
		{
			bool num = AreSteamWorkshopFeaturesAvailable();
			if (!num && !bSilent)
			{
				ExtContentMessages.ShowErrorMessageBox(ExtContentMessages.GetMessageString(EMessageType.SteamWorkshopFeaturesErrorMessageTitle), ExtContentMessages.GetMessageString(EMessageType.SteamWorkshopFeaturesErrorMessageBody));
			}
			return num;
		}

		public static EResult GetLastSteamResult()
		{
			return _lastSteamResult;
		}

		public static bool IsLastSteamResultError()
		{
			return _lastSteamResult != EResult.k_EResultOK;
		}

		public static void ResetLastSteamResult()
		{
			_lastSteamResult = EResult.k_EResultOK;
		}

		public static void SetLastSteamResult(EResult result)
		{
			_lastSteamResult = result;
		}

		public static string GetLastSteamResultErrorCodeString()
		{
			if (!IsLastSteamResultError())
			{
				return string.Empty;
			}
			return SteamErrorCodeToString(_lastSteamResult);
		}

		public static string SteamErrorCodeToString(EResult steamResult)
		{
			string result = string.Empty;
			if (steamResult != EResult.k_EResultOK)
			{
				result = steamResult.ToString();
			}
			return result;
		}

		public static string GetItemStateString(uint itemState)
		{
			string text = string.Empty;
			if (itemState != 0)
			{
				int num = 32;
				for (int num2 = 1; num2 <= num; num2 <<= 1)
				{
					if ((itemState & num2) == num2)
					{
						if (!text.IsNullOrEmpty())
						{
							text += ", ";
						}
						string text2 = "Unknown";
						switch ((EItemState)num2)
						{
						case EItemState.k_EItemStateNone:
							text2 = "None";
							break;
						case EItemState.k_EItemStateSubscribed:
							text2 = "Subscribed";
							break;
						case EItemState.k_EItemStateLegacyItem:
							text2 = "Legacy Item";
							break;
						case EItemState.k_EItemStateInstalled:
							text2 = "Installed";
							break;
						case EItemState.k_EItemStateNeedsUpdate:
							text2 = "Needs Update";
							break;
						case EItemState.k_EItemStateDownloading:
							text2 = "Downloading";
							break;
						case EItemState.k_EItemStateDownloadPending:
							text2 = "Download Pending";
							break;
						}
						text += text2;
					}
				}
			}
			if (text.IsNullOrEmpty())
			{
				text = "None";
			}
			return text;
		}

		public static Dictionary<string, string> GetQueryItemTags(UGCQueryHandle_t hUGCQueryResult, uint itemIndex)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			uint queryUGCNumKeyValueTags = SteamUGC.GetQueryUGCNumKeyValueTags(hUGCQueryResult, itemIndex);
			for (uint num = 0u; num < queryUGCNumKeyValueTags; num++)
			{
				string pchKey = string.Empty;
				string pchValue = string.Empty;
				if (SteamUGC.GetQueryUGCKeyValueTag(hUGCQueryResult, itemIndex, num, out pchKey, 64u, out pchValue, 64u) && !dictionary.ContainsKey(pchKey))
				{
					dictionary.Add(pchKey, pchValue);
				}
			}
			return dictionary;
		}

		public static string GetAllTagsString(Dictionary<string, string> tags)
		{
			string text = string.Empty;
			int count = tags.Count;
			if (count > 0)
			{
				int num = 0;
				foreach (KeyValuePair<string, string> tag in tags)
				{
					text = text + "[" + num + "][" + tag.Key + "]:'" + tag.Value + "'";
					if (num < count - 1)
					{
						text += ", ";
					}
					num++;
				}
			}
			return text;
		}

		public static bool ValidateItemCreationParams(string itemName, string itemDescription, string itemFolderPathSpec)
		{
			bool flag = false;
			if (!itemName.IsNullOrEmpty())
			{
				itemDescription.IsNullOrEmpty();
				if (!itemFolderPathSpec.IsNullOrEmpty())
				{
					flag = true;
				}
			}
			if (!flag)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidWorkshopItemCreationParameters)));
			}
			return flag;
		}

		public static GameID GetAppId()
		{
			return OSManager.AppID;
		}

		public static string GetAppIdStr()
		{
			return GetAppId().ToString();
		}

		public static WaitForCallResult<CreateItemResult_t> StartItemCreate()
		{
			ExtContentMessages.LogDebug($"Starting workshop item creation ...");
			return new WaitForCallResult<CreateItemResult_t>(SteamUGC.CreateItem(SteamUtils.GetAppID(), EWorkshopFileType.k_EWorkshopFileTypeFirst));
		}

		public static void OnFinishedItemCreate()
		{
			ExtContentMessages.LogDebug("Finished workshop item creation!");
		}

		public static bool ValidateItemCreateResult(CreateItemResult_t createResult, string itemName)
		{
			bool result = false;
			SetLastSteamResult(createResult.m_eResult);
			if (createResult.m_eResult == EResult.k_EResultOK)
			{
				result = true;
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.CreateWorkshopItemError), itemName));
			}
			return result;
		}

		public static bool ValidateItemUpdateParams(string itemName, string itemContentTypeName, string itemDescription, int itemVersionNum, string workshopItemPreviewImageFileSpec, string itemDataFolderPathSpec)
		{
			bool result = false;
			if (!itemName.IsNullOrEmpty() && !itemContentTypeName.IsNullOrEmpty())
			{
				itemDescription.IsNullOrEmpty();
				if (!itemDataFolderPathSpec.IsNullOrEmpty())
				{
					if (ExtContentType.StringToContentType(itemContentTypeName) != EContentType.Unknown)
					{
						if (Directory.Exists(itemDataFolderPathSpec))
						{
							result = true;
							if (!workshopItemPreviewImageFileSpec.IsNullOrEmpty() && !File.Exists(workshopItemPreviewImageFileSpec))
							{
								result = false;
								ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopPreviewImageFileDoesNotExist), workshopItemPreviewImageFileSpec));
							}
						}
						else
						{
							ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopItemUpdateDataFolderNotFound), itemDataFolderPathSpec, itemName));
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopItemInvalidContentType), itemContentTypeName, itemName));
					}
					goto IL_00a6;
				}
			}
			ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidWorkshopItemUpdateParameters)));
			goto IL_00a6;
			IL_00a6:
			return result;
		}

		public static WaitForCallResult<SubmitItemUpdateResult_t> StartItemUpdate(out UGCUpdateHandle_t hRetUGCUpdate, PublishedFileId_t publishedFileId, string itemName, string itemContentTypeName, string itemDescription, string workshopItemPreviewImageFileSpec, EItemVisibility workshopItemVisibility, int itemVersionNum, List<string> workshopItemSearchTags, string itemDataFolderPathSpec, bool bIsInitialItemUpdate)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Starting workshop item update for item id {0}, Type {1}, from folder '{2}' ..."), publishedFileId.ToString(), itemContentTypeName, itemDataFolderPathSpec));
			AppId_t appID = SteamUtils.GetAppID();
			hRetUGCUpdate = SteamUGC.StartItemUpdate(appID, publishedFileId);
			bool flag = true;
			flag = SteamUGC.SetItemTitle(hRetUGCUpdate, itemName) && flag;
			flag = SteamUGC.SetItemDescription(hRetUGCUpdate, itemDescription) && flag;
			flag = SteamUGC.SetItemUpdateLanguage(hRetUGCUpdate, "english") && flag;
			flag = SteamUGC.SetItemMetadata(hRetUGCUpdate, "") && flag;
			ERemoteStoragePublishedFileVisibility eVisibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
			switch (workshopItemVisibility)
			{
			case EItemVisibility.Private:
				eVisibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
				break;
			case EItemVisibility.Friends:
				eVisibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityFriendsOnly;
				break;
			case EItemVisibility.Public:
				eVisibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic;
				break;
			}
			flag = SteamUGC.SetItemVisibility(hRetUGCUpdate, eVisibility) && flag;
			if (bIsInitialItemUpdate)
			{
				flag = SteamUGC.RemoveItemKeyValueTags(hRetUGCUpdate, "ContentType") && flag;
				flag = SteamUGC.AddItemKeyValueTag(hRetUGCUpdate, "ContentType", itemContentTypeName) && flag;
			}
			flag = SteamUGC.RemoveItemKeyValueTags(hRetUGCUpdate, "AssetVersion") && flag;
			flag = SteamUGC.AddItemKeyValueTag(hRetUGCUpdate, "AssetVersion", $"{itemVersionNum}") && flag;
			if (workshopItemSearchTags.Count > 0)
			{
				flag = SteamUGC.SetItemTags(hRetUGCUpdate, workshopItemSearchTags) && flag;
			}
			if (!workshopItemPreviewImageFileSpec.IsNullOrEmpty())
			{
				flag = SteamUGC.SetItemPreview(hRetUGCUpdate, workshopItemPreviewImageFileSpec) && flag;
			}
			flag = SteamUGC.SetItemContent(hRetUGCUpdate, itemDataFolderPathSpec) && flag;
			string empty = string.Empty;
			return new WaitForCallResult<SubmitItemUpdateResult_t>(SteamUGC.SubmitItemUpdate(hRetUGCUpdate, empty));
		}

		public static void OnFinishedItemUpdate()
		{
			ExtContentMessages.LogDebug("Finished workshop item update!");
		}

		public static bool LogItemUploadStatus(UGCUpdateHandle_t hUGCUpdate, ref float logTimer, float logTimerDuration, ref int bytesProcessed, ref int bytesTotal)
		{
			ulong punBytesProcessed = 0uL;
			ulong punBytesTotal = 0uL;
			EItemUpdateStatus itemUpdateProgress = SteamUGC.GetItemUpdateProgress(hUGCUpdate, out punBytesProcessed, out punBytesTotal);
			if ((int)punBytesProcessed > bytesProcessed)
			{
				bytesProcessed = (int)punBytesProcessed;
			}
			if ((int)punBytesTotal > bytesTotal)
			{
				bytesTotal = (int)punBytesTotal;
			}
			logTimer -= Time.unscaledDeltaTime;
			if (logTimer <= 0f)
			{
				logTimer = logTimerDuration;
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Upload progress: Status: [{0}] - {1}. Bytes uploaded {2} / {3}"), (int)itemUpdateProgress, itemUpdateProgress.ToString(), bytesProcessed, bytesTotal));
			}
			return itemUpdateProgress == EItemUpdateStatus.k_EItemUpdateStatusInvalid;
		}

		public static bool ValidateItemUpdateResult(SubmitItemUpdateResult_t updateResult, string itemName, string itemContentTypeName, string itemDataFolerPathSpec, string itemPublishedFileIdStr)
		{
			bool result = false;
			SetLastSteamResult(updateResult.m_eResult);
			if (updateResult.m_eResult == EResult.k_EResultOK)
			{
				result = true;
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.UploadWorkshopItemError), itemName, itemPublishedFileIdStr, itemContentTypeName, itemDataFolerPathSpec));
			}
			return result;
		}

		public static uint GetWorkshopItemState(PublishedFileId_t publishedFileId)
		{
			uint result = 0u;
			if (AreSteamWorkshopFeaturesAvailable())
			{
				result = SteamUGC.GetItemState(publishedFileId);
			}
			return result;
		}

		public static bool IsWorkshopItemInFullyInstalledState(PublishedFileId_t publishedFileId)
		{
			uint workshopItemState = GetWorkshopItemState(publishedFileId);
			bool flag = (workshopItemState & 1) != 0;
			bool flag2 = (workshopItemState & 2) != 0;
			bool flag3 = (workshopItemState & 4) != 0;
			bool flag4 = (workshopItemState & 8) != 0;
			bool flag5 = (workshopItemState & 0x10) != 0;
			bool flag6 = (workshopItemState & 0x20) != 0;
			if (flag && flag3 && !flag2 && !flag4 && !flag5)
			{
				return !flag6;
			}
			return false;
		}

		public static bool IsWorkshopItemInNeedsUpdateState(string publishedFileIdStr)
		{
			return IsWorkshopItemInNeedsUpdateState(PublishedFileIdFromString(publishedFileIdStr));
		}

		public static bool IsWorkshopItemInNeedsUpdateState(PublishedFileId_t publishedFileId)
		{
			uint workshopItemState = GetWorkshopItemState(publishedFileId);
			bool flag = (workshopItemState & 1) != 0;
			bool flag2 = (workshopItemState & 2) != 0;
			bool flag3 = (workshopItemState & 4) != 0;
			bool flag4 = (workshopItemState & 8) != 0;
			bool flag5 = (workshopItemState & 0x10) != 0;
			bool flag6 = (workshopItemState & 0x20) != 0;
			if (flag && flag3 && flag4 && !flag2 && !flag5)
			{
				return !flag6;
			}
			return false;
		}

		public static bool GetSubscribedToItemsPublishedFileIds(out uint retNumItems, out PublishedFileId_t[] retPublishedFileIDs)
		{
			ExtContentMessages.LogDebug("Obtaining subscribed to published file ids ...");
			bool flag = true;
			retNumItems = 0u;
			retPublishedFileIDs = null;
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			if (numSubscribedItems != 0)
			{
				retPublishedFileIDs = new PublishedFileId_t[numSubscribedItems];
				uint subscribedItems = SteamUGC.GetSubscribedItems(retPublishedFileIDs, numSubscribedItems);
				if (subscribedItems != 0)
				{
					retNumItems = subscribedItems;
				}
				else
				{
					flag = false;
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopZeroGetSubscribedItems)));
				}
			}
			else
			{
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Found {0} subscribed to published file ids"), 0));
			}
			if (flag)
			{
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Successfully retrieved {0} subscribed to published file ids..."), numSubscribedItems));
			}
			return flag;
		}

		public static PublishedFileId_t[] PublishedFileIdsArrayFromList(List<PublishedFileId_t> publishedFileIdsList)
		{
			PublishedFileId_t[] array = null;
			int count = publishedFileIdsList.Count;
			if (count > 0)
			{
				array = new PublishedFileId_t[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = publishedFileIdsList[i];
				}
			}
			return array;
		}

		public static WaitForCallResult<SteamUGCQueryCompleted_t> StartPublishedItemsQuery(uint numSubscribedToItems, PublishedFileId_t[] publishedFileIDs)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Starting workshop items query on {0} published file ids ..."), numSubscribedToItems));
			UGCQueryHandle_t handle = SteamUGC.CreateQueryUGCDetailsRequest(publishedFileIDs, numSubscribedToItems);
			SteamUGC.SetReturnOnlyIDs(handle, bReturnOnlyIDs: false);
			SteamUGC.SetReturnKeyValueTags(handle, bReturnKeyValueTags: true);
			SteamUGC.SetReturnLongDescription(handle, bReturnLongDescription: true);
			return new WaitForCallResult<SteamUGCQueryCompleted_t>(SteamUGC.SendQueryUGCRequest(handle));
		}

		public static WaitForCallResult<SteamUGCQueryCompleted_t> StartGeneralItemsQuery(EQueryType queryType, uint pageNum = 1u)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Starting workshop {0} query for page {1} ..."), queryType.ToString(), pageNum));
			AppId_t appID = SteamUtils.GetAppID();
			AccountID_t accountID = SteamUser.GetSteamID().GetAccountID();
			UGCQueryHandle_t handle = ((queryType != EQueryType.All) ? SteamUGC.CreateQueryUserUGCRequest(accountID, EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_All, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderAsc, appID, appID, pageNum) : SteamUGC.CreateQueryAllUGCRequest(EUGCQuery.k_EUGCQuery_RankedByPublicationDate, EUGCMatchingUGCType.k_EUGCMatchingUGCType_All, appID, appID, pageNum));
			SteamUGC.SetReturnOnlyIDs(handle, bReturnOnlyIDs: false);
			SteamUGC.SetReturnKeyValueTags(handle, bReturnKeyValueTags: true);
			SteamUGC.SetReturnLongDescription(handle, bReturnLongDescription: true);
			return new WaitForCallResult<SteamUGCQueryCompleted_t>(SteamUGC.SendQueryUGCRequest(handle));
		}

		public static WaitForCallResult<SteamUGCQueryCompleted_t> StartAllItemsQuery(uint pageNum = 1u)
		{
			return StartGeneralItemsQuery(EQueryType.All, pageNum);
		}

		public static WaitForCallResult<SteamUGCQueryCompleted_t> StartUserItemsQuery(uint pageNum = 1u)
		{
			return StartGeneralItemsQuery(EQueryType.User, pageNum);
		}

		public static void OnFinishedItemsQuery(int numItemsFound)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Finished workshop items query finding {0} items"), numItemsFound));
		}

		public static bool ValidateItemsQueryResult(SteamUGCQueryCompleted_t queryResult, uint numSubscribedToItemsReqd = 0u, bool bSilent = true)
		{
			bool flag = false;
			SetLastSteamResult(queryResult.m_eResult);
			if (queryResult.m_eResult == EResult.k_EResultOK)
			{
				int unNumResultsReturned = (int)queryResult.m_unNumResultsReturned;
				if (numSubscribedToItemsReqd == 0 || unNumResultsReturned == numSubscribedToItemsReqd)
				{
					flag = true;
					if (queryResult.m_bCachedData)
					{
						ExtContentMessages.LogDebug("Items query returned cached results");
					}
				}
				else
				{
					ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.WorkshopQueryItemsNumDetailsMismatch), numSubscribedToItemsReqd, unNumResultsReturned));
				}
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.QueryWorkshopItemsDetailFailed)));
			}
			if (!flag && !bSilent)
			{
				ExtContentMessages.ShowPlayerGeneralErrorMessageBox();
			}
			return flag;
		}

		public static bool CreateItemDetailsFromQueryResult(SteamUGCQueryCompleted_t queryResult, ref List<WorkshopItemDetail> workshopItemsDetails)
		{
			bool result = false;
			UGCQueryHandle_t handle = queryResult.m_handle;
			if (queryResult.m_unNumResultsReturned != 0)
			{
				if (workshopItemsDetails == null)
				{
					workshopItemsDetails = new List<WorkshopItemDetail>();
				}
				result = true;
				for (uint num = 0u; num < queryResult.m_unNumResultsReturned; num++)
				{
					if (SteamUGC.GetQueryUGCResult(handle, num, out var pDetails))
					{
						PublishedFileId_t nPublishedFileId = pDetails.m_nPublishedFileId;
						Dictionary<string, string> queryItemTags = GetQueryItemTags(handle, num);
						if (ExtContentUtils.IsTagsContentTypeValid(queryItemTags))
						{
							uint workshopItemState = GetWorkshopItemState(nPublishedFileId);
							bool flag = (workshopItemState & 8) != 0;
							bool flag2 = (workshopItemState & 4) != 0;
							ulong punBytesDownloaded = 0uL;
							ulong punBytesTotal = 0uL;
							if (flag)
							{
								SteamUGC.GetItemDownloadInfo(nPublishedFileId, out punBytesDownloaded, out punBytesTotal);
							}
							bool flag3 = false;
							uint punTimeStamp = 0u;
							ulong punSizeOnDisk = 0uL;
							string pchFolder = string.Empty;
							if (flag2)
							{
								if (SteamUGC.GetItemInstallInfo(nPublishedFileId, out punSizeOnDisk, out pchFolder, 1024u, out punTimeStamp))
								{
									flag3 = true;
								}
								else
								{
									ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ErrorObtainingWorkshopItemInstallInfo), nPublishedFileId.ToString()));
								}
							}
							EItemVisibility visibility = EItemVisibility.Private;
							switch (pDetails.m_eVisibility)
							{
							case ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic:
								visibility = EItemVisibility.Public;
								break;
							case ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityFriendsOnly:
								visibility = EItemVisibility.Friends;
								break;
							case ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate:
								visibility = EItemVisibility.Private;
								break;
							}
							WorkshopItemDetail workshopItemDetail = new WorkshopItemDetail(pDetails.m_rgchTitle, pDetails.m_rgchDescription, nPublishedFileId, visibility, queryItemTags);
							if (flag2 && flag3)
							{
								workshopItemDetail.SetInstalledInfo(pchFolder, punTimeStamp, (long)punSizeOnDisk);
							}
							if (flag)
							{
								workshopItemDetail.SetNeedsUpdateInfo((long)punBytesDownloaded, (long)punBytesTotal);
							}
							workshopItemsDetails.Add(workshopItemDetail);
						}
						else
						{
							ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.QueryWorkshopItemUnknownType), nPublishedFileId.ToString(), ExtContentUtils.GetContentTypeTagValueString(queryItemTags)));
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.QueryWorkshopItemDetailFailed), num));
					}
				}
			}
			SteamUGC.ReleaseQueryUGCRequest(handle);
			return result;
		}

		public static bool StartItemDownloading(WorkshopItemDetail itemDetail, bool bHighPriority = false)
		{
			bool result = false;
			if (SteamUGC.DownloadItem(itemDetail.PublishedFileId, bHighPriority))
			{
				result = true;
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Started downloading workshop item '{0}'"), itemDetail.PublishedFileId.ToString()));
			}
			else
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FailedToStartWorkshopItemDownload), itemDetail.PublishedFileId.ToString()));
			}
			return result;
		}

		public static PublishedFileId_t PublishedFileIdFromString(string publishedFileIdStr)
		{
			PublishedFileId_t result = default(PublishedFileId_t);
			result.m_PublishedFileId = 0uL;
			if (!publishedFileIdStr.IsNullOrEmpty())
			{
				result.m_PublishedFileId = Convert.ToUInt64(publishedFileIdStr);
			}
			return result;
		}

		public static void LogItemsDetails(string contextStr, List<WorkshopItemDetail> itemDetails)
		{
			if (itemDetails != null)
			{
				int i = 0;
				for (int count = itemDetails.Count; i < count; i++)
				{
					ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("{0} Item:{1}/{2}:"), contextStr, i, count) + itemDetails[i].GetLogInfoString());
				}
			}
		}

		public static void OpenSteamOverlay(string steamOverlayURL, string browserURL)
		{
			if (!CheckSteamWorkshopFeaturesAvailable())
			{
				return;
			}
			bool flag = OnlineManager.IsInitialized();
			bool flag2 = SteamUtils.IsOverlayEnabled();
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Called OpenSteamOverlay with URL Steam:'{0}', Browser:'{1}'. SteamManagerInitialised: {2}, SteamOverlayEnabled: {3}"), steamOverlayURL, browserURL, flag ? "Y" : "N", flag2 ? "Y" : "N"));
			if (!steamOverlayURL.IsNullOrEmpty())
			{
				bool flag3 = true;
				if (flag && flag2)
				{
					ExtContentMessages.LogDebug($"Calling SteamFriends.ActivateGameOverlayToWebPage with URL '{steamOverlayURL}'");
					flag3 = false;
					SteamFriends.ActivateGameOverlayToWebPage(steamOverlayURL);
				}
				if (flag3 && browserURL.StartsWith("https:"))
				{
					ExtContentMessages.LogDebug($"Failed to open steam overlay - starting system process with browser URL '{browserURL}'");
					Process.Start(browserURL);
				}
			}
		}
	}
}
