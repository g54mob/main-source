using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Gamepad Release")]
	[Category("Gamepad/Gamepad Release")]
	[Description("When a gamepad or joystick key is released")]
	[Image(typeof(IconGamepad), ColorTheme.Type.Yellow, typeof(OverlayArrowUp))]
	[Keywords(new string[] { "Key", "Button", "Up", "Joystick" })]
	public class InputValueButtonGamepadRelease : TInputButton
	{
		[SerializeField]
		private GamepadButton m_Button = GamepadButton.South;

		public static InputPropertyButton Create(GamepadButton button = GamepadButton.South)
		{
			return new InputPropertyButton(new InputValueButtonGamepadRelease
			{
				m_Button = button
			});
		}

		public override void OnUpdate()
		{
			if (Gamepad.all.Count > 0 && Gamepad.current[m_Button].wasReleasedThisFrame)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}
	}
}
