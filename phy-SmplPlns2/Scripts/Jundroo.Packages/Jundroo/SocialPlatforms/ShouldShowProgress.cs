using Jundroo.SocialPlatforms.Achievements;

namespace Jundroo.SocialPlatforms
{
	public delegate bool ShouldShowProgress(AchievementInfo achievementInfo, Achievement achievement, double previousStatValue, double newStatValue);
}
