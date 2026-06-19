using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsVector2Int : PlayerPrefsType
	{
		public Vector2Int DefaultValue;

		public Vector2Int Value
		{
			get
			{
				return new Vector2Int(PlayerPrefs.GetInt(base.Key + "x", DefaultValue.x), PlayerPrefs.GetInt(base.Key + "y", DefaultValue.y));
			}
			set
			{
				PlayerPrefs.SetInt(base.Key + "x", value.x);
				PlayerPrefs.SetInt(base.Key + "y", value.y);
			}
		}

		public static PlayerPrefsVector2Int WithKey(string key, Vector2Int defaultValue = default(Vector2Int))
		{
			return new PlayerPrefsVector2Int(key, defaultValue);
		}

		public PlayerPrefsVector2Int(string key, Vector2Int defaultValue = default(Vector2Int))
		{
			base.Key = key;
			DefaultValue = defaultValue;
		}
	}
}
