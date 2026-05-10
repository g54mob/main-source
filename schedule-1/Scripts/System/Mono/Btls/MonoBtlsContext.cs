using System;
using System.Security.Cryptography.X509Certificates;
using Mono.Net.Security;
using Mono.Security.Interface;

namespace Mono.Btls
{
	internal class MonoBtlsContext : MobileTlsContext, IMonoBtlsBioMono
	{
		private X509Certificate2 remoteCertificate;

		private X509Certificate clientCertificate;

		private X509CertificateImplBtls nativeServerCertificate;

		private X509CertificateImplBtls nativeClientCertificate;

		private MonoBtlsSslCtx ctx;

		private MonoBtlsSsl ssl;

		private MonoBtlsBio bio;

		private MonoBtlsBio errbio;

		private MonoTlsConnectionInfo connectionInfo;

		private bool certificateValidated;

		private bool isAuthenticated;

		private bool connected;

		public override bool IsAuthenticated => false;

		internal override X509Certificate LocalClientCertificate => null;

		public override X509Certificate2 RemoteCertificate => null;

		public MonoBtlsContext(MobileAuthenticatedStream parent, MonoSslAuthenticationOptions options)
			: base(null, null)
		{
		}

		private static X509CertificateImplBtls GetPrivateCertificate(X509Certificate certificate)
		{
			return null;
		}

		private int VerifyCallback(MonoBtlsX509StoreCtx storeCtx)
		{
			return 0;
		}

		private int SelectCallback(string[] acceptableIssuers)
		{
			return 0;
		}

		private int ServerNameCallback()
		{
			return 0;
		}

		public override void StartHandshake()
		{
		}

		private void SetPrivateCertificate(X509CertificateImplBtls privateCert)
		{
		}

		private static Exception GetException(MonoBtlsSslError status)
		{
			return null;
		}

		public override bool ProcessHandshake()
		{
			return false;
		}

		private MonoBtlsSslError DoProcessHandshake()
		{
			return default(MonoBtlsSslError);
		}

		public override void FinishHandshake()
		{
		}

		private void InitializeConnection()
		{
		}

		private void GetPeerCertificate()
		{
		}

		private void InitializeSession()
		{
		}

		private static TlsProtocols GetProtocol(TlsProtocolCode protocol)
		{
			return default(TlsProtocols);
		}

		public override void Flush()
		{
		}

		public override (int, bool) Read(byte[] buffer, int offset, int size)
		{
			return default((int, bool));
		}

		public override (int, bool) Write(byte[] buffer, int offset, int size)
		{
			return default((int, bool));
		}

		public override void Renegotiate()
		{
		}

		public override void Shutdown()
		{
		}

		public override bool PendingRenegotiation()
		{
			return false;
		}

		private void Dispose<T>(ref T disposable) where T : class, IDisposable
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		int IMonoBtlsBioMono.Read(byte[] buffer, int offset, int size, out bool wantMore)
		{
			wantMore = default(bool);
			return 0;
		}

		bool IMonoBtlsBioMono.Write(byte[] buffer, int offset, int size)
		{
			return false;
		}

		void IMonoBtlsBioMono.Flush()
		{
		}

		void IMonoBtlsBioMono.Close()
		{
		}
	}
}
