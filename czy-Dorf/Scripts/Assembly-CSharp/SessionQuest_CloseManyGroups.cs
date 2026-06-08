using System.Collections.Generic;
using UnityEngine;

public class SessionQuest_CloseManyGroups : SessionQuest
{
	public CountTarget countTarget;

	public GroupType groupType;

	public ElementType elementType;

	public List<int> targetGroupSizePerLevel;

	[SerializeField]
	private List<ElementGroup> validGroups;

	private bool hasProgressChanged;

	public override string GetDescription(int level = -1)
	{
		int value = ((level == -1) ? CurrentLevel.index : level);
		string localizedValue = LocalizationManager.Instance.GetLocalizedValue(descriptionKey);
		localizedValue = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(localizedValue, TargetCount(level));
		localizedValue = localizedValue.Replace("[y]", targetGroupSizePerLevel[Mathf.Clamp(value, 0, targetGroupSizePerLevel.Count - 1)].ToString());
		return localizedValue.Replace("[x]", TargetCount(level).ToString());
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.StartWatching(sessionQuestWatcher);
		if (!base.Completed)
		{
			validGroups = new List<ElementGroup>();
			hasProgressChanged = false;
			sessionQuestWatcher.ElementGroupManager.OnGroupClosed += UpdateProgressAndFulfillment;
			sessionQuestWatcher.ElementGroupManager.OnGroupRemoved += RemoveGroup;
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += StoreProgress;
		}
	}

	private void StoreProgress(Tile obj, bool isPlacedByPlayer = true)
	{
		if (validGroups.Count != 0 && hasProgressChanged && isPlacedByPlayer)
		{
			sessionQuestWatcher.SessionQuestManager.UpdateSessionQuestData(this, save: true);
			validGroups.Clear();
		}
	}

	private void RemoveGroup(ElementGroup groupToRemove)
	{
		if (groupToRemove.GroupType == groupType && validGroups.Contains(groupToRemove))
		{
			currentProgress--;
			validGroups.Remove(groupToRemove);
		}
	}

	private void UpdateProgressAndFulfillment(ElementGroup updatedGroup, bool newClosed)
	{
		if (!(updatedGroup.GroupType == groupType))
		{
			return;
		}
		if (!newClosed || updatedGroup.IsAboutToBeRemoved)
		{
			if (validGroups.Contains(updatedGroup))
			{
				currentProgress--;
				validGroups.Remove(updatedGroup);
				hasProgressChanged = true;
			}
		}
		else if (updatedGroup.ConditionCount(countTarget, elementType) >= targetGroupSizePerLevel[CurrentLevelIndex] && !validGroups.Contains(updatedGroup))
		{
			validGroups.Add(updatedGroup);
			currentProgress++;
			hasProgressChanged = true;
		}
		ProgressChanged(save: false);
	}

	public override void StopWatching()
	{
		base.StopWatching();
		validGroups.Clear();
		if ((bool)sessionQuestWatcher)
		{
			sessionQuestWatcher.ElementGroupManager.OnGroupClosed -= UpdateProgressAndFulfillment;
			sessionQuestWatcher.ElementGroupManager.OnGroupRemoved -= RemoveGroup;
		}
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= StoreProgress;
	}
}
