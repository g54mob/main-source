namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CommitmentTypeQualifier : Asn1Encodable
	{
		private readonly DerObjectIdentifier commitmentTypeIdentifier;

		private readonly Asn1Object qualifier;

		public DerObjectIdentifier CommitmentTypeIdentifier => null;

		public Asn1Object Qualifier => null;

		public CommitmentTypeQualifier(DerObjectIdentifier commitmentTypeIdentifier)
		{
		}

		public CommitmentTypeQualifier(DerObjectIdentifier commitmentTypeIdentifier, Asn1Encodable qualifier)
		{
		}

		public CommitmentTypeQualifier(Asn1Sequence seq)
		{
		}

		public static CommitmentTypeQualifier GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
