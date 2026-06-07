namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class DefaultTlsEncryptionCredentials : AbstractTlsEncryptionCredentials
	{
		protected readonly TlsContext mContext;

		protected readonly Certificate mCertificate;

		protected readonly AsymmetricKeyParameter mPrivateKey;

		public override Certificate Certificate => null;

		public DefaultTlsEncryptionCredentials(TlsContext context, Certificate certificate, AsymmetricKeyParameter privateKey)
		{
		}

		public override byte[] DecryptPreMasterSecret(byte[] encryptedPreMasterSecret)
		{
			return null;
		}
	}
}
