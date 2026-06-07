namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class V3TbsCertificateGenerator
	{
		internal DerTaggedObject version;

		internal DerInteger serialNumber;

		internal AlgorithmIdentifier signature;

		internal X509Name issuer;

		internal Time startDate;

		internal Time endDate;

		internal X509Name subject;

		internal SubjectPublicKeyInfo subjectPublicKeyInfo;

		internal X509Extensions extensions;

		private bool altNamePresentAndCritical;

		private DerBitString issuerUniqueID;

		private DerBitString subjectUniqueID;

		public void SetSerialNumber(DerInteger serialNumber)
		{
		}

		public void SetSignature(AlgorithmIdentifier signature)
		{
		}

		public void SetIssuer(X509Name issuer)
		{
		}

		public void SetStartDate(DerUtcTime startDate)
		{
		}

		public void SetStartDate(Time startDate)
		{
		}

		public void SetEndDate(DerUtcTime endDate)
		{
		}

		public void SetEndDate(Time endDate)
		{
		}

		public void SetSubject(X509Name subject)
		{
		}

		public void SetIssuerUniqueID(DerBitString uniqueID)
		{
		}

		public void SetSubjectUniqueID(DerBitString uniqueID)
		{
		}

		public void SetSubjectPublicKeyInfo(SubjectPublicKeyInfo pubKeyInfo)
		{
		}

		public void SetExtensions(X509Extensions extensions)
		{
		}

		public TbsCertificateStructure GenerateTbsCertificate()
		{
			return null;
		}
	}
}
