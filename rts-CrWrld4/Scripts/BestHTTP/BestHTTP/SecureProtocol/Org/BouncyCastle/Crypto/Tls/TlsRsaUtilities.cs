using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class TlsRsaUtilities
	{
		public static byte[] GenerateEncryptedPreMasterSecret(TlsContext context, RsaKeyParameters rsaServerPublicKey, Stream output)
		{
			return null;
		}

		public static byte[] SafeDecryptPreMasterSecret(TlsContext context, RsaKeyParameters rsaServerPrivateKey, byte[] encryptedPreMasterSecret)
		{
			return null;
		}
	}
}
