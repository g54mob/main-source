public class SessionQuest_FormBigGroup : SessionQuest
{
	public CountTarget countTarget;

	public GroupType groupType;

	public ElementType elementType;

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
		}
	}

	protected override void InitializeProgress()
	{
		currentProgress = sessionQuestWatcher.ElementGroupManager.GetGroupCountByCondition(groupType, elementType, EqualityComparison.MoreThan, countTarget);
	}

	private void UpdateProgress(ElementGroup updatedGroup)
	{
		if (updatedGroup.GroupType == groupType)
		{
			currentProgress = sessionQuestWatcher.ElementGroupManager.GetGroupCountByCondition(groupType, elementType, EqualityComparison.MoreThan, countTarget, -1, null, countClosedGroups: true);
			if (!IsFulfilled())
			{
				currentProgress = sessionQuestWatcher.ElementGroupManager.GetGroupCountByCondition(groupType, elementType, EqualityComparison.MoreThan, countTarget);
			}
			ProgressChanged(save: false);
		}
	}

	public override void StopWatching()
	{
		base.StopWatching();
		if ((bool)sessionQuestWatcher)
		{
			sessionQuestWatcher.ElementGroupManager.OnGroupChanged -= UpdateProgress;
		}
	}
}
