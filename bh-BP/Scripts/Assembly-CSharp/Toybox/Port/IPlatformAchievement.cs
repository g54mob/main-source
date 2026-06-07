namespace Toybox.Port
{
	public interface IPlatformAchievement
	{
		void UnlockAchievement(string achievementName);

		bool GetAchievementUnlocked(string achievementName, bool fallback);

		void ClearAchievement(string achievementName);
	}
}
