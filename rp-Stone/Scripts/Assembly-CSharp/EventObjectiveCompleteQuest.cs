public class EventObjectiveCompleteQuest : EventObjectiveBase
{
	private string questId;

	public EventObjectiveCompleteQuest(int goal, string questId = null, string questName = null)
		: base("complete_quest", goal)
	{
		this.questId = questId;
		if (questName == null)
		{
			description = Te.xt("tid_q_basic_complete_quest_any");
		}
		else
		{
			description = Te.xt("tid_q_basic_complete_quest") + "\n" + TranslateIfTID(questName);
		}
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
		if (questId == null || quest.customQuestId == questId)
		{
			AddProgress();
		}
	}
}
