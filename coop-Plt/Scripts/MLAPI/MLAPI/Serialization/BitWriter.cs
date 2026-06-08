#define ARRAY_WRITE_PREMAP
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using MLAPI.Reflection;
using UnityEngine;

namespace MLAPI.Serialization
{
	public class BitWriter
	{
		private Stream sink;

		private BitStream bitSink;

		public BitWriter(Stream stream)
		{
			sink = stream;
			bitSink = stream as BitStream;
		}

		public void SetStream(Stream stream)
		{
			sink = stream;
			bitSink = stream as BitStream;
		}

		public void WriteObjectPacked(object value)
		{
			bool flag = value == null || (value is UnityEngine.Object && (UnityEngine.Object)value == null);
			if (flag || value.GetType().IsNullable())
			{
				WriteBool(flag);
				if (flag)
				{
					return;
				}
			}
			if (SerializationManager.TrySerialize(sink, value))
			{
				return;
			}
			if (value is Array array)
			{
				Type elementType = value.GetType().GetElementType();
				if (SerializationManager.IsTypeSupported(elementType))
				{
					WriteInt32Packed(array.Length);
					for (int i = 0; i < array.Length; i++)
					{
						WriteObjectPacked(array.GetValue(i));
					}
					return;
				}
			}
			else
			{
				if (value is byte)
				{
					WriteByte((byte)value);
					return;
				}
				if (value is sbyte)
				{
					WriteSByte((sbyte)value);
					return;
				}
				if (value is ushort)
				{
					WriteUInt16Packed((ushort)value);
					return;
				}
				if (value is short)
				{
					WriteInt16Packed((short)value);
					return;
				}
				if (value is int)
				{
					WriteInt32Packed((int)value);
					return;
				}
				if (value is uint)
				{
					WriteUInt32Packed((uint)value);
					return;
				}
				if (value is long)
				{
					WriteInt64Packed((long)value);
					return;
				}
				if (value is ulong)
				{
					WriteUInt64Packed((ulong)value);
					return;
				}
				if (value is float)
				{
					WriteSinglePacked((float)value);
					return;
				}
				if (value is double)
				{
					WriteDoublePacked((double)value);
					return;
				}
				if (value is string)
				{
					WriteStringPacked((string)value);
					return;
				}
				if (value is bool)
				{
					WriteBit((bool)value);
					return;
				}
				if (value is Vector2)
				{
					WriteVector2Packed((Vector2)value);
					return;
				}
				if (value is Vector3)
				{
					WriteVector3Packed((Vector3)value);
					return;
				}
				if (value is Vector4)
				{
					WriteVector4Packed((Vector4)value);
					return;
				}
				if (value is Color)
				{
					WriteColorPacked((Color)value);
					return;
				}
				if (value is Color32)
				{
					WriteColor32((Color32)value);
					return;
				}
				if (value is Ray)
				{
					WriteRayPacked((Ray)value);
					return;
				}
				if (value is Quaternion)
				{
					WriteRotationPacked((Quaternion)value);
					return;
				}
				if (value is char)
				{
					WriteCharPacked((char)value);
					return;
				}
				if (value.GetType().IsEnum)
				{
					WriteInt32Packed((int)value);
					return;
				}
				if (value is GameObject)
				{
					NetworkedObject component = ((GameObject)value).GetComponent<NetworkedObject>();
					if (component == null)
					{
						throw new ArgumentException("BitWriter cannot write GameObject types that does not has a NetworkedObject component attached. GameObject: " + ((GameObject)value).name);
					}
					if (!component.IsSpawned)
					{
						throw new ArgumentException("BitWriter cannot write NetworkedObject types that are not spawned. GameObject: " + ((GameObject)value).name);
					}
					WriteUInt64Packed(component.NetworkId);
					return;
				}
				if (value is NetworkedObject)
				{
					if (!((NetworkedObject)value).IsSpawned)
					{
						throw new ArgumentException("BitWriter cannot write NetworkedObject types that are not spawned. GameObject: " + ((GameObject)value).name);
					}
					WriteUInt64Packed(((NetworkedObject)value).NetworkId);
					return;
				}
				if (value is NetworkedBehaviour)
				{
					if (!((NetworkedBehaviour)value).HasNetworkedObject || !((NetworkedBehaviour)value).NetworkedObject.IsSpawned)
					{
						throw new ArgumentException("BitWriter cannot write NetworkedBehaviour types that are not spawned. GameObject: " + ((GameObject)value).name);
					}
					WriteUInt64Packed(((NetworkedBehaviour)value).NetworkId);
					WriteUInt16Packed(((NetworkedBehaviour)value).GetBehaviourId());
					return;
				}
				if (value is IBitWritable)
				{
					((IBitWritable)value).Write(sink);
					return;
				}
			}
			throw new ArgumentException("BitWriter cannot write type " + value.GetType().Name);
		}

		public void WriteSingle(float value)
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				floatValue = value
			};
			WriteUInt32(uIntFloat.uintValue);
		}

		public void WriteDouble(double value)
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				doubleValue = value
			};
			WriteUInt64(uIntFloat.ulongValue);
		}

		public void WriteSinglePacked(float value)
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				floatValue = value
			};
			WriteUInt32Packed(uIntFloat.uintValue);
		}

		public void WriteDoublePacked(double value)
		{
			UIntFloat uIntFloat = new UIntFloat
			{
				doubleValue = value
			};
			WriteUInt64Packed(uIntFloat.ulongValue);
		}

		public void WriteRay(Ray ray)
		{
			WriteVector3(ray.origin);
			WriteVector3(ray.direction);
		}

		public void WriteRayPacked(Ray ray)
		{
			WriteVector3Packed(ray.origin);
			WriteVector3Packed(ray.direction);
		}

		public void WriteColor(Color color)
		{
			WriteSingle(color.r);
			WriteSingle(color.g);
			WriteSingle(color.b);
			WriteSingle(color.a);
		}

		public void WriteColorPacked(Color color)
		{
			WriteSinglePacked(color.r);
			WriteSinglePacked(color.g);
			WriteSinglePacked(color.b);
			WriteSinglePacked(color.a);
		}

		public void WriteColor32(Color32 color32)
		{
			WriteSingle((int)color32.r);
			WriteSingle((int)color32.g);
			WriteSingle((int)color32.b);
			WriteSingle((int)color32.a);
		}

		public void WriteVector2(Vector2 vector2)
		{
			WriteSingle(vector2.x);
			WriteSingle(vector2.y);
		}

		public void WriteVector2Packed(Vector2 vector2)
		{
			WriteSinglePacked(vector2.x);
			WriteSinglePacked(vector2.y);
		}

		public void WriteVector3(Vector3 vector3)
		{
			WriteSingle(vector3.x);
			WriteSingle(vector3.y);
			WriteSingle(vector3.z);
		}

		public void WriteVector3Packed(Vector3 vector3)
		{
			WriteSinglePacked(vector3.x);
			WriteSinglePacked(vector3.y);
			WriteSinglePacked(vector3.z);
		}

		public void WriteVector4(Vector4 vector4)
		{
			WriteSingle(vector4.x);
			WriteSingle(vector4.y);
			WriteSingle(vector4.z);
			WriteSingle(vector4.w);
		}

		public void WriteVector4Packed(Vector4 vector4)
		{
			WriteSinglePacked(vector4.x);
			WriteSinglePacked(vector4.y);
			WriteSinglePacked(vector4.z);
			WriteSinglePacked(vector4.w);
		}

		public void WriteRangedSingle(float value, float minValue, float maxValue, int bytes)
		{
			if (bytes < 1 || bytes > 4)
			{
				throw new ArgumentOutOfRangeException("Result must occupy between 1 and 4 bytes!");
			}
			if (value < minValue || value > maxValue)
			{
				throw new ArgumentOutOfRangeException("Given value does not match the given constraints!");
			}
			uint num = (uint)((value + minValue) / (maxValue + minValue) * (float)(256 * bytes - 1));
			for (int i = 0; i < bytes; i++)
			{
				sink.WriteByte((byte)(num >> (i << 3)));
			}
		}

		public void WriteRangedDouble(double value, double minValue, double maxValue, int bytes)
		{
			if (bytes < 1 || bytes > 8)
			{
				throw new ArgumentOutOfRangeException("Result must occupy between 1 and 8 bytes!");
			}
			if (value < minValue || value > maxValue)
			{
				throw new ArgumentOutOfRangeException("Given value does not match the given constraints!");
			}
			ulong num = (ulong)((value + minValue) / (maxValue + minValue) * (double)(256 * bytes - 1));
			for (int i = 0; i < bytes; i++)
			{
				WriteByte((byte)(num >> (i << 3)));
			}
		}

		public void WriteRotationPacked(Quaternion rotation)
		{
			if (Mathf.Sign(rotation.w) < 0f)
			{
				WriteSinglePacked(0f - rotation.x);
				WriteSinglePacked(0f - rotation.y);
				WriteSinglePacked(0f - rotation.z);
			}
			else
			{
				WriteSinglePacked(rotation.x);
				WriteSinglePacked(rotation.y);
				WriteSinglePacked(rotation.z);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use WriteRotationPacked instead")]
		public void WriteRotation(Quaternion rotation, int bytesPerAngle)
		{
			WriteRotationPacked(rotation);
		}

		public void WriteRotation(Quaternion rotation)
		{
			WriteSingle(rotation.x);
			WriteSingle(rotation.y);
			WriteSingle(rotation.z);
			WriteSingle(rotation.w);
		}

		public void WriteBit(bool bit)
		{
			if (bitSink == null)
			{
				throw new InvalidOperationException("Cannot write bits on a non BitStream stream");
			}
			bitSink.WriteBit(bit);
		}

		public void WriteBool(bool value)
		{
			if (bitSink == null)
			{
				sink.WriteByte((byte)(value ? 1 : 0));
			}
			else
			{
				WriteBit(value);
			}
		}

		public void WritePadBits()
		{
			while (!bitSink.BitAligned)
			{
				WriteBit(bit: false);
			}
		}

		public void WriteNibble(byte value)
		{
			WriteBits(value, 4);
		}

		public void WriteNibble(byte value, bool upper)
		{
			WriteNibble((byte)(value >> (upper ? 4 : 0)));
		}

		public void WriteBits(ulong value, int bitCount)
		{
			if (bitSink == null)
			{
				throw new InvalidOperationException("Cannot write bits on a non BitStream stream");
			}
			if (bitCount > 64)
			{
				throw new ArgumentOutOfRangeException("Cannot read more than 64 bits from a 64-bit value!");
			}
			if (bitCount < 0)
			{
				throw new ArgumentOutOfRangeException("Cannot read fewer than 0 bits!");
			}
			int i;
			for (i = 0; i + 8 < bitCount; i += 8)
			{
				bitSink.WriteByte((byte)(value >> i));
			}
			for (; i < bitCount; i++)
			{
				bitSink.WriteBit((value & (ulong)(1L << i)) != 0);
			}
		}

		public void WriteBits(byte value, int bitCount)
		{
			if (bitSink == null)
			{
				throw new InvalidOperationException("Cannot write bits on a non BitStream stream");
			}
			for (int i = 0; i < bitCount; i++)
			{
				bitSink.WriteBit(((value >> i) & 1) != 0);
			}
		}

		public void WriteSByte(sbyte value)
		{
			WriteByte((byte)value);
		}

		public void WriteChar(char c)
		{
			WriteUInt16(c);
		}

		public void WriteUInt16(ushort value)
		{
			sink.WriteByte((byte)value);
			sink.WriteByte((byte)(value >> 8));
		}

		public void WriteInt16(short value)
		{
			WriteUInt16((ushort)value);
		}

		public void WriteUInt32(uint value)
		{
			sink.WriteByte((byte)value);
			sink.WriteByte((byte)(value >> 8));
			sink.WriteByte((byte)(value >> 16));
			sink.WriteByte((byte)(value >> 24));
		}

		public void WriteInt32(int value)
		{
			WriteUInt32((uint)value);
		}

		public void WriteUInt64(ulong value)
		{
			sink.WriteByte((byte)value);
			sink.WriteByte((byte)(value >> 8));
			sink.WriteByte((byte)(value >> 16));
			sink.WriteByte((byte)(value >> 24));
			sink.WriteByte((byte)(value >> 32));
			sink.WriteByte((byte)(value >> 40));
			sink.WriteByte((byte)(value >> 48));
			sink.WriteByte((byte)(value >> 56));
		}

		public void WriteInt64(long value)
		{
			WriteUInt64((ulong)value);
		}

		public void WriteInt16Packed(short value)
		{
			WriteInt64Packed(value);
		}

		public void WriteUInt16Packed(ushort value)
		{
			WriteUInt64Packed(value);
		}

		public void WriteCharPacked(char c)
		{
			WriteUInt16Packed(c);
		}

		public void WriteInt32Packed(int value)
		{
			WriteInt64Packed(value);
		}

		public void WriteUInt32Packed(uint value)
		{
			WriteUInt64Packed(value);
		}

		public void WriteInt64Packed(long value)
		{
			WriteUInt64Packed(Arithmetic.ZigZagEncode(value));
		}

		public void WriteUInt64Packed(ulong value)
		{
			if (value <= 240)
			{
				WriteULongByte(value);
				return;
			}
			if (value <= 2287)
			{
				WriteULongByte((value - 240 >> 8) + 241);
				WriteULongByte(value - 240);
				return;
			}
			if (value <= 67823)
			{
				WriteULongByte(249uL);
				WriteULongByte(value - 2288 >> 8);
				WriteULongByte(value - 2288);
				return;
			}
			ulong num = 255uL;
			ulong num2 = 72057594037927935uL;
			while (value <= num2)
			{
				num--;
				num2 >>= 8;
			}
			WriteULongByte(num);
			int num3 = (int)(num - 247);
			for (int i = 0; i < num3; i++)
			{
				WriteULongByte(value >> (i << 3));
			}
		}

		private void WriteIntByte(int value)
		{
			WriteByte((byte)value);
		}

		private void WriteULongByte(ulong byteValue)
		{
			WriteByte((byte)byteValue);
		}

		public void WriteByte(byte value)
		{
			sink.WriteByte(value);
		}

		public void WriteString(string s, bool oneByteChars = false)
		{
			WriteUInt32Packed((uint)s.Length);
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				if (oneByteChars)
				{
					WriteByte((byte)s[i]);
				}
				else
				{
					WriteChar(s[i]);
				}
			}
		}

		public void WriteStringPacked(string s)
		{
			WriteUInt32Packed((uint)s.Length);
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				WriteCharPacked(s[i]);
			}
		}

		public void WriteStringDiff(string write, string compare, bool oneByteChars = false)
		{
			WriteUInt32Packed((uint)write.Length);
			int num = Math.Min(write.Length, compare.Length);
			for (int i = 0; i < num; i++)
			{
				WriteBit(write[i] != compare[i]);
			}
			for (int j = 0; j < num; j++)
			{
				if (write[j] != compare[j])
				{
					if (oneByteChars)
					{
						WriteByte((byte)write[j]);
					}
					else
					{
						WriteChar(write[j]);
					}
				}
			}
		}

		public void WriteStringPackedDiff(string write, string compare)
		{
			WriteUInt32Packed((uint)write.Length);
			int num = Math.Min(write.Length, compare.Length);
			for (int i = 0; i < num; i++)
			{
				WriteBit(write[i] != compare[i]);
			}
			for (int j = 0; j < num; j++)
			{
				if (write[j] != compare[j])
				{
					WriteCharPacked(write[j]);
				}
			}
		}

		private void CheckLengths(Array a1, Array a2)
		{
		}

		[Conditional("ARRAY_WRITE_PREMAP")]
		private void WritePremap(Array a1, Array a2)
		{
			long num = Math.Min(a1.LongLength, a2.LongLength);
			for (long num2 = 0L; num2 < num; num2++)
			{
				WriteBit(!a1.GetValue(num2).Equals(a2.GetValue(num2)));
			}
		}

		private ulong WriteArraySize(Array a1, Array a2, long length)
		{
			ulong num = (ulong)((length >= 0) ? length : a1.LongLength);
			if (length < 0)
			{
				if (length > a1.LongLength)
				{
					throw new IndexOutOfRangeException("Cannot write more data than is available");
				}
				WriteUInt64Packed(num);
			}
			return num;
		}

		public void WriteByteArray(byte[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				sink.WriteByte(b[num2]);
			}
		}

		public void WriteByteArrayDiff(byte[] write, byte[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteByte(write[num2]);
				}
			}
		}

		public void WriteShortArray(short[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteInt16(b[num2]);
			}
		}

		public void WriteShortArrayDiff(short[] write, short[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteInt16(write[num2]);
				}
			}
		}

		public void WriteUShortArray(ushort[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteUInt16(b[num2]);
			}
		}

		public void WriteUShortArrayDiff(ushort[] write, ushort[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteUInt16(write[num2]);
				}
			}
		}

		public void WriteCharArray(char[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteChar(b[num2]);
			}
		}

		public void WriteCharArrayDiff(char[] write, char[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteChar(write[num2]);
				}
			}
		}

		public void WriteIntArray(int[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteInt32(b[num2]);
			}
		}

		public void WriteIntArrayDiff(int[] write, int[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteInt32(write[num2]);
				}
			}
		}

		public void WriteUIntArray(uint[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteUInt32(b[num2]);
			}
		}

		public void WriteUIntArrayDiff(uint[] write, uint[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteUInt32(write[num2]);
				}
			}
		}

		public void WriteLongArray(long[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteInt64(b[num2]);
			}
		}

		public void WriteLongArrayDiff(long[] write, long[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteInt64(write[num2]);
				}
			}
		}

		public void WriteULongArray(ulong[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteUInt64(b[num2]);
			}
		}

		public void WriteULongArrayDiff(ulong[] write, ulong[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteUInt64(write[num2]);
				}
			}
		}

		public void WriteFloatArray(float[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteSingle(b[num2]);
			}
		}

		public void WriteFloatArrayDiff(float[] write, float[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteSingle(write[num2]);
				}
			}
		}

		public void WriteDoubleArray(double[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteDouble(b[num2]);
			}
		}

		public void WriteDoubleArrayDiff(double[] write, double[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteDouble(write[num2]);
				}
			}
		}

		public void WriteArrayPacked(Array a, long count = -1L)
		{
			Type type = a.GetType();
			if ((object)type == typeof(byte[]))
			{
				WriteByteArray(a as byte[], count);
				return;
			}
			if ((object)type == typeof(short[]))
			{
				WriteShortArrayPacked(a as short[], count);
				return;
			}
			if ((object)type == typeof(ushort[]))
			{
				WriteUShortArrayPacked(a as ushort[], count);
				return;
			}
			if ((object)type == typeof(char[]))
			{
				WriteCharArrayPacked(a as char[], count);
				return;
			}
			if ((object)type == typeof(int[]))
			{
				WriteIntArrayPacked(a as int[], count);
				return;
			}
			if ((object)type == typeof(uint[]))
			{
				WriteUIntArrayPacked(a as uint[], count);
				return;
			}
			if ((object)type == typeof(long[]))
			{
				WriteLongArrayPacked(a as long[], count);
				return;
			}
			if ((object)type == typeof(ulong[]))
			{
				WriteULongArrayPacked(a as ulong[], count);
				return;
			}
			if ((object)type == typeof(float[]))
			{
				WriteFloatArrayPacked(a as float[], count);
				return;
			}
			if ((object)type == typeof(double[]))
			{
				WriteDoubleArrayPacked(a as double[], count);
				return;
			}
			throw new InvalidDataException("Unknown array type! Please serialize manually!");
		}

		public void WriteArrayPackedDiff(Array write, Array compare, long count = -1L)
		{
			Type type = write.GetType();
			if ((object)type != compare.GetType())
			{
				throw new ArrayTypeMismatchException("Cannot write diff of two differing array types");
			}
			if ((object)type == typeof(byte[]))
			{
				WriteByteArrayDiff(write as byte[], compare as byte[], count);
				return;
			}
			if ((object)type == typeof(short[]))
			{
				WriteShortArrayPackedDiff(write as short[], compare as short[], count);
				return;
			}
			if ((object)type == typeof(ushort[]))
			{
				WriteUShortArrayPackedDiff(write as ushort[], compare as ushort[], count);
				return;
			}
			if ((object)type == typeof(char[]))
			{
				WriteCharArrayPackedDiff(write as char[], compare as char[], count);
				return;
			}
			if ((object)type == typeof(int[]))
			{
				WriteIntArrayPackedDiff(write as int[], compare as int[], count);
				return;
			}
			if ((object)type == typeof(uint[]))
			{
				WriteUIntArrayPackedDiff(write as uint[], compare as uint[], count);
				return;
			}
			if ((object)type == typeof(long[]))
			{
				WriteLongArrayPackedDiff(write as long[], compare as long[], count);
				return;
			}
			if ((object)type == typeof(ulong[]))
			{
				WriteULongArrayPackedDiff(write as ulong[], compare as ulong[], count);
				return;
			}
			if ((object)type == typeof(float[]))
			{
				WriteFloatArrayPackedDiff(write as float[], compare as float[], count);
				return;
			}
			if ((object)type == typeof(double[]))
			{
				WriteDoubleArrayPackedDiff(write as double[], compare as double[], count);
				return;
			}
			throw new InvalidDataException("Unknown array type! Please serialize manually!");
		}

		public void WriteShortArrayPacked(short[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteInt16Packed(b[num2]);
			}
		}

		public void WriteShortArrayPackedDiff(short[] write, short[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteInt16Packed(write[num2]);
				}
			}
		}

		public void WriteUShortArrayPacked(ushort[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteUInt16Packed(b[num2]);
			}
		}

		public void WriteUShortArrayPackedDiff(ushort[] write, ushort[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteUInt16Packed(write[num2]);
				}
			}
		}

		public void WriteCharArrayPacked(char[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteCharPacked(b[num2]);
			}
		}

		public void WriteCharArrayPackedDiff(char[] write, char[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteCharPacked(write[num2]);
				}
			}
		}

		public void WriteIntArrayPacked(int[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteInt32Packed(b[num2]);
			}
		}

		public void WriteIntArrayPackedDiff(int[] write, int[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteInt32Packed(write[num2]);
				}
			}
		}

		public void WriteUIntArrayPacked(uint[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteUInt32Packed(b[num2]);
			}
		}

		public void WriteUIntArrayPackedDiff(uint[] write, uint[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteUInt32Packed(write[num2]);
				}
			}
		}

		public void WriteLongArrayPacked(long[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteInt64Packed(b[num2]);
			}
		}

		public void WriteLongArrayPackedDiff(long[] write, long[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteInt64Packed(write[num2]);
				}
			}
		}

		public void WriteULongArrayPacked(ulong[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteUInt64Packed(b[num2]);
			}
		}

		public void WriteULongArrayPackedDiff(ulong[] write, ulong[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteUInt64Packed(write[num2]);
				}
			}
		}

		public void WriteFloatArrayPacked(float[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteSinglePacked(b[num2]);
			}
		}

		public void WriteFloatArrayPackedDiff(float[] write, float[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteSinglePacked(write[num2]);
				}
			}
		}

		public void WriteDoubleArrayPacked(double[] b, long count = -1L)
		{
			ulong num = WriteArraySize(b, null, count);
			for (ulong num2 = 0uL; num2 < num; num2++)
			{
				WriteDoublePacked(b[num2]);
			}
		}

		public void WriteDoubleArrayPackedDiff(double[] write, double[] compare, long count = -1L)
		{
			CheckLengths(write, compare);
			long num = (long)WriteArraySize(write, compare, count);
			WritePremap(write, compare);
			for (long num2 = 0L; num2 < num; num2++)
			{
				if (num2 >= compare.LongLength || write[num2] != compare[num2])
				{
					WriteDoublePacked(write[num2]);
				}
			}
		}
	}
}
