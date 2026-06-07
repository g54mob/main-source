namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CAKeyUpdAnnContent : Asn1Encodable
	{
		private readonly CmpCertificate oldWithNew;

		private readonly CmpCertificate newWithOld;

		private readonly CmpCertificate newWithNew;

		public virtual CmpCertificate OldWithNew => null;

		public virtual CmpCertificate NewWithOld => null;

		public virtual CmpCertificate NewWithNew => null;

		private CAKeyUpdAnnContent(Asn1Sequence seq)
		{
		}

		public static CAKeyUpdAnnContent GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
