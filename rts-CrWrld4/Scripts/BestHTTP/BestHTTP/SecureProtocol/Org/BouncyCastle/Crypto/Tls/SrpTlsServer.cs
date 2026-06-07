using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class SrpTlsServer : AbstractTlsServer
	{
		protected TlsSrpIdentityManager mSrpIdentityManager;

		protected byte[] mSrpIdentity;

		protected TlsSrpLoginParameters mLoginParameters;

		public SrpTlsServer(TlsSrpIdentityManager srpIdentityManager)
		{
		}

		public SrpTlsServer(TlsCipherFactory cipherFactory, TlsSrpIdentityManager srpIdentityManager)
		{
		}

		protected virtual TlsSignerCredentials GetDsaSignerCredentials()
		{
			return null;
		}

		protected virtual TlsSignerCredentials GetRsaSignerCredentials()
		{
			return null;
		}

		protected override int[] GetCipherSuites()
		{
			return null;
		}

		public override void ProcessClientExtensions(IDictionary clientExtensions)
		{
		}

		public override int GetSelectedCipherSuite()
		{
			return 0;
		}

		public override TlsCredentials GetCredentials()
		{
			return null;
		}

		public override TlsKeyExchange GetKeyExchange()
		{
			return null;
		}

		protected virtual TlsKeyExchange CreateSrpKeyExchange(int keyExchange)
		{
			return null;
		}
	}
}
