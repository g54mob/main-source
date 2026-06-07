using UnityEngine;

namespace SettingScripts
{
	public class StringUserSetting : StringSetting
	{
		public string key;

		public override string val
		{
			get
			{
				return PlayerPrefs.GetString(key, DefaultValue);
			}
			set
			{
				OnValueChangeWithPrecedent.Invoke(value, val);
				PlayerPrefs.SetString(key, value);
			}
		}
	}
}
