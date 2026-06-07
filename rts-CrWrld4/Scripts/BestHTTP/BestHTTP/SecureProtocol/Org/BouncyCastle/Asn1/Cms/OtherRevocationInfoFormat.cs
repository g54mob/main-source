namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class OtherRevocationInfoFormat : Asn1Encodable
	{
		private readonly DerObjectIdentifier otherRevInfoFormat;

		private readonly Asn1Encodable otherRevInfo;

		public virtual DerObjectIdentifier InfoFormat => null;

		public virtual Asn1Encodable Info => null;

		public OtherRevocationInfoFormat(DerObjectIdentifier otherRevInfoFormat, Asn1Encodable otherRevInfo)
		{
		}

		private OtherRevocationInfoFormat(Asn1Sequence seq)
		{
		}

		public static OtherRevocationInfoFormat GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static OtherRevocationInfoFormat GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
