using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Gamepad Button Pressed")]
	[Description("Returns true if the Gamepad button is pressed during this frame")]
	[Category("Input/Is Gamepad Button Pressed")]
	[Parameter("Button", "The Gamepad button that is checked")]
	[Keywords(new string[] { "Button", "Down", "Key" })]
	[Image(typeof(IconGamepad), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	public class ConditionInputIsGamepadPress : Condition
	{
		[SerializeField]
		protected GamepadButton m_Button = GamepadButton.South;

		protected override string Summary => $"{m_Button} just pressed";

		public GamepadButton Button
		{
			get
			{
				return m_Button;
			}
			set
			{
				m_Button = value;
			}
		}

		protected override bool Run(Args args)
		{
			return Gamepad.current[m_Button].wasPressedThisFrame;
		}
	}
}
