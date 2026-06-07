using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Achievements
{
	public class BaseGame_CustomAchivementHandleing : ICustomAchievements
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

		private bool CheckForStage6Achievement(PlayerOptions playerOptions)
		{
			return false;
		}

		private bool CheckSigmaUnlock(PlayerOptions playerOptions)
		{
			return false;
		}

		public int CountKilledEnemiesAndVariants(EnemyType enemyType, PlayerOptions playerOptions, DataManager dataManager)
		{
			return 0;
		}
	}
}
