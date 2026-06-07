using Factory;
using Motorways.Actions;

public class KeyboardController : BaseController, IKeyboardController, IController
{
	[Dependency]
	protected MenuNavigation menuNavigator;

	public override string DeviceName => "Keyboard";

	public override void RegisterInputActionsForApp(IScope appScope)
	{
		base.RegisterInputActionsForApp(appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(6, InputEventButtonState.JustDown), menuNavigator.CreateNavigateLeftAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(4, InputEventButtonState.JustDown), menuNavigator.CreateNavigateRightAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(5, InputEventButtonState.JustDown), menuNavigator.CreateNavigateDownAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(3, InputEventButtonState.JustDown), menuNavigator.CreateNavigateUpAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(2, InputEventButtonState.JustDown), menuNavigator.CreateNavigateAccept, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(7, InputEventButtonState.JustDown), menuNavigator.CreateNavigateBack, appScope);
	}

	public override void RegisterInputActionsForGame(IScope gameScope)
	{
		base.RegisterInputActionsForGame(gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(13, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreatePauseSpeed, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(14, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreatePlaySpeed, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(15, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateFastForwardSpeed, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(45, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateExtraFastForwardSpeed, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(16, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateToggleSpeed, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(11, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateSlowDown, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(10, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateSpeedUp, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(21, InputEventButtonState.JustDown), ChangeUpgradeBarAction.CreateShowOrLockUpgradeBar, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(22, InputEventButtonState.JustDown), ChangeUpgradeBarAction.CreateHideUpgradeBar, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(9, InputEventButtonState.JustDown), ToggleDrawModeAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(40, InputEventButtonState.JustDown), ToggleZoomAction.CreateZoomIn, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(41, InputEventButtonState.JustDown), ToggleZoomAction.CreateZoomOut, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateKeyboardEventFilter(44, InputEventButtonState.JustDown), OpenElectiveUpgradeScreenAction.Create, gameScope);
	}
}
