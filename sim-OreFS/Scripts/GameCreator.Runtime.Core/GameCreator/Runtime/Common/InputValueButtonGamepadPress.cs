using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Gamepad Press")]
	[Category("Gamepad/Gamepad Press")]
	[Description("When a gamepad or joystick key is pressed")]
	[Image(typeof(IconGamepad), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	[Keywords(new string[] { "Key", "Button", "Down", "Joystick" })]
	public class InputValueButtonGamepadPress : TInputButton
	{
		[SerializeField]
		private GamepadButton m_Button = GamepadButton.South;

		public static InputPropertyButton Create(GamepadButton button = GamepadButton.South)
		{
			return new InputPropertyButton(new InputValueButtonGamepadPress
			{
				m_Button = button
			});
		}

		public override void OnUpdate()
		{
			if (Gamepad.all.Count > 0 && Gamepad.current[m_Button].wasPressedThisFrame)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}
	}
}
