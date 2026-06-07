namespace UltimateReplay.Util
{
	public static class BitConverterNonAlloc
	{
		public static void GetBytes(byte[] buffer, short value)
		{
			buffer[0] = (byte)((value >> 8) & 0xFF);
			buffer[1] = (byte)(value & 0xFF);
		}

		public static void GetBytes(byte[] buffer, int value)
		{
			buffer[0] = (byte)((value >> 24) & 0xFF);
			buffer[1] = (byte)((value >> 16) & 0xFF);
			buffer[2] = (byte)((value >> 8) & 0xFF);
			buffer[3] = (byte)(value & 0xFF);
		}

		public static void GetBytes(byte[] buffer, float value)
		{
			int value2 = Common32.ToInteger(value);
			GetBytes(buffer, value2);
		}

		public static void GetBytes(byte[] buffer, bool value)
		{
			buffer[0] = (byte)(value ? 1u : 0u);
		}

		public static short GetShort(byte[] buffer)
		{
			return (short)((buffer[0] << 8) | buffer[1]);
		}

		public static int GetInt(byte[] buffer)
		{
			return (buffer[0] << 24) | (buffer[1] << 16) | (buffer[2] << 8) | buffer[3];
		}

		public static float GetFloat(byte[] buffer)
		{
			return Common32.ToSingle(GetInt(buffer));
		}

		public static bool GetBool(byte[] buffer)
		{
			return buffer[0] != 0;
		}
	}
}
