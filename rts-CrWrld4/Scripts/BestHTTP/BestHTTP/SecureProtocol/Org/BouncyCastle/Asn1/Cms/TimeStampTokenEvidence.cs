namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class TimeStampTokenEvidence : Asn1Encodable
	{
		private TimeStampAndCrl[] timeStampAndCrls;

		public TimeStampTokenEvidence(TimeStampAndCrl[] timeStampAndCrls)
		{
		}

		public TimeStampTokenEvidence(TimeStampAndCrl timeStampAndCrl)
		{
		}

		private TimeStampTokenEvidence(Asn1Sequence seq)
		{
		}

		public static TimeStampTokenEvidence GetInstance(Asn1TaggedObject tagged, bool isExplicit)
		{
			return null;
		}

		public static TimeStampTokenEvidence GetInstance(object obj)
		{
			return null;
		}

		public virtual TimeStampAndCrl[] ToTimeStampAndCrlArray()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
