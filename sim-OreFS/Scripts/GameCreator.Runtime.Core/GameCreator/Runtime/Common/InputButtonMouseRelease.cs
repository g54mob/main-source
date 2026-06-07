using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Release")]
	[Category("Mouse/Mouse Release")]
	[Description("When the specified mouse button is released")]
	[Image(typeof(IconMouse), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Cursor", "Button", "Up" })]
	public class InputButtonMouseRelease : TInputButtonMouse
	{
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.WasReleasedThisFrame)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonMouseRelease());
		}
	}
}
