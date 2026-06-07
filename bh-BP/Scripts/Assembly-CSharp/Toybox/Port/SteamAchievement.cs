namespace Toybox.Port
{
	public class SteamAchievement : IPlatformAchievement
	{
		public bool GetAchievementUnlocked(string achievementName, bool fallback)
		{
			return false;
		}

		public void UnlockAchievement(string achievementName)
		{
		}

		public void ClearAchievement(string achievementName)
		{
		}
	}
}
