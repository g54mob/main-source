public class EventObjectiveRem5Requirement : EventObjectiveBase
{
	private string questId;

	public EventObjectiveRem5Requirement()
		: base("complete_rem5", 1)
	{
		questId = "epic_remnants_five";
		description = Te.xt("tid_q_basic_complete_quest") + "\n" + Te.xt("tid_q_rem_title");
	}

	public override bool CheckConditions()
	{
		return !CustomQuestsController.Singleton.IsEpicCompleted(questId);
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
