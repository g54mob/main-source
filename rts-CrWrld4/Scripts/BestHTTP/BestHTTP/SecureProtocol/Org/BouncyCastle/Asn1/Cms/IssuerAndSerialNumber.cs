using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms
{
	public class IssuerAndSerialNumber : Asn1Encodable
	{
		private X509Name name;

		private DerInteger serialNumber;

		public X509Name Name => null;

		public DerInteger SerialNumber => null;

		public static IssuerAndSerialNumber GetInstance(object obj)
		{
			return null;
		}

		public IssuerAndSerialNumber(Asn1Sequence seq)
		{
		}

		public IssuerAndSerialNumber(X509Name name, BigInteger serialNumber)
		{
		}

		public IssuerAndSerialNumber(X509Name name, DerInteger serialNumber)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
