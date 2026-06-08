public class EventObjectiveVisitScotty : EventObjectiveBase
{
	private int framesRemaining;

	public EventObjectiveVisitScotty()
		: base("visit_scotty", 1)
	{
		string format = Te.xt("tid_q_basic_visit_holiday_mal");
		description = string.Format(format, Te.xt("Scotty"));
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
		if (quest.id == "undead_crypt_intro")
		{
			framesRemaining = 60;
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
