using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CmpCertificate : Asn1Encodable, IAsn1Choice
	{
		private readonly X509CertificateStructure x509v3PKCert;

		private readonly AttributeCertificate x509v2AttrCert;

		public virtual bool IsX509v3PKCert => false;

		public virtual X509CertificateStructure X509v3PKCert => null;

		public virtual AttributeCertificate X509v2AttrCert => null;

		public CmpCertificate(AttributeCertificate x509v2AttrCert)
		{
		}

		public CmpCertificate(X509CertificateStructure x509v3PKCert)
		{
		}

		public static CmpCertificate GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
