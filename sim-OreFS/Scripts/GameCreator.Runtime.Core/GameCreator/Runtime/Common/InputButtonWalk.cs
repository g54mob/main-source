using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Walk")]
	[Category("Usage/Walk")]
	[Description("Cross-device support for the 'Walk' skill: Z key on Keyboards and the pressing Left Stick on Gamepads")]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Green)]
	public class InputButtonWalk : TInputButtonInputAction
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public override InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Walk", InputActionType.Button);
					m_InputAction.AddBinding("<Gamepad>/leftStickPress");
					m_InputAction.AddBinding("<Keyboard>/z");
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
			return new InputPropertyButton(new InputButtonWalk());
		}
	}
}
