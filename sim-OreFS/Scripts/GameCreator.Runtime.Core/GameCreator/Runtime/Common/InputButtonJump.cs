using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Jump")]
	[Category("Usage/Jump")]
	[Description("Cross-device support for the 'Jump' skill: Space key on Keyboards and the South Button on Gamepads")]
	[Image(typeof(IconCharacterJump), ColorTheme.Type.Green)]
	public class InputButtonJump : TInputButtonInputAction
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public override InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Jump", InputActionType.Button);
					m_InputAction.AddBinding("<Gamepad>/buttonSouth");
					m_InputAction.AddBinding("<Keyboard>/space");
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
			return new InputPropertyButton(new InputButtonJump());
		}
	}
}
