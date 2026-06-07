namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class KeyParameter : ICipherParameters
	{
		private readonly byte[] key;

		public KeyParameter(byte[] key)
		{
		}

		public KeyParameter(byte[] key, int keyOff, int keyLen)
		{
		}

		public byte[] GetKey()
		{
			return null;
		}
	}
}
