namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Kdf
{
	public class ConcatenationKdfGenerator : IDerivationFunction
	{
		private readonly IDigest mDigest;

		private byte[] mShared;

		private byte[] mOtherInfo;

		private int mHLen;

		public virtual IDigest Digest => null;

		public ConcatenationKdfGenerator(IDigest digest)
		{
		}

		public virtual void Init(IDerivationParameters param)
		{
		}

		public virtual int GenerateBytes(byte[] outBytes, int outOff, int len)
		{
			return 0;
		}
	}
}
