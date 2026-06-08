public class WaterfallFromDeadwoodValley : Decoration
{
	private enum State
	{
		Waiting = 0,
		LevelEnded = 1,
		Done = 2
	}

	private State currentState;

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (currentState == State.Waiting && GameStates.Singleton.hero.PositionX > base.PositionX)
		{
			currentState = State.LevelEnded;
			GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
			gameCamera.SetupLerpToPos(gameCamera.PositionX, gameCamera.PositionY, gameCamera.PositionZ, 0f);
		}
		else if (currentState == State.LevelEnded && GameStates.Singleton.hero.PositionX - GameStates.Singleton.level.gameCamera.PositionX > 28)
		{
			currentState = State.Done;
			Data.Quest questById = QuestController.singleton.GetQuestById("waterfall");
			GameStates.Singleton.StartQuest(questById);
		}
	}
}
