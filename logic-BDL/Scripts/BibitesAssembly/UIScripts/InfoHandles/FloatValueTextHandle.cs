using ScriptHelpers;
using SettingScripts;

namespace UIScripts.InfoHandles
{
	public class FloatValueTextHandle : ValueTextHandle<float>
	{
		public string prefix;

		public string suffix;

		public int precision;

		public float factor = 1f;

		public bool contract;

		public bool alwaysShowSign;

		public bool precisionIsSI;

		public bool isInt;

		public void InitFromSetting<T>(NumericSetting<T> setting)
		{
			if (setting is IntSetting)
			{
				isInt = true;
			}
			prefix = setting.prefix;
			suffix = setting.units;
			precision = setting.precision;
			factor = setting.factor;
			contract = setting.SI;
			alwaysShowSign = setting.alwaysShowSign;
		}

		public void InitFromSetup(FloatValueFormat format, bool overrideUnits = false)
		{
			prefix = format.prefix;
			suffix = (overrideUnits ? "" : format.units);
			precision = format.precision;
			factor = format.factor;
			contract = format.SI;
			alwaysShowSign = format.alwaysShowSign;
			precisionIsSI = format.precisionIsSI;
			isInt = format.isInt;
		}

		protected override void OnValueChange()
		{
			string text = (contract ? value : (value * factor)).ScientificFormat(precision, suffix, alwaysShowSign, SIUnits: contract, prefixWithUnits: !isInt, scientificPrecision: precisionIsSI && !isInt, isInt: isInt);
			base.text.text = prefix + text;
		}

		public void SetValue(float val)
		{
			UpdateValue(val);
		}
	}
}
