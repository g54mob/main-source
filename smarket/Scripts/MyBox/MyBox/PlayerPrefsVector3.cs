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
				return default(Vector3);
			}
			set
			{
			}
		}

		public static PlayerPrefsVector3 WithKey(string key, Vector3 defaultValue = default(Vector3))
		{
			return null;
		}

		public PlayerPrefsVector3(string key, Vector3 defaultValue = default(Vector3))
		{
		}
	}
}
