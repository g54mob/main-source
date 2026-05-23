using System;
using Steamworks;

public class SteamLeaderboard
{
	private string leaderboardName;

	private int scoreToSet;

	private SteamLeaderboard_t currentLeaderboard;

	private CallResult<LeaderboardFindResult_t> findResult = new CallResult<LeaderboardFindResult_t>();

	private CallResult<LeaderboardScoreUploaded_t> uploadResult = new CallResult<LeaderboardScoreUploaded_t>();

	private CallResult<LeaderboardScoresDownloaded_t> downloadResultPlayer = new CallResult<LeaderboardScoresDownloaded_t>();

	private CallResult<LeaderboardScoresDownloaded_t> downloadResultTop = new CallResult<LeaderboardScoresDownloaded_t>();

	private Action<LeaderboardEntryData[]> loadPlayerCallback;

	private Action<LeaderboardEntryData[]> loadTopCallback;

	private SteamLeaderboard(string leaderboardName, int scoreToSet, Action<LeaderboardEntryData[]> loadPlayerCallback, Action<LeaderboardEntryData[]> loadTopCallback)
	{
		this.leaderboardName = leaderboardName;
		this.loadPlayerCallback = loadPlayerCallback;
		this.loadTopCallback = loadTopCallback;
		this.scoreToSet = scoreToSet;
	}

	public static SteamLeaderboard LoadLeaderboard(string leaderboardName, int score, Action<LeaderboardEntryData[]> loadPlayerCallback, Action<LeaderboardEntryData[]> loadTopCallback)
	{
		SteamLeaderboard steamLeaderboard = new SteamLeaderboard(leaderboardName, score, loadPlayerCallback, loadTopCallback);
		steamLeaderboard.Load();
		return steamLeaderboard;
	}

	public void Load()
	{
		if (SteamManager.Initialized)
		{
			SteamAPICall_t hAPICall = SteamUserStats.FindLeaderboard(leaderboardName);
			findResult.Set(hAPICall, OnLeaderboardFindResult);
		}
	}

	private void OnLeaderboardFindResult(LeaderboardFindResult_t callback, bool failure)
	{
		if (!failure)
		{
			currentLeaderboard = callback.m_hSteamLeaderboard;
			if (scoreToSet != 0)
			{
				SteamAPICall_t hAPICall = SteamUserStats.UploadLeaderboardScore(currentLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, scoreToSet, null, 0);
				uploadResult.Set(hAPICall, OnLeaderboardUploadResult);
			}
			else
			{
				SteamAPICall_t hAPICall2 = SteamUserStats.UploadLeaderboardScore(currentLeaderboard, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodNone, 0, null, 0);
				uploadResult.Set(hAPICall2, OnLeaderboardUploadResult);
			}
			SteamAPICall_t hAPICall3 = SteamUserStats.DownloadLeaderboardEntries(currentLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 0, 300);
			downloadResultTop.Set(hAPICall3, OnTopEntriesLoaded);
		}
	}

	private void OnLeaderboardUploadResult(LeaderboardScoreUploaded_t callback, bool failure)
	{
		if (!failure)
		{
			SteamAPICall_t hAPICall = SteamUserStats.DownloadLeaderboardEntries(currentLeaderboard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobalAroundUser, 0, 0);
			downloadResultPlayer.Set(hAPICall, OnPlayerEntryLoaded);
		}
	}

	private void OnPlayerEntryLoaded(LeaderboardScoresDownloaded_t callback, bool failure)
	{
		if (!failure)
		{
			loadPlayerCallback(GetEntryData(callback));
		}
	}

	private void OnTopEntriesLoaded(LeaderboardScoresDownloaded_t callback, bool failure)
	{
		if (!failure)
		{
			loadTopCallback(GetEntryData(callback));
		}
	}

	private LeaderboardEntryData[] GetEntryData(LeaderboardScoresDownloaded_t callback)
	{
		LeaderboardEntryData[] array = new LeaderboardEntryData[callback.m_cEntryCount];
		for (int i = 0; i < callback.m_cEntryCount; i++)
		{
			SteamUserStats.GetDownloadedLeaderboardEntry(callback.m_hSteamLeaderboardEntries, i, out var pLeaderboardEntry, null, 0);
			array[i].playerName = SteamFriends.GetFriendPersonaName(pLeaderboardEntry.m_steamIDUser);
			array[i].score = pLeaderboardEntry.m_nScore;
			array[i].rank = pLeaderboardEntry.m_nGlobalRank;
		}
		return array;
	}
}
