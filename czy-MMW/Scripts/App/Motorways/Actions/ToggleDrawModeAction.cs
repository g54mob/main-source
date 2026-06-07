using Factory;

namespace Motorways.Actions
{
	public class ToggleDrawModeAction : MotorwaysPlayerAction
	{
		[Dependency]
		private PlayerActionController _playerActionController;

		public override void OnActionBegin(float timestamp)
		{
			_playerActionController.CancelAllActions();
			SetColourWidgetRadialVisible(visible: false);
			base.OnActionBegin(timestamp);
			_gameUI.ToggleDrawMode();
		}

		public override void Tick(float frameTime)
		{
			OnActionComplete();
		}

		public static ToggleDrawModeAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ToggleDrawModeAction toggleDrawModeAction = scope.Get<ToggleDrawModeAction>();
			toggleDrawModeAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Keyboard && !scope.Get<ActivePlayer>().IsDrawModeToggleEnabled)
			{
				toggleDrawModeAction.OnActionCancel();
			}
			else
			{
				toggleDrawModeAction.OnActionBegin(timestamp);
			}
			return toggleDrawModeAction;
		}
	}
}
