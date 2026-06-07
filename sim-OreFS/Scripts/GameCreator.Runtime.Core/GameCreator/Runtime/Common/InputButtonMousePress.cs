using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Press")]
	[Category("Mouse/Mouse Press")]
	[Description("When the specified mouse button is pressed")]
	[Image(typeof(IconMouse), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Cursor", "Button", "Down" })]
	public class InputButtonMousePress : TInputButtonMouse
	{
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.WasPressedThisFrame)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonMousePress());
		}
	}
}
