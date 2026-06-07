using DV.Localization;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class FrameLimitSliderDV : SliderDV
	{
		public const int VSYNC_INDEX = 0;

		public const int UNLIMITED_INDEX = 999;

		public string vsyncLocalizeKey;

		public string unlimitedLocalizeKey;

		protected override void UpdateValueText(float _ = 0f)
		{
			if (valueTMPro == null)
			{
				return;
			}
			int num = Mathf.RoundToInt(value);
			string text = null;
			if (num == 0)
			{
				if (!string.IsNullOrWhiteSpace(vsyncLocalizeKey))
				{
					text = LocalizationAPI.L(vsyncLocalizeKey);
				}
			}
			else if ((float)num == base.maxValue)
			{
				if (!string.IsNullOrWhiteSpace(unlimitedLocalizeKey))
				{
					text = LocalizationAPI.L(unlimitedLocalizeKey);
				}
			}
			else if (!string.IsNullOrWhiteSpace(localizeValueKey))
			{
				text = LocalizationAPI.L(localizeValueKey, value.ToString("F0"));
			}
			valueTMPro.text = text;
		}
	}
}
