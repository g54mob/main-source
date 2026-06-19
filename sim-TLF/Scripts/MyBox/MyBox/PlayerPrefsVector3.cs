using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class PlayerPrefsVector3 : PlayerPrefsType
	{
		public Vector3 DefaultValue;

		public Vector3 Value
		{
			get
			{
				return new Vector3(PlayerPrefs.GetFloat(base.Key + "x", DefaultValue.x), PlayerPrefs.GetFloat(base.Key + "y", DefaultValue.y), PlayerPrefs.GetFloat(base.Key + "z", DefaultValue.z));
			}
			set
			{
				PlayerPrefs.SetFloat(base.Key + "x", value.x);
				PlayerPrefs.SetFloat(base.Key + "y", value.y);
				PlayerPrefs.SetFloat(base.Key + "z", value.z);
			}
		}

		public static PlayerPrefsVector3 WithKey(string key, Vector3 defaultValue = default(Vector3))
		{
			return new PlayerPrefsVector3(key, defaultValue);
		}

		public PlayerPrefsVector3(string key, Vector3 defaultValue = default(Vector3))
		{
			base.Key = key;
			DefaultValue = defaultValue;
		}
	}
}
