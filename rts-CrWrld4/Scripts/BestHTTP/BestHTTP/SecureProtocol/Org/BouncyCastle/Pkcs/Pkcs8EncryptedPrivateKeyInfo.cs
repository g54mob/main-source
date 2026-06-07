using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public class Pkcs8EncryptedPrivateKeyInfo
	{
		private EncryptedPrivateKeyInfo encryptedPrivateKeyInfo;

		private static EncryptedPrivateKeyInfo parseBytes(byte[] pkcs8Encoding)
		{
			return null;
		}

		public Pkcs8EncryptedPrivateKeyInfo(EncryptedPrivateKeyInfo encryptedPrivateKeyInfo)
		{
		}

		public Pkcs8EncryptedPrivateKeyInfo(byte[] encryptedPrivateKeyInfo)
		{
		}

		public EncryptedPrivateKeyInfo ToAsn1Structure()
		{
			return null;
		}

		public byte[] GetEncryptedData()
		{
			return null;
		}

		public byte[] GetEncoded()
		{
			return null;
		}

		public PrivateKeyInfo DecryptPrivateKeyInfo(IDecryptorBuilderProvider inputDecryptorProvider)
		{
			return null;
		}
	}
}
