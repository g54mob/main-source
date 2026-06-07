namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class SignedDataParser
	{
		private Asn1SequenceParser _seq;

		private DerInteger _version;

		private object _nextObject;

		private bool _certsCalled;

		private bool _crlsCalled;

		public DerInteger Version => null;

		public static SignedDataParser GetInstance(object o)
		{
			return null;
		}

		public SignedDataParser(Asn1SequenceParser seq)
		{
		}

		public Asn1SetParser GetDigestAlgorithms()
		{
			return null;
		}

		public ContentInfoParser GetEncapContentInfo()
		{
			return null;
		}

		public Asn1SetParser GetCertificates()
		{
			return null;
		}

		public Asn1SetParser GetCrls()
		{
			return null;
		}

		public Asn1SetParser GetSignerInfos()
		{
			return null;
		}
	}
}
