using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;

namespace HeathenEngineering.SteamworksIntegration
{
	public struct WorkshopItemData
	{
		public PublishedFileId_t? publishedFileId;

		public AppData appId;

		public string title;

		public string description;

		public DirectoryInfo content;

		public FileInfo preview;

		public string metadata;

		public string[] tags;

		public ERemoteStoragePublishedFileVisibility visibility;

		public bool IsValid
		{
			get
			{
				if (appId != AppId_t.Invalid && !string.IsNullOrEmpty(title) && title.Length < 129 && !string.IsNullOrEmpty(description) && description.Length < 8000 && (string.IsNullOrEmpty(metadata) || metadata.Length < 5000) && preview != null && content != null && preview.Exists && content.Exists)
				{
					return !tags.Any((string p) => p.Length > 255);
				}
				return false;
			}
		}

		public bool Create(Action<WorkshopItemDataCreateStatus> completedCallback = null, Action<UGCUpdateHandle_t> uploadStartedCallback = null, Action<CreateItemResult_t> fileCreatedCallback = null)
		{
			return UserGeneratedContent.Client.CreateItem(this, null, null, null, completedCallback, uploadStartedCallback, fileCreatedCallback);
		}

		public bool Create(WorkshopItemPreviewFile[] additionalPreviews, string[] additionalYouTubeIds, WorkshopItemKeyValueTag[] additionalKeyValueTags, Action<WorkshopItemDataCreateStatus> completedCallback = null, Action<UGCUpdateHandle_t> uploadStartedCallback = null, Action<CreateItemResult_t> fileCreatedCallback = null)
		{
			return UserGeneratedContent.Client.CreateItem(this, additionalPreviews, additionalYouTubeIds, additionalKeyValueTags, completedCallback, uploadStartedCallback, fileCreatedCallback);
		}

		public bool Update(Action<WorkshopItemDataUpdateStatus> completedCallback = null, Action<UGCUpdateHandle_t> uploadStartedCallback = null)
		{
			return UserGeneratedContent.Client.UpdateItem(this, null, null, null, completedCallback, uploadStartedCallback);
		}

		public bool Update(WorkshopItemPreviewFile[] additionalPreviews, string[] additionalYouTubeIds, WorkshopItemKeyValueTag[] additionalKeyValueTags, Action<WorkshopItemDataUpdateStatus> completedCallback = null, Action<UGCUpdateHandle_t> uploadStartedCallback = null)
		{
			return UserGeneratedContent.Client.UpdateItem(this, additionalPreviews, additionalYouTubeIds, additionalKeyValueTags, completedCallback, uploadStartedCallback);
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

		public static void GetSubscribed(bool withLongDescription, bool withMetadata, bool withKeyValueTags, bool withAdditionalPreviews, uint withPlayTimeStatsInDays, Action<List<WorkshopItem>> callback)
		{
			UserGeneratedContent.Client.GetSubscribedItems(withLongDescription, withMetadata, withKeyValueTags, withAdditionalPreviews, withPlayTimeStatsInDays, callback);
		}
	}
}
