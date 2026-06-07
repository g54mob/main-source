using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAMaterialPropertyBlock : ISerializationCallbackReceiver
	{
		public bool alwaysUpdate;

		public bool alwaysUpdateParms;

		public static string[] PropertyTypeStrings;

		public static List<Type> availableTypes;

		public List<PropertyHolder> serializedProperties;

		public List<UMAProperty> shaderProperties;

		public string[] GetPropertyStrings()
		{
			return null;
		}

		public void SetPropertyStrings(string[] strings)
		{
		}

		public static void CheckInitialize()
		{
		}

		public static List<Type> GetPropertyTypes()
		{
			return null;
		}

		public void Validate()
		{
		}

		public void AddProperty(UMAProperty property)
		{
		}

		public UMAProperty AddProperty(Type propertyType, string propertyName)
		{
			return null;
		}

		public UMAProperty AddProperty<t>(string propertyName)
		{
			return null;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
