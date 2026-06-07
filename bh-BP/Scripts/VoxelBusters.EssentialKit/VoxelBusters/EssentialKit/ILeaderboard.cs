using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public interface ILeaderboard
	{
		string Id { get; }

		string PlatformId { get; }

		string Title { get; }

		LeaderboardPlayerScope PlayerScope { get; set; }

		LeaderboardTimeScope TimeScope { get; set; }

		int LoadScoresQuerySize { get; set; }

		[Obsolete("Use LocalPlayerScore property in LeaderboardLoadScoresResult instead")]
		ILeaderboardScore LocalPlayerScore { get; }

		void ReportScore(long score, CompletionCallback callback, string tag = null);

		void LoadTopScores(EventCallback<LeaderboardLoadScoresResult> callback);

		void LoadPlayerCenteredScores(EventCallback<LeaderboardLoadScoresResult> callback);

		void LoadNext(EventCallback<LeaderboardLoadScoresResult> callback);

		void LoadPrevious(EventCallback<LeaderboardLoadScoresResult> callback);

		void LoadImage(EventCallback<TextureData> callback);
	}
}
