using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace TinyJSON
{
	public static class JSON
	{
		private static readonly Type includeAttrType = typeof(Include);

		private static readonly Type excludeAttrType = typeof(Exclude);

		private static Dictionary<string, Type> typeCache = new Dictionary<string, Type>();

		private static BindingFlags instanceBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private static BindingFlags staticBindingFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		private static MethodInfo decodeTypeMethod = typeof(JSON).GetMethod("DecodeType", staticBindingFlags);

		private static MethodInfo decodeListMethod = typeof(JSON).GetMethod("DecodeList", staticBindingFlags);

		private static MethodInfo decodeDictionaryMethod = typeof(JSON).GetMethod("DecodeDictionary", staticBindingFlags);

		private static MethodInfo decodeArrayMethod = typeof(JSON).GetMethod("DecodeArray", staticBindingFlags);

		private static MethodInfo decodeMultiRankArrayMethod = typeof(JSON).GetMethod("DecodeMultiRankArray", staticBindingFlags);

		public static Variant Load(string json)
		{
			if (json == null)
			{
				throw new ArgumentNullException("json");
			}
			return Decoder.Decode(json);
		}

		public static string Dump(object data)
		{
			return Dump(data, EncodeOptions.None);
		}

		public static string Dump(object data, EncodeOptions options)
		{
			if (data != null)
			{
				Type type = data.GetType();
				if (!type.IsEnum && !type.IsPrimitive && !type.IsArray)
				{
					MethodInfo[] methods = type.GetMethods(instanceBindingFlags);
					foreach (MethodInfo methodInfo in methods)
					{
						if (methodInfo.GetCustomAttributes(inherit: false).AnyOfType(typeof(BeforeEncode)) && methodInfo.GetParameters().Length == 0)
						{
							methodInfo.Invoke(data, null);
						}
					}
				}
			}
			return Encoder.Encode(data, options);
		}

		public static void MakeInto<T>(Variant data, out T item)
		{
			item = DecodeType<T>(data);
		}

		private static Type FindType(string fullName)
		{
			if (fullName == null)
			{
				return null;
			}
			if (typeCache.TryGetValue(fullName, out var value))
			{
				return value;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				value = assemblies[i].GetType(fullName);
				if (value != null)
				{
					typeCache.Add(fullName, value);
					return value;
				}
			}
			return null;
		}

		private static T DecodeType<T>(Variant data)
		{
			if (data == null)
			{
				return default(T);
			}
			Type type = typeof(T);
			if (type.IsEnum)
			{
				return (T)Enum.Parse(type, data.ToString());
			}
			if (type.IsPrimitive || type == typeof(string) || type == typeof(decimal))
			{
				return (T)Convert.ChangeType(data, type);
			}
			if (type.IsArray)
			{
				if (type.GetArrayRank() == 1)
				{
					return (T)decodeArrayMethod.MakeGenericMethod(type.GetElementType()).Invoke(null, new object[1] { data });
				}
				ProxyArray proxyArray = data as ProxyArray;
				int[] array = new int[type.GetArrayRank()];
				if (proxyArray.CanBeMultiRankArray(array))
				{
					Array array2 = Array.CreateInstance(type.GetElementType(), array);
					MethodInfo methodInfo = decodeMultiRankArrayMethod.MakeGenericMethod(type.GetElementType());
					try
					{
						methodInfo.Invoke(null, new object[4] { proxyArray, array2, 1, array });
					}
					catch (Exception innerException)
					{
						throw new DecodeException("Error decoding multidimensional array. Did you try to decode into an array of incompatible rank or element type?", innerException);
					}
					return (T)Convert.ChangeType(array2, typeof(T));
				}
				throw new DecodeException("Error decoding multidimensional array; JSON data doesn't seem fit this structure.");
			}
			if (typeof(IList).IsAssignableFrom(type))
			{
				return (T)decodeListMethod.MakeGenericMethod(type.GetGenericArguments()).Invoke(null, new object[1] { data });
			}
			if (typeof(IDictionary).IsAssignableFrom(type))
			{
				return (T)decodeDictionaryMethod.MakeGenericMethod(type.GetGenericArguments()).Invoke(null, new object[1] { data });
			}
			string typeHint = ((data as ProxyObject) ?? throw new InvalidCastException("ProxyObject expected when decoding into '" + type.FullName + "'.")).TypeHint;
			T val;
			if (typeHint != null && typeHint != type.FullName)
			{
				Type type2 = FindType(typeHint);
				if (type2 == null)
				{
					throw new TypeLoadException("Could not load type '" + typeHint + "'.");
				}
				if (!type.IsAssignableFrom(type2))
				{
					throw new InvalidCastException("Cannot assign type '" + typeHint + "' to type '" + type.FullName + "'.");
				}
				val = (T)Activator.CreateInstance(type2);
				type = type2;
			}
			else
			{
				val = Activator.CreateInstance<T>();
			}
			foreach (KeyValuePair<string, Variant> item in (IEnumerable<KeyValuePair<string, Variant>>)(data as ProxyObject))
			{
				FieldInfo field = type.GetField(item.Key, instanceBindingFlags);
				if (field != null)
				{
					bool flag = field.IsPublic;
					object[] customAttributes = field.GetCustomAttributes(inherit: true);
					foreach (object obj in customAttributes)
					{
						if (excludeAttrType.IsAssignableFrom(obj.GetType()))
						{
							flag = false;
						}
						if (includeAttrType.IsAssignableFrom(obj.GetType()))
						{
							flag = true;
						}
					}
					if (flag)
					{
						MethodInfo methodInfo2 = decodeTypeMethod.MakeGenericMethod(field.FieldType);
						if (type.IsValueType)
						{
							object obj2 = val;
							field.SetValue(obj2, methodInfo2.Invoke(null, new object[1] { item.Value }));
							val = (T)obj2;
						}
						else
						{
							field.SetValue(val, methodInfo2.Invoke(null, new object[1] { item.Value }));
						}
					}
				}
				PropertyInfo property = type.GetProperty(item.Key, instanceBindingFlags);
				if (property != null && property.CanWrite && property.GetCustomAttributes(inherit: false).AnyOfType(includeAttrType))
				{
					MethodInfo methodInfo3 = decodeTypeMethod.MakeGenericMethod(property.PropertyType);
					if (type.IsValueType)
					{
						object obj3 = val;
						property.SetValue(obj3, methodInfo3.Invoke(null, new object[1] { item.Value }), null);
						val = (T)obj3;
					}
					else
					{
						property.SetValue(val, methodInfo3.Invoke(null, new object[1] { item.Value }), null);
					}
				}
			}
			MethodInfo[] methods = type.GetMethods(instanceBindingFlags);
			foreach (MethodInfo methodInfo4 in methods)
			{
				if (methodInfo4.GetCustomAttributes(inherit: false).AnyOfType(typeof(AfterDecode)))
				{
					if (methodInfo4.GetParameters().Length == 0)
					{
						methodInfo4.Invoke(val, null);
						continue;
					}
					methodInfo4.Invoke(val, new object[1] { data });
				}
			}
			return val;
		}

		private static List<T> DecodeList<T>(Variant data)
		{
			List<T> list = new List<T>();
			foreach (Variant item in (IEnumerable<Variant>)(data as ProxyArray))
			{
				list.Add(DecodeType<T>(item));
			}
			return list;
		}

		private static Dictionary<K, V> DecodeDictionary<K, V>(Variant data)
		{
			Dictionary<K, V> dictionary = new Dictionary<K, V>();
			Type typeFromHandle = typeof(K);
			foreach (KeyValuePair<string, Variant> item in (IEnumerable<KeyValuePair<string, Variant>>)(data as ProxyObject))
			{
				K key = (K)(typeFromHandle.IsEnum ? Enum.Parse(typeFromHandle, item.Key) : Convert.ChangeType(item.Key, typeFromHandle));
				V value = DecodeType<V>(item.Value);
				dictionary.Add(key, value);
			}
			return dictionary;
		}

		private static T[] DecodeArray<T>(Variant data)
		{
			T[] array = new T[(data as ProxyArray).Count];
			int num = 0;
			foreach (Variant item in (IEnumerable<Variant>)(data as ProxyArray))
			{
				array[num++] = DecodeType<T>(item);
			}
			return array;
		}

		private static void DecodeMultiRankArray<T>(ProxyArray arrayData, Array array, int arrayRank, int[] indices)
		{
			int count = arrayData.Count;
			for (int i = 0; i < count; i++)
			{
				indices[arrayRank - 1] = i;
				if (arrayRank < array.Rank)
				{
					DecodeMultiRankArray<T>(arrayData[i] as ProxyArray, array, arrayRank + 1, indices);
				}
				else
				{
					array.SetValue(DecodeType<T>(arrayData[i]), indices);
				}
			}
		}

		public static void SupportTypeForAOT<T>()
		{
			DecodeType<T>(null);
			DecodeList<T>(null);
			DecodeArray<T>(null);
			DecodeDictionary<short, T>(null);
			DecodeDictionary<ushort, T>(null);
			DecodeDictionary<int, T>(null);
			DecodeDictionary<uint, T>(null);
			DecodeDictionary<long, T>(null);
			DecodeDictionary<ulong, T>(null);
			DecodeDictionary<float, T>(null);
			DecodeDictionary<double, T>(null);
			DecodeDictionary<decimal, T>(null);
			DecodeDictionary<bool, T>(null);
			DecodeDictionary<string, T>(null);
		}

		private static void SupportValueTypesForAOT()
		{
			SupportTypeForAOT<short>();
			SupportTypeForAOT<ushort>();
			SupportTypeForAOT<int>();
			SupportTypeForAOT<uint>();
			SupportTypeForAOT<long>();
			SupportTypeForAOT<ulong>();
			SupportTypeForAOT<float>();
			SupportTypeForAOT<double>();
			SupportTypeForAOT<decimal>();
			SupportTypeForAOT<bool>();
			SupportTypeForAOT<string>();
		}
	}
}
