using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ess
{
	public class EssCertID : Asn1Encodable
	{
		private Asn1OctetString certHash;

		private IssuerSerial issuerSerial;

		public IssuerSerial IssuerSerial => null;

		public static EssCertID GetInstance(object o)
		{
			return null;
		}

		public EssCertID(Asn1Sequence seq)
		{
		}

		public EssCertID(byte[] hash)
		{
		}

		public EssCertID(byte[] hash, IssuerSerial issuerSerial)
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
