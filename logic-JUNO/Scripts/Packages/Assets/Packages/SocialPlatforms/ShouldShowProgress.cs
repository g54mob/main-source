using Assets.Packages.SocialPlatforms.Achievements;

namespace Assets.Packages.SocialPlatforms
{
	public delegate bool ShouldShowProgress(AchievementInfo achievementInfo, Achievement achievement, double previousStatValue, double newStatValue);
}
