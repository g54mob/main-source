using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsEnvelopedData
	{
		internal RecipientInformationStore recipientInfoStore;

		internal ContentInfo contentInfo;

		private AlgorithmIdentifier encAlg;

		private Asn1Set unprotectedAttributes;

		public AlgorithmIdentifier EncryptionAlgorithmID => null;

		public string EncryptionAlgOid => null;

		public ContentInfo ContentInfo => null;

		public CmsEnvelopedData(byte[] envelopedData)
		{
		}

		public CmsEnvelopedData(Stream envelopedData)
		{
		}

		public CmsEnvelopedData(ContentInfo contentInfo)
		{
		}

		public RecipientInformationStore GetRecipientInfos()
		{
			return null;
		}

		public BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable GetUnprotectedAttributes()
		{
			return null;
		}

		public byte[] GetEncoded()
		{
			return null;
		}
	}
}
