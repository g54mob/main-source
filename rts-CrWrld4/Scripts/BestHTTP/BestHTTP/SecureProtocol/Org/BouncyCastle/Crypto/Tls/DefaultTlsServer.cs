using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class DefaultTlsServer : AbstractTlsServer
	{
		public DefaultTlsServer()
		{
		}

		public DefaultTlsServer(TlsCipherFactory cipherFactory)
		{
		}

		protected virtual TlsSignerCredentials GetDsaSignerCredentials()
		{
			return null;
		}

		protected virtual TlsSignerCredentials GetECDsaSignerCredentials()
		{
			return null;
		}

		protected virtual TlsEncryptionCredentials GetRsaEncryptionCredentials()
		{
			return null;
		}

		protected virtual TlsSignerCredentials GetRsaSignerCredentials()
		{
			return null;
		}

		protected virtual DHParameters GetDHParameters()
		{
			return null;
		}

		protected override int[] GetCipherSuites()
		{
			return null;
		}

		public override TlsCredentials GetCredentials()
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
