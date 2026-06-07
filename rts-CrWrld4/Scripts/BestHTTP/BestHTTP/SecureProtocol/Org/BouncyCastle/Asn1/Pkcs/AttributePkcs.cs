namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class AttributePkcs : Asn1Encodable
	{
		private readonly DerObjectIdentifier attrType;

		private readonly Asn1Set attrValues;

		public DerObjectIdentifier AttrType => null;

		public Asn1Set AttrValues => null;

		public static AttributePkcs GetInstance(object obj)
		{
			return null;
		}

		private AttributePkcs(Asn1Sequence seq)
		{
		}

		public AttributePkcs(DerObjectIdentifier attrType, Asn1Set attrValues)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
