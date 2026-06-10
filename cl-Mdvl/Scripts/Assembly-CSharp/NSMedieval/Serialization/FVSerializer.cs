using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using UnityEngine;

namespace NSMedieval.Serialization
{
	public class FVSerializer
	{
		private struct ValueTypePair
		{
			public IFVSerializable Value;

			public Type Type;

			public ValueTypePair(IFVSerializable value, Type type)
			{
				Value = value;
				Type = type;
			}
		}

		private Dictionary<string, FVBinaryWriter> writers = new Dictionary<string, FVBinaryWriter>();

		private FVBinaryWriter referenceWriter;

		private readonly FVBinaryWriter defaultWriter;

		private FVBinaryWriter currentWriter;

		private Stack<FVBinaryWriter> writerStack = new Stack<FVBinaryWriter>();

		private int refId;

		private int referencedCount;

		private Dictionary<ValueTypePair, FVSerializationReference> referencedObjects = new Dictionary<ValueTypePair, FVSerializationReference>();

		private Dictionary<ValueTypePair, int> serializedObjects = new Dictionary<ValueTypePair, int>();

		private HashSet<ValueTypePair> visitedObjects = new HashSet<ValueTypePair>();

		public FVSerializer(string defaultWriterId, string[] additionalWriterIds = null)
		{
			FVBinaryWriter value = new FVBinaryWriter(defaultWriterId);
			writers.Add(defaultWriterId, value);
			currentWriter = value;
			defaultWriter = value;
			referenceWriter = new FVBinaryWriter("reference");
			if (additionalWriterIds != null && additionalWriterIds.Length != 0)
			{
				foreach (string text in additionalWriterIds)
				{
					FVBinaryWriter value2 = new FVBinaryWriter(text);
					writers.Add(text, value2);
				}
			}
		}

		public void WriteReferences()
		{
			BinaryWriter writer = referenceWriter.Writer;
			writer.Write(referencedCount);
			foreach (FVSerializationReference item in referencedObjects.Where(delegate(KeyValuePair<ValueTypePair, FVSerializationReference> referencePair)
			{
				KeyValuePair<ValueTypePair, FVSerializationReference> keyValuePair = referencePair;
				return keyValuePair.Value.IsReferenced;
			}).Select(delegate(KeyValuePair<ValueTypePair, FVSerializationReference> referencePair)
			{
				KeyValuePair<ValueTypePair, FVSerializationReference> keyValuePair = referencePair;
				return keyValuePair.Value;
			}))
			{
				writer.Write(item.RefId);
				writer.Write(item.BufferId);
				writer.Write(item.BufferPosition);
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\FVSerializer.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Wrote ");
				messageBuilder.AppendFormatted(referencedCount);
				messageBuilder.AppendLiteral(" references");
			}
			Log.Info(messageBuilder);
		}

		public void ChangeWriter(string id)
		{
			if (!writers.ContainsKey(id))
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Profile\\FVSerializer.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("FVSerializer: Writer ");
					messageBuilder.AppendFormatted(id);
					messageBuilder.AppendLiteral(" couldn't be found!");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				writerStack.Push(currentWriter);
				currentWriter = writers[id];
			}
		}

		public void SetDefaultWriter()
		{
			currentWriter = defaultWriter;
			writerStack.Clear();
		}

		public void PopBackWriter()
		{
			if (writerStack.Count != 0)
			{
				currentWriter = writerStack.Pop();
			}
		}

		public byte[] GetBytes(string id = null)
		{
			if (id == null)
			{
				return defaultWriter.GetBytes();
			}
			if (!writers.ContainsKey(id))
			{
				return null;
			}
			return writers[id].GetBytes();
		}

		public byte[] GetReferenceBytes()
		{
			return referenceWriter.GetBytes();
		}

		public void Write(string key, byte value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, bool value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, int value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void WriteEnum<T>(string key, T value) where T : struct, Enum
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(Convert.ToInt32(value));
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, short value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, uint value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, ushort value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, long value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, float value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, double value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, string value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (WriteIsNull(value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			currentWriter.Writer.Write(value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, int? value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (WriteIsNull(value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			currentWriter.Writer.Write(value.Value);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, Vec3Int value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value.x);
			currentWriter.Writer.Write(value.y);
			currentWriter.Writer.Write(value.z);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, SerializableVector2Int value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value.x);
			currentWriter.Writer.Write(value.y);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, Vector2 value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value.x);
			currentWriter.Writer.Write(value.y);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, Vector3 value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value.x);
			currentWriter.Writer.Write(value.y);
			currentWriter.Writer.Write(value.z);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, Color value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			currentWriter.Writer.Write(value.r);
			currentWriter.Writer.Write(value.g);
			currentWriter.Writer.Write(value.b);
			currentWriter.Writer.Write(value.a);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, IFVSerializable value)
		{
			WriteKey(key);
			if (value == null)
			{
				Write(null);
				return;
			}
			ValueTypePair item = new ValueTypePair(value, value.GetType());
			if (visitedObjects.Contains(item))
			{
				throw new Exception("Reference loop detected");
			}
			visitedObjects.Add(item);
			Write(value);
			visitedObjects.Remove(item);
		}

		private void Write(IFVSerializable value)
		{
			long startByte = GetStartByte();
			if (WriteIsNull(value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			if (WriteReference(value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			WriteType(value);
			long bufferPosition = currentWriter.GetBufferPosition();
			value.Serialize(this);
			WriteBufferPosition(startByte, bufferPosition);
		}

		private long GetStartByte()
		{
			int offset = 24;
			long bufferPosition = currentWriter.GetBufferPosition();
			currentWriter.Writer.Seek(offset, SeekOrigin.Current);
			return bufferPosition;
		}

		private void WriteBufferPosition(long startByte, long dataStartByte)
		{
			long bufferPosition = currentWriter.GetBufferPosition();
			currentWriter.SeekBuffer(startByte);
			currentWriter.Writer.Write(startByte);
			currentWriter.Writer.Write(dataStartByte);
			currentWriter.Writer.Write(bufferPosition);
			currentWriter.SeekBuffer(bufferPosition);
		}

		private bool WriteReference(IFVSerializable value)
		{
			ValueTypePair key = new ValueTypePair(value, value.GetType());
			bool flag = serializedObjects.ContainsKey(key);
			currentWriter.Writer.Write(flag);
			if (flag)
			{
				int value2 = serializedObjects[key];
				currentWriter.Writer.Write(value2);
				if (!referencedObjects[key].IsReferenced)
				{
					referencedObjects[key].IsReferenced = true;
					referencedCount++;
				}
				return true;
			}
			serializedObjects.Add(key, refId);
			currentWriter.Writer.Write(refId);
			referencedObjects.Add(key, new FVSerializationReference(refId, currentWriter.GetId(), currentWriter.GetBufferPosition()));
			refId++;
			return false;
		}

		private bool WriteIsNull(object value)
		{
			currentWriter.Writer.Write(value == null);
			return value == null;
		}

		public void Write<T>(string key, IList<T> value) where T : IFVSerializable
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			long bufferPosition = currentWriter.GetBufferPosition();
			for (int i = 0; i < value.Count; i++)
			{
				Write($"{key}{i}", value[i]);
			}
			WriteBufferPosition(startByte, bufferPosition);
		}

		public void WriteEnum<T>(string key, IList<T> value) where T : struct, Enum
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (T item in value)
			{
				writer.Write(Convert.ToInt32(item));
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, IList<bool> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			value.ForEach(writer.Write);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, IList<int> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			value.ForEach(writer.Write);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, IList<long> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			value.ForEach(writer.Write);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, IList<string> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			value.ForEach(writer.Write);
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, IList<float> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			value.ForEach(writer.Write);
			WriteBufferPosition(startByte, startByte);
		}

		private bool WriteListHeader<T>(string key, IList<T> value)
		{
			if (WriteIsNull(value))
			{
				return false;
			}
			currentWriter.Writer.Write(value.Count);
			return value.Count != 0;
		}

		public void Write<T>(string key, LinkedList<T> value) where T : IFVSerializable
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			long bufferPosition = currentWriter.GetBufferPosition();
			int num = 0;
			foreach (T item in value)
			{
				Write($"{key}{num}", item);
				num++;
			}
			WriteBufferPosition(startByte, bufferPosition);
		}

		public void Write(string key, LinkedList<int> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (int item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, LinkedList<string> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (string item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, LinkedList<float> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteListHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (float item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		private bool WriteListHeader<T>(string key, LinkedList<T> value)
		{
			if (WriteIsNull(value))
			{
				return false;
			}
			currentWriter.Writer.Write(value.Count);
			return value.Count != 0;
		}

		public void Write<T>(string key, T[] value) where T : IFVSerializable
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			long bufferPosition = currentWriter.GetBufferPosition();
			int num = 0;
			foreach (T val in value)
			{
				Write($"{key}{num}", val);
				num++;
			}
			WriteBufferPosition(startByte, bufferPosition);
		}

		public void WriteEnum<T>(string key, T[] value) where T : struct, Enum
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (T val in value)
			{
				writer.Write(Convert.ToInt32(val));
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, bool[] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (bool value2 in value)
			{
				writer.Write(value2);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, int[] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (int value2 in value)
			{
				writer.Write(value2);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, long[] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (long value2 in value)
			{
				writer.Write(value2);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, string[] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (string value2 in value)
			{
				writer.Write(value2);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, float[] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (float value2 in value)
			{
				writer.Write(value2);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, byte[] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (byte value2 in value)
			{
				writer.Write(value2);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, byte[,] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (WriteIsNull(value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			int length = value.GetLength(0);
			int length2 = value.GetLength(1);
			BinaryWriter writer = currentWriter.Writer;
			writer.Write(length);
			writer.Write(length2);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					writer.Write(value[i, j]);
				}
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, byte[,,] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (WriteIsNull(value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			int length = value.GetLength(0);
			int length2 = value.GetLength(1);
			int length3 = value.GetLength(2);
			BinaryWriter writer = currentWriter.Writer;
			writer.Write(length);
			writer.Write(length2);
			writer.Write(length3);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					for (int k = 0; k < length3; k++)
					{
						writer.Write(value[i, j, k]);
					}
				}
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, List<int>[] value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteArrayHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			foreach (List<int> value2 in value)
			{
				Write(key, value2);
			}
			WriteBufferPosition(startByte, startByte);
		}

		private bool WriteArrayHeader<T>(string key, T[] value)
		{
			if (WriteIsNull(value))
			{
				return false;
			}
			currentWriter.Writer.Write(value.Length);
			return value.Length != 0;
		}

		public void Write<T>(string key, HashSet<T> value) where T : IFVSerializable
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteCollectionHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			long bufferPosition = currentWriter.GetBufferPosition();
			int num = 0;
			foreach (T item in value)
			{
				Write($"{key}{num}", item);
				num++;
			}
			WriteBufferPosition(startByte, bufferPosition);
		}

		public void Write<T>(string key, ConcurrentHashSet<T> value) where T : IFVSerializable
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteCollectionHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			long bufferPosition = currentWriter.GetBufferPosition();
			int num = 0;
			foreach (T item in value)
			{
				Write($"{key}{num}", item);
				num++;
			}
			WriteBufferPosition(startByte, bufferPosition);
		}

		public void Write(string key, HashSet<int> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteCollectionHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (int item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, HashSet<string> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteCollectionHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (string item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, HashSet<float> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteCollectionHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (float item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		private bool WriteCollectionHeader<T>(string key, ICollection<T> value)
		{
			if (WriteIsNull(value))
			{
				return false;
			}
			currentWriter.Writer.Write(value.Count);
			return value.Count != 0;
		}

		public void Write<T>(string key, Queue<T> value) where T : IFVSerializable
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteQueueHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			long bufferPosition = currentWriter.GetBufferPosition();
			int num = 0;
			foreach (T item in value)
			{
				Write($"{key}{num}", item);
				num++;
			}
			WriteBufferPosition(startByte, bufferPosition);
		}

		public void Write(string key, Queue<bool> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteQueueHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (bool item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, Queue<int> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteQueueHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (int item in value)
			{
				writer.Write(item);
			}
			WriteBufferPosition(startByte, startByte);
		}

		private bool WriteQueueHeader<T>(string key, Queue<T> value)
		{
			if (WriteIsNull(value))
			{
				return false;
			}
			currentWriter.Writer.Write(value.Count);
			return value.Count != 0;
		}

		public void Write(string key, Dictionary<string, int> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteDictionaryHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (KeyValuePair<string, int> item in value)
			{
				writer.Write(item.Key);
				writer.Write(item.Value);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, Dictionary<string, float> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteDictionaryHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (KeyValuePair<string, float> item in value)
			{
				writer.Write(item.Key);
				writer.Write(item.Value);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write<T>(string key, Dictionary<T, int> value) where T : Enum
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteDictionaryHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (KeyValuePair<T, int> item in value)
			{
				writer.Write(Convert.ToInt32(item.Key));
				writer.Write(item.Value);
			}
			WriteBufferPosition(startByte, startByte);
		}

		public void Write(string key, Dictionary<int, int> value)
		{
			WriteKey(key);
			long startByte = GetStartByte();
			if (!WriteDictionaryHeader(key, value))
			{
				WriteBufferPosition(startByte, startByte);
				return;
			}
			BinaryWriter writer = currentWriter.Writer;
			foreach (KeyValuePair<int, int> item in value)
			{
				writer.Write(item.Key);
				writer.Write(item.Value);
			}
			WriteBufferPosition(startByte, startByte);
		}

		private bool WriteDictionaryHeader<T, TK>(string key, Dictionary<T, TK> value)
		{
			if (WriteIsNull(value))
			{
				return false;
			}
			currentWriter.Writer.Write(value.Count);
			return value.Count != 0;
		}

		private void WriteKey(string key)
		{
			currentWriter.Writer.Write(key.GetHashCode());
		}

		private void WriteType(IFVSerializable value)
		{
			Type type = value.GetType();
			FVSerializableKey customAttribute = type.GetCustomAttribute<FVSerializableKey>();
			if (customAttribute == null)
			{
				throw new Exception($"Can't serialize value of type {type}. Type name is empty!");
			}
			currentWriter.Writer.Write(customAttribute.Key.GetHashCode());
		}
	}
}
