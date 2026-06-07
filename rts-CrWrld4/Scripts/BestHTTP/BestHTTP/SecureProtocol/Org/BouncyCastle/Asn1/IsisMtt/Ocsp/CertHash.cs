using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.Ocsp
{
	public class CertHash : Asn1Encodable
	{
		private readonly AlgorithmIdentifier hashAlgorithm;

		private readonly byte[] certificateHash;

		public AlgorithmIdentifier HashAlgorithm => null;

		public byte[] CertificateHash => null;

		public static CertHash GetInstance(object obj)
		{
			return null;
		}

		private CertHash(Asn1Sequence seq)
		{
		}

		public CertHash(AlgorithmIdentifier hashAlgorithm, byte[] certificateHash)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
