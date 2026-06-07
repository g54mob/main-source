using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Right Stick")]
	[Category("Mobile/Right Stick")]
	[Description("")]
	[Image(typeof(IconTouchstick), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Virtual", "Joystick", "Touchstick", "Direction" })]
	public class InputValueVector2MobileStickRight : TInputValueVector2MobileStick
	{
		public static InputPropertyValueVector2 Create => new InputPropertyValueVector2(new InputValueVector2MobileStickRight());

		protected override ITouchStick CreateTouchStick()
		{
			return TouchStickRight.Create();
		}
	}
}
