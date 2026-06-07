namespace Motorways.Leaderboards.Backends
{
	public class NullHistogramBackend : IHistogramBackend
	{
		public void RequestHistogram(LeaderboardId leaderboardId, HistogramRequestCompleted histogramRequestCompleted)
		{
			histogramRequestCompleted(null, 0, new LeaderboardError(LeaderboardErrorCode.Unknown));
		}
	}
}
