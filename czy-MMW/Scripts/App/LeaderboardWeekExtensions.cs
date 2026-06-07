using Motorways;

public static class LeaderboardWeekExtensions
{
	public static ChallengeSystem.LeaderboardWeek Other(this ChallengeSystem.LeaderboardWeek week)
	{
		if (week != ChallengeSystem.LeaderboardWeek.WeekA)
		{
			return ChallengeSystem.LeaderboardWeek.WeekA;
		}
		return ChallengeSystem.LeaderboardWeek.WeekB;
	}
}
