using System.Runtime.InteropServices;

namespace CLanguage
{
	[StructLayout((LayoutKind)2, Pack = 1, Size = 8)]
	public struct Value
	{
		[FieldOffset(0)]
		public double Float64Value;

		[FieldOffset(0)]
		public long Int64Value;

		[FieldOffset(0)]
		public ulong UInt64Value;

		[FieldOffset(0)]
		public float Float32Value;

		[FieldOffset(0)]
		public int Int32Value;

		[FieldOffset(0)]
		public uint UInt32Value;

		[FieldOffset(0)]
		public short Int16Value;

		[FieldOffset(0)]
		public ushort UInt16Value;

		[FieldOffset(0)]
		public sbyte Int8Value;

		[FieldOffset(0)]
		public byte UInt8Value;

		[FieldOffset(0)]
		public int PointerValue;

		[FieldOffset(0)]
		public char CharValue;

		public override string ToString()
		{
			return null;
		}

		public static implicit operator Value(bool v)
		{
			return default(Value);
		}

		public static implicit operator Value(string v)
		{
			return default(Value);
		}

		public static implicit operator Value(char v)
		{
			return default(Value);
		}

		public static implicit operator Value(float v)
		{
			return default(Value);
		}

		public static implicit operator Value(double v)
		{
			return default(Value);
		}

		public static implicit operator Value(ulong v)
		{
			return default(Value);
		}

		public static implicit operator Value(long v)
		{
			return default(Value);
		}

		public static implicit operator Value(uint v)
		{
			return default(Value);
		}

		public static implicit operator Value(int v)
		{
			return default(Value);
		}

		public static implicit operator Value(ushort v)
		{
			return default(Value);
		}

		public static implicit operator Value(short v)
		{
			return default(Value);
		}

		public static implicit operator Value(byte v)
		{
			return default(Value);
		}

		public static implicit operator Value(sbyte v)
		{
			return default(Value);
		}

		public static explicit operator float(Value v)
		{
			return 0f;
		}

		public static explicit operator double(Value v)
		{
			return 0.0;
		}

		public static explicit operator ulong(Value v)
		{
			return 0uL;
		}

		public static explicit operator long(Value v)
		{
			return 0L;
		}

		public static explicit operator uint(Value v)
		{
			return 0u;
		}

		public static explicit operator int(Value v)
		{
			return 0;
		}

		public static explicit operator ushort(Value v)
		{
			return 0;
		}

		public static explicit operator short(Value v)
		{
			return 0;
		}

		public static explicit operator byte(Value v)
		{
			return 0;
		}

		public static explicit operator sbyte(Value v)
		{
			return 0;
		}

		public static Value Pointer(int address)
		{
			return default(Value);
		}
	}
}
