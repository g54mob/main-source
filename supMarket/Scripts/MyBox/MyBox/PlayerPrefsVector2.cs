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
				return default(Vector2);
			}
			set
			{
			}
		}

		public static PlayerPrefsVector2 WithKey(string key, Vector2 defaultValue = default(Vector2))
		{
			return null;
		}

		public PlayerPrefsVector2(string key, Vector2 defaultValue = default(Vector2))
		{
		}
	}
}
