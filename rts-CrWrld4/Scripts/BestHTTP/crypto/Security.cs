using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace crypto
{
	public class Security
	{
		public static string ComputeHash(string text, string salt)
		{
			return null;
		}

		public static string Decrypt(string cipherText, string key, string iv)
		{
			return null;
		}

		public static string Encrypt(string plainText, string key, string iv)
		{
			return null;
		}

		public static string GenerateText(int size)
		{
			return null;
		}

		private static IBufferedCipher CreateCipher(bool isEncryption, string key, string iv)
		{
			return null;
		}
	}
}
