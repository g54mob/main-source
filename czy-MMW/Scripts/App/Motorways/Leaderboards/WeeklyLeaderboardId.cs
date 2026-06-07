using System;

namespace Motorways.Leaderboards
{
	public class WeeklyLeaderboardId : RecurringLeaderboardId
	{
		public const string WeeklyChallengeIdPrefix = "weekly_challenge";

		public ChallengeSystem.LeaderboardWeek Week { get; }

		public WeeklyLeaderboardId(int startTime)
			: base(startTime)
		{
			Week = ChallengeSystem.GetLeaderboardWeek(startTime);
			_serializedString = Serialize();
		}

		public static bool IsWeeklyLeaderboardId(string leaderboardIdString)
		{
			return leaderboardIdString.StartsWith("weekly_challenge");
		}

		public override bool IsLeaderboardOpen()
		{
			DateTime dateTime = ChallengeSystem.StartOfWeek(GameDateTime.UtcToday);
			int num = ChallengeSystem.ToTimestamp(dateTime);
			int num2 = ChallengeSystem.ToTimestamp(dateTime + TimeSpan.FromDays(7.0) + TimeSpan.FromSeconds(3600.0));
			if (base.Timestamp >= num)
			{
				return base.Timestamp < num2;
			}
			return false;
		}

		public new static WeeklyLeaderboardId Deserialize(string leaderboardIdString)
		{
			if (!IsWeeklyLeaderboardId(leaderboardIdString))
			{
				LeaderboardId.Log.Error("Invalid WeeklyLeaderboardId string prefix: " + leaderboardIdString);
				return null;
			}
			int num = "weekly_challenge".Length + 1;
			if (leaderboardIdString.Length < num)
			{
				LeaderboardId.Log.Error("Too few characters for WeeklyLeaderboardId string: " + leaderboardIdString);
				return null;
			}
			string[] array = leaderboardIdString.Substring(num).Split('_');
			if (array.Length != 1)
			{
				LeaderboardId.Log.Error("Invalid component count for WeeklyLeaderboardId: " + leaderboardIdString);
				return null;
			}
			if (!int.TryParse(array[0], out var result))
			{
				LeaderboardId.Log.Error("Failed to parse timestamp string from WeeklyLeaderboardId: " + leaderboardIdString);
				return null;
			}
			return new WeeklyLeaderboardId(result);
		}

		private string Serialize()
		{
			return string.Format("{0}_{1}", "weekly_challenge", base.Timestamp);
		}
	}
}
