using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class KdfCounterBytesGenerator : IMacDerivationFunction, IDerivationFunction
	{
		private static readonly BigInteger IntegerMax;

		private static readonly BigInteger Two;

		private readonly IMac prf;

		private readonly int h;

		private byte[] fixedInputDataCtrPrefix;

		private byte[] fixedInputData_afterCtr;

		private int maxSizeExcl;

		private byte[] ios;

		private int generatedBytes;

		private byte[] k;

		public IDigest Digest => null;

		public KdfCounterBytesGenerator(IMac prf)
		{
		}

		public void Init(IDerivationParameters param)
		{
		}

		public IMac GetMac()
		{
			return null;
		}

		public int GenerateBytes(byte[] output, int outOff, int length)
		{
			return 0;
		}

		private void generateNext()
		{
		}
	}
}
