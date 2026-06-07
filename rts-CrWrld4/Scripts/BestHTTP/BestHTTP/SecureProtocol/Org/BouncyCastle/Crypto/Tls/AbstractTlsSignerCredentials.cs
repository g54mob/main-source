namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class AbstractTlsSignerCredentials : AbstractTlsCredentials, TlsSignerCredentials, TlsCredentials
	{
		public virtual SignatureAndHashAlgorithm SignatureAndHashAlgorithm => null;

		public abstract byte[] GenerateCertificateSignature(byte[] hash);
	}
}
