namespace Epic.OnlineServices.Leaderboards
{
	public class UserScoresQueryStatInfo : ISettable
	{
		public string StatName { get; set; }

		public LeaderboardAggregation Aggregation { get; set; }

		internal void Set(UserScoresQueryStatInfoInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
