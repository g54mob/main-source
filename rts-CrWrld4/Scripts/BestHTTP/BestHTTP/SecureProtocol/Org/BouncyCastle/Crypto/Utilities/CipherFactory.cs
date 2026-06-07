using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Utilities
{
	public class CipherFactory
	{
		private static readonly short[] rc2Ekb;

		private CipherFactory()
		{
		}

		public static object CreateContentCipher(bool forEncryption, ICipherParameters encKey, AlgorithmIdentifier encryptionAlgID)
		{
			return null;
		}

		private static BufferedBlockCipher CreateCipher(DerObjectIdentifier algorithm)
		{
			return null;
		}
	}
}
