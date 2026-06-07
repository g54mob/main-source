using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes.Gcm
{
	[Il2CppEagerStaticClassConstruction]
	internal static class GcmUtilities
	{
		private const uint E1 = 3774873600u;

		private const ulong E1L = 16212958658533785600uL;

		private static readonly uint[] LOOKUP;

		private static uint[] GenerateLookup()
		{
			return null;
		}

		internal static byte[] OneAsBytes()
		{
			return null;
		}

		internal static uint[] OneAsUints()
		{
			return null;
		}

		internal static ulong[] OneAsUlongs()
		{
			return null;
		}

		internal static byte[] AsBytes(uint[] x)
		{
			return null;
		}

		internal static void AsBytes(uint[] x, byte[] z)
		{
		}

		internal static byte[] AsBytes(ulong[] x)
		{
			return null;
		}

		internal static void AsBytes(ulong[] x, byte[] z)
		{
		}

		internal static uint[] AsUints(byte[] bs)
		{
			return null;
		}

		internal static void AsUints(byte[] bs, uint[] output)
		{
		}

		internal static ulong[] AsUlongs(byte[] x)
		{
			return null;
		}

		public static void AsUlongs(byte[] x, ulong[] z)
		{
		}

		internal static void Multiply(byte[] x, byte[] y)
		{
		}

		internal static void Multiply(uint[] x, uint[] y)
		{
		}

		internal static void Multiply(ulong[] x, ulong[] y)
		{
		}

		internal static void MultiplyP(uint[] x)
		{
		}

		internal static void MultiplyP(uint[] x, uint[] z)
		{
		}

		internal static void MultiplyP8(uint[] x)
		{
		}

		internal static void MultiplyP8(uint[] x, uint[] y)
		{
		}

		internal static uint ShiftRight(uint[] x)
		{
			return 0u;
		}

		internal static uint ShiftRight(uint[] x, uint[] z)
		{
			return 0u;
		}

		internal static uint ShiftRightN(uint[] x, int n)
		{
			return 0u;
		}

		internal static uint ShiftRightN(uint[] x, int n, uint[] z)
		{
			return 0u;
		}

		internal static void Xor(byte[] x, byte[] y)
		{
		}

		internal static void Xor(byte[] x, byte[] y, int yOff)
		{
		}

		internal static void Xor(byte[] x, int xOff, byte[] y, int yOff, byte[] z, int zOff)
		{
		}

		internal static void Xor(byte[] x, byte[] y, int yOff, int yLen)
		{
		}

		internal static void Xor(byte[] x, int xOff, byte[] y, int yOff, int len)
		{
		}

		internal static void Xor(byte[] x, byte[] y, byte[] z)
		{
		}

		internal static void Xor(uint[] x, uint[] y)
		{
		}

		internal static void Xor(uint[] x, uint[] y, uint[] z)
		{
		}

		internal static void Xor(ulong[] x, ulong[] y)
		{
		}

		internal static void Xor(ulong[] x, ulong[] y, ulong[] z)
		{
		}
	}
}
