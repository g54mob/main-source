using System.Collections.Generic;

namespace TH20.ExtContent
{
	public class ExtContentSourceBase
	{
		public delegate void OnGameItemCreatedCallback(GameItemBase gameItemBase);

		public delegate void OnGameItemUpdatedCallback(GameItemBase gameItemBase);

		public delegate void OnGameItemDeletedCallback(GameItemBase gameItemBase);

		public event OnGameItemUpdatedCallback OnGameItemCreated;

		public event OnGameItemUpdatedCallback OnGameItemUpdated;

		public event OnGameItemDeletedCallback OnGameItemDeleted;

		public virtual List<GameItemBase> GetAllGameItems(EContentType contentType = EContentType.None)
		{
			return null;
		}

		public virtual List<GameItemBase> GetAllGameItemsSorted(EContentType contentType = EContentType.None)
		{
			List<GameItemBase> allGameItems = GetAllGameItems(contentType);
			GameItemUtils.SortMostRecent(allGameItems);
			return allGameItems;
		}

		public virtual List<GameItemBase> GetAllGameItemsRef()
		{
			return null;
		}

		public virtual GameItemBase FindGameItemByTitle(string gameItemTitle, bool bSilent = false)
		{
			gameItemTitle = gameItemTitle.ToLower();
			GameItemBase gameItemBase = GetAllGameItemsRef().Find((GameItemBase item) => item.Title.ToLower() == gameItemTitle);
			if (gameItemBase == null && !bSilent)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FailedToFindGameItemByTitle), GetContentSourceIdentifier(), gameItemTitle));
			}
			return gameItemBase;
		}

		public virtual GameItemBase FindGameItemByInstalledPath(string gameItemInstallPath, bool bSilent = false)
		{
			uint searchHash = ExtContentUtils.GetPathSpecHash2(gameItemInstallPath);
			GameItemBase gameItemBase = GetAllGameItemsRef().Find((GameItemBase item) => item.InstalledFolderPathSpecHash == searchHash);
			if (gameItemBase == null && !bSilent)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FailedToFindGameItemByInstalledPath), GetContentSourceIdentifier(), gameItemInstallPath));
			}
			return gameItemBase;
		}

		public virtual GameItemBase FindGameItemByID(string gameItemContentID, bool bSilent = false)
		{
			GameItemBase gameItemBase = GetAllGameItemsRef().Find((GameItemBase item) => item.ContentID == gameItemContentID);
			if (gameItemBase == null && !bSilent)
			{
				ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.FailedToFindGameItemByID), GetContentSourceIdentifier(), gameItemContentID));
			}
			return gameItemBase;
		}

		public virtual GameItemBase FindGameItem(EGameItemIDType gameItemIDType, string itemID, bool bSilent = false)
		{
			GameItemBase result = null;
			switch (gameItemIDType)
			{
			case EGameItemIDType.Name:
				result = FindGameItemByTitle(itemID, bSilent);
				break;
			case EGameItemIDType.Path:
				result = FindGameItemByInstalledPath(itemID, bSilent);
				break;
			case EGameItemIDType.ID:
				result = FindGameItemByID(itemID, bSilent);
				break;
			}
			return result;
		}

		public static EGameItemIDType StringToGameItemIDType(string gameItemIDTypeStr)
		{
			EGameItemIDType result = EGameItemIDType.Name;
			gameItemIDTypeStr = gameItemIDTypeStr.ToLower();
			int i = 0;
			for (int num = 3; i < num; i++)
			{
				EGameItemIDType eGameItemIDType = (EGameItemIDType)i;
				if (eGameItemIDType.ToString().ToLower() == gameItemIDTypeStr)
				{
					result = eGameItemIDType;
					break;
				}
			}
			return result;
		}

		public virtual List<ExtContentBundleInfo> GetBundleInfoList()
		{
			List<ExtContentBundleInfo> list = new List<ExtContentBundleInfo>();
			foreach (GameItemBase allGameItem in GetAllGameItems())
			{
				if (allGameItem.IsWithinBundle())
				{
					string bundleName = string.Empty;
					string bundlePublishedFileId = string.Empty;
					allGameItem.GetBundleInfo(ref bundleName, ref bundlePublishedFileId);
					int num = list.FindIndex((ExtContentBundleInfo item) => item._bundlePublishedFileId == bundlePublishedFileId);
					if (num < 0)
					{
						list.Add(new ExtContentBundleInfo(bundleName, bundlePublishedFileId));
						num = list.Count - 1;
					}
					list[num]._bunldeGameItems.AddUnique(allGameItem);
				}
			}
			return list;
		}

		public virtual bool IsCurrentlyUsingOnlineServices()
		{
			return false;
		}

		public virtual string GetContentSourceIdentifier()
		{
			return string.Empty;
		}

		public virtual string GetCommonPathSearchFolder()
		{
			return string.Empty;
		}

		public virtual string GetGameItemSourceSpecificLogInfoString(GameItemBase gameItem)
		{
			return string.Empty;
		}

		public void InvokeOnGameItemCreated(GameItemBase gameItem)
		{
			if (this.OnGameItemCreated != null)
			{
				this.OnGameItemCreated(gameItem);
			}
		}

		public void InvokeOnGameItemUpdated(GameItemBase gameItem)
		{
			if (this.OnGameItemUpdated != null)
			{
				this.OnGameItemUpdated(gameItem);
			}
		}

		public void InvokeOnGameItemDeleted(GameItemBase gameItem)
		{
			if (this.OnGameItemDeleted != null)
			{
				this.OnGameItemDeleted(gameItem);
			}
		}

		public virtual bool ReloadAllGameItemDataAssets(EContentType contentType = EContentType.None)
		{
			bool result = true;
			foreach (GameItemBase allGameItem in GetAllGameItems(contentType))
			{
				GameItemDataBase gameItemDataBase = allGameItem.GetGameItemDataBase();
				if (gameItemDataBase != null && gameItemDataBase.HaveAssetsBeenLoaded() && !gameItemDataBase.ReloadAllAssets())
				{
					result = false;
				}
			}
			return result;
		}

		public virtual bool UnloadAllGameItemDataAssets(EContentType contentType = EContentType.None)
		{
			foreach (GameItemBase allGameItem in GetAllGameItems(contentType))
			{
				allGameItem.GetGameItemDataBase()?.UnloadAllAssets();
			}
			return true;
		}

		public GameItemLog GenerateGameItemsLog(EContentType contentType = EContentType.None)
		{
			GameItemLog gameItemLog = new GameItemLog(contentType);
			List<GameItemBase> allGameItemsSorted = GetAllGameItemsSorted(contentType);
			List<string> list = new List<string>();
			List<string> logInstallPathSpecs = new List<string>();
			List<string> list2 = new List<string>();
			string contentSourceIdentifier = GetContentSourceIdentifier();
			int i = 0;
			for (int count = allGameItemsSorted.Count; i < count; i++)
			{
				string item = string.Format(ExtContentUtils.HiliteParams("{0} Game Item:{1:00}/{2:00}:"), contentSourceIdentifier, i, count) + allGameItemsSorted[i].GetLogInfoString();
				list.Add(item);
				logInstallPathSpecs.Add(allGameItemsSorted[i].InstalledFolderPathSpec);
				list2.Add(GetGameItemSourceSpecificLogInfoString(allGameItemsSorted[i]));
			}
			string arg = ExtContentUtils.ExtractCommonRootPathFromSpecs(ref logInstallPathSpecs, GetCommonPathSearchFolder());
			gameItemLog._logHeader = string.Format(ExtContentUtils.HiliteParams("{0}: {1} Game Items: (RootInstallPath: '{2}')"), contentSourceIdentifier, allGameItemsSorted.Count, arg);
			int j = 0;
			for (int count2 = list.Count; j < count2; j++)
			{
				string text = string.Format(ExtContentUtils.HiliteParams("I:'{0}'"), logInstallPathSpecs[j]);
				string text2 = list[j] + ", " + text;
				if (!list2[j].IsNullOrEmpty())
				{
					text2 = text2 + ", " + list2[j];
				}
				GameItemLogItem item2 = new GameItemLogItem(allGameItemsSorted[j], text2);
				gameItemLog._logItems.Add(item2);
			}
			return gameItemLog;
		}

		public static void LogGameItemsLog(GameItemLog gameItemLog, bool bSort = false, bool bShowHeader = true)
		{
			if (gameItemLog == null)
			{
				return;
			}
			if (bShowHeader)
			{
				ExtContentMessages.LogDebug(gameItemLog._logHeader);
			}
			if (bSort && gameItemLog._logItems.Count > 1)
			{
				gameItemLog._logItems.Sort(delegate(GameItemLogItem item1, GameItemLogItem item2)
				{
					long lastUpdatedTimeStamp = item1._gameItemBase.LastUpdatedTimeStamp;
					long lastUpdatedTimeStamp2 = item2._gameItemBase.LastUpdatedTimeStamp;
					if (lastUpdatedTimeStamp < lastUpdatedTimeStamp2)
					{
						return 1;
					}
					return (lastUpdatedTimeStamp > lastUpdatedTimeStamp2) ? (-1) : 0;
				});
			}
			int num = 0;
			for (int count = gameItemLog._logItems.Count; num < count; num++)
			{
				ExtContentMessages.LogDebug(gameItemLog._logItems[num]._logStr);
			}
		}

		public void LogGameItems(EContentType contentType = EContentType.None, bool bSort = false, bool bShowHeader = true)
		{
			LogGameItemsLog(GenerateGameItemsLog(contentType), bSort, bShowHeader);
		}
	}
}
