namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class IsaacEngine : IStreamCipher
	{
		private static readonly int sizeL;

		private static readonly int stateArraySize;

		private uint[] engineState;

		private uint[] results;

		private uint a;

		private uint b;

		private uint c;

		private int index;

		private byte[] keyStream;

		private byte[] workingKey;

		private bool initialised;

		public virtual string AlgorithmName => null;

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual byte ReturnByte(byte input)
		{
			return 0;
		}

		public virtual void ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
		}

		public virtual void Reset()
		{
		}

		private void setKey(byte[] keyBytes)
		{
		}

		private void isaac()
		{
		}

		private void mix(uint[] x)
		{
		}
	}
}
