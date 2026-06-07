namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class MgfParameters : IDerivationParameters
	{
		private readonly byte[] seed;

		public MgfParameters(byte[] seed)
		{
		}

		public MgfParameters(byte[] seed, int off, int len)
		{
		}

		public byte[] GetSeed()
		{
			return null;
		}
	}
}
