using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SessionQuest_CloseBigGroupExcludingSegmentTypes : SessionQuest
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public ElementGroupSegment x;

		internal bool _003CUpdateProgress_003Eb__2(SegmentType y)
		{
			return x.SegmentType == y;
		}
	}

	public CountTarget countTarget;

	public GroupType groupType;

	public ElementType elementType;

	public List<SegmentType> forbiddenSegmentTypes;

	[SerializeField]
	private List<ElementGroup> potentialFulfillmentGroups;

	[SerializeField]
	private List<ElementGroup> validGroups;

	public override string GetDescription(int level = -1)
	{
		string localizedValue = LocalizationManager.Instance.GetLocalizedValue(descriptionKey);
		localizedValue = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(localizedValue, TargetCount(level));
		return localizedValue.Replace("[x]", TargetCount(level).ToString());
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.StartWatching(sessionQuestWatcher);
		if (!base.Completed)
		{
			validGroups = new List<ElementGroup>();
			potentialFulfillmentGroups = new List<ElementGroup>();
			sessionQuestWatcher.ElementGroupManager.OnGroupChanged += UpdateProgress;
			sessionQuestWatcher.ElementGroupManager.OnGroupClosed += UpdateFulfillment;
		}
	}

	private void UpdateFulfillment(ElementGroup updatedGroup, bool newClosed)
	{
		if (updatedGroup.GroupType == groupType)
		{
			if (!newClosed)
			{
				potentialFulfillmentGroups.Remove(updatedGroup);
			}
			else if (!validGroups.Contains(updatedGroup))
			{
				potentialFulfillmentGroups.Remove(updatedGroup);
			}
			else if (!potentialFulfillmentGroups.Contains(updatedGroup) && updatedGroup.ConditionCount(countTarget, elementType) >= CurrentLevel.count)
			{
				potentialFulfillmentGroups.Add(updatedGroup);
			}
		}
	}

	public override bool IsFulfilled()
	{
		return potentialFulfillmentGroups.Count > 0;
	}

	private void UpdateProgress(ElementGroup updatedGroup)
	{
		if (!(updatedGroup.GroupType == groupType))
		{
			return;
		}
		if (updatedGroup.IsAboutToBeRemoved || Enumerable.Count(updatedGroup.Segments, delegate(ElementGroupSegment x)
		{
			_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass10_0();
			CS_0024_003C_003E8__locals2.x = x;
			return Enumerable.Any(forbiddenSegmentTypes, (SegmentType y) => CS_0024_003C_003E8__locals2.x.SegmentType == y);
		}) > 0)
		{
			validGroups.Remove(updatedGroup);
		}
		else if (!validGroups.Contains(updatedGroup))
		{
			validGroups.Add(updatedGroup);
		}
		if (validGroups.Count == 0)
		{
			currentProgress = 0;
			return;
		}
		validGroups = Enumerable.ToList(Enumerable.Reverse(Enumerable.OrderBy(validGroups, (ElementGroup x) => x.ConditionCount(countTarget, elementType))));
		currentProgress = validGroups[0].ConditionCount(countTarget, elementType);
		ProgressChanged(save: false);
	}

	public override void ExecuteFulfillment(Tile placedTile = null, bool isPlacedByPlayer = true)
	{
		if (isPlacedByPlayer)
		{
			base.ExecuteFulfillment(placedTile);
			potentialFulfillmentGroups.Clear();
		}
	}

	public override void StopWatching()
	{
		base.StopWatching();
		potentialFulfillmentGroups.Clear();
		validGroups.Clear();
		sessionQuestWatcher.ElementGroupManager.OnGroupChanged -= UpdateProgress;
		sessionQuestWatcher.ElementGroupManager.OnGroupClosed -= UpdateFulfillment;
	}

	private bool _003CUpdateProgress_003Eb__10_0(ElementGroupSegment x)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals2.x = x;
		return Enumerable.Any(forbiddenSegmentTypes, (SegmentType y) => CS_0024_003C_003E8__locals2.x.SegmentType == y);
	}

	private int _003CUpdateProgress_003Eb__10_1(ElementGroup x)
	{
		return x.ConditionCount(countTarget, elementType);
	}
}
