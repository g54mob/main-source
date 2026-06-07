using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Key Pressed")]
	[Description("Returns true if the keyboard key is pressed during this frame")]
	[Category("Input/Is Key Pressed")]
	[Parameter("Key", "The Keyboard key that is checked")]
	[Keywords(new string[] { "Button", "Down" })]
	[Image(typeof(IconKey), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	public class ConditionInputIsKeyPress : Condition
	{
		[SerializeField]
		protected Key m_Key = Key.Space;

		protected override string Summary => $"{m_Key} just pressed";

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
			return Keyboard.current[m_Key].wasPressedThisFrame;
		}
	}
}
