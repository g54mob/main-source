using System;
using System.Collections;
using System.IO;
using Steamworks;
using UnityEngine;

public class SteamWorkshopEvents
{
	private struct SteamWorkshopItem
	{
		public string[] ContentFilesPath;

		public string Description;

		public string PreviewImagePath;

		public string[] Tags;

		public string Title;
	}

	private SteamWorkshopItem currentSteamWorkshopItem;

	private PublishedFileId_t currentPublishedFileId;

	private CallResult<CreateItemResult_t> createItemCallResult;

	private CallResult<SubmitItemUpdateResult_t> submitItemUpdateCallResult;

	private CallResult<RemoteStorageUnsubscribePublishedFileResult_t> unsubscribeItemCallResult;

	private MonoBehaviour monoBehaviour;

	private Coroutine itemUpdateProcessCoroutine;

	private bool isNewItemCreated;

	public event Action<ulong> OnFinishedCreateItemEvent;

	public event Action OnUploadingItemEvent;

	public event Action<ulong> OnUploadedItemEvent;

	public event Action<string> OnNotCreateItemEvent;

	public event Action<string> OnNotUploadedItemEvent;

	public event Action<string> OnNotUpgradedItemEvent;

	public event Action OnUnsubscribedItemEvent;

	public event Action<string> OnNotUnsubscribedItemEvent;

	public SteamWorkshopEvents(MonoBehaviour monoBehaviour)
	{
		this.monoBehaviour = monoBehaviour;
		createItemCallResult = CallResult<CreateItemResult_t>.Create(CreateItemResultHandler);
		submitItemUpdateCallResult = CallResult<SubmitItemUpdateResult_t>.Create(SubmitItemUpdateResultHandler);
		unsubscribeItemCallResult = CallResult<RemoteStorageUnsubscribePublishedFileResult_t>.Create(UnsubscribeItemResultHandler);
		isNewItemCreated = false;
	}

	public void UnsubscribeItem(ulong workshopId)
	{
		SteamAPICall_t hAPICall = SteamUGC.UnsubscribeItem(new PublishedFileId_t(workshopId));
		unsubscribeItemCallResult.Set(hAPICall);
	}

	private void UnsubscribeItemResultHandler(RemoteStorageUnsubscribePublishedFileResult_t param, bool bIOFailure)
	{
		if (param.m_eResult == EResult.k_EResultOK)
		{
			this.OnUnsubscribedItemEvent?.Invoke();
		}
		else
		{
			this.OnNotUnsubscribedItemEvent?.Invoke(param.m_eResult.ToString());
		}
	}

	public void SetContent(string itemTitle, string itemDescription, string[] contentFilesPath, string[] tags, string previewImagePath)
	{
		currentSteamWorkshopItem = new SteamWorkshopItem
		{
			Title = itemTitle,
			Description = itemDescription,
			ContentFilesPath = contentFilesPath,
			Tags = tags,
			PreviewImagePath = previewImagePath
		};
	}

	public void CreateNewItem()
	{
		SteamAPICall_t hAPICall = SteamUGC.CreateItem(SteamUtils.GetAppID(), EWorkshopFileType.k_EWorkshopFileTypeFirst);
		createItemCallResult.Set(hAPICall);
	}

	private void CreateItemResultHandler(CreateItemResult_t param, bool bIOFailure)
	{
		if (param.m_eResult == EResult.k_EResultOK)
		{
			isNewItemCreated = true;
			this.OnFinishedCreateItemEvent?.Invoke((ulong)param.m_nPublishedFileId);
			UpdateItem(param.m_nPublishedFileId);
		}
		else
		{
			this.OnNotCreateItemEvent?.Invoke(param.m_eResult.ToString());
		}
	}

	private void CopyFilesToTempFolder()
	{
		DeleteTempFolder();
		Directory.CreateDirectory(PathNames.WorkshopTemp);
		string[] contentFilesPath = currentSteamWorkshopItem.ContentFilesPath;
		foreach (string path in contentFilesPath)
		{
			string directoryName = Path.GetDirectoryName(path);
			string fileName = Path.GetFileName(path);
			File.Copy(Path.Combine(directoryName, fileName), Path.Combine(PathNames.WorkshopTemp, fileName));
		}
	}

	public void UpdateItem(ulong workshopId)
	{
		UpdateItem(new PublishedFileId_t(workshopId));
	}

	private void UpdateItem(PublishedFileId_t publishedFileId)
	{
		currentPublishedFileId = publishedFileId;
		CopyFilesToTempFolder();
		UGCUpdateHandle_t uGCUpdateHandle_t = SteamUGC.StartItemUpdate(SteamUtils.GetAppID(), publishedFileId);
		SteamUGC.SetItemTitle(uGCUpdateHandle_t, currentSteamWorkshopItem.Title);
		SteamUGC.SetItemDescription(uGCUpdateHandle_t, currentSteamWorkshopItem.Description);
		SteamUGC.SetItemContent(uGCUpdateHandle_t, PathNames.WorkshopTemp);
		SteamUGC.SetItemTags(uGCUpdateHandle_t, currentSteamWorkshopItem.Tags);
		SteamUGC.SetItemPreview(uGCUpdateHandle_t, currentSteamWorkshopItem.PreviewImagePath);
		SteamUGC.SetItemVisibility(uGCUpdateHandle_t, ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic);
		SteamAPICall_t hAPICall = SteamUGC.SubmitItemUpdate(uGCUpdateHandle_t, "");
		submitItemUpdateCallResult.Set(hAPICall);
		itemUpdateProcessCoroutine = monoBehaviour.StartCoroutine(ItemUpdateProgress(uGCUpdateHandle_t));
	}

	private void SubmitItemUpdateResultHandler(SubmitItemUpdateResult_t param, bool bIOFailure)
	{
		if (param.m_eResult == EResult.k_EResultOK)
		{
			this.OnUploadedItemEvent?.Invoke((ulong)currentPublishedFileId);
		}
		else
		{
			if (isNewItemCreated)
			{
				SteamUGC.DeleteItem(currentPublishedFileId);
			}
			this.OnNotUploadedItemEvent?.Invoke(param.m_eResult.ToString());
			if (!isNewItemCreated && (param.m_eResult == EResult.k_EResultFileNotFound || param.m_eResult == EResult.k_EResultInvalidParam))
			{
				this.OnNotUpgradedItemEvent?.Invoke(param.m_eResult.ToString());
			}
		}
		DeleteTempFolder();
		monoBehaviour.StopCoroutine(itemUpdateProcessCoroutine);
		isNewItemCreated = false;
	}

	private void DeleteTempFolder()
	{
		if (Directory.Exists(PathNames.WorkshopTemp))
		{
			Directory.Delete(PathNames.WorkshopTemp, recursive: true);
		}
	}

	private IEnumerator ItemUpdateProgress(UGCUpdateHandle_t updateHandle)
	{
		while (true)
		{
			ulong punBytesProcessed;
			ulong punBytesTotal;
			EItemUpdateStatus itemUpdateProgress = SteamUGC.GetItemUpdateProgress(updateHandle, out punBytesProcessed, out punBytesTotal);
			Debug.Log(itemUpdateProgress.ToString() + " = " + punBytesProcessed + " / " + punBytesTotal);
			this.OnUploadingItemEvent?.Invoke();
			yield return new WaitForSeconds(0.2f);
		}
	}
}
