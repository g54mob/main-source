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
				return default(Vector2Int);
			}
			set
			{
			}
		}

		public static PlayerPrefsVector2Int WithKey(string key, Vector2Int defaultValue = default(Vector2Int))
		{
			return null;
		}

		public PlayerPrefsVector2Int(string key, Vector2Int defaultValue = default(Vector2Int))
		{
		}
	}
}
