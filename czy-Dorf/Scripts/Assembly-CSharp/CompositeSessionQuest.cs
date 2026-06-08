using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class CompositeSessionQuest : SessionQuest
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<SessionQuest, bool> _003C_003E9__17_0;

		public static Func<SessionQuest, bool> _003C_003E9__17_1;

		public static Func<SessionQuest, bool> _003C_003E9__22_0;

		internal bool _003CGetActiveChildSessionQuest_003Eb__17_0(SessionQuest x)
		{
			return x.CurrentState != RewardState.Completed;
		}

		internal bool _003CGetActiveChildSessionQuest_003Eb__17_1(SessionQuest x)
		{
			return x.CurrentState != RewardState.Completed;
		}

		internal bool _003COnValidate_003Eb__22_0(SessionQuest x)
		{
			return x is CompositeSessionQuest;
		}
	}

	[SerializeField]
	[FormerlySerializedAs("partSessionQuests")]
	private List<SessionQuest> childSessionQuests;

	public override bool SelectableInClassicMode => GetActiveChildSessionQuest().SelectableInClassicMode;

	public override SessionQuestLevel CurrentLevel => GetActiveChildSessionQuest().CurrentLevel;

	public override RewardState CurrentState => GetActiveChildSessionQuest().CurrentState;

	public override bool Passive => GetActiveChildSessionQuest().Passive;

	public override int CurrentLevelIndex
	{
		get
		{
			int num = 0;
			foreach (SessionQuest childSessionQuest in childSessionQuests)
			{
				if (childSessionQuest.CurrentState == RewardState.Completed)
				{
					num += childSessionQuest.LevelCount;
					continue;
				}
				return num + childSessionQuest.CurrentLevelIndex;
			}
			return num;
		}
	}

	public override int LevelCount
	{
		get
		{
			int num = 0;
			foreach (SessionQuest childSessionQuest in childSessionQuests)
			{
				num += childSessionQuest.LevelCount;
			}
			return num;
		}
	}

	public override int GetCurrentProgress(int level = -1)
	{
		int childLevel;
		return GetChildSessionQuestAtLevel(level, out childLevel).GetCurrentProgress(childLevel);
	}

	public override SessionQuestLevel GetLevel(int levelIndex)
	{
		int childLevel;
		return GetChildSessionQuestAtLevel(levelIndex, out childLevel).GetLevel(childLevel);
	}

	public override string GetTitle(int level = -1, bool addLevel = true, bool addNoBreakTags = true)
	{
		int childLevel;
		return GetChildSessionQuestAtLevel(level, out childLevel).GetTitle(childLevel, addLevel, addNoBreakTags);
	}

	public override string GetDescription(int level = -1)
	{
		int childLevel;
		return GetChildSessionQuestAtLevel(level, out childLevel).GetDescription(childLevel);
	}

	public SessionQuest GetActiveChildSessionQuest()
	{
		if (Enumerable.Count(childSessionQuests, (SessionQuest x) => x.CurrentState != RewardState.Completed) > 0)
		{
			return Enumerable.First(childSessionQuests, (SessionQuest x) => x.CurrentState != RewardState.Completed);
		}
		return Enumerable.Last(childSessionQuests);
	}

	private SessionQuest GetChildSessionQuestAtLevel(int targetLevel, out int childLevel)
	{
		if (targetLevel == -1)
		{
			childLevel = GetActiveChildSessionQuest().CurrentLevelIndex;
			return GetActiveChildSessionQuest();
		}
		childLevel = targetLevel;
		for (int i = 0; i < childSessionQuests.Count; i++)
		{
			childLevel = targetLevel;
			if (targetLevel < childSessionQuests[i].LevelCount)
			{
				return childSessionQuests[i];
			}
			targetLevel -= childSessionQuests[i].LevelCount;
		}
		return Enumerable.Last(childSessionQuests);
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.sessionQuestWatcher = sessionQuestWatcher;
		GetActiveChildSessionQuest().StartWatching(sessionQuestWatcher);
	}

	public override void StopWatching()
	{
		GetActiveChildSessionQuest().StopWatching();
	}

	public override void ExecuteFulfillment(Tile placedTile = null, bool isPlacedByPlayer = true)
	{
		if (!isPlacedByPlayer || !GetActiveChildSessionQuest().IsFulfilled())
		{
			return;
		}
		int fulfilledLevel = CurrentLevelIndex;
		SetCurrentLevelIndex(currentLevelIndex + 1);
		sessionQuestWatcher.SessionQuestManager.UpdateSessionQuestData(this, save: false);
		foreach (SessionQuest childSessionQuest in childSessionQuests)
		{
			sessionQuestWatcher.SessionQuestManager.UpdateSessionQuestData(childSessionQuest, save: false);
		}
		sessionQuestWatcher.SessionQuestManager.UpdateSessionQuestData(this, save: true);
		InvokeOnFulfilledEvent(fulfilledLevel);
	}

	protected override void OnValidate()
	{
		if (childSessionQuests.Count == 0)
		{
			return;
		}
		if (Enumerable.Any(childSessionQuests, (SessionQuest x) => x is CompositeSessionQuest))
		{
			Debug.LogError(base.name + " has composite session quest as child! this is not allowed");
			return;
		}
		int num = currentLevelIndex;
		for (int num2 = 0; num2 < childSessionQuests.Count; num2++)
		{
			childSessionQuests[num2].compositeParentQuest = this;
			if (num == -1 || (num2 > 0 && childSessionQuests[num2 - 1].CurrentState == RewardState.InProgress))
			{
				childSessionQuests[num2].SetCurrentLevelIndex(-1);
				continue;
			}
			childSessionQuests[num2].SetCurrentLevelIndex(Mathf.Clamp(num, -1, childSessionQuests[num2].LevelCount));
			num -= childSessionQuests[num2].CurrentLevelIndex;
		}
		for (int num3 = 0; num3 < LevelCount; num3++)
		{
			GetLevel(num3).reward.compositeSessionQuest = this;
			GetLevel(num3).reward.compositeLevel = num3;
		}
		UpdateQuestState();
	}

	protected internal override void SetCurrentLevelIndex(int newLevel)
	{
		currentLevelIndex = newLevel;
		int num = currentLevelIndex;
		for (int i = 0; i < childSessionQuests.Count; i++)
		{
			if (num == -1 || (i > 0 && childSessionQuests[i - 1].CurrentState == RewardState.InProgress))
			{
				childSessionQuests[i].SetCurrentLevelIndex(-1);
				continue;
			}
			childSessionQuests[i].SetCurrentLevelIndex(Mathf.Clamp(num, -1, childSessionQuests[i].LevelCount));
			num -= childSessionQuests[i].CurrentLevelIndex;
		}
		UpdateQuestState();
	}

	public override void SetCurrentProgress(int newProgress)
	{
		currentProgress = newProgress;
		GetActiveChildSessionQuest().SetCurrentProgress(newProgress);
	}
}
