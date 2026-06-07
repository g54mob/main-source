using UnityEngine;

namespace API
{
	public class Generic : IApi
	{
		public void API_Log()
		{
		}

		public void API_SendAchievement(AchievementDefinition achievement)
		{
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
