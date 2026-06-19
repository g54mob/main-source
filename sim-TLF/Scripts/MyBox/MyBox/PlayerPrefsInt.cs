using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsInt : PlayerPrefsType
	{
		public int DefaultValue;

		public int Value
		{
			get
			{
				return PlayerPrefs.GetInt(base.Key, DefaultValue);
			}
			set
			{
				PlayerPrefs.SetInt(base.Key, value);
			}
		}

		public static PlayerPrefsInt WithKey(string key, int defaultValue = 0)
		{
			return new PlayerPrefsInt(key, defaultValue);
		}

		public PlayerPrefsInt(string key, int defaultValue = 0)
		{
			base.Key = key;
			DefaultValue = defaultValue;
		}
	}
}
