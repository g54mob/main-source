using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public class Pkcs8EncryptedPrivateKeyInfoBuilder
	{
		private PrivateKeyInfo privateKeyInfo;

		public Pkcs8EncryptedPrivateKeyInfoBuilder(byte[] privateKeyInfo)
		{
		}

		public Pkcs8EncryptedPrivateKeyInfoBuilder(PrivateKeyInfo privateKeyInfo)
		{
		}

		public Pkcs8EncryptedPrivateKeyInfo Build(ICipherBuilder encryptor)
		{
			return null;
		}
	}
}
