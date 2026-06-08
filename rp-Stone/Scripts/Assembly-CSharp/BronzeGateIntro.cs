using UnityEngine;

public class BronzeGateIntro : Decoration
{
	private enum State
	{
		Waiting = 0,
		Approach = 1,
		Dialog = 2,
		Done = 3
	}

	public int approachDistance = 25;

	public int approachOffsetX = 4;

	public int approachOffsetZ = 2;

	public int cameraOffsetX = 5;

	public int cameraOffsetZ = -3;

	public float cameraLerpSpeed = 0.15f;

	public string dialogLine1 = "A conspicuous Bronze Gate";

	public string dialogLine2 = "is built into the cliffside";

	public string buttonLabel1 = "Examine";

	public string buttonLabel2 = "Examine Later";

	private State currentState;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Approach:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + approachOffsetX, base.PositionZ + approachOffsetZ);
			GameStates.Singleton.level.gameCamera.SetupLerpToPos(base.PositionX + cameraOffsetX, 0, base.PositionZ + cameraOffsetZ, cameraLerpSpeed);
			break;
		case State.Dialog:
			GameStates.Singleton.playChoiceDialog.SetupText(dialogLine1 + "\n" + dialogLine2, buttonLabel1, buttonLabel2, KeyCode.E, KeyCode.L);
			GameStates.Singleton.playChoiceDialog.button1.OnPressed += HandleButton1;
			GameStates.Singleton.playChoiceDialog.button2.OnPressed += HandleButton2;
			GameStates.Singleton.ShowPlayChoiceDialog();
			break;
		case State.Done:
			GameStates.Singleton.playChoiceDialog.button1.OnPressed -= HandleButton1;
			GameStates.Singleton.playChoiceDialog.button2.OnPressed -= HandleButton2;
			ProgressFlags.SetFlag("reveal_bronze_gate", value: false);
			QuestController.singleton.MakeAvailable("bronze_gate");
			GameStates.Singleton.hero.RestoreAI();
			GameStates.Singleton.level.gameCamera.SetState(GameCamera.State.RelativeToHero);
			break;
		}
		currentState = newState;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (currentState == State.Waiting)
		{
			if (base.PositionX - GameStates.Singleton.hero.PositionX < approachDistance)
			{
				SetState(State.Approach);
			}
		}
		else if (currentState == State.Approach && GameStates.Singleton.hero.PositionX == base.PositionX + approachOffsetX && GameStates.Singleton.hero.PositionZ == base.PositionZ + approachOffsetZ)
		{
			SetState(State.Dialog);
		}
	}

	private void HandleButton1(DialogButton button)
	{
		Data.Quest questById = QuestController.singleton.GetQuestById("bronze_gate");
		GameStates.Singleton.StartQuest(questById);
		SetState(State.Done);
	}

	private void HandleButton2(DialogButton button)
	{
		GameStates.Singleton.SetState(GameStates.State.Playing);
		SetState(State.Done);
	}
}
