using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Obsolete("Use ILeaderboardScore for accessing the score of a leaderboard. For reporting scores, use ILeaderboard.", true)]
	public interface IScore
	{
		string LeaderboardId { get; }

		string LeaderboardPlatformId { get; }

		IPlayer Player { get; }

		long Rank { get; }

		long Value { get; set; }

		string FormattedValue { get; }

		DateTime LastReportedDate { get; }

		string Tag { get; set; }

		void ReportScore(CompletionCallback callback);
	}
}
