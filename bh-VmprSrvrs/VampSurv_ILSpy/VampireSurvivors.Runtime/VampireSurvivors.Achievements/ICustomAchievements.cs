using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Achievements;

public interface ICustomAchievements
{
	List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager);

	List<AchievementType> GetUnlocksThatNeedFixing(PlayerOptions playerOptions);

	List<AchievementType> CheckForStartupAchievements(PlayerOptions playerOptions);

	void RunSecretsCheck(AchievementManager achievementManager, PlayerOptions playerOptions, DataManager dataManager);
}
