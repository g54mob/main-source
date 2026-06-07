namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Esf
{
	public class CommitmentTypeIndication : Asn1Encodable
	{
		private readonly DerObjectIdentifier commitmentTypeId;

		private readonly Asn1Sequence commitmentTypeQualifier;

		public DerObjectIdentifier CommitmentTypeID => null;

		public Asn1Sequence CommitmentTypeQualifier => null;

		public static CommitmentTypeIndication GetInstance(object obj)
		{
			return null;
		}

		public CommitmentTypeIndication(Asn1Sequence seq)
		{
		}

		public CommitmentTypeIndication(DerObjectIdentifier commitmentTypeId)
		{
		}

		public CommitmentTypeIndication(DerObjectIdentifier commitmentTypeId, Asn1Sequence commitmentTypeQualifier)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
