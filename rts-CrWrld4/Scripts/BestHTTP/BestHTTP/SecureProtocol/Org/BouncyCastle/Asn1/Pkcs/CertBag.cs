namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class CertBag : Asn1Encodable
	{
		private readonly DerObjectIdentifier certID;

		private readonly Asn1Object certValue;

		public virtual DerObjectIdentifier CertID => null;

		public virtual Asn1Object CertValue => null;

		public static CertBag GetInstance(object obj)
		{
			return null;
		}

		public CertBag(Asn1Sequence seq)
		{
		}

		public CertBag(DerObjectIdentifier certID, Asn1Object certValue)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
