namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class InfoTypeAndValue : Asn1Encodable
	{
		private readonly DerObjectIdentifier infoType;

		private readonly Asn1Encodable infoValue;

		public virtual DerObjectIdentifier InfoType => null;

		public virtual Asn1Encodable InfoValue => null;

		private InfoTypeAndValue(Asn1Sequence seq)
		{
		}

		public static InfoTypeAndValue GetInstance(object obj)
		{
			return null;
		}

		public InfoTypeAndValue(DerObjectIdentifier infoType)
		{
		}

		public InfoTypeAndValue(DerObjectIdentifier infoType, Asn1Encodable optionalValue)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
