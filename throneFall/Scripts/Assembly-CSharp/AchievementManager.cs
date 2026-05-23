using System;
using Steamworks;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
	public enum Achievements
	{
		ET_STAGE_1 = 11,
		ET_STAGE_2 = 12,
		ET_STAGE_3 = 13,
		ET_STAGE_4 = 14,
		ET_STAGE_5 = 15,
		ET_STAGE_6 = 16,
		ET_STAGE_7 = 17,
		START_TUTORIAL = 0,
		COMPLETE_TUTORIAL = 1,
		NORDFELS_BEATEN = 2,
		NORDFELS_QUESTSCOMPLETE = 3,
		DURSTSTEIN_BEATEN = 4,
		DURSTSTEIN_QUESTSCOMPLETE = 5,
		FROSTSEE_BEATEN = 6,
		FROSTSEE_QUESTSCOMPLETE = 7,
		MAXLEVEL_REACHED = 8,
		UFERWIND_BEATEN = 9,
		UFERWIND_QUESTSCOMPLETE = 10,
		STURMKLAMM_BEATEN = 18,
		STURMKLAMM_QUESTSCOMPLETE = 19,
		CROWNS_5 = 20,
		CROWNS_10 = 21,
		CROWNS_20 = 22,
		CROWNS_30 = 23,
		WILDBACH_BEATEN = 24,
		WILDBACH_QUESTSCOMPLETE = 25,
		MOORWEG_BEATEN = 26,
		MOORWEG_QUESTSCOMPLETE = 27,
		FREIFORT_BEATEN = 28,
		FREIFORT_QUESTSCOMPLETE = 29,
		TOTEND_BEATEN = 30,
		TOTEND_QUESTSCOMPLETE = 31,
		CROWNS_40 = 32,
		CROWNS_50 = 33
	}

	public static void GiveCrownsAchievement(int _crownsAchieved)
	{
		if (_crownsAchieved >= 5)
		{
			UnlockAchievement(Achievements.CROWNS_5);
		}
		if (_crownsAchieved >= 10)
		{
			UnlockAchievement(Achievements.CROWNS_10);
		}
		if (_crownsAchieved >= 20)
		{
			UnlockAchievement(Achievements.CROWNS_20);
		}
		if (_crownsAchieved >= 30)
		{
			UnlockAchievement(Achievements.CROWNS_30);
		}
		if (_crownsAchieved >= 40)
		{
			UnlockAchievement(Achievements.CROWNS_40);
		}
		if (_crownsAchieved >= 50)
		{
			UnlockAchievement(Achievements.CROWNS_50);
		}
	}

	public static void UnlockEternalTrialsAchievementForBeating(int _stage)
	{
		switch (_stage)
		{
		case 1:
			UnlockAchievement(Achievements.ET_STAGE_1);
			break;
		case 2:
			UnlockAchievement(Achievements.ET_STAGE_2);
			break;
		case 3:
			UnlockAchievement(Achievements.ET_STAGE_3);
			break;
		case 4:
			UnlockAchievement(Achievements.ET_STAGE_4);
			break;
		case 5:
			UnlockAchievement(Achievements.ET_STAGE_5);
			break;
		case 6:
			UnlockAchievement(Achievements.ET_STAGE_6);
			break;
		case 7:
			UnlockAchievement(Achievements.ET_STAGE_7);
			break;
		}
	}

	public static void UnlockAchievement(Achievements _achievement)
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.SetAchievement(_achievement.ToString());
			SteamUserStats.StoreStats();
		}
	}

	public static void ResetAllAchievements()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("Warning: Resetting achievements only works while in play mode.");
			return;
		}
		string[] names = Enum.GetNames(typeof(Achievements));
		for (int i = 0; i < names.Length; i++)
		{
			SteamUserStats.ClearAchievement(names[i]);
		}
	}

	public static void LevelBeaten(string _scene)
	{
		if (_scene == "Neuland(Tutorial)")
		{
			UnlockAchievement(Achievements.START_TUTORIAL);
			UnlockAchievement(Achievements.COMPLETE_TUTORIAL);
		}
		if (_scene == "Nordfels")
		{
			UnlockAchievement(Achievements.NORDFELS_BEATEN);
		}
		if (_scene == "Durststein")
		{
			UnlockAchievement(Achievements.DURSTSTEIN_BEATEN);
		}
		if (_scene == "Frostsee")
		{
			UnlockAchievement(Achievements.FROSTSEE_BEATEN);
		}
		if (_scene == "Uferwind")
		{
			UnlockAchievement(Achievements.UFERWIND_BEATEN);
		}
		if (_scene == "Sturmklamm")
		{
			UnlockAchievement(Achievements.STURMKLAMM_BEATEN);
		}
		if (_scene == "Wildbach")
		{
			UnlockAchievement(Achievements.WILDBACH_BEATEN);
		}
		if (_scene == "Moorweg")
		{
			UnlockAchievement(Achievements.MOORWEG_BEATEN);
		}
		if (_scene == "Freifort")
		{
			UnlockAchievement(Achievements.FREIFORT_BEATEN);
		}
		if (_scene == "Totend")
		{
			UnlockAchievement(Achievements.TOTEND_BEATEN);
		}
	}

	public static void LevelAllQuestsComplete(string _scene)
	{
		if (_scene == "Nordfels")
		{
			UnlockAchievement(Achievements.NORDFELS_QUESTSCOMPLETE);
		}
		if (_scene == "Durststein")
		{
			UnlockAchievement(Achievements.DURSTSTEIN_QUESTSCOMPLETE);
		}
		if (_scene == "Frostsee")
		{
			UnlockAchievement(Achievements.FROSTSEE_QUESTSCOMPLETE);
		}
		if (_scene == "Uferwind")
		{
			UnlockAchievement(Achievements.UFERWIND_QUESTSCOMPLETE);
		}
		if (_scene == "Sturmklamm")
		{
			UnlockAchievement(Achievements.STURMKLAMM_QUESTSCOMPLETE);
		}
		if (_scene == "Wildbach")
		{
			UnlockAchievement(Achievements.WILDBACH_QUESTSCOMPLETE);
		}
		if (_scene == "Moorweg")
		{
			UnlockAchievement(Achievements.MOORWEG_QUESTSCOMPLETE);
		}
		if (_scene == "Freifort")
		{
			UnlockAchievement(Achievements.FREIFORT_QUESTSCOMPLETE);
		}
		if (_scene == "Totend")
		{
			UnlockAchievement(Achievements.TOTEND_QUESTSCOMPLETE);
		}
	}
}
