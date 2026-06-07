using Steamworks;

public static class SteamLeaderboards
{
	private static SteamLeaderboard_t s_leaderboard;

	private static CallResult<LeaderboardFindResult_t> s_findResult;

	private static CallResult<LeaderboardScoreUploaded_t> s_uploadResult;

	private static CallResult<LeaderboardScoresDownloaded_t> s_downloadResult;

	private static bool s_initialized;

	private static int s_pendingScore;

	public static int UserGlobalRank { get; private set; }

	public static int UserBestScore { get; private set; }

	public static bool UserEntryReady { get; private set; }

	public static void Init()
	{
	}

	public static void UploadScore(float moneyPerSecond)
	{
	}

	public static void RequestUserEntry()
	{
	}

	private static void OnLeaderboardFound(LeaderboardFindResult_t result, bool ioFailure)
	{
	}

	private static void OnUserScoreDownloaded(LeaderboardScoresDownloaded_t result, bool ioFailure)
	{
	}

	private static void OnScoreUploaded(LeaderboardScoreUploaded_t result, bool ioFailure)
	{
	}
}
