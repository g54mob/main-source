using System;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Mono.Security.Interface;

namespace Mono.Net.Security
{
	internal abstract class MobileTlsContext : IDisposable
	{
		private ChainValidationHelper certificateValidator;

		internal MonoSslAuthenticationOptions Options { get; }

		internal MobileAuthenticatedStream Parent { get; }

		public MonoTlsSettings Settings => null;

		public abstract bool IsAuthenticated { get; }

		public bool IsServer { get; }

		internal string TargetHost { get; }

		protected string ServerName { get; }

		protected bool AskForClientCertificate { get; }

		protected SslProtocols EnabledProtocols { get; }

		protected X509CertificateCollection ClientCertificates { get; }

		internal X509Certificate LocalServerCertificate { get; private set; }

		internal abstract X509Certificate LocalClientCertificate { get; }

		public abstract X509Certificate2 RemoteCertificate { get; }

		protected MobileTlsContext(MobileAuthenticatedStream parent, MonoSslAuthenticationOptions options)
		{
		}

		protected void GetProtocolVersions(out TlsProtocolCode? min, out TlsProtocolCode? max)
		{
			min = null;
			max = null;
		}

		public abstract void StartHandshake();

		public abstract bool ProcessHandshake();

		public abstract void FinishHandshake();

		public abstract void Flush();

		public abstract (int, bool) Read(byte[] buffer, int offset, int count);

		public abstract (int, bool) Write(byte[] buffer, int offset, int count);

		public abstract void Shutdown();

		public abstract bool PendingRenegotiation();

		protected bool ValidateCertificate(X509Certificate2 leaf, X509Chain chain)
		{
			return false;
		}

		protected X509Certificate SelectServerCertificate(string serverIdentity)
		{
			return null;
		}

		protected X509Certificate SelectClientCertificate(string[] acceptableIssuers)
		{
			return null;
		}

		public abstract void Renegotiate();

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		~MobileTlsContext()
		{
		}
	}
}
