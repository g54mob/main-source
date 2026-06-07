using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse While Pressing")]
	[Category("Mouse/Mouse While Pressing")]
	[Description("While the specified mouse button is being held down")]
	[Image(typeof(IconMouse), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Keywords(new string[] { "Cursor", "Button", "Down", "Held", "Hold" })]
	public class InputButtonMouseWhilePressing : TInputButtonMouse
	{
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.WasPressedThisFrame)
			{
				ExecuteEventStart();
			}
			if (base.IsPressed)
			{
				ExecuteEventPerform();
			}
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonMouseWhilePressing());
		}
	}
}
