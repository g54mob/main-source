using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Namotion.Reflection
{
	public static class ObjectExtensions
	{
		public static bool DisableNullabilityValidation { get; set; }

		public static bool HasProperty(this object? obj, string propertyName)
		{
			return obj?.GetType().GetRuntimeProperty(propertyName) != null;
		}

		public static T? TryGetPropertyValue<T>(this object? obj, string propertyName, T? defaultValue = default(T?))
		{
			PropertyInfo propertyInfo = obj?.GetType().GetRuntimeProperty(propertyName);
			if (!(propertyInfo == null))
			{
				return (T)propertyInfo.GetValue(obj);
			}
			return defaultValue;
		}

		public static bool HasValidNullability(this object obj, bool checkChildren = true)
		{
			return !obj.ValidateNullability(checkChildren).Any();
		}

		public static void EnsureValidNullability(this object? obj, bool checkChildren = true)
		{
			if (obj != null)
			{
				ValidateNullability(obj, obj.GetType().ToContextualType(), checkChildren ? new HashSet<object>() : null, null, stopFirstFail: false);
			}
		}

		public static IEnumerable<string> ValidateNullability(this object obj, bool checkChildren = true)
		{
			List<string> list = new List<string>();
			ValidateNullability(obj, obj.GetType().ToContextualType(), checkChildren ? new HashSet<object>() : null, list, stopFirstFail: false);
			return list;
		}

		private static void ValidateNullability(object obj, ContextualType type, HashSet<object>? checkedObjects, List<string>? errors, bool stopFirstFail)
		{
			if (DisableNullabilityValidation || (stopFirstFail && errors != null && errors.Any()))
			{
				return;
			}
			if (checkedObjects != null)
			{
				if (checkedObjects.Contains(obj))
				{
					return;
				}
				checkedObjects.Add(obj);
			}
			if (checkedObjects != null && obj is IDictionary dictionary)
			{
				{
					foreach (object item in dictionary.Keys.Cast<object>().Concat(dictionary.Values.Cast<object>()))
					{
						ValidateNullability(item, type.GenericArguments[1], checkedObjects, errors, stopFirstFail);
					}
					return;
				}
			}
			if (checkedObjects != null && obj is IEnumerable source && !(obj is string))
			{
				ContextualType contextualType = type.ElementType ?? type.GenericArguments[0];
				{
					foreach (object item2 in source.Cast<object>())
					{
						if (item2 == null)
						{
							if (contextualType.Nullability == Nullability.NotNullable)
							{
								throw new InvalidOperationException("The object's nullability is invalid, item in enumerable.");
							}
						}
						else
						{
							ValidateNullability(item2, contextualType, checkedObjects, errors, stopFirstFail);
						}
					}
					return;
				}
			}
			if (type.TypeInfo.IsValueType)
			{
				return;
			}
			ContextualPropertyInfo[] contextualProperties = type.Type.GetContextualProperties();
			foreach (ContextualPropertyInfo contextualPropertyInfo in contextualProperties)
			{
				if (contextualPropertyInfo.PropertyType.IsValueType || !contextualPropertyInfo.CanRead || contextualPropertyInfo.GetContextAttribute<CompilerGeneratedAttribute>() != null)
				{
					continue;
				}
				object value = contextualPropertyInfo.GetValue(obj);
				if (value == null)
				{
					if (contextualPropertyInfo.Nullability == Nullability.NotNullable)
					{
						if (errors == null)
						{
							throw new InvalidOperationException("The object's nullability is invalid, property: " + contextualPropertyInfo.PropertyType.Type.FullName + "." + contextualPropertyInfo.Name);
						}
						errors.Add(contextualPropertyInfo.Name);
						if (stopFirstFail)
						{
							break;
						}
					}
				}
				else if (checkedObjects != null)
				{
					ValidateNullability(value, contextualPropertyInfo.PropertyType, checkedObjects, errors, stopFirstFail);
				}
			}
		}
	}
}
