namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	public class DefaultVerifierResult : IVerifier
	{
		private readonly ISigner mSigner;

		public DefaultVerifierResult(ISigner signer)
		{
		}

		public bool IsVerified(byte[] signature)
		{
			return false;
		}

		public bool IsVerified(byte[] sig, int sigOff, int sigLen)
		{
			return false;
		}
	}
}
