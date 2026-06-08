using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class GroupConditionWatcher : QuestConditionWatcher
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ElementGroup, bool> _003C_003E9__11_0;

		public static Func<ElementGroup, bool> _003C_003E9__11_1;

		internal bool _003CCheckIfConditionIsFulfilled_003Eb__11_0(ElementGroup x)
		{
			return x.PreviewClosed;
		}

		internal bool _003CCheckIfConditionIsFulfilled_003Eb__11_1(ElementGroup x)
		{
			return x.PreviewClosed;
		}
	}

	private List<ElementGroup> _003CWatchedGroups_003Ek__BackingField;

	private Dictionary<ElementType, int> allElements = new Dictionary<ElementType, int>();

	private Dictionary<GroupTypeId, int> allSegments = new Dictionary<GroupTypeId, int>
	{
		{
			GroupTypeId.Village,
			0
		},
		{
			GroupTypeId.Forest,
			0
		},
		{
			GroupTypeId.Agriculture,
			0
		},
		{
			GroupTypeId.Water,
			0
		},
		{
			GroupTypeId.TrainTracks,
			0
		}
	};

	private bool isAffectedByCurrentTile;

	private bool watchedGroupIsClosed;

	public List<ElementGroup> WatchedGroups
	{
		get
		{
			return _003CWatchedGroups_003Ek__BackingField;
		}
		private set
		{
			_003CWatchedGroups_003Ek__BackingField = value;
		}
	}

	public GroupConditionWatcher(QuestCondition condition, List<int> watchDirections, Quest quest, QuestTile questTile, int index, QuestManager questManager, int overwriteTargetValue)
		: base(condition, watchDirections, quest, questTile, index, questManager, overwriteTargetValue)
	{
	}

	public override void InitializeWatchTargets()
	{
		InitializeWatchedGroups();
	}

	protected override void CheckIfConditionIsFulfilled()
	{
		FulfillmentStatus fulfillmentStatus = FulfillmentStatus.Changed;
		base.CurrentValue = FulfillmentCount();
		switch (condition.conditionType)
		{
		case QuestConditionType.CloseGroup:
			base.RemainingValue = base.CurrentValue;
			if (Enumerable.All(WatchedGroups, (ElementGroup x) => x.PreviewClosed))
			{
				fulfillmentStatus = FulfillmentStatus.Fulfilled;
			}
			break;
		case QuestConditionType.CountElements:
		case QuestConditionType.CountSegments:
			base.RemainingValue = base.TargetValue - base.CurrentValue;
			fulfillmentStatus = FulfillmentCountSufficient();
			if (fulfillmentStatus == FulfillmentStatus.Changed && Enumerable.All(WatchedGroups, (ElementGroup x) => x.PreviewClosed))
			{
				fulfillmentStatus = FulfillmentStatus.Unfulfillable;
				conditionFailedReason = QuestFailedReason.GroupClosedPrematurely;
			}
			break;
		}
		ConditionFulfillmentChanged(index, fulfillmentStatus, base.RemainingValue);
	}

	private FulfillmentStatus FulfillmentCountSufficient()
	{
		switch (condition.equalityComparer)
		{
		case EqualityComparison.MoreThan:
			if (base.RemainingValue <= 0)
			{
				return FulfillmentStatus.Fulfilled;
			}
			break;
		case EqualityComparison.Exactly:
			if (base.RemainingValue == 0)
			{
				return FulfillmentStatus.Fulfilled;
			}
			if (base.RemainingValue < 0)
			{
				conditionFailedReason = QuestFailedReason.ExactlyConditionExceeded;
				return FulfillmentStatus.Unfulfillable;
			}
			break;
		case EqualityComparison.FewerThan:
			if (base.RemainingValue >= 0)
			{
				return FulfillmentStatus.Fulfilled;
			}
			return FulfillmentStatus.Unfulfillable;
		}
		return FulfillmentStatus.Changed;
	}

	public override void StopWatching()
	{
		base.StopWatching();
		foreach (ElementGroup watchedGroup in WatchedGroups)
		{
			watchedGroup.OnGroupClosed -= WatchedGroupClosed;
			watchedGroup.OnGroupsMerged -= ChangeWatchedGroup;
			watchedGroup.OnSegmentAdded -= CheckIfConditionIsFulfilled;
			watchedGroup.OnSegmentRemoved -= CheckIfConditionIsFulfilled;
			watchedGroup.OnHighlight -= HighlightGroup;
			watchedGroupIsClosed = false;
		}
		WatchedGroups.Clear();
	}

	private void HighlightGroup(bool groupHighlighted)
	{
		isAffectedByCurrentTile = groupHighlighted;
		ChangeAffectedByCurrentTile(isAffectedByCurrentTile || watchedGroupIsClosed);
	}

	private void CheckIfConditionIsFulfilled(ElementGroup updatedGroup)
	{
		CheckIfConditionIsFulfilled();
	}

	public override bool IsRelevantFor(ElementGroupSegment newSegment)
	{
		return condition.groupType == newSegment.GroupType;
	}

	private void InitializeWatchedGroups()
	{
		WatchedGroups = new List<ElementGroup>();
		foreach (int watchDirection in watchDirections)
		{
			AddGroupsAtLocalDirection(watchDirection);
		}
		questTile.OnGroupChanged += ChangeWatchedGroup;
		CheckIfConditionIsFulfilled();
	}

	private void WatchedGroupClosed(ElementGroup watchedGroup, bool closed)
	{
		watchedGroupIsClosed = closed;
		CheckIfConditionIsFulfilled();
		ChangeAffectedByCurrentTile(isAffectedByCurrentTile || watchedGroupIsClosed);
	}

	private int FulfillmentCount()
	{
		int num = 0;
		if (condition.conditionType == QuestConditionType.CountElements)
		{
			allElements.Clear();
			foreach (ElementGroup watchedGroup in WatchedGroups)
			{
				foreach (KeyValuePair<ElementType, int> element in watchedGroup.Elements)
				{
					if (!allElements.ContainsKey(element.Key))
					{
						allElements.Add(element.Key, 0);
					}
					allElements[element.Key] += element.Value;
				}
			}
			if (allElements.ContainsKey(condition.elementType))
			{
				num = allElements[condition.elementType];
			}
		}
		if (condition.conditionType == QuestConditionType.CountSegments)
		{
			ClearSegmentsDictionary();
			foreach (ElementGroup watchedGroup2 in WatchedGroups)
			{
				foreach (ElementGroupSegment segment in watchedGroup2.Segments)
				{
					if (!allSegments.ContainsKey(segment.GroupType.id))
					{
						allSegments.Add(segment.GroupType.id, 0);
					}
					allSegments[segment.GroupType.id]++;
				}
			}
			if (allSegments.ContainsKey(condition.groupType.id))
			{
				num = allSegments[condition.groupType.id];
			}
		}
		if (condition.conditionType == QuestConditionType.CloseGroup)
		{
			foreach (ElementGroup watchedGroup3 in WatchedGroups)
			{
				num += watchedGroup3.OpenEdges;
			}
		}
		return num;
	}

	private void AddGroupsAtLocalDirection(int localWatchDirection)
	{
		int num = GridCalculator.RotatedDirection(localWatchDirection, questTile.RotationIndex);
		if (quest.watchType.watchOnQuestTile)
		{
			if (quest.watchType.watchWholeTile)
			{
				AddAllWatchedGroupsOnTile(questTile);
			}
			else
			{
				AddWatchedGroupAtWorldDirection(questTile, num);
			}
		}
		if (quest.watchType.watchOnNeighborTile)
		{
			if (quest.watchType.watchWholeTile)
			{
				AddAllWatchedGroupsOnTile(questTile.NeighborTiles[num]);
			}
			else
			{
				AddWatchedGroupAtWorldDirection(questTile.NeighborTiles[num], (num + 3) % 6);
			}
		}
	}

	private void AddAllWatchedGroupsOnTile(Tile tileToCheck)
	{
		if ((bool)tileToCheck)
		{
			for (int i = 0; i < 6; i++)
			{
				AddWatchedGroupAtWorldDirection(tileToCheck, i);
			}
		}
	}

	private void AddWatchedGroupAtWorldDirection(Tile tileToCheck, int worldDirection)
	{
		if ((bool)tileToCheck)
		{
			ElementGroup elementGroup = tileToCheck.GetElementGroup(worldDirection, Space.World, condition.groupType);
			AddWatchedGroup(elementGroup);
		}
	}

	private void AddWatchedGroup(ElementGroup groupToAdd)
	{
		if ((bool)groupToAdd && (condition.groupType == null || condition.groupType == groupToAdd.GroupType) && !WatchedGroups.Contains(groupToAdd))
		{
			base.GroupType = groupToAdd.GroupType;
			WatchedGroups.Add(groupToAdd);
			groupToAdd.OnGroupClosed += WatchedGroupClosed;
			groupToAdd.OnGroupsMerged += ChangeWatchedGroup;
			groupToAdd.OnSegmentAdded += CheckIfConditionIsFulfilled;
			groupToAdd.OnSegmentRemoved += CheckIfConditionIsFulfilled;
			groupToAdd.OnHighlight += HighlightGroup;
		}
	}

	public override void QuestTileNeighborAdded(int worldNeighborDirection, Tile neighborTile)
	{
		int num = GridCalculator.RotatedDirection(worldNeighborDirection, -questTile.RotationIndex);
		if (watchDirections.Contains(num))
		{
			AddGroupsAtLocalDirection(num);
		}
		CheckIfConditionIsFulfilled();
	}

	private void ChangeWatchedGroup(ElementGroup previousGroup, ElementGroup updatedGroup)
	{
		if (previousGroup != null && WatchedGroups.Contains(previousGroup))
		{
			previousGroup.OnGroupClosed -= WatchedGroupClosed;
			previousGroup.OnGroupsMerged -= ChangeWatchedGroup;
			previousGroup.OnSegmentAdded -= CheckIfConditionIsFulfilled;
			previousGroup.OnSegmentRemoved -= CheckIfConditionIsFulfilled;
			previousGroup.OnHighlight -= HighlightGroup;
			watchedGroupIsClosed = false;
			WatchedGroups.Remove(previousGroup);
			AddWatchedGroup(updatedGroup);
		}
		CheckIfConditionIsFulfilled();
	}

	public void HighlightWatchedGroups(bool newHighlight)
	{
		foreach (ElementGroup watchedGroup in WatchedGroups)
		{
			watchedGroup.HighlightOpenEdges(newHighlight, questTile);
		}
	}

	private void ClearSegmentsDictionary()
	{
		allSegments[GroupTypeId.Village] = 0;
		allSegments[GroupTypeId.Forest] = 0;
		allSegments[GroupTypeId.Agriculture] = 0;
		allSegments[GroupTypeId.Water] = 0;
		allSegments[GroupTypeId.TrainTracks] = 0;
	}
}
