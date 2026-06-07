using SettingScripts;
using TMPro;
using UIScripts.SettingHandles.References;

namespace UIScripts.SettingHandles
{
	public class FloatSettingSlider : SettingSlider<NumericSetting<float>, float>
	{
		protected override void TypeSpecificUIElementCreation()
		{
			SettingSliderRef.slider.wholeNumbers = false;
			SettingSliderRef.slider.SetValueWithoutNotify(setting.val);
			SettingSliderRef.editField.contentType = TMP_InputField.ContentType.DecimalNumber;
		}

		public override float SettingValueOfSlider(float val)
		{
			return val;
		}

		public FloatSettingSlider(NumericSetting<float> _setting, SettingSliderReference reference)
			: base(_setting, reference)
		{
		}

		public FloatSettingSlider(NumericSetting<float> _setting, bool simple = false)
			: base(_setting, simple)
		{
		}

		public FloatSettingSlider()
		{
		}
	}
}
