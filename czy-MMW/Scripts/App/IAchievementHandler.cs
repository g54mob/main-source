public interface IAchievementHandler
{
	void OnAppStart();

	bool CompleteAchievement(Achievement achievement, bool showNotification);

	bool IsAchievementCompleted(AchievementDefinition achievement);

	bool IncrementStatistic(string statisticId, int increment);
}
