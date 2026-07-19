using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniJSON
{
	public static class FormatterExtensionsSerializer
	{
		public static void SerializeDictionary(this IFormatter f, IDictionary<string, object> dictionary)
		{
			f.BeginMap(dictionary.Count);
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				f.Key(item.Key);
				f.SerializeObject(item.Value);
			}
			f.EndMap();
		}

		public static void SerializeArray<T>(this IFormatter f, IEnumerable<T> values)
		{
			f.BeginList(values.Count());
			foreach (T value in values)
			{
				f.Serialize(value);
			}
			f.EndList();
		}

		public static void SerializeObjectArray(this IFormatter f, object[] array)
		{
			f.BeginList(array.Length);
			foreach (object value in array)
			{
				f.SerializeObject(value);
			}
			f.EndList();
		}

		public static void SerializeObject(this IFormatter f, object value)
		{
			if (value == null)
			{
				f.Null();
				return;
			}
			typeof(FormatterExtensionsSerializer).GetMethod("Serialize").MakeGenericMethod(value.GetType()).Invoke(null, new object[2] { f, value });
		}

		public static void Serialize<T>(this IFormatter f, T arg)
		{
			if (arg == null)
			{
				f.Null();
			}
			else
			{
				GenericSerializer<T>.Serialize(f, arg);
			}
		}

		public static void SetCustomSerializer<T>(Action<IFormatter, T> serializer)
		{
			GenericSerializer<T>.Set(serializer);
		}

		public static MethodInfo GetMethod(string name)
		{
			return typeof(FormatterExtensionsSerializer).GetMethod(name);
		}
	}
}
