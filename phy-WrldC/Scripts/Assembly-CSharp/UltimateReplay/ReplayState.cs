using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UltimateReplay.Core;
using UltimateReplay.Util;
using UnityEngine;

namespace UltimateReplay
{
	public sealed class ReplayState
	{
		private const int maxByteAllocation = 4;

		private static byte[] sharedBuffer = new byte[4];

		private List<byte> bytes = new List<byte>();

		private int readPointer;

		public bool CanRead => bytes.Count > 0;

		public bool EndRead => readPointer >= Size;

		public int Size => bytes.Count;

		public ReplayState()
		{
		}

		internal ReplayState(byte[] data)
		{
			bytes.AddRange(data);
		}

		internal void PrepareForRead()
		{
			readPointer = 0;
		}

		public void Clear()
		{
			bytes.Clear();
			readPointer = 0;
		}

		public byte[] ToArray()
		{
			return bytes.ToArray();
		}

		public void Write(byte value)
		{
			bytes.Add(value);
		}

		public void Write(byte[] bytes)
		{
			for (int i = 0; i < bytes.Length; i++)
			{
				Write(bytes[i]);
			}
		}

		public void Write(byte[] bytes, int offset, int length)
		{
			for (int i = offset; i < length; i++)
			{
				Write(bytes[i]);
			}
		}

		public void Write(short value)
		{
			BitConverterNonAlloc.GetBytes(sharedBuffer, value);
			Write(sharedBuffer, 0, 2);
		}

		public void Write(int value)
		{
			BitConverterNonAlloc.GetBytes(sharedBuffer, value);
			Write(sharedBuffer, 0, 4);
		}

		public void Write(float value)
		{
			BitConverterNonAlloc.GetBytes(sharedBuffer, value);
			Write(sharedBuffer, 0, 4);
		}

		public void Write(bool value)
		{
			BitConverterNonAlloc.GetBytes(sharedBuffer, value);
			Write(sharedBuffer, 0, 1);
		}

		public void Write(string value)
		{
			byte[] array = Encoding.Default.GetBytes(value);
			Write((short)array.Length);
			Write(array);
		}

		public void Write(ReplayIdentity identity)
		{
			if (ReplayIdentity.byteSize == 4)
			{
				Write((int)(short)identity);
			}
			else
			{
				Write((short)identity);
			}
		}

		public void Write(ReplayState other)
		{
			foreach (byte @byte in other.bytes)
			{
				Write(@byte);
			}
		}

		public void Write(Vector2 value)
		{
			Write(value.x);
			Write(value.y);
		}

		public void Write(Vector3 value)
		{
			Write(value.x);
			Write(value.y);
			Write(value.z);
		}

		public void Write(Vector4 value)
		{
			Write(value.x);
			Write(value.y);
			Write(value.z);
			Write(value.w);
		}

		public void Write(Quaternion value)
		{
			Write(value.x);
			Write(value.y);
			Write(value.z);
			Write(value.w);
		}

		public void Write(Color value)
		{
			Write(value.r);
			Write(value.g);
			Write(value.b);
			Write(value.a);
		}

		public void Write(Color32 value)
		{
			Write(value.r);
			Write(value.g);
			Write(value.b);
			Write(value.a);
		}

		public void WriteLowPrecision(float value)
		{
			short value2 = (short)(value * 256f);
			Write(value2);
		}

		public void WriteLowPrecision(Vector2 value)
		{
			WriteLowPrecision(value.x);
			WriteLowPrecision(value.y);
		}

		public void WriteLowPrecision(Vector3 value)
		{
			WriteLowPrecision(value.x);
			WriteLowPrecision(value.y);
			WriteLowPrecision(value.z);
		}

		public void WriteLowPrecision(Vector4 value)
		{
			WriteLowPrecision(value.x);
			WriteLowPrecision(value.y);
			WriteLowPrecision(value.z);
			WriteLowPrecision(value.w);
		}

		public void WriteLowPrecision(Quaternion value)
		{
			WriteLowPrecision(value.x);
			WriteLowPrecision(value.y);
			WriteLowPrecision(value.z);
			WriteLowPrecision(value.w);
		}

		public object TryReadObject()
		{
			Type type = Type.GetType(ReadString());
			if (type == null)
			{
				throw new InvalidOperationException("Attempted to read an object from the state but its type information could not be decoded");
			}
			if (typeof(IReplaySerialize).IsAssignableFrom(type))
			{
				IReplaySerialize obj = (IReplaySerialize)Activator.CreateInstance(type);
				obj.OnReplayDeserialize(this);
				return obj;
			}
			if (!TypeSwitchReturn(type, out var result, TypeCaseReturn(ReadByte), TypeCaseReturn(Read16), TypeCaseReturn(Read32), TypeCaseReturn(ReadFloat), TypeCaseReturn(ReadBool), TypeCaseReturn(ReadString), TypeCaseReturn(ReadVec2), TypeCaseReturn(ReadVec3), TypeCaseReturn(ReadVec4), TypeCaseReturn(ReadQuat), TypeCaseReturn(ReadColor), TypeCaseReturn(ReadColor32)))
			{
				throw new NotSupportedException($"There is no deserializer for type '{type}'. Try implementing 'IReplaySerialize' to ensure the type can be deserialized correctly");
			}
			return result;
		}

		public void TryWriteObject(object value)
		{
			Type type = value.GetType();
			if (type.Assembly == typeof(Type).Assembly || type.Assembly == typeof(ReplayState).Assembly)
			{
				Write(type.FullName);
			}
			else
			{
				Write(type.AssemblyQualifiedName);
			}
			if (typeof(IReplaySerialize).IsAssignableFrom(type))
			{
				(value as IReplaySerialize).OnReplaySerialize(this);
			}
			else if (!TypeSwitch(type, value, TypeCase<byte>(Write), TypeCase<short>(Write), TypeCase<int>(Write), TypeCase<float>(Write), TypeCase<bool>(Write), TypeCase<string>(Write), TypeCase<Vector2>(Write), TypeCase<Vector3>(Write), TypeCase<Vector4>(Write), TypeCase<Quaternion>(Write), TypeCase<Color>(Write), TypeCase<Color32>(Write)))
			{
				throw new NotSupportedException($"There is no serializer for type '{type}'. Try implementing 'IReplaySerialize' to ensure the type can be seriaized correctly");
			}
		}

		public byte ReadByte()
		{
			if (!CanRead)
			{
				throw new InvalidOperationException("There is no data in the object state");
			}
			if (readPointer >= bytes.Count)
			{
				throw new InvalidOperationException("There are not enough bytes in the data to read the specified type");
			}
			byte result = bytes[readPointer];
			readPointer++;
			return result;
		}

		public byte[] ReadBytes(int amount)
		{
			byte[] array = new byte[amount];
			for (int i = 0; i < amount; i++)
			{
				array[i] = ReadByte();
			}
			return array;
		}

		public void ReadBytes(byte[] buffer, int offset, int amount)
		{
			for (int i = offset; i < amount; i++)
			{
				buffer[i] = ReadByte();
			}
		}

		public short Read16()
		{
			ReadBytes(sharedBuffer, 0, 2);
			return BitConverterNonAlloc.GetShort(sharedBuffer);
		}

		public int Read32()
		{
			ReadBytes(sharedBuffer, 0, 4);
			return BitConverterNonAlloc.GetInt(sharedBuffer);
		}

		public float ReadFloat()
		{
			ReadBytes(sharedBuffer, 0, 4);
			return BitConverterNonAlloc.GetFloat(sharedBuffer);
		}

		public bool ReadBool()
		{
			ReadBytes(sharedBuffer, 0, 1);
			return BitConverterNonAlloc.GetBool(sharedBuffer);
		}

		public string ReadString()
		{
			short amount = Read16();
			byte[] array = ReadBytes(amount);
			return Encoding.Default.GetString(array);
		}

		public ReplayIdentity ReadIdentity()
		{
			if (ReplayIdentity.byteSize == 4)
			{
				return new ReplayIdentity(Read32());
			}
			return new ReplayIdentity(Read16());
		}

		public ReplayState ReadState(int bytes)
		{
			return new ReplayState(ReadBytes(bytes));
		}

		public Vector2 ReadVec2()
		{
			float x = ReadFloat();
			float y = ReadFloat();
			return new Vector2(x, y);
		}

		public Vector3 ReadVec3()
		{
			float x = ReadFloat();
			float y = ReadFloat();
			float z = ReadFloat();
			return new Vector3(x, y, z);
		}

		public Vector4 ReadVec4()
		{
			float x = ReadFloat();
			float y = ReadFloat();
			float z = ReadFloat();
			float w = ReadFloat();
			return new Vector4(x, y, z, w);
		}

		public Quaternion ReadQuat()
		{
			float x = ReadFloat();
			float y = ReadFloat();
			float z = ReadFloat();
			float w = ReadFloat();
			return new Quaternion(x, y, z, w);
		}

		public Color ReadColor()
		{
			float r = ReadFloat();
			float g = ReadFloat();
			float b = ReadFloat();
			float a = ReadFloat();
			return new Color(r, g, b, a);
		}

		public Color32 ReadColor32()
		{
			byte r = ReadByte();
			byte g = ReadByte();
			byte b = ReadByte();
			byte a = ReadByte();
			return new Color32(r, g, b, a);
		}

		public float ReadFloatLowPrecision()
		{
			return (float)Read16() / 256f;
		}

		public Vector2 ReadVec2LowPrecision()
		{
			float x = ReadFloatLowPrecision();
			float y = ReadFloatLowPrecision();
			return new Vector2(x, y);
		}

		public Vector3 ReadVec3LowPrecision()
		{
			float x = ReadFloatLowPrecision();
			float y = ReadFloatLowPrecision();
			float z = ReadFloatLowPrecision();
			return new Vector3(x, y, z);
		}

		public Vector4 ReadVec4LowPrecision()
		{
			float x = ReadFloatLowPrecision();
			float y = ReadFloatLowPrecision();
			float z = ReadFloatLowPrecision();
			float w = ReadFloatLowPrecision();
			return new Vector4(x, y, z, w);
		}

		public Quaternion ReadQuatLowPrecision()
		{
			float x = ReadFloatLowPrecision();
			float y = ReadFloatLowPrecision();
			float z = ReadFloatLowPrecision();
			float w = ReadFloatLowPrecision();
			return new Quaternion(x, y, z, w);
		}

		public void WriteToBinary(BinaryWriter writer)
		{
			writer.Write(Size);
			for (int i = 0; i < Size; i++)
			{
				writer.Write(bytes[i]);
			}
		}

		public void ReadFromBinary(BinaryReader reader)
		{
			int count = reader.ReadInt32();
			byte[] collection = reader.ReadBytes(count);
			bytes = new List<byte>(collection);
			PrepareForRead();
		}

		private static bool TypeSwitch(Type type, object value, params KeyValuePair<Type, Action<object>>[] checkers)
		{
			for (int i = 0; i < checkers.Length; i++)
			{
				KeyValuePair<Type, Action<object>> keyValuePair = checkers[i];
				if (type == keyValuePair.Key)
				{
					keyValuePair.Value(value);
					return true;
				}
			}
			return false;
		}

		private static bool TypeSwitchReturn(Type type, out object result, params KeyValuePair<Type, Func<object>>[] checkers)
		{
			for (int i = 0; i < checkers.Length; i++)
			{
				KeyValuePair<Type, Func<object>> keyValuePair = checkers[i];
				if (type == keyValuePair.Key)
				{
					result = keyValuePair.Value();
					return true;
				}
			}
			result = null;
			return false;
		}

		private static KeyValuePair<Type, Action<object>> TypeCase<T>(Action<T> match)
		{
			return new KeyValuePair<Type, Action<object>>(typeof(T), delegate(object o)
			{
				match((T)o);
			});
		}

		private static KeyValuePair<Type, Func<object>> TypeCaseReturn<T>(Func<T> match)
		{
			return new KeyValuePair<Type, Func<object>>(typeof(T), () => match());
		}
	}
}
