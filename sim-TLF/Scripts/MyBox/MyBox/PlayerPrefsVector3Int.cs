using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsVector3Int : PlayerPrefsType
	{
		public Vector3Int DefaultValue;

		public Vector3Int Value
		{
			get
			{
				return new Vector3Int(PlayerPrefs.GetInt(base.Key + "x", DefaultValue.x), PlayerPrefs.GetInt(base.Key + "y", DefaultValue.y), PlayerPrefs.GetInt(base.Key + "z", DefaultValue.z));
			}
			set
			{
				PlayerPrefs.SetInt(base.Key + "x", value.x);
				PlayerPrefs.SetInt(base.Key + "y", value.y);
				PlayerPrefs.SetInt(base.Key + "z", value.z);
			}
		}

		public static PlayerPrefsVector3Int WithKey(string key, Vector3Int defaultValue = default(Vector3Int))
		{
			return new PlayerPrefsVector3Int(key, defaultValue);
		}

		public PlayerPrefsVector3Int(string key, Vector3Int defaultValue = default(Vector3Int))
		{
			base.Key = key;
			DefaultValue = defaultValue;
		}
	}
}
