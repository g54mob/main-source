using System;
using Galaxy.Api;
using Helpers;
using UnityEngine;

public class GogAchievementManager : MonoBehaviour
{
	private class UserStatsAndAchievementsRetrieveListener : GlobalUserStatsAndAchievementsRetrieveListener
	{
		public bool retrieved;

		public event Action OnStatsRetrievedSuccessfully;

		public override void OnUserStatsAndAchievementsRetrieveSuccess(GalaxyID userID)
		{
			retrieved = true;
			Debug.Log("User " + ((object)userID)?.ToString() + " stats and achievements retrieved");
			this.OnStatsRetrievedSuccessfully?.Invoke();
		}

		public unsafe override void OnUserStatsAndAchievementsRetrieveFailure(GalaxyID userID, FailureReason failureReason)
		{
			retrieved = false;
			Debug.LogWarning("User " + ((object)userID)?.ToString() + " stats and achievements could not be retrieved, for reason " + ((object)(*(FailureReason*)(&failureReason))/*cast due to .constrained prefix*/).ToString());
		}
	}

	private class StatsAndAchievementsStoreListener : GlobalStatsAndAchievementsStoreListener
	{
		public unsafe override void OnUserStatsAndAchievementsStoreFailure(FailureReason failureReason)
		{
			Debug.LogWarning("OnUserStatsAndAchievementsStoreFailure: " + ((object)(*(FailureReason*)(&failureReason))/*cast due to .constrained prefix*/).ToString());
		}

		public override void OnUserStatsAndAchievementsStoreSuccess()
		{
		}
	}

	private class AchievementChangeListener : GlobalAchievementChangeListener
	{
		public override void OnAchievementUnlocked(string name)
		{
		}
	}

	[SerializeField]
	private RewardLibrary rewardLibrary;

	[SerializeField]
	private bool unlockLocallyUnlockdAchievementsOnStart;

	private UserStatsAndAchievementsRetrieveListener achievementRetrieveListener;

	private AchievementChangeListener achievementChangeListener;

	private StatsAndAchievementsStoreListener achievementStoreListener;

	private void Start()
	{
		rewardLibrary.OnRewardUnlocked += UnlockAchievement;
		GalaxyManager.OnSignInSuccessful += InitializeStatsAndAchievements;
	}

	private void InitializeStatsAndAchievements()
	{
		ListenersInit();
		if (unlockLocallyUnlockdAchievementsOnStart)
		{
			achievementRetrieveListener.OnStatsRetrievedSuccessfully += UnlockLocallyUnlockedAchievements;
		}
		GalaxyInstance.Stats().RequestUserStatsAndAchievements();
	}

	private void UnlockLocallyUnlockedAchievements()
	{
		achievementRetrieveListener.OnStatsRetrievedSuccessfully -= UnlockLocallyUnlockedAchievements;
		foreach (SessionQuestReward allReward in rewardLibrary.allRewards)
		{
			if (allReward.state == RewardState.Completed)
			{
				UnlockAchievement(allReward.id);
			}
		}
	}

	private void ListenersInit()
	{
		Listener.Create(ref achievementRetrieveListener);
		Listener.Create(ref achievementChangeListener);
		Listener.Create(ref achievementStoreListener);
	}

	private void ListenersDispose()
	{
		achievementRetrieveListener.OnStatsRetrievedSuccessfully -= UnlockLocallyUnlockedAchievements;
		Listener.Dispose<StatsAndAchievementsStoreListener>(ref achievementStoreListener);
		Listener.Dispose<UserStatsAndAchievementsRetrieveListener>(ref achievementRetrieveListener);
		Listener.Dispose<AchievementChangeListener>(ref achievementChangeListener);
	}

	private void UnlockAchievement(string achievementId)
	{
		//IL_0031: Expected O, but got Unknown
		if (!GalaxyManager.Instance.IsSignedIn(silent: true))
		{
			Debug.LogWarning("GalaxyManager is not initialized");
			return;
		}
		try
		{
			GalaxyInstance.Stats().SetAchievement(achievementId);
			GalaxyInstance.Stats().StoreStatsAndAchievements();
		}
		catch (Error val)
		{
			Debug.LogWarning("Achievement " + achievementId + " could not be unlocked for reason: " + (object)val);
		}
	}

	private void LockAchievement(string achievementId)
	{
		//IL_0031: Expected O, but got Unknown
		if (!GalaxyManager.Instance.IsSignedIn(silent: true))
		{
			Debug.LogWarning("GalaxyManager is not initialized");
			return;
		}
		try
		{
			GalaxyInstance.Stats().ClearAchievement(achievementId);
			GalaxyInstance.Stats().StoreStatsAndAchievements();
		}
		catch (Error val)
		{
			Debug.LogWarning("Achievement " + achievementId + " could not be locked for reason: " + (object)val);
		}
	}

	private void OnDestroy()
	{
		ListenersDispose();
		rewardLibrary.OnRewardUnlocked -= UnlockAchievement;
		GalaxyManager.OnSignInSuccessful -= InitializeStatsAndAchievements;
	}
}
