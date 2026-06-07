using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class Admissions : Asn1Encodable
	{
		private readonly GeneralName admissionAuthority;

		private readonly NamingAuthority namingAuthority;

		private readonly Asn1Sequence professionInfos;

		public virtual GeneralName AdmissionAuthority => null;

		public virtual NamingAuthority NamingAuthority => null;

		public static Admissions GetInstance(object obj)
		{
			return null;
		}

		private Admissions(Asn1Sequence seq)
		{
		}

		public Admissions(GeneralName admissionAuthority, NamingAuthority namingAuthority, ProfessionInfo[] professionInfos)
		{
		}

		public ProfessionInfo[] GetProfessionInfos()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
