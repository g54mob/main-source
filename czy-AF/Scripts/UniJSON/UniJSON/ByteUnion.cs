using System;
using System.Net;
using System.Runtime.InteropServices;

namespace UniJSON
{
	public static class ByteUnion
	{
		[StructLayout(LayoutKind.Explicit)]
		public struct WordValue
		{
			[FieldOffset(0)]
			public short Signed;

			[FieldOffset(0)]
			public ushort Unsigned;

			[FieldOffset(0)]
			public byte Byte0;

			[FieldOffset(1)]
			public byte Byte1;

			public WordValue HostToNetworkOrder()
			{
				return new WordValue
				{
					Signed = IPAddress.HostToNetworkOrder(Signed)
				};
			}

			public static WordValue Create(short value)
			{
				return new WordValue
				{
					Signed = value
				};
			}

			public static WordValue Create(ushort value)
			{
				return new WordValue
				{
					Unsigned = value
				};
			}
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct DWordValue
		{
			[FieldOffset(0)]
			public int Signed;

			[FieldOffset(0)]
			public uint Unsigned;

			[FieldOffset(0)]
			public float Float;

			[FieldOffset(0)]
			public byte Byte0;

			[FieldOffset(1)]
			public byte Byte1;

			[FieldOffset(2)]
			public byte Byte2;

			[FieldOffset(3)]
			public byte Byte3;

			public DWordValue HostToNetworkOrder()
			{
				return new DWordValue
				{
					Signed = IPAddress.HostToNetworkOrder(Signed)
				};
			}

			public static DWordValue Create(int value)
			{
				return new DWordValue
				{
					Signed = value
				};
			}

			public static DWordValue Create(uint value)
			{
				return new DWordValue
				{
					Unsigned = value
				};
			}

			public static DWordValue Create(float value)
			{
				return new DWordValue
				{
					Float = value
				};
			}
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct QWordValue
		{
			[FieldOffset(0)]
			public long Signed;

			[FieldOffset(0)]
			public ulong Unsigned;

			[FieldOffset(0)]
			public double Float;

			[FieldOffset(0)]
			public byte Byte0;

			[FieldOffset(1)]
			public byte Byte1;

			[FieldOffset(2)]
			public byte Byte2;

			[FieldOffset(3)]
			public byte Byte3;

			[FieldOffset(4)]
			public byte Byte4;

			[FieldOffset(5)]
			public byte Byte5;

			[FieldOffset(6)]
			public byte Byte6;

			[FieldOffset(7)]
			public byte Byte7;

			public QWordValue HostToNetworkOrder()
			{
				if (BitConverter.IsLittleEndian)
				{
					return new QWordValue
					{
						Byte0 = Byte7,
						Byte1 = Byte6,
						Byte2 = Byte5,
						Byte3 = Byte4,
						Byte4 = Byte3,
						Byte5 = Byte2,
						Byte6 = Byte1,
						Byte7 = Byte0
					};
				}
				return this;
			}

			public static QWordValue Create(long value)
			{
				return new QWordValue
				{
					Signed = value
				};
			}

			public static QWordValue Create(ulong value)
			{
				return new QWordValue
				{
					Unsigned = value
				};
			}

			public static QWordValue Create(double value)
			{
				return new QWordValue
				{
					Float = value
				};
			}
		}
	}
}
