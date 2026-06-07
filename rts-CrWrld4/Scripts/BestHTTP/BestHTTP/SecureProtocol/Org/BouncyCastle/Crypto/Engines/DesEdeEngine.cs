namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class DesEdeEngine : DesEngine
	{
		private int[] workingKey1;

		private int[] workingKey2;

		private int[] workingKey3;

		private bool forEncryption;

		public override string AlgorithmName => null;

		public override void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public override int GetBlockSize()
		{
			return 0;
		}

		public override int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public override void Reset()
		{
		}
	}
}
