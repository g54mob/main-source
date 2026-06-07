using ScriptHelpers;
using SettingScripts;

namespace UIScripts.SettingHandles
{
	public class IntSettingDropdown : NumericSettingDropdown<NumericSetting<int>, int>
	{
		public IntSettingDropdown(NumericSetting<int> setting)
			: base(setting)
		{
		}

		protected override string FormattedValueOfLandmark(SettingLandmarkValues<int> landmark)
		{
			return landmark.value.ScientificFormat(setting.precision, setting.units);
		}
	}
}
