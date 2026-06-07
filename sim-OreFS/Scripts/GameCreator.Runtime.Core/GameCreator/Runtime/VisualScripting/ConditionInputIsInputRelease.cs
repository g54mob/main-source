using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Input Released")]
	[Description("Returns true if the Input Action asset with a button behavior is released during this frame")]
	[Category("Input/Is Input Released")]
	[Parameter("Input", "A reference to the Input Action asset with map and action name")]
	[Keywords(new string[] { "Unity", "Button", "Up", "Input", "Action", "System", "Map" })]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	public class ConditionInputIsInputRelease : Condition
	{
		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		protected override string Summary => $"{m_Input} just released";

		protected override bool Run(Args args)
		{
			return (m_Input?.InputAction)?.WasReleasedThisFrame() ?? false;
		}
	}
}
