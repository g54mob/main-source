namespace Motorways.Leaderboards
{
	public abstract class RecurringLeaderboardId : LeaderboardId
	{
		private readonly int _timestamp = -1;

		public override bool IsRecurringLeaderboard => true;

		public int Timestamp => _timestamp;

		protected RecurringLeaderboardId(int timestamp)
		{
			_timestamp = timestamp;
		}

		public abstract bool IsLeaderboardOpen();
	}
}
