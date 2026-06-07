using System;

namespace Brewery.Achievements
{
	public interface ISteamAchievementService
	{
		bool IsAvailable { get; }

		event Action OnStatsReceived;

		event Action<string> OnAchievementUnlocked;

		bool UnlockAchievement(string achievementId);

		bool IsAchievementUnlocked(string achievementId);

		float GetAchievementUnlockPercentage(string achievementId);

		bool StoreStats();

		void RequestCurrentStats();

		bool SetStat(string statName, int value);

		int GetStat(string statName);

		bool ClearAchievement(string achievementId);

		bool ClearAllAchievements();
	}
}
