using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SessionQuestWatcher : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public SessionQuest challenge;

		internal bool _003CSetupWatchedChallenge_003Eb__0(WatchedSessionQuest x)
		{
			return x.SessionQuest == challenge;
		}
	}

	[SerializeField]
	private ElementGroupManager elementGroupManager;

	[SerializeField]
	private SessionQuestBar sessionQuestBar;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	private RewardLibrary rewardLibrary;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private VfxManager vfxManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	public List<WatchedSessionQuest> watchedSessionQuests = new List<WatchedSessionQuest>();

	private List<SessionQuest> lockedChallenges = new List<SessionQuest>();

	private SessionQuestFulfilledFX spawnedEffect;

	public ElementGroupManager ElementGroupManager => elementGroupManager;

	public RewardSystem RewardSystem => rewardSystem;

	public RewardLibrary RewardLibrary => rewardLibrary;

	public SessionQuestManager SessionQuestManager => sessionQuestManager;

	public void SetupWatchedChallenge(SessionQuest challenge, int watchLevel, bool effectWasWatched = false)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals9.challenge = challenge;
		watchLevel = ((watchLevel == -1) ? CS_0024_003C_003E8__locals9.challenge.CurrentLevelIndex : watchLevel);
		if (Enumerable.Count(watchedSessionQuests, (WatchedSessionQuest x) => x.SessionQuest == CS_0024_003C_003E8__locals9.challenge) > 0)
		{
			Debug.LogError($"tries to add watched session quest {CS_0024_003C_003E8__locals9.challenge} as duplicate!");
			return;
		}
		WatchedSessionQuest watchedSessionQuest = new WatchedSessionQuest(CS_0024_003C_003E8__locals9.challenge, watchLevel, effectWasWatched);
		watchedSessionQuests.Add(watchedSessionQuest);
		if (settingsRouter.defaultSettings.setupSessionQuestIngameDisplay)
		{
			sessionQuestBar.SetupDisplay(watchedSessionQuest, Singleton<RewardTileViewerManager>.Instance.GetTileViewer(CS_0024_003C_003E8__locals9.challenge));
		}
		if (CS_0024_003C_003E8__locals9.challenge.GetLevelState(watchLevel) != RewardState.Completed)
		{
			CS_0024_003C_003E8__locals9.challenge.StartWatching(this);
			for (int num = 0; num < 3; num++)
			{
			}
			CS_0024_003C_003E8__locals9.challenge.OnFulfillmentChanged += SessionQuestFulfillmentChanged;
		}
	}

	private void SessionQuestFulfillmentChanged(SessionQuest fulfilledSessionQuest, int fulfilledLevel)
	{
		if (fulfilledSessionQuest.GetLevelState(fulfilledLevel) == RewardState.Completed)
		{
			SessionQuestReward reward = fulfilledSessionQuest.GetLevel(fulfilledLevel).reward;
			rewardLibrary.UpdateRewardState(reward.id, RewardState.Completed, saveRewards: true);
			if (reward.unlockType == UnlockType.Biome)
			{
				Object.FindObjectOfType<CreativeModeConfigurationInitializer>().ApplyExcludedBiomes(initial: false);
			}
			vfxManager.AddSessionQuestEffectToQueue(fulfilledSessionQuest, fulfilledLevel, SessionQuestFxType.ChallengeFulfilled);
		}
	}

	private void OnDisable()
	{
		foreach (WatchedSessionQuest watchedSessionQuest in watchedSessionQuests)
		{
			watchedSessionQuest.SessionQuest.StopWatching();
			watchedSessionQuest.SessionQuest.OnFulfillmentChanged -= SessionQuestFulfillmentChanged;
		}
		foreach (SessionQuest lockedChallenge in lockedChallenges)
		{
			lockedChallenge.OnUnlocked -= SetupUnlockedChallenge;
		}
	}

	public void PrepareLockedChallenges(List<SessionQuest> lockedChallenges)
	{
		this.lockedChallenges = lockedChallenges;
		foreach (SessionQuest lockedChallenge in lockedChallenges)
		{
			lockedChallenge.OnUnlocked += SetupUnlockedChallenge;
		}
	}

	private void SetupUnlockedChallenge(SessionQuest unlockedChallenge)
	{
		Debug.Log($"Challenge {unlockedChallenge} was unlocked -> start watching");
		SetupWatchedChallenge(unlockedChallenge, unlockedChallenge.CurrentLevelIndex);
		sessionQuestBar.ReorderDisplays();
		lockedChallenges.Remove(unlockedChallenge);
		unlockedChallenge.OnUnlocked -= SetupUnlockedChallenge;
	}
}
