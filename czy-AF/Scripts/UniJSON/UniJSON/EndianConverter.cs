using System;

namespace UniJSON
{
	public static class EndianConverter
	{
		public static short NetworkByteWordToSignedNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.WordValue wordValue = new ByteUnion.WordValue
				{
					Byte0 = bytes.Get(1),
					Byte1 = bytes.Get(0)
				};
				return wordValue.Signed;
			}
			return new ByteUnion.WordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1)
			}.Signed;
		}

		public static int NetworkByteDWordToSignedNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.DWordValue dWordValue = new ByteUnion.DWordValue
				{
					Byte0 = bytes.Get(3),
					Byte1 = bytes.Get(2),
					Byte2 = bytes.Get(1),
					Byte3 = bytes.Get(0)
				};
				return dWordValue.Signed;
			}
			return new ByteUnion.DWordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1),
				Byte2 = bytes.Get(2),
				Byte3 = bytes.Get(3)
			}.Signed;
		}

		public static long NetworkByteQWordToSignedNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.QWordValue qWordValue = new ByteUnion.QWordValue
				{
					Byte0 = bytes.Get(7),
					Byte1 = bytes.Get(6),
					Byte2 = bytes.Get(5),
					Byte3 = bytes.Get(4),
					Byte4 = bytes.Get(3),
					Byte5 = bytes.Get(2),
					Byte6 = bytes.Get(1),
					Byte7 = bytes.Get(0)
				};
				return qWordValue.Signed;
			}
			return new ByteUnion.QWordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1),
				Byte2 = bytes.Get(2),
				Byte3 = bytes.Get(3),
				Byte4 = bytes.Get(4),
				Byte5 = bytes.Get(5),
				Byte6 = bytes.Get(6),
				Byte7 = bytes.Get(7)
			}.Signed;
		}

		public static ushort NetworkByteWordToUnsignedNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.WordValue wordValue = new ByteUnion.WordValue
				{
					Byte0 = bytes.Get(1),
					Byte1 = bytes.Get(0)
				};
				return wordValue.Unsigned;
			}
			return new ByteUnion.WordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1)
			}.Unsigned;
		}

		public static uint NetworkByteDWordToUnsignedNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.DWordValue dWordValue = new ByteUnion.DWordValue
				{
					Byte0 = bytes.Get(3),
					Byte1 = bytes.Get(2),
					Byte2 = bytes.Get(1),
					Byte3 = bytes.Get(0)
				};
				return dWordValue.Unsigned;
			}
			return new ByteUnion.DWordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1),
				Byte2 = bytes.Get(2),
				Byte3 = bytes.Get(3)
			}.Unsigned;
		}

		public static ulong NetworkByteQWordToUnsignedNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.QWordValue qWordValue = new ByteUnion.QWordValue
				{
					Byte0 = bytes.Get(7),
					Byte1 = bytes.Get(6),
					Byte2 = bytes.Get(5),
					Byte3 = bytes.Get(4),
					Byte4 = bytes.Get(3),
					Byte5 = bytes.Get(2),
					Byte6 = bytes.Get(1),
					Byte7 = bytes.Get(0)
				};
				return qWordValue.Unsigned;
			}
			return new ByteUnion.QWordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1),
				Byte2 = bytes.Get(2),
				Byte3 = bytes.Get(3),
				Byte4 = bytes.Get(4),
				Byte5 = bytes.Get(5),
				Byte6 = bytes.Get(6),
				Byte7 = bytes.Get(7)
			}.Unsigned;
		}

		public static float NetworkByteDWordToFloatNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.DWordValue dWordValue = new ByteUnion.DWordValue
				{
					Byte0 = bytes.Get(3),
					Byte1 = bytes.Get(2),
					Byte2 = bytes.Get(1),
					Byte3 = bytes.Get(0)
				};
				return dWordValue.Float;
			}
			return new ByteUnion.DWordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1),
				Byte2 = bytes.Get(2),
				Byte3 = bytes.Get(3)
			}.Float;
		}

		public static double NetworkByteQWordToFloatNativeByteOrder(ArraySegment<byte> bytes)
		{
			if (BitConverter.IsLittleEndian)
			{
				ByteUnion.QWordValue qWordValue = new ByteUnion.QWordValue
				{
					Byte0 = bytes.Get(7),
					Byte1 = bytes.Get(6),
					Byte2 = bytes.Get(5),
					Byte3 = bytes.Get(4),
					Byte4 = bytes.Get(3),
					Byte5 = bytes.Get(2),
					Byte6 = bytes.Get(1),
					Byte7 = bytes.Get(0)
				};
				return qWordValue.Float;
			}
			return new ByteUnion.QWordValue
			{
				Byte0 = bytes.Get(0),
				Byte1 = bytes.Get(1),
				Byte2 = bytes.Get(2),
				Byte3 = bytes.Get(3),
				Byte4 = bytes.Get(4),
				Byte5 = bytes.Get(5),
				Byte6 = bytes.Get(6),
				Byte7 = bytes.Get(7)
			}.Float;
		}

		public static short ToNetworkByteOrder(this short value)
		{
			return ByteUnion.WordValue.Create(value).HostToNetworkOrder().Signed;
		}

		public static ushort ToNetworkByteOrder(this ushort value)
		{
			return ByteUnion.WordValue.Create(value).HostToNetworkOrder().Unsigned;
		}

		public static int ToNetworkByteOrder(this int value)
		{
			return ByteUnion.DWordValue.Create(value).HostToNetworkOrder().Signed;
		}

		public static uint ToNetworkByteOrder(this uint value)
		{
			return ByteUnion.DWordValue.Create(value).HostToNetworkOrder().Unsigned;
		}

		public static float ToNetworkByteOrder(this float value)
		{
			return ByteUnion.DWordValue.Create(value).HostToNetworkOrder().Float;
		}

		public static long ToNetworkByteOrder(this long value)
		{
			return ByteUnion.QWordValue.Create(value).HostToNetworkOrder().Signed;
		}

		public static ulong ToNetworkByteOrder(this ulong value)
		{
			return ByteUnion.QWordValue.Create(value).HostToNetworkOrder().Unsigned;
		}

		public static double ToNetworkByteOrder(this double value)
		{
			return ByteUnion.QWordValue.Create(value).HostToNetworkOrder().Float;
		}
	}
}
