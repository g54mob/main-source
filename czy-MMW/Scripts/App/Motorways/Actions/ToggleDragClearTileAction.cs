using Factory;

namespace Motorways.Actions
{
	public class ToggleDragClearTileAction : DragClearTileAction
	{
		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		public override void OnActionBegin(float timestamp)
		{
			if (_gameUI.CurrentRoadDrawMode != RoadDrawMode.Remove)
			{
				OnActionCancel();
			}
			else
			{
				base.OnActionBegin(timestamp);
			}
		}

		public new static ToggleDragClearTileAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ToggleDragClearTileAction toggleDragClearTileAction = scope.Get<ToggleDragClearTileAction>();
			toggleDragClearTileAction.InitializeAction(owningGroup, timestamp);
			toggleDragClearTileAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			toggleDragClearTileAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			toggleDragClearTileAction.OnActionBegin(timestamp);
			return toggleDragClearTileAction;
		}
	}
}
