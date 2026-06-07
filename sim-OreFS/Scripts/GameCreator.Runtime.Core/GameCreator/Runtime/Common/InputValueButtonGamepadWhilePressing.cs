using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Gamepad While Pressing")]
	[Category("Gamepad/Gamepad While Pressing")]
	[Description("While the specified gamepad or joystick button is being held down")]
	[Image(typeof(IconGamepad), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Keywords(new string[] { "Key", "Button", "Down", "Held", "Hold" })]
	public class InputValueButtonGamepadWhilePressing : TInputButton
	{
		[SerializeField]
		private GamepadButton m_Button = GamepadButton.South;

		public static InputPropertyButton Create(GamepadButton button = GamepadButton.South)
		{
			return new InputPropertyButton(new InputValueButtonGamepadWhilePressing
			{
				m_Button = button
			});
		}

		public override void OnUpdate()
		{
			if (Gamepad.all.Count > 0)
			{
				if (Gamepad.current[m_Button].wasPressedThisFrame)
				{
					ExecuteEventStart();
				}
				if (Gamepad.current[m_Button].IsPressed())
				{
					ExecuteEventPerform();
				}
			}
		}
	}
}
