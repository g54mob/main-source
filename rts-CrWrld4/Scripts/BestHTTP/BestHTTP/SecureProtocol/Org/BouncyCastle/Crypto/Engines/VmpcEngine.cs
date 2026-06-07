namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class VmpcEngine : IStreamCipher
	{
		protected byte n;

		protected byte[] P;

		protected byte s;

		protected byte[] workingIV;

		protected byte[] workingKey;

		public virtual string AlgorithmName => null;

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		protected virtual void InitKey(byte[] keyBytes, byte[] ivBytes)
		{
		}

		public virtual void ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
		}

		public virtual void Reset()
		{
		}

		public virtual byte ReturnByte(byte input)
		{
			return 0;
		}
	}
}
