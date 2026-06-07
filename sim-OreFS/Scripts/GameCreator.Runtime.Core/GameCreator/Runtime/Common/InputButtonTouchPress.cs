using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Touch Press")]
	[Category("Mobile/Touch Press")]
	[Description("When a finger touches the touchscreen")]
	[Image(typeof(IconTouch), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Down" })]
	public class InputButtonTouchPress : TInputButtonTouch
	{
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (base.WasTouchedThisFrame)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonTouchPress());
		}
	}
}
