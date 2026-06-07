using SettingScripts;
using TMPro;

namespace UIScripts.SettingHandles
{
	public class IntSettingSlider : SettingSlider<NumericSetting<int>, int>
	{
		protected override void TypeSpecificUIElementCreation()
		{
			SettingSliderRef.slider.wholeNumbers = true;
			SettingSliderRef.slider.SetValueWithoutNotify(setting.val);
			SettingSliderRef.editField.contentType = TMP_InputField.ContentType.IntegerNumber;
		}

		public override int SettingValueOfSlider(float val)
		{
			return (int)val;
		}

		public IntSettingSlider(NumericSetting<int> _setting, bool simple = false)
			: base(_setting, simple)
		{
		}

		public IntSettingSlider()
		{
		}
	}
}
