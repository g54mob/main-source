namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class Iso18033KdfParameters : IDerivationParameters
	{
		private byte[] seed;

		public Iso18033KdfParameters(byte[] seed)
		{
		}

		public byte[] GetSeed()
		{
			return null;
		}
	}
}
