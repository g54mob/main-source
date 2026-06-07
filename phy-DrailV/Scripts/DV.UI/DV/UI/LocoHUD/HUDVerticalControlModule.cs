using DV.UIFramework;

namespace DV.UI.LocoHUD
{
	public class HUDVerticalControlModule : HUDControlModule
	{
		public ButtonDV upButton;

		public ButtonDV downButton;

		public bool holdValue;

		protected override void Awake()
		{
			base.Awake();
			SetupButtons();
		}

		protected virtual void SetupButtons()
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
			SetHoverButton(upButton);
			SetHoverButton(downButton);
		}

		public override void ScrollValue(int notches)
		{
			base.Value = notches;
		}
	}
}
