using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class UISettingFloatSlider : UISettingSlider<float>
	{
		private Vector2 _settingRange = Vector2.up;

		public void SetSettingRange(Vector2 range)
		{
			_settingRange = range;
		}

		protected override float GetValueForSlider(float settingValue)
		{
			return settingValue.Remap(_settingRange.x, _settingRange.y, _slider.minValue, _slider.maxValue);
		}

		protected override float GetValueForSetting(float sliderValue)
		{
			return sliderValue.Remap(_slider.minValue, _slider.maxValue, _settingRange.x, _settingRange.y);
		}
	}
}
