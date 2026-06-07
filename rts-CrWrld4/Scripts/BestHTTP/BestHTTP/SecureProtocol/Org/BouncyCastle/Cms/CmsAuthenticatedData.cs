using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsAuthenticatedData
	{
		internal RecipientInformationStore recipientInfoStore;

		internal ContentInfo contentInfo;

		private AlgorithmIdentifier macAlg;

		private Asn1Set authAttrs;

		private Asn1Set unauthAttrs;

		private byte[] mac;

		public AlgorithmIdentifier MacAlgorithmID => null;

		public string MacAlgOid => null;

		public ContentInfo ContentInfo => null;

		public CmsAuthenticatedData(byte[] authData)
		{
		}

		public CmsAuthenticatedData(Stream authData)
		{
		}

		public CmsAuthenticatedData(ContentInfo contentInfo)
		{
		}

		public byte[] GetMac()
		{
			return null;
		}

		public RecipientInformationStore GetRecipientInfos()
		{
			return null;
		}

		public BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable GetAuthAttrs()
		{
			return null;
		}

		public BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms.AttributeTable GetUnauthAttrs()
		{
			return null;
		}

		public byte[] GetEncoded()
		{
			return null;
		}
	}
}
