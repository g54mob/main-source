namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class AuthEnvelopedDataParser
	{
		private Asn1SequenceParser seq;

		private DerInteger version;

		private IAsn1Convertible nextObject;

		private bool originatorInfoCalled;

		public DerInteger Version => null;

		public AuthEnvelopedDataParser(Asn1SequenceParser seq)
		{
		}

		public OriginatorInfo GetOriginatorInfo()
		{
			return null;
		}

		public Asn1SetParser GetRecipientInfos()
		{
			return null;
		}

		public EncryptedContentInfoParser GetAuthEncryptedContentInfo()
		{
			return null;
		}

		public Asn1SetParser GetAuthAttrs()
		{
			return null;
		}

		public Asn1OctetString GetMac()
		{
			return null;
		}

		public Asn1SetParser GetUnauthAttrs()
		{
			return null;
		}
	}
}
