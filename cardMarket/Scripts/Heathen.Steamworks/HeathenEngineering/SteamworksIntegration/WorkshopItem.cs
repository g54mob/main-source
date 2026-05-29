using System;
using System.Collections.Generic;
using System.IO;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	[HelpURL("https://kb.heathen.group/assets/steamworks/objects/workshop-item")]
	public class WorkshopItem
	{
		public Texture2D previewImage;

		public string previewImageLocation;

		protected SteamUGCDetails_t itemDetails;

		public string metadata;

		public StringKeyValuePair[] keyValueTags;

		public UnityEvent previewImageUpdated = new UnityEvent();

		public CallResult<RemoteStorageDownloadUGCResult_t> m_RemoteStorageDownloadUGCResult;

		public string Title => itemDetails.m_rgchTitle;

		public string Description => itemDetails.m_rgchDescription;

		public AppData ConsumerApp => itemDetails.m_nConsumerAppID;

		public PublishedFileId_t FileId => itemDetails.m_nPublishedFileId;

		public UserData Owner => new CSteamID(itemDetails.m_ulSteamIDOwner);

		public DateTime TimeCreated => new DateTime(1970, 1, 1).AddSeconds(itemDetails.m_rtimeCreated);

		public DateTime TimeUpdated => new DateTime(1970, 1, 1).AddSeconds(itemDetails.m_rtimeUpdated);

		public uint UpVotes => itemDetails.m_unVotesUp;

		public uint DownVotes => itemDetails.m_unVotesDown;

		public float VoteScore => itemDetails.m_flScore;

		public bool IsBanned => itemDetails.m_bBanned;

		public bool IsTagsTruncated => itemDetails.m_bTagsTruncated;

		public bool IsSubscribed => UserGeneratedContent.ItemStateHasFlag(StateFlags, EItemState.k_EItemStateSubscribed);

		public bool IsNeedsUpdate => UserGeneratedContent.ItemStateHasFlag(StateFlags, EItemState.k_EItemStateNeedsUpdate);

		public bool IsInstalled => UserGeneratedContent.ItemStateHasFlag(StateFlags, EItemState.k_EItemStateInstalled);

		public bool IsDownloading => UserGeneratedContent.ItemStateHasFlag(StateFlags, EItemState.k_EItemStateDownloading);

		public bool IsDownloadPending => UserGeneratedContent.ItemStateHasFlag(StateFlags, EItemState.k_EItemStateDownloadPending);

		public float DownloadCompletion
		{
			get
			{
				UserGeneratedContent.Client.GetItemDownloadInfo(FileId, out var completion);
				return completion;
			}
		}

		public int FileSize => itemDetails.m_nFileSize;

		public DirectoryInfo FolderPath
		{
			get
			{
				UserGeneratedContent.Client.GetItemInstallInfo(FileId, out var _, out var folderPath, out var _);
				return new DirectoryInfo(folderPath);
			}
		}

		public EItemState StateFlags => (EItemState)SteamUGC.GetItemState(itemDetails.m_nPublishedFileId);

		public ERemoteStoragePublishedFileVisibility Visibility => itemDetails.m_eVisibility;

		public string[] Tags => itemDetails.m_rgchTags?.Split(',');

		public SteamUGCDetails_t SourceItemDetails => itemDetails;

		public WorkshopItem(SteamUGCDetails_t itemDetails)
		{
			this.itemDetails = itemDetails;
			if (itemDetails.m_eFileType != EWorkshopFileType.k_EWorkshopFileTypeFirst)
			{
				Debug.LogWarning("HeathenWorkshopReadItem is designed to display File Type = Community Item, this item is not a community item and may not load correctly.");
			}
			m_RemoteStorageDownloadUGCResult = CallResult<RemoteStorageDownloadUGCResult_t>.Create(HandleUGCDownload);
			if (itemDetails.m_nPreviewFileSize > 0)
			{
				SteamAPICall_t hAPICall = SteamRemoteStorage.UGCDownload(itemDetails.m_hPreviewFile, 1u);
				m_RemoteStorageDownloadUGCResult.Set(hAPICall, HandleUGCDownloadPreviewFile);
			}
			else
			{
				Debug.LogWarning("Item [" + Title + "] has no preview file!");
			}
		}

		public static void Get(PublishedFileId_t file, Action<WorkshopItem> callback)
		{
			UgcQuery query = UgcQuery.Get(file);
			query.SetReturnLongDescription(longDescription: true);
			query.SetReturnMetadata(metadata: true);
			query.Execute(delegate(UgcQuery r)
			{
				callback?.Invoke((r.ResultsList != null && r.ResultsList.Count > 0) ? r.ResultsList[0] : null);
				query.Dispose();
			});
		}

		public static UgcQuery Get(IEnumerable<PublishedFileId_t> files)
		{
			return UgcQuery.Get(files);
		}

		public static UgcQuery GetMyPublished()
		{
			return UgcQuery.GetMyPublished();
		}

		public static UgcQuery GetMyPublished(AppData creatorApp, AppData consumerApp)
		{
			return UgcQuery.GetMyPublished(creatorApp, consumerApp);
		}

		public static UgcQuery GetSubscribed()
		{
			return UgcQuery.GetSubscribed();
		}

		public static UgcQuery GetPlayed()
		{
			return UgcQuery.GetPlayed();
		}

		public static UgcQuery GetPlayed(AppData creatorApp, AppData consumerApp)
		{
			return UgcQuery.GetPlayed(creatorApp, consumerApp);
		}

		public void UpdateTitle(string value, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t handle = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemTitle(handle, value))
			{
				UserGeneratedContent.Client.SubmitItemUpdate(handle, changeNote, callback);
				return;
			}
			callback?.Invoke(new SubmitItemUpdateResult_t
			{
				m_eResult = EResult.k_EResultInvalidParam
			}, arg2: true);
		}

		public void UpdateTitle(string value, LanguageCodes language, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t handle = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemUpdateLanguage(handle, language.ToString()))
			{
				if (!SteamUGC.SetItemTitle(handle, value))
				{
					UserGeneratedContent.Client.SubmitItemUpdate(handle, changeNote, callback);
					return;
				}
				callback?.Invoke(new SubmitItemUpdateResult_t
				{
					m_eResult = EResult.k_EResultInvalidParam
				}, arg2: true);
			}
			else
			{
				callback?.Invoke(new SubmitItemUpdateResult_t
				{
					m_eResult = EResult.k_EResultInvalidParam
				}, arg2: true);
			}
		}

		public void UpdateDescription(string value, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t handle = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemDescription(handle, value))
			{
				UserGeneratedContent.Client.SubmitItemUpdate(handle, changeNote, callback);
				return;
			}
			callback?.Invoke(new SubmitItemUpdateResult_t
			{
				m_eResult = EResult.k_EResultInvalidParam
			}, arg2: true);
		}

		public void UpdateDescription(string value, LanguageCodes language, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t handle = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemUpdateLanguage(handle, language.ToString()))
			{
				if (SteamUGC.SetItemDescription(handle, value))
				{
					UserGeneratedContent.Client.SubmitItemUpdate(handle, changeNote, callback);
					return;
				}
				callback?.Invoke(new SubmitItemUpdateResult_t
				{
					m_eResult = EResult.k_EResultInvalidParam
				}, arg2: true);
			}
			else
			{
				callback?.Invoke(new SubmitItemUpdateResult_t
				{
					m_eResult = EResult.k_EResultInvalidParam
				}, arg2: true);
			}
		}

		public void UpdateContent(DirectoryInfo value, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t handle = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemContent(handle, value.FullName))
			{
				UserGeneratedContent.Client.SubmitItemUpdate(handle, changeNote, callback);
				return;
			}
			callback?.Invoke(new SubmitItemUpdateResult_t
			{
				m_eResult = EResult.k_EResultInvalidParam
			}, arg2: true);
		}

		public void UpdateContent(FileInfo value, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t handle = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemPreview(handle, value.FullName))
			{
				UserGeneratedContent.Client.SubmitItemUpdate(handle, changeNote, callback);
				return;
			}
			callback?.Invoke(new SubmitItemUpdateResult_t
			{
				m_eResult = EResult.k_EResultInvalidParam
			}, arg2: true);
		}

		public void UpdateMetadata(string value, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t handle = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemMetadata(handle, value))
			{
				UserGeneratedContent.Client.SubmitItemUpdate(handle, changeNote, callback);
				return;
			}
			callback?.Invoke(new SubmitItemUpdateResult_t
			{
				m_eResult = EResult.k_EResultInvalidParam
			}, arg2: true);
		}

		public void UpdateTags(string[] value, string changeNote, Action<SubmitItemUpdateResult_t, bool> callback)
		{
			UGCUpdateHandle_t uGCUpdateHandle_t = UserGeneratedContent.Client.StartItemUpdate(ConsumerApp, FileId);
			if (SteamUGC.SetItemTags(uGCUpdateHandle_t, value))
			{
				UserGeneratedContent.Client.SubmitItemUpdate(uGCUpdateHandle_t, changeNote, callback);
				return;
			}
			callback?.Invoke(new SubmitItemUpdateResult_t
			{
				m_eResult = EResult.k_EResultInvalidParam
			}, arg2: true);
		}

		public void DownloadPreviewImage()
		{
			if (previewImage == null)
			{
				if (itemDetails.m_nPreviewFileSize > 0)
				{
					SteamAPICall_t hAPICall = SteamRemoteStorage.UGCDownload(itemDetails.m_hPreviewFile, 1u);
					m_RemoteStorageDownloadUGCResult.Set(hAPICall, HandleUGCDownloadPreviewFile);
				}
				else
				{
					Debug.LogWarning("Item [" + Title + "] has no preview file!");
				}
			}
		}

		public void DeleteItem(Action<DeleteItemResult_t, bool> callback)
		{
			UserGeneratedContent.Client.DeleteItem(FileId, callback);
		}

		public bool DownloadItem(bool highPriority)
		{
			return UserGeneratedContent.Client.DownloadItem(FileId, highPriority);
		}

		public void Subscribe(Action<RemoteStorageSubscribePublishedFileResult_t, bool> callback)
		{
			UserGeneratedContent.Client.SubscribeItem(FileId, callback);
		}

		public void Unsubscribe(Action<RemoteStorageUnsubscribePublishedFileResult_t, bool> callback)
		{
			UserGeneratedContent.Client.UnsubscribeItem(FileId, callback);
		}

		public void SetVote(bool voteUp, Action<SetUserItemVoteResult_t, bool> callback)
		{
			UserGeneratedContent.Client.SetUserItemVote(FileId, voteUp, callback);
		}

		public void StartPlayTime(Action<StartPlaytimeTrackingResult_t, bool> callback)
		{
			UserGeneratedContent.Client.StartPlaytimeTracking(new PublishedFileId_t[1] { FileId }, callback);
		}

		public void StopPlayTime(Action<StopPlaytimeTrackingResult_t, bool> callback)
		{
			UserGeneratedContent.Client.StopPlaytimeTracking(new PublishedFileId_t[1] { FileId }, callback);
		}

		private void HandleUGCDownload(RemoteStorageDownloadUGCResult_t param, bool bIOFailure)
		{
			if (!bIOFailure)
			{
				Debug.LogError("UGC Download generic handler loaded without failure.");
			}
			else
			{
				Debug.LogError("UGC Download request failed.");
			}
		}

		private void HandleUGCDownloadPreviewFile(RemoteStorageDownloadUGCResult_t param, bool bIOFailure)
		{
			if (!bIOFailure)
			{
				if (param.m_eResult == EResult.k_EResultOK)
				{
					byte[] array = new byte[param.m_nSizeInBytes];
					SteamRemoteStorage.UGCRead(param.m_hFile, array, param.m_nSizeInBytes, 0u, EUGCReadAction.k_EUGCRead_ContinueReadingUntilFinished);
					previewImage = new Texture2D(2, 2);
					previewImage.LoadImage(array);
					previewImageLocation = param.m_pchFileName;
					previewImageUpdated.Invoke();
				}
				else
				{
					Debug.LogError("UGC Download: unexpected result state: " + param.m_eResult.ToString() + "\nImage will not be loaded.");
				}
			}
			else
			{
				Debug.LogError("UGC Download request failed.");
			}
		}

		~WorkshopItem()
		{
			UnityEngine.Object.Destroy(previewImage);
		}
	}
}
