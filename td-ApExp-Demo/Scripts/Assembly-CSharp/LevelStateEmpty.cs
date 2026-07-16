public class LevelStateEmpty : LevelBaseState
{
	public override string Key => "Empty";

	public LevelStateEmpty(StateMachine sm)
		: base(sm)
	{
		transitionStates = new string[1] { "Station" };
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
