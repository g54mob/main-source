namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	public class DefaultSignatureResult : IBlockResult
	{
		private readonly ISigner mSigner;

		public DefaultSignatureResult(ISigner signer)
		{
		}

		public byte[] Collect()
		{
			return null;
		}

		public int Collect(byte[] sig, int sigOff)
		{
			return 0;
		}
	}
}
