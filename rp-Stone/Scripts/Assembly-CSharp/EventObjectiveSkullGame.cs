public class EventObjectiveSkullGame : EventObjectiveBase
{
	public EventObjectiveSkullGame(int goal)
		: base("skull_game", goal)
	{
		description = Te.xt("tid_quest_basic_skull_game");
	}

	public override void Init()
	{
		UndeadCryptIntro.OnSkullGameWon += HandleSkullGamePlayed;
	}

	public override void End()
	{
		UndeadCryptIntro.OnSkullGameWon -= HandleSkullGamePlayed;
	}

	private void HandleSkullGamePlayed()
	{
		AddProgress();
	}
}
