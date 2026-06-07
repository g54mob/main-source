using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class KeyTransRecipientInfoGenerator : RecipientInfoGenerator
	{
		private static readonly CmsEnvelopedHelper Helper;

		private TbsCertificateStructure recipientTbsCert;

		private AsymmetricKeyParameter recipientPublicKey;

		private Asn1OctetString subjectKeyIdentifier;

		private SubjectPublicKeyInfo info;

		private IssuerAndSerialNumber issuerAndSerialNumber;

		private SecureRandom random;

		internal X509Certificate RecipientCert
		{
			set
			{
			}
		}

		internal AsymmetricKeyParameter RecipientPublicKey
		{
			set
			{
			}
		}

		internal Asn1OctetString SubjectKeyIdentifier
		{
			set
			{
			}
		}

		protected virtual AlgorithmIdentifier AlgorithmDetails => null;

		internal KeyTransRecipientInfoGenerator()
		{
		}

		protected KeyTransRecipientInfoGenerator(IssuerAndSerialNumber issuerAndSerialNumber)
		{
		}

		protected KeyTransRecipientInfoGenerator(byte[] subjectKeyIdentifier)
		{
		}

		public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
		{
			return null;
		}

		protected virtual byte[] GenerateWrappedKey(KeyParameter contentEncryptionKey)
		{
			return null;
		}
	}
}
