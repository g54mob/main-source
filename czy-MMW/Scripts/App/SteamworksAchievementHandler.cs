public class SteamworksAchievementHandler : IAchievementHandler
{
	public void OnAppStart()
	{
	}

	public bool CompleteAchievement(Achievement achievement, bool showNotification)
	{
		AchievementDefinition definition = achievement.Definition;
		if (definition == null)
		{
			return false;
		}
		if (!definition.TryGetStringDataForPlatformAndKey(AchievementData.AchievementPlatform.Steamworks, AchievementData.AchievementDataType.PlatformId, out var result))
		{
			return false;
		}
		return SteamworksShared.CompleteAchievement(result);
	}

	public bool IsAchievementCompleted(AchievementDefinition achievement)
	{
		if (!achievement.TryGetStringDataForPlatformAndKey(AchievementData.AchievementPlatform.Steamworks, AchievementData.AchievementDataType.PlatformId, out var result))
		{
			return false;
		}
		return SteamworksShared.IsAchievementCompleted(result);
	}

	public bool IncrementStatistic(string statisticId, int increment)
	{
		if (increment > 0)
		{
			return SteamworksShared.IncrementStatistic(statisticId, increment);
		}
		return true;
	}
}
