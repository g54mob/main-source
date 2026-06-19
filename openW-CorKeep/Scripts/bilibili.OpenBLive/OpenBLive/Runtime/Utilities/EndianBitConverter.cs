using System;
using System.Runtime.CompilerServices;

namespace OpenBLive.Runtime.Utilities
{
	public abstract class EndianBitConverter
	{
		public static EndianBitConverter LittleEndian { get; } = new LittleEndianBitConverter();

		public static EndianBitConverter BigEndian { get; } = new BigEndianBitConverter();

		public abstract bool IsLittleEndian { get; }

		public byte[] GetBytes(bool value)
		{
			return new byte[1] { (byte)(value ? 1 : 0) };
		}

		public byte[] GetBytes(char value)
		{
			return GetBytes((short)value);
		}

		public byte[] GetBytes(double value)
		{
			long value2 = BitConverter.DoubleToInt64Bits(value);
			return GetBytes(value2);
		}

		public abstract byte[] GetBytes(short value);

		public abstract byte[] GetBytes(int value);

		public abstract byte[] GetBytes(long value);

		public byte[] GetBytes(float value)
		{
			int intValue = new SingleConverter(value).GetIntValue();
			return GetBytes(intValue);
		}

		public byte[] GetBytes(ushort value)
		{
			return GetBytes((short)value);
		}

		public byte[] GetBytes(uint value)
		{
			return GetBytes((int)value);
		}

		public byte[] GetBytes(ulong value)
		{
			return GetBytes((long)value);
		}

		public bool ToBoolean(byte[] value, int startIndex)
		{
			CheckArguments(value, startIndex, 1);
			return value[startIndex] != 0;
		}

		public char ToChar(byte[] value, int startIndex)
		{
			return (char)ToInt16(value, startIndex);
		}

		public double ToDouble(byte[] value, int startIndex)
		{
			return BitConverter.Int64BitsToDouble(ToInt64(value, startIndex));
		}

		public abstract short ToInt16(byte[] value, int startIndex);

		public abstract int ToInt32(byte[] value, int startIndex);

		public abstract long ToInt64(byte[] value, int startIndex);

		public float ToSingle(byte[] value, int startIndex)
		{
			return new SingleConverter(ToInt32(value, startIndex)).GetFloatValue();
		}

		public ushort ToUInt16(byte[] value, int startIndex)
		{
			return (ushort)ToInt16(value, startIndex);
		}

		public uint ToUInt32(byte[] value, int startIndex)
		{
			return (uint)ToInt32(value, startIndex);
		}

		public ulong ToUInt64(byte[] value, int startIndex)
		{
			return (ulong)ToInt64(value, startIndex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void CheckArguments(byte[] value, int startIndex, int byteLength)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if ((uint)startIndex > value.Length - byteLength)
			{
				throw new ArgumentOutOfRangeException("value");
			}
		}
	}
}
