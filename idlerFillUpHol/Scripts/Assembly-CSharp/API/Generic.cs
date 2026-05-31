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
