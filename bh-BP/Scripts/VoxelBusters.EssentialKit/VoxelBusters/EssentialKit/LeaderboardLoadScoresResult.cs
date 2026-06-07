namespace VoxelBusters.EssentialKit
{
	public class LeaderboardLoadScoresResult
	{
		public ILeaderboardScore[] Scores { get; private set; }

		public ILeaderboardScore LocalPlayerScore { get; private set; }

		public LeaderboardLoadScoresResult(ILeaderboardScore[] scores, ILeaderboardScore localPlayerScore)
		{
		}
	}
}
