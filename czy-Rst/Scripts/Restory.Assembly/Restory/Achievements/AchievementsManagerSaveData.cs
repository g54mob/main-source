using System;
using System.Collections.Generic;

namespace Restory.Achievements
{
	[Serializable]
	public class AchievementsManagerSaveData
	{
		public Dictionary<AchievementId, AchievementProgress> AchievementsProgress;
	}
}
