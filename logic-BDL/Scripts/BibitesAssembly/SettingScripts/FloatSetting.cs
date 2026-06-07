using System;
using UIScripts.InfoHandles;

namespace SettingScripts
{
	[Serializable]
	public class FloatSetting : NumericSimulationSetting<float>
	{
		public override FloatValueFormat formatting => new FloatValueFormat
		{
			precision = precision,
			units = units,
			prefix = prefix,
			factor = factor,
			alwaysShowSign = alwaysShowSign,
			isInt = false,
			precisionIsSI = false,
			SI = SI
		};
	}
}
