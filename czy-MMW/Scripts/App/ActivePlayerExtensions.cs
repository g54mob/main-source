using System;

public static class ActivePlayerExtensions
{
	public static bool IsAchievementCompleted(this IActivePlayer player, Enum achievementIdEnum)
	{
		AchievementDefinition achievementDefinition = player.Scope.Get<AchievementDatabase>()[achievementIdEnum];
		if (achievementDefinition != null)
		{
			return player.IsAchievementCompleted(achievementDefinition);
		}
		return false;
	}

	public static bool IsAchievementCompleted(this IActivePlayer player, string achievementId)
	{
		AchievementDefinition achievementDefinition = player.Scope.Get<AchievementDatabase>()[achievementId];
		if (achievementDefinition != null)
		{
			return player.IsAchievementCompleted(achievementDefinition);
		}
		return false;
	}

	public static void CompleteAchievement(this IActivePlayer player, Enum achievementIdEnum)
	{
		AchievementDefinition achievementDefinition = player.Scope.Get<AchievementDatabase>()[achievementIdEnum];
		if (achievementDefinition != null)
		{
			player.CompleteAchievement(achievementDefinition, showNotification: true);
		}
	}

	public static void CompleteAchievement(this IActivePlayer player, string achievementId)
	{
		AchievementDefinition achievementDefinition = player.Scope.Get<AchievementDatabase>()[achievementId];
		if (achievementDefinition != null)
		{
			player.CompleteAchievement(achievementDefinition, showNotification: true);
		}
	}
}
