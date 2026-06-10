namespace NSMedieval
{
	public interface IAchievementManager
	{
		void UnlockAchievement(string achievementName);

		bool IsUnlocked(string achievementName);

		void ResetAll();

		void SetStat(string statName, int value);

		void IncreaseStat(string statName, int incValue = 1);

		int GetStat(string statName);

		void ForceFlush();
	}
}
