using System;
using System.Collections.Generic;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;

namespace VampireSurvivors
{
	public interface IPlatformAchievementsManager : ILastErrorProvider
	{
		AchievementsManagerState State { get; }

		void InitAsync(Dictionary<AchievementType, AchievementData> readonly_achievementDefinitions, List<AchievementType> inout_Completed, Action<bool, List<AchievementType>> onComplete);

		void ReportProgressAsync(AchievementType id, float newprogress = 1f, Action<AchievementType, bool> onComplete = null);

		void Close();
	}
}
