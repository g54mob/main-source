namespace Epic.OnlineServices.Leaderboards
{
	public class LeaderboardRecord : ISettable
	{
		public ProductUserId UserId { get; set; }

		public uint Rank { get; set; }

		public int Score { get; set; }

		public string UserDisplayName { get; set; }

		internal void Set(LeaderboardRecordInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
