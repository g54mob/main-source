using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Input Pressed")]
	[Description("Returns true if the Input Action asset with a button behavior is pressed during this frame")]
	[Category("Input/Is Input Pressed")]
	[Parameter("Input", "A reference to the Input Action asset with map and action name")]
	[Keywords(new string[] { "Unity", "Button", "Down", "Input", "Action", "System", "Map" })]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue, typeof(OverlayArrowLeft))]
	public class ConditionInputIsInputAssetPress : Condition
	{
		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		protected override string Summary => $"{m_Input} just pressed";

		protected override bool Run(Args args)
		{
			return (m_Input?.InputAction)?.WasPressedThisFrame() ?? false;
		}
	}
}
