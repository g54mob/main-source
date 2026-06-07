using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class CertifiedKeyPair : Asn1Encodable
	{
		private readonly CertOrEncCert certOrEncCert;

		private readonly EncryptedValue privateKey;

		private readonly PkiPublicationInfo publicationInfo;

		public virtual CertOrEncCert CertOrEncCert => null;

		public virtual EncryptedValue PrivateKey => null;

		public virtual PkiPublicationInfo PublicationInfo => null;

		private CertifiedKeyPair(Asn1Sequence seq)
		{
		}

		public static CertifiedKeyPair GetInstance(object obj)
		{
			return null;
		}

		public CertifiedKeyPair(CertOrEncCert certOrEncCert)
		{
		}

		public CertifiedKeyPair(CertOrEncCert certOrEncCert, EncryptedValue privateKey, PkiPublicationInfo publicationInfo)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
