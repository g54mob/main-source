using System;
using UnityEngine;

namespace NSMedieval.MaterialHelpers
{
	[Serializable]
	public class MaterialProperty
	{
		public string name;

		public MaterialPropertyTypes valueType;

		public Color colorValue;

		public Vector2 vec2Value;

		public Vector3 vec3Value;

		public Vector4 vec4Value;

		public float floatValue;

		public Vector2 rangeValue;

		public Texture2D textureValue;

		public int intValue;
	}
}
