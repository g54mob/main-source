using Factory;
using UnityEngine.EventSystems;

namespace Motorways.Actions
{
	public class PressUIFocusAction : MotorwaysPlayerAction
	{
		protected IController onController;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			if (_gameUI.FocussedSelectable != null)
			{
				ControllerInputEventData eventData = new ControllerInputEventData(EventSystem.current, onController);
				_gameUI.FocussedSelectable.OnSubmit(eventData);
			}
		}

		public override void Tick(float frameTime)
		{
			OnActionComplete();
		}

		public static PressUIFocusAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp, IController controller)
		{
			PressUIFocusAction pressUIFocusAction = scope.Get<PressUIFocusAction>();
			pressUIFocusAction.onController = controller;
			pressUIFocusAction.InitializeAction(owningGroup, timestamp);
			pressUIFocusAction.OnActionBegin(timestamp);
			return pressUIFocusAction;
		}
	}
}
