namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class Attribute : Asn1Encodable
	{
		private DerObjectIdentifier attrType;

		private Asn1Set attrValues;

		public DerObjectIdentifier AttrType => null;

		public Asn1Set AttrValues => null;

		public static Attribute GetInstance(object obj)
		{
			return null;
		}

		public Attribute(Asn1Sequence seq)
		{
		}

		public Attribute(DerObjectIdentifier attrType, Asn1Set attrValues)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
