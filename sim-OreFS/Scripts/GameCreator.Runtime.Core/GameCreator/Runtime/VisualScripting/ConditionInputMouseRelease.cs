using System;
using GameCreator.Runtime.Common;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Mouse Released")]
	[Description("Returns true if the mouse button is released during this frame")]
	[Category("Input/Is Mouse Released")]
	[Keywords(new string[] { "Key", "Up", "Click" })]
	[Image(typeof(IconMouse), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class ConditionInputMouseRelease : TConditionMouse
	{
		protected override string Summary => $"Mouse {m_Button} just released";

		protected override bool Run(Args args)
		{
			Mouse current = Mouse.current;
			if (current == null)
			{
				return false;
			}
			return m_Button switch
			{
				Button.Left => current.leftButton.wasReleasedThisFrame, 
				Button.Right => current.rightButton.wasReleasedThisFrame, 
				Button.Middle => current.middleButton.wasReleasedThisFrame, 
				Button.Forward => current.forwardButton.wasReleasedThisFrame, 
				Button.Back => current.backButton.wasReleasedThisFrame, 
				_ => throw new ArgumentOutOfRangeException($"Mouse '{m_Button}' not found"), 
			};
		}
	}
}
