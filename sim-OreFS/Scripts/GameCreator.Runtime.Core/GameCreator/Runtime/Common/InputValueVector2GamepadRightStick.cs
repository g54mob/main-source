using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Gamepad Right Stick")]
	[Category("Gamepad/Gamepad Right Stick")]
	[Description("The Right Stick direction")]
	[Image(typeof(IconJoystick), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Cursor", "Location", "Move", "Pan" })]
	public class InputValueVector2GamepadRightStick : TInputValueVector2
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Right Stick", InputActionType.Value, "<Gamepad>/rightStick");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2GamepadRightStick());
		}

		public override void OnStartup()
		{
			Enable();
		}

		public override void OnDispose()
		{
			Disable();
			InputAction?.Dispose();
		}

		public override Vector2 Read()
		{
			return InputAction?.ReadValue<Vector2>() ?? Vector2.zero;
		}

		private void Enable()
		{
			InputAction?.Enable();
		}

		private void Disable()
		{
			InputAction?.Disable();
		}
	}
}
