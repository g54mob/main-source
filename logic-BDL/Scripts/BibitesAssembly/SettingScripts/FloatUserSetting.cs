using UIScripts.InfoHandles;
using UnityEngine;

namespace SettingScripts
{
	public class FloatUserSetting : NumericUserSetting<float>
	{
		public override float val
		{
			get
			{
				return PlayerPrefs.GetFloat(key, DefaultValue);
			}
			set
			{
				PlayerPrefs.SetFloat(key, value);
			}
		}

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
