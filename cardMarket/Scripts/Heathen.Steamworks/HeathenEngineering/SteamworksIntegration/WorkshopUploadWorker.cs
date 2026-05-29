using System;
using System.IO;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	public class WorkshopUploadWorker
	{
		private WorkshopItemData itemData;

		private UGCUpdateHandle_t? updateHandle;

		public PublishedFileId_t? FileId => itemData.publishedFileId;

		public AppData AppId => itemData.appId;

		public string Title => itemData.title;

		public string Description => itemData.description;

		public DirectoryInfo Content => itemData.content;

		public FileInfo Preview => itemData.preview;

		public string Metadata => itemData.metadata;

		public string[] Tags => itemData.tags;

		public ERemoteStoragePublishedFileVisibility Visibility => itemData.visibility;

		public event EventHandler<WorkshopItemDataCreateStatus> Completed;

		public event EventHandler<UGCUpdateHandle_t> UpdateStarted;

		public event EventHandler<CreateItemResult_t> FileCreated;

		public static WorkshopUploadWorker Get(WorkshopItemData data)
		{
			return new WorkshopUploadWorker
			{
				itemData = data
			};
		}

		public bool RunCreate()
		{
			if (itemData.IsValid)
			{
				return itemData.Create(CompletedHandler, UploadStartedHandler, FileCreatedHandler);
			}
			return false;
		}

		public bool RunCreate(WorkshopItemPreviewFile[] additionalPreviews, string[] additionalYouTubeIds, WorkshopItemKeyValueTag[] additionalKeyValueTags)
		{
			if (itemData.IsValid)
			{
				return itemData.Create(additionalPreviews, additionalYouTubeIds, additionalKeyValueTags, CompletedHandler, UploadStartedHandler, FileCreatedHandler);
			}
			return false;
		}

		public EItemUpdateStatus GetUpdateProgress(out float progress)
		{
			progress = 0f;
			if (updateHandle.HasValue)
			{
				return UserGeneratedContent.Client.GetItemUpdateProgress(updateHandle.Value, out progress);
			}
			return EItemUpdateStatus.k_EItemUpdateStatusInvalid;
		}

		private void CompletedHandler(WorkshopItemDataCreateStatus arg)
		{
			updateHandle = null;
			this.Completed?.Invoke(this, arg);
		}

		private void UploadStartedHandler(UGCUpdateHandle_t arg)
		{
			updateHandle = arg;
			this.UpdateStarted?.Invoke(this, arg);
		}

		private void FileCreatedHandler(CreateItemResult_t arg)
		{
			this.FileCreated?.Invoke(this, arg);
		}
	}
}
