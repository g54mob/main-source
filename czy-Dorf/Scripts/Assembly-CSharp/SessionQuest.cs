using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public abstract class SessionQuest : ScriptableObject
{
	public ChallengeId id;

	[SerializeField]
	protected RewardState currentState;

	[SerializeField]
	protected int currentLevelIndex;

	public int currentProgress;

	public bool isPinned;

	public bool storeProgress;

	[SerializeField]
	private bool passive;

	public string stringId;

	[SerializeField]
	private string titleKey;

	[SerializeField]
	protected string descriptionKey;

	public bool priorityQuest;

	public bool unlocksQuestTile = true;

	[SerializeField]
	private List<SessionQuestLevel> levels;

	public CompositeSessionQuest compositeParentQuest;

	[SerializeField]
	protected TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	[SerializeField]
	protected RewardSystem rewardSystem;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	protected SessionQuestWatcher sessionQuestWatcher;

	private bool isWatching;

	public virtual bool SelectableInClassicMode => true;

	public virtual RewardState CurrentState => currentState;

	public virtual int CurrentLevelIndex => currentLevelIndex;

	protected bool Completed => CurrentState == RewardState.Completed;

	public virtual SessionQuestLevel CurrentLevel => GetLevel(CurrentLevelIndex);

	public virtual int LevelCount => levels.Count;

	public List<SessionQuestLevel> AllLevels => levels;

	public virtual bool Passive => passive;

	public event Action<int> OnProgressChanged;

	public event Action<SessionQuest, int> OnFulfillmentChanged;

	public event Action<SessionQuest> OnUnlocked;

	public event Action<bool> OnPinned;

	public virtual string GetTitle(int level = -1, bool showLevel = true, bool addNoBreakTags = true)
	{
		string text = LocalizationManager.Instance.GetLocalizedValue(titleKey, useFallbackText: true);
		if (showLevel && LevelCount > 1)
		{
			int arabic = GetLevel(level).index + 1;
			string text2 = (LocalizationManager.Instance.UseRomanNumerals ? RomanNumeralConverter.ArabicToRoman(arabic) : arabic.ToString());
			text = text + " " + text2;
		}
		if (addNoBreakTags)
		{
			string[] array = text.Split(' ');
			if (array.Length > 1 && !LocalizationManager.Instance.IsCurrentLanguageRightToLeft)
			{
				text = "";
				for (int i = 0; i < array.Length - 2; i++)
				{
					text = text + array[i] + " ";
				}
				text = text + "<nobr>" + array[array.Length - 2] + " " + array[array.Length - 1] + "</nobr>";
			}
		}
		return text;
	}

	public virtual string GetDescription(int level = -1)
	{
		return LocalizationManager.Instance.GetLocalizedValue(descriptionKey, useFallbackText: true).Replace("[x]", TargetCount(level).ToString());
	}

	public virtual int GetCurrentProgress(int level = -1)
	{
		if (CurrentState != RewardState.Completed && (level == -1 || level == CurrentLevelIndex))
		{
			return currentProgress;
		}
		return TargetCount(level);
	}

	public int TargetCount(int level = -1)
	{
		if (level != -1)
		{
			return GetLevel(level).count;
		}
		return CurrentLevel.count;
	}

	public virtual void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		if (isWatching)
		{
			Debug.LogError(base.name + " is already watching but StartWatching was called!");
		}
		this.sessionQuestWatcher = sessionQuestWatcher;
		InitializeProgress();
		ProgressChanged(save: false);
		if (!Completed)
		{
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += ExecuteFulfillment;
		}
		isWatching = true;
	}

	public virtual bool IsFulfilled()
	{
		return currentProgress >= TargetCount();
	}

	public virtual void StopWatching()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= ExecuteFulfillment;
		isWatching = false;
	}

	protected virtual void ProgressChanged(bool save)
	{
		if (sessionQuestWatcher == null)
		{
			Debug.LogError(base.name + " ProgressChanged was called but sessionQuestWatcher is null");
		}
		if (currentState != RewardState.Completed)
		{
			if (storeProgress && save)
			{
				sessionQuestManager.UpdateSessionQuestData(this, save: true);
			}
			this.OnProgressChanged?.Invoke(currentProgress);
			if ((bool)compositeParentQuest)
			{
				compositeParentQuest.ProgressChanged(save);
			}
		}
	}

	protected virtual void InitializeProgress()
	{
	}

	public virtual void ExecuteFulfillment(Tile placedTile = null, bool isPlacedByPlayer = true)
	{
		if (sessionQuestWatcher == null)
		{
			Debug.LogError(base.name + " ExecuteFulfillment was called but sessionQuestWatcher is null");
		}
		if (isPlacedByPlayer && currentState != RewardState.Completed && IsFulfilled())
		{
			if ((bool)compositeParentQuest)
			{
				compositeParentQuest.ExecuteFulfillment(placedTile);
				return;
			}
			int num = currentLevelIndex;
			currentLevelIndex++;
			UpdateQuestState();
			sessionQuestManager.UpdateSessionQuestData(this, save: true);
			Debug.Log($"{base.name} level {num} was fulfilled!");
			UnityAnalyticsAccessor.SendCustomEvent("challenge_fulfilled", new Dictionary<string, object>
			{
				{ "id", stringId },
				{ "level", num },
				{ "score", rewardSystem.Score }
			});
			InvokeOnFulfilledEvent(num);
		}
	}

	protected void InvokeOnFulfilledEvent(int fulfilledLevel)
	{
		if (sessionQuestWatcher == null)
		{
			Debug.LogError(base.name + " InvokeOnFulfilledEvent was called but sessionQuestWatcher is null");
		}
		this.OnFulfillmentChanged?.Invoke(this, fulfilledLevel);
	}

	public void OverwriteSaveState()
	{
		sessionQuestManager.UpdateSessionQuestData(this, save: true);
	}

	protected void UpdateQuestState()
	{
		if (CurrentLevelIndex >= LevelCount)
		{
			currentState = RewardState.Completed;
			Pin(pin: false);
		}
		else if (CurrentLevelIndex >= 0)
		{
			currentState = RewardState.InProgress;
		}
		else
		{
			currentState = RewardState.Hidden;
		}
	}

	protected virtual void OnValidate()
	{
		UpdateQuestState();
		for (int i = 0; i < LevelCount; i++)
		{
			GetLevel(i).index = i;
			GetLevel(i).reward.sessionQuest = this;
			GetLevel(i).reward.rewardLevel = i;
			if (!compositeParentQuest)
			{
				GetLevel(i).reward.compositeLevel = -1;
				GetLevel(i).reward.compositeSessionQuest = null;
			}
		}
		titleKey = "sq_" + stringId + "_title";
		descriptionKey = "sq_" + stringId + "_description";
		currentLevelIndex = Mathf.Clamp(CurrentLevelIndex, -1, LevelCount);
	}

	public virtual SessionQuestLevel GetLevel(int levelIndex)
	{
		levelIndex = Mathf.Clamp(levelIndex, 0, LevelCount);
		if (levelIndex < LevelCount)
		{
			return levels[levelIndex];
		}
		return Enumerable.Last(levels);
	}

	public RewardState GetLevelState(int levelIndex)
	{
		if (CurrentLevelIndex > levelIndex)
		{
			return RewardState.Completed;
		}
		if (levelIndex == CurrentLevelIndex)
		{
			return CurrentState;
		}
		return RewardState.Hidden;
	}

	public void LoadFromData(ChallengeData_002 loadedChallengeData)
	{
		RewardState num = CurrentState;
		SetCurrentProgress(loadedChallengeData.currentProgress);
		SetCurrentLevelIndex(loadedChallengeData.currentLevel);
		isPinned = loadedChallengeData.pinned && currentState != RewardState.Completed;
		this.OnProgressChanged?.Invoke(currentProgress);
		if (num != currentState)
		{
			this.OnFulfillmentChanged?.Invoke(this, CurrentLevelIndex);
		}
	}

	protected internal virtual void SetCurrentLevelIndex(int newLevel)
	{
		currentLevelIndex = newLevel;
		UpdateQuestState();
		if (currentLevelIndex == LevelCount)
		{
			currentProgress = TargetCount();
			this.OnProgressChanged?.Invoke(currentProgress);
		}
		else if (newLevel > 0 && storeProgress && currentProgress < TargetCount(newLevel - 1))
		{
			currentProgress = TargetCount(newLevel - 1);
			this.OnProgressChanged?.Invoke(currentProgress);
		}
	}

	public void Unlock()
	{
		if (CurrentState == RewardState.Hidden)
		{
			if ((bool)compositeParentQuest && compositeParentQuest.CurrentState == RewardState.Hidden)
			{
				compositeParentQuest.Unlock();
			}
			else
			{
				SetCurrentLevelIndex(0);
			}
			this.OnUnlocked?.Invoke(this);
		}
	}

	public void ResetProgress()
	{
		if (!storeProgress)
		{
			currentProgress = 0;
			this.OnProgressChanged?.Invoke(currentProgress);
		}
	}

	public void HardResetProgress()
	{
		currentProgress = 0;
		SetCurrentLevelIndex(-1);
		foreach (SessionQuestLevel level in levels)
		{
			level.reward.state = RewardState.Hidden;
		}
		Pin(pin: false);
	}

	public virtual void SetCurrentProgress(int newProgress)
	{
		currentProgress = newProgress;
	}

	public void Pin(bool pin)
	{
		isPinned = pin;
		this.OnPinned?.Invoke(isPinned);
	}
}
