using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class CertificationRequest : Asn1Encodable
	{
		protected CertificationRequestInfo reqInfo;

		protected AlgorithmIdentifier sigAlgId;

		protected DerBitString sigBits;

		public AlgorithmIdentifier SignatureAlgorithm => null;

		public DerBitString Signature => null;

		public static CertificationRequest GetInstance(object obj)
		{
			return null;
		}

		protected CertificationRequest()
		{
		}

		public CertificationRequest(CertificationRequestInfo requestInfo, AlgorithmIdentifier algorithm, DerBitString signature)
		{
		}

		public CertificationRequest(Asn1Sequence seq)
		{
		}

		public CertificationRequestInfo GetCertificationRequestInfo()
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
