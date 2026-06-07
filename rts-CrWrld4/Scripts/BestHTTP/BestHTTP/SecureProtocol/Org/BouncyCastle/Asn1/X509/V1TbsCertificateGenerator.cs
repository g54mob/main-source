namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class V1TbsCertificateGenerator
	{
		internal DerTaggedObject version;

		internal DerInteger serialNumber;

		internal AlgorithmIdentifier signature;

		internal X509Name issuer;

		internal Time startDate;

		internal Time endDate;

		internal X509Name subject;

		internal SubjectPublicKeyInfo subjectPublicKeyInfo;

		public void SetSerialNumber(DerInteger serialNumber)
		{
		}

		public void SetSignature(AlgorithmIdentifier signature)
		{
		}

		public void SetIssuer(X509Name issuer)
		{
		}

		public void SetStartDate(Time startDate)
		{
		}

		public void SetStartDate(DerUtcTime startDate)
		{
		}

		public void SetEndDate(Time endDate)
		{
		}

		public void SetEndDate(DerUtcTime endDate)
		{
		}

		public void SetSubject(X509Name subject)
		{
		}

		public void SetSubjectPublicKeyInfo(SubjectPublicKeyInfo pubKeyInfo)
		{
		}

		public TbsCertificateStructure GenerateTbsCertificate()
		{
			return null;
		}
	}
}
