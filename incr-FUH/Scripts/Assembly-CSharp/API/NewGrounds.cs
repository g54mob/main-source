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

		public void API_SaveGame(int saveId, string data)
		{
			PlayerPrefs.SetString(ApiManager.GetPlayerPrefKey(saveId), data);
			PlayerPrefs.Save();
		}

		public string API_LoadGame(int saveId)
		{
			return PlayerPrefs.GetString(ApiManager.GetPlayerPrefKey(saveId));
		}

		public bool API_HasSave(int saveId)
		{
			if (PlayerPrefs.HasKey(ApiManager.GetPlayerPrefKey(saveId)) && PlayerPrefs.GetString(ApiManager.GetPlayerPrefKey(saveId)) != "")
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

		public void API_RunCallbacks()
		{
		}
	}
}
