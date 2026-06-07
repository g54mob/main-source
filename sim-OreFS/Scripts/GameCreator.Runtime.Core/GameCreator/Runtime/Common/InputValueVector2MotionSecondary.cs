using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Secondary Motion")]
	[Category("Usage/Secondary Motion")]
	[Description("Secondary motion commonly used to orbit the camera around the main character: Move the Mouse and Right Stick on Gamepads")]
	[Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Orbit", "Joystick" })]
	public class InputValueVector2MotionSecondary : TInputValueVector2
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Secondary Motion");
					m_InputAction.AddBinding("<Mouse>/delta", null, "\n                        invertVector2(invertX=false,invertY=true)");
					m_InputAction.AddBinding("<Gamepad>/rightStick", null, "\n                        invertVector2(invertX=false,invertY=true)");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2MotionSecondary());
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
