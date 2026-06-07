using System;
using GameCreator.Runtime.Common;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Mouse Held Down")]
	[Description("Returns true if the mouse button is being held down")]
	[Category("Input/Is Mouse Held Down")]
	[Keywords(new string[] { "Key", "Up", "Click" })]
	[Image(typeof(IconMouse), ColorTheme.Type.Blue, typeof(OverlayDot))]
	public class ConditionInputMouseHeldDown : TConditionMouse
	{
		protected override string Summary => $"Mouse {m_Button} held down";

		protected override bool Run(Args args)
		{
			Mouse current = Mouse.current;
			if (current == null)
			{
				return false;
			}
			return m_Button switch
			{
				Button.Left => current.leftButton.isPressed, 
				Button.Right => current.rightButton.isPressed, 
				Button.Middle => current.middleButton.isPressed, 
				Button.Forward => current.forwardButton.isPressed, 
				Button.Back => current.backButton.isPressed, 
				_ => throw new ArgumentOutOfRangeException($"Mouse '{m_Button}' not found"), 
			};
		}
	}
}
