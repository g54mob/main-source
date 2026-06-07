using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public abstract class Gost3411_2012Digest : IDigest, IMemoable
	{
		private readonly byte[] IV;

		private readonly byte[] N;

		private readonly byte[] Sigma;

		private readonly byte[] Ki;

		private readonly byte[] m;

		private readonly byte[] h;

		private readonly byte[] tmp;

		private readonly byte[] block;

		private int bOff;

		private static readonly byte[][] C;

		private static readonly byte[] Zero;

		private static readonly ulong[][] T;

		public abstract string AlgorithmName { get; }

		protected Gost3411_2012Digest(byte[] IV)
		{
		}

		public abstract IMemoable Copy();

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public int GetByteLength()
		{
			return 0;
		}

		public abstract int GetDigestSize();

		public void Reset()
		{
		}

		public void Reset(IMemoable other)
		{
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		private void F(byte[] V)
		{
		}

		private void xor512(byte[] A, byte[] B)
		{
		}

		private void E(byte[] K, byte[] m)
		{
		}

		private void g_N(byte[] h, byte[] N, byte[] m)
		{
		}

		private void addMod512(byte[] A, int num)
		{
		}

		private void addMod512(byte[] A, byte[] B)
		{
		}

		private void reverse(byte[] src, byte[] dst)
		{
		}
	}
}
