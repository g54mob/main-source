public class EventObjectiveReplayQuest : EventObjectiveBase
{
	private string questId;

	public EventObjectiveReplayQuest(int goal, string questId, string questName)
		: base("replay_quest", goal)
	{
		this.questId = questId;
		description = string.Format(Te.xt("Replay {0} and look for an alternate ending"), questName);
	}

	public override void Init()
	{
		CustomQuestsController.Singleton.OnQuestCompleted += HandleQuestCompleted;
	}

	public override void End()
	{
		CustomQuestsController.Singleton.OnQuestCompleted -= HandleQuestCompleted;
	}

	private void HandleQuestCompleted(Data.CustomQuestInstance quest)
	{
		if (quest.customQuestId == questId)
		{
			AddProgress();
		}
	}
}
