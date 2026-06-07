using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class PkiArchiveControlBuilder
	{
		private CmsEnvelopedDataGenerator envGen;

		private CmsProcessableByteArray keyContent;

		public PkiArchiveControlBuilder(PrivateKeyInfo privateKeyInfo, GeneralName generalName)
		{
		}

		public PkiArchiveControlBuilder AddRecipientGenerator(RecipientInfoGenerator recipientGen)
		{
			return null;
		}

		public PkiArchiveControl Build(ICipherBuilderWithKey contentEncryptor)
		{
			return null;
		}
	}
}
