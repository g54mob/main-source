using DV.Localization;
using DV.UIFramework;

namespace DV.UI
{
	public class UIElementTooltipRandomizedElement : UIElementTooltipCustomText
	{
		public ToggleDV randomizeToggle;

		public string disabledRandomizedKey;

		private void Awake()
		{
			randomizeToggle.onValueChanged.AddListener(delegate(bool on)
			{
				base.enabled = on;
				TextChanged_Fire();
			});
			base.enabled = randomizeToggle.isOn;
		}

		public override string GetText()
		{
			return LocalizationAPI.L(disabledRandomizedKey);
		}
	}
}
