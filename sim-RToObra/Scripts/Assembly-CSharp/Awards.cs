using System;
using Steamworks;
using UnityEngine;

public class Awards
{
	public enum Id
	{
		None = 0,
		Any6 = 1,
		Any15 = 2,
		Any30 = 3,
		Any45 = 4,
		ChapterSolved1 = 5,
		ChapterSolved2 = 6,
		ChapterSolved3 = 7,
		ChapterSolved4 = 8,
		ChapterSolved5 = 9,
		ChapterSolved6 = 10,
		ChapterSolved7 = 11,
		ChapterSolved9 = 12,
		ChapterSolved10 = 13,
		KillerCaptain = 14,
		BadEnding = 15,
		GoodEnding = 16,
		COUNT = 17
	}

	public static void Give(Id id)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogWarning("Failed to give award (no Steam): " + id);
			return;
		}
		string steamName = GetSteamName(id);
		if (steamName.HasValue())
		{
			Debug.Log("Giving award: " + steamName);
			SteamUserStats.SetAchievement(steamName);
			SteamUserStats.StoreStats();
		}
	}

	public static bool GetEarned(Id id)
	{
		if (!SteamManager.Initialized)
		{
			return false;
		}
		bool pbAchieved = false;
		if (SteamUserStats.GetAchievement(GetSteamName(id), out pbAchieved))
		{
			return pbAchieved;
		}
		return false;
	}

	public static string GetEarnedCode()
	{
		string text = string.Empty;
		for (int i = 1; i < 17; i++)
		{
			text = ((!GetEarned((Id)i)) ? (text + ".") : (text + "|"));
		}
		return text;
	}

	private static string GetSteamName(Id id)
	{
		switch (id)
		{
		case Id.Any6:
			return "ACH_ANYSOLVED_06";
		case Id.Any15:
			return "ACH_ANYSOLVED_15";
		case Id.Any30:
			return "ACH_ANYSOLVED_30";
		case Id.Any45:
			return "ACH_ANYSOLVED_45";
		case Id.ChapterSolved1:
			return "ACH_CHAPTERSOLVED_01";
		case Id.ChapterSolved2:
			return "ACH_CHAPTERSOLVED_02";
		case Id.ChapterSolved3:
			return "ACH_CHAPTERSOLVED_03";
		case Id.ChapterSolved4:
			return "ACH_CHAPTERSOLVED_04";
		case Id.ChapterSolved5:
			return "ACH_CHAPTERSOLVED_05";
		case Id.ChapterSolved6:
			return "ACH_CHAPTERSOLVED_06";
		case Id.ChapterSolved7:
			return "ACH_CHAPTERSOLVED_07";
		case Id.ChapterSolved9:
			return "ACH_CHAPTERSOLVED_09";
		case Id.ChapterSolved10:
			return "ACH_CHAPTERSOLVED_10";
		case Id.KillerCaptain:
			return "ACH_KILLERCAPTAIN";
		case Id.BadEnding:
			return "ACH_ENDING_BAD";
		case Id.GoodEnding:
			return "ACH_ENDING_GOOD";
		default:
			Debug.LogErrorFormat("No Steam name: {0}", id.ToString());
			return null;
		}
	}

	public static bool CheckForKillerCaptain()
	{
		foreach (Manifest.Crew item in Manifest.it.IterateCrews())
		{
			Story.Zone deathOrDisappearZone = Story.it.GetDeathOrDisappearZone(item.id);
			if (deathOrDisappearZone != Story.Zone.Ship)
			{
				continue;
			}
			string fateId = SaveData.it.faceRo[item.id].fateId;
			if (item.id == "captain")
			{
				if (fateId.Contains("suicide"))
				{
					continue;
				}
				return false;
			}
			string text = Manifest.FateId_KillerId(fateId);
			if (!(text != "captain"))
			{
				continue;
			}
			return false;
		}
		return true;
	}

	public static void PrepForClearAll()
	{
		if (SteamManager.Initialized)
		{
			SteamUserStats.RequestCurrentStats();
		}
	}

	public static void ClearAll()
	{
		if (!SteamManager.Initialized)
		{
			return;
		}
		Debug.Log("Clearing all awards");
		foreach (object value in Enum.GetValues(typeof(Id)))
		{
			string steamName = GetSteamName((Id)value);
			if (steamName.HasValue())
			{
				SteamUserStats.ClearAchievement(steamName);
			}
		}
		SteamUserStats.StoreStats();
	}
}
