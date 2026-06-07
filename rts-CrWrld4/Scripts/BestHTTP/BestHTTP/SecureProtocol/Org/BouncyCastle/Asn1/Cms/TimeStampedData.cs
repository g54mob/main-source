namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class TimeStampedData : Asn1Encodable
	{
		private DerInteger version;

		private DerIA5String dataUri;

		private MetaData metaData;

		private Asn1OctetString content;

		private Evidence temporalEvidence;

		public virtual DerIA5String DataUri => null;

		public MetaData MetaData => null;

		public Asn1OctetString Content => null;

		public Evidence TemporalEvidence => null;

		public TimeStampedData(DerIA5String dataUri, MetaData metaData, Asn1OctetString content, Evidence temporalEvidence)
		{
		}

		private TimeStampedData(Asn1Sequence seq)
		{
		}

		public static TimeStampedData GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
