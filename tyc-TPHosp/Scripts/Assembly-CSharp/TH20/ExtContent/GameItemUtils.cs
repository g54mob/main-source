using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TH20.ExtContent
{
	public static class GameItemUtils
	{
		public static bool ScanFoldersForGameItems(EContentSourceType contentSource, string folderSpec, ref List<GameItemBase> targetGameItemsList)
		{
			bool flag = false;
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Scanning for '{0}' game items within folder '{1}' ..."), contentSource.ToString(), folderSpec));
			if (targetGameItemsList == null)
			{
				targetGameItemsList = new List<GameItemBase>();
			}
			flag = ScanFoldersForGameItemsRecurse(contentSource, folderSpec, ref targetGameItemsList);
			ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Scanning found {0} game items within folder '{1}'. Errors encountered: {2}"), targetGameItemsList.Count, folderSpec, flag ? "N" : "Y"));
			return flag;
		}

		private static bool ScanFoldersForGameItemsRecurse(EContentSourceType contentSource, string folderSpec, ref List<GameItemBase> targetGameItemsList)
		{
			bool result = false;
			if (Directory.Exists(folderSpec))
			{
				if (!File.Exists(GameItemMetaData.GetMetaDataFileSpec(folderSpec)))
				{
					result = true;
					string[] directories = Directory.GetDirectories(folderSpec);
					if (directories.Length != 0)
					{
						int i = 0;
						for (int num = directories.Length; i < num; i++)
						{
							string pathSpec = ExtContentUtils.GetPathSpec(folderSpec, directories[i]);
							if (!ScanFoldersForGameItemsRecurse(contentSource, pathSpec, ref targetGameItemsList))
							{
								result = false;
							}
						}
					}
				}
				else
				{
					GameItemBase gameItemBase = GameItemFactory.CreateFolderGameItem(contentSource, folderSpec);
					if (gameItemBase != null)
					{
						result = true;
						targetGameItemsList.Add(gameItemBase);
					}
				}
			}
			return result;
		}

		public static bool ScanFoldersForGameItemMetaDataFileFolderSpecs(string folderSpec, ref List<string> targetGameItemMetaDataFileSpecs)
		{
			return ExtContentUtils.ScanFoldersForFileSpecFolders(folderSpec, "GameItemMetaData.json", ref targetGameItemMetaDataFileSpecs);
		}

		public static bool ScanFoldersForGameItemMetaData(string folderSpec, ref List<GameItemMetaData> retGameItemsMetaData)
		{
			bool result = false;
			List<string> targetGameItemMetaDataFileSpecs = null;
			if (ScanFoldersForGameItemMetaDataFileFolderSpecs(folderSpec, ref targetGameItemMetaDataFileSpecs))
			{
				result = true;
				if (retGameItemsMetaData == null)
				{
					retGameItemsMetaData = new List<GameItemMetaData>();
				}
				foreach (string item in targetGameItemMetaDataFileSpecs)
				{
					GameItemMetaData gameItemMetaData = new GameItemMetaData(item);
					if (gameItemMetaData.ReadMetaDataFile())
					{
						retGameItemsMetaData.Add(gameItemMetaData);
					}
					else
					{
						result = false;
					}
				}
			}
			return result;
		}

		public static GameItemBase SortMostRecent(List<GameItemBase> gameItems)
		{
			GameItemBase result = null;
			if (gameItems.Count > 1)
			{
				gameItems.Sort(delegate(GameItemBase item1, GameItemBase item2)
				{
					long lastUpdatedTimeStamp = item1.LastUpdatedTimeStamp;
					long lastUpdatedTimeStamp2 = item2.LastUpdatedTimeStamp;
					if (lastUpdatedTimeStamp < lastUpdatedTimeStamp2)
					{
						return 1;
					}
					return (lastUpdatedTimeStamp > lastUpdatedTimeStamp2) ? (-1) : 0;
				});
				result = gameItems[0];
			}
			else if (gameItems.Count == 1)
			{
				result = gameItems[0];
			}
			return result;
		}

		public static GameItemMetaData LoadGameItemMetaData(string metaDataFolderSpec)
		{
			GameItemMetaData result = null;
			GameItemMetaData gameItemMetaData = new GameItemMetaData(metaDataFolderSpec);
			if (gameItemMetaData.DoesMetaDataFileExist() && gameItemMetaData.ReadMetaDataFile())
			{
				result = gameItemMetaData;
			}
			return result;
		}

		public static bool GetGameItemMetaDataContentType(GameItemMetaData metaData, ref EContentType retContentType)
		{
			string retContentSubType = string.Empty;
			return GetGameItemMetaDataContentTypes(metaData, ref retContentType, ref retContentSubType);
		}

		public static bool GetGameItemMetaDataContentTypes(GameItemMetaData metaData, ref EContentType retContentType, ref string retContentSubType)
		{
			bool result = false;
			retContentType = EContentType.None;
			retContentSubType = string.Empty;
			if (metaData != null)
			{
				string value = string.Empty;
				string value2 = string.Empty;
				if (metaData.Get("ContentType", ref value))
				{
					metaData.Get("SubTypeID", ref value2);
					EContentType eContentType = ExtContentType.StringToContentType(value);
					if (ExtContentType.IsValid(eContentType))
					{
						result = true;
						retContentType = eContentType;
						if (value2.ToLower() != value.ToLower())
						{
							retContentSubType = value2;
						}
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.InvalidGameItemMetaDataContentType), ExtContentType.ContentTypeToString(eContentType)));
					}
				}
			}
			return result;
		}

		public static string GetGameItemInstalledFolderGUID(EContentSourceType contentSourceType, string installedPathSpec)
		{
			return $"{ExtContentSourceType.GetContentSourceTypePrefix(contentSourceType, bWithDelemiter: true)}{SystemInfo.deviceUniqueIdentifier}-{WorkshopUtils.GetAppIdStr()}-{ExtContentUtils.GetPathSpecHash(installedPathSpec)}";
		}
	}
}
