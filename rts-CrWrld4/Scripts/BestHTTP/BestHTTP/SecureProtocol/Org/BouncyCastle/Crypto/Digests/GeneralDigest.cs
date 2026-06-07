using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	[Il2CppEagerStaticClassConstruction]
	public abstract class GeneralDigest : IDigest, IMemoable
	{
		private const int BYTE_LENGTH = 64;

		private byte[] xBuf;

		private int xBufOff;

		private long byteCount;

		public abstract string AlgorithmName { get; }

		internal GeneralDigest()
		{
		}

		internal GeneralDigest(GeneralDigest t)
		{
		}

		protected void CopyIn(GeneralDigest t)
		{
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int length)
		{
		}

		public void Finish()
		{
		}

		public virtual void Reset()
		{
		}

		public int GetByteLength()
		{
			return 0;
		}

		internal abstract void ProcessWord(byte[] input, int inOff);

		internal abstract void ProcessLength(long bitLength);

		internal abstract void ProcessBlock();

		public abstract int GetDigestSize();

		public abstract int DoFinal(byte[] output, int outOff);

		public abstract IMemoable Copy();

		public abstract void Reset(IMemoable t);
	}
}
