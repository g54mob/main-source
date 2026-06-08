using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MLAPI.Reflection;
using UnityEngine;

namespace MLAPI.Serialization
{
	public static class SerializationManager
	{
		public delegate T CustomDeserializationDelegate<T>(Stream stream);

		public delegate void CustomSerializationDelegate<T>(Stream stream, T instance);

		private delegate void BoxedSerializationDelegate(Stream stream, object instance);

		private delegate object BoxedDeserializationDelegate(Stream stream);

		private static readonly Dictionary<Type, FieldInfo[]> fieldCache = new Dictionary<Type, FieldInfo[]>();

		private static readonly Dictionary<Type, BoxedSerializationDelegate> cachedExternalSerializers = new Dictionary<Type, BoxedSerializationDelegate>();

		private static readonly Dictionary<Type, BoxedDeserializationDelegate> cachedExternalDeserializers = new Dictionary<Type, BoxedDeserializationDelegate>();

		private static readonly HashSet<Type> SupportedTypes = new HashSet<Type>
		{
			typeof(byte),
			typeof(byte),
			typeof(sbyte),
			typeof(ushort),
			typeof(short),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(float),
			typeof(double),
			typeof(string),
			typeof(bool),
			typeof(Vector2),
			typeof(Vector3),
			typeof(Vector4),
			typeof(Color),
			typeof(Color32),
			typeof(Ray),
			typeof(Quaternion),
			typeof(char),
			typeof(GameObject),
			typeof(NetworkedObject),
			typeof(NetworkedBehaviour)
		};

		public static void RegisterSerializationHandlers<T>(CustomSerializationDelegate<T> onSerialize, CustomDeserializationDelegate<T> onDeserialize)
		{
			cachedExternalSerializers[typeof(T)] = delegate(Stream stream, object instance)
			{
				onSerialize(stream, (T)instance);
			};
			cachedExternalDeserializers[typeof(T)] = (Stream stream) => onDeserialize(stream);
		}

		public static bool RemoveSerializationHandlers<T>()
		{
			bool flag = cachedExternalSerializers.Remove(typeof(T));
			bool flag2 = cachedExternalDeserializers.Remove(typeof(T));
			return flag || flag2;
		}

		internal static bool TrySerialize(Stream stream, object obj)
		{
			if (cachedExternalSerializers.ContainsKey(obj.GetType()))
			{
				cachedExternalSerializers[obj.GetType()](stream, obj);
				return true;
			}
			return false;
		}

		internal static bool TryDeserialize(Stream stream, Type type, out object obj)
		{
			if (cachedExternalDeserializers.ContainsKey(type))
			{
				obj = cachedExternalDeserializers[type](stream);
				return true;
			}
			obj = null;
			return false;
		}

		internal static FieldInfo[] GetFieldsForType(Type type)
		{
			if (fieldCache.ContainsKey(type))
			{
				return fieldCache[type];
			}
			FieldInfo[] array = (from x in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
				where (x.IsPublic || x.GetCustomAttributes(typeof(SerializeField), inherit: true).Length != 0) && IsTypeSupported(x.FieldType)
				select x).OrderBy((FieldInfo x) => x.Name, StringComparer.Ordinal).ToArray();
			fieldCache.Add(type, array);
			return array;
		}

		public static bool IsTypeSupported(Type type)
		{
			if (!type.IsEnum && !SupportedTypes.Contains(type) && !type.HasInterface(typeof(IBitWritable)) && (!cachedExternalSerializers.ContainsKey(type) || !cachedExternalDeserializers.ContainsKey(type)))
			{
				if (type.IsArray && type.HasElementType)
				{
					return IsTypeSupported(type.GetElementType());
				}
				return false;
			}
			return true;
		}
	}
}
