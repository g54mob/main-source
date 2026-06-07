namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class HC128Engine : IStreamCipher
	{
		private uint[] p;

		private uint[] q;

		private uint cnt;

		private byte[] key;

		private byte[] iv;

		private bool initialised;

		private byte[] buf;

		private int idx;

		public virtual string AlgorithmName => null;

		private static uint F1(uint x)
		{
			return 0u;
		}

		private static uint F2(uint x)
		{
			return 0u;
		}

		private uint G1(uint x, uint y, uint z)
		{
			return 0u;
		}

		private uint G2(uint x, uint y, uint z)
		{
			return 0u;
		}

		private static uint RotateLeft(uint x, int bits)
		{
			return 0u;
		}

		private static uint RotateRight(uint x, int bits)
		{
			return 0u;
		}

		private uint H1(uint x)
		{
			return 0u;
		}

		private uint H2(uint x)
		{
			return 0u;
		}

		private static uint Mod1024(uint x)
		{
			return 0u;
		}

		private static uint Mod512(uint x)
		{
			return 0u;
		}

		private static uint Dim(uint x, uint y)
		{
			return 0u;
		}

		private uint Step()
		{
			return 0u;
		}

		private void Init()
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		private byte GetByte()
		{
			return 0;
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
