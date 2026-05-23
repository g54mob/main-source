namespace Utf8Json.Internal
{
	public static class NumberConverter
	{
		public static bool IsNumber(byte c)
		{
			return false;
		}

		public static bool IsNumberRepresentation(byte c)
		{
			return false;
		}

		public static sbyte ReadSByte(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0;
		}

		public static short ReadInt16(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0;
		}

		public static int ReadInt32(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0;
		}

		public static long ReadInt64(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0L;
		}

		public static byte ReadByte(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0;
		}

		public static ushort ReadUInt16(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0;
		}

		public static uint ReadUInt32(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0u;
		}

		public static ulong ReadUInt64(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0uL;
		}

		public static float ReadSingle(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0f;
		}

		public static double ReadDouble(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return 0.0;
		}

		public static int WriteByte(ref byte[] buffer, int offset, byte value)
		{
			return 0;
		}

		public static int WriteUInt16(ref byte[] buffer, int offset, ushort value)
		{
			return 0;
		}

		public static int WriteUInt32(ref byte[] buffer, int offset, uint value)
		{
			return 0;
		}

		public static int WriteUInt64(ref byte[] buffer, int offset, ulong value)
		{
			return 0;
		}

		public static int WriteSByte(ref byte[] buffer, int offset, sbyte value)
		{
			return 0;
		}

		public static int WriteInt16(ref byte[] buffer, int offset, short value)
		{
			return 0;
		}

		public static int WriteInt32(ref byte[] buffer, int offset, int value)
		{
			return 0;
		}

		public static int WriteInt64(ref byte[] buffer, int offset, long value)
		{
			return 0;
		}

		public static int WriteSingle(ref byte[] bytes, int offset, float value)
		{
			return 0;
		}

		public static int WriteDouble(ref byte[] bytes, int offset, double value)
		{
			return 0;
		}

		public static bool ReadBoolean(byte[] bytes, int offset, out int readCount)
		{
			readCount = default(int);
			return false;
		}
	}
}
