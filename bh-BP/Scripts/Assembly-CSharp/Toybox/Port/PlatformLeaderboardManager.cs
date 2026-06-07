using System;
using System.Collections.Generic;

namespace Toybox.Port
{
	public static class PlatformLeaderboardManager
	{
		public static readonly string[] LBIds;

		public const int kNumberFastestLeaderboards = 12;

		public const int kNumberActiveLeaderboards = 24;

		public const string kFastestTimePrefix = "kFastestTime";

		public const string kEndlessPrefix = "kEndless";

		private static IPlatformLeaderboard s_platformLeaderboard;

		public const int kCurExtDataVersion = 1;

		public const int kExtDataIdxChar1 = 0;

		public const int kExtDataIdxChar2 = 1;

		public const int kExtDataIdxBallStart = 2;

		public const int kExtDataIdxPassiveStart = 12;

		public const int kExtDataIdxMoreBallsStart = 17;

		public const int kExtDataIdxMorePassivesStart = 27;

		public const int kExtDataIdxVersion = 37;

		public const int kExtDataIdxFastLvl = 38;

		public const int kExtDataIdxCharLvl = 39;

		public const int kExtDataIdxChar2Lvl = 40;

		public const int kExtDataIdxCharStatsStart = 41;

		public const int kExtDataNumKills = 47;

		public const int kFastestTimeExtraDataLen = 48;

		public static int NumberLeaderboards => 0;

		public static void SetPlatformLeaderboard(IPlatformLeaderboard platformLeaderboard)
		{
		}

		public static int GetNumLBEntries(LBType t)
		{
			return 0;
		}

		public static void FetchLBEntries(LBType t, LBFilter filt, int rangeStart, int rangeEnd, Action<List<LBEntry>, LBType> callback)
		{
		}

		public static void PostScore(LBType t, int score, int[] extraData = null)
		{
		}

		public static void FetchLBEntries(string lbID, LBFilter filt, int rangeStart, int rangeEnd, Action<List<LBEntry>, string> callback)
		{
		}

		public static void PostScore(string lbID, int score, int[] extraData = null, LBSortDir sortMethod = LBSortDir.kAscending, LBDisplayType displayType = LBDisplayType.kNumeric)
		{
		}

		public static int GetNumLBEntries(string lbId)
		{
			return 0;
		}

		public static void PopulateExtraData(int[] extraData, BattleSaveData battleData)
		{
		}

		public static void PostFastestTime(LevelType level, BattleSaveData battleData)
		{
		}

		public static void PostEndlessScore(LevelType level, BattleSaveData battleData)
		{
		}

		public static bool IsValidLB(LBType t)
		{
			return false;
		}

		public static LBType GetFastestTimeLBForLvl(LevelType lvl)
		{
			return default(LBType);
		}

		public static LBType GetEndlessLBForLvl(LevelType lvl)
		{
			return default(LBType);
		}

		public static LevelType GetLevelForLB(LBType lb)
		{
			return default(LevelType);
		}

		public static string GetLBName(LBType t)
		{
			return null;
		}

		public static int GetActiveLeaderboardId(LBType leaderboardTypeEnum)
		{
			return 0;
		}

		public static bool IsActiveLeaderboard(LBType lBType)
		{
			return false;
		}

		public static bool IsFastestTimeLeaderboard(LBType lBType)
		{
			return false;
		}

		public static string GetLBID(LBParams prams)
		{
			return null;
		}

		public static int GetExtDataIdxVersion(int[] extraData)
		{
			return 0;
		}
	}
}
