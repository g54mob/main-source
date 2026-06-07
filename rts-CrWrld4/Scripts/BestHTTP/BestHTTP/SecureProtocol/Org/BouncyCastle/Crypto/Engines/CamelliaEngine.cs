namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class CamelliaEngine : IBlockCipher
	{
		private bool initialised;

		private bool _keyIs128;

		private const int BLOCK_SIZE = 16;

		private uint[] subkey;

		private uint[] kw;

		private uint[] ke;

		private uint[] state;

		private static readonly uint[] SIGMA;

		private static readonly uint[] SBOX1_1110;

		private static readonly uint[] SBOX4_4404;

		private static readonly uint[] SBOX2_0222;

		private static readonly uint[] SBOX3_3033;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		private static uint rightRotate(uint x, int s)
		{
			return 0u;
		}

		private static uint leftRotate(uint x, int s)
		{
			return 0u;
		}

		private static void roldq(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
		{
		}

		private static void decroldq(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
		{
		}

		private static void roldqo32(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
		{
		}

		private static void decroldqo32(int rot, uint[] ki, int ioff, uint[] ko, int ooff)
		{
		}

		private static uint bytes2uint(byte[] src, int offset)
		{
			return 0u;
		}

		private static void uint2bytes(uint word, byte[] dst, int offset)
		{
		}

		private static void camelliaF2(uint[] s, uint[] skey, int keyoff)
		{
		}

		private static void camelliaFLs(uint[] s, uint[] fkey, int keyoff)
		{
		}

		private void setKey(bool forEncryption, byte[] key)
		{
		}

		private int processBlock128(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		private int processBlock192or256(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}
	}
}
