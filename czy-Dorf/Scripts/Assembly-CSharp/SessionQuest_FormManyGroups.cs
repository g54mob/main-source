using System.Collections.Generic;
using UnityEngine;

public class SessionQuest_FormManyGroups : SessionQuest
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
		int num = ((level == -1) ? CurrentLevelIndex : level);
		string localizedValue = LocalizationManager.Instance.GetLocalizedValue(descriptionKey);
		localizedValue = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(localizedValue, TargetCount(num));
		localizedValue = localizedValue.Replace("[y]", targetGroupSizePerLevel[num].ToString());
		return localizedValue.Replace("[x]", TargetCount(num).ToString());
	}

	public override void StartWatching(SessionQuestWatcher sessionQuestWatcher)
	{
		base.StartWatching(sessionQuestWatcher);
		if (!base.Completed)
		{
			validGroups = new List<ElementGroup>();
			hasProgressChanged = false;
			sessionQuestWatcher.ElementGroupManager.OnGroupChanged += UpdateProgressAndFulfillment;
			sessionQuestWatcher.ElementGroupManager.OnGroupRemoved += RemoveGroup;
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += StoreProgress;
		}
	}

	private void StoreProgress(Tile obj, bool isPlacedByPlayer)
	{
		if (validGroups.Count != 0 && hasProgressChanged && isPlacedByPlayer)
		{
			if (storeProgress)
			{
				sessionQuestWatcher.SessionQuestManager.UpdateSessionQuestData(this, save: true);
			}
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

	private void UpdateProgressAndFulfillment(ElementGroup updatedGroup)
	{
		if (!(updatedGroup.GroupType == groupType))
		{
			return;
		}
		if (updatedGroup.IsAboutToBeRemoved)
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
		sessionQuestWatcher.ElementGroupManager.OnGroupChanged -= UpdateProgressAndFulfillment;
		sessionQuestWatcher.ElementGroupManager.OnGroupRemoved -= RemoveGroup;
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= StoreProgress;
	}
}
