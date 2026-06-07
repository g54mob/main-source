using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.PlatformSupport.Memory;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	[Il2CppEagerStaticClassConstruction]
	public sealed class Chacha20Poly1305 : TlsCipher
	{
		private static readonly byte[] Zeroes;

		protected readonly TlsContext context;

		protected readonly ChaCha7539Engine encryptCipher;

		protected readonly ChaCha7539Engine decryptCipher;

		protected readonly byte[] encryptIV;

		protected readonly byte[] decryptIV;

		public Chacha20Poly1305(TlsContext context)
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

		protected KeyParameter InitRecord(IStreamCipher cipher, bool forEncryption, long seqNo, byte[] iv)
		{
			return null;
		}

		protected byte[] CalculateNonce(long seqNo, byte[] iv)
		{
			return null;
		}

		protected KeyParameter GenerateRecordMacKey(IStreamCipher cipher)
		{
			return null;
		}

		protected BufferSegment CalculateRecordMac(KeyParameter macKey, BufferSegment additionalData, byte[] buf, int off, int len)
		{
			return default(BufferSegment);
		}

		protected void UpdateRecordMacLength(Poly1305 mac, int len)
		{
		}

		protected void UpdateRecordMacText(Poly1305 mac, BufferSegment buf)
		{
		}

		protected BufferSegment GetAdditionalData(long seqNo, byte type, int len)
		{
			return default(BufferSegment);
		}
	}
}
