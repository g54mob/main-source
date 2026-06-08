using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<QuestWatcher, bool> _003C_003E9__25_0;

		internal bool _003CGetLatestQuest_003Eb__25_0(QuestWatcher x)
		{
			return x.State == TileState.topStackPreview;
		}
	}

	[SerializeField]
	private List<QuestWatcher> activeQuests;

	[SerializeField]
	private List<QuestWatcher> lockAndCrownQuests;

	[SerializeField]
	private QuestSystemConfiguration configuration;

	private ElementGroupManager elementGroupManager;

	[SerializeField]
	private RewardSystem rewardSystem;

	private List<QuestWatcher> _003CAllQuestWatchers_003Ek__BackingField;

	public QuestSystemConfiguration Configuration => configuration;

	public int ActiveQuestCount => activeQuests.Count;

	public List<QuestWatcher> AllQuestWatchers
	{
		get
		{
			return _003CAllQuestWatchers_003Ek__BackingField;
		}
		private set
		{
			_003CAllQuestWatchers_003Ek__BackingField = value;
		}
	}

	public event Action<QuestWatcher> OnQuestAdded;

	public event Action<QuestWatcher> OnQuestRemoved;

	public Quest GetFollowupQuest(QuestTile questTile, Quest quest)
	{
		if ((bool)questTile.QuestWatcher.UnlockingSessionQuest)
		{
			return null;
		}
		UnityEngine.Random.InitState(questTile.Seed);
		float value = UnityEngine.Random.value;
		Quest flagQuest = configuration.GetFlagQuest(quest, value, questTile.level);
		Randomizer.RandomizeSeed();
		return flagQuest;
	}

	public void Reset(ElementGroupManager elementGroupManager)
	{
		activeQuests = new List<QuestWatcher>();
		lockAndCrownQuests = new List<QuestWatcher>();
		AllQuestWatchers = new List<QuestWatcher>();
		this.elementGroupManager = elementGroupManager;
	}

	public void AddQuest(QuestWatcher questWatcher)
	{
		if (questWatcher.CurrentQuest.countsTowardsQuestLimit && questWatcher.UnlockingSessionQuest == null)
		{
			if (!activeQuests.Contains(questWatcher))
			{
				activeQuests.Add(questWatcher);
				this.OnQuestAdded?.Invoke(questWatcher);
			}
		}
		else if (!lockAndCrownQuests.Contains(questWatcher))
		{
			lockAndCrownQuests.Add(questWatcher);
			this.OnQuestAdded?.Invoke(questWatcher);
		}
		if (!AllQuestWatchers.Contains(questWatcher))
		{
			AllQuestWatchers.Add(questWatcher);
		}
	}

	public void RemoveQuest(QuestWatcher questWatcher)
	{
		activeQuests.Remove(questWatcher);
		lockAndCrownQuests.Remove(questWatcher);
		AllQuestWatchers.Remove(questWatcher);
		this.OnQuestRemoved?.Invoke(questWatcher);
	}

	public void ExpandAndCollapseQuests(Tile newTile)
	{
	}

	public int ReferenceGroupCount(QuestCondition condition, Tile questTile)
	{
		int result = 0;
		switch (condition.conditionType)
		{
		case QuestConditionType.CountElements:
			result = elementGroupManager.GetGroupCountByCondition(condition.groupType, condition.elementType, condition.equalityComparer, CountTarget.Elements, questTile.Seed, (questTile.State == TileState.placementPreview) ? questTile.AllElementGroups : null);
			break;
		case QuestConditionType.CountSegments:
			result = elementGroupManager.GetGroupCountByCondition(condition.groupType, null, condition.equalityComparer, CountTarget.Segments, questTile.Seed, (questTile.State == TileState.placementPreview) ? questTile.AllElementGroups : null);
			break;
		}
		return result;
	}

	public QuestWatcher GetLatestQuest(bool onStack = false)
	{
		if (activeQuests.Count == 0)
		{
			if (lockAndCrownQuests.Count > 0)
			{
				return Enumerable.Last(lockAndCrownQuests);
			}
			return null;
		}
		if (!onStack)
		{
			return Enumerable.Last(activeQuests);
		}
		return Enumerable.Last(activeQuests, (QuestWatcher x) => x.State == TileState.topStackPreview);
	}

	public void SetConfiguration(QuestSystemConfiguration newConfiguration)
	{
		configuration = newConfiguration;
		configuration.Setup();
	}

	public void Clear()
	{
		lockAndCrownQuests.Clear();
		activeQuests.Clear();
		AllQuestWatchers.Clear();
	}
}
