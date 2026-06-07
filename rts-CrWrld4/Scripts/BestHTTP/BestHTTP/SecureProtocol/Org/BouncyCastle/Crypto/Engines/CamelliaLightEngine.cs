namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class CamelliaLightEngine : IBlockCipher
	{
		private const int BLOCK_SIZE = 16;

		private bool initialised;

		private bool _keyis128;

		private uint[] subkey;

		private uint[] kw;

		private uint[] ke;

		private uint[] state;

		private static readonly uint[] SIGMA;

		private static readonly byte[] SBOX1;

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

		private byte lRot8(byte v, int rot)
		{
			return 0;
		}

		private uint sbox2(int x)
		{
			return 0u;
		}

		private uint sbox3(int x)
		{
			return 0u;
		}

		private uint sbox4(int x)
		{
			return 0u;
		}

		private void camelliaF2(uint[] s, uint[] skey, int keyoff)
		{
		}

		private void camelliaFLs(uint[] s, uint[] fkey, int keyoff)
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

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
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
