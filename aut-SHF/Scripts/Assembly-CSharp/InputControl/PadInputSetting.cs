using System;
using UnityEngine.InputSystem;

namespace InputControl
{
	public abstract class PadInputSetting
	{
		public Action<InputAction.CallbackContext> Escape;

		public Action<InputAction.CallbackContext> Reset;

		public Action<InputAction.CallbackContext> MousePosition;

		public Action<InputAction.CallbackContext> MouseScroll;

		public Action<InputAction.CallbackContext> MouseLeftClick;

		public Action<InputAction.CallbackContext> MouseRightClick;

		public Action<InputAction.CallbackContext> Left;

		public Action<InputAction.CallbackContext> Right;

		public Action<InputAction.CallbackContext> Up;

		public Action<InputAction.CallbackContext> Down;

		public Action<InputAction.CallbackContext> Switch;

		public Action<InputAction.CallbackContext> LeftTrigger;

		public Action<InputAction.CallbackContext> RightTrigger;

		public Action<InputAction.CallbackContext> Decide;

		public Action<InputAction.CallbackContext> Cancel;

		public Action<InputAction.CallbackContext> Select;

		public Action<InputAction.CallbackContext> LeftShoulder;

		public Action<InputAction.CallbackContext> RightShoulder;

		public Action<InputAction.CallbackContext> SubMenu;

		public Action<InputAction.CallbackContext> Start;

		public Action<InputAction.CallbackContext> RightStickPush;
	}
}
