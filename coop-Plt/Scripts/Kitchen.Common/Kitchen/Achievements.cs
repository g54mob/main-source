using Platforms;

namespace Kitchen
{
	public static class Achievements
	{
		public static (int, int) Progress => Platform.Current.AchievementProgress();

		public static bool Has(string achievement)
		{
			return Platform.Current.HasAchievement(achievement);
		}

		public static void Unlock(string achievement)
		{
			Platform.Current.UnlockAchievement(achievement, Players.Main.LocalUsers);
		}
	}
}
