using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using MLAPI.Logging;
using MLAPI.Reflection;
using MLAPI.Spawning;
using UnityEngine;

namespace MLAPI.Serialization
{
	public class BitReader
	{
		private Stream source;

		private BitStream bitSource;

		public BitReader(Stream stream)
		{
			source = stream;
			bitSource = stream as BitStream;
		}

		public void SetStream(Stream stream)
		{
			source = stream;
			bitSource = stream as BitStream;
		}

		public int ReadByte()
		{
			return source.ReadByte();
		}

		public byte ReadByteDirect()
		{
			return (byte)source.ReadByte();
		}

		public bool ReadBit()
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			return bitSource.ReadBit();
		}

		public bool ReadBool()
		{
			if (bitSource == null)
			{
				return source.ReadByte() != 0;
			}
			return ReadBit();
		}

		public void SkipPadBits()
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			while (!bitSource.BitAligned)
			{
				ReadBit();
			}
		}

		public object ReadObjectPacked(Type type)
		{
			if (type.IsNullable() && ReadBool())
			{
				return null;
			}
			if (SerializationManager.TryDeserialize(source, type, out var obj))
			{
				return obj;
			}
			if (type.IsArray && type.HasElementType)
			{
				int num = ReadInt32Packed();
				Array array = Array.CreateInstance(type.GetElementType(), num);
				for (int i = 0; i < num; i++)
				{
					array.SetValue(ReadObjectPacked(type.GetElementType()), i);
				}
				return array;
			}
			if ((object)type == typeof(byte))
			{
				return ReadByteDirect();
			}
			if ((object)type == typeof(sbyte))
			{
				return ReadSByte();
			}
			if ((object)type == typeof(ushort))
			{
				return ReadUInt16Packed();
			}
			if ((object)type == typeof(short))
			{
				return ReadInt16Packed();
			}
			if ((object)type == typeof(int))
			{
				return ReadInt32Packed();
			}
			if ((object)type == typeof(uint))
			{
				return ReadUInt32Packed();
			}
			if ((object)type == typeof(long))
			{
				return ReadInt64Packed();
			}
			if ((object)type == typeof(ulong))
			{
				return ReadUInt64Packed();
			}
			if ((object)type == typeof(float))
			{
				return ReadSinglePacked();
			}
			if ((object)type == typeof(double))
			{
				return ReadDoublePacked();
			}
			if ((object)type == typeof(string))
			{
				return ReadStringPacked().ToString();
			}
			if ((object)type == typeof(bool))
			{
				return ReadBool();
			}
			if ((object)type == typeof(Vector2))
			{
				return ReadVector2Packed();
			}
			if ((object)type == typeof(Vector3))
			{
				return ReadVector3Packed();
			}
			if ((object)type == typeof(Vector4))
			{
				return ReadVector4Packed();
			}
			if ((object)type == typeof(Color))
			{
				return ReadColorPacked();
			}
			if ((object)type == typeof(Color32))
			{
				return ReadColor32();
			}
			if ((object)type == typeof(Ray))
			{
				return ReadRayPacked();
			}
			if ((object)type == typeof(Quaternion))
			{
				return ReadRotationPacked();
			}
			if ((object)type == typeof(char))
			{
				return ReadCharPacked();
			}
			if (type.IsEnum)
			{
				return ReadInt32Packed();
			}
			if ((object)type == typeof(GameObject))
			{
				ulong key = ReadUInt64Packed();
				if (SpawnManager.SpawnedObjects.ContainsKey(key))
				{
					return SpawnManager.SpawnedObjects[key].gameObject;
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("BitReader cannot find the GameObject sent in the SpawnedObjects list, it may have been destroyed. NetworkId: " + key);
				}
				return null;
			}
			if ((object)type == typeof(NetworkedObject))
			{
				ulong key2 = ReadUInt64Packed();
				if (SpawnManager.SpawnedObjects.ContainsKey(key2))
				{
					return SpawnManager.SpawnedObjects[key2];
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("BitReader cannot find the NetworkedObject sent in the SpawnedObjects list, it may have been destroyed. NetworkId: " + key2);
				}
				return null;
			}
			if (typeof(NetworkedBehaviour).IsAssignableFrom(type))
			{
				ulong key3 = ReadUInt64Packed();
				ushort index = ReadUInt16Packed();
				if (SpawnManager.SpawnedObjects.ContainsKey(key3))
				{
					return SpawnManager.SpawnedObjects[key3].GetBehaviourAtOrderIndex(index);
				}
				if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
				{
					NetworkLog.LogWarning("BitReader cannot find the NetworkedBehaviour sent in the SpawnedObjects list, it may have been destroyed. NetworkId: " + key3);
				}
				return null;
			}
			if (typeof(IBitWritable).IsAssignableFrom(type))
			{
				object obj2 = Activator.CreateInstance(type);
				((IBitWritable)obj2).Read(source);
				return obj2;
			}
			Type underlyingType = Nullable.GetUnderlyingType(type);
			if ((object)underlyingType != null && SerializationManager.IsTypeSupported(underlyingType))
			{
				return ReadObjectPacked(underlyingType);
			}
			throw new ArgumentException("BitReader cannot read type " + type.Name);
		}

		public float ReadSingle()
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				uintValue = ReadUInt32()
			};
			return uIntFloat.floatValue;
		}

		public double ReadDouble()
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				ulongValue = ReadUInt64()
			};
			return uIntFloat.doubleValue;
		}

		public float ReadSinglePacked()
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				uintValue = ReadUInt32Packed()
			};
			return uIntFloat.floatValue;
		}

		public double ReadDoublePacked()
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				ulongValue = ReadUInt64Packed()
			};
			return uIntFloat.doubleValue;
		}

		public Vector2 ReadVector2()
		{
			return new Vector2(ReadSingle(), ReadSingle());
		}

		public Vector2 ReadVector2Packed()
		{
			return new Vector2(ReadSinglePacked(), ReadSinglePacked());
		}

		public Vector3 ReadVector3()
		{
			return new Vector3(ReadSingle(), ReadSingle(), ReadSingle());
		}

		public Vector3 ReadVector3Packed()
		{
			return new Vector3(ReadSinglePacked(), ReadSinglePacked(), ReadSinglePacked());
		}

		public Vector4 ReadVector4()
		{
			return new Vector4(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
		}

		public Vector4 ReadVector4Packed()
		{
			return new Vector4(ReadSinglePacked(), ReadSinglePacked(), ReadSinglePacked(), ReadSinglePacked());
		}

		public Color ReadColor()
		{
			return new Color(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
		}

		public Color ReadColorPacked()
		{
			return new Color(ReadSinglePacked(), ReadSinglePacked(), ReadSinglePacked(), ReadSinglePacked());
		}

		public Color32 ReadColor32()
		{
			return new Color32((byte)ReadByte(), (byte)ReadByte(), (byte)ReadByte(), (byte)ReadByte());
		}

		public Ray ReadRay()
		{
			return new Ray(ReadVector3(), ReadVector3());
		}

		public Ray ReadRayPacked()
		{
			return new Ray(ReadVector3Packed(), ReadVector3Packed());
		}

		public float ReadRangedSingle(float minValue, float maxValue, int bytes)
		{
			if (bytes < 1 || bytes > 4)
			{
				throw new ArgumentOutOfRangeException("Result must occupy between 1 and 4 bytes!");
			}
			uint num = 0u;
			for (int i = 0; i < bytes; i++)
			{
				num |= (uint)(ReadByte() << (i << 3));
			}
			return (float)num / (float)(256 * bytes - 1) * (minValue + maxValue) - minValue;
		}

		public double ReadRangedDouble(double minValue, double maxValue, int bytes)
		{
			if (bytes < 1 || bytes > 8)
			{
				throw new ArgumentOutOfRangeException("Result must occupy between 1 and 8 bytes!");
			}
			ulong num = 0uL;
			for (int i = 0; i < bytes; i++)
			{
				num |= (ulong)((long)ReadByte() << (i << 3));
			}
			return (double)num / (double)(256 * bytes - 1) * (minValue + maxValue) - minValue;
		}

		public Quaternion ReadRotationPacked()
		{
			float num = ReadSinglePacked();
			float num2 = ReadSinglePacked();
			float num3 = ReadSinglePacked();
			float w = Mathf.Sqrt(1f - Mathf.Pow(num, 2f) - Mathf.Pow(num2, 2f) - Mathf.Pow(num3, 2f));
			return new Quaternion(num, num2, num3, w);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use ReadRotationPacked instead")]
		public Quaternion ReadRotation(int bytesPerAngle)
		{
			return ReadRotationPacked();
		}

		public Quaternion ReadRotation()
		{
			float x = ReadSingle();
			float y = ReadSingle();
			float z = ReadSingle();
			float w = ReadSingle();
			return new Quaternion(x, y, z, w);
		}

		public ulong ReadBits(int bitCount)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (bitCount > 64)
			{
				throw new ArgumentOutOfRangeException("Cannot read more than 64 bits into a 64-bit value!");
			}
			if (bitCount < 0)
			{
				throw new ArgumentOutOfRangeException("Cannot read fewer than 0 bits!");
			}
			ulong num = 0uL;
			for (int i = 0; i + 8 < bitCount; i += 8)
			{
				num |= (ulong)((long)ReadByte() << i);
			}
			return num | ((ulong)ReadByteBits(bitCount & 7) << (bitCount & -8));
		}

		public byte ReadByteBits(int bitCount)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (bitCount > 8)
			{
				throw new ArgumentOutOfRangeException("Cannot read more than 8 bits into an 8-bit value!");
			}
			if (bitCount < 0)
			{
				throw new ArgumentOutOfRangeException("Cannot read fewer than 0 bits!");
			}
			int num = 0;
			ByteBool byteBool = default(ByteBool);
			for (int i = 0; i < bitCount; i++)
			{
				num |= byteBool.Collapse(ReadBit()) << i;
			}
			return (byte)num;
		}

		public byte ReadNibble(bool asUpper)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			ByteBool byteBool = default(ByteBool);
			byte b = (byte)(byteBool.Collapse(ReadBit()) | (byteBool.Collapse(ReadBit()) << 1) | (byteBool.Collapse(ReadBit()) << 2) | (byteBool.Collapse(ReadBit()) << 3));
			if (asUpper)
			{
				b <<= 4;
			}
			return b;
		}

		public byte ReadNibble()
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			ByteBool byteBool = default(ByteBool);
			return (byte)(byteBool.Collapse(ReadBit()) | (byteBool.Collapse(ReadBit()) << 1) | (byteBool.Collapse(ReadBit()) << 2) | (byteBool.Collapse(ReadBit()) << 3));
		}

		public sbyte ReadSByte()
		{
			return (sbyte)ReadByte();
		}

		public ushort ReadUInt16()
		{
			return (ushort)(ReadByte() | (ReadByte() << 8));
		}

		public short ReadInt16()
		{
			return (short)ReadUInt16();
		}

		public char ReadChar()
		{
			return (char)ReadUInt16();
		}

		public uint ReadUInt32()
		{
			return (uint)(ReadByte() | (ReadByte() << 8) | (ReadByte() << 16) | (ReadByte() << 24));
		}

		public int ReadInt32()
		{
			return (int)ReadUInt32();
		}

		public ulong ReadUInt64()
		{
			return (ulong)((uint)ReadByte() | ((long)ReadByte() << 8) | ((long)ReadByte() << 16) | ((long)ReadByte() << 24) | ((long)ReadByte() << 32) | ((long)ReadByte() << 40) | ((long)ReadByte() << 48) | ((long)ReadByte() << 56));
		}

		public long ReadInt64()
		{
			return (long)ReadUInt64();
		}

		public short ReadInt16Packed()
		{
			return (short)Arithmetic.ZigZagDecode(ReadUInt64Packed());
		}

		public ushort ReadUInt16Packed()
		{
			return (ushort)ReadUInt64Packed();
		}

		public char ReadCharPacked()
		{
			return (char)ReadUInt16Packed();
		}

		public int ReadInt32Packed()
		{
			return (int)Arithmetic.ZigZagDecode(ReadUInt64Packed());
		}

		public uint ReadUInt32Packed()
		{
			return (uint)ReadUInt64Packed();
		}

		public long ReadInt64Packed()
		{
			return Arithmetic.ZigZagDecode(ReadUInt64Packed());
		}

		public ulong ReadUInt64Packed()
		{
			ulong num = ReadByteDirect();
			if (num <= 240)
			{
				return num;
			}
			if (num <= 248)
			{
				return 240 + (num - 241 << 8) + ReadByteDirect();
			}
			if (num == 249)
			{
				return (ulong)(2288L + (long)(ReadByte() << 8) + ReadByteDirect());
			}
			ulong num2 = ReadByteDirect() | ((ulong)ReadByteDirect() << 8) | (ulong)((long)ReadByte() << 16);
			int num3 = 2;
			int num4 = (int)(num - 247);
			while (num4 > ++num3)
			{
				num2 |= (ulong)((long)ReadByte() << (num3 << 3));
			}
			return num2;
		}

		public StringBuilder ReadString(bool oneByteChars)
		{
			return ReadString(null, oneByteChars);
		}

		public StringBuilder ReadString(StringBuilder builder = null, bool oneByteChars = false)
		{
			int num = (int)ReadUInt32Packed();
			if (builder == null)
			{
				builder = new StringBuilder(num);
			}
			else if (builder.Capacity + builder.Length < num)
			{
				builder.Capacity = num + builder.Length;
			}
			for (int i = 0; i < num; i++)
			{
				builder.Insert(i, oneByteChars ? ((char)ReadByte()) : ReadChar());
			}
			return builder;
		}

		public StringBuilder ReadStringPacked(StringBuilder builder = null)
		{
			int num = (int)ReadUInt32Packed();
			if (builder == null)
			{
				builder = new StringBuilder(num);
			}
			else if (builder.Capacity + builder.Length < num)
			{
				builder.Capacity = num + builder.Length;
			}
			for (int i = 0; i < num; i++)
			{
				builder.Insert(i, ReadCharPacked());
			}
			return builder;
		}

		public StringBuilder ReadStringDiff(string compare, bool oneByteChars = false)
		{
			return ReadStringDiff(null, compare, oneByteChars);
		}

		public StringBuilder ReadStringDiff(StringBuilder builder, string compare, bool oneByteChars = false)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			int num = (int)ReadUInt32Packed();
			if (builder == null)
			{
				builder = new StringBuilder(num);
			}
			else if (builder.Capacity < num)
			{
				builder.Capacity = num;
			}
			ulong bitPosition = bitSource.BitPosition + (ulong)((compare != null) ? Math.Min(num, compare.Length) : 0);
			int num2 = compare?.Length ?? 0;
			for (int i = 0; i < num; i++)
			{
				if (i >= num2 || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					builder.Insert(i, oneByteChars ? ((char)ReadByte()) : ReadChar());
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (i < num2)
				{
					builder.Insert(i, compare[i]);
				}
			}
			bitSource.BitPosition = bitPosition;
			return builder;
		}

		public StringBuilder ReadStringDiff(StringBuilder compareAndBuffer, bool oneByteChars = false)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			int num = (int)ReadUInt32Packed();
			if (compareAndBuffer == null)
			{
				throw new ArgumentNullException("Buffer cannot be null");
			}
			if (compareAndBuffer.Capacity < num)
			{
				compareAndBuffer.Capacity = num;
			}
			ulong bitPosition = bitSource.BitPosition + (ulong)Math.Min(num, compareAndBuffer.Length);
			for (int i = 0; i < num; i++)
			{
				if (i >= compareAndBuffer.Length || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					compareAndBuffer.Remove(i, 1);
					compareAndBuffer.Insert(i, oneByteChars ? ((char)ReadByte()) : ReadChar());
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
			}
			bitSource.BitPosition = bitPosition;
			return compareAndBuffer;
		}

		public StringBuilder ReadStringPackedDiff(string compare)
		{
			return ReadStringPackedDiff(null, compare);
		}

		public StringBuilder ReadStringPackedDiff(StringBuilder builder, string compare)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			int num = (int)ReadUInt32Packed();
			if (builder == null)
			{
				builder = new StringBuilder(num);
			}
			else if (builder.Capacity < num)
			{
				builder.Capacity = num;
			}
			ulong bitPosition = bitSource.BitPosition + (ulong)((compare != null) ? Math.Min(num, compare.Length) : 0);
			int num2 = compare?.Length ?? 0;
			for (int i = 0; i < num; i++)
			{
				if (i >= num2 || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					builder.Insert(i, ReadCharPacked());
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (i < num2)
				{
					builder.Insert(i, compare[i]);
				}
			}
			bitSource.BitPosition = bitPosition;
			return builder;
		}

		public StringBuilder ReadStringPackedDiff(StringBuilder compareAndBuffer)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			int num = (int)ReadUInt32Packed();
			if (compareAndBuffer == null)
			{
				throw new ArgumentNullException("Buffer cannot be null");
			}
			if (compareAndBuffer.Capacity < num)
			{
				compareAndBuffer.Capacity = num;
			}
			ulong bitPosition = bitSource.BitPosition + (ulong)Math.Min(num, compareAndBuffer.Length);
			for (int i = 0; i < num; i++)
			{
				if (i >= compareAndBuffer.Length || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					compareAndBuffer.Remove(i, 1);
					compareAndBuffer.Insert(i, ReadCharPacked());
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
			}
			bitSource.BitPosition = bitPosition;
			return compareAndBuffer;
		}

		public byte[] ReadByteArray(byte[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new byte[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadByteDirect();
			}
			return readTo;
		}

		public byte[] ReadByteArrayDiff(byte[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			byte[] array = ((readTo == null || readTo.LongLength != knownLength) ? new byte[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadByteDirect();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public short[] ReadShortArray(short[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new short[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadInt16();
			}
			return readTo;
		}

		public short[] ReadShortArrayPacked(short[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new short[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadInt16Packed();
			}
			return readTo;
		}

		public short[] ReadShortArrayDiff(short[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			short[] array = ((readTo == null || readTo.LongLength != knownLength) ? new short[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadInt16();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public short[] ReadShortArrayPackedDiff(short[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			short[] array = ((readTo == null || readTo.LongLength != knownLength) ? new short[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadInt16Packed();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public ushort[] ReadUShortArray(ushort[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new ushort[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadUInt16();
			}
			return readTo;
		}

		public ushort[] ReadUShortArrayPacked(ushort[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new ushort[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadUInt16Packed();
			}
			return readTo;
		}

		public ushort[] ReadUShortArrayDiff(ushort[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			ushort[] array = ((readTo == null || readTo.LongLength != knownLength) ? new ushort[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadUInt16();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public ushort[] ReadUShortArrayPackedDiff(ushort[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			ushort[] array = ((readTo == null || readTo.LongLength != knownLength) ? new ushort[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadUInt16Packed();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public int[] ReadIntArray(int[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new int[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadInt32();
			}
			return readTo;
		}

		public int[] ReadIntArrayPacked(int[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new int[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadInt32Packed();
			}
			return readTo;
		}

		public int[] ReadIntArrayDiff(int[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			int[] array = ((readTo == null || readTo.LongLength != knownLength) ? new int[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadInt32();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public int[] ReadIntArrayPackedDiff(int[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			int[] array = ((readTo == null || readTo.LongLength != knownLength) ? new int[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadInt32Packed();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public uint[] ReadUIntArray(uint[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new uint[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadUInt32();
			}
			return readTo;
		}

		public uint[] ReadUIntArrayPacked(uint[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new uint[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadUInt32Packed();
			}
			return readTo;
		}

		public uint[] ReadUIntArrayDiff(uint[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			uint[] array = ((readTo == null || readTo.LongLength != knownLength) ? new uint[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadUInt32();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public long[] ReadLongArray(long[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new long[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadInt64();
			}
			return readTo;
		}

		public long[] ReadLongArrayPacked(long[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new long[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadInt64Packed();
			}
			return readTo;
		}

		public long[] ReadLongArrayDiff(long[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			long[] array = ((readTo == null || readTo.LongLength != knownLength) ? new long[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadInt64();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public long[] ReadLongArrayPackedDiff(long[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			long[] array = ((readTo == null || readTo.LongLength != knownLength) ? new long[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadInt64Packed();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public ulong[] ReadULongArray(ulong[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new ulong[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadUInt64();
			}
			return readTo;
		}

		public ulong[] ReadULongArrayPacked(ulong[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new ulong[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadUInt64Packed();
			}
			return readTo;
		}

		public ulong[] ReadULongArrayDiff(ulong[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			ulong[] array = ((readTo == null || readTo.LongLength != knownLength) ? new ulong[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadUInt64();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public ulong[] ReadULongArrayPackedDiff(ulong[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			ulong[] array = ((readTo == null || readTo.LongLength != knownLength) ? new ulong[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadUInt64Packed();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public float[] ReadFloatArray(float[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new float[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadSingle();
			}
			return readTo;
		}

		public float[] ReadFloatArrayPacked(float[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new float[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadSinglePacked();
			}
			return readTo;
		}

		public float[] ReadFloatArrayDiff(float[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			float[] array = ((readTo == null || readTo.LongLength != knownLength) ? new float[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadSingle();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public float[] ReadFloatArrayPackedDiff(float[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			float[] array = ((readTo == null || readTo.LongLength != knownLength) ? new float[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					readTo[num2] = ReadSinglePacked();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public double[] ReadDoubleArray(double[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new double[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadDouble();
			}
			return readTo;
		}

		public double[] ReadDoubleArrayPacked(double[] readTo = null, long knownLength = -1L)
		{
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			if (readTo == null || readTo.LongLength != knownLength)
			{
				readTo = new double[knownLength];
			}
			for (long num = 0L; num < knownLength; num++)
			{
				readTo[num] = ReadDoublePacked();
			}
			return readTo;
		}

		public double[] ReadDoubleArrayDiff(double[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			double[] array = ((readTo == null || readTo.LongLength != knownLength) ? new double[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadDouble();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}

		public double[] ReadDoubleArrayPackedDiff(double[] readTo = null, long knownLength = -1L)
		{
			if (bitSource == null)
			{
				throw new InvalidOperationException("Cannot read bits on a non BitStream stream");
			}
			if (knownLength < 0)
			{
				knownLength = (long)ReadUInt64Packed();
			}
			double[] array = ((readTo == null || readTo.LongLength != knownLength) ? new double[knownLength] : readTo);
			ulong bitPosition = bitSource.BitPosition + (ulong)((readTo == null) ? 0 : Math.Min(knownLength, readTo.LongLength));
			long num = ((readTo == null) ? 0 : readTo.LongLength);
			for (long num2 = 0L; num2 < knownLength; num2++)
			{
				if (num2 >= num || ReadBit())
				{
					ulong bitPosition2 = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition;
					array[num2] = ReadDoublePacked();
					bitPosition = bitSource.BitPosition;
					bitSource.BitPosition = bitPosition2;
				}
				else if (num2 < readTo.LongLength)
				{
					array[num2] = readTo[num2];
				}
			}
			bitSource.BitPosition = bitPosition;
			return array;
		}
	}
}
