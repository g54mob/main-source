using Factory;

public class InGameInputStateChangeAction : PlayerAction
{
	[Dependency]
	protected MotorwaysInGameStateToggleController _motorwaysController;

	protected MotorwaysInGameStateToggleController.InGameControllerState _action;

	protected MotorwaysInGameStateToggleController.StateSwapActionBehaviour _swapActionBehaviour;

	public override void OnActionBegin(float timestamp)
	{
		base.OnActionBegin(timestamp);
		_motorwaysController.SwitchToState(_action, base.Scope, _swapActionBehaviour);
	}

	public override void Tick(float frameTime)
	{
		OnActionComplete();
	}

	public static InGameInputStateChangeAction CreateSwitchToState(PlayerActionGroup owningGroup, IScope scope, float timestamp, MotorwaysInGameStateToggleController.InGameControllerState stateChangeAction, MotorwaysInGameStateToggleController.StateSwapActionBehaviour swapActionBehaviour = MotorwaysInGameStateToggleController.StateSwapActionBehaviour.MaintainActions)
	{
		InGameInputStateChangeAction inGameInputStateChangeAction = scope.Get<InGameInputStateChangeAction>();
		inGameInputStateChangeAction._action = stateChangeAction;
		inGameInputStateChangeAction._swapActionBehaviour = swapActionBehaviour;
		inGameInputStateChangeAction.Scope = scope;
		inGameInputStateChangeAction.InitializeAction(owningGroup, timestamp);
		inGameInputStateChangeAction.OnActionBegin(timestamp);
		return inGameInputStateChangeAction;
	}
}
