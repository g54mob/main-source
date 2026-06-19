using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;

namespace TH20
{
	public static class UnitySerialisationUtils
	{
		public static bool TypeIsSerializedByUnity(Type type)
		{
			if (type.IsAbstract)
			{
				return false;
			}
			if (type == typeof(UnityEngine.Object) || (type.IsClass && type.IsSubclassOf(typeof(UnityEngine.Object))))
			{
				return true;
			}
			if ((type.IsClass || (type.IsValueType && !type.IsEnum)) && type.GetCustomAttributes(typeof(SerializableAttribute), inherit: false).Length == 0)
			{
				return false;
			}
			if (type.IsArray)
			{
				return TypeIsSerializedByUnity(type.GetElementType());
			}
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments().Length == 1)
			{
				return TypeIsSerializedByUnity(type.GetGenericArguments()[0]);
			}
			return true;
		}

		public static bool FieldIsSerializedByUnity(FieldInfo field)
		{
			if (field.IsStatic)
			{
				return false;
			}
			if (field.IsLiteral)
			{
				return false;
			}
			if (field.IsInitOnly)
			{
				return false;
			}
			if (!field.IsPublic && field.GetCustomAttributes(typeof(SerializeField), inherit: false).Length == 0)
			{
				return false;
			}
			if (!TypeIsSerializedByUnity(field.FieldType))
			{
				return false;
			}
			return true;
		}

		public static T CreateInstance<T>()
		{
			return (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, CultureInfo.InvariantCulture);
		}

		public static T CreateInstance<T>(T obj)
		{
			object obj2 = Activator.CreateInstance(obj.GetType(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, CultureInfo.InvariantCulture);
			FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				List<object> list = new List<object>(fieldInfo.GetCustomAttributes(inherit: true));
				if (!list.Exists((object x) => x is NonSerializedAttribute) && (fieldInfo.IsPublic || list.Exists((object x) => x is SerializeField)))
				{
					object value = fieldInfo.GetValue(obj);
					fieldInfo.SetValue(obj2, value);
				}
			}
			return (T)obj2;
		}
	}
}
