using System.IO;
using System.Text;
using Steamworks;
using UnityEngine;
using V1;

namespace API
{
	public class Steam : IApi
	{
		public void API_Log()
		{
			if (!SteamManager.Initialized)
			{
				SteamAPI.Init();
			}
		}

		public void API_SendAchievement(AchievementDefinition achievement)
		{
			if (SteamManager.Initialized)
			{
				SteamUserStats.SetAchievement(achievement.SteamName);
				SteamUserStats.StoreStats();
			}
		}

		public void API_SendXpInformation(int totalXp)
		{
		}

		public void API_SaveGame(int saveId, string data)
		{
			if (SteamManager.Initialized)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(data);
				if (bytes.Length == 0)
				{
					SteamRemoteStorage.FileDelete(SteamUser.GetSteamID().ToString() + "_" + ApiManager.GetPlayerPrefKey(saveId));
				}
				else
				{
					SteamRemoteStorage.FileWrite(SteamUser.GetSteamID().ToString() + "_" + ApiManager.GetPlayerPrefKey(saveId), bytes, bytes.Length);
				}
			}
			else
			{
				SaveIntoComputer(ApiManager.GetPlayerPrefKey(saveId), data);
			}
		}

		public string API_LoadGame(int saveId)
		{
			if (SteamManager.Initialized)
			{
				int fileSize = SteamRemoteStorage.GetFileSize(SteamUser.GetSteamID().ToString() + "_" + ApiManager.GetPlayerPrefKey(saveId));
				byte[] array = new byte[fileSize];
				SteamRemoteStorage.FileRead(SteamUser.GetSteamID().ToString() + "_" + ApiManager.GetPlayerPrefKey(saveId), array, fileSize);
				return Encoding.UTF8.GetString(array);
			}
			return LoadFromComputer(ApiManager.GetPlayerPrefKey(saveId));
		}

		public bool API_HasSave(int saveId)
		{
			if (SteamManager.Initialized)
			{
				if (!SteamRemoteStorage.FileExists(SteamUser.GetSteamID().ToString() + "_" + ApiManager.GetPlayerPrefKey(saveId)))
				{
					return false;
				}
				if (SteamRemoteStorage.GetFileSize(SteamUser.GetSteamID().ToString() + "_" + ApiManager.GetPlayerPrefKey(saveId)) == 0)
				{
					return false;
				}
				string text = API_LoadGame(saveId);
				if (string.IsNullOrEmpty(text) || !text.Contains(MainData.GetVersion()))
				{
					return false;
				}
				return true;
			}
			return HasDataInComputer(ApiManager.GetPlayerPrefKey(saveId));
		}

		public void API_SaveApplication(string data)
		{
			if (SteamManager.Initialized)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(data);
				SteamRemoteStorage.FileWrite(SteamUser.GetSteamID().ToString() + "_SaveApplication", bytes, bytes.Length);
			}
			else
			{
				SaveIntoComputer("SaveApplication", data);
			}
		}

		public string API_LoadApplication()
		{
			if (SteamManager.Initialized)
			{
				int fileSize = SteamRemoteStorage.GetFileSize(SteamUser.GetSteamID().ToString() + "_SaveApplication");
				byte[] array = new byte[fileSize];
				SteamRemoteStorage.FileRead(SteamUser.GetSteamID().ToString() + "_SaveApplication", array, fileSize);
				return Encoding.UTF8.GetString(array);
			}
			return LoadFromComputer("SaveApplication");
		}

		public bool API_HasApplicationSave()
		{
			if (SteamManager.Initialized)
			{
				return SteamRemoteStorage.GetFileSize(SteamUser.GetSteamID().ToString() + "_SaveApplication") > 0;
			}
			return HasDataInComputer("SaveApplication");
		}

		public void API_RunCallbacks()
		{
			if (SteamManager.Initialized)
			{
				SteamAPI.RunCallbacks();
			}
		}

		public bool OpenSteamForWishlist()
		{
			if (SteamManager.Initialized)
			{
				SteamFriends.ActivateGameOverlayToStore((AppId_t)3343160u, EOverlayToStoreFlag.k_EOverlayToStoreFlag_None);
				return true;
			}
			return false;
		}

		private string GetFilePath(string key)
		{
			return Path.Combine(Application.persistentDataPath, key + ".txt");
		}

		private void SaveIntoComputer(string key, string data)
		{
			try
			{
				File.WriteAllText(GetFilePath(key), data);
			}
			catch
			{
			}
		}

		private bool HasDataInComputer(string key)
		{
			try
			{
				string filePath = GetFilePath(key);
				return File.Exists(filePath) && new FileInfo(filePath).Length > 0;
			}
			catch
			{
			}
			return false;
		}

		private string LoadFromComputer(string key)
		{
			try
			{
				string filePath = GetFilePath(key);
				return File.Exists(filePath) ? File.ReadAllText(filePath) : string.Empty;
			}
			catch
			{
			}
			return string.Empty;
		}
	}
}
