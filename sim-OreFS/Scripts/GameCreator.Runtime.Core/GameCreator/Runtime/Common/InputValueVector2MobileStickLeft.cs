using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Left Stick")]
	[Category("Mobile/Left Stick")]
	[Description("")]
	[Image(typeof(IconTouchstick), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Virtual", "Joystick", "Touchstick", "Direction" })]
	public class InputValueVector2MobileStickLeft : TInputValueVector2MobileStick
	{
		public static InputPropertyValueVector2 Create => new InputPropertyValueVector2(new InputValueVector2MobileStickLeft());

		protected override ITouchStick CreateTouchStick()
		{
			return TouchStickLeft.Create();
		}
	}
}
