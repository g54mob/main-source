using Factory;
using Motorways.Actions;

public class ToggleGameUIAction : MotorwaysPlayerAction
{
	public override void OnActionBegin(float timestamp)
	{
		bool flag = !_gameUI.IsUiVisible;
		_gameUI.SetUIVisible(flag, instantly: false, forceHide: true);
		_gameUI.SetDrawButtonsVisible(flag);
		_gameUI.SetFocusPointActive(flag);
	}

	public override void Tick(float frameTime)
	{
		OnActionComplete();
	}

	public static ToggleGameUIAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		ToggleGameUIAction toggleGameUIAction = scope.Get<ToggleGameUIAction>();
		toggleGameUIAction.InitializeAction(owningGroup, timestamp);
		toggleGameUIAction.OnActionBegin(timestamp);
		return toggleGameUIAction;
	}
}
