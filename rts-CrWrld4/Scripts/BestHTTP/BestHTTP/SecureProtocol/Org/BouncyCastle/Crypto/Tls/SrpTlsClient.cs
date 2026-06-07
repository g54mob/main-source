using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class SrpTlsClient : AbstractTlsClient
	{
		protected TlsSrpGroupVerifier mGroupVerifier;

		protected byte[] mIdentity;

		protected byte[] mPassword;

		protected virtual bool RequireSrpServerExtension => false;

		public SrpTlsClient(byte[] identity, byte[] password)
		{
		}

		public SrpTlsClient(TlsCipherFactory cipherFactory, byte[] identity, byte[] password)
		{
		}

		public SrpTlsClient(TlsCipherFactory cipherFactory, TlsSrpGroupVerifier groupVerifier, byte[] identity, byte[] password)
		{
		}

		public override int[] GetCipherSuites()
		{
			return null;
		}

		public override IDictionary GetClientExtensions()
		{
			return null;
		}

		public override void ProcessServerExtensions(IDictionary serverExtensions)
		{
		}

		public override TlsKeyExchange GetKeyExchange()
		{
			return null;
		}

		public override TlsAuthentication GetAuthentication()
		{
			return null;
		}

		protected virtual TlsKeyExchange CreateSrpKeyExchange(int keyExchange)
		{
			return null;
		}
	}
}
