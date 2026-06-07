using Factory;
using Motorways;
using Motorways.Actions;

public class TouchScreenController : ITouchScreenController, IController
{
	[Dependency]
	protected PlayerActionController _playerActionController;

	public void RegisterInputActionsForApp(IScope appScope)
	{
	}

	public void RegisterInputActionsForGame(IScope gameScope)
	{
		_playerActionController.RegisterAction(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustDown), ToggleCreativeModeEditMenuAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustDown), TouchCameraAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustDown), DrawRoadAction.Create, gameScope);
		_playerActionController.RegisterAction(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustDown), DragEditMotorwayAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.Motorway, InputEventButtonState.JustDown), DragMotorwayAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.TrafficLight, InputEventButtonState.JustDown), DragTrafficLightAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.Roundabout, InputEventButtonState.JustDown), DragRoundaboutAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.MotorwayHandle, InputEventButtonState.JustDown), DragMotorwayHandleAction.Create, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.House, InputEventButtonState.JustDown), DragHouseAction.CreateFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.Destination, InputEventButtonState.JustDown), DragDestinationAction.CreateSingleFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.DoubleDestination, InputEventButtonState.JustDown), DragDestinationAction.CreateDoubleFromUpgradeMenu, gameScope);
		_playerActionController.RegisterAction(MotorwaysUIInputEventFilter.CreateTouchUIEventFilter(0, GameUIButtonType.MoveCreativeModeObject, InputEventButtonState.JustDown), DragCreativeModeEditableObjectAction.Create, gameScope);
	}

	public void OnControllerConnected()
	{
	}

	public void OnControllerDisconnected()
	{
	}

	public void EnsureActionsAreRegistered(IScope scope)
	{
	}

	public virtual InputEventSource GetInputSource()
	{
		return InputEventSource.Touch;
	}
}
