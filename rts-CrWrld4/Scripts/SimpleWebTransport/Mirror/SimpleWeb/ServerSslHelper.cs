using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Mirror.SimpleWeb
{
	internal class ServerSslHelper
	{
		private readonly SslConfig config;

		private readonly X509Certificate2 certificate;

		public ServerSslHelper(SslConfig sslConfig)
		{
		}

		internal bool TryCreateStream(Connection conn)
		{
			return false;
		}

		private Stream CreateStream(NetworkStream stream)
		{
			return null;
		}

		private bool acceptClient(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return false;
		}
	}
}
