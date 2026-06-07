namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class AuthEnvelopedData : Asn1Encodable
	{
		private DerInteger version;

		private OriginatorInfo originatorInfo;

		private Asn1Set recipientInfos;

		private EncryptedContentInfo authEncryptedContentInfo;

		private Asn1Set authAttrs;

		private Asn1OctetString mac;

		private Asn1Set unauthAttrs;

		public DerInteger Version => null;

		public OriginatorInfo OriginatorInfo => null;

		public Asn1Set RecipientInfos => null;

		public EncryptedContentInfo AuthEncryptedContentInfo => null;

		public Asn1Set AuthAttrs => null;

		public Asn1OctetString Mac => null;

		public Asn1Set UnauthAttrs => null;

		public AuthEnvelopedData(OriginatorInfo originatorInfo, Asn1Set recipientInfos, EncryptedContentInfo authEncryptedContentInfo, Asn1Set authAttrs, Asn1OctetString mac, Asn1Set unauthAttrs)
		{
		}

		private AuthEnvelopedData(Asn1Sequence seq)
		{
		}

		public static AuthEnvelopedData GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static AuthEnvelopedData GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
