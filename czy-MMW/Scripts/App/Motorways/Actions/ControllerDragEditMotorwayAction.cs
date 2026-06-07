using Factory;

namespace Motorways.Actions
{
	public class ControllerDragEditMotorwayAction : DragEditMotorwayAction
	{
		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			PlayerAction.Log.Info("Beginning drag edit!");
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (base.ActionState == State.Begun)
			{
				if (inputEvent.InputAction == 2)
				{
					PlayerAction.Log.Info("Completing drag edit!");
					OnActionComplete();
				}
				else
				{
					PlayerAction.Log.Info("Cancelling drag edit!");
					OnActionCancel();
				}
			}
			else
			{
				PlayerAction.Log.Info("Completing drag edit!");
				OnActionCancel();
			}
		}

		public new static ControllerDragEditMotorwayAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ControllerDragEditMotorwayAction controllerDragEditMotorwayAction = scope.Get<ControllerDragEditMotorwayAction>();
			controllerDragEditMotorwayAction.InitializeAction(owningGroup, timestamp);
			controllerDragEditMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragEditMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragEditMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragEditMotorwayAction.OnActionBegin(timestamp);
			return controllerDragEditMotorwayAction;
		}
	}
}
