using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	public class PlayerPrefsBool : PlayerPrefsType
	{
		public bool DefaultValue;

		public bool Value
		{
			get
			{
				return PlayerPrefs.GetInt(base.Key, DefaultValue ? 1 : 0) == 1;
			}
			set
			{
				PlayerPrefs.SetInt(base.Key, value ? 1 : 0);
			}
		}

		public static PlayerPrefsBool WithKey(string key, bool defaultValue = false)
		{
			return new PlayerPrefsBool(key);
		}

		public PlayerPrefsBool(string key, bool defaultValue = false)
		{
			base.Key = key;
			DefaultValue = defaultValue;
		}
	}
}
