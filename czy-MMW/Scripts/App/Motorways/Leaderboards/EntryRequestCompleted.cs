using System.Collections.Generic;
using JetBrains.Annotations;

namespace Motorways.Leaderboards
{
	public delegate void EntryRequestCompleted([CanBeNull] List<LeaderboardEntry> entries, long totalLeaderboardEntryCount, [CanBeNull] LeaderboardError error);
}
