using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsString : PlayerPrefsType
	{
		public string DefaultString;

		public string Value
		{
			get
			{
				return PlayerPrefs.GetString(base.Key, DefaultString);
			}
			set
			{
				PlayerPrefs.SetString(base.Key, value);
			}
		}

		public static PlayerPrefsString WithKey(string key, string defaultString = "")
		{
			return new PlayerPrefsString(key, defaultString);
		}

		public PlayerPrefsString(string key, string defaultString = "")
		{
			base.Key = key;
			DefaultString = defaultString;
		}
	}
}
