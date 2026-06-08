using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardLibrary : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public string id;

		internal bool _003CUpdateRewardState_003Eb__0(RewardData x)
		{
			return x.id == id;
		}

		internal bool _003CUpdateRewardState_003Eb__1(RewardData x)
		{
			return x.id == id;
		}
	}

	public List<SessionQuestReward> allRewards;

	private Dictionary<string, SessionQuestReward> rewardById;

	[SerializeField]
	private RewardsData rewardData;

	[SerializeField]
	private SettingsRouter settingsRouter;

	public event Action<string> OnRewardUnlocked;

	public SuccessStatus Setup()
	{
		rewardById = new Dictionary<string, SessionQuestReward>();
		foreach (SessionQuestReward allReward in allRewards)
		{
			rewardById.Add(allReward.id, allReward);
		}
		return LoadRewardStates();
	}

	public void UpdateRewardState(string id, RewardState newState, bool saveRewards)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals6.id = id;
		rewardById[CS_0024_003C_003E8__locals6.id].state = newState;
		if (Enumerable.Count(rewardData.rewards, (RewardData x) => x.id == CS_0024_003C_003E8__locals6.id) == 0)
		{
			rewardData.rewards.Add(new RewardData(CS_0024_003C_003E8__locals6.id, newState));
		}
		else
		{
			Enumerable.First(rewardData.rewards, (RewardData x) => x.id == CS_0024_003C_003E8__locals6.id).SetState(newState);
		}
		if (saveRewards && settingsRouter.defaultSettings.saveChallengesAndRewardsWhenUpdated)
		{
			SaveRewardStates();
		}
		if (newState == RewardState.Completed)
		{
			this.OnRewardUnlocked?.Invoke(CS_0024_003C_003E8__locals6.id);
		}
	}

	private void UnlockAllRewards()
	{
		foreach (SessionQuestReward allReward in allRewards)
		{
			UpdateRewardState(allReward.id, RewardState.Completed, saveRewards: true);
		}
	}

	public void SaveRewardStates()
	{
		BinarySaveLoad.SaveAsBinary(rewardData, "Rewards01.sav");
	}

	private SuccessStatus LoadRewardStates()
	{
		rewardData = BinarySaveLoad.LoadFromBinary<RewardsData>("Rewards01.sav", out var successStatus) ?? new RewardsData();
		foreach (RewardData reward in rewardData.rewards)
		{
			if (rewardById.ContainsKey(reward.id))
			{
				rewardById[reward.id].state = (RewardState)reward.state;
			}
		}
		return successStatus;
	}

	public void SetupFromLoadedChallenges(List<SessionQuest> sessionQuests)
	{
		foreach (SessionQuest sessionQuest in sessionQuests)
		{
			if ((bool)sessionQuest.compositeParentQuest)
			{
				continue;
			}
			for (int i = 0; i < sessionQuest.LevelCount; i++)
			{
				if (sessionQuest.GetLevelState(i) == RewardState.Completed)
				{
					sessionQuest.GetLevel(i).reward.state = RewardState.Completed;
				}
			}
		}
	}

	public void RestoreRewardsFromChallenge(SessionQuest challenge)
	{
		for (int i = 0; i < challenge.LevelCount; i++)
		{
			RewardState newState = ((challenge.CurrentLevelIndex > i) ? RewardState.Completed : RewardState.Hidden);
			UpdateRewardState(challenge.GetLevel(i).reward.id, newState, saveRewards: false);
		}
		if (settingsRouter.defaultSettings.saveChallengesAndRewardsWhenUpdated)
		{
			SaveRewardStates();
		}
	}
}
