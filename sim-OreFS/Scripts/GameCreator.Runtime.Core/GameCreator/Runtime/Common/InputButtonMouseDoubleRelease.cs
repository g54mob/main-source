using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Double Release")]
	[Category("Mouse/Mouse Double Release")]
	[Description("When the specified mouse button is released after a double press")]
	[Image(typeof(IconMouse), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Cursor", "Button", "Up", "Click" })]
	public class InputButtonMouseDoubleRelease : TInputButtonMouse
	{
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.WasReleasedThisFrame && base.PressCount == 2)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonMouseDoubleRelease());
		}
	}
}
