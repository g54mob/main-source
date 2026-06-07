namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class OtherKeyAttribute : Asn1Encodable
	{
		private DerObjectIdentifier keyAttrId;

		private Asn1Encodable keyAttr;

		public DerObjectIdentifier KeyAttrId => null;

		public Asn1Encodable KeyAttr => null;

		public static OtherKeyAttribute GetInstance(object obj)
		{
			return null;
		}

		public OtherKeyAttribute(Asn1Sequence seq)
		{
		}

		public OtherKeyAttribute(DerObjectIdentifier keyAttrId, Asn1Encodable keyAttr)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
