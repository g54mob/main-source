using System;
using GameCreator.Runtime.Common;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Mouse Pressed")]
	[Description("Returns true if the mouse button is pressed during this frame")]
	[Category("Input/Is Mouse Pressed")]
	[Keywords(new string[] { "Key", "Down" })]
	[Image(typeof(IconMouse), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	public class ConditionInputMousePress : TConditionMouse
	{
		protected override string Summary => $"Mouse {m_Button} just pressed";

		protected override bool Run(Args args)
		{
			Mouse current = Mouse.current;
			if (current == null)
			{
				return false;
			}
			return m_Button switch
			{
				Button.Left => current.leftButton.wasPressedThisFrame, 
				Button.Right => current.rightButton.wasPressedThisFrame, 
				Button.Middle => current.middleButton.wasPressedThisFrame, 
				Button.Forward => current.forwardButton.wasPressedThisFrame, 
				Button.Back => current.backButton.wasPressedThisFrame, 
				_ => throw new ArgumentOutOfRangeException($"Mouse '{m_Button}' not found"), 
			};
		}
	}
}
