using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	public abstract class LeaderboardBase : NativeObjectBase, ILeaderboard
	{
		public string Id { get; internal set; }

		public string PlatformId { get; private set; }

		public string Title => null;

		public LeaderboardPlayerScope PlayerScope
		{
			get
			{
				return default(LeaderboardPlayerScope);
			}
			set
			{
			}
		}

		public LeaderboardTimeScope TimeScope
		{
			get
			{
				return default(LeaderboardTimeScope);
			}
			set
			{
			}
		}

		public int LoadScoresQuerySize { get; set; }

		public ILeaderboardScore LocalPlayerScore => null;

		protected LeaderboardBase(string id, string platformId)
		{
		}

		protected abstract string GetTitleInternal();

		protected abstract LeaderboardPlayerScope GetPlayerScopeInternal();

		protected abstract void SetPlayerScopeInternal(LeaderboardPlayerScope value);

		protected abstract LeaderboardTimeScope GetTimeScopeInternal();

		protected abstract void SetTimeScopeInternal(LeaderboardTimeScope value);

		protected abstract ILeaderboardScore GetLocalPlayerScoreInternal();

		protected abstract void ReportScoreInternal(long score, ReportScoreInternalCallback callback, string tag = null);

		protected abstract void LoadTopScoresInternal(LoadScoresInternalCallback callback);

		protected abstract void LoadPlayerCenteredScoresInternal(LoadScoresInternalCallback callback);

		protected abstract void LoadNextInternal(LoadScoresInternalCallback callback);

		protected abstract void LoadPreviousInternal(LoadScoresInternalCallback callback);

		protected abstract void LoadImageInternal(LoadImageInternalCallback callback);

		public override string ToString()
		{
			return null;
		}

		public void ReportScore(long score, CompletionCallback callback, string tag = null)
		{
		}

		public void LoadTopScores(EventCallback<LeaderboardLoadScoresResult> callback)
		{
		}

		public void LoadPlayerCenteredScores(EventCallback<LeaderboardLoadScoresResult> callback)
		{
		}

		public void LoadNext(EventCallback<LeaderboardLoadScoresResult> callback)
		{
		}

		public void LoadPrevious(EventCallback<LeaderboardLoadScoresResult> callback)
		{
		}

		public void LoadImage(EventCallback<TextureData> callback)
		{
		}

		private void SendLoadScoresResult(EventCallback<LeaderboardLoadScoresResult> callback, ILeaderboardScore[] scores, ILeaderboardScore localPlayerScore, Error error)
		{
		}

		private void SendReportScoreResult(CompletionCallback callback, bool success, Error error)
		{
		}
	}
}
