using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Touch While Pressing")]
	[Category("Mobile/Touch While Pressing")]
	[Description("While a finger is being held down on the touchscreen")]
	[Image(typeof(IconTouch), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Keywords(new string[] { "Down", "Held", "Hold" })]
	public class InputButtonTouchWhilePressing : TInputButtonTouch
	{
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.WasTouchedThisFrame)
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
			return new InputPropertyButton(new InputButtonTouchWhilePressing());
		}
	}
}
