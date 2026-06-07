using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsStreamCipher : TlsCipher
	{
		protected readonly TlsContext context;

		protected readonly IStreamCipher encryptCipher;

		protected readonly IStreamCipher decryptCipher;

		protected readonly TlsMac writeMac;

		protected readonly TlsMac readMac;

		protected readonly bool usesNonce;

		public TlsStreamCipher(TlsContext context, IStreamCipher clientWriteCipher, IStreamCipher serverWriteCipher, IDigest clientWriteDigest, IDigest serverWriteDigest, int cipherKeySize, bool usesNonce)
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

		protected virtual void CheckMac(long seqNo, byte type, byte[] recBuf, int recStart, int recEnd, byte[] calcBuf, int calcOff, int calcLen)
		{
		}

		protected virtual void UpdateIV(IStreamCipher cipher, bool forEncryption, long seqNo)
		{
		}
	}
}
