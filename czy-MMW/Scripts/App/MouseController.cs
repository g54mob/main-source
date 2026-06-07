using Factory;
using Motorways;
using Motorways.Actions;

public class MouseController : BaseController, IMouseController, IController
{
	public override string DeviceName => "Mouse";

	public override void RegisterInputActionsForApp(IScope appScope)
	{
		base.RegisterInputActionsForApp(appScope);
		_inputState.EnsurePollingRewiredAction(19);
		_inputState.EnsurePollingRewiredAction(20);
		_inputState.EnsurePollingRewiredAction(25);
	}

	public override void RegisterInputActionsForGame(IScope gameScope)
	{
		base.RegisterInputActionsForGame(gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustDown), DrawRoadAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustDown), ToggleCreativeModeEditMenuAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), DragClearTileAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustDown), DragEditMotorwayAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateMouseEventFilter(30, InputEventButtonState.JustDown), MouseCameraAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.Motorway, InputEventButtonState.JustDown), DragMotorwayAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.TrafficLight, InputEventButtonState.JustDown), DragTrafficLightAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.Roundabout, InputEventButtonState.JustDown), DragRoundaboutAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.MotorwayHandle, InputEventButtonState.JustDown), DragMotorwayHandleAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.House, InputEventButtonState.JustDown), DragHouseAction.CreateFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.Destination, InputEventButtonState.JustDown), DragDestinationAction.CreateSingleFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.DoubleDestination, InputEventButtonState.JustDown), DragDestinationAction.CreateDoubleFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateMouseUIEventFilter(19, GameUIButtonType.MoveCreativeModeObject, InputEventButtonState.JustDown), DragCreativeModeEditableObjectAction.Create, gameScope);
	}
}
