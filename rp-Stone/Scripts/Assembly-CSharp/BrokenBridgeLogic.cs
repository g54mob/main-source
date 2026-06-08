public class BrokenBridgeLogic : Decoration
{
	private enum State
	{
		Waiting = 0,
		SmallPause = 1,
		Dialog = 2
	}

	private const int DIALOG_DISTANCE = 12;

	private State currentState;

	private int elapsedStateTics;

	private void SetState(State newState)
	{
		if (newState == State.Dialog)
		{
			SfxController.singleton.Play("prompt_choice");
			GameStates.Singleton.ShowPlayChoiceDialog("tid_brige_1", "Leave", Binding.Action.Leave);
			GameStates.Singleton.playChoiceDialog.buttonSingle.OnPressed += HandleButtonPressed;
		}
		currentState = newState;
		elapsedStateTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedStateTics++;
		if (currentState == State.Waiting && base.PositionX - GameStates.Singleton.hero.PositionX <= 12)
		{
			SetState(State.SmallPause);
		}
		else if (currentState == State.SmallPause && elapsedStateTics >= 10)
		{
			SetState(State.Dialog);
		}
	}

	private void HandleButtonPressed(DialogButton btn)
	{
		btn.OnPressed -= HandleButtonPressed;
		GameStates.Singleton.CompleteQuest();
	}
}
