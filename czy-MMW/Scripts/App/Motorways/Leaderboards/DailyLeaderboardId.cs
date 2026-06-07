using System;

namespace Motorways.Leaderboards
{
	public class DailyLeaderboardId : RecurringLeaderboardId
	{
		public const string DailyChallengeIdPrefix = "daily_challenge";

		public DayOfWeek Day { get; }

		public DailyLeaderboardId(int startTime)
			: base(startTime)
		{
			Day = ChallengeSystem.ToDateTime(startTime).DayOfWeek;
			_serializedString = Serialize();
		}

		public static bool IsDailyLeaderboardId(string leaderboardIdString)
		{
			return leaderboardIdString.StartsWith("daily_challenge");
		}

		public override bool IsLeaderboardOpen()
		{
			int num = ChallengeSystem.ToTimestamp(GameDateTime.UtcToday);
			int num2 = ChallengeSystem.ToTimestamp(GameDateTime.UtcToday + TimeSpan.FromDays(1.0) + TimeSpan.FromSeconds(3600.0));
			if (base.Timestamp >= num)
			{
				return base.Timestamp < num2;
			}
			return false;
		}

		public new static DailyLeaderboardId Deserialize(string leaderboardIdString)
		{
			if (!IsDailyLeaderboardId(leaderboardIdString))
			{
				LeaderboardId.Log.Error("Invalid DailyLeaderboardId string prefix: " + leaderboardIdString);
				return null;
			}
			int num = "daily_challenge".Length + 1;
			if (leaderboardIdString.Length < num)
			{
				LeaderboardId.Log.Error("Too few characters for DailyLeaderboardId string: " + leaderboardIdString);
				return null;
			}
			string[] array = leaderboardIdString.Substring(num).Split('_');
			if (array.Length != 1)
			{
				LeaderboardId.Log.Error("Invalid component count for DailyLeaderboardId: " + leaderboardIdString);
				return null;
			}
			if (!int.TryParse(array[0], out var result))
			{
				LeaderboardId.Log.Error("Failed to parse timestamp string from DailyLeaderboardId: " + leaderboardIdString);
				return null;
			}
			return new DailyLeaderboardId(result);
		}

		private string Serialize()
		{
			return string.Format("{0}_{1}", "daily_challenge", base.Timestamp);
		}
	}
}
