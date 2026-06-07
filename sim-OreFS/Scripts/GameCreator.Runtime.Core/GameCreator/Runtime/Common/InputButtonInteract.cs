using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Interact")]
	[Category("Usage/Interact")]
	[Description("Cross-device support for the 'Interact' skill: E key on Keyboards and pressing the West Stick on Gamepads")]
	[Image(typeof(IconCharacterInteract), ColorTheme.Type.Green)]
	public class InputButtonInteract : TInputButtonInputAction
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public override InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Interact", InputActionType.Button);
					m_InputAction.AddBinding("<Gamepad>/buttonWest");
					m_InputAction.AddBinding("<Keyboard>/e");
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
			return new InputPropertyButton(new InputButtonInteract());
		}
	}
}
