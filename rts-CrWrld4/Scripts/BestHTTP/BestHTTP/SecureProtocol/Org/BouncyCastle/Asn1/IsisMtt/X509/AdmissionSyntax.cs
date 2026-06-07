using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.X509
{
	public class AdmissionSyntax : Asn1Encodable
	{
		private readonly GeneralName admissionAuthority;

		private readonly Asn1Sequence contentsOfAdmissions;

		public virtual GeneralName AdmissionAuthority => null;

		public static AdmissionSyntax GetInstance(object obj)
		{
			return null;
		}

		private AdmissionSyntax(Asn1Sequence seq)
		{
		}

		public AdmissionSyntax(GeneralName admissionAuthority, Asn1Sequence contentsOfAdmissions)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public virtual Admissions[] GetContentsOfAdmissions()
		{
			return null;
		}
	}
}
