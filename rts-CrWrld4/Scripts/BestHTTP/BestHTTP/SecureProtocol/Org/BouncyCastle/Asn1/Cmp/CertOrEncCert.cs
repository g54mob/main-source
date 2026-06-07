using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CertOrEncCert : Asn1Encodable, IAsn1Choice
	{
		private readonly CmpCertificate certificate;

		private readonly EncryptedValue encryptedCert;

		public virtual CmpCertificate Certificate => null;

		public virtual EncryptedValue EncryptedCert => null;

		private CertOrEncCert(Asn1TaggedObject tagged)
		{
		}

		public static CertOrEncCert GetInstance(object obj)
		{
			return null;
		}

		public CertOrEncCert(CmpCertificate certificate)
		{
		}

		public CertOrEncCert(EncryptedValue encryptedCert)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
