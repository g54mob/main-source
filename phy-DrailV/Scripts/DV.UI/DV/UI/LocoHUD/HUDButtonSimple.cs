using DV.UIFramework;

namespace DV.UI.LocoHUD
{
	public class HUDButtonSimple : HUDControlModule
	{
		public bool holdValue;

		private ButtonDV button;

		protected override void Awake()
		{
			base.Awake();
			button = GetComponentInChildren<ButtonDV>();
			if (holdValue)
			{
				button.PressChanged += delegate(IClickable b)
				{
					base.Value = (b.IsPressed ? 1 : 0);
				};
			}
			else
			{
				button.Clicked += delegate
				{
					base.Value = 1f;
					base.Value = 0f;
				};
			}
			SetHoverButton(button);
		}

		public override void ScrollValue(int notches)
		{
			if (holdValue)
			{
				base.Value = notches;
				return;
			}
			switch (notches)
			{
			case 1:
				base.Value = 1f;
				break;
			case -1:
				base.Value = 0f;
				break;
			}
		}
	}
}
