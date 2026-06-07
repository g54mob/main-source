namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class DefaultTlsClient : AbstractTlsClient
	{
		protected TlsDHVerifier mDHVerifier;

		public DefaultTlsClient()
		{
		}

		public DefaultTlsClient(TlsCipherFactory cipherFactory)
		{
		}

		public DefaultTlsClient(TlsCipherFactory cipherFactory, TlsDHVerifier dhVerifier)
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

		protected virtual TlsKeyExchange CreateDHKeyExchange(int keyExchange)
		{
			return null;
		}

		protected virtual TlsKeyExchange CreateDheKeyExchange(int keyExchange)
		{
			return null;
		}

		protected virtual TlsKeyExchange CreateECDHKeyExchange(int keyExchange)
		{
			return null;
		}

		protected virtual TlsKeyExchange CreateECDheKeyExchange(int keyExchange)
		{
			return null;
		}

		protected virtual TlsKeyExchange CreateRsaKeyExchange()
		{
			return null;
		}
	}
}
