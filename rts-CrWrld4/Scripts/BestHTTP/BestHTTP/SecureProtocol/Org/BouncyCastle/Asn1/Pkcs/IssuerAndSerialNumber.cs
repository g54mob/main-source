using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs
{
	public class IssuerAndSerialNumber : Asn1Encodable
	{
		private readonly X509Name name;

		private readonly DerInteger certSerialNumber;

		public X509Name Name => null;

		public DerInteger CertificateSerialNumber => null;

		public static IssuerAndSerialNumber GetInstance(object obj)
		{
			return null;
		}

		private IssuerAndSerialNumber(Asn1Sequence seq)
		{
		}

		public IssuerAndSerialNumber(X509Name name, BigInteger certSerialNumber)
		{
		}

		public IssuerAndSerialNumber(X509Name name, DerInteger certSerialNumber)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
