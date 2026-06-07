using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Ocsp
{
	public class ServiceLocator : Asn1Encodable
	{
		private readonly X509Name issuer;

		private readonly Asn1Object locator;

		public X509Name Issuer => null;

		public Asn1Object Locator => null;

		public static ServiceLocator GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static ServiceLocator GetInstance(object obj)
		{
			return null;
		}

		public ServiceLocator(X509Name issuer)
		{
		}

		public ServiceLocator(X509Name issuer, Asn1Object locator)
		{
		}

		private ServiceLocator(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
