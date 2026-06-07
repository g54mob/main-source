using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class KdfFeedbackBytesGenerator : IMacDerivationFunction, IDerivationFunction
	{
		private static readonly BigInteger IntegerMax;

		private static readonly BigInteger Two;

		private readonly IMac prf;

		private readonly int h;

		private byte[] fixedInputData;

		private int maxSizeExcl;

		private byte[] ios;

		private byte[] iv;

		private bool useCounter;

		private int generatedBytes;

		private byte[] k;

		public IDigest Digest => null;

		public KdfFeedbackBytesGenerator(IMac prf)
		{
		}

		public void Init(IDerivationParameters parameters)
		{
		}

		public int GenerateBytes(byte[] output, int outOff, int length)
		{
			return 0;
		}

		private void generateNext()
		{
		}

		public IMac GetMac()
		{
			return null;
		}
	}
}
