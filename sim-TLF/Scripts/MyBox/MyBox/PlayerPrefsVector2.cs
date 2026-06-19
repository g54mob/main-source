using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsVector2 : PlayerPrefsType
	{
		public Vector2 DefaultValue;

		public Vector2 Value
		{
			get
			{
				return new Vector2(PlayerPrefs.GetFloat(base.Key + "x", DefaultValue.x), PlayerPrefs.GetFloat(base.Key + "y", DefaultValue.y));
			}
			set
			{
				PlayerPrefs.SetFloat(base.Key + "x", value.x);
				PlayerPrefs.SetFloat(base.Key + "y", value.y);
			}
		}

		public static PlayerPrefsVector2 WithKey(string key, Vector2 defaultValue = default(Vector2))
		{
			return new PlayerPrefsVector2(key, defaultValue);
		}

		public PlayerPrefsVector2(string key, Vector2 defaultValue = default(Vector2))
		{
			base.Key = key;
			DefaultValue = defaultValue;
		}
	}
}
