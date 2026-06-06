namespace BrewGame.SaveSystem.Serialization
{
	public static class SaveEncryptor
	{
		private static readonly byte[] MAGIC;

		private const byte ENCRYPTION_VERSION = 1;

		private const int IV_SIZE = 16;

		private const int KEY_SIZE = 32;

		private static readonly byte[] SALT;

		public static byte[] Encrypt(byte[] plaintext)
		{
			return null;
		}

		public static byte[] Decrypt(byte[] ciphertext)
		{
			return null;
		}

		public static bool IsEncrypted(byte[] data)
		{
			return false;
		}

		private static byte[] DeriveKey()
		{
			return null;
		}
	}
}
