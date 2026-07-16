public class GameStatePlay : StateBase
{
	public override string Key => "Play";

	public GameStatePlay(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[1] { "Menu" };
	}

	public GameStatePlay(StateMachine sm, params string[] transitionStates)
		: base(sm, transitionStates)
	{
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
	}

	public override void UpdateState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}

	public override void ExitState()
	{
	}
}
