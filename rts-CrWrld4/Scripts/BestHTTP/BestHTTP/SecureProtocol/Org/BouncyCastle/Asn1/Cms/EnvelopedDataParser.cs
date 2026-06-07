namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class EnvelopedDataParser
	{
		private Asn1SequenceParser _seq;

		private DerInteger _version;

		private IAsn1Convertible _nextObject;

		private bool _originatorInfoCalled;

		public DerInteger Version => null;

		public EnvelopedDataParser(Asn1SequenceParser seq)
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

		public EncryptedContentInfoParser GetEncryptedContentInfo()
		{
			return null;
		}

		public Asn1SetParser GetUnprotectedAttrs()
		{
			return null;
		}
	}
}
