using System;

namespace Timberborn.AchievementSystem
{
	public interface IStoreAchievements
	{
		void Initialize(Action successCallback);

		bool IsAchievementUnlocked(string achievementId);

		void UnlockAchievement(string achievementId);
	}
}
