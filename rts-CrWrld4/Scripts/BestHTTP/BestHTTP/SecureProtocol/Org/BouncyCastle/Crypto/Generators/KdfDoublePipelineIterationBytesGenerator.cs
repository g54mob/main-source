using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class KdfDoublePipelineIterationBytesGenerator : IMacDerivationFunction, IDerivationFunction
	{
		private static readonly BigInteger IntegerMax;

		private static readonly BigInteger Two;

		private readonly IMac prf;

		private readonly int h;

		private byte[] fixedInputData;

		private int maxSizeExcl;

		private byte[] ios;

		private bool useCounter;

		private int generatedBytes;

		private byte[] a;

		private byte[] k;

		public IDigest Digest => null;

		public KdfDoublePipelineIterationBytesGenerator(IMac prf)
		{
		}

		public void Init(IDerivationParameters parameters)
		{
		}

		private void generateNext()
		{
		}

		public int GenerateBytes(byte[] output, int outOff, int length)
		{
			return 0;
		}

		public IMac GetMac()
		{
			return null;
		}
	}
}
