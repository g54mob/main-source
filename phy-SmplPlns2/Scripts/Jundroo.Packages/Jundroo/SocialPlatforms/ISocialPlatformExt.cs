using System;
using Jundroo.SocialPlatforms.Achievements;

namespace Jundroo.SocialPlatforms
{
	public interface ISocialPlatformExt : ISocialPlatform
	{
		bool LoggedOn { get; }

		string PlatformName { get; }

		void IncrementAchievement(string achievementID, int incrementAmount, bool showProgress, Action<bool> callback);

		void IncrementAchievement(string achievementID, float incrementAmount, bool showProgress, Action<bool> callback);

		void IncrementStat(string statID, int incrementAmount, ShouldShowProgress showProgress, Action<bool> callback);

		void IncrementStat(string statID, float incrementAmount, ShouldShowProgress showProgress, Action<bool> callback);

		void Initialize(AchievementDatabase achievementDatabase);

		void ResetAllAchievements();
	}
}
