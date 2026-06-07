using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.IsisMtt.Ocsp
{
	public class RequestedCertificate : Asn1Encodable, IAsn1Choice
	{
		public enum Choice
		{
			Certificate = -1,
			PublicKeyCertificate = 0,
			AttributeCertificate = 1
		}

		private readonly X509CertificateStructure cert;

		private readonly byte[] publicKeyCert;

		private readonly byte[] attributeCert;

		public Choice Type => default(Choice);

		public static RequestedCertificate GetInstance(object obj)
		{
			return null;
		}

		public static RequestedCertificate GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		private RequestedCertificate(Asn1TaggedObject tagged)
		{
		}

		public RequestedCertificate(X509CertificateStructure certificate)
		{
		}

		public RequestedCertificate(Choice type, byte[] certificateOctets)
		{
		}

		public byte[] GetCertificateBytes()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
