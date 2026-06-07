using System.IO;
using System.Text;
using Steamworks;
using UnityEngine;

public static class Steam
{
	private enum CloudSync
	{
		Idle = 0,
		ClientToServer = 1,
		ServerToClient = 2
	}

	private static bool Enabled = false;

	private static float Timer = 0f;

	private static bool UpdateStats = false;

	private static CloudSync CloudState = CloudSync.Idle;

	public static string UserID = string.Empty;

	private static Callback<RemoteStorageFileWriteAsyncComplete_t> CloudWriteAsyncComplete;

	private static Callback<GameOverlayActivated_t> GameOverlayActivated;

	private static Callback<UserStatsReceived_t> UserStatsReceived;

	private static Callback<UserAchievementStored_t> UserAchStored;

	private static int PrintCount = 0;

	public static void Init()
	{
		Enabled = !Commandline.IsSet("--nosteam");
		if (Enabled)
		{
			if (!IsAvailable() || !IsInitialized())
			{
				Enabled = false;
				return;
			}
			UserStatsReceived = Callback<UserStatsReceived_t>.Create(OnUserStatsReceived);
			UserAchStored = Callback<UserAchievementStored_t>.Create(OnUserAchStored);
			SteamUserStats.RequestCurrentStats();
			UserID = SteamUser.GetSteamID().ToString();
			Print("User ID: " + UserID);
		}
	}

	public static void Poll()
	{
		if (IsAvailable() && UpdateStats)
		{
			Timer += Time.unscaledDeltaTime;
			if (Timer > 5f)
			{
				Timer = 0f;
				UpdateStats = false;
				SteamUserStats.StoreStats();
			}
		}
	}

	private static bool IsValidAppID(AppId_t appID)
	{
		return appID == SteamUtils.GetAppID();
	}

	public static bool IsAvailable()
	{
		return Enabled;
	}

	public static void ActivateGameOverlayToWebPage(string url)
	{
		SteamFriends.ActivateGameOverlayToWebPage(url);
	}

	public static bool IsInitialized()
	{
		return SteamManager.Initialized;
	}

	public static void ForceShutdown()
	{
		if (SteamManager.Initialized)
		{
			SteamManager.Instance.m_bInitialized = false;
			SteamAPI.Shutdown();
		}
	}

	public static bool IsValidUserID()
	{
		return UserID.Length > 0;
	}

	public static void Print(string text)
	{
		IsAvailable();
	}

	public static string GetUserID()
	{
		return UserID;
	}

	public static string GetValidSaveName(string name)
	{
		return name + "_" + GetUserID();
	}

	public static bool IsCloudEnabled()
	{
		if (IsAvailable())
		{
			bool num = SteamRemoteStorage.IsCloudEnabledForApp();
			bool flag = SteamRemoteStorage.IsCloudEnabledForAccount();
			return num && flag;
		}
		return false;
	}

	public static void SetCloudEnabled(bool state)
	{
		if (IsAvailable())
		{
			SteamRemoteStorage.SetCloudEnabledForApp(state);
		}
	}

	public static int GetNumSavesInCloud()
	{
		if (IsAvailable())
		{
			return SteamRemoteStorage.GetFileCount();
		}
		return 0;
	}

	public static bool HasCloudSaves()
	{
		return GetNumSavesInCloud() > 0;
	}

	public static bool SaveToCloud(string name, string json, Encoding encoding, bool dumpBytes = false)
	{
		if (CloudState == CloudSync.Idle)
		{
			byte[] bytes = LZF.Compress(encoding.GetBytes(json.ToCharArray()));
			return SaveToCloud(name, bytes, dumpBytes);
		}
		return false;
	}

	public static bool SaveToCloud(string name, byte[] bytes, bool dumpBytes = false)
	{
		if (dumpBytes)
		{
			int num = Application.dataPath.LastIndexOf('/');
			string text = Application.dataPath.Substring(0, num + 1) + name;
			File.WriteAllBytes(text, bytes);
			Print("SAVEGAME dumped to: " + text);
		}
		if (IsCloudEnabled() && CloudState == CloudSync.Idle)
		{
			CloudState = CloudSync.ClientToServer;
			name = GetValidSaveName(name);
			if (SteamRemoteStorage.FileWrite(name, bytes, bytes.Length))
			{
				Print("Written save to cloud: " + name);
				CloudState = CloudSync.Idle;
				return true;
			}
			Print("Failed writing save: " + name);
		}
		CloudState = CloudSync.Idle;
		return false;
	}

	public static string LoadFromCloud(string name, Encoding encoding)
	{
		if (IsCloudEnabled() && CloudState == CloudSync.Idle)
		{
			CloudState = CloudSync.ServerToClient;
			name = GetValidSaveName(name);
			int fileSize = SteamRemoteStorage.GetFileSize(name);
			if (fileSize > 0)
			{
				byte[] array = new byte[fileSize];
				if (SteamRemoteStorage.FileRead(name, array, fileSize) != 0)
				{
					Print("Compressed cloud save loaded OK: " + name);
					CloudState = CloudSync.Idle;
					byte[] bytes = LZF.Decompress(array);
					return encoding.GetString(bytes);
				}
				Print("Failed reading from cloud: " + name);
			}
			else
			{
				Print("Failed reading from cloud. \"" + name + "\" save doesn't exist!");
			}
		}
		CloudState = CloudSync.Idle;
		return string.Empty;
	}

	public static bool DeleteCloudSave(string name, bool resolveName, bool cloudOnly = false)
	{
		if (IsCloudEnabled())
		{
			string pchFile = (resolveName ? GetValidSaveName(name) : name);
			bool num = (cloudOnly ? SteamRemoteStorage.FileForget(pchFile) : SteamRemoteStorage.FileDelete(pchFile));
			if (num)
			{
				Print("Successfully deleted save: " + name);
			}
			return num;
		}
		return false;
	}

	public static bool DeleteAllCloudSaves(string nameTemplate, bool cloudOnly = false)
	{
		bool result = true;
		for (int i = 0; i <= 100; i++)
		{
			if (!DeleteCloudSave(GetValidSaveName(nameTemplate + i), cloudOnly))
			{
				result = false;
			}
		}
		if (!DeleteCloudSave(GetValidSaveName("WTL_saves_global"), cloudOnly))
		{
			result = false;
		}
		return result;
	}

	public static bool UnlockAchievement(string name)
	{
		AchivementData achivementDataByKeyName = Logic.GetAchivementDataByKeyName(name);
		if (achivementDataByKeyName == null)
		{
			return false;
		}
		if (achivementDataByKeyName.Locked)
		{
			return false;
		}
		if (IsAvailable() && IsInitialized())
		{
			bool pbAchieved = false;
			SteamUserStats.GetAchievement(name, out pbAchieved);
			if (!pbAchieved)
			{
				UpdateStats = true;
				SteamUserStats.SetAchievement(name);
			}
		}
		if (Logic.GetModel().globalSaves.gainedAchivements.Contains(name))
		{
			return false;
		}
		Logic.GetModel().globalSaves.gainedAchivements.Add(name);
		return true;
	}

	private static void onReportProgressComplete(bool success)
	{
	}

	private static void OnUserStatsReceived(UserStatsReceived_t p)
	{
		Print("UserStats updated with: " + p.m_eResult.ToString() + "; User ID: " + p.m_steamIDUser.ToString());
	}

	private static void OnUserAchStored(UserAchievementStored_t p)
	{
		Print("Achievement unlocked: " + p.m_rgchAchievementName);
	}
}
