using System.Security.Cryptography;

namespace Mono.Security.Cryptography
{
	public sealed class PKCS1
	{
		private static byte[] emptySHA1;

		private static byte[] emptySHA256;

		private static byte[] emptySHA384;

		private static byte[] emptySHA512;

		private static bool Compare(byte[] array1, byte[] array2)
		{
			return false;
		}

		public static byte[] I2OSP(byte[] x, int size)
		{
			return null;
		}

		public static byte[] OS2IP(byte[] x)
		{
			return null;
		}

		public static byte[] RSAVP1(RSA rsa, byte[] s)
		{
			return null;
		}

		public static bool Verify_v15(RSA rsa, HashAlgorithm hash, byte[] hashValue, byte[] signature, bool tryNonStandardEncoding)
		{
			return false;
		}

		public static byte[] Encode_v15(HashAlgorithm hash, byte[] hashValue, int emLength)
		{
			return null;
		}

		internal static string HashNameFromOid(string oid, bool throwOnError = true)
		{
			return null;
		}

		internal static HashAlgorithm CreateFromOid(string oid)
		{
			return null;
		}

		internal static HashAlgorithm CreateFromName(string name)
		{
			return null;
		}
	}
}
