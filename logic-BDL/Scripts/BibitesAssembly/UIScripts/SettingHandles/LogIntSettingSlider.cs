using SettingScripts;

namespace UIScripts.SettingHandles
{
	public class LogIntSettingSlider : LogSettingSlider<NumericSetting<int>, int>
	{
		public LogIntSettingSlider(NumericSetting<int> _setting, float logBase, bool wholeNumbers = false, bool simple = false, float? targetSpanIfZero = null)
			: base(_setting, logBase, wholeNumbers, simple, targetSpanIfZero)
		{
		}

		public LogIntSettingSlider(float logBase, bool wholeNumbers = false, bool simple = false, float? targetSpanIfZero = null)
			: base((NumericSetting<int>)null, logBase, wholeNumbers, simple, targetSpanIfZero)
		{
		}
	}
}
