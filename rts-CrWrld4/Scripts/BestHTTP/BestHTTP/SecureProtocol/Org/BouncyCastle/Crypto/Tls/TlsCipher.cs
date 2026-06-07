using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public interface TlsCipher
	{
		int GetPlaintextLimit(int ciphertextLimit);

		BufferSegment EncodePlaintext(long seqNo, byte type, byte[] plaintext, int offset, int len);

		BufferSegment DecodeCiphertext(long seqNo, byte type, byte[] ciphertext, int offset, int len);
	}
}
