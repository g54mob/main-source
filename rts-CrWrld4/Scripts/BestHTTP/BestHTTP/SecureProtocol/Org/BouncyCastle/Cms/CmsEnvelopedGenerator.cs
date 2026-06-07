using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsEnvelopedGenerator
	{
		internal static readonly short[] rc2Table;

		public static readonly string DesEde3Cbc;

		public static readonly string RC2Cbc;

		public const string IdeaCbc = "1.3.6.1.4.1.188.7.1.1.2";

		public const string Cast5Cbc = "1.2.840.113533.7.66.10";

		public static readonly string Aes128Cbc;

		public static readonly string Aes192Cbc;

		public static readonly string Aes256Cbc;

		public static readonly string Camellia128Cbc;

		public static readonly string Camellia192Cbc;

		public static readonly string Camellia256Cbc;

		public static readonly string SeedCbc;

		public static readonly string DesEde3Wrap;

		public static readonly string Aes128Wrap;

		public static readonly string Aes192Wrap;

		public static readonly string Aes256Wrap;

		public static readonly string Camellia128Wrap;

		public static readonly string Camellia192Wrap;

		public static readonly string Camellia256Wrap;

		public static readonly string SeedWrap;

		public static readonly string ECDHSha1Kdf;

		public static readonly string ECMqvSha1Kdf;

		internal readonly IList recipientInfoGenerators;

		internal readonly SecureRandom rand;

		internal CmsAttributeTableGenerator unprotectedAttributeGenerator;

		public CmsAttributeTableGenerator UnprotectedAttributeGenerator
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CmsEnvelopedGenerator()
		{
		}

		public CmsEnvelopedGenerator(SecureRandom rand)
		{
		}

		public void AddKeyTransRecipient(X509Certificate cert)
		{
		}

		public void AddKeyTransRecipient(AsymmetricKeyParameter pubKey, byte[] subKeyId)
		{
		}

		public void AddKekRecipient(string keyAlgorithm, KeyParameter key, byte[] keyIdentifier)
		{
		}

		public void AddKekRecipient(string keyAlgorithm, KeyParameter key, KekIdentifier kekIdentifier)
		{
		}

		public void AddPasswordRecipient(CmsPbeKey pbeKey, string kekAlgorithmOid)
		{
		}

		public void AddKeyAgreementRecipient(string agreementAlgorithm, AsymmetricKeyParameter senderPrivateKey, AsymmetricKeyParameter senderPublicKey, X509Certificate recipientCert, string cekWrapAlgorithm)
		{
		}

		public void AddKeyAgreementRecipients(string agreementAlgorithm, AsymmetricKeyParameter senderPrivateKey, AsymmetricKeyParameter senderPublicKey, ICollection recipientCerts, string cekWrapAlgorithm)
		{
		}

		public void AddRecipientInfoGenerator(RecipientInfoGenerator recipientInfoGenerator)
		{
		}

		protected internal virtual AlgorithmIdentifier GetAlgorithmIdentifier(string encryptionOid, KeyParameter encKey, Asn1Encodable asn1Params, out ICipherParameters cipherParameters)
		{
			cipherParameters = null;
			return null;
		}

		protected internal virtual Asn1Encodable GenerateAsn1Parameters(string encryptionOid, byte[] encKeyBytes)
		{
			return null;
		}
	}
}
