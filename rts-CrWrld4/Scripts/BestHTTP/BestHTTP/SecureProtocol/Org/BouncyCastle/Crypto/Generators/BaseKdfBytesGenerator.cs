namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class BaseKdfBytesGenerator : IDerivationFunction
	{
		private int counterStart;

		private IDigest digest;

		private byte[] shared;

		private byte[] iv;

		public virtual IDigest Digest => null;

		public BaseKdfBytesGenerator(int counterStart, IDigest digest)
		{
		}

		public virtual void Init(IDerivationParameters parameters)
		{
		}

		public virtual int GenerateBytes(byte[] output, int outOff, int length)
		{
			return 0;
		}
	}
}
