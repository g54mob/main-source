using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Mirror.SimpleWeb
{
	internal class ClientSslHelper
	{
		internal bool TryCreateStream(Connection conn, Uri uri)
		{
			return false;
		}

		private Stream CreateStream(NetworkStream stream, Uri uri)
		{
			return null;
		}

		private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return false;
		}
	}
}
