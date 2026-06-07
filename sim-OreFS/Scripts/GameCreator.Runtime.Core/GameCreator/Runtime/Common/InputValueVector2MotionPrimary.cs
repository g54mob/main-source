using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Primary Motion")]
	[Category("Usage/Primary Motion")]
	[Description("Primary motion commonly used to move the main character: WASD keys on Keyboard and Left Stick on Gamepads")]
	[Image(typeof(IconGamepadCross), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Move", "Joystick", "WASD", "Arrows" })]
	public class InputValueVector2MotionPrimary : TInputValueVector2
	{
		private const float MIN_MAGNITUDE = 0.2f;

		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Primary Motion");
					m_InputAction.AddBinding("<Gamepad>/leftStick");
					m_InputAction.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s")
						.With("Left", "<Keyboard>/a")
						.With("Right", "<Keyboard>/d");
					m_InputAction.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/upArrow").With("Down", "<Keyboard>/downArrow")
						.With("Left", "<Keyboard>/leftArrow")
						.With("Right", "<Keyboard>/rightArrow");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2MotionPrimary());
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
			Vector2 result = InputAction?.ReadValue<Vector2>() ?? Vector2.zero;
			if (!(result.magnitude < 0.2f))
			{
				return result;
			}
			return Vector2.zero;
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
