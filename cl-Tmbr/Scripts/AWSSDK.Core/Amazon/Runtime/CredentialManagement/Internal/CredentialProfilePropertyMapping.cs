using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Amazon.Runtime.CredentialManagement.Internal
{
	public class CredentialProfilePropertyMapping
	{
		private static readonly HashSet<string> TypePropertySet = new HashSet<string>(from p in typeof(CredentialProfileOptions).GetProperties()
			select p.Name, StringComparer.OrdinalIgnoreCase);

		private static readonly PropertyInfo[] CredentialProfileReflectionProperties = typeof(CredentialProfileOptions).GetProperties();

		private readonly Dictionary<string, string> _nameMapping;

		private readonly HashSet<string> _mappedNames;

		public CredentialProfilePropertyMapping(Dictionary<string, string> nameMapping)
		{
			if (!TypePropertySet.SetEquals(new HashSet<string>(nameMapping.Keys, StringComparer.OrdinalIgnoreCase)))
			{
				throw new ArgumentException("The nameMapping Dictionary must contain a name mapping for each ProfileOptions property, and no additional keys.");
			}
			_nameMapping = nameMapping;
			_mappedNames = new HashSet<string>(nameMapping.Values.Where((string v) => !string.IsNullOrEmpty(v)), StringComparer.OrdinalIgnoreCase);
		}

		public void ExtractProfileParts(Dictionary<string, string> profileDictionary, HashSet<string> reservedKeys, out CredentialProfileOptions profileOptions, out Dictionary<string, string> userProperties)
		{
			ExtractProfileParts(profileDictionary, reservedKeys, out profileOptions, out var _, out userProperties);
		}

		public void ExtractProfileParts(Dictionary<string, string> profileDictionary, HashSet<string> reservedKeys, out CredentialProfileOptions profileOptions, out Dictionary<string, string> reservedProperties, out Dictionary<string, string> userProperties)
		{
			userProperties = new Dictionary<string, string>(profileDictionary);
			profileOptions = new CredentialProfileOptions();
			PropertyInfo[] credentialProfileReflectionProperties = CredentialProfileReflectionProperties;
			foreach (PropertyInfo propertyInfo in credentialProfileReflectionProperties)
			{
				string value = null;
				string text = _nameMapping[propertyInfo.Name];
				if (text != null && userProperties.TryGetValue(text, out value))
				{
					propertyInfo.SetValue(profileOptions, value, null);
					userProperties.Remove(text);
				}
			}
			if (reservedKeys == null)
			{
				reservedProperties = null;
				return;
			}
			reservedProperties = new Dictionary<string, string>();
			foreach (string reservedKey in reservedKeys)
			{
				string value2 = null;
				if (userProperties.TryGetValue(reservedKey, out value2))
				{
					reservedProperties.Add(reservedKey, value2);
					userProperties.Remove(reservedKey);
				}
			}
		}

		public Dictionary<string, string> CombineProfileParts(CredentialProfileOptions profileOptions, HashSet<string> reservedPropertyNames, Dictionary<string, string> reservedProperties, Dictionary<string, string> userProperties)
		{
			ValidateNoProfileOptionsProperties(userProperties);
			ValidateNoReservedProperties(reservedPropertyNames, userProperties);
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			foreach (KeyValuePair<string, string> item in Convert(profileOptions).Concat(reservedProperties).Concat(userProperties))
			{
				dictionary.Add(item.Key, item.Value);
			}
			return dictionary;
		}

		private static void ValidateNoReservedProperties(HashSet<string> reservedPropertyNames, Dictionary<string, string> userProperties)
		{
			if (userProperties == null)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (string reservedPropertyName in reservedPropertyNames)
			{
				if (userProperties.Keys.Contains(reservedPropertyName, StringComparer.OrdinalIgnoreCase))
				{
					list.Add(reservedPropertyName);
				}
			}
			if (list.Count > 0)
			{
				throw new ArgumentException("The profile properties cannot contain reserved names as keys: " + string.Join(" or ", list.ToArray()));
			}
		}

		private void ValidateNoProfileOptionsProperties(Dictionary<string, string> userProperties)
		{
			if (userProperties == null)
			{
				return;
			}
			foreach (string key in userProperties.Keys)
			{
				if (_mappedNames.Contains(key, StringComparer.OrdinalIgnoreCase))
				{
					throw new ArgumentException("The profile properties dictionary cannot contain a key named " + key + " because it is in the name mapping dictionary.");
				}
			}
		}

		private Dictionary<string, string> Convert(CredentialProfileOptions profileOptions)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!profileOptions.IsEmpty)
			{
				PropertyInfo[] properties = typeof(CredentialProfileOptions).GetProperties();
				Array.Sort(properties.Select((PropertyInfo p) => p.Name).ToArray(), properties);
				PropertyInfo[] array = properties;
				foreach (PropertyInfo propertyInfo in array)
				{
					string value = (string)propertyInfo.GetValue(profileOptions, null);
					if (string.IsNullOrEmpty(value))
					{
						value = null;
					}
					if (_nameMapping[propertyInfo.Name] != null)
					{
						dictionary.Add(_nameMapping[propertyInfo.Name], value);
					}
				}
			}
			return dictionary;
		}
	}
}
