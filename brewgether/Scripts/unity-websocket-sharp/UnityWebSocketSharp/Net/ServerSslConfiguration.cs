using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace UnityWebSocketSharp.Net
{
	internal class ServerSslConfiguration
	{
		private bool _checkCertRevocation;

		private bool _clientCertRequired;

		private RemoteCertificateValidationCallback _clientCertValidationCallback;

		private SslProtocols _enabledSslProtocols;

		private X509Certificate2 _serverCert;

		public bool CheckCertificateRevocation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ClientCertificateRequired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public RemoteCertificateValidationCallback ClientCertificateValidationCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SslProtocols EnabledSslProtocols
		{
			get
			{
				return default(SslProtocols);
			}
			set
			{
			}
		}

		public X509Certificate2 ServerCertificate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ServerSslConfiguration()
		{
		}

		public ServerSslConfiguration(ServerSslConfiguration configuration)
		{
		}

		private static bool defaultValidateClientCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return false;
		}
	}
}
