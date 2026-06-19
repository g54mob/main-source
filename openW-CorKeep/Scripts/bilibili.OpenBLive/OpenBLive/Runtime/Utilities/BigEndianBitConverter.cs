namespace OpenBLive.Runtime.Utilities
{
	internal class BigEndianBitConverter : EndianBitConverter
	{
		public override bool IsLittleEndian { get; }

		internal BigEndianBitConverter()
		{
		}

		public override byte[] GetBytes(short value)
		{
			return new byte[2]
			{
				(byte)(value >> 8),
				(byte)value
			};
		}

		public override byte[] GetBytes(int value)
		{
			return new byte[4]
			{
				(byte)(value >> 24),
				(byte)(value >> 16),
				(byte)(value >> 8),
				(byte)value
			};
		}

		public override byte[] GetBytes(long value)
		{
			return new byte[8]
			{
				(byte)(value >> 56),
				(byte)(value >> 48),
				(byte)(value >> 40),
				(byte)(value >> 32),
				(byte)(value >> 24),
				(byte)(value >> 16),
				(byte)(value >> 8),
				(byte)value
			};
		}

		public override short ToInt16(byte[] value, int startIndex)
		{
			CheckArguments(value, startIndex, 2);
			return (short)((value[startIndex] << 8) | value[startIndex + 1]);
		}

		public override int ToInt32(byte[] value, int startIndex)
		{
			CheckArguments(value, startIndex, 4);
			return (value[startIndex] << 24) | (value[startIndex + 1] << 16) | (value[startIndex + 2] << 8) | value[startIndex + 3];
		}

		public override long ToInt64(byte[] value, int startIndex)
		{
			CheckArguments(value, startIndex, 8);
			int num = (value[startIndex] << 24) | (value[startIndex + 1] << 16) | (value[startIndex + 2] << 8) | value[startIndex + 3];
			return (uint)((value[startIndex + 4] << 24) | (value[startIndex + 5] << 16) | (value[startIndex + 6] << 8) | value[startIndex + 7]) | ((long)num << 32);
		}
	}
}
