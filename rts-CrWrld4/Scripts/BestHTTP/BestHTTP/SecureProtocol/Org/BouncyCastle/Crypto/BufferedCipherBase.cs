namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
	public abstract class BufferedCipherBase : IBufferedCipher
	{
		protected static readonly byte[] EmptyBuffer;

		public abstract string AlgorithmName { get; }

		public abstract void Init(bool forEncryption, ICipherParameters parameters);

		public abstract int GetBlockSize();

		public abstract int GetOutputSize(int inputLen);

		public abstract int GetUpdateOutputSize(int inputLen);

		public abstract byte[] ProcessByte(byte input);

		public virtual int ProcessByte(byte input, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual byte[] ProcessBytes(byte[] input)
		{
			return null;
		}

		public abstract byte[] ProcessBytes(byte[] input, int inOff, int length);

		public virtual int ProcessBytes(byte[] input, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
			return 0;
		}

		public abstract byte[] DoFinal();

		public virtual byte[] DoFinal(byte[] input)
		{
			return null;
		}

		public abstract byte[] DoFinal(byte[] input, int inOff, int length);

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int DoFinal(byte[] input, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int DoFinal(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
			return 0;
		}

		public abstract void Reset();
	}
}
