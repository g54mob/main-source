using System;
using System.Collections.Generic;
using BrewGame.SaveSystem.Data;
using BrewGame.SaveSystem.Storage;

namespace BrewGame.SaveSystem.Core
{
	[Serializable]
	public class SaveSlotMetadata
	{
		public int slotIndex;

		public bool exists;

		public CloudSyncStatus cloudSyncStatus;

		public string displayName;

		public long lastSaveTimestamp;

		public float totalPlaytimeSeconds;

		public int dayNumber;

		public bool introPlayed;

		public string hostPlayerName;

		public float hostMoney;

		public int saveVersion;

		public string gameBuildVersion;

		public int totalBrewsMade;

		public int totalDiscoveries;

		public int legendaryBrewCount;

		public float bestBrewPrice;

		public int favoriteBrewCount;

		public int catalystsEncountered;

		public int completedQuestsCount;

		public int activeQuestsCount;

		public float globalReputation;

		public float crimeRate;

		public int barsOwned;

		public int employeesHired;

		public int stationsCount;

		public int vehiclesCount;

		public int totalSkillLevels;

		public int standSalesCount;

		public int barSalesCount;

		public int propertiesOwned;

		public List<string> knownPlayerSteamIds;

		public static SaveSlotMetadata CreateEmpty(int slotIndex)
		{
			return null;
		}

		public static SaveSlotMetadata FromSaveData(int slotIndex, SaveGameData data)
		{
			return null;
		}

		private static List<string> CollectKnownPlayerSteamIds(SaveGameData data)
		{
			return null;
		}

		public bool IsIncompatibleBuild()
		{
			return false;
		}

		public string GetLastPlayedString()
		{
			return null;
		}

		public string GetPlaytimeString()
		{
			return null;
		}

		public string GetSummaryString()
		{
			return null;
		}

		public string GetCloudSyncStatusString()
		{
			return null;
		}

		public string GetCloudSyncIcon()
		{
			return null;
		}
	}
}
