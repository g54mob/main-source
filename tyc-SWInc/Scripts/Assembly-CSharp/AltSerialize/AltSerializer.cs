using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;

namespace AltSerialize
{
	public class AltSerializer
	{
		public static int DepthCounter;

		private static Dictionary<Type, int> _hashTypeInt;

		private static Dictionary<int, Type> _hashIntType;

		private static Dictionary<string, Type> _types;

		private static Dictionary<Type, ObjectMetaData> _metaDataHash;

		private bool _serializeProperties = true;

		public bool NetworkMode;

		public int ConvertFloats = -1;

		private Encoding _encoding = Encoding.Unicode;

		private Stream _stream;

		private bool _cacheEnabled = true;

		private bool _serializePropertyNames;

		private SerializerCache _cache = new SerializerCache();

		private byte[] arrayBuffer;

		private int BlockSize = 16384;

		private static Dictionary<Type, string> _cachedTypeNames;

		private static StringBuilder _cachedBuilder;

		private byte[] guidArray = new byte[16];

		private static Dictionary<Type, Dictionary<string, Type>> _cachedDeps;

		private readonly object[] _streamContext = new object[1] { default(StreamingContext) };

		internal static Dictionary<Type, ObjectMetaData> MetaDataHash
		{
			get
			{
				return _metaDataHash;
			}
		}

		public bool SerializeProperties
		{
			get
			{
				return _serializeProperties;
			}
			set
			{
				_serializeProperties = value;
			}
		}

		public Encoding Encoding
		{
			get
			{
				return _encoding;
			}
			set
			{
				_encoding = value;
			}
		}

		public Stream Stream
		{
			get
			{
				return _stream;
			}
			set
			{
				_stream = value;
			}
		}

		public bool CacheEnabled
		{
			get
			{
				return _cacheEnabled;
			}
			set
			{
				_cacheEnabled = value;
			}
		}

		public bool SerializePropertyNames
		{
			get
			{
				return _serializePropertyNames;
			}
			set
			{
				_serializePropertyNames = value;
			}
		}

		internal SerializerCache Cache
		{
			get
			{
				return _cache;
			}
		}

		private static void AddType(Type objectType, int hashId)
		{
			_hashIntType[hashId] = objectType;
			_hashTypeInt[objectType] = hashId;
		}

		private static void AddTypes()
		{
			AddType(typeof(int), 0);
			AddType(typeof(uint), 1);
			AddType(typeof(short), 2);
			AddType(typeof(ushort), 3);
			AddType(typeof(byte), 4);
			AddType(typeof(sbyte), 5);
			AddType(typeof(long), 6);
			AddType(typeof(ulong), 7);
			AddType(typeof(float), 8);
			AddType(typeof(double), 9);
			AddType(typeof(decimal), 10);
			AddType(typeof(int?), 20);
			AddType(typeof(uint?), 21);
			AddType(typeof(short?), 22);
			AddType(typeof(ushort?), 23);
			AddType(typeof(byte?), 24);
			AddType(typeof(sbyte?), 25);
			AddType(typeof(long?), 26);
			AddType(typeof(ulong?), 27);
			AddType(typeof(float?), 28);
			AddType(typeof(double?), 29);
			AddType(typeof(decimal?), 30);
			AddType(typeof(char), 31);
			AddType(typeof(char?), 32);
			AddType(typeof(bool), 33);
			AddType(typeof(bool?), 34);
			AddType(typeof(int[]), 40);
			AddType(typeof(uint[]), 41);
			AddType(typeof(short[]), 42);
			AddType(typeof(ushort[]), 43);
			AddType(typeof(byte[]), 44);
			AddType(typeof(sbyte[]), 45);
			AddType(typeof(long[]), 46);
			AddType(typeof(ulong[]), 47);
			AddType(typeof(float[]), 48);
			AddType(typeof(double[]), 49);
			AddType(typeof(decimal[]), 50);
			AddType(typeof(char[]), 51);
			AddType(typeof(bool[]), 52);
			AddType(typeof(TimeSpan), 100);
			AddType(typeof(DateTime), 101);
			AddType(typeof(Guid), 102);
			AddType(typeof(TimeSpan?), 103);
			AddType(typeof(DateTime?), 104);
			AddType(typeof(Guid?), 105);
			AddType(typeof(string), 106);
			AddType(typeof(DateTime[]), 110);
			AddType(typeof(TimeSpan[]), 111);
			AddType(typeof(Guid[]), 112);
			AddType(typeof(string[]), 113);
			AddType(typeof(object), 250);
			AddType(typeof(object[]), 251);
			AddType(typeof(Type), 252);
			AddType(typeof(Type[]), 253);
		}

		private static void GetAllFieldsOfType(Type type, HashSet<FieldInfo> fieldList)
		{
			if (!(type == null) && !(type == typeof(object)) && !(type == typeof(ValueType)))
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				for (int i = 0; i < fields.Length; i++)
				{
					fieldList.Add(fields[i]);
				}
				GetAllFieldsOfType(type.BaseType, fieldList);
			}
		}

		internal static void InsertSortedMetaData(List<ReflectedMemberInfo> list, ReflectedMemberInfo minfo)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Name.CompareTo(minfo.Name) > 0)
				{
					list.Insert(i, minfo);
					return;
				}
			}
			list.Add(minfo);
		}

		static AltSerializer()
		{
			DepthCounter = 0;
			_hashTypeInt = new Dictionary<Type, int>();
			_hashIntType = new Dictionary<int, Type>();
			_types = new Dictionary<string, Type>();
			_metaDataHash = new Dictionary<Type, ObjectMetaData>();
			_cachedTypeNames = new Dictionary<Type, string>();
			_cachedBuilder = new StringBuilder();
			_cachedDeps = new Dictionary<Type, Dictionary<string, Type>>();
			AddTypes();
		}

		internal static byte[] GetBytes(object obj, Type objectType)
		{
			if (objectType == typeof(int))
			{
				return BitConverter.GetBytes((int)obj);
			}
			if (objectType == typeof(bool))
			{
				return new byte[1] { (byte)(((bool)obj) ? 1 : 0) };
			}
			if (objectType == typeof(byte))
			{
				return new byte[1] { (byte)obj };
			}
			if (objectType == typeof(sbyte))
			{
				return new byte[1] { (byte)(sbyte)obj };
			}
			if (objectType == typeof(short))
			{
				return BitConverter.GetBytes((short)obj);
			}
			if (objectType == typeof(ushort))
			{
				return BitConverter.GetBytes((ushort)obj);
			}
			if (objectType == typeof(uint))
			{
				return BitConverter.GetBytes((uint)obj);
			}
			if (objectType == typeof(long))
			{
				return BitConverter.GetBytes((long)obj);
			}
			if (objectType == typeof(ulong))
			{
				return BitConverter.GetBytes((ulong)obj);
			}
			if (objectType == typeof(float))
			{
				return BitConverter.GetBytes((float)obj);
			}
			if (objectType == typeof(double))
			{
				return BitConverter.GetBytes((double)obj);
			}
			if (objectType == typeof(char))
			{
				return BitConverter.GetBytes((char)obj);
			}
			if (objectType == typeof(IntPtr))
			{
				throw new AltSerializeException("IntPtr type is not supported.");
			}
			if (objectType == typeof(UIntPtr))
			{
				throw new AltSerializeException("UIntPtr type is not supported.");
			}
			throw new AltSerializeException("Could not retrieve bytes from the object type " + objectType.FullName + ".");
		}

		internal static object ReadBytes(byte[] bytes, Type objectType)
		{
			if (objectType == typeof(bool))
			{
				return bytes[0] == 1;
			}
			if (objectType == typeof(byte))
			{
				return bytes[0];
			}
			if (objectType == typeof(sbyte))
			{
				return (sbyte)bytes[0];
			}
			if (objectType == typeof(short))
			{
				return BitConverter.ToInt16(bytes, 0);
			}
			if (objectType == typeof(ushort))
			{
				return BitConverter.ToUInt16(bytes, 0);
			}
			if (objectType == typeof(int))
			{
				return BitConverter.ToInt32(bytes, 0);
			}
			if (objectType == typeof(uint))
			{
				return BitConverter.ToUInt32(bytes, 0);
			}
			if (objectType == typeof(long))
			{
				return BitConverter.ToInt64(bytes, 0);
			}
			if (objectType == typeof(ulong))
			{
				return BitConverter.ToUInt64(bytes, 0);
			}
			if (objectType == typeof(float))
			{
				return BitConverter.ToSingle(bytes, 0);
			}
			if (objectType == typeof(double))
			{
				return BitConverter.ToDouble(bytes, 0);
			}
			if (objectType == typeof(char))
			{
				return BitConverter.ToChar(bytes, 0);
			}
			if (objectType == typeof(IntPtr))
			{
				throw new AltSerializeException("IntPtr type is not supported.");
			}
			throw new AltSerializeException("Could not retrieve bytes from the object type " + objectType.FullName + ".");
		}

		internal ObjectMetaData GetMetaData(Type type)
		{
			if (type == null)
			{
				throw new AltSerializeException("The serializer could not get meta data for the type.");
			}
			if (MetaDataHash.ContainsKey(type))
			{
				return MetaDataHash[type];
			}
			if (type.GetCustomAttributes(typeof(CompiledSerializerAttribute), true).Length != 0)
			{
				ObjectMetaData objectMetaData = new ObjectMetaData(this);
				objectMetaData.ObjectType = type;
				objectMetaData.DynamicSerializer = DynamicSerializerFactory.GenerateSerializer(type);
				MetaDataHash[type] = objectMetaData;
				return objectMetaData;
			}
			if (type.GetInterface(typeof(IAltSerializable).Name) != null)
			{
				ObjectMetaData objectMetaData2 = new ObjectMetaData(this);
				objectMetaData2.ObjectType = type;
				objectMetaData2.IsIAltSerializable = true;
				MetaDataHash[type] = objectMetaData2;
				return objectMetaData2;
			}
			List<ReflectedMemberInfo> list = new List<ReflectedMemberInfo>();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.GetCustomAttributes(typeof(DoNotSerializeAttribute), true).Length == 0 && propertyInfo.GetIndexParameters().Length == 0 && propertyInfo.CanRead && propertyInfo.CanWrite)
				{
					InsertSortedMetaData(list, new ReflectedMemberInfo(propertyInfo));
				}
			}
			List<ReflectedMemberInfo> list2 = new List<ReflectedMemberInfo>();
			HashSet<FieldInfo> hashSet = new HashSet<FieldInfo>();
			GetAllFieldsOfType(type, hashSet);
			foreach (FieldInfo item in hashSet)
			{
				if (!item.IsNotSerialized)
				{
					InsertSortedMetaData(list2, new ReflectedMemberInfo(item));
				}
			}
			ObjectMetaData objectMetaData3 = new ObjectMetaData(this);
			objectMetaData3.ObjectType = type;
			objectMetaData3.Fields = list2.ToArray();
			objectMetaData3.NetworkedFields = objectMetaData3.Fields.Count((ReflectedMemberInfo x) => !x.IgnoreNetwork);
			objectMetaData3.Properties = list.ToArray();
			if (type.IsGenericType)
			{
				objectMetaData3.GenericTypeDefinition = type.GetGenericTypeDefinition();
				objectMetaData3.GenericParameters = type.GetGenericArguments();
			}
			if (type.GetInterface(typeof(ISerializable).Name) != null)
			{
				objectMetaData3.IsISerializable = true;
				objectMetaData3.Extra = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[2]
				{
					typeof(SerializationInfo),
					typeof(StreamingContext)
				}, null);
			}
			if (type.GetInterface("System.Collections.IList") != null)
			{
				objectMetaData3.ImplementsIList = true;
			}
			if (type.GetInterface("System.Collections.IDictionary") != null)
			{
				objectMetaData3.ImplementsIDictionary = true;
			}
			if (objectMetaData3.GenericTypeDefinition == typeof(List<>))
			{
				objectMetaData3.IsGenericList = true;
				objectMetaData3.ImplementsIList = false;
				objectMetaData3.Extra = type.GetField("_items", BindingFlags.Instance | BindingFlags.NonPublic);
				objectMetaData3.SizeField = type.GetField("_size", BindingFlags.Instance | BindingFlags.NonPublic);
				objectMetaData3.SerializeMethod = type.GetMethod("ToArray");
			}
			if (objectMetaData3.GenericTypeDefinition == typeof(HashSet<>))
			{
				objectMetaData3.IsGenericHashSet = true;
				objectMetaData3.ImplementsIList = false;
				objectMetaData3.Extra = type.GetField("m_slots", BindingFlags.Instance | BindingFlags.NonPublic);
				objectMetaData3.SizeField = type.GetField("m_count", BindingFlags.Instance | BindingFlags.NonPublic);
				objectMetaData3.SerializeMethod = type.GetMethod("ToArray");
			}
			MetaDataHash[type] = objectMetaData3;
			return objectMetaData3;
		}

		public void SetCachedObjectID(object obj, int cacheID)
		{
			Cache.SetCachedObjectId(obj, cacheID);
		}

		private void WriteSerializationFlags(SerializedObjectFlags flags)
		{
			Stream.WriteByte((byte)flags);
		}

		private SerializedObjectFlags ReadSerializationFlags()
		{
			return (SerializedObjectFlags)Stream.ReadByte();
		}

		private void WriteType(Type objectType)
		{
			int value;
			if (_hashTypeInt.TryGetValue(objectType, out value))
			{
				WriteUInt24(0);
				Stream.WriteByte((byte)value);
			}
			else
			{
				byte[] bytes = Encoding.ASCII.GetBytes(GetTypeName(objectType));
				WriteUInt24(bytes.Length);
				Stream.Write(bytes, 0, bytes.Length);
			}
		}

		public static string GetTypeName(Type objectType)
		{
			string value;
			if (_cachedTypeNames.TryGetValue(objectType, out value))
			{
				return value;
			}
			_cachedBuilder.Clear();
			SubGetTypeName(objectType, _cachedBuilder);
			string text = _cachedBuilder.ToString();
			_cachedTypeNames[objectType] = text;
			return text;
		}

		private static Type SubGetTypeName(Type type, StringBuilder sb, bool appendNameSpace = true)
		{
			if (type.IsArray)
			{
				int arrayRank = type.GetArrayRank();
				type = SubGetTypeName(type.GetElementType(), sb, false);
				sb.Append("[");
				for (int i = 0; i < arrayRank - 1; i++)
				{
					sb.Append(",");
				}
				sb.Append("]");
			}
			else
			{
				if (type.IsNested)
				{
					Type declaringType = type.DeclaringType;
					if (string.IsNullOrEmpty(declaringType.Namespace))
					{
						sb.Append(declaringType.Name + "+" + type.Name);
					}
					else
					{
						sb.Append(declaringType.Namespace + "." + declaringType.Name + "+" + type.Name);
					}
				}
				else if (string.IsNullOrEmpty(type.Namespace))
				{
					sb.Append(type.Name);
				}
				else
				{
					sb.Append(type.Namespace + "." + type.Name);
				}
				if (type.IsGenericType)
				{
					Type[] genericArguments = type.GetGenericArguments();
					sb.Append("[");
					for (int j = 0; j < genericArguments.Length; j++)
					{
						Type type2 = genericArguments[j];
						sb.Append("[");
						SubGetTypeName(type2, sb);
						sb.Append("]");
						if (j < genericArguments.Length - 1)
						{
							sb.Append(",");
						}
					}
					sb.Append("]");
				}
			}
			if (appendNameSpace)
			{
				sb.Append(", " + type.Assembly.GetName().Name);
			}
			return type;
		}

		private Type ReadType()
		{
			int num = ReadUInt24();
			if (num == 0)
			{
				num = Stream.ReadByte();
				return _hashIntType[num];
			}
			byte[] array = new byte[num];
			Stream.Read(array, 0, num);
			string text = Encoding.ASCII.GetString(array);
			Type value;
			if (_types.TryGetValue(text, out value))
			{
				return value;
			}
			value = Type.GetType(text);
			if (value == null)
			{
				value = Type.GetType(text.Replace("[]", ""));
				if (value == null)
				{
					throw new AltSerializeException("Unable to GetType object type '" + text + "'");
				}
				value = value.MakeArrayType();
			}
			_types[text] = value;
			return value;
		}

		public AltSerializer()
			: this(new MemoryStream())
		{
		}

		public AltSerializer(byte[] bytes)
			: this(new MemoryStream(bytes))
		{
		}

		public AltSerializer(Stream stream)
		{
			InitStaticCache();
			Stream = stream;
			arrayBuffer = new byte[BlockSize];
		}

		public void Reset()
		{
			if (Stream != null)
			{
				Stream.Position = 0L;
			}
			Cache.Clear();
		}

		public void CacheObject(object cachedObject)
		{
			Cache.CacheObject(cachedObject, true);
		}

		private void CacheType(Type objType)
		{
			GetMetaData(objType);
			CacheObject(objType);
		}

		private void InitStaticCache()
		{
			Type[] array = new Type[14]
			{
				typeof(List<int>),
				typeof(List<uint>),
				typeof(List<byte>),
				typeof(List<sbyte>),
				typeof(List<short>),
				typeof(List<ushort>),
				typeof(List<long>),
				typeof(List<ulong>),
				typeof(List<DateTime>),
				typeof(List<TimeSpan>),
				typeof(List<decimal>),
				typeof(List<float>),
				typeof(List<double>),
				typeof(List<Guid>)
			};
			foreach (Type objType in array)
			{
				CacheType(objType);
			}
		}

		private void WriteUInt24(int value)
		{
			Write((byte)(value & 0xFF));
			Write((byte)((value >> 8) & 0xFF));
			Write((byte)((value >> 16) & 0xFF));
		}

		public void Write(byte val)
		{
			Stream.WriteByte(val);
		}

		public void Write(sbyte val)
		{
			Stream.WriteByte((byte)val);
		}

		public void Write(byte[] bytes, int offset, int count)
		{
			Stream.Write(bytes, offset, count);
		}

		public void Write(byte[] bytes)
		{
			Stream.Write(bytes, 0, bytes.Length);
		}

		public void Write(int value)
		{
			Stream.Write(BitConverter.GetBytes(value), 0, 4);
		}

		public void Write(uint value)
		{
			Stream.Write(BitConverter.GetBytes(value), 0, 4);
		}

		public void Write(string str)
		{
			if (str == null)
			{
				WriteUInt24(16777215);
				return;
			}
			int byteCount = Encoding.GetByteCount(str);
			WriteUInt24(byteCount);
			if (byteCount > BlockSize)
			{
				byte[] array = new byte[byteCount];
				Encoding.GetBytes(str, 0, str.Length, array, 0);
				Stream.Write(array, 0, byteCount);
			}
			else
			{
				Encoding.GetBytes(str, 0, str.Length, arrayBuffer, 0);
				Stream.Write(arrayBuffer, 0, byteCount);
			}
		}

		public void Write(short value)
		{
			Stream.WriteByte((byte)(value & 0xFF));
			Stream.WriteByte((byte)((value >> 8) & 0xFF));
		}

		public void Write(ushort value)
		{
			Stream.WriteByte((byte)(value & 0xFF));
			Stream.WriteByte((byte)((value >> 8) & 0xFF));
		}

		public void Write(long value)
		{
			Stream.Write(BitConverter.GetBytes(value), 0, 8);
		}

		public void Write(ulong value)
		{
			Stream.Write(BitConverter.GetBytes(value), 0, 8);
		}

		public void Write(DateTime value)
		{
			long value2 = value.ToBinary();
			Write(value2);
		}

		public void Write(TimeSpan value)
		{
			long ticks = value.Ticks;
			Write(ticks);
		}

		public void Write(Guid value)
		{
			Write(value.ToByteArray());
		}

		public void Write(decimal value)
		{
			int[] bits = decimal.GetBits(value);
			Write(bits[0]);
			Write(bits[1]);
			Write(bits[2]);
			Write(bits[3]);
		}

		public void Write(double value)
		{
			Stream.Write(BitConverter.GetBytes(value), 0, 8);
		}

		public void Write(float value)
		{
			Stream.Write(BitConverter.GetBytes(value), 0, 4);
		}

		public void Write(char value)
		{
			Stream.Write(BitConverter.GetBytes(value), 0, 2);
		}

		public void WriteCultureInfo(CultureInfo info)
		{
			SerializeValueType(info.LCID, typeof(int), 0);
		}

		private int ReadUInt24()
		{
			return ReadByte() + (ReadByte() << 8) + (ReadByte() << 16);
		}

		public int ReadInt32()
		{
			Stream.Read(arrayBuffer, 0, 4);
			return BitConverter.ToInt32(arrayBuffer, 0);
		}

		public uint ReadUInt32()
		{
			Stream.Read(arrayBuffer, 0, 4);
			return BitConverter.ToUInt32(arrayBuffer, 0);
		}

		public int ReadByte()
		{
			return Stream.ReadByte();
		}

		public sbyte ReadSByte()
		{
			return (sbyte)Stream.ReadByte();
		}

		public byte[] ReadBytes(int count)
		{
			byte[] array = new byte[count];
			ReadBytes(array, 0, count);
			return array;
		}

		public void ReadBytes(byte[] bytes, int offset, int count)
		{
			Stream.Read(bytes, offset, count);
		}

		public string ReadString()
		{
			int num = ReadUInt24();
			if (num == 16777215)
			{
				return null;
			}
			byte[] array = ((num <= BlockSize) ? arrayBuffer : new byte[num]);
			Stream.Read(array, 0, num);
			return Encoding.GetString(array, 0, num);
		}

		public short ReadInt16()
		{
			Stream.Read(arrayBuffer, 0, 2);
			return (short)(arrayBuffer[0] + (arrayBuffer[1] << 8));
		}

		public ushort ReadUInt16()
		{
			Stream.Read(arrayBuffer, 0, 2);
			return (ushort)(arrayBuffer[0] + (arrayBuffer[1] << 8));
		}

		public long ReadInt64()
		{
			Stream.Read(arrayBuffer, 0, 8);
			return BitConverter.ToInt64(arrayBuffer, 0);
		}

		public ulong ReadUInt64()
		{
			Stream.Read(arrayBuffer, 0, 8);
			return BitConverter.ToUInt64(arrayBuffer, 0);
		}

		public DateTime ReadDateTime()
		{
			return DateTime.FromBinary(ReadInt64());
		}

		public TimeSpan ReadTimeSpan()
		{
			return new TimeSpan(ReadInt64());
		}

		public Guid ReadGuid()
		{
			Stream.Read(guidArray, 0, 16);
			return new Guid(guidArray);
		}

		public char ReadChar()
		{
			Stream.Read(arrayBuffer, 0, 2);
			return BitConverter.ToChar(arrayBuffer, 0);
		}

		public decimal ReadDecimal()
		{
			return new decimal(new int[4]
			{
				ReadInt32(),
				ReadInt32(),
				ReadInt32(),
				ReadInt32()
			});
		}

		public double ReadDouble()
		{
			Stream.Read(arrayBuffer, 0, 8);
			return BitConverter.ToDouble(arrayBuffer, 0);
		}

		public float ReadSingle()
		{
			Stream.Read(arrayBuffer, 0, 4);
			return BitConverter.ToSingle(arrayBuffer, 0);
		}

		public CultureInfo ReadCultureInfo()
		{
			return CultureInfo.GetCultureInfo((int)DeserializeValueType(typeof(int), -1));
		}

		private static Dictionary<string, Type> CheckDeprecations(Type type)
		{
			Dictionary<string, Type> value;
			if (_cachedDeps.TryGetValue(type, out value))
			{
				return value;
			}
			value = null;
			object[] customAttributes = type.GetCustomAttributes(typeof(AltDeprecate), true);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				AltDeprecate altDeprecate = (AltDeprecate)customAttributes[i];
				if (value == null)
				{
					value = new Dictionary<string, Type>();
				}
				value[altDeprecate.Name] = altDeprecate.type;
			}
			_cachedDeps[type] = value;
			return value;
		}

		private object DeserializeValueType(Type objectType, int convertFloats)
		{
			if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				if ((bool)Deserialize())
				{
					Type type = objectType.GetGenericArguments()[0];
					return objectType.GetConstructor(new Type[1] { type }).Invoke(new object[1] { Deserialize() });
				}
				return null;
			}
			if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(KeyValuePair<, >))
			{
				Type[] array = new Type[2]
				{
					(Type)Deserialize(),
					(Type)Deserialize()
				};
				if (ShouldConvert(convertFloats))
				{
					array = objectType.GenericTypeArguments;
				}
				object obj = DoConversion(Deserialize(null, convertFloats), convertFloats, array[0]);
				object obj2 = DoConversion(Deserialize(null, convertFloats), convertFloats, array[1]);
				return typeof(KeyValuePair<, >).MakeGenericType(array).GetConstructor(array).Invoke(new object[2] { obj, obj2 });
			}
			if (objectType.IsPrimitive)
			{
				int num = Marshal.SizeOf(objectType);
				if (objectType == typeof(char))
				{
					num = 2;
				}
				if (objectType == typeof(bool))
				{
					num = 1;
				}
				byte[] array2 = new byte[num];
				Stream.Read(array2, 0, num);
				return ReadBytes(array2, objectType);
			}
			if (objectType == typeof(DateTime))
			{
				return DateTime.FromBinary(ReadInt64());
			}
			if (objectType == typeof(TimeSpan))
			{
				return TimeSpan.FromTicks(ReadInt64());
			}
			if (objectType == typeof(decimal))
			{
				return new decimal(new int[4]
				{
					ReadInt32(),
					ReadInt32(),
					ReadInt32(),
					ReadInt32()
				});
			}
			if (objectType == typeof(Guid))
			{
				byte[] array3 = new byte[16];
				Stream.Read(array3, 0, 16);
				return new Guid(array3);
			}
			if (objectType.IsEnum)
			{
				Type underlyingType = Enum.GetUnderlyingType(objectType);
				object value = Deserialize(underlyingType, -1);
				return Enum.ToObject(objectType, value);
			}
			if (objectType.IsValueType && !objectType.IsPrimitive && (objectType.Namespace == null || !objectType.Namespace.StartsWith("System")))
			{
				return DeserializeComplexType(objectType, -1, convertFloats);
			}
			int num2 = Marshal.SizeOf(objectType);
			IntPtr intPtr = Marshal.AllocHGlobal(num2);
			Marshal.Copy(ReadBytes(num2), 0, intPtr, num2);
			object result = Marshal.PtrToStructure(intPtr, objectType);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		private object DeserializeByteArray()
		{
			int num = ReadInt32();
			byte[] array = new byte[num];
			ReadBytes(array, 0, num);
			return array;
		}

		private object DeserializeValueTypeArray(Type baseType, int convertFloats)
		{
			bool convert;
			baseType = CheckFloatConversion(baseType, convertFloats, out convert);
			int num = Marshal.SizeOf(baseType);
			if (baseType == typeof(char))
			{
				num = 2;
			}
			else if (baseType == typeof(bool))
			{
				num = 1;
			}
			int num2 = ReadInt32();
			int i = 0;
			Array array = Array.CreateInstance(baseType, num2);
			int num4;
			for (int num3 = num2 * num; i < num3; i += num4)
			{
				num4 = BlockSize;
				if (i + num4 > num3)
				{
					num4 = num3 - i;
				}
				Stream.Read(arrayBuffer, 0, num4);
				Buffer.BlockCopy(arrayBuffer, 0, array, i, num4);
			}
			if (convert)
			{
				return ((float[])array).ToDoubles();
			}
			return array;
		}

		private object DeserializeArray(Type objectType, int cacheID, int convertFloats)
		{
			int num = ReadByte();
			Type elementType = objectType.GetElementType();
			if (elementType.IsPrimitive && num == 1)
			{
				if (elementType == typeof(byte))
				{
					object obj = DeserializeByteArray();
					if (cacheID > 0)
					{
						Cache.SetCachedObjectId(obj, cacheID);
					}
					return obj;
				}
				object obj2 = DeserializeValueTypeArray(elementType, convertFloats);
				if (cacheID > 0)
				{
					Cache.SetCachedObjectId(obj2, cacheID);
				}
				return obj2;
			}
			int[] array = new int[num];
			int num2 = 1;
			for (int i = 0; i < num; i++)
			{
				array[i] = ReadInt32();
				num2 *= array[i];
			}
			Array array2 = Array.CreateInstance(elementType, array);
			if (cacheID > 0)
			{
				Cache.SetCachedObjectId(array2, cacheID);
			}
			int[] array3 = new int[num];
			for (int j = 0; j < num2; j++)
			{
				object value = DeserializeElement(elementType, convertFloats);
				try
				{
					array2.SetValue(value, array3);
				}
				catch (InvalidCastException message)
				{
					Debug.Log(message);
					throw;
				}
				array3[array3.Length - 1]++;
				for (int num3 = array3.Length - 1; num3 >= 0; num3--)
				{
					if (array3[num3] >= array[num3] && num3 > 0)
					{
						array3[num3] = 0;
						array3[num3 - 1]++;
					}
				}
			}
			return array2;
		}

		private object DeserializeElement(Type elementType, int convertFloats)
		{
			Type objectType = CheckFloatConversion(elementType, convertFloats);
			if (elementType.IsPrimitive)
			{
				return DoConversion(DeserializeValueType(objectType, convertFloats), convertFloats, elementType);
			}
			if ((elementType.IsClass && !elementType.IsSealed) || elementType.IsAbstract || elementType.IsInterface)
			{
				return Deserialize(ShouldConvert(convertFloats) ? elementType : null, convertFloats);
			}
			return DoConversion(Deserialize(objectType, convertFloats), convertFloats, elementType);
		}

		private object DeserializeList(Type objectType, int cacheID, ObjectMetaData metaData, int convertFloats)
		{
			int num = ReadInt32();
			IList list = Activator.CreateInstance(objectType) as IList;
			if (cacheID > 0)
			{
				Cache.SetCachedObjectId(list, cacheID);
			}
			Type type = typeof(object);
			if (metaData.GenericParameters != null && metaData.GenericParameters.Length != 0)
			{
				type = metaData.GenericParameters[0];
			}
			for (int i = 0; i < num; i++)
			{
				object value = DoConversion(DeserializeElement(type, -1), convertFloats, type);
				list.Add(value);
			}
			return list;
		}

		private object DeserializeDictionary(Type objectType, int cacheID, int convertFloats)
		{
			Type[] genericArguments = objectType.GetGenericArguments();
			int num = (int)Deserialize(typeof(int), -1);
			IDictionary dictionary = Activator.CreateInstance(objectType) as IDictionary;
			if (cacheID > 0)
			{
				Cache.SetCachedObjectId(dictionary, cacheID);
			}
			Type elementType = typeof(object);
			Type elementType2 = typeof(object);
			if (genericArguments.Length != 0)
			{
				elementType = genericArguments[0];
				elementType2 = genericArguments[1];
			}
			for (int i = 0; i < num; i++)
			{
				object key = DeserializeElement(elementType, convertFloats);
				object value = DeserializeElement(elementType2, convertFloats);
				dictionary[key] = value;
			}
			return dictionary;
		}

		private bool ShouldConvert(int convertFloats)
		{
			if (ConvertFloats >= 0 && convertFloats >= 0)
			{
				return convertFloats >= ConvertFloats;
			}
			return false;
		}

		private Type CheckFloatConversion(Type input, int convertFloats)
		{
			if (!ShouldConvert(convertFloats) || !(input == typeof(double)))
			{
				return input;
			}
			return typeof(float);
		}

		private Type CheckFloatConversion(Type input, int convertFloats, out bool convert)
		{
			if (ShouldConvert(convertFloats) && input == typeof(double))
			{
				convert = true;
				return typeof(float);
			}
			convert = false;
			return input;
		}

		private object DoConversion(object input, int convert, Type type)
		{
			if (ShouldConvert(convert) && type == typeof(double))
			{
				return (double)(float)input;
			}
			return input;
		}

		private object DeserializeComplexType(Type objectType, int cacheID, int convertFloats)
		{
			ObjectMetaData metaData = GetMetaData(objectType);
			if (metaData.DynamicSerializer != null)
			{
				return metaData.DynamicSerializer.Deserialize(this, cacheID);
			}
			if (metaData.IsIAltSerializable)
			{
				object obj = Activator.CreateInstance(objectType);
				obj = ((IAltSerializable)obj).Deserialize(this);
				if (cacheID > 0)
				{
					Cache.SetCachedObjectId(obj, cacheID);
				}
				return obj;
			}
			if (metaData.ImplementsIDictionary)
			{
				return DeserializeDictionary(objectType, cacheID, convertFloats);
			}
			if (metaData.ImplementsIList)
			{
				return DeserializeList(objectType, cacheID, metaData, convertFloats);
			}
			if (metaData.IsGenericList || metaData.IsGenericHashSet)
			{
				Type objectType2 = metaData.GenericParameters[0].MakeArrayType();
				object obj2 = DeserializeArray(objectType2, 0, convertFloats);
				object obj3 = Activator.CreateInstance(objectType, obj2);
				if (cacheID > 0)
				{
					Cache.SetCachedObjectId(obj3, cacheID);
				}
				return obj3;
			}
			if (metaData.IsISerializable)
			{
				SerializationInfo serializationInfo = new SerializationInfo(objectType, new AltFormatter());
				StreamingContext streamingContext = new StreamingContext(StreamingContextStates.All);
				foreach (KeyValuePair<string, object> item in (Dictionary<string, object>)Deserialize(typeof(Dictionary<string, object>), convertFloats))
				{
					serializationInfo.AddValue(item.Key, item.Value);
				}
				return ((ConstructorInfo)metaData.Extra).Invoke(new object[2] { serializationInfo, streamingContext });
			}
			object obj4 = Activator.CreateInstance(objectType);
			if (cacheID > 0)
			{
				Cache.SetCachedObjectId(obj4, cacheID);
			}
			if (SerializePropertyNames)
			{
				Dictionary<string, Type> dictionary = CheckDeprecations(metaData.ObjectType);
				int num = ReadInt32();
				for (int i = 0; i < num; i++)
				{
					string text = ReadString();
					Type value;
					if (dictionary != null && text != null && dictionary.TryGetValue(text, out value))
					{
						DeserializeElement(value, convertFloats);
						continue;
					}
					ReflectedMemberInfo reflectedMemberInfo = metaData.FindMemberInfoByName(text);
					if (reflectedMemberInfo == null)
					{
						bool flag = false;
						for (int j = 0; j < metaData.Fields.Length; j++)
						{
							ReflectedMemberInfo reflectedMemberInfo2 = metaData.Fields[j];
							NameRedirection customAttribute = reflectedMemberInfo2.Field.GetCustomAttribute<NameRedirection>();
							if (customAttribute != null && customAttribute.OldNames.Contains(text))
							{
								object newValue = DeserializeElement(reflectedMemberInfo2.FieldType, convertFloats);
								reflectedMemberInfo2.SetValue(obj4, newValue);
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							throw new AltSerializeException("Unable to find the property '" + text + "' in object type '" + objectType.FullName + "'.");
						}
					}
					else
					{
						if (reflectedMemberInfo.NonSerialized)
						{
							continue;
						}
						int convertFloats2 = -1;
						if (ConvertFloats >= 0)
						{
							AltWasFloat customAttribute2 = reflectedMemberInfo.Field.GetCustomAttribute<AltWasFloat>();
							if (customAttribute2 != null)
							{
								convertFloats2 = customAttribute2.Version;
							}
						}
						object newValue2 = DeserializeElement(reflectedMemberInfo.FieldType, convertFloats2);
						reflectedMemberInfo.SetValue(obj4, newValue2);
					}
				}
			}
			else
			{
				ReflectedMemberInfo[] values = metaData.Values;
				foreach (ReflectedMemberInfo reflectedMemberInfo3 in values)
				{
					if (SerializeProperties || reflectedMemberInfo3.FieldType.IsSerializable)
					{
						object newValue3 = DeserializeElement(reflectedMemberInfo3.FieldType, convertFloats);
						reflectedMemberInfo3.SetValue(obj4, newValue3);
					}
				}
			}
			return obj4;
		}

		public object Deserialize()
		{
			return Deserialize(null, -1);
		}

		public object Deserialize(Type objectType, int convertFloats)
		{
			SerializedObjectFlags serializedObjectFlags = SerializedObjectFlags.Invalid;
			int num = 0;
			serializedObjectFlags = ReadSerializationFlags();
			if (serializedObjectFlags == SerializedObjectFlags.IsNull)
			{
				return null;
			}
			if ((serializedObjectFlags & SerializedObjectFlags.CachedItem) != SerializedObjectFlags.None)
			{
				num = ReadInt32();
				return Cache.GetCachedObject(num);
			}
			if ((serializedObjectFlags & SerializedObjectFlags.SetCache) != SerializedObjectFlags.None)
			{
				num = ReadInt32();
			}
			if ((serializedObjectFlags & SerializedObjectFlags.SystemType) != SerializedObjectFlags.None)
			{
				int key = Stream.ReadByte();
				if (!_hashIntType.TryGetValue(key, out objectType))
				{
					throw new AltSerializeException("Unknown data type encountered in stream.");
				}
			}
			if ((serializedObjectFlags & SerializedObjectFlags.Type) != SerializedObjectFlags.None)
			{
				if (ShouldConvert(convertFloats) && objectType != null)
				{
					Deserialize(typeof(Type), convertFloats);
				}
				else
				{
					objectType = (Type)Deserialize(typeof(Type), convertFloats);
				}
			}
			if (objectType == null)
			{
				throw new AltSerializeException("Object type was null, probably corrupt file");
			}
			if (objectType.IsValueType)
			{
				return DoConversion(DeserializeValueType(CheckFloatConversion(objectType, convertFloats), convertFloats), convertFloats, objectType);
			}
			object obj = null;
			if (objectType.IsArray)
			{
				obj = DeserializeArray(objectType, num, convertFloats);
				num = 0;
			}
			else if (objectType == typeof(string))
			{
				obj = ReadString();
			}
			else if (objectType.IsInstanceOfType(typeof(Type)))
			{
				obj = ReadType();
			}
			else if (objectType == typeof(CultureInfo))
			{
				obj = ReadCultureInfo();
			}
			else
			{
				obj = DeserializeComplexType(objectType, num, convertFloats);
				num = 0;
			}
			if (num > 0)
			{
				Cache.SetCachedObjectId(obj, num);
			}
			return obj;
		}

		private void SerializeValueType(object obj, Type objectType, int depth)
		{
			if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				bool flag = (bool)objectType.GetProperty("HasValue").GetValue(obj, null);
				Serialize(flag, depth);
				if (flag)
				{
					Serialize(objectType.GetProperty("Value").GetValue(obj, null), depth);
				}
			}
			else if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(KeyValuePair<, >))
			{
				Type[] genericArguments = objectType.GetGenericArguments();
				Serialize(genericArguments[0], depth);
				Serialize(genericArguments[1], depth);
				Serialize(objectType.GetProperty("Key").GetValue(obj, null), depth);
				Serialize(objectType.GetProperty("Value").GetValue(obj, null), depth);
			}
			else if (objectType.IsPrimitive)
			{
				byte[] bytes = GetBytes(obj, objectType);
				Stream.Write(bytes, 0, bytes.Length);
			}
			else if (objectType == typeof(DateTime))
			{
				Write(((DateTime)obj).ToBinary());
			}
			else if (objectType == typeof(TimeSpan))
			{
				Write(((TimeSpan)obj).Ticks);
			}
			else if (objectType == typeof(Guid))
			{
				byte[] buffer = ((Guid)obj).ToByteArray();
				Stream.Write(buffer, 0, 16);
			}
			else if (objectType.IsEnum)
			{
				Type underlyingType = Enum.GetUnderlyingType(objectType);
				object obj2 = Convert.ChangeType(obj, underlyingType);
				Serialize(obj2, underlyingType, depth);
			}
			else if (objectType == typeof(decimal))
			{
				int[] bits = decimal.GetBits((decimal)obj);
				Write(bits[0]);
				Write(bits[1]);
				Write(bits[2]);
				Write(bits[3]);
			}
			else if (objectType.IsValueType && !objectType.IsPrimitive && (objectType.Namespace == null || !objectType.Namespace.StartsWith("System")))
			{
				SerializeComplexType(obj, objectType, depth);
			}
			else
			{
				int num = Marshal.SizeOf(objectType);
				byte[] array = new byte[num];
				IntPtr intPtr = Marshal.AllocHGlobal(num);
				Marshal.StructureToPtr(obj, intPtr, false);
				Marshal.Copy(intPtr, array, 0, num);
				Write(array, 0, array.Length);
				Marshal.FreeHGlobal(intPtr);
			}
		}

		private void SerializeValueTypeArray(Array array, Type baseType, int count)
		{
			int num = Marshal.SizeOf(baseType);
			if (baseType == typeof(bool))
			{
				num = 1;
			}
			else if (baseType == typeof(char))
			{
				num = 2;
			}
			Write(count);
			int num2 = count * num;
			int num3;
			for (int i = 0; i < num2; i += num3)
			{
				num3 = BlockSize;
				if (i + BlockSize > num2)
				{
					num3 = num2 - i;
				}
				Buffer.BlockCopy(array, i, arrayBuffer, 0, num3);
				Stream.Write(arrayBuffer, 0, num3);
			}
		}

		private void SerializeByteArray(object array, int count)
		{
			byte[] bytes = (byte[])array;
			Write(count);
			Write(bytes, 0, count);
		}

		private void SerializeArray(object obj, Type objectType, int count, int depth)
		{
			Array array = obj as Array;
			if (array == null)
			{
				WriteSerializationFlags(SerializedObjectFlags.IsNull);
				Debug.LogException(new Exception("Failed serializing array: " + ((obj != null) ? obj.GetType().Name : "null")));
				return;
			}
			if (objectType == null)
			{
				objectType = obj.GetType().GetElementType();
			}
			Write((byte)array.Rank);
			if (count < 0)
			{
				count = array.Length;
			}
			Type type = objectType;
			if (array.Rank == 1 && type.IsPrimitive)
			{
				if (type == typeof(byte))
				{
					SerializeByteArray(obj, count);
				}
				else
				{
					SerializeValueTypeArray(array, type, count);
				}
				return;
			}
			int[] array2 = new int[array.Rank];
			if (array.Rank == 1)
			{
				Write(count);
			}
			else
			{
				for (int i = 0; i < array.Rank; i++)
				{
					array2[i] = array.GetLength(i);
					Write(array2[i]);
				}
			}
			int[] array3 = new int[array.Rank];
			for (int j = 0; j < count; j++)
			{
				object value = array.GetValue(array3);
				SerializeElement(value, type, depth + 1);
				array3[array3.Length - 1]++;
				for (int num = array3.Length - 1; num >= 0; num--)
				{
					if (array3[num] >= array2[num] && num > 0)
					{
						array3[num] = 0;
						array3[num - 1]++;
					}
				}
			}
		}

		private void SerializeElement(object obj, Type elementType, int depth)
		{
			if (elementType.IsPrimitive)
			{
				SerializeValueType(obj, elementType, depth);
			}
			else if ((elementType.IsClass && !elementType.IsSealed) || elementType.IsAbstract || elementType.IsInterface)
			{
				Serialize(obj, depth);
			}
			else
			{
				Serialize(obj, elementType, depth);
			}
		}

		private void SerializeList(object genericObject, Type objectType, ObjectMetaData metaData, int depth)
		{
			IList list = genericObject as IList;
			if (list == null)
			{
				throw new AltSerializeException("The object type " + objectType.FullName + " does not implement IList.");
			}
			IEnumerator enumerator = list.GetEnumerator();
			Write(list.Count);
			while (enumerator.MoveNext())
			{
				SerializeElement(enumerator.Current, objectType, depth + 1);
			}
		}

		private void SerializeDictionary(object genericObject, Type objectType, int depth)
		{
			Type[] genericArguments = objectType.GetGenericArguments();
			IDictionary dictionary = genericObject as IDictionary;
			if (dictionary == null)
			{
				throw new AltSerializeException("The object type " + objectType.FullName + " does not implement IDictionary.");
			}
			IDictionaryEnumerator enumerator = dictionary.GetEnumerator();
			Type elementType = typeof(object);
			Type elementType2 = typeof(object);
			if (genericArguments.Length != 0)
			{
				elementType = genericArguments[0];
				elementType2 = genericArguments[1];
			}
			Serialize(dictionary.Count, typeof(int), depth + 1);
			while (enumerator.MoveNext())
			{
				SerializeElement(enumerator.Key, elementType, depth + 1);
				SerializeElement(enumerator.Value, elementType2, depth + 1);
			}
		}

		private void SerializeComplexType(object obj, Type objectType, int depth)
		{
			ObjectMetaData metaData = GetMetaData(objectType);
			if (metaData.DynamicSerializer != null)
			{
				metaData.DynamicSerializer.Serialize(obj, this);
				return;
			}
			if (metaData.IsIAltSerializable)
			{
				((IAltSerializable)obj).Serialize(this, depth);
				return;
			}
			if (metaData.ImplementsIDictionary)
			{
				SerializeDictionary(obj, objectType, depth);
				return;
			}
			if (metaData.ImplementsIList)
			{
				SerializeList(obj, objectType, metaData, depth);
				return;
			}
			if (metaData.IsGenericHashSet || metaData.IsGenericList)
			{
				int count;
				Array obj2 = ((IEnumerable)obj).ToArray(metaData.GenericParameters[0], out count);
				SerializeArray(obj2, metaData.GenericParameters[0], count, depth);
				return;
			}
			if (metaData.IsISerializable)
			{
				SerializationInfo serializationInfo = new SerializationInfo(objectType, new AltFormatter());
				StreamingContext context = new StreamingContext(StreamingContextStates.All);
				((ISerializable)obj).GetObjectData(serializationInfo, context);
				SerializationInfoEnumerator enumerator = serializationInfo.GetEnumerator();
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				while (enumerator.MoveNext())
				{
					dictionary[enumerator.Name] = enumerator.Value;
				}
				Serialize(dictionary, typeof(Dictionary<string, object>), depth);
				return;
			}
			if (SerializePropertyNames)
			{
				Write(NetworkMode ? metaData.NetworkedFields : metaData.Values.Length);
			}
			ReflectedMemberInfo[] values = metaData.Values;
			foreach (ReflectedMemberInfo reflectedMemberInfo in values)
			{
				if (!NetworkMode || !reflectedMemberInfo.IgnoreNetwork)
				{
					object value = reflectedMemberInfo.GetValue(obj);
					if (SerializePropertyNames)
					{
						Write(reflectedMemberInfo.Name);
					}
					if (SerializeProperties || !reflectedMemberInfo.NonSerialized)
					{
						SerializeElement(value, reflectedMemberInfo.FieldType, depth + 1);
					}
				}
			}
		}

		public void Serialize(object obj, int depth)
		{
			Serialize(obj, null, depth);
		}

		public void Serialize(object obj, Type objectType, int depth)
		{
			if (obj == null)
			{
				WriteSerializationFlags(SerializedObjectFlags.IsNull);
				return;
			}
			DepthCounter = Math.Max(depth, DepthCounter);
			SerializedObjectFlags serializedObjectFlags = SerializedObjectFlags.None;
			int value = 0;
			bool flag = true;
			if (objectType == null)
			{
				objectType = obj.GetType();
				if (objectType.BaseType == typeof(Type))
				{
					serializedObjectFlags = SerializedObjectFlags.SystemType;
					objectType = typeof(Type);
				}
				else if (objectType == typeof(string))
				{
					serializedObjectFlags = SerializedObjectFlags.SystemType;
				}
				else if (_hashTypeInt.ContainsKey(objectType))
				{
					serializedObjectFlags = SerializedObjectFlags.SystemType;
					flag = false;
				}
				else
				{
					serializedObjectFlags = SerializedObjectFlags.Type;
				}
			}
			if (objectType == typeof(EventHandler) || (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(EventHandler<>)))
			{
				WriteSerializationFlags(SerializedObjectFlags.IsNull);
				return;
			}
			IAltSerializable altSerializable;
			if ((altSerializable = obj as IAltSerializable) != null)
			{
				flag = altSerializable.CanCache;
			}
			if (CacheEnabled && flag && !objectType.IsEnum && !objectType.IsValueType)
			{
				serializedObjectFlags |= SerializedObjectFlags.SetCache;
				value = Cache.GetObjectCacheID(obj, objectType);
				if (value != 0)
				{
					WriteSerializationFlags(SerializedObjectFlags.CachedItem);
					Write(value);
					return;
				}
				value = Cache.CacheObject(obj, false);
			}
			WriteSerializationFlags(serializedObjectFlags);
			if ((serializedObjectFlags & SerializedObjectFlags.SetCache) != SerializedObjectFlags.None)
			{
				Write(value);
			}
			if ((serializedObjectFlags & SerializedObjectFlags.SystemType) != SerializedObjectFlags.None)
			{
				try
				{
					Write((byte)_hashTypeInt[objectType]);
				}
				catch (Exception)
				{
					throw new Exception("Trying to write system type, but it does not exist in map: " + objectType.FullName);
				}
			}
			if ((serializedObjectFlags & SerializedObjectFlags.Type) != SerializedObjectFlags.None)
			{
				Serialize(objectType, typeof(Type), depth);
			}
			if (objectType.IsValueType)
			{
				SerializeValueType(obj, objectType, depth);
			}
			else if (objectType.IsArray)
			{
				SerializeArray(obj, null, -1, depth);
			}
			else if (objectType == typeof(string))
			{
				Write(obj.ToString());
			}
			else if (objectType.IsInstanceOfType(typeof(Type)))
			{
				WriteType(obj as Type);
			}
			else if (objectType == typeof(CultureInfo))
			{
				WriteCultureInfo(obj as CultureInfo);
			}
			else
			{
				SerializeComplexType(obj, objectType, depth);
			}
		}
	}
}
