using Factory;

namespace Motorways.Actions
{
	public class ControllerDragMotorwayHandleAction : DragMotorwayHandleAction
	{
		[Dependency]
		private GameCamera _camera;

		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			_gameUI.SetFocusPointActive(active: false);
			_gameUI.SetFocusPointBlocked(blocked: true);
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			ResetFocusPoint();
		}

		public override void OnActionComplete()
		{
			base.OnActionComplete();
			ResetFocusPoint();
		}

		private void ResetFocusPoint()
		{
			_gameUI.SetFocusPointBlocked(blocked: false);
			_gameUI.SetFocusPointPosition(_camera.GetScreenFromWorld(_motorwayView.HandlePosition));
			_gameUI.SetFocusPointActive(active: true);
		}

		public new static ControllerDragMotorwayHandleAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ControllerDragMotorwayHandleAction controllerDragMotorwayHandleAction = scope.Get<ControllerDragMotorwayHandleAction>();
			controllerDragMotorwayHandleAction.InitializeAction(owningGroup, timestamp);
			MotorwaysUIInputEvent motorwaysUIInputEvent = owningGroup.InstigatingInputEvent as MotorwaysUIInputEvent;
			controllerDragMotorwayHandleAction._editedMotorwayId = motorwaysUIInputEvent.UIButtonIndex;
			controllerDragMotorwayHandleAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragMotorwayHandleAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragMotorwayHandleAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragMotorwayHandleAction.OnActionBegin(timestamp);
			return controllerDragMotorwayHandleAction;
		}
	}
}
