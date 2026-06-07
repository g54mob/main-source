using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Input Button")]
	[Category("Input/On Input Button")]
	[Description("Detects when a button is interacted with")]
	[Image(typeof(IconButton), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Down", "Up", "Press", "Release" })]
	[Keywords(new string[] { "Keyboard", "Mouse", "Button", "Gamepad", "Controller", "Joystick" })]
	public class EventOnInputButton : TEventButton
	{
		protected override void OnInput()
		{
			base.OnInput();
			Execute();
		}
	}
}
