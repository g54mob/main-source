using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema
{
	public static class JsonPathUtilities
	{
		public static string GetJsonPath(object rootObject, object searchedObject)
		{
			return GetJsonPath(rootObject, searchedObject, new DefaultContractResolver());
		}

		public static string GetJsonPath(object rootObject, object searchedObject, IContractResolver contractResolver)
		{
			return GetJsonPaths(rootObject, new List<object> { searchedObject }, contractResolver)[searchedObject];
		}

		public static IReadOnlyDictionary<object, string> GetJsonPaths(object rootObject, IEnumerable<object> searchedObjects, IContractResolver contractResolver)
		{
			if (rootObject == null)
			{
				throw new ArgumentNullException("rootObject");
			}
			Dictionary<object, string> dictionary = searchedObjects.ToDictionary((object o) => o, (object o) => (string)null);
			FindJsonPaths(rootObject, dictionary, "#", new HashSet<object>(), contractResolver);
			if (dictionary.Any((KeyValuePair<object, string> p) => p.Value == null))
			{
				throw new InvalidOperationException("Could not find the JSON path of a referenced schema: Manually referenced schemas must be added to the 'Definitions' of a parent schema.");
			}
			return dictionary;
		}

		private static bool FindJsonPaths(object obj, Dictionary<object, string> searchedObjects, string basePath, HashSet<object> checkedObjects, IContractResolver contractResolver)
		{
			if (obj == null)
			{
				return false;
			}
			Type type = obj.GetType();
			if (type == typeof(string) || type.IsPrimitive || type.IsEnum || type == typeof(JValue) || checkedObjects.Contains(obj))
			{
				return false;
			}
			if (searchedObjects.ContainsKey(obj))
			{
				searchedObjects[obj] = basePath;
				if (searchedObjects.All((KeyValuePair<object, string> p) => p.Value != null))
				{
					return true;
				}
			}
			checkedObjects.Add(obj);
			string text = basePath + "/";
			if (obj is IDictionary dictionary)
			{
				foreach (DictionaryEntry item in dictionary)
				{
					if (FindJsonPaths(item.Value, searchedObjects, text + item.Key, checkedObjects, contractResolver))
					{
						return true;
					}
				}
			}
			else if (obj is IList list)
			{
				for (int num = 0; num < list.Count; num++)
				{
					object obj2 = list[num];
					if (FindJsonPaths(obj2, searchedObjects, text + num, checkedObjects, contractResolver))
					{
						return true;
					}
				}
			}
			else if (obj is IEnumerable enumerable)
			{
				int num2 = 0;
				foreach (object item2 in enumerable)
				{
					if (FindJsonPaths(item2, searchedObjects, text + num2, checkedObjects, contractResolver))
					{
						return true;
					}
					num2++;
				}
			}
			else if (contractResolver.ResolveContract(type) is JsonObjectContract jsonObjectContract)
			{
				foreach (JsonProperty property in jsonObjectContract.Properties)
				{
					if (!property.Ignored)
					{
						object value = property.ValueProvider.GetValue(obj);
						if (value != null && FindJsonPaths(value, searchedObjects, text + property.PropertyName, checkedObjects, contractResolver))
						{
							return true;
						}
					}
				}
				if (obj is IJsonExtensionObject)
				{
					PropertyInfo runtimeProperty = type.GetRuntimeProperty("ExtensionData");
					if (runtimeProperty != null)
					{
						object value2 = runtimeProperty.GetValue(obj);
						if (FindJsonPaths(value2, searchedObjects, basePath, checkedObjects, contractResolver))
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
