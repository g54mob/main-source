using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class ReflectionUtil
	{
		private static Dictionary<object, MethodInfo> listClearMethodInfoCaches = new Dictionary<object, MethodInfo>();

		private static Dictionary<object, MethodInfo> listAddMethodInfoCaches = new Dictionary<object, MethodInfo>();

		public static void InvokeListClear(object obj, FieldInfo field)
		{
			object value = field.GetValue(obj);
			if (!listClearMethodInfoCaches.TryGetValue(value, out var value2))
			{
				value2 = value.GetType().GetMethod("Clear");
				listClearMethodInfoCaches[value] = value2;
			}
			value2.Invoke(value, new object[0]);
		}

		public static int InvokeListCount(object obj, FieldInfo field)
		{
			object value = field.GetValue(obj);
			return (int)value.GetType().GetProperty("Count").GetValue(value, null);
		}

		public static void InvokeListAdd(object obj, FieldInfo field, object item)
		{
			object value = field.GetValue(obj);
			if (!listAddMethodInfoCaches.TryGetValue(value, out var value2))
			{
				value2 = value.GetType().GetMethod("Add");
				listAddMethodInfoCaches[value] = value2;
			}
			value2.Invoke(value, new object[1] { item });
		}

		public static T InvokeListGet<T>(object obj, FieldInfo field, int i)
		{
			object value = field.GetValue(obj);
			return (T)value.GetType().GetProperty("Item").GetValue(value, new object[1] { i });
		}

		public static void InvokeListAddTo<T>(object obj, FieldInfo field, Action<T> callback)
		{
			object value = field.GetValue(obj);
			Type type = value.GetType();
			int num = Convert.ToInt32(type.GetProperty("Count").GetValue(value, null));
			for (int i = 0; i < num; i++)
			{
				object value2 = type.GetProperty("Item").GetValue(value, new object[1] { i });
				callback((T)value2);
			}
		}

		public static object DeepCloneSerializeField(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			Type type = obj.GetType();
			if (type.IsValueType || type == typeof(string))
			{
				return obj;
			}
			if (type.IsArray)
			{
				Type type2 = Type.GetType(type.FullName.Replace("[]", string.Empty));
				Array array = obj as Array;
				Array array2 = Array.CreateInstance(type2, array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					array2.SetValue(DeepCloneSerializeField(array.GetValue(i)), i);
				}
				return Convert.ChangeType(array2, obj.GetType());
			}
			if (type.IsClass)
			{
				object obj2;
				if (obj is IList)
				{
					PropertyInfo[] properties = type.GetProperties();
					obj2 = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(properties[^1].PropertyType));
					IList list = (IList)obj2;
					foreach (object item in (IList)obj)
					{
						if (item != null)
						{
							list.Add(DeepCloneSerializeField(item));
						}
					}
				}
				else
				{
					try
					{
						obj2 = Activator.CreateInstance(type);
					}
					catch
					{
						return null;
					}
					FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						if (fieldInfo.IsDefined(typeof(SerializeField), inherit: false))
						{
							object value = fieldInfo.GetValue(obj);
							if (value == null)
							{
								fieldInfo.SetValue(obj2, value);
							}
							else
							{
								fieldInfo.SetValue(obj2, DeepCloneSerializeField(value));
							}
						}
					}
				}
				return obj2;
			}
			throw new ArgumentException("DeepCloneSerializeField: Unknown type:" + type?.ToString() + "," + obj);
		}
	}
}
