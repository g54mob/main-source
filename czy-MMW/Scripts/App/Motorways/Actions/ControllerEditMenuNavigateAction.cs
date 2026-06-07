using Factory;
using UnityEngine;

namespace Motorways.Actions
{
	public class ControllerEditMenuNavigateAction : EditMenuNavigateAction
	{
		protected override void OnTick()
		{
			Vector2 moveFocusJoystickInputValue = GetMoveFocusJoystickInputValue();
			if (!(moveFocusJoystickInputValue.magnitude < 0.6f))
			{
				EditMenu.SelectButtonAtDirection(moveFocusJoystickInputValue);
			}
		}

		public static ControllerEditMenuNavigateAction Create(PlayerActionGroup playerActionGroup, IScope scope, float timestamp)
		{
			ControllerEditMenuNavigateAction controllerEditMenuNavigateAction = scope.Get<ControllerEditMenuNavigateAction>();
			controllerEditMenuNavigateAction.InitializeAction(playerActionGroup, timestamp);
			controllerEditMenuNavigateAction.OnActionBegin(timestamp);
			return controllerEditMenuNavigateAction;
		}
	}
}
