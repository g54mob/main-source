using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class CertificateList : Asn1Encodable
	{
		private readonly TbsCertificateList tbsCertList;

		private readonly AlgorithmIdentifier sigAlgID;

		private readonly DerBitString sig;

		public TbsCertificateList TbsCertList => null;

		public AlgorithmIdentifier SignatureAlgorithm => null;

		public DerBitString Signature => null;

		public int Version => 0;

		public X509Name Issuer => null;

		public Time ThisUpdate => null;

		public Time NextUpdate => null;

		public static CertificateList GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static CertificateList GetInstance(object obj)
		{
			return null;
		}

		private CertificateList(Asn1Sequence seq)
		{
		}

		public CrlEntry[] GetRevokedCertificates()
		{
			return null;
		}

		public IEnumerable GetRevokedCertificateEnumeration()
		{
			return null;
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
