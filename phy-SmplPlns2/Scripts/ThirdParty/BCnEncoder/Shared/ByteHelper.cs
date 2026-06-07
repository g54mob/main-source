namespace BCnEncoder.Shared
{
	internal static class ByteHelper
	{
		public static byte ClampToByte(int i)
		{
			if (i < 0)
			{
				i = 0;
			}
			if (i > 255)
			{
				i = 255;
			}
			return (byte)i;
		}

		public static byte ClampToByte(float f)
		{
			return ClampToByte((int)f);
		}

		public static byte Extract1(ulong source, int index)
		{
			return (byte)((source >> index) & 1);
		}

		public static ulong Store1(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(1L << index));
			dest |= ((ulong)value & 1uL) << index;
			return dest;
		}

		public static byte Extract2(ulong source, int index)
		{
			return (byte)((source >> index) & 3);
		}

		public static ulong Store2(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(3L << index));
			dest |= ((ulong)value & 3uL) << index;
			return dest;
		}

		public static byte Extract3(ulong source, int index)
		{
			return (byte)((source >> index) & 7);
		}

		public static ulong Store3(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(7L << index));
			dest |= ((ulong)value & 7uL) << index;
			return dest;
		}

		public static byte Extract4(ulong source, int index)
		{
			return (byte)((source >> index) & 0xF);
		}

		public static ulong Store4(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(15L << index));
			dest |= ((ulong)value & 0xFuL) << index;
			return dest;
		}

		public static byte Extract5(ulong source, int index)
		{
			return (byte)((source >> index) & 0x1F);
		}

		public static ulong Store5(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(31L << index));
			dest |= ((ulong)value & 0x1FuL) << index;
			return dest;
		}

		public static byte Extract6(ulong source, int index)
		{
			return (byte)((source >> index) & 0x3F);
		}

		public static ulong Store6(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(63L << index));
			dest |= ((ulong)value & 0x3FuL) << index;
			return dest;
		}

		public static byte Extract7(ulong source, int index)
		{
			return (byte)((source >> index) & 0x7F);
		}

		public static ulong Store7(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(127L << index));
			dest |= ((ulong)value & 0x7FuL) << index;
			return dest;
		}

		public static byte Extract8(ulong source, int index)
		{
			return (byte)((source >> index) & 0xFF);
		}

		public static ulong Store8(ulong dest, int index, byte value)
		{
			dest &= (ulong)(~(255L << index));
			dest |= ((ulong)value & 0xFFuL) << index;
			return dest;
		}

		public static ulong Extract(ulong source, int index, int bitCount)
		{
			ulong num = (ulong)((1L << bitCount) - 1);
			return (source >> index) & num;
		}

		public static ulong Store(ulong dest, int index, int bitCount, ulong value)
		{
			ulong num = (ulong)((1L << bitCount) - 1);
			dest &= ~(num << index);
			dest |= (value & num) << index;
			return dest;
		}

		public static ulong ExtractFrom128(ulong low, ulong high, int index, int bitCount)
		{
			if (index + bitCount <= 64)
			{
				return Extract(low, index, bitCount);
			}
			if (index >= 64)
			{
				return Extract(high, index - 64, bitCount);
			}
			int num = 64 - index;
			int bitCount2 = bitCount - num;
			int index2 = 0;
			ulong dest = Extract(low, index, num);
			ulong value = Extract(high, index2, bitCount2);
			return Store(dest, num, bitCount2, value);
		}

		public static (ulong, ulong) StoreTo128(ulong low, ulong high, int index, int bitCount, ulong value)
		{
			if (index + bitCount <= 64)
			{
				return (Store(low, index, bitCount, value), high);
			}
			if (index >= 64)
			{
				return (low, Store(high, index - 64, bitCount, value));
			}
			int num = 64 - index;
			int bitCount2 = bitCount - num;
			int index2 = 0;
			ulong item = Store(low, index, num, value);
			value >>= num;
			ulong item2 = Store(high, index2, bitCount2, value);
			return (item, item2);
		}
	}
}
