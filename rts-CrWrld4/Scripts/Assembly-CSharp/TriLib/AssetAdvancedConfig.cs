using System;
using UnityEngine;

namespace TriLib
{
	[Serializable]
	public class AssetAdvancedConfig
	{
		public string Key;

		public int IntValue;

		public float FloatValue;

		public bool BoolValue;

		public string StringValue;

		public Vector3 TranslationValue;

		public Vector3 RotationValue;

		public Vector3 ScaleValue;

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, int value)
		{
			return null;
		}

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, float value)
		{
			return null;
		}

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, bool value)
		{
			return null;
		}

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, string value)
		{
			return null;
		}

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, AiComponent value)
		{
			return null;
		}

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, AiPrimitiveType value)
		{
			return null;
		}

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, AiUVTransform value)
		{
			return null;
		}

		public static AssetAdvancedConfig CreateConfig(AssetAdvancedPropertyClassNames className, Vector3 translation, Vector3 rotation, Vector3 scale)
		{
			return null;
		}

		public AssetAdvancedConfig()
		{
		}

		public AssetAdvancedConfig(string key)
		{
		}

		public AssetAdvancedConfig(string key, int defaultValue)
		{
		}

		public AssetAdvancedConfig(string key, float defaultValue)
		{
		}

		public AssetAdvancedConfig(string key, bool defaultValue)
		{
		}

		public AssetAdvancedConfig(string key, string defaultValue)
		{
		}

		public AssetAdvancedConfig(string key, AiComponent defaultValue)
		{
		}

		public AssetAdvancedConfig(string key, AiPrimitiveType defaultValue)
		{
		}

		public AssetAdvancedConfig(string key, AiUVTransform defaultValue)
		{
		}

		public AssetAdvancedConfig(string key, Vector3 translation, Vector3 rotation, Vector3 scale)
		{
		}
	}
}
