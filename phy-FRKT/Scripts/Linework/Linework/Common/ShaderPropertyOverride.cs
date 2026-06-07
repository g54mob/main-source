using System;
using UnityEngine;

namespace Linework.Common
{
	[Serializable]
	public class ShaderPropertyOverride
	{
		public ShaderPropertyType type;

		public string propertyName;

		[HideInInspector]
		public int propertyId;

		public float floatValue;

		public int intValue;

		public Vector4 vectorValue;

		public Color colorValue;

		public void CachePropertyID()
		{
		}

		public object GetValue()
		{
			return null;
		}
	}
}
