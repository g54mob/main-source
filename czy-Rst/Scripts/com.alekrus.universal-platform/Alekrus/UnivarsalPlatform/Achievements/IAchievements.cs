using System.Collections.Generic;

namespace Alekrus.UnivarsalPlatform.Achievements
{
	public interface IAchievements : IInitializable, ISubInterface<IMain>
	{
		event AchievementsInfoReceivedEventHandler AchievementsInfoReceived;

		event AchievementsProgressReceivedEventHandler AchievementsProgressReceived;

		event AchievementUnlockedEventHandler AchievementUnlocked;

		int GetAchievementsCount();

		IEnumerable<IAchievementInfo> GetAchievementsInfo();

		IAchievementInfo GetAchievementInfo(AchievementId parAchievementId);

		IEnumerable<IAchievementProgress> GetAchievementsProgress(ILocalUserId parUserId);

		IAchievementProgress GetAchievementProgress(ILocalUserId parUserId, AchievementId parAchievementId);

		bool RequestAchievementsInfo(ILocalUserId parUserId);

		bool RequestAchievementsProgress(ILocalUserId parUserId);

		bool UnlockAchievement(ILocalUserId parUserId, AchievementId parAchievementId);

		bool LockAchievement(ILocalUserId parUserId, AchievementId parAchievementId);
	}
}
