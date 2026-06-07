using System.Collections.Generic;

namespace FractureField.Achievements
{
	public class AchievementManager : AchievementManagerSaveData, ISaveData<AchievementManager, AchievementManagerSaveData>
	{
		public List<Achievement> Achievements { get; }

		public Queue<Achievement> NewlyCompletedAchievements { get; }

		public AchievementManager Load()
		{
			return null;
		}

		public AchievementManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		private void OnGameRestart()
		{
		}
	}
}
