using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Gost3411Digest : IDigest, IMemoable
	{
		private const int DIGEST_LENGTH = 32;

		private byte[] H;

		private byte[] L;

		private byte[] M;

		private byte[] Sum;

		private byte[][] C;

		private byte[] xBuf;

		private int xBufOff;

		private ulong byteCount;

		private readonly IBlockCipher cipher;

		private byte[] sBox;

		private byte[] K;

		private byte[] a;

		internal short[] wS;

		internal short[] w_S;

		internal byte[] S;

		internal byte[] U;

		internal byte[] V;

		internal byte[] W;

		private static readonly byte[] C2;

		public string AlgorithmName => null;

		private static byte[][] MakeC()
		{
			return null;
		}

		public Gost3411Digest()
		{
		}

		public Gost3411Digest(byte[] sBoxParam)
		{
		}

		public Gost3411Digest(Gost3411Digest t)
		{
		}

		public int GetDigestSize()
		{
			return 0;
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		private byte[] P(byte[] input)
		{
			return null;
		}

		private byte[] A(byte[] input)
		{
			return null;
		}

		private void E(byte[] key, byte[] s, int sOff, byte[] input, int inOff)
		{
		}

		private void fw(byte[] input)
		{
		}

		private void processBlock(byte[] input, int inOff)
		{
		}

		private void finish()
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		private void sumByteArray(byte[] input)
		{
		}

		private static void cpyBytesToShort(byte[] S, short[] wS)
		{
		}

		private static void cpyShortToBytes(short[] wS, byte[] S)
		{
		}

		public int GetByteLength()
		{
			return 0;
		}

		public IMemoable Copy()
		{
			return null;
		}

		public void Reset(IMemoable other)
		{
		}
	}
}
