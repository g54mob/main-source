using JetBrains.Annotations;

namespace Motorways.Leaderboards
{
	public delegate void LocalEntryRequestCompleted([CanBeNull] LeaderboardEntry localEntry, long totalLeaderboardEntryCount, [CanBeNull] LeaderboardError error);
}
