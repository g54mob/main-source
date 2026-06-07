using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Key Held Down")]
	[Description("Returns true if the keyboard key is being held down this frame")]
	[Category("Input/Is Key Held Down")]
	[Parameter("Key", "The Keyboard key that is checked")]
	[Keywords(new string[] { "Button", "Active", "Down", "Press" })]
	[Image(typeof(IconKey), ColorTheme.Type.Blue, typeof(OverlayDot))]
	public class ConditionInputKeyHeldDown : Condition
	{
		[SerializeField]
		protected Key m_Key = Key.Space;

		protected override string Summary => $"{m_Key} held down";

		public Key Key
		{
			get
			{
				return m_Key;
			}
			set
			{
				m_Key = value;
			}
		}

		protected override bool Run(Args args)
		{
			return Keyboard.current[m_Key].isPressed;
		}
	}
}
