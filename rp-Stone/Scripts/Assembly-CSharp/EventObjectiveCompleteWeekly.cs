public class EventObjectiveCompleteWeekly : EventObjectiveBase
{
	public EventObjectiveCompleteWeekly()
		: base("complete_weekly", 1)
	{
		description = Te.xt("tid_q_basic_complete_weekly");
	}

	public override bool CheckConditions()
	{
		if (WeeklyQuestsController.singleton.activeQuest != null && !WeeklyQuestsController.singleton.activeQuest.completed)
		{
			return true;
		}
		return false;
	}

	public override void Init()
	{
		WeeklyQuestsController.singleton.OnWeeklyCompleted += HandleWeeklyCompleted;
	}

	public override void End()
	{
		WeeklyQuestsController.singleton.OnWeeklyCompleted -= HandleWeeklyCompleted;
	}

	private void HandleWeeklyCompleted(Data.WeeklyQuest quest)
	{
		AddProgress();
	}
}
