using SettingScripts;

namespace UIScripts.SettingHandles
{
	public class LogFloatSettingSlider : LogSettingSlider<NumericSetting<float>, float>
	{
		public LogFloatSettingSlider(NumericSetting<float> _setting, float logBase, bool wholeNumbers = false, bool simple = false, float? targetSpanIfZero = null)
			: base(_setting, logBase, wholeNumbers, simple, targetSpanIfZero)
		{
		}

		public LogFloatSettingSlider(float logBase, bool wholeNumbers = false, bool simple = false, float? targetSpanIfZero = null)
			: base((NumericSetting<float>)null, logBase, wholeNumbers, simple, targetSpanIfZero)
		{
		}
	}
}
