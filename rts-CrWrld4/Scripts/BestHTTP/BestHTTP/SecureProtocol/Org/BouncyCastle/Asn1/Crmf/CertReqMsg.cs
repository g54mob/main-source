namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class CertReqMsg : Asn1Encodable
	{
		private readonly CertRequest certReq;

		private readonly ProofOfPossession popo;

		private readonly Asn1Sequence regInfo;

		public virtual CertRequest CertReq => null;

		public virtual ProofOfPossession Popo => null;

		private CertReqMsg(Asn1Sequence seq)
		{
		}

		public static CertReqMsg GetInstance(object obj)
		{
			return null;
		}

		public static CertReqMsg GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public CertReqMsg(CertRequest certReq, ProofOfPossession popo, AttributeTypeAndValue[] regInfo)
		{
		}

		public virtual AttributeTypeAndValue[] GetRegInfo()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
