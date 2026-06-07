using Factory;
using Motorways.UI;
using Motorways.Views;

namespace Motorways.Actions
{
	public class ControllerDragDestinationAction : DragDestinationAction
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
				if (draftDestination == null || draftDestination.CompletelyOutOfPlayArea(_city))
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

		public new static ControllerDragDestinationAction CreateSingleFromEditMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: false, fromUpgradeMenu: false);
		}

		public new static ControllerDragDestinationAction CreateDoubleFromEditMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: true, fromUpgradeMenu: false);
		}

		public new static ControllerDragDestinationAction CreateSingleFromUpgradeMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: false, fromUpgradeMenu: true);
		}

		public new static ControllerDragDestinationAction CreateDoubleFromUpgradeMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: true, fromUpgradeMenu: true);
		}

		private static ControllerDragDestinationAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp, bool isDouble, bool fromUpgradeMenu)
		{
			ControllerDragDestinationAction controllerDragDestinationAction = scope.Get<ControllerDragDestinationAction>();
			controllerDragDestinationAction.isDouble = isDouble;
			controllerDragDestinationAction.fromUpgradeMenu = fromUpgradeMenu;
			controllerDragDestinationAction.InitializeAction(owningGroup, timestamp);
			controllerDragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragDestinationAction.OnActionBegin(timestamp);
			controllerDragDestinationAction.MakeExclusive();
			controllerDragDestinationAction.SetWorldGridVisible(visible: true);
			return controllerDragDestinationAction;
		}
	}
}
