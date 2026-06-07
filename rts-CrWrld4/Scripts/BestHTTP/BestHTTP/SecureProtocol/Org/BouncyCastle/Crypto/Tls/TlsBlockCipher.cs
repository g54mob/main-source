using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	[Il2CppEagerStaticClassConstruction]
	public class TlsBlockCipher : TlsCipher
	{
		protected readonly TlsContext context;

		protected readonly byte[] randomData;

		protected readonly bool useExplicitIV;

		protected readonly bool encryptThenMac;

		protected readonly IBlockCipher encryptCipher;

		protected readonly IBlockCipher decryptCipher;

		protected readonly TlsMac mWriteMac;

		protected readonly TlsMac mReadMac;

		private byte[] explicitIV;

		public virtual TlsMac WriteMac => null;

		public virtual TlsMac ReadMac => null;

		public TlsBlockCipher(TlsContext context, IBlockCipher clientWriteCipher, IBlockCipher serverWriteCipher, IDigest clientWriteDigest, IDigest serverWriteDigest, int cipherKeySize)
		{
		}

		public virtual int GetPlaintextLimit(int ciphertextLimit)
		{
			return 0;
		}

		public virtual BufferSegment EncodePlaintext(long seqNo, byte type, byte[] plaintext, int offset, int len)
		{
			return default(BufferSegment);
		}

		public virtual BufferSegment DecodeCiphertext(long seqNo, byte type, byte[] ciphertext, int offset, int len)
		{
			return default(BufferSegment);
		}

		protected virtual int CheckPaddingConstantTime(byte[] buf, int off, int len, int blockSize, int macSize)
		{
			return 0;
		}

		protected virtual int ChooseExtraPadBlocks(SecureRandom r, int max)
		{
			return 0;
		}

		protected virtual int LowestBitSet(int x)
		{
			return 0;
		}
	}
}
