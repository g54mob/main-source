using System.Runtime.CompilerServices;

namespace kcp2k
{
	public static class Utils
	{
		public static int Clamp(int value, int min, int max)
		{
			return 0;
		}

		public static int Encode8u(byte[] p, int offset, byte value)
		{
			return 0;
		}

		public static int Decode8u(byte[] p, int offset, out byte value)
		{
			value = default(byte);
			return 0;
		}

		public static int Encode16U(byte[] p, int offset, ushort value)
		{
			return 0;
		}

		public static int Decode16U(byte[] p, int offset, out ushort value)
		{
			value = default(ushort);
			return 0;
		}

		public static int Encode32U(byte[] p, int offset, uint value)
		{
			return 0;
		}

		public static int Decode32U(byte[] p, int offset, out uint value)
		{
			value = default(uint);
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int TimeDiff(uint later, uint earlier)
		{
			return 0;
		}
	}
}
