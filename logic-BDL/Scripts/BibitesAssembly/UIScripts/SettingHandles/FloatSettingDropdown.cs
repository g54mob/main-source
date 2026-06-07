using ScriptHelpers;
using SettingScripts;

namespace UIScripts.SettingHandles
{
	public class FloatSettingDropdown : NumericSettingDropdown<NumericSetting<float>, float>
	{
		public FloatSettingDropdown(NumericSetting<float> setting)
			: base(setting)
		{
		}

		protected override string FormattedValueOfLandmark(SettingLandmarkValues<float> landmark)
		{
			return landmark.value.ScientificFormat(setting.precision, setting.units);
		}
	}
}
