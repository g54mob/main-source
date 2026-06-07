using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ess
{
	public class OtherCertID : Asn1Encodable
	{
		private Asn1Encodable otherCertHash;

		private IssuerSerial issuerSerial;

		public AlgorithmIdentifier AlgorithmHash => null;

		public IssuerSerial IssuerSerial => null;

		public static OtherCertID GetInstance(object o)
		{
			return null;
		}

		public OtherCertID(Asn1Sequence seq)
		{
		}

		public OtherCertID(AlgorithmIdentifier algId, byte[] digest)
		{
		}

		public OtherCertID(AlgorithmIdentifier algId, byte[] digest, IssuerSerial issuerSerial)
		{
		}

		public byte[] GetCertHash()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
