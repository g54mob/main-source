using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Achievements;
using Restory.UniversalPlatform;
using Restory.UniversalPlatform.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Achievements
{
	public sealed class AchievementsManager : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private AchievementsList achievementsList;

		private Dictionary<AchievementId, AchievementProgress> achievements = new Dictionary<AchievementId, AchievementProgress>();

		private PlatformAchievementsManager platformAchManager;

		private PlatformAchievementsManagerAchievementsReceivedObserver achievementsReceivedObserver;

		public AchievementsList AchievementsList => achievementsList;

		public event Action<Achievement> AchievementUnlocked;

		public event Action<Achievement> AchievementCleared;

		public event Action<Achievement> AchievementProgressChanged;

		[Inject]
		public void Construct(PlatformAchievementsManager platformAchManager, PlatformAchievementsManagerAchievementsReceivedObserver achievementsReceivedObserver)
		{
			this.achievementsReceivedObserver = achievementsReceivedObserver;
			this.platformAchManager = platformAchManager;
		}

		public void Initialize()
		{
			achievementsReceivedObserver.AddSubscriber(this, PlatformAchManager_AchievementsReceived);
			if (platformAchManager.IsInitialized)
			{
				UnlockAchievementsInPlatform();
			}
		}

		public void Dispose()
		{
			achievementsReceivedObserver.RemoveSubscriber(this);
		}

		public float GetAchievementProgress(Achievement achievement)
		{
			return GetOrCreateAchievementProgress(achievement).Progress;
		}

		private AchievementProgress GetOrCreateAchievementProgress(Achievement achievement)
		{
			return GetOrCreateAchievementProgress(achievement.Id);
		}

		private AchievementProgress GetOrCreateAchievementProgress(AchievementId achievementId)
		{
			if (!achievements.TryGetValue(achievementId, out var value))
			{
				value = new AchievementProgress();
				achievements[achievementId] = value;
			}
			return value;
		}

		public void AddProgressAchievement(Achievement achievement, float delta)
		{
			AchievementProgress orCreateAchievementProgress = GetOrCreateAchievementProgress(achievement);
			orCreateAchievementProgress.Progress = Math.Clamp(orCreateAchievementProgress.Progress + delta, achievement.MinValue, achievement.MaxValue);
			this.AchievementProgressChanged?.Invoke(achievement);
			if (orCreateAchievementProgress.Progress >= achievement.MaxValue)
			{
				UnlockAchievement(achievement);
			}
		}

		public void SetProgressAchievement(Achievement achievement, float value)
		{
			AchievementProgress orCreateAchievementProgress = GetOrCreateAchievementProgress(achievement);
			orCreateAchievementProgress.Progress = Math.Clamp(value, achievement.MinValue, achievement.MaxValue);
			this.AchievementProgressChanged?.Invoke(achievement);
			if (orCreateAchievementProgress.Progress >= achievement.MaxValue)
			{
				UnlockAchievement(achievement);
			}
		}

		public bool IsAchievementUnlocked(Achievement achievement)
		{
			if (achievements.TryGetValue(achievement.Id, out var value))
			{
				return value.IsUnlocked;
			}
			return false;
		}

		public void UnlockAchievement(Achievement achievement)
		{
			AchievementProgress orCreateAchievementProgress = GetOrCreateAchievementProgress(achievement);
			bool flag = !orCreateAchievementProgress.IsUnlocked;
			orCreateAchievementProgress.Progress = achievement.MaxValue;
			orCreateAchievementProgress.IsUnlocked = true;
			platformAchManager.UnlockAchievement(achievement.Id);
			if (flag)
			{
				Debug.Log($"UnlockAchievement = {achievement.Id}");
				this.AchievementProgressChanged?.Invoke(achievement);
				this.AchievementUnlocked?.Invoke(achievement);
			}
		}

		public void ClearAchievement(Achievement achievement)
		{
			bool num = achievements.Remove(achievement.Id);
			platformAchManager.LockAchievement(achievement.Id);
			if (num)
			{
				Debug.Log($"ClearAchievement = {achievement.Id}");
				this.AchievementProgressChanged?.Invoke(achievement);
				this.AchievementCleared?.Invoke(achievement);
			}
		}

		public AchievementsManagerSaveData GetSaveData()
		{
			return new AchievementsManagerSaveData
			{
				AchievementsProgress = achievements.ToDictionary((KeyValuePair<AchievementId, AchievementProgress> k) => k.Key, (KeyValuePair<AchievementId, AchievementProgress> v) => v.Value)
			};
		}

		public void SetSaveData(AchievementsManagerSaveData saveData)
		{
			if (saveData == null || saveData.AchievementsProgress == null)
			{
				achievements.Clear();
			}
			else
			{
				achievements = new Dictionary<AchievementId, AchievementProgress>(saveData.AchievementsProgress);
			}
			UnlockAchievementsInPlatform();
		}

		private void UnlockAchievementsInPlatform()
		{
			foreach (KeyValuePair<AchievementId, AchievementProgress> achievement in achievements)
			{
				if (achievement.Value.IsUnlocked)
				{
					platformAchManager.UnlockAchievement(achievement.Key);
				}
			}
		}

		private void PlatformAchManager_AchievementsReceived()
		{
			UnlockAchievementsInPlatform();
		}
	}
}
