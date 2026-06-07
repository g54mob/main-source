using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class Dstu7564Digest : IDigest, IMemoable
	{
		private const int NB_512 = 8;

		private const int NB_1024 = 16;

		private const int NR_512 = 10;

		private const int NR_1024 = 14;

		private int hashSize;

		private int blockSize;

		private int columns;

		private int rounds;

		private ulong[] state;

		private ulong[] tempState1;

		private ulong[] tempState2;

		private ulong inputBlocks;

		private int bufOff;

		private byte[] buf;

		private static readonly byte[] S0;

		private static readonly byte[] S1;

		private static readonly byte[] S2;

		private static readonly byte[] S3;

		public virtual string AlgorithmName => null;

		public Dstu7564Digest(Dstu7564Digest digest)
		{
		}

		private void CopyIn(Dstu7564Digest digest)
		{
		}

		public Dstu7564Digest(int hashSizeBits)
		{
		}

		public virtual int GetDigestSize()
		{
			return 0;
		}

		public virtual int GetByteLength()
		{
			return 0;
		}

		public virtual void Update(byte input)
		{
		}

		public virtual void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		protected virtual void ProcessBlock(byte[] input, int inOff)
		{
		}

		private void P(ulong[] s)
		{
		}

		private void Q(ulong[] s)
		{
		}

		private static ulong MixColumn(ulong c)
		{
			return 0uL;
		}

		private void MixColumns(ulong[] s)
		{
		}

		private static ulong Rotate(int n, ulong x)
		{
			return 0uL;
		}

		private void ShiftRows(ulong[] s)
		{
		}

		private void SubBytes(ulong[] s)
		{
		}

		public virtual IMemoable Copy()
		{
			return null;
		}

		public virtual void Reset(IMemoable other)
		{
		}
	}
}
