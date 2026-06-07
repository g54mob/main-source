namespace Motorways.Leaderboards
{
	public interface IHistogramBackend
	{
		void RequestHistogram(LeaderboardId leaderboardId, HistogramRequestCompleted histogramRequestCompleted);
	}
}
