namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class AccessDescription : Asn1Encodable
	{
		public static readonly DerObjectIdentifier IdADCAIssuers;

		public static readonly DerObjectIdentifier IdADOcsp;

		private readonly DerObjectIdentifier accessMethod;

		private readonly GeneralName accessLocation;

		public DerObjectIdentifier AccessMethod => null;

		public GeneralName AccessLocation => null;

		public static AccessDescription GetInstance(object obj)
		{
			return null;
		}

		private AccessDescription(Asn1Sequence seq)
		{
		}

		public AccessDescription(DerObjectIdentifier oid, GeneralName location)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
