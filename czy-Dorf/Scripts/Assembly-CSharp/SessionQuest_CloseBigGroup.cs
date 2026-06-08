using System.Collections.Generic;
using UnityEngine;

public class SessionQuest_CloseBigGroup : SessionQuest
{
	public CountTarget countTarget;

	public GroupType groupType;

	public ElementType elementType;

	[SerializeField]
	private List<ElementGroup> potentialFulfillmentGroups = new List<ElementGroup>();

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
			sessionQuestWatcher.ElementGroupManager.OnGroupChanged += UpdateProgress;
			sessionQuestWatcher.ElementGroupManager.OnGroupClosed += UpdateFulfillment;
		}
	}

	private void UpdateFulfillment(ElementGroup updatedGroup, bool newClosed)
	{
		if (updatedGroup.GroupType == groupType)
		{
			if (newClosed && updatedGroup.ConditionCount(countTarget, elementType) >= CurrentLevel.count && !potentialFulfillmentGroups.Contains(updatedGroup))
			{
				potentialFulfillmentGroups.Add(updatedGroup);
			}
			else if (!newClosed)
			{
				potentialFulfillmentGroups.Remove(updatedGroup);
			}
		}
	}

	public override bool IsFulfilled()
	{
		return potentialFulfillmentGroups.Count > 0;
	}

	protected override void InitializeProgress()
	{
		currentProgress = sessionQuestWatcher.ElementGroupManager.GetGroupCountByCondition(groupType, elementType, EqualityComparison.MoreThan, countTarget);
	}

	private void UpdateProgress(ElementGroup updatedGroup)
	{
		if (updatedGroup.GroupType == groupType)
		{
			currentProgress = sessionQuestWatcher.ElementGroupManager.GetGroupCountByCondition(groupType, elementType, EqualityComparison.MoreThan, countTarget);
			ProgressChanged(save: false);
		}
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
		sessionQuestWatcher.ElementGroupManager.OnGroupChanged -= UpdateProgress;
		sessionQuestWatcher.ElementGroupManager.OnGroupClosed -= UpdateFulfillment;
	}
}
