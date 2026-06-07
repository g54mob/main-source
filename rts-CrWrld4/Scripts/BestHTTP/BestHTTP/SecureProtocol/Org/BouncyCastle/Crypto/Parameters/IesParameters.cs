namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class IesParameters : ICipherParameters
	{
		private byte[] derivation;

		private byte[] encoding;

		private int macKeySize;

		public int MacKeySize => 0;

		public IesParameters(byte[] derivation, byte[] encoding, int macKeySize)
		{
		}

		public byte[] GetDerivationV()
		{
			return null;
		}

		public byte[] GetEncodingV()
		{
			return null;
		}
	}
}
