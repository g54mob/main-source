namespace TH20
{
	public interface IStatsAndAchievements
	{
		void SetStatValue(Stat stat, int value);

		void TriggerAchievement(AchievementId achievementId);

		void Update();

		void Destroy();

		void SetStatsAsAchievementsData(StatsAsAchievementsData achievementData);
	}
}
