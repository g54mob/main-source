using System;

namespace VampireSurvivors.Achievements
{
	[Flags]
	public enum AchievementPlatform
	{
		Generic = 1,
		Steam = 2,
		GameCorePC = 4,
		GameCoreXboxOne = 8,
		GameCoreXboxSeries = 0x10,
		GameCore = 0x1C,
		PS4 = 0x20,
		PS5 = 0x40
	}
}
