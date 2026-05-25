using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace API
{
	public class NewGrounds : IApi
	{
		private const string AppID = "56521:PwQqgrBA";

		private const string EncryptionKey = "NpspA8SMRCTDx7Sd7yAXvA==";

		[DllImport("__Internal")]
		private static extern void NG_Log(string app_id, string encrypt_key);

		[DllImport("__Internal")]
		private static extern void NG_SetAchievement(string achievementId);

		public void API_Log()
		{
			try
			{
				NG_Log("56521:PwQqgrBA", "NpspA8SMRCTDx7Sd7yAXvA==");
			}
			catch (EntryPointNotFoundException)
			{
				Debug.Log("NG_Log - Could not find js method");
			}
		}

		public void API_SendAchievement(AchievementDefinition achievement)
		{
			try
			{
				if (achievement.NewGroundsId != "")
				{
					NG_SetAchievement(achievement.NewGroundsId);
				}
			}
			catch (EntryPointNotFoundException)
			{
				Debug.Log("NG_SetAchievement - Could not find js method");
			}
		}

		public void API_SendXpInformation(int totalXp)
		{
		}

		public void API_SaveGame(string data)
		{
			PlayerPrefs.SetString("SaveGame", data);
			PlayerPrefs.Save();
		}

		public string API_LoadGame()
		{
			return PlayerPrefs.GetString("SaveGame");
		}

		public bool API_HasSave()
		{
			if (PlayerPrefs.HasKey("SaveGame") && PlayerPrefs.GetString("SaveGame") != "")
			{
				return true;
			}
			return false;
		}

		public void API_SaveApplication(string data)
		{
			PlayerPrefs.SetString("SaveApplication", data);
			PlayerPrefs.Save();
		}

		public string API_LoadApplication()
		{
			return PlayerPrefs.GetString("SaveApplication");
		}

		public bool API_HasApplicationSave()
		{
			if (PlayerPrefs.HasKey("SaveApplication") && PlayerPrefs.GetString("SaveApplication") != "")
			{
				return true;
			}
			return false;
		}
	}
}
