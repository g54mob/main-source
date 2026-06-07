public class RequiredQuest : Requirement
{
	public QuestType questType;

	public Quest cachedQuest;

	public RequiredQuest(QuestType t)
	{
		questType = t;
		if (Crafting.questCache.TryGetValue(questType, out var _))
		{
			TryAddToProcessingQueue();
		}
		else
		{
			questType = QuestType.None;
		}
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		if (GameManager.Instance.globalQuests.TryGetValue(questType, out var value))
		{
			cachedQuest = value;
		}
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		if (GameManager.Instance.globalQuests.TryGetValue(questType, out var value))
		{
			cachedQuest = value;
		}
	}

	public override bool IsMet()
	{
		if (cachedQuest != null)
		{
			return cachedQuest.availability == BuildObjectAvailability.Completed;
		}
		return false;
	}

	public override string ToString()
	{
		return "Required Quest " + questType;
	}
}
