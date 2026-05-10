using System;
using System.Collections.Generic;
using UnityEngine;

namespace EPOOutline
{
	[Serializable]
	public class SerializedPass : ISerializationCallbackReceiver
	{
		public enum PropertyType
		{
			Color = 0,
			Vector = 1,
			Float = 2,
			Range = 3,
			TexEnv = 4
		}

		[Serializable]
		private class SerializedPropertyKeyValuePair
		{
			[SerializeField]
			public string PropertyName;

			[SerializeField]
			public SerializedPassProperty Property;
		}

		[Serializable]
		private class SerializedPassProperty
		{
			[SerializeField]
			public Color ColorValue;

			[SerializeField]
			public float FloatValue;

			[SerializeField]
			public Vector4 VectorValue;

			[SerializeField]
			public PropertyType PropertyType;
		}

		[SerializeField]
		private Shader shader;

		[SerializeField]
		private List<SerializedPropertyKeyValuePair> serializedProperties;

		private Dictionary<int, SerializedPassProperty> propertiesById;

		private Dictionary<string, SerializedPassProperty> propertiesByName;

		private Material material;

		private bool propertiesIsDirty;

		public Shader Shader
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material Material => null;

		public bool HasProperty(string name)
		{
			return false;
		}

		public bool HasProperty(int hash)
		{
			return false;
		}

		public Vector4 GetVector(string name)
		{
			return default(Vector4);
		}

		public Vector4 GetVector(int hash)
		{
			return default(Vector4);
		}

		public void SetVector(string name, Vector4 value)
		{
		}

		public void SetVector(int hash, Vector4 value)
		{
		}

		public float GetFloat(string name)
		{
			return 0f;
		}

		public float GetFloat(int hash)
		{
			return 0f;
		}

		public void SetFloat(string name, float value)
		{
		}

		public void SetFloat(int hash, float value)
		{
		}

		public Color GetColor(string name)
		{
			return default(Color);
		}

		public Color GetColor(int hash)
		{
			return default(Color);
		}

		public void SetColor(string name, Color value)
		{
		}

		public void SetColor(int hash, Color value)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
