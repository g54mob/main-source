using System;
using System.Reflection;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class ReflectionUtility
	{
		private static readonly BindingFlags DefaultBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		public static object InvokeMethod(this object target, string methodName)
		{
			MethodInfo methodInfo = Get<MethodInfo>(target, methodName);
			if ((object)methodInfo == null)
			{
				Debug.LogError("Method " + methodName + " not found");
				return null;
			}
			return methodInfo.Invoke(target, null);
		}

		public static bool TryGetField<TObject>(this object target, string fieldName, out TObject outObject)
		{
			if (target.TryGetField(fieldName, out var outObject2) && outObject2 is TObject val)
			{
				outObject = val;
				return true;
			}
			outObject = default(TObject);
			return false;
		}

		public static bool TryGetField(this object target, string fieldName, out object outObject)
		{
			FieldInfo fieldInfo = Get<FieldInfo>(target, fieldName);
			if ((object)fieldInfo == null)
			{
				outObject = null;
				return false;
			}
			outObject = fieldInfo.GetValue(target);
			return true;
		}

		private static TReflect Get<TReflect>(object target, string fieldName) where TReflect : MemberInfo
		{
			Type type = target.GetType();
			Type typeFromHandle = typeof(TReflect);
			MemberInfo memberInfo;
			do
			{
				if (typeFromHandle == typeof(FieldInfo))
				{
					memberInfo = type.GetField(fieldName, DefaultBindingFlags);
				}
				else if (typeFromHandle == typeof(PropertyInfo))
				{
					memberInfo = type.GetProperty(fieldName, DefaultBindingFlags);
				}
				else
				{
					if (!(typeFromHandle == typeof(MethodInfo)))
					{
						throw new Exception("Can't get member info");
					}
					memberInfo = type.GetMethod(fieldName, DefaultBindingFlags);
				}
				type = type.BaseType;
			}
			while ((object)memberInfo == null && (object)type != null);
			if ((object)memberInfo == null)
			{
				Debug.LogError(typeFromHandle.Name + " " + fieldName + " not found");
				return null;
			}
			return (TReflect)memberInfo;
		}

		public static bool TryGetProperty<TObject>(this object target, string fieldName, out TObject outObject)
		{
			PropertyInfo propertyInfo = Get<PropertyInfo>(target, fieldName);
			if ((object)propertyInfo == null)
			{
				outObject = default(TObject);
				return false;
			}
			if (propertyInfo.GetValue(target) is TObject val)
			{
				outObject = val;
				return true;
			}
			outObject = default(TObject);
			return true;
		}

		public static void SetProperty<TObject>(this object target, string propertyName, TObject value)
		{
			PropertyInfo propertyInfo = Get<PropertyInfo>(target, propertyName);
			if ((object)propertyInfo != null)
			{
				if (propertyInfo.PropertyType != typeof(TObject))
				{
					Debug.LogError($"Property {propertyName} isn't of type {typeof(TObject)}");
				}
				else
				{
					propertyInfo.SetValue(target, value);
				}
			}
		}

		public static TObject GetField<TObject>(this object target, string fieldName)
		{
			object obj = Get<FieldInfo>(target, fieldName)?.GetValue(target);
			if (obj is TObject)
			{
				return (TObject)obj;
			}
			return default(TObject);
		}

		public static object GetField(this object target, string fieldName)
		{
			return Get<FieldInfo>(target, fieldName)?.GetValue(target);
		}

		public static void SetField(this object target, string fieldName, object value)
		{
			FieldInfo fieldInfo = Get<FieldInfo>(target, fieldName);
			if ((object)fieldInfo == null)
			{
				Debug.LogError("Field " + fieldName + " not found");
			}
			else
			{
				fieldInfo.SetValue(target, value);
			}
		}

		public static void SetField<TObject>(this object target, string fieldName, TObject value)
		{
			FieldInfo fieldInfo = Get<FieldInfo>(target, fieldName);
			if ((object)fieldInfo == null)
			{
				Debug.LogError("Field " + fieldName + " not found");
			}
			else if (fieldInfo.GetValue(target) is TObject)
			{
				fieldInfo.SetValue(target, value);
			}
		}
	}
}
