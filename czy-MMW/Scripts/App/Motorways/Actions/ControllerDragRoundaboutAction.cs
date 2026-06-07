using Factory;
using Motorways.UI;

namespace Motorways.Actions
{
	public class ControllerDragRoundaboutAction : DragRoundaboutAction
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

		public new static ControllerDragRoundaboutAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ControllerDragRoundaboutAction controllerDragRoundaboutAction = scope.Get<ControllerDragRoundaboutAction>();
			controllerDragRoundaboutAction.InitializeAction(owningGroup, timestamp);
			controllerDragRoundaboutAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragRoundaboutAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragRoundaboutAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragRoundaboutAction.OnActionBegin(timestamp);
			return controllerDragRoundaboutAction;
		}
	}
}
