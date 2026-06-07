namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class Mgf1BytesGenerator : IDerivationFunction
	{
		private IDigest digest;

		private byte[] seed;

		private int hLen;

		public IDigest Digest => null;

		public Mgf1BytesGenerator(IDigest digest)
		{
		}

		public void Init(IDerivationParameters parameters)
		{
		}

		private void ItoOSP(int i, byte[] sp)
		{
		}

		public int GenerateBytes(byte[] output, int outOff, int length)
		{
			return 0;
		}
	}
}
