public class EventObjectiveCompleteDaily : EventObjectiveBase
{
	public EventObjectiveCompleteDaily(int goal)
		: base("complete_daily", goal)
	{
		description = Te.xt("tid_q_basic_complete_dailies");
	}

	public override bool CheckConditions()
	{
		if (!EventController.singleton.IsObjectiveActive("complete_daily"))
		{
			CustomQuestsController.Singleton.GenerateRandomBasicQuest();
		}
		return true;
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
		if (quest.IsBasic)
		{
			AddProgress();
		}
	}
}
