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
				return default(Vector3Int);
			}
			set
			{
			}
		}

		public static PlayerPrefsVector3Int WithKey(string key, Vector3Int defaultValue = default(Vector3Int))
		{
			return null;
		}

		public PlayerPrefsVector3Int(string key, Vector3Int defaultValue = default(Vector3Int))
		{
		}
	}
}
