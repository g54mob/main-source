namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class KdfParameters : IDerivationParameters
	{
		private byte[] iv;

		private byte[] shared;

		public KdfParameters(byte[] shared, byte[] iv)
		{
		}

		public byte[] GetSharedSecret()
		{
			return null;
		}

		public byte[] GetIV()
		{
			return null;
		}
	}
}
