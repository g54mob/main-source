using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Motorways
{
	public class JsonSerializable
	{
		public void LoadFromJson(JSON.Dictionary jsonDictionary)
		{
			if (jsonDictionary == null || jsonDictionary.Keys.Count == 0)
			{
				return;
			}
			foreach (PropertyInfo jsonSerializableProperty in GetJsonSerializableProperties())
			{
				string jsonSerializableName = GetJsonSerializableName(jsonSerializableProperty);
				if (jsonDictionary.ContainsKey(jsonSerializableName))
				{
					if (jsonSerializableProperty.PropertyType == typeof(int) || jsonSerializableProperty.PropertyType == typeof(short) || jsonSerializableProperty.PropertyType == typeof(int) || jsonSerializableProperty.PropertyType == typeof(long))
					{
						int num = jsonDictionary.GetInt(jsonSerializableName);
						jsonSerializableProperty.SetValue(this, num);
					}
					else if (jsonSerializableProperty.PropertyType == typeof(float))
					{
						jsonSerializableProperty.SetValue(this, jsonDictionary.GetFloat(jsonSerializableName));
					}
					else if (jsonSerializableProperty.PropertyType == typeof(string))
					{
						jsonSerializableProperty.SetValue(this, jsonDictionary.GetString(jsonSerializableName));
					}
					else
					{
						Diagnostics.FailAssert("Type {0} not supported", jsonSerializableProperty.DeclaringType);
					}
				}
			}
		}

		public void Merge(JsonSerializable other, DateTime ourTimestamp, DateTime theirTimestamp)
		{
			foreach (PropertyInfo jsonSerializableProperty in GetJsonSerializableProperties())
			{
				JsonSerializableAttribute[] array = (JsonSerializableAttribute[])jsonSerializableProperty.GetCustomAttributes(typeof(JsonSerializableAttribute), inherit: true);
				JsonSerializableAttribute.MergeStrategy mergeStrategy = array[0].mergeStrategy;
				object value = jsonSerializableProperty.GetValue(this);
				object value2 = jsonSerializableProperty.GetValue(other);
				bool condition = typeof(IComparable).IsAssignableFrom(jsonSerializableProperty.PropertyType);
				object value3;
				switch (mergeStrategy)
				{
				case JsonSerializableAttribute.MergeStrategy.Max:
					value3 = ((!Diagnostics.Verify(condition, "Can't compare object of type {0}! Defaulting to our value", jsonSerializableProperty.PropertyType)) ? value : (((value as IComparable).CompareTo(value2 as IComparable) >= 0) ? value : value2));
					break;
				case JsonSerializableAttribute.MergeStrategy.Min:
					value3 = ((!Diagnostics.Verify(condition, "Can't compare object of type {0}! Defaulting to our value", jsonSerializableProperty.PropertyType)) ? value : (((value as IComparable).CompareTo(value2 as IComparable) <= 0) ? value : value2));
					break;
				case JsonSerializableAttribute.MergeStrategy.Latest:
					value3 = ((ourTimestamp > theirTimestamp) ? value : value2);
					break;
				default:
					Diagnostics.FailAssert("Unknown merge strategy {0}, defaulting to our value", array[0].mergeStrategy);
					value3 = value;
					break;
				}
				jsonSerializableProperty.SetValue(this, value3);
			}
		}

		public Dictionary<string, object> Save()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (PropertyInfo jsonSerializableProperty in GetJsonSerializableProperties())
			{
				string jsonSerializableName = GetJsonSerializableName(jsonSerializableProperty);
				dictionary.Add(jsonSerializableName, jsonSerializableProperty.GetValue(this));
			}
			return dictionary;
		}

		public IEnumerable<PropertyInfo> GetJsonSerializableProperties()
		{
			return from p in GetType().GetProperties()
				where p.IsDefined(typeof(JsonSerializableAttribute), inherit: true)
				select p;
		}

		public static string GetJsonSerializableName(PropertyInfo property)
		{
			return ((JsonSerializableAttribute[])property.GetCustomAttributes(typeof(JsonSerializableAttribute), inherit: true))[0].serializedName;
		}
	}
}
