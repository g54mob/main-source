using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class AuthenticatedDataParser
	{
		private Asn1SequenceParser seq;

		private DerInteger version;

		private IAsn1Convertible nextObject;

		private bool originatorInfoCalled;

		public DerInteger Version => null;

		public AuthenticatedDataParser(Asn1SequenceParser seq)
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

		public AlgorithmIdentifier GetMacAlgorithm()
		{
			return null;
		}

		public AlgorithmIdentifier GetDigestAlgorithm()
		{
			return null;
		}

		public ContentInfoParser GetEnapsulatedContentInfo()
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
