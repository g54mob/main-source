using System;
using System.Collections.Generic;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;

namespace VampireSurvivors
{
	public class DummyAchievementsManager : IPlatformAchievementsManager, ILastErrorProvider
	{
		private AchievementsManagerState m_State;

		public ErroInfo LastError => default(ErroInfo);

		public AchievementsManagerState State => default(AchievementsManagerState);

		public void Close()
		{
		}

		public void InitAsync(Dictionary<AchievementType, AchievementData> readonly_achievementDefinitions, List<AchievementType> inout_Completed, Action<bool, List<AchievementType>> onComplete)
		{
		}

		public void ReportProgressAsync(AchievementType id, float newprogress = 1f, Action<AchievementType, bool> onComplete = null)
		{
		}
	}
}
