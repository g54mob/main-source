namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class PskTlsClient : AbstractTlsClient
	{
		protected TlsDHVerifier mDHVerifier;

		protected TlsPskIdentity mPskIdentity;

		public PskTlsClient(TlsPskIdentity pskIdentity)
		{
		}

		public PskTlsClient(TlsCipherFactory cipherFactory, TlsPskIdentity pskIdentity)
		{
		}

		public PskTlsClient(TlsCipherFactory cipherFactory, TlsDHVerifier dhVerifier, TlsPskIdentity pskIdentity)
		{
		}

		public override int[] GetCipherSuites()
		{
			return null;
		}

		public override TlsKeyExchange GetKeyExchange()
		{
			return null;
		}

		public override TlsAuthentication GetAuthentication()
		{
			return null;
		}

		protected virtual TlsKeyExchange CreatePskKeyExchange(int keyExchange)
		{
			return null;
		}
	}
}
