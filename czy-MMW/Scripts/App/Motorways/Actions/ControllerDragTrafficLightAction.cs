using Factory;
using Motorways.UI;

namespace Motorways.Actions
{
	public class ControllerDragTrafficLightAction : DragTrafficLightAction
	{
		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		protected override void InitializeUpgradeCursor()
		{
			base.InitializeUpgradeCursor();
			_gameUI.SetUpgradeCursorPosition(GetPointerScreenPosition(), UpgradeCursor.UpgradeCursorOffsetType.OnPointer);
		}

		protected override void UpdateUpgradeCursorPosition()
		{
			_gameUI.SetUpgradeCursorPosition(GetPointerScreenPosition(), UpgradeCursor.UpgradeCursorOffsetType.OnPointer);
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.InputAction == 2)
			{
				OnActionComplete();
			}
			else
			{
				OnActionCancel();
			}
		}

		public new static ControllerDragTrafficLightAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ControllerDragTrafficLightAction controllerDragTrafficLightAction = scope.Get<ControllerDragTrafficLightAction>();
			controllerDragTrafficLightAction.InitializeAction(owningGroup, timestamp);
			controllerDragTrafficLightAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragTrafficLightAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragTrafficLightAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragTrafficLightAction.OnActionBegin(timestamp);
			return controllerDragTrafficLightAction;
		}
	}
}
