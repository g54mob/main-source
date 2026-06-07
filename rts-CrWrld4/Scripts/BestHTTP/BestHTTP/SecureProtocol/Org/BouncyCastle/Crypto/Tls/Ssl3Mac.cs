namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class Ssl3Mac : IMac
	{
		private const byte IPAD_BYTE = 54;

		private const byte OPAD_BYTE = 92;

		internal static readonly byte[] IPAD;

		internal static readonly byte[] OPAD;

		private readonly IDigest digest;

		private readonly int padLength;

		private byte[] secret;

		public virtual string AlgorithmName => null;

		public Ssl3Mac(IDigest digest)
		{
		}

		public virtual void Init(ICipherParameters parameters)
		{
		}

		public virtual int GetMacSize()
		{
			return 0;
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		private static byte[] GenPad(byte b, int count)
		{
			return null;
		}
	}
}
