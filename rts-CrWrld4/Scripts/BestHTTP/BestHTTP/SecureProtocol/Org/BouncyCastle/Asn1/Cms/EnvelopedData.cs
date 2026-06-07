namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class EnvelopedData : Asn1Encodable
	{
		private DerInteger version;

		private OriginatorInfo originatorInfo;

		private Asn1Set recipientInfos;

		private EncryptedContentInfo encryptedContentInfo;

		private Asn1Set unprotectedAttrs;

		public DerInteger Version => null;

		public OriginatorInfo OriginatorInfo => null;

		public Asn1Set RecipientInfos => null;

		public EncryptedContentInfo EncryptedContentInfo => null;

		public Asn1Set UnprotectedAttrs => null;

		public EnvelopedData(OriginatorInfo originatorInfo, Asn1Set recipientInfos, EncryptedContentInfo encryptedContentInfo, Asn1Set unprotectedAttrs)
		{
		}

		public EnvelopedData(OriginatorInfo originatorInfo, Asn1Set recipientInfos, EncryptedContentInfo encryptedContentInfo, Attributes unprotectedAttrs)
		{
		}

		public EnvelopedData(Asn1Sequence seq)
		{
		}

		public static EnvelopedData GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static EnvelopedData GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public static int CalculateVersion(OriginatorInfo originatorInfo, Asn1Set recipientInfos, Asn1Set unprotectedAttrs)
		{
			return 0;
		}
	}
}
