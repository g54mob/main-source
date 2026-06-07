using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DV
{
	[Serializable]
	public abstract class BaseOverridablePreset<T> : ICloneable, ISerializable where T : class
	{
		protected class TrackedProperty
		{
			public readonly PropertyInfo PropertyInfo;

			public readonly Type InnerType;

			public readonly PropertyInfo IsOverriddenProperty;

			public readonly PropertyInfo CurrentValueProperty;

			public readonly MethodInfo EngageOverrideMethod;

			public readonly MethodInfo ClearOverrideMethod;

			public TrackedProperty(PropertyInfo property)
			{
				PropertyInfo = property;
				InnerType = property.PropertyType.GenericTypeArguments[0];
				IsOverriddenProperty = property.PropertyType.GetProperty("IsOverridden");
				CurrentValueProperty = property.PropertyType.GetProperty("CurrentValue");
				EngageOverrideMethod = property.PropertyType.GetMethod("EngageOverride");
				ClearOverrideMethod = property.PropertyType.GetMethod("ClearOverride");
			}
		}

		private static Dictionary<Type, Dictionary<string, TrackedProperty>> propertyCache = new Dictionary<Type, Dictionary<string, TrackedProperty>>();

		protected readonly Dictionary<string, TrackedProperty> myProperties;

		[JsonProperty]
		protected Dictionary<string, object> overriddenValues = new Dictionary<string, object>();

		protected static Dictionary<string, TrackedProperty> GetPropertiesInfo(Type type)
		{
			if (propertyCache.TryGetValue(type, out var value))
			{
				return value;
			}
			Dictionary<string, TrackedProperty> dictionary = new Dictionary<string, TrackedProperty>();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(OverridableValue<>))
				{
					dictionary.Add(propertyInfo.Name, new TrackedProperty(propertyInfo));
				}
			}
			propertyCache.Add(type, dictionary);
			return dictionary;
		}

		[JsonConstructor]
		public BaseOverridablePreset()
		{
			myProperties = GetPropertiesInfo(typeof(T));
		}

		public BaseOverridablePreset(T sourceObject)
			: this()
		{
			ReadFrom(sourceObject);
		}

		public void ReadFrom(T sourceObject)
		{
			overriddenValues.Clear();
			foreach (KeyValuePair<string, TrackedProperty> myProperty in myProperties)
			{
				string key = myProperty.Key;
				TrackedProperty value = myProperty.Value;
				object value2 = value.PropertyInfo.GetValue(sourceObject);
				if (value2 != null && (bool)value.IsOverriddenProperty.GetValue(value2))
				{
					overriddenValues[key] = value.CurrentValueProperty.GetValue(value2);
				}
			}
		}

		public void ApplyTo(T targetObject)
		{
			foreach (KeyValuePair<string, TrackedProperty> myProperty in myProperties)
			{
				string key = myProperty.Key;
				TrackedProperty value = myProperty.Value;
				object value2 = value.PropertyInfo.GetValue(targetObject);
				if (value2 != null)
				{
					bool flag = (bool)value.IsOverriddenProperty.GetValue(value2);
					if (overriddenValues.TryGetValue(key, out var value3))
					{
						value.EngageOverrideMethod.Invoke(value2, new object[1] { value3 });
					}
					else if (flag)
					{
						value.ClearOverrideMethod.Invoke(value2, null);
					}
				}
			}
		}

		protected void InternalSetOverride<V>(string propName, V value)
		{
			if (!myProperties.TryGetValue(propName, out var value2))
			{
				throw new ArgumentException($"Property {propName} not found in {typeof(T)}");
			}
			if (value2.PropertyInfo.PropertyType.GetGenericArguments()[0] != typeof(V))
			{
				throw new ArgumentException($"Property {propName} is not an OverridableValue<{typeof(V)}> in {typeof(T)}");
			}
			overriddenValues[propName] = value;
		}

		protected void InternalClearOverride(string propName)
		{
			if (!myProperties.ContainsKey(propName))
			{
				throw new ArgumentException($"Property {propName} not found in {typeof(T)}");
			}
			overriddenValues.Remove(propName);
		}

		protected bool InternalIsOverridden(string propName)
		{
			return overriddenValues.ContainsKey(propName);
		}

		protected Type InternalGetOverrideType(string propName)
		{
			return myProperties[propName].PropertyInfo.PropertyType.GetGenericArguments()[0];
		}

		protected static TrackedProperty GetProp(Type type, string propName)
		{
			if (GetPropertiesInfo(typeof(T)).TryGetValue(propName, out var value))
			{
				return value;
			}
			throw new ArgumentException($"Property {propName} of type OverridableValue<?> is not found in class {type}.");
		}

		public static void ClearAllOverridesOn(T targetObject)
		{
			foreach (KeyValuePair<string, TrackedProperty> item in GetPropertiesInfo(typeof(T)))
			{
				TrackedProperty value = item.Value;
				object value2 = value.PropertyInfo.GetValue(targetObject);
				if (value2 != null)
				{
					value.ClearOverrideMethod.Invoke(value2, null);
				}
			}
		}

		protected static V GetCurrentValueFrom<V>(T sourceObject, string propName)
		{
			TrackedProperty prop = GetProp(typeof(T), propName);
			if (!typeof(V).IsAssignableFrom(prop.PropertyInfo.PropertyType.GenericTypeArguments[0]))
			{
				throw new ArgumentException($"Property {propName} is not assignable from type {typeof(V)}, it is of type {prop.PropertyInfo.PropertyType.GenericTypeArguments[0]}");
			}
			object value = prop.PropertyInfo.GetValue(sourceObject);
			return (V)prop.CurrentValueProperty.GetValue(value);
		}

		protected static bool IsOverriddenIn(T sourceObject, string propName)
		{
			TrackedProperty prop = GetProp(typeof(T), propName);
			object value = prop.PropertyInfo.GetValue(sourceObject);
			return (bool)prop.IsOverriddenProperty.GetValue(value);
		}

		protected static void EngageOverrideOn<V>(T targetObject, string propName, V value)
		{
			TrackedProperty prop = GetProp(typeof(T), propName);
			if (!prop.PropertyInfo.PropertyType.GenericTypeArguments[0].IsAssignableFrom(typeof(V)))
			{
				throw new ArgumentException($"Property {propName} is not assignable from type {typeof(V)}, it is of type {prop.PropertyInfo.PropertyType.GenericTypeArguments[0]}");
			}
			object value2 = prop.PropertyInfo.GetValue(targetObject);
			prop.EngageOverrideMethod.Invoke(value2, new object[1] { value });
		}

		protected static void ClearOverrideOn(T targetObject, string propName)
		{
			TrackedProperty prop = GetProp(typeof(T), propName);
			object value = prop.PropertyInfo.GetValue(targetObject);
			prop.ClearOverrideMethod.Invoke(value, null);
		}

		public abstract object Clone();

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			foreach (KeyValuePair<string, object> overriddenValue in overriddenValues)
			{
				info.AddValue(overriddenValue.Key, overriddenValue.Value);
			}
		}

		protected BaseOverridablePreset(SerializationInfo info, StreamingContext context)
		{
			myProperties = GetPropertiesInfo(typeof(T));
			overriddenValues = new Dictionary<string, object>();
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				overriddenValues[current.Name] = Convert.ChangeType(current.Value, InternalGetOverrideType(current.Name));
			}
		}
	}
}
