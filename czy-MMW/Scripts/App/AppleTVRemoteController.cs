using Factory;
using Motorways;
using Motorways.Actions;
using Motorways.Views;

public class AppleTVRemoteController : GenericGamepadController, IAppleTVRemoteController, IController
{
	public new static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("AppleTVRemoteController");

	public override string DeviceName => "Apple TV Remote";

	public override void RegisterInputActionsForApp(IScope appScope)
	{
		_inputState.EnsurePollingAxis(0);
		_inputState.EnsurePollingAxis(1);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(0, InputEventButtonState.JustDown), (PlayerActionGroup playerActionGroup, IScope scope, float time) => menuNavigator.CreateNavigateInDirection(0, 1, playerActionGroup, scope, time), appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(1, InputEventButtonState.JustDown), (PlayerActionGroup playerActionGroup, IScope scope, float time) => menuNavigator.CreateNavigateInDirection(0, 1, playerActionGroup, scope, time), appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(2, InputEventButtonState.JustDown), menuNavigator.CreateNavigateAccept, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(7, InputEventButtonState.JustDown), HandleNavigateBack, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(6, InputEventButtonState.JustDown), menuNavigator.CreateNavigateLeftAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(4, InputEventButtonState.JustDown), menuNavigator.CreateNavigateRightAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(5, InputEventButtonState.JustDown), menuNavigator.CreateNavigateDownAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(3, InputEventButtonState.JustDown), menuNavigator.CreateNavigateUpAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(29, InputEventButtonState.JustDown), menuNavigator.CreateNavigateLeftAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(27, InputEventButtonState.JustDown), menuNavigator.CreateNavigateRightAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(28, InputEventButtonState.JustDown), menuNavigator.CreateNavigateDownAction, appScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(26, InputEventButtonState.JustDown), menuNavigator.CreateNavigateUpAction, appScope);
	}

	public override void RegisterInputActionsForGame(IScope gameScope)
	{
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(16, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateToggleSpeed, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(2, InputEventButtonState.JustDown), HandleActivateSelected, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(2, InputEventButtonState.DoubleTapDown), ToggleDrawModeAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(8, InputEventButtonState.JustDown), HandleNavigateBackOrCancel, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(0, InputEventButtonState.Axis), DragMoveInGameFocusAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(1, InputEventButtonState.Axis), DragMoveInGameFocusAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(18, InputEventButtonState.JustDown), ToggleDragClearTileAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.Motorway, InputEventButtonState.JustDown), ControllerDragMotorwayAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.TrafficLight, InputEventButtonState.JustDown), ControllerDragTrafficLightAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.Roundabout, InputEventButtonState.JustDown), ControllerDragRoundaboutAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.MotorwayHandle, InputEventButtonState.JustDown), ControllerDragMotorwayHandleAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.House, InputEventButtonState.JustDown), ControllerDragHouseAction.CreateFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.Destination, InputEventButtonState.JustDown), (PlayerActionGroup owningGroup, IScope scope, float timestamp) => ControllerDragDestinationAction.CreateSingleFromUpgradeMenu(owningGroup, scope, timestamp), gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.DoubleDestination, InputEventButtonState.JustDown), (PlayerActionGroup owningGroup, IScope scope, float timestamp) => ControllerDragDestinationAction.CreateDoubleFromUpgradeMenu(owningGroup, scope, timestamp), gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.MoveCreativeModeObject, InputEventButtonState.JustDown), DragCreativeModeEditableObjectAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(2, InputEventButtonState.JustDown), ToggleCreativeModeEditMenuAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(31, InputEventButtonState.JustDown), ToggleZoomAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(29, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateSlowDown, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateRemoteEventFilter(27, InputEventButtonState.JustDown), ChangeGameSpeedAction.CreateSpeedUp, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateRemoteUIEventFilter(2, GameUIButtonType.EditMenuOpened, InputEventButtonState.JustDown), RemoteEditMenuNavigateAction.Create, gameScope);
	}

	public override InputEventSource GetInputSource()
	{
		return InputEventSource.Remote;
	}

	public PlayerAction HandleNavigateBack(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		_playerActionController.CancelAllActions();
		return menuNavigator.CreateNavigateBack(playerActionGroup, scope, time);
	}

	public PlayerAction HandleNavigateBackOrCancel(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		if (scope.Get<GameUIScreen>().CurrentRoadDrawMode == RoadDrawMode.Remove)
		{
			return ToggleDrawModeAction.Create(playerActionGroup, scope, time);
		}
		return HandleNavigateBack(playerActionGroup, scope, time);
	}

	protected override MotorwaysPlayerAction ControllerDrawRoadAction(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		return Motorways.Actions.ControllerDrawRoadAction.Create(owningGroup, scope, timestamp);
	}

	protected override MotorwaysPlayerAction ControllerDeleteRoadAction(PlayerActionGroup owningGroup, IScope scope, float timestamp)
	{
		return ToggleDragClearTileAction.Create(owningGroup, scope, timestamp);
	}
}
