using System.Collections.Generic;
using Steamworks;
using app;
using app.plat;
using haxe.lang;

public class SocialWrapper
{
	private class ApiSteam : PlatformSocialService
	{
		private Dictionary<string, SteamLeaderboard_t> leaderboardHandles;

		private List<CallResult<LeaderboardFindResult_t>> callResultsLFR;

		private List<CallResult<LeaderboardScoreUploaded_t>> callResultsLSU;

		private List<CallResult<LeaderboardScoresDownloaded_t>> callResultsLSD;

		private bool requestCurrentStatsSucceeded;

		private const ELeaderboardUploadScoreMethod kLeaderboardMethod = ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest;

		public ApiSteam()
			: base(default(EmptyObject))
		{
		}

		public override void connect(PlatformSocialLocalAchievements localAchievements_, PlatformSocialLocalLeaderboards localLeaderboards_)
		{
		}

		public override bool isConnected()
		{
			return false;
		}

		public override void processFrame()
		{
		}

		private void Call(SteamAPICall_t apiCall, CallResult<LeaderboardFindResult_t>.APIDispatchDelegate callback)
		{
		}

		private void Call(SteamAPICall_t apiCall, CallResult<LeaderboardScoreUploaded_t>.APIDispatchDelegate callback)
		{
		}

		private void Call(SteamAPICall_t apiCall, CallResult<LeaderboardScoresDownloaded_t>.APIDispatchDelegate callback)
		{
		}

		private void RemoveFinishedCallResults<T>(List<CallResult<T>> callResults)
		{
		}

		private void FindAllLeaderboards()
		{
		}

		public override string versionCode()
		{
			return null;
		}

		public override void pullAchievements()
		{
		}

		public override void pushAchievement(string achievementId)
		{
		}

		public override void clearAchievements()
		{
		}

		public override bool hasLeaderboards()
		{
			return false;
		}

		public override void pullLeaderboards()
		{
		}

		public override void pushLeaderboard(string leaderboardId, int score, int time)
		{
		}

		public override void showLeaderboard(string leaderboardId)
		{
		}

		public override void reportStat(string name, int value)
		{
		}
	}

	public static PlatformSocial MakePlatformSocial(CommandLine commandLine)
	{
		return null;
	}

	private static void Log(string format, params object[] args)
	{
	}
}
