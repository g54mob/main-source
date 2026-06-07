using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Crouch")]
	[Category("Usage/Crouch")]
	[Description("Cross-device support for the 'Crouch' skill: Ctrl key on Keyboards and pressing the Right Stick on Gamepads")]
	[Image(typeof(IconCharacterCrouch), ColorTheme.Type.Green)]
	public class InputButtonCrouch : TInputButtonInputAction
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public override InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Crouch", InputActionType.Button);
					m_InputAction.AddBinding("<Gamepad>/rightStickPress");
					m_InputAction.AddBinding("<Keyboard>/ctrl");
				}
				return m_InputAction;
			}
		}

		protected override void ExecuteEventStart(InputAction.CallbackContext context)
		{
			ExecuteEventStart();
		}

		protected override void ExecuteEventCancel(InputAction.CallbackContext context)
		{
			ExecuteEventCancel();
		}

		protected override void ExecuteEventPerform(InputAction.CallbackContext context)
		{
			ExecuteEventPerform();
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonCrouch());
		}
	}
}
