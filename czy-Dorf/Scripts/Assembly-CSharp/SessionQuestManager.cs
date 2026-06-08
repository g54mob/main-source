using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class SessionQuestManager : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<SessionQuest, bool> _003C_003E9__14_0;

		public static Func<SessionQuest, bool> _003C_003E9__17_0;

		public static Func<SessionQuest, bool> _003C_003E9__18_0;

		public static Func<SessionQuest, bool> _003C_003E9__18_1;

		public static Func<SessionQuest, int> _003C_003E9__18_2;

		public static Func<SessionQuest, bool> _003C_003E9__24_0;

		public static Func<SessionQuest, string> _003C_003E9__24_1;

		public static Func<SessionQuest, ChallengeId> _003C_003E9__26_0;

		internal bool _003CSelectablePassiveChallenges_003Eb__14_0(SessionQuest x)
		{
			if (x.compositeParentQuest == null && x.CurrentState == RewardState.InProgress && x.SelectableInClassicMode)
			{
				return x.Passive;
			}
			return false;
		}

		internal bool _003CLockedChallenges_003Eb__17_0(SessionQuest x)
		{
			if (x.compositeParentQuest == null && x.CurrentState == RewardState.Hidden)
			{
				return x.SelectableInClassicMode;
			}
			return false;
		}

		internal bool _003CSelectPrioritySessionQuest_003Eb__18_0(SessionQuest x)
		{
			return x.priorityQuest;
		}

		internal bool _003CSelectPrioritySessionQuest_003Eb__18_1(SessionQuest x)
		{
			return x.priorityQuest;
		}

		internal int _003CSelectPrioritySessionQuest_003Eb__18_2(SessionQuest x)
		{
			return x.CurrentLevelIndex;
		}

		internal bool _003CUpdateOrder_003Eb__24_0(SessionQuest x)
		{
			return x.CurrentState != RewardState.Hidden;
		}

		internal string _003CUpdateOrder_003Eb__24_1(SessionQuest x)
		{
			return x.GetTitle(-1, showLevel: true, addNoBreakTags: false);
		}

		internal ChallengeId _003CUnlockAllChallenges_003Eb__26_0(SessionQuest x)
		{
			return x.id;
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public int lowestLevel;

		internal bool _003CSelectPrioritySessionQuest_003Eb__3(SessionQuest x)
		{
			return x.CurrentLevelIndex == lowestLevel;
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public SessionQuest challenge;

		internal bool _003CUpdateSessionQuestData_003Eb__0(ChallengeData_002 x)
		{
			return x.id == challenge.id;
		}

		internal bool _003CUpdateSessionQuestData_003Eb__1(ChallengeData_002 x)
		{
			return x.id == challenge.id;
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public ChallengeId challengeId;

		internal bool _003CBuildReset_003Eb__0(SessionQuest x)
		{
			return x.id == challengeId;
		}
	}

	public List<SessionQuest> sessionQuests;

	private Dictionary<ChallengeId, SessionQuest> sessionQuestById;

	[SerializeField]
	private ChallengeCollectionData_002 challengeCollectionData;

	[SerializeField]
	private SessionQuestsData debug_oldChallengeData;

	[SerializeField]
	private List<SessionQuestReward> unlockedRewards;

	public List<SessionQuest> activeSessionQuests;

	[FormerlySerializedAs("saveGameManager")]
	public SaveFileManager saveFileManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	public event Action OnActiveQuestChanged;

	public event Action OnOrderUpdated;

	public List<SessionQuest> SelectablePassiveChallenges()
	{
		return Enumerable.ToList(Enumerable.Where(sessionQuests, (SessionQuest x) => x.compositeParentQuest == null && x.CurrentState == RewardState.InProgress && x.SelectableInClassicMode && x.Passive));
	}

	public SuccessStatus Setup()
	{
		sessionQuestById = new Dictionary<ChallengeId, SessionQuest>();
		foreach (SessionQuest sessionQuest in sessionQuests)
		{
			sessionQuestById.Add(sessionQuest.id, sessionQuest);
		}
		SuccessStatus result = LoadSessionQuestStates();
		UpdateOrder();
		return result;
	}

	public SessionQuest GetSessionQuest(ChallengeId id)
	{
		return sessionQuestById[id];
	}

	public List<SessionQuest> LockedChallenges()
	{
		return Enumerable.ToList(Enumerable.Where(sessionQuests, (SessionQuest x) => x.compositeParentQuest == null && x.CurrentState == RewardState.Hidden && x.SelectableInClassicMode));
	}

	private SessionQuest SelectPrioritySessionQuest(List<SessionQuest> validSessionQuests)
	{
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass18_0();
		if (Enumerable.Count(validSessionQuests, (SessionQuest x) => x.priorityQuest) > 0)
		{
			return Enumerable.First(validSessionQuests, (SessionQuest x) => x.priorityQuest);
		}
		CS_0024_003C_003E8__locals3.lowestLevel = Enumerable.Min(validSessionQuests, (SessionQuest x) => x.CurrentLevelIndex);
		List<SessionQuest> list = ((CS_0024_003C_003E8__locals3.lowestLevel == 0) ? Enumerable.ToList(Enumerable.Where(validSessionQuests, (SessionQuest x) => x.CurrentLevelIndex == CS_0024_003C_003E8__locals3.lowestLevel)) : validSessionQuests);
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	private SuccessStatus LoadSessionQuestStates()
	{
		challengeCollectionData = BinarySaveLoad.LoadFromBinary<ChallengeCollectionData_002>("SessionQuests01.sav", out var successStatus);
		if (successStatus == SuccessStatus.Failed)
		{
			Debug.Log($"Loading ChallengeData_002: {successStatus}");
			SuccessStatus successStatus2;
			SessionQuestsData oldData = BinarySaveLoad.LoadFromBinary<SessionQuestsData>("SessionQuests01.sav", out successStatus2);
			Debug.Log($"Loading SessionQuestsData: {successStatus2}");
			debug_oldChallengeData = oldData;
			if (successStatus2 == SuccessStatus.Success)
			{
				challengeCollectionData = new ChallengeCollectionData_002(oldData);
			}
			successStatus = successStatus2;
		}
		if (challengeCollectionData == null)
		{
			Debug.Log("Loaded Data is null, creating new one");
			challengeCollectionData = new ChallengeCollectionData_002();
		}
		foreach (ChallengeData_002 challenge in challengeCollectionData.challenges)
		{
			if (!sessionQuestById.ContainsKey(challenge.id))
			{
				Debug.LogError($"no entry for session quest {challenge.id}");
			}
			else
			{
				sessionQuestById[challenge.id].LoadFromData(challenge);
			}
		}
		return successStatus;
	}

	public void UpdateSessionQuestData(SessionQuest challenge, bool save)
	{
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals8.challenge = challenge;
		if (Enumerable.Count(challengeCollectionData.challenges, (ChallengeData_002 x) => x.id == CS_0024_003C_003E8__locals8.challenge.id) == 0)
		{
			challengeCollectionData.challenges.Add(new ChallengeData_002(CS_0024_003C_003E8__locals8.challenge));
		}
		ChallengeData_002 challengeData_ = Enumerable.First(challengeCollectionData.challenges, (ChallengeData_002 x) => x.id == CS_0024_003C_003E8__locals8.challenge.id);
		challengeData_.currentProgress = CS_0024_003C_003E8__locals8.challenge.currentProgress;
		challengeData_.currentLevel = CS_0024_003C_003E8__locals8.challenge.CurrentLevelIndex;
		challengeData_.state = (int)CS_0024_003C_003E8__locals8.challenge.CurrentState;
		challengeData_.pinned = CS_0024_003C_003E8__locals8.challenge.isPinned;
		if (save && settingsRouter.defaultSettings.saveChallengesAndRewardsWhenUpdated)
		{
			SaveSessionQuestData();
		}
	}

	public void SaveSessionQuestData()
	{
		BinarySaveLoad.SaveAsBinary(challengeCollectionData, "SessionQuests01.sav");
	}

	public void ChangeSelectedQuest(SessionQuest previouslySelected, SessionQuest newSelected)
	{
		int num = activeSessionQuests.IndexOf(previouslySelected);
		Debug.Log($"looking for index of {previouslySelected}: {num}");
		activeSessionQuests[num] = newSelected;
		PlayerPrefsAccessor.SetInt(Constants.PlayerPrefKeys.SelectedSessionQuests[num], (int)((activeSessionQuests.Count > num) ? newSelected.id : ((ChallengeId)(-1))));
		this.OnActiveQuestChanged?.Invoke();
	}

	public void AddSelectedQuest(SessionQuest sessionQuest)
	{
		if (!activeSessionQuests.Contains(sessionQuest))
		{
			if (activeSessionQuests.Count >= 3)
			{
				activeSessionQuests.RemoveAt(0);
			}
			activeSessionQuests.Add(sessionQuest);
			for (int i = 0; i < Constants.PlayerPrefKeys.SelectedSessionQuests.Length; i++)
			{
				PlayerPrefsAccessor.SetInt(Constants.PlayerPrefKeys.SelectedSessionQuests[i], (int)((activeSessionQuests.Count > i) ? activeSessionQuests[i].id : ((ChallengeId)(-1))));
			}
			this.OnActiveQuestChanged?.Invoke();
		}
	}

	public void UpdateOrder()
	{
		sessionQuests = Enumerable.ToList(Enumerable.ThenBy(Enumerable.OrderByDescending(sessionQuests, (SessionQuest x) => x.CurrentState != RewardState.Hidden), (SessionQuest x) => x.GetTitle(-1, showLevel: true, addNoBreakTags: false)));
		this.OnOrderUpdated?.Invoke();
	}

	public void ResetAllChallenges()
	{
		BuildReset();
		foreach (SessionQuest sessionQuest in sessionQuests)
		{
			UpdateSessionQuestData(sessionQuest, save: false);
		}
		SaveSessionQuestData();
	}

	public void UnlockAllChallenges()
	{
		BuildReset(null, Enumerable.ToList(Enumerable.Select(sessionQuests, (SessionQuest x) => x.id)));
		foreach (SessionQuest sessionQuest in sessionQuests)
		{
			UpdateSessionQuestData(sessionQuest, save: false);
		}
		SaveSessionQuestData();
	}

	public void CompleteAllChallenges()
	{
		foreach (SessionQuest sessionQuest in sessionQuests)
		{
			sessionQuest.SetCurrentLevelIndex(sessionQuest.LevelCount);
			UpdateSessionQuestData(sessionQuest, save: false);
		}
		SaveSessionQuestData();
	}

	public void BuildReset(List<SessionQuestReward> unlockRewards = null, List<ChallengeId> unlockChallenges = null)
	{
		foreach (SessionQuest sessionQuest in sessionQuests)
		{
			sessionQuest.HardResetProgress();
		}
		if (unlockChallenges == null)
		{
			unlockChallenges = new List<ChallengeId>
			{
				ChallengeId.Composite_Windmill,
				ChallengeId.Champion,
				ChallengeId.Landscaper,
				ChallengeId.Engineer,
				ChallengeId.Ocean,
				ChallengeId.Overachiever
			};
		}
		using (List<ChallengeId>.Enumerator enumerator2 = unlockChallenges.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass28_0();
				CS_0024_003C_003E8__locals2.challengeId = enumerator2.Current;
				Enumerable.First(sessionQuests, (SessionQuest x) => x.id == CS_0024_003C_003E8__locals2.challengeId).Unlock();
			}
		}
		unlockedRewards.Clear();
		if (unlockRewards == null)
		{
			return;
		}
		foreach (SessionQuestReward unlockReward in unlockRewards)
		{
			unlockReward.state = RewardState.Completed;
		}
		unlockedRewards = new List<SessionQuestReward>(unlockRewards);
	}

	public void SetupFromLoadedRewards(List<SessionQuestReward> allLoadedRewards)
	{
		foreach (SessionQuestReward allLoadedReward in allLoadedRewards)
		{
			if (allLoadedReward.state != RewardState.Completed)
			{
				continue;
			}
			if ((bool)allLoadedReward.compositeSessionQuest && !unlockedRewards.Contains(allLoadedReward))
			{
				if (allLoadedReward.compositeSessionQuest.CurrentLevelIndex < allLoadedReward.compositeLevel + 1)
				{
					allLoadedReward.compositeSessionQuest.SetCurrentLevelIndex(allLoadedReward.compositeLevel + 1);
				}
			}
			else if ((bool)allLoadedReward.sessionQuest && !unlockedRewards.Contains(allLoadedReward) && allLoadedReward.sessionQuest.CurrentLevelIndex < allLoadedReward.rewardLevel + 1)
			{
				allLoadedReward.sessionQuest.SetCurrentLevelIndex(allLoadedReward.rewardLevel + 1);
			}
		}
		UpdateOrder();
	}
}
