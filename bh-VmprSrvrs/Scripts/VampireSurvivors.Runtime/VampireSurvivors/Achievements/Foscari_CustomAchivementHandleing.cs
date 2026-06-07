using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Achievements
{
	public class Foscari_CustomAchivementHandleing : ICustomAchievements
	{
		public List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager)
		{
			return null;
		}

		public List<AchievementType> GetUnlocksThatNeedFixing(PlayerOptions playerOptions)
		{
			return null;
		}

		public List<AchievementType> CheckForStartupAchievements(PlayerOptions playerOptions)
		{
			return null;
		}

		public void RunSecretsCheck(AchievementManager achievementManager, PlayerOptions playerOptions, DataManager dataManager)
		{
		}

		private int GetDestroyCount(PlayerOptions playerOptions, PropType t)
		{
			return 0;
		}
	}
}
