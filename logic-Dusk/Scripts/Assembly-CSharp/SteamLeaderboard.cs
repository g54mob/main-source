using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Steamworks;
using UnityEngine;

public class SteamLeaderboard : MonoBehaviour
{
	public enum ScoreStatusEnum
	{
		UnknownOrNone = 0,
		Partial = 1,
		Final = 10
	}

	public class ScoreInfo
	{
		public CSteamID PlayerID;

		public string PlayerName = string.Empty;

		public int Rank;

		public int Score;

		public bool IsSelf;

		public ScoreStatusEnum ScoreStatus;
	}

	private class LeaderboardInfo
	{
		private CallResult<LeaderboardFindResult_t> leaderBoardFindResult;

		private CallResult<LeaderboardScoresDownloaded_t> leaderBoardScoreDownloadResult;

		public string leaderboardKey = string.Empty;

		public string titleAtRequest = string.Empty;

		public bool friendsOnly;

		public SteamAPICall_t handle;

		public SteamLeaderboard_t leaderboard;

		public SteamStatusDelegate callback;

		public ScoreInfo[] scoreInfoArray;

		public bool knownNoData;

		public int LastKnownCount;

		private bool tempDownloadOnlySelf;

		private void FindLeaderboard()
		{
			leaderBoardFindResult = CallResult<LeaderboardFindResult_t>.Create(OnLeaderboardFindResult);
			handle = SteamUserStats.FindLeaderboard(leaderboardKey);
			leaderBoardFindResult.Set(handle);
		}

		public void BeginDownloadingScores()
		{
			if (leaderboard.m_SteamLeaderboard == 0L)
			{
				if (!knownNoData)
				{
					FindLeaderboard();
				}
				else
				{
					callback(false, null, 0, 0, string.Empty);
				}
			}
			else if (scoreInfoArray == null)
			{
				leaderBoardScoreDownloadResult = CallResult<LeaderboardScoresDownloaded_t>.Create(OnLeaderboardScoreDownloadResult);
				SteamAPICall_t hAPICall = (friendsOnly ? SteamUserStats.DownloadLeaderboardEntries(leaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestFriends, 1, 10) : SteamUserStats.DownloadLeaderboardEntries(leaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 1, 10));
				leaderBoardScoreDownloadResult.Set(hAPICall);
			}
			else
			{
				callback(true, scoreInfoArray, scoreInfoArray.Length, LastKnownCount, titleAtRequest);
			}
		}

		private void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
		{
			if (pCallback.m_bLeaderboardFound != 1 || bIOFailure)
			{
				if (!bIOFailure)
				{
					knownNoData = true;
				}
				callback(false, null, 0, 0, string.Empty);
				if (GlobalSettings.cheatMode)
				{
					DialogUI.Instance.ShowDialog("Error", "Couldn't connect to Daily Leaderboard - check steam account and Inet connection");
				}
				else
				{
					Debug.LogWarning("Couldn't connect to Daily Leaderboard - check steam account and Inet connection");
				}
			}
			else
			{
				leaderboard = pCallback.m_hSteamLeaderboard;
				BeginDownloadingScores();
			}
		}

		private void OnLeaderboardScoreDownloadResult(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
		{
			LeaderboardEntry_t pLeaderboardEntry2;
			if (pCallback.m_cEntryCount == 0)
			{
				if (!tempDownloadOnlySelf)
				{
					knownNoData = true;
					callback(false, null, 0, 0, string.Empty);
				}
				else
				{
					tempDownloadOnlySelf = false;
					callback(true, scoreInfoArray, scoreInfoArray.Length, LastKnownCount, titleAtRequest);
				}
			}
			else if (bIOFailure)
			{
				callback(false, null, 0, 0, string.Empty);
			}
			else if (!tempDownloadOnlySelf)
			{
				scoreInfoArray = new ScoreInfo[pCallback.m_cEntryCount];
				bool flag = false;
				for (int i = 0; i < pCallback.m_cEntryCount; i++)
				{
					int[] array = new int[1];
					LeaderboardEntry_t pLeaderboardEntry;
					if (SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, i, out pLeaderboardEntry, array, 1))
					{
						if (!flag && SteamUser.GetSteamID() == pLeaderboardEntry.m_steamIDUser)
						{
							flag = true;
						}
						ScoreInfo scoreInfo = new ScoreInfo();
						scoreInfo.PlayerID = pLeaderboardEntry.m_steamIDUser;
						scoreInfo.PlayerName = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser);
						scoreInfo.Rank = pLeaderboardEntry.m_nGlobalRank;
						scoreInfo.Score = pLeaderboardEntry.m_nScore;
						scoreInfo.IsSelf = SteamUser.GetSteamID() == pLeaderboardEntry.m_steamIDUser;
						scoreInfo.ScoreStatus = (ScoreStatusEnum)array[0];
						ScoreInfo scoreInfo2 = scoreInfo;
						scoreInfoArray[i] = scoreInfo2;
					}
				}
				LastKnownCount = SteamUserStats.GetLeaderboardEntryCount(leaderboard);
				if (!flag && pCallback.m_cEntryCount == 10)
				{
					tempDownloadOnlySelf = true;
					leaderBoardScoreDownloadResult = CallResult<LeaderboardScoresDownloaded_t>.Create(OnLeaderboardScoreDownloadResult);
					SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(leaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, 0, 0);
					leaderBoardScoreDownloadResult.Set(hAPICall);
				}
				else
				{
					callback(true, scoreInfoArray, pCallback.m_cEntryCount, LastKnownCount, titleAtRequest);
				}
			}
			else if (pCallback.m_cEntryCount <= 1 && SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, 0, out pLeaderboardEntry2, null, 0))
			{
				if (pLeaderboardEntry2.m_steamIDUser == SteamUser.GetSteamID())
				{
					Array.Resize(ref scoreInfoArray, scoreInfoArray.Length + 1);
					ScoreInfo scoreInfo = new ScoreInfo();
					scoreInfo.PlayerID = pLeaderboardEntry2.m_steamIDUser;
					scoreInfo.PlayerName = SteamFriends.GetFriendPersonaName(pLeaderboardEntry2.m_steamIDUser);
					scoreInfo.Rank = pLeaderboardEntry2.m_nGlobalRank;
					scoreInfo.Score = pLeaderboardEntry2.m_nScore;
					scoreInfo.IsSelf = true;
					ScoreInfo scoreInfo3 = scoreInfo;
					scoreInfoArray[scoreInfoArray.Length - 1] = scoreInfo3;
					tempDownloadOnlySelf = false;
					callback(true, scoreInfoArray, 11, LastKnownCount, titleAtRequest);
				}
				else
				{
					tempDownloadOnlySelf = false;
					callback(true, scoreInfoArray, 10, LastKnownCount, titleAtRequest);
				}
			}
		}
	}

	public delegate void SteamStatusDelegate(bool success, ScoreInfo[] scoreInfoArray, int recCount, int totalKnownRecordCount, string titleAtRequest);

	private static CallResult<LeaderboardFindResult_t> leaderBoardDailyFindResult;

	private static CallResult<LeaderboardFindResult_t> leaderBoardWeeklyFindResult;

	private static CallResult<LeaderboardScoreUploaded_t> leaderBoardScoreDailyUploadResult;

	private static CallResult<LeaderboardScoreUploaded_t> leaderBoardScoreWeeklyUploadResult;

	private static CallResult<LeaderboardScoresDownloaded_t> leaderBoardScoreDailyScoreDownloadResult;

	private static CallResult<LeaderboardScoresDownloaded_t> leaderBoardScoreWeeklyScoreDownloadResult;

	private static CallResult<LeaderboardScoresDownloaded_t> leaderBoardScoreDailyDownloadResult;

	private static CallResult<LeaderboardScoresDownloaded_t> leaderBoardScoreWeeklyDownloadResult;

	private static SteamLeaderboard_t dailyLeaderboard;

	private static SteamLeaderboard_t weeklyLeaderboard;

	private static bool initalized;

	private static Dictionary<string, LeaderboardInfo> dailyLeaderboadDict;

	public static bool IsRequestingDailyLeaderboard { get; private set; }

	public static int DailyLeaderboardScore { get; private set; }

	public static int WeeklyLeaderboardScore { get; private set; }

	public static ScoreStatusEnum WeeklyScoreStatus { get; private set; }

	public static bool HasDailyLeaderboard
	{
		get
		{
			return dailyLeaderboard.m_SteamLeaderboard != 0;
		}
	}

	public static bool HasWeeklyLeaderboard
	{
		get
		{
			return weeklyLeaderboard.m_SteamLeaderboard != 0;
		}
	}

	private void OnEnable()
	{
		if (SteamManager.Initialized && !initalized)
		{
			leaderBoardDailyFindResult = CallResult<LeaderboardFindResult_t>.Create(OnLeaderboardDailyFindResult);
			leaderBoardWeeklyFindResult = CallResult<LeaderboardFindResult_t>.Create(OnLeaderboardWeeklyFindResult);
			leaderBoardScoreDailyUploadResult = CallResult<LeaderboardScoreUploaded_t>.Create(OnLeaderboardScoreDailyUploadedResult);
			leaderBoardScoreWeeklyUploadResult = CallResult<LeaderboardScoreUploaded_t>.Create(OnLeaderboardScoreWeeklyUploadedResult);
			leaderBoardScoreDailyScoreDownloadResult = CallResult<LeaderboardScoresDownloaded_t>.Create(OnLeaderboardDailyScoreDownloadResult);
			leaderBoardScoreWeeklyScoreDownloadResult = CallResult<LeaderboardScoresDownloaded_t>.Create(OnLeaderboardWeeklyScoreDownloadResult);
			string arg = DateTime.UtcNow.ToString("yyyyMMdd");
			SteamAPICall_t hAPICall = SteamUserStats.FindOrCreateLeaderboard(string.Format("DailyLeaderboard{0}", arg), ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
			leaderBoardDailyFindResult.Set(hAPICall);
			CalendarWeekRule rule = CalendarWeekRule.FirstFullWeek;
			DayOfWeek firstDayOfWeek = DayOfWeek.Sunday;
			Calendar calendar = Thread.CurrentThread.CurrentCulture.Calendar;
			int weekOfYear = calendar.GetWeekOfYear(DateTime.UtcNow, rule, firstDayOfWeek);
			string arg2 = string.Format("{0:0000}{1:00}", DateTime.UtcNow.Year, weekOfYear);
			DateTime now = DateTime.Now;
			DateTime utcNow = DateTime.UtcNow;
			SteamAPICall_t hAPICall2 = SteamUserStats.FindOrCreateLeaderboard(string.Format("WeeklyLeaderboard{0}", arg2), ELeaderboardSortMethod.k_ELeaderboardSortMethodDescending, ELeaderboardDisplayType.k_ELeaderboardDisplayTypeNumeric);
			leaderBoardWeeklyFindResult.Set(hAPICall2);
			initalized = true;
		}
	}

	public static bool RequestLeaderboard(bool friendsOnly, string key, string titleAtRequest, bool forceRefresh, SteamStatusDelegate callback)
	{
		string key2 = key + ((!friendsOnly) ? "_G" : "_F");
		IsRequestingDailyLeaderboard = true;
		if (dailyLeaderboadDict == null)
		{
			dailyLeaderboadDict = new Dictionary<string, LeaderboardInfo>();
		}
		if (!dailyLeaderboadDict.ContainsKey(key2))
		{
			dailyLeaderboadDict.Add(key2, new LeaderboardInfo());
			dailyLeaderboadDict[key2].leaderboardKey = key;
			dailyLeaderboadDict[key2].friendsOnly = friendsOnly;
			dailyLeaderboadDict[key2].titleAtRequest = titleAtRequest;
		}
		dailyLeaderboadDict[key2].callback = callback;
		if (forceRefresh)
		{
			dailyLeaderboadDict[key2].scoreInfoArray = null;
			dailyLeaderboadDict[key2].knownNoData = false;
		}
		dailyLeaderboadDict[key2].BeginDownloadingScores();
		return true;
	}

	public static void RefreshChallengeScores()
	{
		RefreshDailyChallengeScore();
		RefreshWeeklyChallengeScore();
	}

	private static void RefreshDailyChallengeScore()
	{
		SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(dailyLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, 0, 0);
		leaderBoardScoreDailyScoreDownloadResult.Set(hAPICall);
	}

	private static void RefreshWeeklyChallengeScore()
	{
		SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(weeklyLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, 0, 0);
		leaderBoardScoreWeeklyScoreDownloadResult.Set(hAPICall);
	}

	public static void PostChallengeScore(GameModeEnum mode, int score, ScoreStatusEnum scoreStatus)
	{
		if (SteamManager.Initialized)
		{
			int[] pScoreDetails = new int[1] { (int)scoreStatus };
			switch (mode)
			{
			case GameModeEnum.DailyChallenge:
			{
				SteamAPICall_t hAPICall2 = SteamUserStats.UploadLeaderboardScore(dailyLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, score, pScoreDetails, 1);
				leaderBoardScoreDailyUploadResult.Set(hAPICall2);
				break;
			}
			case GameModeEnum.WeeklyChallenge:
			{
				WeeklyScoreStatus = scoreStatus;
				WeeklyLeaderboardScore = score;
				SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(weeklyLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodForceUpdate, score, pScoreDetails, 1);
				leaderBoardScoreWeeklyUploadResult.Set(hAPICall);
				break;
			}
			default:
				Debug.LogWarning(string.Format("SteamLeaderboard doesn't support posting stores for {0} mode", mode));
				break;
			}
		}
	}

	private static void OnLeaderboardDailyFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bLeaderboardFound != 1 || bIOFailure)
		{
			if (GlobalSettings.cheatMode)
			{
				DialogUI.Instance.ShowDialog("Error", "Couldn't connect to Daily Leaderboard - check steam account and Inet connection");
			}
			else
			{
				Debug.LogWarning("Couldn't connect to Daily Leaderboard - check steam account and Inet connection");
			}
		}
		else
		{
			dailyLeaderboard = pCallback.m_hSteamLeaderboard;
			RefreshDailyChallengeScore();
		}
	}

	private static void OnLeaderboardWeeklyFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bLeaderboardFound != 1 || bIOFailure)
		{
			if (GlobalSettings.cheatMode)
			{
				DialogUI.Instance.ShowDialog("Error", "Couldn't connect to Weekly Leaderboard - check steam account and Inet connection");
			}
			else
			{
				Debug.LogWarning("Couldn't connect to Weekly Leaderboard - check steam account and Inet connection");
			}
		}
		else
		{
			weeklyLeaderboard = pCallback.m_hSteamLeaderboard;
			RefreshWeeklyChallengeScore();
		}
	}

	private static void OnLeaderboardScoreDailyUploadedResult(LeaderboardScoreUploaded_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bSuccess != 1 || bIOFailure)
		{
			Debug.LogError("Couldn't upload score");
		}
		else
		{
			DailyLeaderboardScore = pCallback.m_nScore;
		}
	}

	private static void OnLeaderboardScoreWeeklyUploadedResult(LeaderboardScoreUploaded_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bSuccess != 1 || bIOFailure)
		{
			Debug.LogError("Couldn't upload score");
		}
		else
		{
			WeeklyLeaderboardScore = pCallback.m_nScore;
		}
	}

	private static void OnLeaderboardDailyScoreDownloadResult(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
	{
		LeaderboardEntry_t pLeaderboardEntry;
		if (pCallback.m_cEntryCount == 0)
		{
			DailyLeaderboardScore = -1;
		}
		else if (bIOFailure)
		{
			DailyLeaderboardScore = -2;
		}
		else if (SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, 0, out pLeaderboardEntry, null, 0))
		{
			DailyLeaderboardScore = pLeaderboardEntry.m_nScore;
		}
		else
		{
			DailyLeaderboardScore = -3;
		}
	}

	private static void OnLeaderboardWeeklyScoreDownloadResult(LeaderboardScoresDownloaded_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_cEntryCount == 0)
		{
			WeeklyLeaderboardScore = -1;
			WeeklyScoreStatus = ScoreStatusEnum.UnknownOrNone;
			return;
		}
		if (bIOFailure)
		{
			WeeklyLeaderboardScore = -2;
			WeeklyScoreStatus = ScoreStatusEnum.UnknownOrNone;
			return;
		}
		int[] array = new int[1];
		LeaderboardEntry_t pLeaderboardEntry;
		if (SteamUserStats.GetDownloadedLeaderboardEntry(pCallback.m_hSteamLeaderboardEntries, 0, out pLeaderboardEntry, array, 1))
		{
			WeeklyLeaderboardScore = pLeaderboardEntry.m_nScore;
			WeeklyScoreStatus = (ScoreStatusEnum)array[0];
		}
		else
		{
			WeeklyLeaderboardScore = -3;
			WeeklyScoreStatus = ScoreStatusEnum.UnknownOrNone;
		}
	}
}
