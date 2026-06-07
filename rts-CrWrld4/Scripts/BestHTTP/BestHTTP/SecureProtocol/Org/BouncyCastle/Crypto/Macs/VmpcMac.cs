namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	public class VmpcMac : IMac
	{
		private byte g;

		private byte n;

		private byte[] P;

		private byte s;

		private byte[] T;

		private byte[] workingIV;

		private byte[] workingKey;

		private byte x1;

		private byte x2;

		private byte x3;

		private byte x4;

		public virtual string AlgorithmName => null;

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int GetMacSize()
		{
			return 0;
		}

		public virtual void Init(ICipherParameters parameters)
		{
		}

		private void initKey(byte[] keyBytes, byte[] ivBytes)
		{
		}

		public virtual void Reset()
		{
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int inOff, int len)
		{
		}
	}
}
