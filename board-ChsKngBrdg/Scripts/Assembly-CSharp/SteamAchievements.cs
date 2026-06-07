using System;
using System.Collections.Generic;
using Steamworks.Data;
using UnityEngine;

public class SteamAchievements : MonoBehaviour
{
	public static List<string> Achievements = new List<string>
	{
		"WALK_WRONG_WAY", "CREATE_TWO_CASTLES", "BAD_ENDING", "GOOD_ENDING", "UNLOCKED_10_PAGES", "UNLOCKED_ALL_PAGES", "COMPLETE_UNDER_15_MIN", "COMPLETE_UNDER_10_MIN", "CAPTURE_BY_LANDMINE", "CAPTURE_QUEEN_BY_LANDMINE",
		"WALK_FAR", "LEAVE_MANY_LANDMINES", "CAPTURE_TWO", "CAPTURE_THREE", "ASCEND_TWO_PAWNS", "MISS_THREE_CHEATS", "ACCUSE_WITHOUT_DEFOG", "EAT_TEN_WHITE_PIECES", "ACCUSE_TROLL_SUCCESS", "ACCUSE_TROLL_10_SUCCES",
		"SLIP_THREE_WHITE_PIECES", "WIN_BY_OVERKILL", "MANY_VALORITE_SCRAPS", "PIECE_OUT_OF_TOWN", "HIDE_BEHIND_TROLL", "CAPTURE_KING_WITH_QUEEN", "WIN_MATCH_BY_JUGGLING", "RALLY_QUEEN", "SHOWDOWN_KINGS", "DUCK_FORCE",
		"WIN_SPEED_CHESS_ONE", "WIN_SPEED_CHESS_TWO", "WIN_SPEED_CHESS_THREE", "ASCENSION_ENDING", "DUCK_ENDING", "DROP_MENULOGO"
	};

	public static bool IsThisAchievementUnlocked(string id)
	{
		try
		{
			return new Achievement(id).State;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return false;
	}

	public static string TryGetNameOfAchievement(string id)
	{
		try
		{
			return new Achievement(id).Name;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return "ACHIEVEMENT_NAME_NOT_FOUND";
	}

	public static string TryGetDescriptionOfAchievement(string id)
	{
		try
		{
			return new Achievement(id).Description;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return "ACHIEVEMENT_DESCRIPTION_NOT_FOUND";
	}

	public static float TryGetGlobalUnlockedOfAchievement(string id)
	{
		try
		{
			return new Achievement(id).GlobalUnlocked;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return -1f;
	}

	public static void UnlockAchievement(string id)
	{
		try
		{
			Achievement achievement = new Achievement(id);
			if (!achievement.State)
			{
				achievement.Trigger();
				CheckForFinalAchievement();
			}
			Debug.Log("Achievement " + id + " unlocked");
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public static void ClearAchievementStatus(string id)
	{
		try
		{
			new Achievement(id).Clear();
			Debug.Log("Achievement " + id + " cleared");
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public static void CheckForFinalAchievement()
	{
		bool flag = true;
		foreach (string achievement in Achievements)
		{
			if (!IsThisAchievementUnlocked(achievement))
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			UnlockAchievement("UNLOCK_ALL_ACHIEVEMENTS");
		}
		else
		{
			ClearAchievementStatus("UNLOCK_ALL_ACHIEVEMENTS");
		}
	}
}
