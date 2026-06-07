namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DesEdeParameters : DesParameters
	{
		public const int DesEdeKeyLength = 24;

		private static byte[] FixKey(byte[] key, int keyOff, int keyLen)
		{
			return null;
		}

		public DesEdeParameters(byte[] key)
			: base(null)
		{
		}

		public DesEdeParameters(byte[] key, int keyOff, int keyLen)
			: base(null)
		{
		}

		public static bool IsWeakKey(byte[] key, int offset, int length)
		{
			return false;
		}

		public new static bool IsWeakKey(byte[] key, int offset)
		{
			return false;
		}

		public new static bool IsWeakKey(byte[] key)
		{
			return false;
		}

		public static bool IsRealEdeKey(byte[] key, int offset)
		{
			return false;
		}

		public static bool IsReal2Key(byte[] key, int offset)
		{
			return false;
		}

		public static bool IsReal3Key(byte[] key, int offset)
		{
			return false;
		}
	}
}
