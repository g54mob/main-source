public class GameStateEnd : StateBase
{
	public override string Key => "End";

	public GameStateEnd(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[0];
	}

	public GameStateEnd(StateMachine sm, params string[] transitionStates)
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
		return false;
	}

	public override void ExitState()
	{
	}
}
