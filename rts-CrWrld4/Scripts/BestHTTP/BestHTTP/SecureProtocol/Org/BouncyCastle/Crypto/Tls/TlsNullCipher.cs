using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsNullCipher : TlsCipher
	{
		protected readonly TlsContext context;

		protected readonly TlsMac writeMac;

		protected readonly TlsMac readMac;

		public TlsNullCipher(TlsContext context)
		{
		}

		public TlsNullCipher(TlsContext context, IDigest clientWriteDigest, IDigest serverWriteDigest)
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
	}
}
