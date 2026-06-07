namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class X509CertificateStructure : Asn1Encodable
	{
		private readonly TbsCertificateStructure tbsCert;

		private readonly AlgorithmIdentifier sigAlgID;

		private readonly DerBitString sig;

		public TbsCertificateStructure TbsCertificate => null;

		public int Version => 0;

		public DerInteger SerialNumber => null;

		public X509Name Issuer => null;

		public Time StartDate => null;

		public Time EndDate => null;

		public X509Name Subject => null;

		public SubjectPublicKeyInfo SubjectPublicKeyInfo => null;

		public AlgorithmIdentifier SignatureAlgorithm => null;

		public DerBitString Signature => null;

		public static X509CertificateStructure GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static X509CertificateStructure GetInstance(object obj)
		{
			return null;
		}

		public X509CertificateStructure(TbsCertificateStructure tbsCert, AlgorithmIdentifier sigAlgID, DerBitString sig)
		{
		}

		private X509CertificateStructure(Asn1Sequence seq)
		{
		}

		public byte[] GetSignatureOctets()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
