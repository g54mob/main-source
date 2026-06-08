namespace MLAPI.Serialization
{
	public static class EndianHelper
	{
		public static uint SwapEndian(uint value)
		{
			return (uint)(((value >> 24) & 0xFF) | ((value >> 8) & 0xFF00) | ((value << 8) & 0xFF0000) | ((value << 24) & -16777216));
		}

		public static ulong SwapEndian(ulong value)
		{
			return ((value >> 56) & 0xFF) | ((value >> 40) & 0xFF00) | ((value >> 24) & 0xFF0000) | ((value >> 8) & 0xFF000000u) | ((value << 56) & 0xFF00000000000000uL) | ((value << 40) & 0xFF000000000000L) | ((value << 24) & 0xFF0000000000L) | ((value << 8) & 0xFF00000000L);
		}
	}
}
