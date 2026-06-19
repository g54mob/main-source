namespace TH20
{
	public static class PlatformStatsAndAchievements
	{
		private static IStatsAndAchievements _instance;

		public static void Initialise(StatsAsAchievementsData achievementData)
		{
			if (_instance == null && OSManager.IsInitialised() && OSManager.GetPlatform() == OSManager.Platform.Steam)
			{
				_instance = new SteamStatsAndAchievements();
			}
			if (_instance != null)
			{
				_instance.SetStatsAsAchievementsData(achievementData);
			}
		}

		public static void Destroy()
		{
			if (_instance != null)
			{
				_instance.Destroy();
			}
		}

		public static void Update()
		{
			if (_instance != null)
			{
				_instance.Update();
			}
		}

		public static void SetStatValue(Stat stat, int value)
		{
			if (_instance != null)
			{
				_instance.SetStatValue(stat, value);
			}
		}

		public static void TriggerAchievement(AchievementId achievementId)
		{
			if (_instance != null)
			{
				_instance.TriggerAchievement(achievementId);
			}
		}
	}
}
