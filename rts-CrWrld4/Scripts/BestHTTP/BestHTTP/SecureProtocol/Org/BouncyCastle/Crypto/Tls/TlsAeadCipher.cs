using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	[Il2CppEagerStaticClassConstruction]
	public sealed class TlsAeadCipher : TlsCipher
	{
		public const int NONCE_RFC5288 = 1;

		internal const int NONCE_DRAFT_CHACHA20_POLY1305 = 2;

		protected readonly TlsContext context;

		protected readonly int macSize;

		protected readonly int record_iv_length;

		protected readonly IAeadBlockCipher encryptCipher;

		protected readonly IAeadBlockCipher decryptCipher;

		protected readonly byte[] encryptImplicitNonce;

		protected readonly byte[] decryptImplicitNonce;

		protected readonly int nonceMode;

		public TlsAeadCipher(TlsContext context, IAeadBlockCipher clientWriteCipher, IAeadBlockCipher serverWriteCipher, int cipherKeySize, int macSize)
		{
		}

		internal TlsAeadCipher(TlsContext context, IAeadBlockCipher clientWriteCipher, IAeadBlockCipher serverWriteCipher, int cipherKeySize, int macSize, int nonceMode)
		{
		}

		public int GetPlaintextLimit(int ciphertextLimit)
		{
			return 0;
		}

		public BufferSegment EncodePlaintext(long seqNo, byte type, byte[] plaintext, int offset, int len)
		{
			return default(BufferSegment);
		}

		public BufferSegment DecodeCiphertext(long seqNo, byte type, byte[] ciphertext, int offset, int len)
		{
			return default(BufferSegment);
		}

		protected byte[] GetAdditionalData(long seqNo, byte type, int len)
		{
			return null;
		}
	}
}
