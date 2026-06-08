using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class QuestConditionWatcher
{
	protected QuestCondition condition;

	protected List<int> watchDirections;

	protected Quest quest;

	protected QuestTile questTile;

	protected int index;

	protected int initialCount;

	private int _003CTargetValue_003Ek__BackingField;

	private int _003CCurrentValue_003Ek__BackingField;

	private int _003CRemainingValue_003Ek__BackingField;

	private GroupType _003CGroupType_003Ek__BackingField;

	protected QuestFailedReason conditionFailedReason;

	public QuestCondition Condition => condition;

	public int TargetValue
	{
		get
		{
			return _003CTargetValue_003Ek__BackingField;
		}
		protected set
		{
			_003CTargetValue_003Ek__BackingField = value;
		}
	}

	public int CurrentValue
	{
		get
		{
			return _003CCurrentValue_003Ek__BackingField;
		}
		protected set
		{
			_003CCurrentValue_003Ek__BackingField = value;
		}
	}

	public int RemainingValue
	{
		get
		{
			return _003CRemainingValue_003Ek__BackingField;
		}
		protected set
		{
			_003CRemainingValue_003Ek__BackingField = value;
		}
	}

	public GroupType GroupType
	{
		get
		{
			return _003CGroupType_003Ek__BackingField;
		}
		protected set
		{
			_003CGroupType_003Ek__BackingField = value;
		}
	}

	public ElementType ElementType => GroupType.primaryElementType;

	public event Action<int, FulfillmentStatus, int, int, QuestFailedReason> OnConditionFulfillmentChanged;

	public event Action<bool> OnAffectedByCurrentTile;

	public QuestConditionWatcher(QuestCondition condition, List<int> watchDirections, Quest quest, QuestTile questTile, int index, QuestManager questManager, int overwriteTargetValue)
	{
		this.condition = condition;
		this.watchDirections = watchDirections;
		this.quest = quest;
		this.questTile = questTile;
		this.index = index;
		TargetValue = ((overwriteTargetValue != -1) ? overwriteTargetValue : (Mathf.Max(questManager.ReferenceGroupCount(condition, questTile), questTile.minTargetCount) + condition.targetValue + quest.DifficultyIncrease(index, questTile.level)));
		questTile.OnNeighborTileAdded += QuestTileNeighborAdded;
	}

	public abstract void InitializeWatchTargets();

	public abstract void QuestTileNeighborAdded(int worldNeighborDirection, Tile neighborTile);

	protected abstract void CheckIfConditionIsFulfilled();

	protected void ConditionFulfillmentChanged(int conditionIndex, FulfillmentStatus conditionFulfilled, int progressionDisplayValue)
	{
		this.OnConditionFulfillmentChanged?.Invoke(conditionIndex, conditionFulfilled, progressionDisplayValue, TargetValue, conditionFailedReason);
	}

	protected void ChangeAffectedByCurrentTile(bool isAffected)
	{
		this.OnAffectedByCurrentTile?.Invoke(isAffected);
	}

	public virtual void StopWatching()
	{
		questTile.OnNeighborTileAdded -= QuestTileNeighborAdded;
	}

	public abstract bool IsRelevantFor(ElementGroupSegment newSegment);
}
