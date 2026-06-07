namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class PolicyQualifierInfo : Asn1Encodable
	{
		private readonly DerObjectIdentifier policyQualifierId;

		private readonly Asn1Encodable qualifier;

		public virtual DerObjectIdentifier PolicyQualifierId => null;

		public virtual Asn1Encodable Qualifier => null;

		public PolicyQualifierInfo(DerObjectIdentifier policyQualifierId, Asn1Encodable qualifier)
		{
		}

		public PolicyQualifierInfo(string cps)
		{
		}

		private PolicyQualifierInfo(Asn1Sequence seq)
		{
		}

		public static PolicyQualifierInfo GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
