namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class HashAlgorithm
	{
		public const byte none = 0;

		public const byte md5 = 1;

		public const byte sha1 = 2;

		public const byte sha224 = 3;

		public const byte sha256 = 4;

		public const byte sha384 = 5;

		public const byte sha512 = 6;

		public static string GetName(byte hashAlgorithm)
		{
			return null;
		}

		public static string GetText(byte hashAlgorithm)
		{
			return null;
		}

		public static bool IsPrivate(byte hashAlgorithm)
		{
			return false;
		}

		public static bool IsRecognized(byte hashAlgorithm)
		{
			return false;
		}
	}
}
