using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsFloat : PlayerPrefsType
	{
		public float DefaultValue;

		public float Value
		{
			get
			{
				return PlayerPrefs.GetFloat(base.Key, DefaultValue);
			}
			set
			{
				PlayerPrefs.SetFloat(base.Key, value);
			}
		}

		public static PlayerPrefsFloat WithKey(string key, float defaultValue = 0f)
		{
			return new PlayerPrefsFloat(key, defaultValue);
		}

		public PlayerPrefsFloat(string key, float defaultValue = 0f)
		{
			base.Key = key;
			DefaultValue = defaultValue;
		}
	}
}
