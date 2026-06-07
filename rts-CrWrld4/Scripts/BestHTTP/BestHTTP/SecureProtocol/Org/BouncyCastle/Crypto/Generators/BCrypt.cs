namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public sealed class BCrypt
	{
		private static readonly uint[] MAGIC_STRING;

		internal const int MAGIC_STRING_LENGTH = 6;

		private static readonly uint[] KP;

		private static readonly uint[] KS0;

		private static readonly uint[] KS1;

		private static readonly uint[] KS2;

		private static readonly uint[] KS3;

		private const int ROUNDS = 16;

		private const int SBOX_SK = 256;

		private const int SBOX_SK2 = 512;

		private const int SBOX_SK3 = 768;

		private const int P_SZ = 18;

		private readonly uint[] S;

		private readonly uint[] P;

		internal const int SALT_SIZE_BYTES = 16;

		internal const int MIN_COST = 4;

		internal const int MAX_COST = 31;

		internal const int MAX_PASSWORD_BYTES = 72;

		private BCrypt()
		{
		}

		private uint F(uint x)
		{
			return 0u;
		}

		private void ProcessTable(uint xl, uint xr, uint[] table)
		{
		}

		private void InitState()
		{
		}

		private void CyclicXorKey(byte[] key)
		{
		}

		private byte[] EncryptMagicString()
		{
			return null;
		}

		private void ProcessTableWithSalt(uint[] table, uint[] salt32Bit, uint iv1, uint iv2)
		{
		}

		private byte[] DeriveRawKey(int cost, byte[] salt, byte[] psw)
		{
			return null;
		}

		public static byte[] PasswordToByteArray(char[] password)
		{
			return null;
		}

		public static byte[] Generate(byte[] password, byte[] salt, int cost)
		{
			return null;
		}
	}
}
