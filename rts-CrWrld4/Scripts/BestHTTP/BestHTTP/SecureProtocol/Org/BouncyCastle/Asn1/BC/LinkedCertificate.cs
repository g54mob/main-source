using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.BC
{
	public class LinkedCertificate : Asn1Encodable
	{
		private readonly DigestInfo mDigest;

		private readonly GeneralName mCertLocation;

		private X509Name mCertIssuer;

		private GeneralNames mCACerts;

		public virtual DigestInfo Digest => null;

		public virtual GeneralName CertLocation => null;

		public virtual X509Name CertIssuer => null;

		public virtual GeneralNames CACerts => null;

		public LinkedCertificate(DigestInfo digest, GeneralName certLocation)
		{
		}

		public LinkedCertificate(DigestInfo digest, GeneralName certLocation, X509Name certIssuer, GeneralNames caCerts)
		{
		}

		private LinkedCertificate(Asn1Sequence seq)
		{
		}

		public static LinkedCertificate GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
