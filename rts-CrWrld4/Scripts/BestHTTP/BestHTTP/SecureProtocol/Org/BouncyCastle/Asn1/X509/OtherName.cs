namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class OtherName : Asn1Encodable
	{
		private readonly DerObjectIdentifier typeID;

		private readonly Asn1Encodable value;

		public virtual DerObjectIdentifier TypeID => null;

		public Asn1Encodable Value => null;

		public static OtherName GetInstance(object obj)
		{
			return null;
		}

		public OtherName(DerObjectIdentifier typeID, Asn1Encodable value)
		{
		}

		private OtherName(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
