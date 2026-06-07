namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class IesWithCipherParameters : IesParameters
	{
		private int cipherKeySize;

		public int CipherKeySize => 0;

		public IesWithCipherParameters(byte[] derivation, byte[] encoding, int macKeySize, int cipherKeySize)
			: base(null, null, 0)
		{
		}
	}
}
