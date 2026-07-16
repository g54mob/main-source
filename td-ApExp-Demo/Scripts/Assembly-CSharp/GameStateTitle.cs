public class GameStateTitle : StateBase
{
	public override string Key => "Title";

	public GameStateTitle(StateMachine sm)
		: base(sm)
	{
	}

	public GameStateTitle(StateMachine sm, params string[] transitionStates)
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
		CameraController.Instance.EnterHubTween();
	}
}
