namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class PkiPublicationInfo : Asn1Encodable
	{
		private readonly DerInteger action;

		private readonly Asn1Sequence pubInfos;

		public virtual DerInteger Action => null;

		private PkiPublicationInfo(Asn1Sequence seq)
		{
		}

		public static PkiPublicationInfo GetInstance(object obj)
		{
			return null;
		}

		public virtual SinglePubInfo[] GetPubInfos()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
