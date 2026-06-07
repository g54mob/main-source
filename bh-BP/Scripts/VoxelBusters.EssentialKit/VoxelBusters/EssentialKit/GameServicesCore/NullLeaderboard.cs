namespace VoxelBusters.EssentialKit.GameServicesCore
{
	internal sealed class NullLeaderboard : LeaderboardBase
	{
		public NullLeaderboard(string id, string platformId)
			: base(null, null)
		{
		}

		public static void LoadLeaderboards(LoadLeaderboardsInternalCallback callback)
		{
		}

		public static void ShowLeaderboardView(string leaderboardId, LeaderboardTimeScope timescope, ViewClosedInternalCallback callback)
		{
		}

		private static void LogNotSupported()
		{
		}

		protected override string GetTitleInternal()
		{
			return null;
		}

		protected override LeaderboardPlayerScope GetPlayerScopeInternal()
		{
			return default(LeaderboardPlayerScope);
		}

		protected override void SetPlayerScopeInternal(LeaderboardPlayerScope value)
		{
		}

		protected override LeaderboardTimeScope GetTimeScopeInternal()
		{
			return default(LeaderboardTimeScope);
		}

		protected override void SetTimeScopeInternal(LeaderboardTimeScope value)
		{
		}

		protected override ILeaderboardScore GetLocalPlayerScoreInternal()
		{
			return null;
		}

		protected override void LoadTopScoresInternal(LoadScoresInternalCallback callback)
		{
		}

		protected override void LoadPlayerCenteredScoresInternal(LoadScoresInternalCallback callback)
		{
		}

		protected override void LoadNextInternal(LoadScoresInternalCallback callback)
		{
		}

		protected override void LoadPreviousInternal(LoadScoresInternalCallback callback)
		{
		}

		protected override void LoadImageInternal(LoadImageInternalCallback callback)
		{
		}

		protected override void ReportScoreInternal(long score, ReportScoreInternalCallback callback, string tag = null)
		{
		}
	}
}
