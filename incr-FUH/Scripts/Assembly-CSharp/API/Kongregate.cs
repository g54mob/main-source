using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace API
{
	public class Kongregate : IApi
	{
		[DllImport("__Internal")]
		private static extern void KG_Log();

		[DllImport("__Internal")]
		private static extern void KG_sendStats(string name, int amount);

		public void API_Log()
		{
			try
			{
				KG_Log();
			}
			catch (EntryPointNotFoundException)
			{
				Debug.Log("KG_Log - Could not find js method");
			}
		}

		public void API_SendAchievement(AchievementDefinition achievement)
		{
			try
			{
				if (achievement.KongregateId != "")
				{
					KG_sendStats(achievement.KongregateId, 1);
				}
			}
			catch (EntryPointNotFoundException)
			{
				Debug.Log("KG_sendStats - Could not find js method");
			}
		}

		public void API_SendXpInformation(int totalXp)
		{
			try
			{
				KG_sendStats("EndGameTotalXP", totalXp);
			}
			catch (EntryPointNotFoundException)
			{
				Debug.Log("KG_SendXpInformation - Could not find js method");
			}
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
