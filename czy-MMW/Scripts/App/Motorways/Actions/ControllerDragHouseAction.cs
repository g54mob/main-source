using Factory;
using Motorways.UI;
using Motorways.Views;

namespace Motorways.Actions
{
	public class ControllerDragHouseAction : DragHouseAction
	{
		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			ICreativeModeEditableObject editableObject = base.Scope.Get<EditMenuPanel>().EditableObject;
			if (editableObject is CreativeModeEditableDestination || editableObject is CreativeModeEditableHouse)
			{
				_gameUI.ConfirmEditMenuEdit();
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.InputAction == 2)
			{
				if (draftHouse == null || draftHouse.CompletelyOutOfPlayArea(_city))
				{
					OnActionCancel();
				}
				else
				{
					OnActionComplete();
				}
			}
			else if (inputEvent.InputAction == 18 || inputEvent.InputAction == 7)
			{
				OnActionCancel();
			}
			else
			{
				PlayerAction.Log.Error($"Unexpected input: {inputEvent}!");
				OnActionCancel();
			}
		}

		public new static ControllerDragHouseAction CreateFromUpgradeMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, fromUpgradeMenu: true);
		}

		public new static ControllerDragHouseAction CreateFromEditMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, fromUpgradeMenu: false);
		}

		public new static ControllerDragHouseAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp, bool fromUpgradeMenu)
		{
			ControllerDragHouseAction controllerDragHouseAction = scope.Get<ControllerDragHouseAction>();
			controllerDragHouseAction.fromUpgradeMenu = fromUpgradeMenu;
			controllerDragHouseAction.InitializeAction(owningGroup, timestamp);
			controllerDragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragHouseAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragHouseAction.OnActionBegin(timestamp);
			controllerDragHouseAction.MakeExclusive();
			controllerDragHouseAction.SetWorldGridVisible(visible: true);
			return controllerDragHouseAction;
		}
	}
}
