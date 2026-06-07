namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DesParameters : KeyParameter
	{
		public const int DesKeyLength = 8;

		private const int N_DES_WEAK_KEYS = 16;

		private static readonly byte[] DES_weak_keys;

		public DesParameters(byte[] key)
			: base(null)
		{
		}

		public DesParameters(byte[] key, int keyOff, int keyLen)
			: base(null)
		{
		}

		public static bool IsWeakKey(byte[] key, int offset)
		{
			return false;
		}

		public static bool IsWeakKey(byte[] key)
		{
			return false;
		}

		public static byte SetOddParity(byte b)
		{
			return 0;
		}

		public static void SetOddParity(byte[] bytes)
		{
		}

		public static void SetOddParity(byte[] bytes, int off, int len)
		{
		}
	}
}
