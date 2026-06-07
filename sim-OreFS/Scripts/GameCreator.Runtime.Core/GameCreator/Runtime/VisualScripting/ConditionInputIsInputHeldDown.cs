using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Input Held Down")]
	[Description("Returns true while the Input Action asset with a button behavior is being pressed")]
	[Category("Input/Is Input Held Down")]
	[Parameter("Input", "A reference to the Input Action asset with map and action name")]
	[Keywords(new string[] { "Unity", "Button", "While", "Hold", "Press", "Input", "Action", "System", "Map" })]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue, typeof(OverlayDot))]
	public class ConditionInputIsInputHeldDown : Condition
	{
		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		protected override string Summary => $"{m_Input} held down";

		protected override bool Run(Args args)
		{
			return (m_Input?.InputAction)?.IsPressed() ?? false;
		}
	}
}
