namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class SipHash : IMac
	{
		protected readonly int c;

		protected readonly int d;

		protected long k0;

		protected long k1;

		protected long v0;

		protected long v1;

		protected long v2;

		protected long v3;

		protected long m;

		protected int wordPos;

		protected int wordCount;

		public virtual string AlgorithmName => null;

		public SipHash()
		{
		}

		public SipHash(int c, int d)
		{
		}

		public virtual int GetMacSize()
		{
			return 0;
		}

		public virtual void Init(ICipherParameters parameters)
		{
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int offset, int length)
		{
		}

		public virtual long DoFinal()
		{
			return 0L;
		}

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		protected virtual void ProcessMessageWord()
		{
		}

		protected virtual void ApplySipRounds(int n)
		{
		}

		protected static long RotateLeft(long x, int n)
		{
			return 0L;
		}
	}
}
