namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class SigPolicyQualifierInfo : Asn1Encodable
	{
		private readonly DerObjectIdentifier sigPolicyQualifierId;

		private readonly Asn1Object sigQualifier;

		public DerObjectIdentifier SigPolicyQualifierId => null;

		public Asn1Object SigQualifier => null;

		public static SigPolicyQualifierInfo GetInstance(object obj)
		{
			return null;
		}

		private SigPolicyQualifierInfo(Asn1Sequence seq)
		{
		}

		public SigPolicyQualifierInfo(DerObjectIdentifier sigPolicyQualifierId, Asn1Encodable sigQualifier)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
