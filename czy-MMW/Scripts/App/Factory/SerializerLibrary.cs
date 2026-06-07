using System;
using System.Collections.Generic;
using FixMath;
using UnityEngine;

namespace Factory
{
	public static class SerializerLibrary
	{
		private class BoolSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((bool)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadBoolean();
			}
		}

		private class CharSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((char)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadChar();
			}
		}

		private class Int16Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((short)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadInt16();
			}
		}

		private class Int32Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((int)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadInt32();
			}
		}

		private class UInt32Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((uint)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadUInt32();
			}
		}

		private class Int64Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((long)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadInt64();
			}
		}

		private class UInt64Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((ulong)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadUInt64();
			}
		}

		private class Fix64Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write(((Fix64)obj).RawValue);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return Fix64.FromRaw(context.Reader.ReadInt64());
			}
		}

		private class SingleSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((float)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadSingle();
			}
		}

		private class StringSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((string)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadString();
			}
		}

		private class DateTimeSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				long value = ((DateTime)obj).ToBinary();
				context.Writer.Write(value);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return DateTime.FromBinary(context.Reader.ReadInt64());
			}
		}

		private class DoubleSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				context.Writer.Write((double)obj);
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return context.Reader.ReadDouble();
			}
		}

		private class Vector2Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is Vector2 vector)
				{
					context.Writer.Write(vector.x);
					context.Writer.Write(vector.y);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				float x = context.Reader.ReadSingle();
				float y = context.Reader.ReadSingle();
				return new Vector2(x, y);
			}
		}

		private class Vector2IntSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is Vector2Int vector2Int)
				{
					context.Writer.Write(vector2Int.x);
					context.Writer.Write(vector2Int.y);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				int x = context.Reader.ReadInt32();
				int y = context.Reader.ReadInt32();
				return new Vector2Int(x, y);
			}
		}

		private class Vector2FixedSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is Vector2Fixed vector2Fixed)
				{
					context.Writer.Write(vector2Fixed.x.RawValue);
					context.Writer.Write(vector2Fixed.y.RawValue);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				Fix64 x = Fix64.FromRaw(context.Reader.ReadInt64());
				Fix64 y = Fix64.FromRaw(context.Reader.ReadInt64());
				return new Vector2Fixed(x, y);
			}
		}

		private class Vector3Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is Vector3 vector)
				{
					context.Writer.Write(vector.x);
					context.Writer.Write(vector.y);
					context.Writer.Write(vector.z);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				float x = context.Reader.ReadSingle();
				float y = context.Reader.ReadSingle();
				float z = context.Reader.ReadSingle();
				return new Vector3(x, y, z);
			}
		}

		private class Vector3FixedSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is Vector3Fixed vector3Fixed)
				{
					context.Writer.Write(vector3Fixed.x.RawValue);
					context.Writer.Write(vector3Fixed.y.RawValue);
					context.Writer.Write(vector3Fixed.z.RawValue);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				Fix64 xValue = Fix64.FromRaw(context.Reader.ReadInt64());
				Fix64 yValue = Fix64.FromRaw(context.Reader.ReadInt64());
				Fix64 zValue = Fix64.FromRaw(context.Reader.ReadInt64());
				return new Vector3Fixed(xValue, yValue, zValue);
			}
		}

		private class RectIntSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is RectInt rectInt)
				{
					context.Writer.Write(rectInt.xMin);
					context.Writer.Write(rectInt.yMin);
					context.Writer.Write(rectInt.width);
					context.Writer.Write(rectInt.height);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				int xMin = context.Reader.ReadInt32();
				int yMin = context.Reader.ReadInt32();
				int width = context.Reader.ReadInt32();
				int height = context.Reader.ReadInt32();
				return new RectInt(xMin, yMin, width, height);
			}
		}

		private class TypeIdSerializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				Type type = obj as Type;
				if (!Diagnostics.Verify(type != null, "TypeIdSerializer unable to convert {0} to System.Type.", obj))
				{
					return false;
				}
				context.Writer.Write(TypeUtilities.GetTypeId(type));
				return true;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				int typeId = context.Reader.ReadInt32();
				return context.Scope.Assembler.TranslateTypeId(typeId);
			}
		}

		private class ObjectSerializer : ISerializer
		{
			public bool CanNestObjects => true;

			public bool Serialize(object obj, ExportContext context)
			{
				if (obj == null)
				{
					context.Writer.Write(0);
					return true;
				}
				int objectId = context.Library.GetObjectId(obj);
				context.Writer.Write(objectId);
				return true;
			}

			public object Deserialize(object existingObj, ImportContext context)
			{
				return context.GetObject(context.Reader.ReadInt32());
			}

			public IEnumerable<object> GetNestedObjects(object obj)
			{
				yield return obj;
			}
		}

		public class ArraySerializer<T> : ISerializer
		{
			private readonly ISerializer _itemSerializer;

			public bool CanNestObjects => _itemSerializer.CanNestObjects;

			public ArraySerializer()
			{
				_itemSerializer = GetSerializer(typeof(T));
			}

			public bool Serialize(object obj, ExportContext context)
			{
				if (!(obj is T[] array))
				{
					if (obj == null)
					{
						context.Writer.Write(0);
						return true;
					}
					return false;
				}
				context.Writer.Write(array.Length);
				T[] array2 = array;
				foreach (T val in array2)
				{
					_itemSerializer.Serialize(val, context);
				}
				return true;
			}

			public object Deserialize(object existingObj, ImportContext context)
			{
				int num = context.Reader.ReadInt32();
				if (num < 0)
				{
					Log.Error("An array of {0} was deserialized with {1} elements. It will be set to zero, but likely indicates that the array is being deserialized from the wrong point in the byte stream.", typeof(T), num);
					num = 0;
				}
				T[] array = null;
				if (existingObj != null)
				{
					array = existingObj as T[];
					if (array != null && array.Length != num)
					{
						array = null;
					}
				}
				if (array == null)
				{
					array = new T[num];
				}
				for (int i = 0; i < num; i++)
				{
					object obj = _itemSerializer.Deserialize(null, context);
					if (obj == null)
					{
						Log.Warn("Failed to deserialise item #{0} in list of {1}.", i, typeof(T));
					}
					array[i] = (T)obj;
				}
				return array;
			}

			public IEnumerable<object> GetNestedObjects(object obj)
			{
				if (!(obj is T[] array))
				{
					yield break;
				}
				T[] array2 = array;
				foreach (T val in array2)
				{
					foreach (object nestedObject in _itemSerializer.GetNestedObjects(val))
					{
						yield return nestedObject;
					}
				}
			}
		}

		public class ListSerializer<T> : ISerializer
		{
			private readonly ISerializer _itemSerializer;

			public bool CanNestObjects => _itemSerializer.CanNestObjects;

			public ListSerializer()
			{
				_itemSerializer = GetSerializer(typeof(T));
			}

			public bool Serialize(object obj, ExportContext context)
			{
				if (!(obj is List<T> list))
				{
					if (obj == null)
					{
						context.Writer.Write(-1);
						return true;
					}
					return false;
				}
				context.Writer.Write(list.Count);
				foreach (T item in list)
				{
					_itemSerializer.Serialize(item, context);
				}
				return true;
			}

			public object Deserialize(object existingObj, ImportContext context)
			{
				int num = context.Reader.ReadInt32();
				List<T> list = existingObj as List<T>;
				if (list != null)
				{
					list.Clear();
				}
				else
				{
					list = ((num >= 0) ? new List<T>(num) : null);
				}
				if (num < 0 || list == null)
				{
					return list;
				}
				for (int i = 0; i < num; i++)
				{
					object obj = _itemSerializer.Deserialize(null, context);
					if (obj == null)
					{
						Log.Warn("Failed to deserialise item #{0} in array of {1}.", i, typeof(T));
					}
					list.Add((T)obj);
				}
				return list;
			}

			public IEnumerable<object> GetNestedObjects(object obj)
			{
				if (!(obj is List<T> list))
				{
					yield break;
				}
				foreach (T item in list)
				{
					foreach (object nestedObject in _itemSerializer.GetNestedObjects(item))
					{
						yield return nestedObject;
					}
				}
			}
		}

		public class DictionarySerializer<TKey, TValue> : ISerializer
		{
			private readonly ISerializer _keySerializer;

			private readonly ISerializer _valueSerializer;

			public bool CanNestObjects
			{
				get
				{
					if (!_keySerializer.CanNestObjects)
					{
						return _valueSerializer.CanNestObjects;
					}
					return true;
				}
			}

			public DictionarySerializer()
			{
				_keySerializer = GetSerializer(typeof(TKey));
				_valueSerializer = GetSerializer(typeof(TValue));
			}

			public bool Serialize(object obj, ExportContext context)
			{
				if (!(obj is Dictionary<TKey, TValue> dictionary))
				{
					if (obj == null)
					{
						context.Writer.Write(0);
						return true;
					}
					return false;
				}
				context.Writer.Write(dictionary.Count);
				foreach (KeyValuePair<TKey, TValue> item in dictionary)
				{
					_keySerializer.Serialize(item.Key, context);
					_valueSerializer.Serialize(item.Value, context);
				}
				return true;
			}

			public object Deserialize(object existingObj, ImportContext context)
			{
				int num = context.Reader.ReadInt32();
				Dictionary<TKey, TValue> dictionary = existingObj as Dictionary<TKey, TValue>;
				if (dictionary != null)
				{
					dictionary.Clear();
				}
				else
				{
					dictionary = new Dictionary<TKey, TValue>(num);
				}
				if (num > 0)
				{
					if (_keySerializer is ObjectSerializer)
					{
						List<object> list = new List<object>(num);
						List<object> list2 = new List<object>(num);
						for (int i = 0; i < num; i++)
						{
							object item = _keySerializer.Deserialize(null, context);
							object item2 = _valueSerializer.Deserialize(null, context);
							list.Add(item);
							list2.Add(item2);
						}
						context.AddUnmappedDictionary(dictionary, list, list2);
					}
					else
					{
						for (int j = 0; j < num; j++)
						{
							object obj = _keySerializer.Deserialize(null, context);
							object obj2 = _valueSerializer.Deserialize(null, context);
							if (obj == null || obj2 == null)
							{
								return null;
							}
							dictionary[(TKey)obj] = (TValue)obj2;
						}
					}
				}
				return dictionary;
			}

			public IEnumerable<object> GetNestedObjects(object obj)
			{
				if (!(obj is Dictionary<TKey, TValue> dictionary))
				{
					yield break;
				}
				if (_keySerializer.CanNestObjects)
				{
					foreach (TKey key in dictionary.Keys)
					{
						foreach (object nestedObject in _keySerializer.GetNestedObjects(key))
						{
							yield return nestedObject;
						}
					}
				}
				if (!_valueSerializer.CanNestObjects)
				{
					yield break;
				}
				foreach (TValue value in dictionary.Values)
				{
					foreach (object nestedObject2 in _valueSerializer.GetNestedObjects(value))
					{
						yield return nestedObject2;
					}
				}
			}
		}

		private static Dictionary<Type, ISerializer> _typeSerializers = new Dictionary<Type, ISerializer>();

		private static ISerializer _objectSerializer;

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Serializer");

		public static void RegisterSerializer<T>(ISerializer serializer)
		{
			RegisterSerializer(typeof(T), serializer);
		}

		public static void RegisterSerializer(Type type, ISerializer serializer)
		{
			_typeSerializers[type] = serializer;
		}

		public static ISerializer GetSerializer<T>()
		{
			return GetSerializer(typeof(T));
		}

		public static ISerializer GetSerializer(Type type)
		{
			if (_objectSerializer == null)
			{
				RegisterSerializer<bool>(new BoolSerializer());
				RegisterSerializer<char>(new CharSerializer());
				RegisterSerializer<short>(new Int16Serializer());
				RegisterSerializer<int>(new Int32Serializer());
				RegisterSerializer<uint>(new UInt32Serializer());
				RegisterSerializer<long>(new Int64Serializer());
				RegisterSerializer<ulong>(new UInt64Serializer());
				RegisterSerializer<Fix64>(new Fix64Serializer());
				RegisterSerializer<float>(new SingleSerializer());
				RegisterSerializer<double>(new DoubleSerializer());
				RegisterSerializer<string>(new StringSerializer());
				RegisterSerializer<DateTime>(new DateTimeSerializer());
				RegisterSerializer<Vector2>(new Vector2Serializer());
				RegisterSerializer<Vector2Int>(new Vector2IntSerializer());
				RegisterSerializer<Vector2Fixed>(new Vector2FixedSerializer());
				RegisterSerializer<Vector3>(new Vector3Serializer());
				RegisterSerializer<Vector3Fixed>(new Vector3FixedSerializer());
				RegisterSerializer<RectInt>(new RectIntSerializer());
				RegisterSerializer<Type>(new TypeIdSerializer());
				_objectSerializer = new ObjectSerializer();
			}
			if (_typeSerializers.ContainsKey(type))
			{
				return _typeSerializers[type];
			}
			if (type.IsEnum)
			{
				return GetSerializer(Enum.GetUnderlyingType(type));
			}
			if (type.IsArray)
			{
				return Activator.CreateInstance(typeof(ArraySerializer<>).MakeGenericType(type.GetElementType())) as ISerializer;
			}
			if (type.IsGenericType)
			{
				if (type.GetGenericTypeDefinition() == typeof(List<>))
				{
					return Activator.CreateInstance(typeof(ListSerializer<>).MakeGenericType(type.GetGenericArguments()[0])) as ISerializer;
				}
				if (type.GetGenericTypeDefinition() == typeof(Dictionary<, >))
				{
					return Activator.CreateInstance(typeof(DictionarySerializer<, >).MakeGenericType(type.GetGenericArguments()[0], type.GetGenericArguments()[1])) as ISerializer;
				}
			}
			if (type.IsClass || type.IsInterface)
			{
				return _objectSerializer;
			}
			return null;
		}
	}
}
