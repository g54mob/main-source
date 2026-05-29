using UnityEngine;

namespace CTS
{
	public class UISettingIntSlider : UISettingSlider<int>
	{
		protected override float GetValueForSlider(int settingValue)
		{
			return settingValue;
		}

		protected override int GetValueForSetting(float sliderValue)
		{
			return Mathf.RoundToInt(sliderValue);
		}
	}
}
