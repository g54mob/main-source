public class NullAchievementHandler : IAchievementHandler
{
	public static NullAchievementHandler Instance = new NullAchievementHandler();

	public void OnAppStart()
	{
	}

	public bool CompleteAchievement(Achievement achievement, bool showNotification)
	{
		return true;
	}

	public bool IsAchievementCompleted(AchievementDefinition achievement)
	{
		return true;
	}

	public bool IncrementStatistic(string statisticId, int increment)
	{
		return false;
	}
}
