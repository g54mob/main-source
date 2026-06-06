using System;
using System.IO;
using M4.Encoding;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace M4.Session
{
	public class SteamUser : IUser
	{
		private const string STAT_SessionCount = "session_count";

		private string _persistentDataPath = Path.GetFullPath(Application.persistentDataPath);

		private IUserEventHandler eventHandler;

		private Callback<UserStatsReceived_t> callback_UserStatsReceived;

		private Callback<UserStatsStored_t> callback_UserStatsStored;

		private Callback<UserAchievementStored_t> callback_UserAchievementStored;

		private Callback<RemoteStorageFileWriteAsyncComplete_t> callback_RemoteStorageFileWriteAsyncComplete;

		private CSteamID steamID;

		public string SaveFilePath { get; private set; }

		public int Id => -1;

		public string Name => "Steam User";

		public void RequestSignIn()
		{
			throw new NotImplementedException();
		}

		public void Initialize(IUserEventHandler event_handler)
		{
			eventHandler = event_handler;
			callback_UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
			callback_UserStatsStored = Callback<UserStatsStored_t>.Create(OnUserStatsStored);
			callback_UserAchievementStored = Callback<UserAchievementStored_t>.Create(OnUserAchievementStored);
			if (SteamManager.Initialized)
			{
				steamID = Steamworks.SteamUser.GetSteamID();
				SteamUserStats.RequestCurrentStats();
			}
			else
			{
				Debug.LogError("Unable to request Steam user stats, SteamManager not initialized");
			}
		}

		public void ProcessGameEvent(IRun run, GameEvent game_event)
		{
			throw new NotImplementedException();
		}

		public void LoadPlayerRuns(PlayerProfile profile, UnityAction result_callback)
		{
			if (SteamManager.Initialized)
			{
				int fileCount = SteamRemoteStorage.GetFileCount();
				while (0 < fileCount--)
				{
					int pnFileSizeInBytes;
					string fileNameAndSize = SteamRemoteStorage.GetFileNameAndSize(fileCount, out pnFileSizeInBytes);
					byte[] array = new byte[pnFileSizeInBytes];
					if (SteamRemoteStorage.FileRead(fileNameAndSize, array, pnFileSizeInBytes) != 0)
					{
						string fullPath = Path.GetFullPath(SaveInfo.PLAYER_SAVES_DIRECTORY + Path.ChangeExtension(fileNameAndSize, ".fs"));
						if (File.Exists(fullPath))
						{
							Debug.LogException(new Exception("Unable to migrate '" + fileNameAndSize + "' to '" + fullPath + "' - File already exists."));
						}
						else
						{
							DefaultUser.DefaultSaveFile(fullPath, array);
							Debug.Log("'" + fileNameAndSize + "' was migarted to '" + fullPath + "' - succes");
						}
						if (!SteamRemoteStorage.FileDelete(fileNameAndSize))
						{
							Debug.LogException(new Exception("Unable to delete migrate file '" + fileNameAndSize + "'"));
						}
						else
						{
							Debug.Log("Deleted migrated file '" + fileNameAndSize + "'");
						}
					}
					else
					{
						Debug.LogException(new Exception("Unable to migrate '" + fileNameAndSize + "' - file could not be loaded"));
					}
				}
			}
			DefaultUser.DefaultLoadPlayerRuns(profile, result_callback);
		}

		public void LoadFile(string path, UnityAction<StorageActionResult> result_callback)
		{
			if (SteamManager.Initialized)
			{
				path = path.ToLower();
				if (SteamRemoteStorage.FileExists(path))
				{
					int fileSize = SteamRemoteStorage.GetFileSize(path);
					byte[] array = new byte[fileSize];
					if (SteamRemoteStorage.FileRead(path, array, fileSize) != 0)
					{
						result_callback(new StorageActionResult(path, succes: true, array));
						return;
					}
				}
			}
			if (File.Exists(path))
			{
				result_callback(new StorageActionResult(path, succes: true, File.ReadAllBytes(path)));
			}
			else
			{
				result_callback(new StorageActionResult(path, succes: false));
			}
		}

		public void SaveFile(string filename, byte[] data, UnityAction<StorageActionResult> result_callback)
		{
			if (Path.IsPathRooted(filename))
			{
				DefaultUser.DefaultSaveFile(filename, data, result_callback);
			}
			else
			{
				result_callback(new StorageActionResult(filename, succes: false));
			}
		}

		public void RemoveFile(string filename, UnityAction<StorageActionResult> result_callback)
		{
			if (SteamManager.Initialized && SteamRemoteStorage.FileExists(filename))
			{
				result_callback?.Invoke(new StorageActionResult(filename, SteamRemoteStorage.FileDelete(filename)));
			}
			else if (File.Exists(filename))
			{
				File.Delete(filename);
				result_callback?.Invoke(new StorageActionResult(filename, succes: true));
			}
			else
			{
				result_callback?.Invoke(new StorageActionResult(filename, succes: false));
			}
		}

		public void SaveJSON(string filename, string json, UnityAction<StorageActionResult> result_callback)
		{
			SaveFile(filename, NoEncoding.GetBytes(json), result_callback);
		}

		public bool IsAchievementUnlocked(AchievementId achievement_id)
		{
			string text = $"_ACH_{achievement_id}";
			if (SteamUserStats.GetAchievement($"_ACH_{achievement_id}", out var pbAchieved))
			{
				return pbAchieved;
			}
			Debug.LogException(new Exception("[SteamUser] Unable to get status on achievement: " + text));
			return false;
		}

		public void UnlockAchievement(AchievementBase achievement)
		{
			if (SteamUserStats.SetAchievement($"_ACH_{achievement.Id}"))
			{
				StoreStats();
			}
			else
			{
				Debug.LogException(new Exception($"Unable to unlock achievement: {achievement}"));
			}
		}

		public bool OwnsDLC(PlatformId id)
		{
			return SteamApps.BIsSubscribedApp(new AppId_t(id.SteamID));
		}

		public bool IsEarlyAccesOwner()
		{
			DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(SteamApps.GetEarliestPurchaseUnixTime(PlatformSteam.APP_ID));
			Debug.Log($"Purchase date {dateTimeOffset} <= release date {Session.RELEASE_DATE} : [{dateTimeOffset <= Session.RELEASE_DATE}]");
			return dateTimeOffset <= Session.RELEASE_DATE;
		}

		public void ClearProfile()
		{
			StoreStats();
			if (!SteamUserStats.ResetAllStats(bAchievementsToo: true))
			{
				Debug.Log("Unable to reset all stats and achievements");
			}
		}

		public void Dispose()
		{
		}

		private void IncrementStat(string name, int increment)
		{
			if (SteamUserStats.GetStat(name, out int pData))
			{
				if (!SteamUserStats.SetStat(name, pData + increment))
				{
					Debug.LogWarning("Unable to SetStat: " + name);
					return;
				}
				Debug.Log("Incremented " + name + " : " + pData + " -> " + (pData + increment));
			}
		}

		private void IncrementStat(string name, float increment)
		{
			if (SteamUserStats.GetStat(name, out float pData) && !SteamUserStats.SetStat(name, pData + increment))
			{
				Debug.LogWarning("Unable to SetStat: " + name);
			}
		}

		private void SetAchievement(string achievement_id)
		{
			if (!SteamUserStats.SetAchievement(achievement_id))
			{
				Debug.Log("Unable to set achievement: " + achievement_id);
			}
		}

		private void OnUserStatsReceived(UserStatsReceived_t result)
		{
			if (result.m_nGameID == 821250)
			{
				callback_UserStatsReceived = null;
				if (result.m_eResult != EResult.k_EResultOK)
				{
					Debug.LogErrorFormat("[STEAM] RequestCurrentStats failed with result '{0}'!", result.m_eResult);
				}
				eventHandler.OnUserEvent(this, UserEventType.INITIALIZATION_COMPLETE);
				IncrementStat("session_count", 1);
			}
		}

		private void StoreStats()
		{
			if (!SteamUserStats.StoreStats())
			{
				Debug.LogWarning("Unable to StoreStats!");
			}
		}

		private void OnUserStatsStored(UserStatsStored_t result)
		{
			if (result.m_nGameID == 821250)
			{
				if (result.m_eResult == EResult.k_EResultOK)
				{
					Debug.Log("Stored stats for steam");
				}
				else
				{
					Debug.Log("Failed to store stats for steam: " + result.m_eResult);
				}
			}
		}

		private void OnUserAchievementStored(UserAchievementStored_t result)
		{
			if (result.m_nGameID == 821250)
			{
				Debug.Log("Achievement '" + result.m_rgchAchievementName + "' was stored on steam!");
			}
		}

		private void OnRemoveFileResult(StorageActionResult result)
		{
			if (!result.Succes)
			{
				Debug.LogException(new Exception("Unable to remove '" + result.Filename + "'"));
			}
		}
	}
}
