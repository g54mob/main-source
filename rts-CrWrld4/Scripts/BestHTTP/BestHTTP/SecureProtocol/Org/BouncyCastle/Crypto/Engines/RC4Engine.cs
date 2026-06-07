namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class RC4Engine : IStreamCipher
	{
		private static readonly int STATE_LENGTH;

		private byte[] engineState;

		private int x;

		private int y;

		private byte[] workingKey;

		public virtual string AlgorithmName => null;

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual byte ReturnByte(byte input)
		{
			return 0;
		}

		public virtual void ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
		}

		public virtual void Reset()
		{
		}

		private void SetKey(byte[] keyBytes)
		{
		}
	}
}
