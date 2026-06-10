using System;
using System.Collections.Generic;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Tools;
using NSMedieval.UI;
using Steamworks;
using UnityEngine;

namespace NSMedieval.Modding
{
	public class SteamWorkshopManager : MonoSingleton<SteamWorkshopManager>
	{
		private ModInstance modInstance;

		private UGCUpdateHandle_t currentHandle = UGCUpdateHandle_t.Invalid;

		private CallResult<SteamUGCQueryCompleted_t> onSteamUgcQueryCompletedCallResult;

		private CallResult<RemoteStorageUnsubscribePublishedFileResult_t> onRemoteStorageUnsubscribePublishedLocal;

		private Callback<RemoteStoragePublishedFileSubscribed_t> onFileSubscribedRemotely;

		private Callback<RemoteStoragePublishedFileUnsubscribed_t> onFileUnsubscribedRemotely;

		private Callback<ItemInstalled_t> itemInstalledResult;

		private CallResult<SubmitItemUpdateResult_t> submitItemUpdateResult;

		private CallResult<CreateItemResult_t> createItemResult;

		public Dictionary<ulong, string> PublishedIdPathDictionary { get; } = new Dictionary<ulong, string>();

		public Dictionary<ulong, bool> PublishedIdIsAuthorDictionary { get; } = new Dictionary<ulong, bool>();

		public WorkshopItemVersion WorkshopItemVersion { get; private set; }

		public event Action OnWorkshopItemsUpdatedEvent;

		public event Action WorkshopAuthorCheckEvent;

		public event Action<ulong, bool> WorkshopItemAuthorEvent;

		public event Action WorkshopItemVersionUpdateEvent;

		public bool IsWorkshopItemAuthor(ModInstance modInstance)
		{
			return PublishedIdIsAuthorDictionary.GetValueOrDefault(modInstance.WorkshopPublishedFileId, defaultValue: false);
		}

		public void RunWorkshopItemAuthorQuery(PublishedFileId_t[] publisherFileIds)
		{
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised)
			{
				Log.Error("SteamManager is not initialized", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			UGCQueryHandle_t handle = SteamUGC.CreateQueryUGCDetailsRequest(publisherFileIds, (uint)publisherFileIds.Length);
			onSteamUgcQueryCompletedCallResult.Set(SteamUGC.SendQueryUGCRequest(handle));
		}

		public void NotifyVersionUpdate()
		{
			this.WorkshopItemVersionUpdateEvent?.Invoke();
		}

		private void OnWorkshopAuthorQueryCompleted(SteamUGCQueryCompleted_t param, bool biofailure)
		{
			SteamUGCDetails_t pDetails;
			for (int i = 0; i < param.m_unNumResultsReturned && SteamUGC.GetQueryUGCResult(param.m_handle, (uint)i, out pDetails); i++)
			{
				bool flag = pDetails.m_ulSteamIDOwner == SteamUser.GetSteamID().m_SteamID;
				PublishedIdIsAuthorDictionary.TryAdd((ulong)pDetails.m_nPublishedFileId, flag);
				this.WorkshopItemAuthorEvent?.Invoke((ulong)pDetails.m_nPublishedFileId, flag);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(45, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral(" SteamUGC.GetQueryUGCResult: Is Author ");
					messageBuilder.AppendFormatted(flag);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(pDetails.m_ulSteamIDOwner);
					messageBuilder.AppendLiteral(" == ");
					messageBuilder.AppendFormatted(SteamUser.GetSteamID().m_SteamID);
				}
				Log.Debug(messageBuilder);
			}
		}

		private void UpdateSubscribedItemsPaths()
		{
			PublishedIdPathDictionary.Clear();
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised)
			{
				Log.Info("SteamManager is not initialized", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			uint numSubscribedItems = SteamUGC.GetNumSubscribedItems();
			Log.Info("Subscribed items: " + numSubscribedItems, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (numSubscribedItems == 0)
			{
				this.OnWorkshopItemsUpdatedEvent?.Invoke();
				return;
			}
			PublishedFileId_t[] array = new PublishedFileId_t[numSubscribedItems];
			if (SteamUGC.GetSubscribedItems(array, numSubscribedItems) == 0)
			{
				Log.Info("Failed to get subscribed items", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			bool flag = false;
			int num = array.Length;
			PublishedFileId_t[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				PublishedFileId_t publishedFileId_t = array2[i];
				num--;
				EItemState itemState = (EItemState)SteamUGC.GetItemState(publishedFileId_t);
				bool isEnabled;
				if (itemState == EItemState.k_EItemStateNeedsUpdate)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Item ");
						messageBuilder.AppendFormatted(publishedFileId_t);
						messageBuilder.AppendLiteral(" needs update, waiting for it to be installed");
					}
					Log.Info(messageBuilder);
					OnItemNeedsUpdate(publishedFileId_t);
					return;
				}
				if (!itemState.HasFlag(EItemState.k_EItemStateSubscribed | EItemState.k_EItemStateInstalled))
				{
					continue;
				}
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Item ");
					messageBuilder2.AppendFormatted(publishedFileId_t);
					messageBuilder2.AppendLiteral(" is Installed");
				}
				Log.Debug(messageBuilder2);
				if (SteamUGC.GetItemInstallInfo(publishedFileId_t, out var punSizeOnDisk, out var pchFolder, 1024u, out var punTimeStamp))
				{
					if (!Directory.Exists(pchFolder))
					{
						SteamUGC.UnsubscribeItem(publishedFileId_t);
						return;
					}
					messageBuilder2 = new FVLogDebugInterpolationHandler(32, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendFormatted(punTimeStamp);
						messageBuilder2.AppendLiteral(" - Loaded item ay path: ");
						messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(pchFolder));
						messageBuilder2.AppendLiteral(", size: ");
						messageBuilder2.AppendFormatted(punSizeOnDisk);
					}
					Log.Debug(messageBuilder2);
					PublishedIdPathDictionary.Add(publishedFileId_t.m_PublishedFileId, pchFolder);
					flag = true;
				}
			}
			if (flag && num <= 0)
			{
				this.OnWorkshopItemsUpdatedEvent?.Invoke();
			}
		}

		public void UpdateMod(ModInstance modInstance)
		{
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised)
			{
				Log.Error("SteamManager is not initialized", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			this.modInstance = modInstance;
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				UploadWorkshopItem(new PublishedFileId_t(modInstance.WorkshopPublishedFileId));
			});
		}

		public void CreateWorkshopItem(ModInstance modInstance)
		{
			if (!MonoSingleton<SteamSdkManager>.IsInstantiated() || !SteamSdkManager.IsSteamInitialised)
			{
				Log.Error("SteamManager is not initialized", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			this.modInstance = modInstance;
			SteamAPICall_t hAPICall = SteamUGC.CreateItem(SteamUtils.GetAppID(), EWorkshopFileType.k_EWorkshopFileTypeFirst);
			createItemResult.Set(hAPICall);
		}

		private void OnItemCreated(CreateItemResult_t callback, bool iOFailure)
		{
			if (iOFailure)
			{
				Log.Error("Error: I/O Failure! :(", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			switch (callback.m_eResult)
			{
			case EResult.k_EResultInsufficientPrivilege:
				Log.Error("Unfortunately, you're banned by the community from uploading to the workshop!", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultTimeout:
				Log.Error("Timeout", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultNotLoggedOn:
				Log.Error("You're not logged into Steam!", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultBanned:
				Log.Error("You don't have permission to upload content to this hub because they have an active VAC or Game ban.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultServiceUnavailable:
				Log.Error("The workshop server hosting the content is having issues - please retry.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultInvalidParam:
				Log.Error("One of the submission fields contains something not being accepted by that field.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultAccessDenied:
				Log.Error("There was a problem trying to save the title and description. Access was denied.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultLimitExceeded:
				Log.Error("You have exceeded your Steam Cloud quota. Remove some items and try again.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultFileNotFound:
				Log.Error("The uploaded file could not be found.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultDuplicateRequest:
				Log.Error("The file was already successfully uploaded. Please refresh.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultDuplicateName:
				Log.Error("You already have a Steam Workshop item with that name.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultServiceReadOnly:
				Log.Error("Due to a recent password or email change, you are not allowed to upload new content. Usually this restriction will expire in 5 days, but can last up to 30 days if the account has been inactive recently.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			}
			if (callback.m_eResult != EResult.k_EResultOK)
			{
				Log.Error("Failed to create WorkShop item. Error: " + callback.m_eResult, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			if (callback.m_bUserNeedsToAcceptWorkshopLegalAgreement)
			{
				RedirectToLegal();
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Workshop item created: ");
				messageBuilder.AppendFormatted(callback.m_nPublishedFileId.ToString());
			}
			Log.Info(messageBuilder);
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				UploadWorkshopItem(callback.m_nPublishedFileId);
			});
		}

		private void UploadWorkshopItem(PublishedFileId_t publishedFileId)
		{
			Log.Info(" UploadWorkshopItem: ", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(SteamUtils.GetAppID(), publishedFileId);
			if (uGCUpdateHandle_t == UGCUpdateHandle_t.Invalid)
			{
				Log.Error("StartItemUpdate returned invalid handle", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			currentHandle = uGCUpdateHandle_t;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral(" UploadWorkshopItem: currentHandle: ");
				messageBuilder.AppendFormatted(currentHandle.ToString());
			}
			Log.Info(messageBuilder);
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("..."));
			SetupModItem(uGCUpdateHandle_t);
			SubmitModItem(uGCUpdateHandle_t);
		}

		private void SetupModItem(UGCUpdateHandle_t updateHandle)
		{
			SteamUGC.SetItemTitle(updateHandle, modInstance.ModModel.Name);
			SteamUGC.SetItemDescription(updateHandle, modInstance.ModModel.Description);
			SteamUGC.SetItemContent(updateHandle, modInstance.RootFolderPath);
			SteamUGC.SetItemTags(updateHandle, modInstance.TagsList);
			string previewModImagePath = ModdingUtils.GetPreviewModImagePath(modInstance.RootFolderPath);
			if (File.Exists(previewModImagePath))
			{
				SteamUGC.SetItemPreview(updateHandle, previewModImagePath);
			}
			SteamUGC.SetItemVisibility(updateHandle, ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate);
		}

		private void SubmitModItem(UGCUpdateHandle_t updateHandle)
		{
			SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(updateHandle, "New update");
			submitItemUpdateResult.Set(hAPICall, OnItemSubmitted);
		}

		private void OnItemSubmitted(SubmitItemUpdateResult_t callback, bool iOFailure)
		{
			currentHandle = UGCUpdateHandle_t.Invalid;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(45, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral(" OnItemSubmitted: currentHandle invalidated: ");
				messageBuilder.AppendFormatted(currentHandle.ToString());
			}
			Log.Info(messageBuilder);
			if (iOFailure)
			{
				Log.Error("I/O Failure!", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				return;
			}
			if (callback.m_bUserNeedsToAcceptWorkshopLegalAgreement)
			{
				RedirectToLegal();
				return;
			}
			MonoSingleton<UIController>.Instance.ClosePrompt();
			switch (callback.m_eResult)
			{
			case EResult.k_EResultOK:
				Log.Info("SUCCESS! Item submitted!", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				OnSubmitSuccess(callback.m_nPublishedFileId);
				break;
			case EResult.k_EResultFail:
				Log.Error("Result failed", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultInvalidParam:
				Log.Error("Either the provided app ID is invalid or doesn't match the consumer app ID of the item or, you have not enabled ISteamUGC for the provided app ID on the Steam Workshop Configuration App Admin page. The preview file is smaller than 16 bytes.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultAccessDenied:
				Log.Error("The user doesn't own a license for the provided app ID.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultFileNotFound:
				Log.Error("Failed to get the workshop info for the item or failed to read the preview file.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultLockingFailed:
				Log.Error("Failed to acquire UGC Lock.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			case EResult.k_EResultLimitExceeded:
				Log.Error("The preview image is too large, it must be less than 1 Megabyte; or there is not enough space available on the users Steam Cloud.", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				break;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Item ");
				messageBuilder.AppendFormatted(callback.m_nPublishedFileId);
				messageBuilder.AppendLiteral(" updated");
			}
			Log.Info(messageBuilder);
			EItemState itemState = (EItemState)SteamUGC.GetItemState(callback.m_nPublishedFileId);
			messageBuilder = new FVLogInfoInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Item state: ");
				messageBuilder.AppendFormatted(itemState);
			}
			Log.Info(messageBuilder);
			if (callback.m_eResult == EResult.k_EResultOK)
			{
				this.OnWorkshopItemsUpdatedEvent?.Invoke();
			}
			if (!itemState.HasFlag(EItemState.k_EItemStateInstalled))
			{
				UpdateSubscribedItemsPaths();
			}
			else if (itemState.HasFlag(EItemState.k_EItemStateNeedsUpdate))
			{
				OnItemNeedsUpdate(callback.m_nPublishedFileId);
			}
		}

		private void OnSubmitSuccess(PublishedFileId_t publishedFileId)
		{
			modInstance.SetWorkshopPublishedFileId(publishedFileId.m_PublishedFileId);
			string contents = JsonUtility.ToJson(publishedFileId);
			string path = Path.Combine(modInstance.RootFolderPath, "WorkshopId.json");
			File.WriteAllText(path, contents);
			this.WorkshopAuthorCheckEvent?.Invoke();
			string text = $"Submitted Steam workshop item. File containing id ({publishedFileId}) is saved in '{FilePathUtils.RemoveUserFromPath(path)}'. Would you like to see it in Workshop?";
			Log.Info(text, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), delegate
				{
					OpenWorkshopPage(publishedFileId.m_PublishedFileId);
				}),
				new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(text, buttonActions));
		}

		public void RedirectToLegal()
		{
			SteamFriends.ActivateGameOverlayToWebPage("https://steamcommunity.com/sharedfiles/workshoplegalagreement");
		}

		public void OpenWorkshopPage(ulong publishedFileId)
		{
			SteamFriends.ActivateGameOverlayToWebPage($"https://steamcommunity.com/sharedfiles/filedetails/?id={publishedFileId}&searchtext=");
		}

		public void GetMods(string[] tags)
		{
			string text = string.Empty;
			foreach (string text2 in tags)
			{
				text = text + "&requiredtags%5B%5D=" + text2;
			}
			SteamFriends.ActivateGameOverlayToWebPage($"https://steamcommunity.com/workshop/browse/?appid={SteamUtils.GetAppID()}&browsesort=trend&section=readytouseitems&admin_view=1{text}");
		}

		public void UnsubscribeFromWorkshopItem(ulong modInstanceWorkshopPublishedFileId)
		{
			SteamAPICall_t hAPICall = SteamUGC.UnsubscribeItem(new PublishedFileId_t(modInstanceWorkshopPublishedFileId));
			onRemoteStorageUnsubscribePublishedLocal.Set(hAPICall);
		}

		private void OnItemNeedsUpdate(PublishedFileId_t publishedFileId)
		{
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(18, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Item ");
				messageBuilder.AppendFormatted(publishedFileId);
				messageBuilder.AppendLiteral(" needs update");
			}
			Log.Debug(messageBuilder);
			if (SteamUGC.DownloadItem(publishedFileId, bHighPriority: true))
			{
				messageBuilder = new FVLogDebugInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Downloading item ");
					messageBuilder.AppendFormatted(publishedFileId);
				}
				Log.Debug(messageBuilder);
			}
		}

		private void OnItemInstalled(ItemInstalled_t param)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Item ");
				messageBuilder.AppendFormatted(param.m_nPublishedFileId);
				messageBuilder.AppendLiteral(" installed");
			}
			Log.Info(messageBuilder);
			UpdateSubscribedItemsPaths();
		}

		private void OnFileSubscribedRemotely(RemoteStoragePublishedFileSubscribed_t pCallback)
		{
			PublishedFileId_t nPublishedFileId = pCallback.m_nPublishedFileId;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(37, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("User has subscribed to item with ID: ");
				messageBuilder.AppendFormatted(nPublishedFileId);
			}
			Log.Debug(messageBuilder);
			EItemState itemState = (EItemState)SteamUGC.GetItemState(nPublishedFileId);
			messageBuilder = new FVLogDebugInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Item state: ");
				messageBuilder.AppendFormatted(itemState);
			}
			Log.Debug(messageBuilder);
			if (!itemState.HasFlag(EItemState.k_EItemStateNeedsUpdate))
			{
				UpdateSubscribedItemsPaths();
			}
			else
			{
				OnItemNeedsUpdate(nPublishedFileId);
			}
		}

		private void OnFileUnsubscribedRemotely(RemoteStoragePublishedFileUnsubscribed_t pCallback)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Unsubscribed remotely from item with ID: ");
				messageBuilder.AppendFormatted(pCallback.m_nPublishedFileId);
			}
			Log.Info(messageBuilder);
			UpdateSubscribedItemsPaths();
		}

		private void OnRemoteStorageUnsubscribePublishedFileResult(RemoteStorageUnsubscribePublishedFileResult_t pCallback, bool bIOFailure)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Unsubscribed locally from item with ID: ");
				messageBuilder.AppendFormatted(pCallback.m_nPublishedFileId);
			}
			Log.Info(messageBuilder);
			UpdateSubscribedItemsPaths();
		}

		public void Initialize()
		{
			if (MonoSingleton<SteamSdkManager>.IsInstantiated() && SteamSdkManager.IsSteamInitialised)
			{
				Log.Info("SteamWorkshopManager Start", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				WorkshopItemVersion = new WorkshopItemVersion();
				UpdateSubscribedItemsPaths();
				onSteamUgcQueryCompletedCallResult = CallResult<SteamUGCQueryCompleted_t>.Create(OnWorkshopAuthorQueryCompleted);
				onRemoteStorageUnsubscribePublishedLocal = CallResult<RemoteStorageUnsubscribePublishedFileResult_t>.Create(OnRemoteStorageUnsubscribePublishedFileResult);
				onFileSubscribedRemotely = Callback<RemoteStoragePublishedFileSubscribed_t>.Create(OnFileSubscribedRemotely);
				onFileUnsubscribedRemotely = Callback<RemoteStoragePublishedFileUnsubscribed_t>.Create(OnFileUnsubscribedRemotely);
				itemInstalledResult = Callback<ItemInstalled_t>.Create(OnItemInstalled);
				createItemResult = CallResult<CreateItemResult_t>.Create(OnItemCreated);
				submitItemUpdateResult = CallResult<SubmitItemUpdateResult_t>.Create(OnItemSubmitted);
				this.WorkshopAuthorCheckEvent?.Invoke();
				Log.Trace("SteamWorkshopManager Initialized", "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			currentHandle = UGCUpdateHandle_t.Invalid;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral(" OnDestroy: currentHandle invalidated: ");
				messageBuilder.AppendFormatted(currentHandle.ToString());
			}
			Log.Info(messageBuilder);
			onSteamUgcQueryCompletedCallResult?.Dispose();
			onRemoteStorageUnsubscribePublishedLocal?.Dispose();
			onFileSubscribedRemotely?.Dispose();
			onFileUnsubscribedRemotely?.Dispose();
			itemInstalledResult?.Dispose();
			createItemResult?.Dispose();
			submitItemUpdateResult?.Dispose();
			this.OnWorkshopItemsUpdatedEvent = null;
			this.WorkshopAuthorCheckEvent = null;
			this.WorkshopItemAuthorEvent = null;
			this.WorkshopItemVersionUpdateEvent = null;
		}

		private void UpdateProgress(UGCUpdateHandle_t handle)
		{
			ulong punBytesProcessed;
			ulong punBytesTotal;
			EItemUpdateStatus itemUpdateProgress = SteamUGC.GetItemUpdateProgress(handle, out punBytesProcessed, out punBytesTotal);
			string text = string.Empty;
			switch (itemUpdateProgress)
			{
			case EItemUpdateStatus.k_EItemUpdateStatusCommittingChanges:
				text = "Committing changes...";
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusUploadingPreviewFile:
				text = "Uploading preview image...";
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusUploadingContent:
				text = "Uploading content...";
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusPreparingConfig:
				text = "Preparing configuration...";
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusPreparingContent:
				text = "Preparing content...";
				break;
			case EItemUpdateStatus.k_EItemUpdateStatusInvalid:
				text = "Item invalid ... dunno why! :(";
				break;
			}
			float num = (float)punBytesProcessed / (float)punBytesTotal;
			string text2 = $" [{num:P}]";
			if (double.IsNaN(num))
			{
				text2 = string.Empty;
			}
			text += text2;
			MonoSingleton<UIController>.Instance.UpdatePromptText(text);
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(3, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(text);
				messageBuilder.AppendLiteral(" [");
				messageBuilder.AppendFormatted(num, "P");
				messageBuilder.AppendLiteral("]");
			}
			Log.Trace(messageBuilder);
		}

		private void Update()
		{
			if (currentHandle == UGCUpdateHandle_t.Invalid)
			{
				return;
			}
			try
			{
				UpdateProgress(currentHandle);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\SteamWorkshopManager.cs");
				throw;
			}
		}
	}
}
