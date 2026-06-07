namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class PolicyInformation : Asn1Encodable
	{
		private readonly DerObjectIdentifier policyIdentifier;

		private readonly Asn1Sequence policyQualifiers;

		public DerObjectIdentifier PolicyIdentifier => null;

		public Asn1Sequence PolicyQualifiers => null;

		private PolicyInformation(Asn1Sequence seq)
		{
		}

		public PolicyInformation(DerObjectIdentifier policyIdentifier)
		{
		}

		public PolicyInformation(DerObjectIdentifier policyIdentifier, Asn1Sequence policyQualifiers)
		{
		}

		public static PolicyInformation GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
