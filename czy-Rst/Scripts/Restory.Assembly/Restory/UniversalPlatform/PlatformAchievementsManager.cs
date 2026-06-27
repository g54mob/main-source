using System;
using Alekrus.UnivarsalPlatform.Achievements;
using Alekrus.UnivarsalPlatform.UserProfiles;
using Restory.Achievements;
using Restory.UniversalPlatform.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UniversalPlatform
{
	public sealed class PlatformAchievementsManager : MonoBehaviour, IInitializable, IDisposable
	{
		private IAchievements achievements;

		private ILocalUserProfiles profiles;

		private PlatformManager platformManager;

		private PlatformAchievementsManagerInitializationObserver managerInitializationObserver;

		public bool IsInitialized
		{
			get
			{
				if (achievements != null)
				{
					return achievements.IsInitialized;
				}
				return false;
			}
		}

		public event Action Initialized;

		public event Action AchievementsReceived;

		[Inject]
		public void Construct(PlatformAchievementsManagerInitializationObserver managerInitializationObserver, PlatformManager platformManager)
		{
			this.platformManager = platformManager;
			this.managerInitializationObserver = managerInitializationObserver;
		}

		public void Initialize()
		{
			managerInitializationObserver.AddSubscriber(this, PlatformManager_ProfileInitialized);
			if (platformManager.ProfilesIsInitialized)
			{
				PlatformManager_ProfileInitialized();
			}
		}

		public void Dispose()
		{
			managerInitializationObserver.RemoveSubscriber(this);
			if (achievements != null)
			{
				achievements.Initialized -= Achievements_Initialized;
				achievements.AchievementsProgressReceived -= Achievements_AchievementsProgressReceived;
				achievements.Shutdown();
			}
		}

		public void UnlockAchievement(Restory.Achievements.AchievementId parId)
		{
			achievements?.UnlockAchievement(profiles.GetPrimaryLocalUserId(), new Alekrus.UnivarsalPlatform.Achievements.AchievementId(parId.ToString()));
		}

		public void LockAchievement(Restory.Achievements.AchievementId parId)
		{
			achievements?.LockAchievement(profiles.GetPrimaryLocalUserId(), new Alekrus.UnivarsalPlatform.Achievements.AchievementId(parId.ToString()));
		}

		private void PlatformManager_ProfileInitialized()
		{
			profiles = platformManager.GetSubInterface<ILocalUserProfiles>();
			achievements = platformManager.GetSubInterface<IAchievements>();
			if (achievements != null)
			{
				achievements.Initialized += Achievements_Initialized;
				achievements.AchievementsProgressReceived += Achievements_AchievementsProgressReceived;
				achievements.Initialize();
			}
		}

		private void Achievements_Initialized()
		{
			this.Initialized?.Invoke();
			achievements.RequestAchievementsInfo(profiles.GetPrimaryLocalUserId());
			achievements.RequestAchievementsProgress(profiles.GetPrimaryLocalUserId());
		}

		private void Achievements_AchievementsProgressReceived(AchievementsProgressReceivedArgs parArgs)
		{
			if (!parArgs.Result.IsSuccess())
			{
				return;
			}
			foreach (IAchievementProgress item in achievements.GetAchievementsProgress(profiles.GetPrimaryLocalUserId()))
			{
				Debug.Log($"Achievement Received: {item.Id} IsUnlocked = {item.IsUnlocked}({item.UnlockTime}");
			}
			this.AchievementsReceived?.Invoke();
		}
	}
}
