namespace VoxelBusters.EssentialKit
{
	public class GameServicesLoadLeaderboardsResult
	{
		public ILeaderboard[] Leaderboards { get; private set; }

		internal GameServicesLoadLeaderboardsResult(ILeaderboard[] leaderboards)
		{
		}
	}
}
