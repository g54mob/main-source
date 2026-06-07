using System;

namespace Motorways.Leaderboards
{
	public abstract class LeaderboardId : IEquatable<LeaderboardId>
	{
		protected static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("LeaderboardId");

		protected const int InvalidTimestamp = -1;

		protected string _serializedString;

		public string SerializedString => _serializedString;

		public abstract bool IsRecurringLeaderboard { get; }

		public static LeaderboardId Deserialize(string leaderboardIdString)
		{
			if (CityLeaderboardId.IsCityLeaderboardId(leaderboardIdString))
			{
				return CityLeaderboardId.Deserialize(leaderboardIdString);
			}
			if (DailyLeaderboardId.IsDailyLeaderboardId(leaderboardIdString))
			{
				return DailyLeaderboardId.Deserialize(leaderboardIdString);
			}
			if (WeeklyLeaderboardId.IsWeeklyLeaderboardId(leaderboardIdString))
			{
				return WeeklyLeaderboardId.Deserialize(leaderboardIdString);
			}
			Log.Error("Invalid LeaderboardId string prefix: " + leaderboardIdString);
			return null;
		}

		public bool Equals(LeaderboardId leaderboardId)
		{
			if (leaderboardId == null)
			{
				return false;
			}
			return SerializedString == leaderboardId.SerializedString;
		}

		public override int GetHashCode()
		{
			return SerializedString.GetHashCode();
		}

		public override string ToString()
		{
			return SerializedString;
		}
	}
}
