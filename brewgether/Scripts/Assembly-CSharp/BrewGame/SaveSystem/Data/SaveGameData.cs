using System;
using BrewGame.SaveSystem.Serialization;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class SaveGameData
	{
		public int saveVersion;

		public long saveTimestamp;

		public string checksum;

		public bool introPlayed;

		public float totalPlaytimeSeconds;

		public string saveName;

		public string gameBuildVersion;

		public PlayerSaveData hostPlayerData;

		public SerializableDictionary<string, PlayerSaveData> clientPlayerData;

		public WorldSaveData worldData;

		public ManagerSaveData managerData;

		public ItemMetadataSaveData itemMetadata;

		public SerializableDictionary<string, SerializableDictionary<string, object>> componentStates;

		public static SaveGameData CreateNew(string hostSteamId, string hostPlayerName)
		{
			return null;
		}

		public void UpdateTimestamp()
		{
		}

		public PlayerSaveData GetOrCreateClientData(string steamId, string playerName)
		{
			return null;
		}

		public PlayerSaveData GetPlayerData(string steamId)
		{
			return null;
		}

		public string GetDisplayName()
		{
			return null;
		}

		public string GetLastPlayedString()
		{
			return null;
		}

		public string GetPlaytimeString()
		{
			return null;
		}
	}
}
