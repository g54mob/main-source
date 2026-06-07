namespace Toybox.Port
{
	public static class PlatformAchievementManager
	{
		private static IPlatformAchievement s_platformAchievement;

		public static void SetPlatformAchievement(IPlatformAchievement platformAchievement)
		{
		}

		public static void UnlockAchievement(string achievementName)
		{
		}

		public static void ClearAchievement(string achievementName)
		{
		}

		public static bool GetAchievementUnlocked(string achievementName, bool fallback)
		{
			return false;
		}
	}
}
