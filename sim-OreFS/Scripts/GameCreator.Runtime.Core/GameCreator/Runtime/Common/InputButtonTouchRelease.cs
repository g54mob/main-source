using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Touch Release")]
	[Category("Mobile/Touch Release")]
	[Description("When a finer is released from the touchscreen")]
	[Image(typeof(IconTouch), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Up" })]
	public class InputButtonTouchRelease : TInputButtonTouch
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
			return new InputPropertyButton(new InputButtonTouchRelease());
		}
	}
}
