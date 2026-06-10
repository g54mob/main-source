using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace NSMedieval.Serialization
{
	public class FVDeserializer
	{
		private Dictionary<string, FVBinaryReader> readers = new Dictionary<string, FVBinaryReader>();

		private readonly FVBinaryReader defaultReader;

		private FVBinaryReader currentReader;

		private Stack<FVBinaryReader> readerStack = new Stack<FVBinaryReader>();

		private readonly Dictionary<int, IFVSerializable> deserializedObjects = new Dictionary<int, IFVSerializable>();

		private Dictionary<int, IFVSerializable> referenceObjects = new Dictionary<int, IFVSerializable>();

		private Dictionary<int, FVSerializationReference> referencePositions = new Dictionary<int, FVSerializationReference>();

		private Dictionary<string, object> temporaryData = new Dictionary<string, object>();

		private Dictionary<IFVSerializable, IFVSerializable> migratedObjects = new Dictionary<IFVSerializable, IFVSerializable>();

		public FVDeserializer(string defaultReaderId, byte[] data)
		{
			FVBinaryReader value = new FVBinaryReader(defaultReaderId, data);
			readers.Add(defaultReaderId, value);
			currentReader = value;
			defaultReader = value;
		}

		public void ReadReferences(byte[] data)
		{
			using MemoryStream input = new MemoryStream(data);
			using BinaryReader binaryReader = new BinaryReader(input);
			int num = binaryReader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int num2 = binaryReader.ReadInt32();
				string id = binaryReader.ReadString();
				long position = binaryReader.ReadInt64();
				referencePositions.Add(num2, new FVSerializationReference(num2, id, position));
			}
		}

		public void AddReader(string readerId, byte[] data)
		{
			FVBinaryReader value = new FVBinaryReader(readerId, data);
			readers.Add(readerId, value);
		}

		public bool ChangeReader(string id)
		{
			if (!readers.ContainsKey(id))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\FVDeserializer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("FVDeserializer: Reader ");
					messageBuilder.AppendFormatted(id);
					messageBuilder.AppendLiteral(" couldn't be found!");
				}
				Log.Warning(messageBuilder);
				return false;
			}
			if (id.Equals(currentReader.GetId()))
			{
				return false;
			}
			readerStack.Push(currentReader);
			currentReader = readers[id];
			return true;
		}

		public void SetDefaultReader()
		{
			currentReader = defaultReader;
			readerStack.Clear();
		}

		public void PopBackReader()
		{
			if (readerStack.Count != 0)
			{
				currentReader = readerStack.Pop();
			}
		}

		public void AddMigratedObject(IFVSerializable oldObject, IFVSerializable newObject)
		{
			migratedObjects.Add(oldObject, newObject);
		}

		public void AddTempData(string key, object obj)
		{
			temporaryData.Add(key, obj);
		}

		public void ReplaceOrAddTempData(string key, object obj)
		{
			if (temporaryData.ContainsKey(key))
			{
				temporaryData[key] = obj;
			}
			else
			{
				temporaryData.Add(key, obj);
			}
		}

		public object GetTempData(string key)
		{
			if (!temporaryData.ContainsKey(key))
			{
				return null;
			}
			return temporaryData[key];
		}

		public object TryGetTempData(string key, object defaultObj = null)
		{
			if (!temporaryData.ContainsKey(key))
			{
				return defaultObj;
			}
			return temporaryData[key];
		}

		public object RemoveTempData(string key)
		{
			if (!temporaryData.ContainsKey(key))
			{
				return null;
			}
			return temporaryData.Remove(key);
		}

		public void ClearTempData()
		{
			temporaryData.Clear();
		}

		public bool HasTempData()
		{
			if (temporaryData != null)
			{
				return temporaryData.Count > 0;
			}
			return false;
		}

		public bool HasTempDataKey(string key)
		{
			if (temporaryData != null)
			{
				return temporaryData.ContainsKey(key);
			}
			return false;
		}

		public bool ContainsKey(string key)
		{
			int hashCode = key.GetHashCode();
			return currentReader.CurrentMap.ContainsKey(hashCode);
		}

		public byte ReadByte(string key, byte defaultValue = 0)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadByte();
			}
			return defaultValue;
		}

		public bool ReadBool(string key, bool defaultValue = false)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadBoolean();
			}
			return defaultValue;
		}

		public int ReadInt(string key, int defaultValue = 0)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadInt32();
			}
			return defaultValue;
		}

		public T ReadEnum<T>(string key, T defaultValue = default(T)) where T : struct, Enum
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return (T)Enum.ToObject(typeof(T), currentReader.Reader.ReadInt32());
			}
			return defaultValue;
		}

		public short ReadShort(string key, short defaultValue = 0)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadInt16();
			}
			return defaultValue;
		}

		public uint ReadUInt(string key, uint defaultValue = 0u)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadUInt32();
			}
			return defaultValue;
		}

		public ushort ReadUShort(string key, ushort defaultValue = 0)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadUInt16();
			}
			return defaultValue;
		}

		public long ReadLong(string key, long defaultValue = 0L)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadInt64();
			}
			return defaultValue;
		}

		public float ReadFloat(string key, float defaultValue = 0f)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadSingle();
			}
			return defaultValue;
		}

		public double ReadDouble(string key, double defaultValue = 0.0)
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return currentReader.Reader.ReadDouble();
			}
			return defaultValue;
		}

		public string ReadString(string key, string defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			if (!ReadIsNull())
			{
				return currentReader.Reader.ReadString();
			}
			return null;
		}

		public int? ReadNullableInt(string key, int? defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			if (!ReadIsNull())
			{
				return currentReader.Reader.ReadInt32();
			}
			return null;
		}

		public SerializableVector2Int ReadVec2Int(string key, SerializableVector2Int defaultValue = default(SerializableVector2Int))
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return new SerializableVector2Int(currentReader.Reader.ReadInt32(), currentReader.Reader.ReadInt32());
			}
			return defaultValue;
		}

		public Vec3Int ReadVec3Int(string key, Vec3Int defaultValue = default(Vec3Int))
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return new Vec3Int(currentReader.Reader.ReadInt32(), currentReader.Reader.ReadInt32(), currentReader.Reader.ReadInt32());
			}
			return defaultValue;
		}

		public Vector2 ReadVector2(string key, Vector2 defaultValue = default(Vector2))
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return new Vector2(currentReader.Reader.ReadSingle(), currentReader.Reader.ReadSingle());
			}
			return defaultValue;
		}

		public Vector3 ReadVector3(string key, Vector3 defaultValue = default(Vector3))
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return new Vector3(currentReader.Reader.ReadSingle(), currentReader.Reader.ReadSingle(), currentReader.Reader.ReadSingle());
			}
			return defaultValue;
		}

		public Color ReadColor(string key, Color defaultValue = default(Color))
		{
			if (currentReader.SeekBufferToKey(key))
			{
				return new Color(currentReader.Reader.ReadSingle(), currentReader.Reader.ReadSingle(), currentReader.Reader.ReadSingle(), currentReader.Reader.ReadSingle());
			}
			return defaultValue;
		}

		public T ReadObject<T>(string key, T defaultValue = default(T)) where T : IFVSerializable
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			bool num = currentReader.CreateMap(key);
			T result = ReadObject<T>();
			if (num)
			{
				currentReader.ReleaseMap();
			}
			return result;
		}

		private T ReadObject<T>() where T : IFVSerializable
		{
			if (ReadIsNull())
			{
				return default(T);
			}
			bool flag = currentReader.Reader.ReadBoolean();
			int key = currentReader.Reader.ReadInt32();
			bool flag2 = false;
			if (deserializedObjects.TryGetValue(key, out var value))
			{
				if (value is IFVMigrated && migratedObjects.TryGetValue(value, out var value2))
				{
					return (T)value2;
				}
				return (T)value;
			}
			if (flag)
			{
				if (!referencePositions.TryGetValue(key, out var value3))
				{
					throw new Exception("Broken reference detected!");
				}
				flag2 = ChangeReader(value3.BufferId);
				currentReader.CreateMapForReference(value3.BufferPosition);
				currentReader.SeekBuffer(value3.BufferPosition);
			}
			IFVSerializable iFVSerializable = (IFVSerializable)ReadType<T>().Invoke(new object[1] { this });
			if (iFVSerializable is IFVMigrated)
			{
				if (!migratedObjects.TryGetValue(iFVSerializable, out var value4))
				{
					if (flag)
					{
						currentReader.ReleaseMap();
					}
					if (flag2)
					{
						PopBackReader();
					}
					return default(T);
				}
				iFVSerializable = (T)value4;
			}
			deserializedObjects.Add(key, iFVSerializable);
			if (flag)
			{
				currentReader.ReleaseMap();
			}
			if (flag2)
			{
				PopBackReader();
			}
			return (T)iFVSerializable;
		}

		private ConstructorInfo ReadType<T>()
		{
			int hash = currentReader.Reader.ReadInt32();
			ConstructorInfo byID = FVSerilizableConstructorMap.Instance.GetByID(hash);
			if (byID == null)
			{
				throw new Exception("FVDeserializer: ReadObject " + typeof(T).FullName + " Missing constructor.");
			}
			return byID;
		}

		private bool ReadIsNull()
		{
			return currentReader.Reader.ReadBoolean();
		}

		public List<T> ReadObjectList<T>(string key, List<T> defaultValue = null) where T : IFVSerializable
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new List<T>();
			case -1:
				return null;
			default:
			{
				bool flag = currentReader.CreateMap(key);
				List<T> list = new List<T>();
				for (int i = 0; i < num; i++)
				{
					list.Add(ReadObject<T>($"{key}{i}"));
				}
				if (flag)
				{
					currentReader.ReleaseMap();
				}
				return list;
			}
			}
		}

		public List<T> ReadEnumList<T>(string key, List<T> defaultValue = null) where T : struct, Enum
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new List<T>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				List<T> list = new List<T>();
				for (int i = 0; i < num; i++)
				{
					int value = reader.ReadInt32();
					T item = (T)Enum.ToObject(typeof(T), value);
					list.Add(item);
				}
				return list;
			}
			}
		}

		public List<long> ReadLongList(string key, List<long> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new List<long>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				List<long> list = new List<long>();
				for (int i = 0; i < num; i++)
				{
					list.Add(reader.ReadInt64());
				}
				return list;
			}
			}
		}

		public List<bool> ReadBoolList(string key, List<bool> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new List<bool>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				List<bool> list = new List<bool>();
				for (int i = 0; i < num; i++)
				{
					list.Add(reader.ReadBoolean());
				}
				return list;
			}
			}
		}

		public List<int> ReadIntList(string key, List<int> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new List<int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				List<int> list = new List<int>();
				for (int i = 0; i < num; i++)
				{
					list.Add(reader.ReadInt32());
				}
				return list;
			}
			}
		}

		public List<string> ReadStringList(string key, List<string> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new List<string>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				List<string> list = new List<string>();
				for (int i = 0; i < num; i++)
				{
					list.Add(reader.ReadString());
				}
				return list;
			}
			}
		}

		public List<float> ReadFloatList(string key, List<float> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new List<float>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				List<float> list = new List<float>();
				for (int i = 0; i < num; i++)
				{
					list.Add(reader.ReadSingle());
				}
				return list;
			}
			}
		}

		public LinkedList<T> ReadObjectLinkedList<T>(string key, LinkedList<T> defaultValue = null) where T : IFVSerializable
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new LinkedList<T>();
			case -1:
				return null;
			default:
			{
				bool flag = currentReader.CreateMap(key);
				LinkedList<T> linkedList = new LinkedList<T>();
				for (int i = 0; i < num; i++)
				{
					linkedList.AddLast(ReadObject<T>($"{key}{i}"));
				}
				if (flag)
				{
					currentReader.ReleaseMap();
				}
				return linkedList;
			}
			}
		}

		public LinkedList<int> ReadIntLinkedList(string key, LinkedList<int> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new LinkedList<int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				LinkedList<int> linkedList = new LinkedList<int>();
				for (int i = 0; i < num; i++)
				{
					linkedList.AddLast(reader.ReadInt32());
				}
				return linkedList;
			}
			}
		}

		public LinkedList<string> ReadStringLinkedList(string key, LinkedList<string> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new LinkedList<string>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				LinkedList<string> linkedList = new LinkedList<string>();
				for (int i = 0; i < num; i++)
				{
					linkedList.AddLast(reader.ReadString());
				}
				return linkedList;
			}
			}
		}

		public T[] ReadObjectArray<T>(string key, T[] defaultValue = null) where T : IFVSerializable
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<T>();
			case -1:
				return null;
			default:
			{
				bool flag = currentReader.CreateMap(key);
				T[] array = new T[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = ReadObject<T>($"{key}{i}");
				}
				if (flag)
				{
					currentReader.ReleaseMap();
				}
				return array;
			}
			}
		}

		public T[] ReadEnumArray<T>(string key, T[] defaultValue = null) where T : struct, Enum
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<T>();
			case -1:
				return null;
			default:
			{
				T[] array = new T[num];
				BinaryReader reader = currentReader.Reader;
				for (int i = 0; i < num; i++)
				{
					int value = reader.ReadInt32();
					T val = (T)Enum.ToObject(typeof(T), value);
					array[i] = val;
				}
				return array;
			}
			}
		}

		public bool[] ReadBoolArray(string key, bool[] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<bool>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				bool[] array = new bool[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = reader.ReadBoolean();
				}
				return array;
			}
			}
		}

		public int[] ReadIntArray(string key, int[] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = reader.ReadInt32();
				}
				return array;
			}
			}
		}

		public long[] ReadLongArray(string key, long[] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<long>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				long[] array = new long[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = reader.ReadInt64();
				}
				return array;
			}
			}
		}

		public string[] ReadStringArray(string key, string[] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<string>();
			case -1:
				return null;
			default:
			{
				string[] array = new string[num];
				BinaryReader reader = currentReader.Reader;
				for (int i = 0; i < num; i++)
				{
					array[i] = reader.ReadString();
				}
				return array;
			}
			}
		}

		public float[] ReadFloatArray(string key, float[] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<float>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				float[] array = new float[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = reader.ReadSingle();
				}
				return array;
			}
			}
		}

		public byte[] ReadByteArray(string key, byte[] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<byte>();
			case -1:
				return null;
			default:
			{
				byte[] array = new byte[num];
				BinaryReader reader = currentReader.Reader;
				for (int i = 0; i < num; i++)
				{
					array[i] = reader.ReadByte();
				}
				return array;
			}
			}
		}

		public byte[,] ReadByteArray2D(string key, byte[,] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			if (currentReader.Reader.ReadBoolean())
			{
				return null;
			}
			BinaryReader reader = currentReader.Reader;
			int num = reader.ReadInt32();
			int num2 = reader.ReadInt32();
			byte[,] array = new byte[num, num2];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array[i, j] = reader.ReadByte();
				}
			}
			return array;
		}

		public byte[,,] ReadByteArray3D(string key, byte[,,] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			if (currentReader.Reader.ReadBoolean())
			{
				return null;
			}
			BinaryReader reader = currentReader.Reader;
			int num = reader.ReadInt32();
			int num2 = reader.ReadInt32();
			int num3 = reader.ReadInt32();
			byte[,,] array = new byte[num, num2, num3];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					for (int k = 0; k < num3; k++)
					{
						array[i, j, k] = reader.ReadByte();
					}
				}
			}
			return array;
		}

		public List<int>[] ReadIntListArray(string key, List<int>[] defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return Array.Empty<List<int>>();
			case -1:
				return null;
			default:
			{
				List<int>[] array = new List<int>[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = ReadIntList(key);
				}
				return array;
			}
			}
		}

		public HashSet<T> ReadObjectHashSet<T>(string key, HashSet<T> defaultValue = null) where T : IFVSerializable
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new HashSet<T>();
			case -1:
				return null;
			default:
			{
				bool flag = currentReader.CreateMap(key);
				HashSet<T> hashSet = new HashSet<T>();
				for (int i = 0; i < num; i++)
				{
					hashSet.Add(ReadObject<T>($"{key}{i}"));
				}
				if (flag)
				{
					currentReader.ReleaseMap();
				}
				return hashSet;
			}
			}
		}

		public ConcurrentHashSet<T> ReadObjectConcurrentHashSet<T>(string key, ConcurrentHashSet<T> defaultValue = null) where T : IFVSerializable
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new ConcurrentHashSet<T>();
			case -1:
				return null;
			default:
			{
				bool flag = currentReader.CreateMap(key);
				HashSet<T> hashSet = new HashSet<T>();
				for (int i = 0; i < num; i++)
				{
					hashSet.Add(ReadObject<T>($"{key}{i}"));
				}
				if (flag)
				{
					currentReader.ReleaseMap();
				}
				return new ConcurrentHashSet<T>(hashSet);
			}
			}
		}

		public HashSet<int> ReadIntHashSet(string key, HashSet<int> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new HashSet<int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				HashSet<int> hashSet = new HashSet<int>();
				for (int i = 0; i < num; i++)
				{
					hashSet.Add(reader.ReadInt32());
				}
				return hashSet;
			}
			}
		}

		public HashSet<string> ReadStringHashSet(string key, HashSet<string> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new HashSet<string>();
			case -1:
				return null;
			default:
			{
				HashSet<string> hashSet = new HashSet<string>();
				BinaryReader reader = currentReader.Reader;
				for (int i = 0; i < num; i++)
				{
					hashSet.Add(reader.ReadString());
				}
				return hashSet;
			}
			}
		}

		public HashSet<float> ReadFloatHashSet(string key, HashSet<float> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new HashSet<float>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				HashSet<float> hashSet = new HashSet<float>();
				for (int i = 0; i < num; i++)
				{
					hashSet.Add(reader.ReadSingle());
				}
				return hashSet;
			}
			}
		}

		public Queue<T> ReadObjectQueue<T>(string key, Queue<T> defaultValue = null) where T : IFVSerializable
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new Queue<T>();
			case -1:
				return null;
			default:
			{
				bool flag = currentReader.CreateMap(key);
				Queue<T> queue = new Queue<T>();
				for (int i = 0; i < num; i++)
				{
					queue.Enqueue(ReadObject<T>($"{key}{i}"));
				}
				if (flag)
				{
					currentReader.ReleaseMap();
				}
				return queue;
			}
			}
		}

		public Queue<bool> ReadBoolQueue(string key, Queue<bool> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new Queue<bool>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				Queue<bool> queue = new Queue<bool>();
				for (int i = 0; i < num; i++)
				{
					queue.Enqueue(reader.ReadBoolean());
				}
				return queue;
			}
			}
		}

		public Queue<int> ReadIntQueue(string key, Queue<int> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new Queue<int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				Queue<int> queue = new Queue<int>();
				for (int i = 0; i < num; i++)
				{
					queue.Enqueue(reader.ReadInt32());
				}
				return queue;
			}
			}
		}

		public Dictionary<string, float> ReadStringFloatDict(string key, Dictionary<string, float> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new Dictionary<string, float>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				Dictionary<string, float> dictionary = new Dictionary<string, float>();
				for (int i = 0; i < num; i++)
				{
					dictionary.Add(reader.ReadString(), reader.ReadSingle());
				}
				return dictionary;
			}
			}
		}

		public Dictionary<string, int> ReadStringIntDict(string key, Dictionary<string, int> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new Dictionary<string, int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				for (int i = 0; i < num; i++)
				{
					dictionary.Add(reader.ReadString(), reader.ReadInt32());
				}
				return dictionary;
			}
			}
		}

		public Dictionary<int, int> ReadIntIntDict(string key, Dictionary<int, int> defaultValue = null)
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new Dictionary<int, int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				Dictionary<int, int> dictionary = new Dictionary<int, int>();
				for (int i = 0; i < num; i++)
				{
					dictionary.Add(reader.ReadInt32(), reader.ReadInt32());
				}
				return dictionary;
			}
			}
		}

		public Dictionary<T, int> ReadEnumIntDict<T>(string key, Dictionary<T, int> defaultValue = null) where T : Enum
		{
			if (!currentReader.SeekBufferToKey(key))
			{
				return defaultValue;
			}
			int num = ReadEnumerableHeader();
			switch (num)
			{
			case 0:
				return new Dictionary<T, int>();
			case -1:
				return null;
			default:
			{
				BinaryReader reader = currentReader.Reader;
				Dictionary<T, int> dictionary = new Dictionary<T, int>();
				for (int i = 0; i < num; i++)
				{
					T key2 = (T)Enum.ToObject(typeof(T), reader.ReadInt32());
					dictionary.Add(key2, reader.ReadInt32());
				}
				return dictionary;
			}
			}
		}

		private int ReadEnumerableHeader()
		{
			if (currentReader.Reader.ReadBoolean())
			{
				return -1;
			}
			return currentReader.Reader.ReadInt32();
		}
	}
}
