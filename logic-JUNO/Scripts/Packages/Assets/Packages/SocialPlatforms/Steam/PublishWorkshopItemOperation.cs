using System.Collections.Generic;
using System.Collections.ObjectModel;
using Steamworks;
using UnityEngine;

namespace Assets.Packages.SocialPlatforms.Steam
{
	public class PublishWorkshopItemOperation : IPublishWorkshopItemOperation
	{
		private CallResult<CreateItemResult_t> _createItemResult;

		private CallResult<SteamUGCQueryCompleted_t> _idQuery;

		private UGCUpdateHandle_t? _updateHandle;

		private CallResult<SubmitItemUpdateResult_t> _updateItemResult;

		public string Description { get; private set; }

		public string FolderPath { get; private set; }

		public string Language { get; private set; }

		public string ModName { get; private set; }

		public bool MustAcceptLicenseAgreement { get; private set; }

		public string PreviewPath { get; private set; }

		public PublishedFileId_t? PublishedFileId { get; private set; }

		ulong? IPublishWorkshopItemOperation.PublishedFileId => (ulong?)PublishedFileId;

		public PublishWorkshopItemOperationStatus Status { get; private set; }

		public string StatusDetails { get; private set; }

		public ReadOnlyCollection<string> Tags { get; private set; }

		public string Title { get; private set; }

		public SteamVisibility Visibility { get; private set; }

		public PublishWorkshopItemOperation(string modName, PublishedFileId_t? id, string folderPath, string previewImagePath, string title, SteamVisibility visibility, string language, IList<string> tags, string description)
		{
			ModName = modName;
			PublishedFileId = id;
			FolderPath = folderPath;
			PreviewPath = previewImagePath;
			Title = title;
			Visibility = visibility;
			Language = language;
			Tags = new ReadOnlyCollection<string>(tags);
			Description = description;
			Status = PublishWorkshopItemOperationStatus.NotStarted;
			StatusDetails = string.Empty;
			_idQuery = new CallResult<SteamUGCQueryCompleted_t>(OnIdQuery);
			_createItemResult = new CallResult<CreateItemResult_t>(OnCreateItem);
			_updateItemResult = new CallResult<SubmitItemUpdateResult_t>(OnUpdateItem);
			ApplyGreaseToSqueakyWheels();
		}

		public void OpenWorkshopBrowserPage()
		{
			if (PublishedFileId.HasValue)
			{
				SteamFriends.ActivateGameOverlayToWebPage("steam://url/CommunityFilePage/" + PublishedFileId.Value.ToString());
			}
		}

		public void PublishAsync()
		{
			if (Status == PublishWorkshopItemOperationStatus.NotStarted)
			{
				Status = PublishWorkshopItemOperationStatus.Started;
				if (PublishedFileId.HasValue)
				{
					UpdateItem();
				}
				else
				{
					QueryIdAndPublish();
				}
			}
		}

		public void UpdateStatus()
		{
			if (Status != PublishWorkshopItemOperationStatus.Updating || !_updateHandle.HasValue)
			{
				return;
			}
			ulong punBytesProcessed;
			ulong punBytesTotal;
			EItemUpdateStatus itemUpdateProgress = SteamUGC.GetItemUpdateProgress(_updateHandle.Value, out punBytesProcessed, out punBytesTotal);
			if (itemUpdateProgress != EItemUpdateStatus.k_EItemUpdateStatusInvalid)
			{
				string empty = string.Empty;
				empty = itemUpdateProgress switch
				{
					EItemUpdateStatus.k_EItemUpdateStatusCommittingChanges => "Committing Changes", 
					EItemUpdateStatus.k_EItemUpdateStatusPreparingConfig => "Preparing Config", 
					EItemUpdateStatus.k_EItemUpdateStatusPreparingContent => "Preparing Content", 
					EItemUpdateStatus.k_EItemUpdateStatusUploadingContent => "Uploading Content", 
					EItemUpdateStatus.k_EItemUpdateStatusUploadingPreviewFile => "Uploading Preview File", 
					_ => "Publishing to Steam Workshop", 
				};
				if (punBytesTotal != 0)
				{
					StatusDetails = $"{empty}... {(double)punBytesProcessed / (double)punBytesTotal * 100.0:F2}%\n{punBytesProcessed} of {punBytesTotal} bytes";
				}
				else
				{
					StatusDetails = empty;
				}
			}
		}

		private void ApplyGreaseToSqueakyWheels()
		{
			_idQuery.ToString();
			_createItemResult.ToString();
			_updateItemResult.ToString();
		}

		private void CreateItem()
		{
			SteamAPICall_t hAPICall = SteamUGC.CreateItem(SteamUtils.GetAppID(), EWorkshopFileType.k_EWorkshopFileTypeFirst);
			_createItemResult.Set(hAPICall);
		}

		private void OnCreateItem(CreateItemResult_t result, bool iofailure)
		{
			if (result.m_eResult != EResult.k_EResultOK || iofailure)
			{
				Debug.LogErrorFormat("Steam was unable to create a workshop item for mod '{0}'. IOFailure: {0}, Result: {1}", ModName, iofailure, result.m_eResult);
				Status = PublishWorkshopItemOperationStatus.Failed;
				StatusDetails = string.Format("Item Creation Failed. Result: {0}{1}", result.m_eResult, iofailure ? "  (IO Failure)" : string.Empty);
			}
			else
			{
				MustAcceptLicenseAgreement = result.m_bUserNeedsToAcceptWorkshopLegalAgreement;
				PublishedFileId = result.m_nPublishedFileId;
				UpdateItem();
			}
		}

		private void OnIdQuery(SteamUGCQueryCompleted_t result, bool iofailure)
		{
			if (result.m_eResult != EResult.k_EResultOK || iofailure)
			{
				Debug.LogErrorFormat("Steam query to find the published file ID of mod '{0}' failed. IOFailure: {0}, Result: {1}", ModName, iofailure, result.m_eResult);
				Status = PublishWorkshopItemOperationStatus.Failed;
				StatusDetails = string.Format("ID query failed. Result: {0}{1}", result.m_eResult, iofailure ? "  (IO Failure)" : string.Empty);
				return;
			}
			for (uint num = 0u; num < result.m_unNumResultsReturned; num++)
			{
				uint queryUGCNumKeyValueTags = SteamUGC.GetQueryUGCNumKeyValueTags(result.m_handle, num);
				for (uint num2 = 0u; num2 < queryUGCNumKeyValueTags; num2++)
				{
					if (SteamUGC.GetQueryUGCKeyValueTag(result.m_handle, num, num2, out var pchKey, 1024u, out var pchValue, 1024u) && pchKey == "ModName" && pchValue == ModName && SteamUGC.GetQueryUGCResult(result.m_handle, num, out var pDetails))
					{
						PublishedFileId = pDetails.m_nPublishedFileId;
						break;
					}
				}
				if (PublishedFileId.HasValue)
				{
					break;
				}
			}
			SteamUGC.ReleaseQueryUGCRequest(result.m_handle);
			if (PublishedFileId.HasValue)
			{
				UpdateItem();
			}
			else
			{
				CreateItem();
			}
		}

		private void OnUpdateItem(SubmitItemUpdateResult_t result, bool iofailure)
		{
			if (result.m_eResult != EResult.k_EResultOK || iofailure)
			{
				Debug.LogErrorFormat("Steam was unable to update the workshop item for mod '{0}'. IOFailure: {0}, Result: {1}", ModName, iofailure, result.m_eResult);
				Status = PublishWorkshopItemOperationStatus.Failed;
				StatusDetails = string.Format("Item Update Failed. Result: {0}{1}", result.m_eResult, iofailure ? "  (IO Failure)" : string.Empty);
			}
			else
			{
				MustAcceptLicenseAgreement = result.m_bUserNeedsToAcceptWorkshopLegalAgreement;
				Status = PublishWorkshopItemOperationStatus.Completed;
				StatusDetails = "Publish Succeeded";
				_updateHandle = null;
			}
		}

		private void QueryIdAndPublish()
		{
			AccountID_t accountID = SteamUser.GetSteamID().GetAccountID();
			AppId_t appID = SteamUtils.GetAppID();
			UGCQueryHandle_t handle = SteamUGC.CreateQueryUserUGCRequest(accountID, EUserUGCList.k_EUserUGCList_Published, EUGCMatchingUGCType.k_EUGCMatchingUGCType_Items, EUserUGCListSortOrder.k_EUserUGCListSortOrder_CreationOrderAsc, appID, appID, 1u);
			SteamUGC.SetReturnKeyValueTags(handle, bReturnKeyValueTags: true);
			SteamAPICall_t hAPICall = SteamUGC.SendQueryUGCRequest(handle);
			_idQuery.Set(hAPICall);
		}

		private void UpdateItem()
		{
			UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(SteamUtils.GetAppID(), PublishedFileId.Value);
			SteamUGC.SetItemTitle(uGCUpdateHandle_t, Title);
			SteamUGC.SetItemVisibility(uGCUpdateHandle_t, (ERemoteStoragePublishedFileVisibility)Visibility);
			SteamUGC.SetItemUpdateLanguage(uGCUpdateHandle_t, Language);
			SteamUGC.SetItemTags(uGCUpdateHandle_t, Tags);
			SteamUGC.SetItemDescription(uGCUpdateHandle_t, Description);
			SteamUGC.SetItemContent(uGCUpdateHandle_t, FolderPath);
			SteamUGC.SetItemPreview(uGCUpdateHandle_t, PreviewPath);
			SteamUGC.AddItemKeyValueTag(uGCUpdateHandle_t, "ModName", ModName);
			SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, null);
			_updateHandle = uGCUpdateHandle_t;
			_updateItemResult.Set(hAPICall);
			Status = PublishWorkshopItemOperationStatus.Updating;
			UpdateStatus();
		}
	}
}
