namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class TbsCertificateStructure : Asn1Encodable
	{
		internal Asn1Sequence seq;

		internal DerInteger version;

		internal DerInteger serialNumber;

		internal AlgorithmIdentifier signature;

		internal X509Name issuer;

		internal Time startDate;

		internal Time endDate;

		internal X509Name subject;

		internal SubjectPublicKeyInfo subjectPublicKeyInfo;

		internal DerBitString issuerUniqueID;

		internal DerBitString subjectUniqueID;

		internal X509Extensions extensions;

		public int Version => 0;

		public DerInteger VersionNumber => null;

		public DerInteger SerialNumber => null;

		public AlgorithmIdentifier Signature => null;

		public X509Name Issuer => null;

		public Time StartDate => null;

		public Time EndDate => null;

		public X509Name Subject => null;

		public SubjectPublicKeyInfo SubjectPublicKeyInfo => null;

		public DerBitString IssuerUniqueID => null;

		public DerBitString SubjectUniqueID => null;

		public X509Extensions Extensions => null;

		public static TbsCertificateStructure GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static TbsCertificateStructure GetInstance(object obj)
		{
			return null;
		}

		internal TbsCertificateStructure(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
