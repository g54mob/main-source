using System;

public static class SteamExtensions
{
	public static void TriggerSteam(this Achievement achievement)
	{
		achievement.Data().TriggerSteam();
	}

	public static void TriggerSteam(this AchievementData achievement)
	{
		if (achievement.steam && !string.IsNullOrEmpty(achievement.steamKey) && !SteamManager.Achievements.HasAchievement(achievement.steamKey))
		{
			SteamManager.Achievements.UnlockAchievement(achievement.steamKey);
		}
	}

	public static void IsAchievedSteam(this Achievement achievement)
	{
		achievement.Data().IsAchievedSteam();
	}

	public static bool IsAchievedSteam(this AchievementData achievement)
	{
		if (achievement.steam)
		{
			return SteamManager.Achievements.HasAchievement(achievement.steamKey);
		}
		return false;
	}

	public static void SetStatSteam(this Achievement achievement, double value)
	{
		achievement.Data().SetStatSteam(value);
	}

	public static void SetStatSteam(this AchievementData achievement, double value)
	{
		if (achievement.steam && !string.IsNullOrEmpty(achievement.steamStatKey))
		{
			switch (achievement.steamStatType)
			{
			case AchievementData.ValueType.Int:
				SteamManager.Stats.SetStatInt(achievement.steamStatKey, (int)Math.Round(value, 0, MidpointRounding.AwayFromZero));
				break;
			case AchievementData.ValueType.Float:
				SteamManager.Stats.SetStatFloat(achievement.steamStatKey, (float)Math.Round(value, 2, MidpointRounding.AwayFromZero));
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
