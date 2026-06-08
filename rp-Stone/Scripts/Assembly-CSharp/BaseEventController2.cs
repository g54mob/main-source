using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEventController2
{
	public EventObjectives objectives;

	public EventRewards rewards;

	private int _part;

	private int lastPart = -99999;

	public EventController.EventData data { get; set; }

	public bool isPremiumActiveForEvent { get; set; }

	public bool isReady { get; private set; }

	public virtual int part
	{
		get
		{
			string partKey = GetPartKey();
			if (EventController.singleton.IsProgressLoaded())
			{
				PlayerPrefs.SetInt(partKey, _part);
				return _part;
			}
			return PlayerPrefs.GetInt(partKey, 0);
		}
		set
		{
			_part = value;
			PlayerPrefs.SetInt(GetPartKey(), value);
			UpdateForPartChanged();
		}
	}

	public virtual int rewardBonus
	{
		get
		{
			string rewardBonusKey = GetRewardBonusKey();
			if (EventController.singleton.IsProgressLoaded())
			{
				PlayerPrefs.SetInt(rewardBonusKey, rewards.treasureRarityBonus);
				return rewards.treasureRarityBonus;
			}
			return PlayerPrefs.GetInt(rewardBonusKey, 0);
		}
		set
		{
			PlayerPrefs.SetInt(GetRewardBonusKey(), value);
		}
	}

	public virtual int rewardLevel
	{
		get
		{
			string rewardLevelKey = GetRewardLevelKey();
			if (EventController.singleton.IsProgressLoaded())
			{
				PlayerPrefs.SetInt(rewardLevelKey, rewards.treasureStarLevel);
				return rewards.treasureStarLevel;
			}
			return PlayerPrefs.GetInt(rewardLevelKey, 0);
		}
		set
		{
			PlayerPrefs.SetInt(GetRewardLevelKey(), value);
		}
	}

	public BaseEventController2()
	{
		objectives = new EventObjectives(GetMaxDailyObjectives());
		rewards = new EventRewards();
		InitObjectives();
		string eventId = GetEventId();
		EventController.singleton.FindEventAsync(eventId, delegate(EventController.EventData d)
		{
			data = d;
			InitRewards();
			InitQuestRequirement();
			isReady = true;
		});
	}

	public abstract string GetEventId();

	public abstract int GetMaxDailyObjectives();

	public abstract void InitObjectives();

	private void InitRewards()
	{
		if (!string.IsNullOrEmpty(data.rewardsPath))
		{
			TextAsset textAsset = Resources.Load<TextAsset>(data.rewardsPath);
			rewards.data = Data.EventRewardCollection.FromString(textAsset.text);
		}
		else
		{
			Debug.LogError("Missing reward data file for event " + GetEventId());
		}
	}

	public bool HasPremiumAccess()
	{
		if (!isPremiumActiveForEvent)
		{
			if (SaveFiles.singleton.IsSynchedDeviceId())
			{
				return SubscriptionController.singleton.HasSubscription(SubscriptionController.EVENTS_SUBSCRIPTION_ID);
			}
			return false;
		}
		return true;
	}

	public bool IsVisibleInQuestScreen()
	{
		if (part < 1)
		{
			if (data != null)
			{
				return string.IsNullOrEmpty(data.unlockEpicQuest);
			}
			return false;
		}
		return true;
	}

	public bool HasEventStarted()
	{
		if (part >= 2)
		{
			return part < 4;
		}
		return false;
	}

	public bool HasMaxRewards()
	{
		if (part != 3)
		{
			return rewards.rewardPoints >= rewards.maxRewardPoints;
		}
		return true;
	}

	public bool HasEventEnded()
	{
		return !EventSchedules.singleton.IsEventActive(GetEventId());
	}

	public bool CanBeCollected()
	{
		if (part >= 2 && part < 4)
		{
			return HasEventEnded();
		}
		return false;
	}

	public bool HasCollectedRewards()
	{
		return part >= 4;
	}

	public void StartEvent()
	{
		if (!HasEventStarted())
		{
			part = 2;
			objectives.StartEvent();
			rewards.eventStartDate = DateTime.Now;
			if (rewards.eventStartDate.DayOfYear <= 2)
			{
				rewards.eventStartDate -= new TimeSpan(3, 0, 0, 0);
			}
		}
	}

	public void CollectRewardsAndEnd()
	{
		part = 4;
		objectives.ClearProgress();
		List<Item> list;
		if (EventController.singleton.HasCompletedYear(GetEventId(), rewards.eventStartDate.Year))
		{
			GameplayActionMessages.SetMessage(Te.xt("tid_event_re_claim"), ColorConstants.yellow, 8f);
			list = new List<Item>();
		}
		else
		{
			EventController.singleton.SetCompletedYear(GetEventId(), rewards.eventStartDate.Year);
			list = rewards.CollectRewards(HasPremiumAccess());
		}
		for (int i = 0; i < list.Count; i++)
		{
			Item item = list[i];
			int count = item.count;
			item = Inventory.Singleton.AddItem(item, count);
			if (item.isLost && item.lostCount > 32)
			{
				item.lostCount--;
				TreasureItem item2 = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "lost", null);
				Inventory.Singleton.AddItem(item2);
				SequentialPopupManager.singleton.ScheduleItemFound(item2, count);
			}
			else
			{
				SequentialPopupManager.singleton.ScheduleItemFound(item, count);
			}
		}
		rewards.ClearProgress();
		GameStates.Singleton.TryToSaveProgress();
		GameStates.Singleton.customQuestsScreen.MarkDirty();
	}

	protected void AddObjective(EventObjectiveBase obj)
	{
		objectives.Add(obj);
	}

	public virtual string GetPartKey()
	{
		return GetEventId() + "_part";
	}

	public virtual string GetRewardBonusKey()
	{
		return GetEventId() + "_bonus";
	}

	public virtual string GetRewardLevelKey()
	{
		return GetEventId() + "_level";
	}

	public bool HasObjectivesToClaim()
	{
		for (int num = objectives.activeObjectives.Count - 1; num >= 0; num--)
		{
			if (objectives.activeObjectives[num].IsComplete())
			{
				return true;
			}
		}
		return false;
	}

	public void ClaimCompletedObjectives()
	{
		int num = 0;
		for (int num2 = objectives.activeObjectives.Count - 1; num2 >= 0; num2--)
		{
			EventObjectiveBase eventObjectiveBase = objectives.activeObjectives[num2];
			if (eventObjectiveBase.IsComplete())
			{
				num += Mathf.Max(1, eventObjectiveBase.rewardPoints);
				objectives.CompleteObjective(eventObjectiveBase.id);
			}
		}
		rewards.AddRewardPoints(num);
		rewardBonus = rewards.treasureRarityBonus;
		rewardLevel = rewards.treasureStarLevel;
		if (rewards.rewardPoints >= rewards.maxRewardPoints)
		{
			part = 3;
		}
		GameStates.Singleton.TryToSaveProgress();
		CustomQuestsController.Singleton.UpdateBadge();
		int score = rewards.rewardPoints + objectives.GetBonusCompletionPoints(rewards.rewardPoints);
		LeaderboardController.singleton.SubmitScoreUpdate(data.id, score);
	}

	protected virtual void HandlePartEnded(int partEnded)
	{
	}

	protected virtual void HandlePartStarted(int partStarted)
	{
	}

	private void HandleQuestCompleted(Data.CustomQuestInstance quest)
	{
		if (part == 0 && data != null && quest.customQuestId == data.unlockEpicQuest)
		{
			part = 1;
			GameStates.Singleton.customQuestsScreen.MarkDirty();
		}
	}

	private void InitQuestRequirement()
	{
		if (string.IsNullOrEmpty(data.unlockEpicQuest))
		{
			if (part == 0)
			{
				part = 1;
			}
			return;
		}
		CustomQuestsController.Singleton.OnQuestCompleted += HandleQuestCompleted;
		if (part == 0 && CustomQuestsController.Singleton.IsEpicCompleted(data.unlockEpicQuest))
		{
			part = 1;
		}
	}

	public virtual void UpdateForPartChanged()
	{
		int num = part;
		if (lastPart != num)
		{
			if (lastPart >= 0)
			{
				HandlePartEnded(lastPart);
			}
			HandlePartStarted(num);
			lastPart = num;
		}
	}

	public virtual void ClearProgress()
	{
		part = 0;
		rewardBonus = 0;
		rewardLevel = 0;
		objectives.ClearProgress();
		rewards.ClearProgress();
		isPremiumActiveForEvent = false;
	}

	public virtual void Parse(string sjson)
	{
		_part = SlimJson.ParseInt(sjson, "p");
		objectives.Parse(SlimJson.Parse(sjson, "objs"));
		rewards.Parse(SlimJson.Parse(sjson, "rwds"));
		isPremiumActiveForEvent = SlimJson.ParseBool(sjson, "pp");
		UpdateForPartChanged();
	}

	public virtual string Serialize()
	{
		SlimJson.BeginSerialization();
		if (_part != 0)
		{
			SlimJson.AddProperty("p", _part);
		}
		SlimJson.AddProperty("objs", objectives.Serialize());
		SlimJson.AddProperty("rwds", rewards.Serialize());
		if (isPremiumActiveForEvent)
		{
			SlimJson.AddProperty("pp", property: true);
		}
		return SlimJson.EndSerialization();
	}
}
