namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class DefaultTlsAgreementCredentials : AbstractTlsAgreementCredentials
	{
		protected readonly Certificate mCertificate;

		protected readonly AsymmetricKeyParameter mPrivateKey;

		protected readonly IBasicAgreement mBasicAgreement;

		protected readonly bool mTruncateAgreement;

		public override Certificate Certificate => null;

		public DefaultTlsAgreementCredentials(Certificate certificate, AsymmetricKeyParameter privateKey)
		{
		}

		public override byte[] GenerateAgreement(AsymmetricKeyParameter peerPublicKey)
		{
			return null;
		}
	}
}
