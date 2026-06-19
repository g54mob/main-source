using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using FullInspector;
using MessagePack;
using TH20.ExtContent;

namespace TH20
{
	[MessagePackObject(false)]
	public class SaveFileHeader
	{
		[Key(0)]
		public DateTime Date;

		[Key(1)]
		public string Name;

		[Key(2)]
		public VersionNumber Version;

		[Key(3)]
		public string LevelID;

		[Key(4)]
		public byte[] ThumbnailPNG;

		[Key(5)]
		public int Balance;

		[Key(6)]
		public float Reputation;

		[Key(7)]
		public int HospitalLevel;

		[Key(8)]
		public float HospitalLevelProgress;

		[Key(9)]
		public int HospitalValue;

		[Key(10)]
		public List<uint> UsedDLCAppIDs;

		[Key(11)]
		public List<string> UsedWorkshopItemPublishedFileIds;

		[Key(12)]
		public List<string> UsedWorkshopItemNames;

		[Key(13)]
		public List<string> UsedLocalUGCItemIDs;

		[Key(14)]
		public List<string> UsedLocalUGCItemNames;

		[IgnoreMember]
		private string _filePath;

		[IgnoreMember]
		private string _fileName;

		[IgnoreMember]
		private string _displayName;

		private static readonly Regex AutosavePathAllBracketsRegex = new Regex("(( \\(\\d+\\))+)$");

		private static readonly Regex AutosavePathLastBracketsAndExtensionRegex = new Regex("( \\(\\d+\\))\\.sav$");

		[IgnoreMember]
		public bool IsBroken { get; private set; }

		[IgnoreMember]
		public string FilePath => _filePath;

		[IgnoreMember]
		public string FileName => _fileName;

		public SaveFileHeader()
		{
		}

		public SaveFileHeader(SaveData saveData, string name)
		{
			Name = name;
			Date = DateTime.UtcNow;
			Version = GameVersionNumber.Version;
			LevelID = saveData.Level.UniqueID;
			Balance = saveData.Level.FinanceManager.Balance;
			Reputation = saveData.Level.ReputationTracker.OverallReputation;
			HospitalLevel = saveData.Level.PrestigeTracker.Level;
			HospitalLevelProgress = saveData.Level.PrestigeTracker.Progress;
			HospitalValue = saveData.Level.LevelStatsDatabase.HospitalValue;
			UsedDLCAppIDs = new List<uint>(GetUniqueDLCUsedInLevel(saveData.Level));
			HashSet<WorkshopItemMetaData> uniqueWorkshopItemsUsedInLevel = GetUniqueWorkshopItemsUsedInLevel(saveData.Level);
			UsedWorkshopItemPublishedFileIds = new List<string>(uniqueWorkshopItemsUsedInLevel.Count);
			UsedWorkshopItemNames = new List<string>(uniqueWorkshopItemsUsedInLevel.Count);
			foreach (WorkshopItemMetaData item in uniqueWorkshopItemsUsedInLevel)
			{
				UsedWorkshopItemPublishedFileIds.Add(item.PublishedFileId);
				UsedWorkshopItemNames.Add(item.Title);
			}
			HashSet<GameItemBase> uniqueLocalUGCUsedInLevel = GetUniqueLocalUGCUsedInLevel(saveData.Level);
			UsedLocalUGCItemIDs = new List<string>(uniqueLocalUGCUsedInLevel.Count);
			UsedLocalUGCItemNames = new List<string>(uniqueLocalUGCUsedInLevel.Count);
			foreach (GameItemBase item2 in uniqueLocalUGCUsedInLevel)
			{
				UsedLocalUGCItemIDs.Add(item2.ContentID);
				UsedLocalUGCItemNames.Add(item2.Title);
			}
			ThumbnailPNG = saveData.Level.TakeThumbnail();
		}

		private static HashSet<uint> GetUniqueDLCUsedInLevel(Level level)
		{
			HashSet<uint> hashSet = new HashSet<uint>();
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				SharedInstance<DLCItemDefinition> dlcPackRequired = allRoom.Definition.DlcPackRequired;
				if (dlcPackRequired != null)
				{
					hashSet.Add(dlcPackRequired.Instance.AppID);
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					SharedInstance<DLCItemDefinition> dlcPackRequired2 = item.Definition.DlcPackRequired;
					if (dlcPackRequired2 != null)
					{
						hashSet.Add(dlcPackRequired2.Instance.AppID);
					}
				}
			}
			return hashSet;
		}

		private static HashSet<WorkshopItemMetaData> GetUniqueWorkshopItemsUsedInLevel(Level level)
		{
			HashSet<WorkshopItemMetaData> hashSet = new HashSet<WorkshopItemMetaData>();
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (item.Definition is RoomItemDefinitionUGC roomItemDefinitionUGC && roomItemDefinitionUGC.ExtContentGameItem != null && roomItemDefinitionUGC.ExtContentGameItem.ContentSource == EContentSourceType.Workshop && roomItemDefinitionUGC.ExtContentGameItem.PublishedWorkshopMetaData != null && !string.IsNullOrEmpty(roomItemDefinitionUGC.ExtContentGameItem.PublishedWorkshopMetaData.PublishedFileId))
					{
						hashSet.Add(roomItemDefinitionUGC.ExtContentGameItem.PublishedWorkshopMetaData);
					}
				}
				if (allRoom.FloorPlanVisual.FloorVisualOverride is FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC)
				{
					GameItemBase gameItemBase = level.App.ExtContentManager.FindGameItemByContentID(floorVisualOverrideDefinitionUGC.ContentID);
					if (gameItemBase != null && gameItemBase.ContentSource == EContentSourceType.Workshop && gameItemBase.PublishedWorkshopMetaData != null && !string.IsNullOrEmpty(gameItemBase.PublishedWorkshopMetaData.PublishedFileId))
					{
						hashSet.Add(gameItemBase.PublishedWorkshopMetaData);
					}
				}
				if (allRoom.FloorPlanVisual.WallVisualOverride is WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC)
				{
					GameItemBase gameItemBase2 = level.App.ExtContentManager.FindGameItemByContentID(wallVisualOverrideDefinitionUGC.ContentID);
					if (gameItemBase2 != null && gameItemBase2.ContentSource == EContentSourceType.Workshop && gameItemBase2.PublishedWorkshopMetaData != null && !string.IsNullOrEmpty(gameItemBase2.PublishedWorkshopMetaData.PublishedFileId))
					{
						hashSet.Add(gameItemBase2.PublishedWorkshopMetaData);
					}
				}
			}
			return hashSet;
		}

		private static HashSet<GameItemBase> GetUniqueLocalUGCUsedInLevel(Level level)
		{
			HashSet<GameItemBase> hashSet = new HashSet<GameItemBase>();
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (item.Definition is RoomItemDefinitionUGC roomItemDefinitionUGC && roomItemDefinitionUGC.ExtContentGameItem != null && roomItemDefinitionUGC.ExtContentGameItem.ContentSource == EContentSourceType.LocalMods)
					{
						hashSet.Add(roomItemDefinitionUGC.ExtContentGameItem);
					}
				}
				if (allRoom.FloorPlanVisual.FloorVisualOverride is FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC)
				{
					GameItemBase gameItemBase = level.App.ExtContentManager.FindGameItemByContentID(floorVisualOverrideDefinitionUGC.ContentID);
					if (gameItemBase != null && gameItemBase.ContentSource == EContentSourceType.LocalMods)
					{
						hashSet.Add(gameItemBase);
					}
				}
				if (allRoom.FloorPlanVisual.WallVisualOverride is WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC)
				{
					GameItemBase gameItemBase2 = level.App.ExtContentManager.FindGameItemByContentID(wallVisualOverrideDefinitionUGC.ContentID);
					if (gameItemBase2 != null && gameItemBase2.ContentSource == EContentSourceType.LocalMods)
					{
						hashSet.Add(gameItemBase2);
					}
				}
			}
			return hashSet;
		}

		public SaveFileHeader(string filePath)
		{
			_filePath = filePath;
			IsBroken = true;
		}

		public SaveFileHeader(SaveFileHeaderV1 old)
		{
			Name = old.saveInfo.Name;
			Date = old.saveInfo.Date;
			Version = old.saveInfo.Version;
			LevelID = old.gameInfo.LevelID;
			ThumbnailPNG = old.gameInfo.ThumbnailPNG.Bytes;
			Balance = old.gameInfo.Balance;
			Reputation = old.gameInfo.Reputation;
			HospitalLevel = old.gameInfo.HospitalLevel;
			HospitalLevelProgress = old.gameInfo.HospitalLevelProgress;
			HospitalValue = old.gameInfo.HospitalValue;
		}

		public string GetDisplayName()
		{
			return _displayName;
		}

		private string CalculateDisplayName()
		{
			string text = Name;
			Match match = AutosavePathAllBracketsRegex.Match(text);
			if (match.Success)
			{
				text = text.Substring(0, match.Index);
			}
			Match match2 = AutosavePathAllBracketsRegex.Match(Path.GetFileNameWithoutExtension(FileName));
			if (match2.Success && match2.Groups.Count > 1)
			{
				return text + match2.Groups[1];
			}
			return text;
		}

		public string GetPathOfMainSaveIfExists()
		{
			Match match = AutosavePathLastBracketsAndExtensionRegex.Match(FilePath);
			if (match.Success)
			{
				return FilePath.Substring(0, match.Index) + ".sav";
			}
			return FilePath;
		}

		public void SetFilePath(string filePath, string fileName)
		{
			_filePath = filePath;
			_fileName = fileName;
			_displayName = CalculateDisplayName();
		}
	}
}
