using DV.UIFramework;

namespace DV.UI.LocoHUD
{
	public class HUDVerticalControlDoubleModule : HUDVerticalControlModule
	{
		public ButtonDV upMaxButton;

		public ButtonDV downMaxButton;

		public bool holdMaxValue;

		protected override void SetupButtons()
		{
			if (holdValue)
			{
				upButton.PressChanged += delegate(IClickable b)
				{
					base.Value = (b.IsPressed ? 1f : 0f);
				};
				downButton.PressChanged += delegate(IClickable b)
				{
					base.Value = (b.IsPressed ? (-1f) : 0f);
				};
			}
			else
			{
				upButton.Clicked += delegate
				{
					base.Value = 1f;
					base.Value = 0f;
				};
				downButton.Clicked += delegate
				{
					base.Value = -1f;
					base.Value = 0f;
				};
			}
			if (holdMaxValue)
			{
				upMaxButton.PressChanged += delegate(IClickable b)
				{
					base.Value = (b.IsPressed ? 2f : 0f);
				};
				downMaxButton.PressChanged += delegate(IClickable b)
				{
					base.Value = (b.IsPressed ? (-2f) : 0f);
				};
			}
			else
			{
				upMaxButton.Clicked += delegate
				{
					base.Value = 2f;
					base.Value = 0f;
				};
				downMaxButton.Clicked += delegate
				{
					base.Value = -2f;
					base.Value = 0f;
				};
			}
			SetHoverButton(upButton);
			SetHoverButton(downButton);
			SetHoverButton(upMaxButton);
			SetHoverButton(downMaxButton);
		}
	}
}
