namespace Epic.OnlineServices.Leaderboards
{
	public class LeaderboardUserScore : ISettable
	{
		public ProductUserId UserId { get; set; }

		public int Score { get; set; }

		internal void Set(LeaderboardUserScoreInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
