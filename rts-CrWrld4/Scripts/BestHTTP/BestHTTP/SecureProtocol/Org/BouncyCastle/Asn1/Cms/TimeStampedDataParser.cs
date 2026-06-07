namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class TimeStampedDataParser
	{
		private DerInteger version;

		private DerIA5String dataUri;

		private MetaData metaData;

		private Asn1OctetStringParser content;

		private Evidence temporalEvidence;

		private Asn1SequenceParser parser;

		public virtual DerIA5String DataUri => null;

		public virtual MetaData MetaData => null;

		public virtual Asn1OctetStringParser Content => null;

		private TimeStampedDataParser(Asn1SequenceParser parser)
		{
		}

		public static TimeStampedDataParser GetInstance(object obj)
		{
			return null;
		}

		public virtual Evidence GetTemporalEvidence()
		{
			return null;
		}
	}
}
