namespace OpenBLive.Runtime.Utilities
{
	internal class LittleEndianBitConverter : EndianBitConverter
	{
		public override bool IsLittleEndian { get; } = true;

		internal LittleEndianBitConverter()
		{
		}

		public override byte[] GetBytes(short value)
		{
			return new byte[2]
			{
				(byte)value,
				(byte)(value >> 8)
			};
		}

		public override byte[] GetBytes(int value)
		{
			return new byte[4]
			{
				(byte)value,
				(byte)(value >> 8),
				(byte)(value >> 16),
				(byte)(value >> 24)
			};
		}

		public override byte[] GetBytes(long value)
		{
			return new byte[8]
			{
				(byte)value,
				(byte)(value >> 8),
				(byte)(value >> 16),
				(byte)(value >> 24),
				(byte)(value >> 32),
				(byte)(value >> 40),
				(byte)(value >> 48),
				(byte)(value >> 56)
			};
		}

		public override short ToInt16(byte[] value, int startIndex)
		{
			CheckArguments(value, startIndex, 2);
			return (short)(value[startIndex] | (value[startIndex + 1] << 8));
		}

		public override int ToInt32(byte[] value, int startIndex)
		{
			CheckArguments(value, startIndex, 4);
			return value[startIndex] | (value[startIndex + 1] << 8) | (value[startIndex + 2] << 16) | (value[startIndex + 3] << 24);
		}

		public override long ToInt64(byte[] value, int startIndex)
		{
			CheckArguments(value, startIndex, 8);
			int num = value[startIndex] | (value[startIndex + 1] << 8) | (value[startIndex + 2] << 16) | (value[startIndex + 3] << 24);
			int num2 = value[startIndex + 4] | (value[startIndex + 5] << 8) | (value[startIndex + 6] << 16) | (value[startIndex + 7] << 24);
			return (uint)num | ((long)num2 << 32);
		}
	}
}
