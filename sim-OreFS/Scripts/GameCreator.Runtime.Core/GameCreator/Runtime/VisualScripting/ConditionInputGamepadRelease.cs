using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Gamepad Button Released")]
	[Description("Returns true if the Gamepad button is released during this frame")]
	[Category("Input/Is Gamepad Button Released")]
	[Parameter("Button", "The Gamepad button that is checked")]
	[Keywords(new string[] { "Key", "Up" })]
	[Image(typeof(IconGamepad), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class ConditionInputGamepadRelease : Condition
	{
		[SerializeField]
		protected GamepadButton m_Button = GamepadButton.South;

		protected override string Summary => $"{m_Button} just released";

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
			return Gamepad.current[m_Button].wasReleasedThisFrame;
		}
	}
}
