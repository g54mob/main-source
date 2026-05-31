using System.IO;
using System.Text;
using Steamworks;
using UnityEngine;

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
			}
		}

		public void API_SendXpInformation(int totalXp)
		{
		}

		public void API_SaveGame(string data)
		{
			if (SteamManager.Initialized)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(data);
				SteamRemoteStorage.FileWrite(SteamUser.GetSteamID().ToString() + "_SaveGame", bytes, bytes.Length);
			}
			else
			{
				SaveIntoComputer("SaveGame", data);
			}
		}

		public string API_LoadGame()
		{
			if (SteamManager.Initialized)
			{
				int fileSize = SteamRemoteStorage.GetFileSize(SteamUser.GetSteamID().ToString() + "_SaveGame");
				byte[] array = new byte[fileSize];
				SteamRemoteStorage.FileRead(SteamUser.GetSteamID().ToString() + "_SaveGame", array, fileSize);
				return Encoding.UTF8.GetString(array);
			}
			return LoadFromComputer("SaveGame");
		}

		public bool API_HasSave()
		{
			if (SteamManager.Initialized)
			{
				return SteamRemoteStorage.GetFileSize(SteamUser.GetSteamID().ToString() + "_SaveGame") > 0;
			}
			return HasDataInComputer("SaveGame");
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
