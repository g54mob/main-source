public class EventObjectiveVisitUulaa : EventObjectiveBase
{
	private int framesRemaining;

	public EventObjectiveVisitUulaa()
		: base("visit_uulaa", 1)
	{
		string format = Te.xt("tid_q_basic_visit_holiday_fem");
		description = string.Format(format, Te.xt("Uulaa"));
	}

	public override void Init()
	{
		GameStates.OnQuestStarting += HandleQuestStarted;
	}

	public override void End()
	{
		GameStates.OnQuestStarting -= HandleQuestStarted;
		GameStates.Singleton.hero.OnUpdateTic -= HandleUpdate;
	}

	private void HandleQuestStarted(Data.Quest quest)
	{
		if (quest.id == "uulaa_shop")
		{
			framesRemaining = 5;
			GameStates.Singleton.hero.OnUpdateTic += HandleUpdate;
		}
	}

	private void HandleUpdate(Character c)
	{
		if (--framesRemaining <= 0)
		{
			GameStates.Singleton.hero.OnUpdateTic -= HandleUpdate;
			AddProgress();
		}
	}
}
