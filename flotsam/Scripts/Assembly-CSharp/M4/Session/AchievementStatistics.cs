using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace M4.Session
{
	[Serializable]
	public class AchievementStatistics : IStatistic
	{
		[NonSerialized]
		private IUser player;

		[SerializeField]
		private List<AchievementId> unlockedAchievementTable;

		public bool IsInitialized { get; private set; }

		public void Initialize(IUser player, UnityAction initialize_callback)
		{
			this.player = player;
			if (unlockedAchievementTable == null)
			{
				unlockedAchievementTable = new List<AchievementId>();
			}
			IsInitialized = true;
		}

		public bool IsAchievementUnlocked(AchievementId achievement_id)
		{
			return unlockedAchievementTable.Contains(achievement_id);
		}

		public bool UnlockAchievement(AchievementBase achievement)
		{
			return UnlockAchievement(achievement.Id);
		}

		public bool UnlockAchievement(AchievementId achievement_id)
		{
			if (unlockedAchievementTable.Contains(achievement_id))
			{
				return false;
			}
			unlockedAchievementTable.Add(achievement_id);
			return true;
		}
	}
}
