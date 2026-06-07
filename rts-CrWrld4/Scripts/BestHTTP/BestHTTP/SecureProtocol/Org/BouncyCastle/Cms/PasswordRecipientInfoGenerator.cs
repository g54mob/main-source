using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	internal class PasswordRecipientInfoGenerator : RecipientInfoGenerator
	{
		private static readonly CmsEnvelopedHelper Helper;

		private AlgorithmIdentifier keyDerivationAlgorithm;

		private KeyParameter keyEncryptionKey;

		private string keyEncryptionKeyOID;

		internal AlgorithmIdentifier KeyDerivationAlgorithm
		{
			set
			{
			}
		}

		internal KeyParameter KeyEncryptionKey
		{
			set
			{
			}
		}

		internal string KeyEncryptionKeyOID
		{
			set
			{
			}
		}

		internal PasswordRecipientInfoGenerator()
		{
		}

		public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
		{
			return null;
		}
	}
}
