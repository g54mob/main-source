using System;
using UIScripts.InfoHandles;

namespace SettingScripts
{
	[Serializable]
	public class IntSetting : NumericSimulationSetting<int>
	{
		public override FloatValueFormat formatting => new FloatValueFormat
		{
			precision = precision,
			units = units,
			prefix = prefix,
			factor = factor,
			alwaysShowSign = alwaysShowSign,
			isInt = true,
			precisionIsSI = false,
			SI = SI
		};
	}
}
