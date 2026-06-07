using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Gamepad Button Held Down")]
	[Description("Returns true if the Gamepad button is being held down this frame")]
	[Category("Input/Is Gamepad Button Held Down")]
	[Parameter("Button", "The Gamepad button that is checked")]
	[Keywords(new string[] { "Key", "Active", "Down", "Press" })]
	[Image(typeof(IconGamepad), ColorTheme.Type.Blue, typeof(OverlayDot))]
	public class ConditionInputGamepadHeldDown : Condition
	{
		[SerializeField]
		protected GamepadButton m_Button = GamepadButton.South;

		protected override string Summary => $"{m_Button} held down";

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
			return Gamepad.current[m_Button].isPressed;
		}
	}
}
