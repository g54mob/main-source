using System.Collections.Generic;
using JetBrains.Annotations;

namespace Motorways.Leaderboards
{
	public delegate void HistogramRequestCompleted([CanBeNull] List<int> buckets, int bucketSize, [CanBeNull] LeaderboardError error);
}
