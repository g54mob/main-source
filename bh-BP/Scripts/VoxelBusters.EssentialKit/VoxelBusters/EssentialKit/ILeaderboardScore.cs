using System;

namespace VoxelBusters.EssentialKit
{
	public interface ILeaderboardScore
	{
		string LeaderboardId { get; }

		string LeaderboardPlatformId { get; }

		IPlayer Player { get; }

		long Rank { get; }

		long Value { get; }

		string FormattedValue { get; }

		DateTime LastReportedDate { get; }

		string Tag { get; }
	}
}
