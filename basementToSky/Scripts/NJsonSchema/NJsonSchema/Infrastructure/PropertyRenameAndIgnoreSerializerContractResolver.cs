using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Infrastructure
{
	public class PropertyRenameAndIgnoreSerializerContractResolver : DefaultContractResolver
	{
		private readonly Dictionary<string, HashSet<string>> _ignores;

		private readonly Dictionary<string, Dictionary<string, string>> _renames;

		public PropertyRenameAndIgnoreSerializerContractResolver()
		{
			_ignores = new Dictionary<string, HashSet<string>>();
			_renames = new Dictionary<string, Dictionary<string, string>>();
		}

		public void IgnoreProperty(Type type, params string[] jsonPropertyNames)
		{
			if (!_ignores.ContainsKey(type.FullName))
			{
				_ignores[type.FullName] = new HashSet<string>();
			}
			foreach (string item in jsonPropertyNames)
			{
				_ignores[type.FullName].Add(item);
			}
		}

		public void RenameProperty(Type type, string propertyName, string newJsonPropertyName)
		{
			if (!_renames.ContainsKey(type.FullName))
			{
				_renames[type.FullName] = new Dictionary<string, string>();
			}
			_renames[type.FullName][propertyName] = newJsonPropertyName;
		}

		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);
			if (IsIgnored(jsonProperty.DeclaringType, jsonProperty.PropertyName))
			{
				jsonProperty.Ignored = true;
				jsonProperty.ShouldSerialize = (object i) => false;
				jsonProperty.ShouldDeserialize = (object i) => false;
			}
			if (IsRenamed(jsonProperty.DeclaringType, jsonProperty.PropertyName, out var newJsonPropertyName))
			{
				jsonProperty.PropertyName = newJsonPropertyName;
			}
			return jsonProperty;
		}

		private bool IsIgnored(Type type, string jsonPropertyName)
		{
			if (!_ignores.ContainsKey(type.FullName))
			{
				return false;
			}
			return _ignores[type.FullName].Contains(jsonPropertyName);
		}

		private bool IsRenamed(Type type, string jsonPropertyName, out string newJsonPropertyName)
		{
			if (!_renames.TryGetValue(type.FullName, out var value) || !value.TryGetValue(jsonPropertyName, out newJsonPropertyName))
			{
				newJsonPropertyName = null;
				return false;
			}
			return true;
		}
	}
}
