using UIScripts.InfoHandles;
using UnityEngine;

namespace SettingScripts
{
	public class IntUserSetting : NumericUserSetting<int>
	{
		public override int val
		{
			get
			{
				return PlayerPrefs.GetInt(key, DefaultValue);
			}
			set
			{
				OnValueChangeWithPrecedent.Invoke(value, val);
				PlayerPrefs.SetInt(key, value);
			}
		}

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
