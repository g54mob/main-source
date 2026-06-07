namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class CrlEntry : Asn1Encodable
	{
		internal Asn1Sequence seq;

		internal DerInteger userCertificate;

		internal Time revocationDate;

		internal X509Extensions crlEntryExtensions;

		public DerInteger UserCertificate => null;

		public Time RevocationDate => null;

		public X509Extensions Extensions => null;

		public CrlEntry(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
