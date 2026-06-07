using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Double Press")]
	[Category("Mouse/Mouse Double Press")]
	[Description("When the specified mouse button is pressed twice in a row")]
	[Image(typeof(IconMouse), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Cursor", "Button", "Down", "Click" })]
	public class InputButtonMouseDoublePress : TInputButtonMouse
	{
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.WasPressedThisFrame && base.PressCount == 2)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonMouseDoublePress());
		}
	}
}
