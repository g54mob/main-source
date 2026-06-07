namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class V2Form : Asn1Encodable
	{
		internal GeneralNames issuerName;

		internal IssuerSerial baseCertificateID;

		internal ObjectDigestInfo objectDigestInfo;

		public GeneralNames IssuerName => null;

		public IssuerSerial BaseCertificateID => null;

		public ObjectDigestInfo ObjectDigestInfo => null;

		public static V2Form GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static V2Form GetInstance(object obj)
		{
			return null;
		}

		public V2Form(GeneralNames issuerName)
		{
		}

		public V2Form(GeneralNames issuerName, IssuerSerial baseCertificateID)
		{
		}

		public V2Form(GeneralNames issuerName, ObjectDigestInfo objectDigestInfo)
		{
		}

		public V2Form(GeneralNames issuerName, IssuerSerial baseCertificateID, ObjectDigestInfo objectDigestInfo)
		{
		}

		private V2Form(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
