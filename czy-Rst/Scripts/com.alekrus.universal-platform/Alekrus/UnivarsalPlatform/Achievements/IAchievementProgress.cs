using System;

namespace Alekrus.UnivarsalPlatform.Achievements
{
	public interface IAchievementProgress
	{
		AchievementId Id { get; }

		bool IsUnlocked { get; }

		DateTime UnlockTime { get; }

		double Progress { get; }
	}
}
