namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class Evidence : Asn1Encodable, IAsn1Choice
	{
		private TimeStampTokenEvidence tstEvidence;

		private Asn1Sequence otherEvidence;

		public virtual TimeStampTokenEvidence TstEvidence => null;

		public Evidence(TimeStampTokenEvidence tstEvidence)
		{
		}

		private Evidence(Asn1TaggedObject tagged)
		{
		}

		public static Evidence GetInstance(object obj)
		{
			return null;
		}

		public static Evidence GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
