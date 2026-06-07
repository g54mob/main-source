using System;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Key Released")]
	[Description("Returns true if the keyboard key is released during this frame")]
	[Category("Input/Is Key Released")]
	[Parameter("Key", "The Keyboard key that is checked")]
	[Keywords(new string[] { "Button", "Up" })]
	[Image(typeof(IconKey), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class ConditionInputKeyRelease : Condition
	{
		[SerializeField]
		protected Key m_Key = Key.Space;

		protected override string Summary => $"{m_Key} just released";

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
			return Keyboard.current[m_Key].wasReleasedThisFrame;
		}
	}
}
